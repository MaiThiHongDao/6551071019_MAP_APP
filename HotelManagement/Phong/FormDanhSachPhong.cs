using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Phong;

/// <summary>Danh sách phòng + Thêm / Sửa / Xóa (xóa mềm).</summary>
public partial class FormDanhSachPhong : Form
{
    private readonly DataGridView dgv = new();
    private readonly TextBox txtTim = new() { Width = 200 };

    public FormDanhSachPhong()
    {
        Text = "Danh sách phòng";
        Font = new Font("Segoe UI", 11F);

        var panelTren = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 58, Padding = new Padding(10, 10, 0, 0), BackColor = Color.AliceBlue };
        panelTren.Controls.Add(new Label { Text = "Tìm mã phòng:", AutoSize = true, Margin = new Padding(3, 6, 3, 0) });
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

        // Cột ảnh: icon phòng (đầu dòng) + icon Sửa / Xóa (cuối dòng), giống mẫu của thầy
        dgv.Columns.Add(TaoCotAnh("colIcon", "", Properties.Resources.Phong));
        dgv.Columns.Add(TaoCotChu("MaPH", "Mã phòng"));
        dgv.Columns.Add(TaoCotChu("TenLPH", "Loại phòng"));
        dgv.Columns.Add(TaoCotChu("TTPH", "Trạng thái phòng"));
        dgv.Columns.Add(TaoCotChu("TTDD", "Tình trạng dọn dẹp"));
        dgv.Columns.Add(TaoCotChu("GhiChu", "Ghi chú"));
        dgv.Columns.Add(TaoCotAnh("colSua", "Sửa", Properties.Resources.edit));
        dgv.Columns.Add(TaoCotAnh("colXoa", "Xóa", Properties.Resources.delete));
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

    private static DataGridViewImageColumn TaoCotAnh(string ten, string tieuDe, Image anh) => new()
    {
        Name = ten,
        HeaderText = tieuDe,
        Image = anh,
        ImageLayout = DataGridViewImageCellLayout.Zoom,
        AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
        Width = 50,
        Resizable = DataGridViewTriState.False,
        SortMode = DataGridViewColumnSortMode.NotSortable
    };

    // Bấm vào icon Sửa / Xóa trên dòng
    private void dgv_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
        string tenCot = dgv.Columns[e.ColumnIndex].Name;
        if (tenCot == "colSua") btnSua_Click(null, EventArgs.Empty);
        else if (tenCot == "colXoa") btnXoa_Click(null, EventArgs.Empty);
    }

    private static Button TaoNut(string text) => new() { Text = text, Width = 100, Height = 32, Margin = new Padding(12, 0, 0, 0) };

    private string? MaPhongDangChon() => dgv.CurrentRow?.Cells["MaPH"].Value?.ToString();

    private void TaiLaiDanhSach()
    {
        try
        {
            string tim = txtTim.Text.Trim();
            using var db = new HotelManagementContext();
            var query = db.Phongs.AsNoTracking().Where(p => p.DaXoa != true);
            if (tim.Length > 0) query = query.Where(p => p.MaPh.Contains(tim));

            var ds = query.OrderBy(p => p.MaPh)
                .Select(p => new
                {
                    MaPH = p.MaPh,
                    TenLPH = p.MaLphNavigation.TenLph,
                    TTPH = p.Ttph,
                    TTDD = p.Ttdd,
                    GhiChu = p.GhiChu
                })
                .ToList();

            dgv.DataSource = ds;
            DatTieuDe("MaPH", "Mã phòng");
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

    private void btnThem_Click(object? sender, EventArgs e)
    {
        using var f = new FormThemPhong();
        if (f.ShowDialog(this) == DialogResult.OK) TaiLaiDanhSach();
    }

    private void btnSua_Click(object? sender, EventArgs e)
    {
        string? ma = MaPhongDangChon();
        if (ma == null)
        {
            MessageBox.Show("Vui lòng chọn phòng cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        using var f = new FormSuaPhong(ma);
        if (f.ShowDialog(this) == DialogResult.OK) TaiLaiDanhSach();
    }

    private void btnXoa_Click(object? sender, EventArgs e)
    {
        string? ma = MaPhongDangChon();
        if (ma == null)
        {
            MessageBox.Show("Vui lòng chọn phòng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        try
        {
            using var db = new HotelManagementContext();
            var phong = db.Phongs.FirstOrDefault(p => p.MaPh == ma && p.DaXoa != true);
            if (phong == null)
            {
                MessageBox.Show("Phòng không tồn tại hoặc đã bị xóa.");
                TaiLaiDanhSach();
                return;
            }
            if (phong.Ttph == "Đang thuê" || phong.Ttph == "Đã đặt")
            {
                MessageBox.Show($"Phòng {ma} đang ở trạng thái \"{phong.Ttph}\" nên không thể xóa.",
                    "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show($"Bạn có chắc muốn xóa phòng {ma}?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            phong.DaXoa = true;   // xóa mềm
            db.SaveChanges();
            TaiLaiDanhSach();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi khi xóa phòng: " + ex.Message);
        }
    }
}
