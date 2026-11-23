namespace HotelManagement.Models;

public partial class HoaDon
{
    public string MaHd { get; set; } = null!;
    public DateTime? NgHd { get; set; }
    public decimal? TriGia { get; set; }
    public string? MaNv { get; set; }
    public string TrangThai { get; set; } = null!;
    public string MaCtdp { get; set; } = null!;
    public bool? DaXoa { get; set; }

    public virtual NhanVien MaNvNavigation { get; set; } = null!;
    public virtual Ctdp MaCtdpNavigation { get; set; } = null!;
}
