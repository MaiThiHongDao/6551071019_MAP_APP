using HotelManagement.Helpers;
using HotelManagement.Models;

namespace HotelManagement.LoaiPhong;

public partial class FormThemLoaiPhong : FormNhapLieu
{
    private readonly TextBox txtMaLPH;
    private readonly TextBox txtTenLPH;
    private readonly NumericUpDown nudSoGiuong;
    private readonly NumericUpDown nudSoNguoi;
    private readonly NumericUpDown nudGiaNgay;
    private readonly NumericUpDown nudGiaGio;

    public FormThemLoaiPhong() : base("Thêm loại phòng")
    {
        txtMaLPH = ThemTruong("Mã loại phòng", new TextBox { MaxLength = 5 });
        txtTenLPH = ThemTruong("Tên loại phòng", new TextBox { MaxLength = 20 });
        nudSoGiuong = ThemTruong("Số giường", new NumericUpDown { Minimum = 1, Maximum = 20, Value = 1 });
        nudSoNguoi = ThemTruong("Số người tối đa", new NumericUpDown { Minimum = 1, Maximum = 50, Value = 2 });
        nudGiaNgay = ThemTruong("Giá theo ngày", new NumericUpDown { Minimum = 0, Maximum = 1_000_000_000, Increment = 10000, ThousandsSeparator = true });
        nudGiaGio = ThemTruong("Giá theo giờ", new NumericUpDown { Minimum = 0, Maximum = 1_000_000_000, Increment = 10000, ThousandsSeparator = true });
    }

    protected override void Luu()
    {
        string ma = txtMaLPH.Text.Trim();
        string ten = txtTenLPH.Text.Trim();

        if (ma.Length == 0) { Loi("Vui lòng nhập mã loại phòng."); txtMaLPH.Focus(); return; }
        if (ten.Length == 0) { Loi("Vui lòng nhập tên loại phòng."); txtTenLPH.Focus(); return; }

        try
        {
            using var db = new HotelManagementContext();
            if (db.LoaiPhongs.Any(l => l.MaLph == ma))
            {
                Loi($"Mã loại phòng {ma} đã tồn tại.");
                return;
            }

            db.LoaiPhongs.Add(new Models.LoaiPhong
            {
                MaLph = ma,
                TenLph = ten,
                SoGiuong = (int)nudSoGiuong.Value,
                SoNguoiToiDa = (int)nudSoNguoi.Value,
                GiaNgay = nudGiaNgay.Value,
                GiaGio = nudGiaGio.Value
            });
            db.SaveChanges();

            MessageBox.Show("Thêm loại phòng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LuuXong();
        }
        catch (Exception ex)
        {
            Loi("Lỗi khi thêm loại phòng: " + (ex.InnerException?.Message ?? ex.Message));
        }
    }
}
