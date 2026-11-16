using HotelManagement.Helpers;
using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.LoaiPhong;

public partial class FormSuaLoaiPhong : FormNhapLieu
{
    private readonly string maLoai;
    private readonly TextBox txtMaLPH;
    private readonly TextBox txtTenLPH;
    private readonly NumericUpDown nudSoGiuong;
    private readonly NumericUpDown nudSoNguoi;
    private readonly NumericUpDown nudGiaNgay;
    private readonly NumericUpDown nudGiaGio;

    public FormSuaLoaiPhong(string maLoai) : base("Sửa loại phòng " + maLoai)
    {
        this.maLoai = maLoai;
        txtMaLPH = ThemTruong("Mã loại phòng", new TextBox { ReadOnly = true, Text = maLoai });
        txtTenLPH = ThemTruong("Tên loại phòng", new TextBox { MaxLength = 20 });
        nudSoGiuong = ThemTruong("Số giường", new NumericUpDown { Minimum = 1, Maximum = 20, Value = 1 });
        nudSoNguoi = ThemTruong("Số người tối đa", new NumericUpDown { Minimum = 1, Maximum = 50, Value = 2 });
        nudGiaNgay = ThemTruong("Giá theo ngày", new NumericUpDown { Minimum = 0, Maximum = 1_000_000_000, Increment = 10000, ThousandsSeparator = true });
        nudGiaGio = ThemTruong("Giá theo giờ", new NumericUpDown { Minimum = 0, Maximum = 1_000_000_000, Increment = 10000, ThousandsSeparator = true });

        Load += (_, _) => NapDuLieu();
    }

    private void NapDuLieu()
    {
        try
        {
            using var db = new HotelManagementContext();
            var l = db.LoaiPhongs.AsNoTracking().FirstOrDefault(x => x.MaLph == maLoai);
            if (l == null)
            {
                Loi("Loại phòng không tồn tại.");
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }
            txtTenLPH.Text = l.TenLph;
            nudSoGiuong.Value = Math.Clamp(l.SoGiuong, (int)nudSoGiuong.Minimum, (int)nudSoGiuong.Maximum);
            nudSoNguoi.Value = Math.Clamp(l.SoNguoiToiDa, (int)nudSoNguoi.Minimum, (int)nudSoNguoi.Maximum);
            nudGiaNgay.Value = Math.Clamp(l.GiaNgay, nudGiaNgay.Minimum, nudGiaNgay.Maximum);
            nudGiaGio.Value = Math.Clamp(l.GiaGio, nudGiaGio.Minimum, nudGiaGio.Maximum);
        }
        catch (Exception ex)
        {
            Loi("Lỗi tải thông tin loại phòng: " + ex.Message);
        }
    }

    protected override void Luu()
    {
        string ten = txtTenLPH.Text.Trim();
        if (ten.Length == 0) { Loi("Vui lòng nhập tên loại phòng."); txtTenLPH.Focus(); return; }

        try
        {
            using var db = new HotelManagementContext();
            var l = db.LoaiPhongs.FirstOrDefault(x => x.MaLph == maLoai);
            if (l == null) { Loi("Loại phòng không tồn tại."); return; }

            l.TenLph = ten;
            l.SoGiuong = (int)nudSoGiuong.Value;
            l.SoNguoiToiDa = (int)nudSoNguoi.Value;
            l.GiaNgay = nudGiaNgay.Value;
            l.GiaGio = nudGiaGio.Value;
            db.SaveChanges();

            MessageBox.Show("Cập nhật loại phòng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LuuXong();
        }
        catch (Exception ex)
        {
            Loi("Lỗi khi cập nhật loại phòng: " + (ex.InnerException?.Message ?? ex.Message));
        }
    }
}
