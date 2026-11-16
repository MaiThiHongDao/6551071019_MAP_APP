using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.LoaiPhong;

/// <summary>Danh sách loại phòng + Thêm / Sửa / Xóa.</summary>
public partial class FormDanhSachLoaiPhong : Form
{
    private readonly DataGridView dgv = new();
    private readonly TextBox txtTim = new() { Width = 200 };

    public FormDanhSachLoaiPhong()
    {
        Text = "Danh sách loại phòng";
        Font = new Font("Segoe UI", 11F);

        var panelTren = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 58, Padding = new Padding(10, 10, 0, 0), BackColor = Color.AliceBlue };
        panelTren.Controls.Add(new Label { Text = "Tìm loại phòng:", AutoSize = true, Margin = new Padding(3, 6, 3, 0) });
        panelTren.Controls.Add(new PictureBox { Image = Properties.Resources.search, Size = new Size(30, 30), SizeMode = PictureBoxSizeMode.Zoom, Margin = new Padding(6, 3, 0, 0), TabStop = false });   // icon tìm kiếm (Resources.search)
        panelTren.Controls.Add(txtTim);
        var btnThem = TaoNut("Thêm");
        var btnSua = TaoNut("Sửa");
        var btnXoa = TaoNut("Xóa");
        var btnLamMoi = TaoNut("Làm mới");
        panelTren.Controls.AddRange(new Control[] { btnThem, btnSua, btnXoa, btnLamMoi });

        dgv.Dock = DockStyle.Fill;
        dgv.ReadOnly = true;
        dgv.AllowUserToAddRows = false;
        dgv.AllowUserToDeleteRows = false;
        dgv.MultiSelect = false;
        dgv.RowHeadersVisible = false;
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgv.BackgroundColor = Color.White;
        dgv.RowTemplate.Height = 40;
        dgv.AutoGenerateColumns = false;

        // Cột ảnh: icon giường (đầu dòng) + icon Tiện nghi / Cập nhật (cuối dòng), giống mẫu của thầy
        dgv.Columns.Add(TaoCotAnh("colIcon", "", Properties.Resources.Giuong, 50));
        dgv.Columns.Add(TaoCotChu("MaLPH", "Mã loại"));
        dgv.Columns.Add(TaoCotChu("TenLPH", "Tên loại phòng"));
        dgv.Columns.Add(TaoCotChu("SoGiuong", "Số giường"));
        dgv.Columns.Add(TaoCotChu("SoNguoiToiDa", "Số người tối đa"));
        dgv.Columns.Add(TaoCotChu("GiaNgay", "Giá theo ngày"));
        dgv.Columns.Add(TaoCotChu("GiaGio", "Giá theo giờ"));
        dgv.Columns["GiaNgay"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        dgv.Columns["GiaGio"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        dgv.Columns.Add(TaoCotAnh("colTienNghi", "Tiện nghi", Properties.Resources.details, 60));
        dgv.Columns.Add(TaoCotAnh("colSua", "Cập nhật", Properties.Resources.edit, 70));
        dgv.CellClick += dgv_CellClick;

        Controls.Add(dgv);
        Controls.Add(panelTren);
        dgv.BringToFront();

        txtTim.TextChanged += (_, _) => TaiLaiDanhSach();
        btnLamMoi.Click += (_, _) => TaiLaiDanhSach();
        btnThem.Click += btnThem_Click;
        btnSua.Click += btnSua_Click;
        btnXoa.Click += btnXoa_Click;
        dgv.CellDoubleClick += (_, e) => { if (e.RowIndex >= 0) btnSua_Click(null, EventArgs.Empty); };
        Load += (_, _) => TaiLaiDanhSach();
    }

    private static DataGridViewTextBoxColumn TaoCotChu(string ten, string tieuDe) =>
        new() { Name = ten, DataPropertyName = ten, HeaderText = tieuDe, SortMode = DataGridViewColumnSortMode.Automatic };

    private static DataGridViewImageColumn TaoCotAnh(string ten, string tieuDe, Image anh, int doRong) => new()
    {
        Name = ten,
        HeaderText = tieuDe,
        Image = anh,
        ImageLayout = DataGridViewImageCellLayout.Zoom,
        AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
        Width = doRong,
        Resizable = DataGridViewTriState.False,
        SortMode = DataGridViewColumnSortMode.NotSortable
    };

    // Bấm vào icon Tiện nghi / Cập nhật trên dòng
    private void dgv_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
        string tenCot = dgv.Columns[e.ColumnIndex].Name;
        if (tenCot == "colSua")
        {
            btnSua_Click(null, EventArgs.Empty);
        }
        else if (tenCot == "colTienNghi")
        {
            string? ma = dgv.Rows[e.RowIndex].Cells["MaLPH"].Value?.ToString();
            string? ten = dgv.Rows[e.RowIndex].Cells["TenLPH"].Value?.ToString();
            MessageBox.Show($"Chức năng chi tiết tiện nghi của loại phòng {ten} ({ma}) đang được xây dựng.",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private static Button TaoNut(string text) => new() { Text = text, Width = 100, Height = 32, Margin = new Padding(12, 0, 0, 0) };

    private string? MaLoaiDangChon() => dgv.CurrentRow?.Cells["MaLPH"].Value?.ToString();

    private void TaiLaiDanhSach()
    {
        try
        {
            string tim = txtTim.Text.Trim();
            using var db = new HotelManagementContext();
            var query = db.LoaiPhongs.AsNoTracking().AsQueryable();
            if (tim.Length > 0)
                query = query.Where(l => l.MaLph.Contains(tim) || l.TenLph.Contains(tim));

            dgv.DataSource = query.OrderBy(l => l.MaLph)
                .Select(l => new
                {
                    MaLPH = l.MaLph,
                    TenLPH = l.TenLph,
                    SoGiuong = l.SoGiuong,
                    SoNguoiToiDa = l.SoNguoiToiDa,
                    GiaNgay = l.GiaNgay,
                    GiaGio = l.GiaGio
                })
                .ToList();

            DatTieuDe("MaLPH", "Mã loại");
            DatTieuDe("TenLPH", "Tên loại phòng");
            DatTieuDe("SoGiuong", "Số giường");
            DatTieuDe("SoNguoiToiDa", "Số người tối đa");
            DatTieuDe("GiaNgay", "Giá theo ngày");
            DatTieuDe("GiaGio", "Giá theo giờ");
            foreach (var c in new[] { "GiaNgay", "GiaGio" })
                if (dgv.Columns.Contains(c)) dgv.Columns[c].DefaultCellStyle.Format = "N0";
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi tải danh sách loại phòng: " + ex.Message);
        }
    }

    private void DatTieuDe(string cot, string tieuDe)
    {
        if (dgv.Columns.Contains(cot)) dgv.Columns[cot].HeaderText = tieuDe;
    }

    private void btnThem_Click(object? sender, EventArgs e)
    {
        using var f = new FormThemLoaiPhong();
        if (f.ShowDialog(this) == DialogResult.OK) TaiLaiDanhSach();
    }

    private void btnSua_Click(object? sender, EventArgs e)
    {
        string? ma = MaLoaiDangChon();
        if (ma == null)
        {
            MessageBox.Show("Vui lòng chọn loại phòng cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        using var f = new FormSuaLoaiPhong(ma);
        if (f.ShowDialog(this) == DialogResult.OK) TaiLaiDanhSach();
    }

    private void btnXoa_Click(object? sender, EventArgs e)
    {
        string? ma = MaLoaiDangChon();
        if (ma == null)
        {
            MessageBox.Show("Vui lòng chọn loại phòng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        try
        {
            using var db = new HotelManagementContext();

            // Bảng LoaiPhong không có cột DaXoa nên xóa thật; không cho xóa nếu còn phòng thuộc loại này
            if (db.Phongs.Any(p => p.MaLph == ma && p.DaXoa != true))
            {
                MessageBox.Show($"Vẫn còn phòng thuộc loại {ma} nên không thể xóa.",
                    "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show($"Bạn có chắc muốn xóa loại phòng {ma}?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var loai = db.LoaiPhongs.FirstOrDefault(l => l.MaLph == ma);
            if (loai != null)
            {
                db.LoaiPhongs.Remove(loai);
                db.SaveChanges();
            }
            TaiLaiDanhSach();
        }
        catch (Exception ex)
        {
            // Thường do còn dữ liệu liên quan (phòng đã xóa mềm, tiện nghi...) tham chiếu tới loại phòng này
            MessageBox.Show("Không thể xóa loại phòng: " + (ex.InnerException?.Message ?? ex.Message));
        }
    }
}
