using HotelManagement.Helpers;
using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Phong;

public partial class FormSuaPhong : FormNhapLieu
{
    private readonly string maPhong;
    private readonly TextBox txtMaPH;
    private readonly ComboBox cbLoaiPhong;
    private readonly ComboBox cbTrangThai;
    private readonly ComboBox cbDonDep;
    private readonly TextBox txtGhiChu;

    public FormSuaPhong(string maPhong) : base("Sửa phòng " + maPhong)
    {
        this.maPhong = maPhong;
        txtMaPH = ThemTruong("Mã phòng", new TextBox { ReadOnly = true, Text = maPhong });
        cbLoaiPhong = ThemTruong("Loại phòng", new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList });
        cbTrangThai = ThemTruong("Trạng thái phòng", new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList });
        cbDonDep = ThemTruong("Tình trạng dọn dẹp", new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList });
        txtGhiChu = ThemTruong("Ghi chú", new TextBox { Multiline = true, Height = 70, MaxLength = 100 });

        cbTrangThai.Items.AddRange(new object[] { "Bình thường", "Đã đặt", "Đang thuê", "Đang sửa chữa" });
        cbDonDep.Items.AddRange(new object[] { "Đã dọn dẹp", "Chưa dọn dẹp" });

        Load += (_, _) => NapDuLieu();
    }

    private void NapDuLieu()
    {
        try
        {
            using var db = new HotelManagementContext();

            cbLoaiPhong.DataSource = db.LoaiPhongs.AsNoTracking().OrderBy(l => l.MaLph)
                .Select(l => new { l.MaLph, l.TenLph }).ToList();
            cbLoaiPhong.DisplayMember = "TenLph";
            cbLoaiPhong.ValueMember = "MaLph";

            var p = db.Phongs.AsNoTracking()
                .Where(x => x.MaPh == maPhong && x.DaXoa != true)
                .Select(x => new { x.Ttph, x.Ttdd, x.MaLph, x.GhiChu })
                .FirstOrDefault();

            if (p == null)
            {
                Loi("Phòng không tồn tại hoặc đã bị xóa.");
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            cbLoaiPhong.SelectedValue = p.MaLph;
            cbTrangThai.SelectedIndex = cbTrangThai.FindStringExact(p.Ttph);
            cbDonDep.SelectedIndex = cbDonDep.FindStringExact(p.Ttdd);
            txtGhiChu.Text = p.GhiChu ?? "";
        }
        catch (Exception ex)
        {
            Loi("Lỗi tải thông tin phòng: " + ex.Message);
        }
    }

    protected override void Luu()
    {
        if (cbLoaiPhong.SelectedValue == null) { Loi("Vui lòng chọn loại phòng."); return; }
        string ghiChu = txtGhiChu.Text.Trim();

        try
        {
            using var db = new HotelManagementContext();
            var phong = db.Phongs.FirstOrDefault(p => p.MaPh == maPhong && p.DaXoa != true);
            if (phong == null) { Loi("Phòng không tồn tại hoặc đã bị xóa."); return; }

            phong.MaLph = cbLoaiPhong.SelectedValue.ToString()!;
            phong.Ttph = cbTrangThai.Text;
            phong.Ttdd = cbDonDep.Text;
            phong.GhiChu = ghiChu.Length == 0 ? null : ghiChu;
            db.SaveChanges();

            MessageBox.Show("Cập nhật phòng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LuuXong();
        }
        catch (Exception ex)
        {
            Loi("Lỗi khi cập nhật phòng: " + (ex.InnerException?.Message ?? ex.Message));
        }
    }
}
