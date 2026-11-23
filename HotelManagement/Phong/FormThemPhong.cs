using HotelManagement.Helpers;
using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Phong;

public partial class FormThemPhong : FormNhapLieu
{
    private readonly TextBox txtMaPH;
    private readonly ComboBox cbLoaiPhong;
    private readonly ComboBox cbTrangThai;
    private readonly ComboBox cbDonDep;
    private readonly TextBox txtGhiChu;

    public FormThemPhong() : base("Thêm phòng")
    {
        txtMaPH = ThemTruong("Mã phòng", new TextBox { MaxLength = 5 });
        cbLoaiPhong = ThemTruong("Loại phòng", new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList });
        cbTrangThai = ThemTruong("Trạng thái phòng", new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList });
        cbDonDep = ThemTruong("Tình trạng dọn dẹp", new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList });
        txtGhiChu = ThemTruong("Ghi chú", new TextBox { Multiline = true, Height = 70, MaxLength = 100 });

        cbTrangThai.Items.AddRange(new object[] { "Bình thường", "Đang sửa chữa" });
        cbDonDep.Items.AddRange(new object[] { "Đã dọn dẹp", "Chưa dọn dẹp" });
        cbTrangThai.SelectedIndex = 0;
        cbDonDep.SelectedIndex = 0;

        Load += (_, _) => NapLoaiPhong();
    }

    private void NapLoaiPhong()
    {
        try
        {
            using var db = new HotelManagementContext();
            var ds = db.LoaiPhongs.AsNoTracking().OrderBy(l => l.MaLph)
                .Select(l => new { l.MaLph, l.TenLph }).ToList();
            cbLoaiPhong.DataSource = ds;
            cbLoaiPhong.DisplayMember = "TenLph";
            cbLoaiPhong.ValueMember = "MaLph";
        }
        catch (Exception ex)
        {
            Loi("Lỗi tải loại phòng: " + ex.Message);
        }
    }

    protected override void Luu()
    {
        string maPH = txtMaPH.Text.Trim();
        string ghiChu = txtGhiChu.Text.Trim();

        if (maPH.Length == 0) { Loi("Vui lòng nhập mã phòng."); txtMaPH.Focus(); return; }
        if (cbLoaiPhong.SelectedValue == null) { Loi("Vui lòng chọn loại phòng."); return; }

        string maLph = cbLoaiPhong.SelectedValue.ToString()!;
        string trangThai = cbTrangThai.Text;
        string donDep = cbDonDep.Text;

        try
        {
            using var db = new HotelManagementContext();
            var tonTai = db.Phongs.FirstOrDefault(p => p.MaPh == maPH);
            if (tonTai != null)
            {
                if (tonTai.DaXoa != true)
                {
                    Loi($"Mã phòng {maPH} đã tồn tại.");
                    return;
                }
                // Phòng từng bị xóa mềm -> khôi phục lại với thông tin mới
                tonTai.Ttph = trangThai;
                tonTai.Ttdd = donDep;
                tonTai.GhiChu = ghiChu.Length == 0 ? null : ghiChu;
                tonTai.MaLph = maLph;
                tonTai.DaXoa = false;
            }
            else
            {
                db.Phongs.Add(new Models.Phong
                {
                    MaPh = maPH,
                    MaLph = maLph,
                    Ttph = trangThai,
                    Ttdd = donDep,
                    GhiChu = ghiChu.Length == 0 ? null : ghiChu,
                    DaXoa = false
                });
            }
            db.SaveChanges();
            MessageBox.Show("Thêm phòng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LuuXong();
        }
        catch (Exception ex)
        {
            Loi("Lỗi khi thêm phòng: " + (ex.InnerException?.Message ?? ex.Message));
        }
    }
}
