using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.SoDoPhong;

/// <summary>Sơ đồ phòng: xem tình trạng các phòng, lọc theo trạng thái / loại phòng / dọn dẹp / mã phòng / ngày trống.</summary>
public partial class FormSoDoPhong : Form
{
    private readonly DataGridView dgv = new();
    private readonly TextBox txtTimMaPhong = new() { Width = 160 };
    private readonly DateTimePicker dtNgayChon = new() { Width = 150, Format = DateTimePickerFormat.Short, ShowCheckBox = true, Checked = false };
    private readonly Button btnDatPhong = new() { Text = "Đặt phòng", Width = 120, Height = 32 };
    private readonly ToolTip toolTip = new();

    // Mỗi nhóm lọc: danh sách (nhãn, giá trị lọc). Giá trị null = "Tất cả".
    private readonly List<(RadioButton Rdb, string? GiaTri)> nhomTrangThai = new();
    private readonly List<(RadioButton Rdb, string? GiaTri)> nhomLoaiPhong = new();
    private readonly List<(RadioButton Rdb, string? GiaTri)> nhomDonDep = new();

    private bool dangKhoiTao;

    public FormSoDoPhong()
    {
        Text = "Sơ đồ phòng";
        Font = new Font("Segoe UI", 11F);
        KhoiTaoGiaoDien();
        Load += FormSoDoPhong_Load;
    }

    private void KhoiTaoGiaoDien()
    {
        // ---- Panel bên trái: 3 nhóm lọc ----
        var panelLoc = new Panel { Dock = DockStyle.Left, Width = 270, BackColor = Color.GreenYellow, AutoScroll = true };

        var gbTrangThai = TaoNhom("Trạng thái phòng", nhomTrangThai,
            new[] { ("Phòng trống", "Bình thường"), ("Phòng đã đặt", "Đã đặt"), ("Phòng đang thuê", "Đang thuê"), ("Phòng đang sửa chữa", "Đang sửa chữa") },
            "Tất cả phòng");
        var gbLoai = TaoNhom("Loại phòng", nhomLoaiPhong, Array.Empty<(string, string)>(), "Tất cả loại");
        var gbDonDep = TaoNhom("Tình trạng dọn dẹp", nhomDonDep,
            new[] { ("Đã dọn dẹp", "Đã dọn dẹp"), ("Chưa dọn dẹp", "Chưa dọn dẹp") }, "Tất cả");

        panelLoc.Controls.Add(gbTrangThai);
        panelLoc.Controls.Add(gbLoai);
        PanelLoc = panelLoc;
        GbLoai = gbLoai;
        GbTrangThai = gbTrangThai;
        GbDonDep = gbDonDep;
        panelLoc.Controls.Add(gbDonDep);
        SapXepNhom();

        // ---- Thanh trên: tìm mã phòng, ngày, đặt phòng ----
        var panelTren = new FlowLayoutPanel
        {
            Dock = DockStyle.Top,
            Height = 56,
            Padding = new Padding(10, 10, 0, 0),
            BackColor = Color.Honeydew
        };
        panelTren.Controls.Add(new Label { Text = "Mã phòng:", AutoSize = true, Margin = new Padding(3, 6, 3, 0) });
        panelTren.Controls.Add(new PictureBox { Image = Properties.Resources.search, Size = new Size(30, 30), SizeMode = PictureBoxSizeMode.Zoom, Margin = new Padding(6, 3, 0, 0), TabStop = false });   // icon tìm kiếm (Resources.search)
        panelTren.Controls.Add(txtTimMaPhong);
        panelTren.Controls.Add(new Label { Text = "Ngày còn trống:", AutoSize = true, Margin = new Padding(20, 6, 3, 0) });
        panelTren.Controls.Add(dtNgayChon);
        panelTren.Controls.Add(btnDatPhong);
        toolTip.SetToolTip(txtTimMaPhong, "Ví dụ: 101, P20...");
        toolTip.SetToolTip(dtNgayChon, "Tick để chỉ xem các phòng còn trống vào ngày chọn");

        // ---- Lưới ----
        dgv.Dock = DockStyle.Fill;
        dgv.ReadOnly = true;
        dgv.AllowUserToAddRows = false;
        dgv.AllowUserToDeleteRows = false;
        dgv.MultiSelect = false;
        dgv.RowHeadersVisible = false;
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgv.BackgroundColor = Color.White;
        dgv.CellFormatting += Dgv_CellFormatting;

        Controls.Add(dgv);
        Controls.Add(panelTren);
        Controls.Add(panelLoc);
        dgv.BringToFront();

        txtTimMaPhong.TextChanged += (_, _) => { if (!dangKhoiTao) TaiLaiDanhSach(); };
        dtNgayChon.ValueChanged += (_, _) => { if (!dangKhoiTao) TaiLaiDanhSach(); };
        btnDatPhong.Click += btnDatPhong_Click;
    }

    private Panel PanelLoc = null!;
    private GroupBox GbTrangThai = null!, GbLoai = null!, GbDonDep = null!;

    /// <summary>Tạo GroupBox chứa các RadioButton (mỗi GroupBox là một nhóm chọn độc lập).</summary>
    private GroupBox TaoNhom(string tieuDe, List<(RadioButton, string?)> luu, IEnumerable<(string Nhan, string Gt)> muc, string nhanTatCa)
    {
        var gb = new GroupBox { Text = tieuDe, Width = 250, Font = new Font("Segoe UI", 11F, FontStyle.Bold) };
        var rdbTatCa = ThemRadio(gb, luu, nhanTatCa, null);
        rdbTatCa.Checked = true;
        foreach (var (nhan, gt) in muc) ThemRadio(gb, luu, nhan, gt);
        CapNhatChieuCao(gb);
        return gb;
    }

    private RadioButton ThemRadio(GroupBox gb, List<(RadioButton, string?)> luu, string nhan, string? giaTri)
    {
        var rdb = new RadioButton
        {
            Text = nhan,
            AutoSize = true,
            Font = new Font("Segoe UI", 11F, FontStyle.Regular),
            Location = new Point(12, 28 + 30 * gb.Controls.Count)
        };
        rdb.CheckedChanged += (_, _) => { if (!dangKhoiTao && rdb.Checked) TaiLaiDanhSach(); };
        gb.Controls.Add(rdb);
        luu.Add((rdb, giaTri));
        return rdb;
    }

    private static void CapNhatChieuCao(GroupBox gb) => gb.Height = 40 + 30 * gb.Controls.Count;

    private void SapXepNhom()
    {
        GbTrangThai.Location = new Point(8, 8);
        GbLoai.Location = new Point(8, GbTrangThai.Bottom + 8);
        GbDonDep.Location = new Point(8, GbLoai.Bottom + 8);
    }

    private void FormSoDoPhong_Load(object? sender, EventArgs e)
    {
        dangKhoiTao = true;
        try
        {
            // Nạp các loại phòng từ CSDL để tạo nút lọc
            using var db = new HotelManagementContext();
            var dsLoai = db.LoaiPhongs.AsNoTracking().OrderBy(l => l.MaLph).Select(l => new { l.MaLph, l.TenLph }).ToList();
            foreach (var l in dsLoai) ThemRadio(GbLoai, nhomLoaiPhong, "Phòng " + l.TenLph.ToLower(), l.MaLph);
            CapNhatChieuCao(GbLoai);
            SapXepNhom();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi tải loại phòng: " + ex.Message);
        }
        dangKhoiTao = false;
        TaiLaiDanhSach();
    }

    private static string? GiaTriDangChon(List<(RadioButton Rdb, string? GiaTri)> nhom) =>
        nhom.FirstOrDefault(x => x.Rdb.Checked).GiaTri;

    private string? MaPhongDangChon() => dgv.CurrentRow?.Cells["MaPH"].Value?.ToString();

    private void btnDatPhong_Click(object? sender, EventArgs e)
    {
        string? maPhong = MaPhongDangChon();
        MessageBox.Show(
            "Chức năng đặt phòng đang được xây dựng."
            + (maPhong != null ? Environment.NewLine + "Phòng đang chọn: " + maPhong : ""),
            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void TaiLaiDanhSach()
    {
        try
        {
            string? ttph = GiaTriDangChon(nhomTrangThai);
            string? maLph = GiaTriDangChon(nhomLoaiPhong);
            string? ttdd = GiaTriDangChon(nhomDonDep);
            string maPhong = txtTimMaPhong.Text.Trim();

            using var db = new HotelManagementContext();
            var query = db.Phongs.AsNoTracking().Where(p => p.DaXoa != true);

            if (ttph != null) query = query.Where(p => p.Ttph == ttph);
            if (maLph != null) query = query.Where(p => p.MaLph == maLph);
            if (ttdd != null) query = query.Where(p => p.Ttdd == ttdd);
            if (maPhong.Length > 0) query = query.Where(p => p.MaPh.Contains(maPhong));

            // Nếu tick chọn ngày: chỉ giữ phòng bình thường và không có phiếu đặt nào bao trùm ngày đó
            if (dtNgayChon.Checked)
            {
                DateTime ngay = dtNgayChon.Value.Date;
                query = query.Where(p => p.Ttph == "Bình thường"
                    && !p.Ctdps.Any(c => c.DaXoa != true
                        && ngay >= c.CheckIn.Date
                        && ngay < c.CheckOut.Date));
            }

            var ds = query.OrderBy(p => p.MaPh)
                .Select(p => new { p.MaPh, TenLph = p.MaLphNavigation.TenLph, p.Ttph, p.Ttdd, p.GhiChu })
                .ToList();

            dgv.DataSource = ds.Select(p => new
            {
                MaPH = p.MaPh,
                Tang = p.MaPh.Length > 1 ? p.MaPh.Substring(1, 1) : "",
                TenLPH = p.TenLph,
                TTPH = p.Ttph,
                TTDD = p.Ttdd,
                GhiChu = p.GhiChu
            }).ToList();

            DatTieuDe("MaPH", "Mã phòng");
            DatTieuDe("Tang", "Tầng");
            DatTieuDe("TenLPH", "Loại phòng");
            DatTieuDe("TTPH", "Trạng thái phòng");
            DatTieuDe("TTDD", "Tình trạng dọn dẹp");
            DatTieuDe("GhiChu", "Ghi chú");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi tải danh sách phòng: " + ex.Message);
        }
    }

    private void DatTieuDe(string cot, string tieuDe)
    {
        if (dgv.Columns.Contains(cot)) dgv.Columns[cot].HeaderText = tieuDe;
    }

    // Tô màu ô "Trạng thái phòng" cho dễ nhìn trực quan
    private void Dgv_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0 || e.Value is not string s) return;
        if (dgv.Columns[e.ColumnIndex].Name != "TTPH") return;
        e.CellStyle.BackColor = s switch
        {
            "Bình thường" => Color.LightGreen,
            "Đã đặt" => Color.Khaki,
            "Đang thuê" => Color.LightSalmon,
            "Đang sửa chữa" => Color.LightGray,
            _ => e.CellStyle.BackColor
        };
    }
}
