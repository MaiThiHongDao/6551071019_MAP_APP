using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Models;

// Phần ánh xạ bảng <-> class (tương đương file EF Core Power Tools sinh ra).
// Chuỗi kết nối nằm ở HotelManagementContext.custom.cs

public partial class HotelManagementContext : DbContext
{
    public virtual DbSet<NhanVien> NhanViens { get; set; }
    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
    public virtual DbSet<KhachHang> KhachHangs { get; set; }
    public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; }
    public virtual DbSet<Phong> Phongs { get; set; }
    public virtual DbSet<PhieuThue> PhieuThues { get; set; }
    public virtual DbSet<Ctdp> Ctdps { get; set; }
    public virtual DbSet<HoaDon> HoaDons { get; set; }
    public virtual DbSet<TienNghi> TienNghis { get; set; }
    public virtual DbSet<Cttn> Cttns { get; set; }
    public virtual DbSet<DichVu> DichVus { get; set; }
    public virtual DbSet<Ctdv> Ctdvs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NhanVien>(e =>
        {
            e.ToTable("NhanVien");
            e.HasKey(x => x.MaNv);
            e.Property(x => x.MaNv).HasColumnName("MaNV");
            e.Property(x => x.TenNv).HasColumnName("TenNV");
            e.Property(x => x.ChucVu).HasColumnName("ChucVu");
            e.Property(x => x.Luong).HasColumnName("Luong").HasColumnType("money");
            e.Property(x => x.Sdt).HasColumnName("SDT");
            e.Property(x => x.Cccd).HasColumnName("CCCD");
            e.Property(x => x.NgaySinh).HasColumnName("NgaySinh");
            e.Property(x => x.GioiTinh).HasColumnName("GioiTinh");
            e.Property(x => x.DiaChi).HasColumnName("DiaChi");
            e.Property(x => x.Email).HasColumnName("Email");
            e.Property(x => x.DaXoa).HasColumnName("DaXoa");
        });
        modelBuilder.Entity<TaiKhoan>(e =>
        {
            e.ToTable("TaiKhoan");
            e.HasKey(x => x.TenTk);
            e.Property(x => x.TenTk).HasColumnName("TenTK");
            e.Property(x => x.Password).HasColumnName("Password");
            e.Property(x => x.CapDoQuyen).HasColumnName("CapDoQuyen");
            e.Property(x => x.MaNv).HasColumnName("MaNV");
            e.Property(x => x.DaXoa).HasColumnName("DaXoa");
            e.HasOne(x => x.MaNvNavigation).WithMany(p => p.TaiKhoans).HasForeignKey(x => x.MaNv).OnDelete(DeleteBehavior.ClientSetNull);
        });
        modelBuilder.Entity<KhachHang>(e =>
        {
            e.ToTable("KhachHang");
            e.HasKey(x => x.MaKh);
            e.Property(x => x.MaKh).HasColumnName("MaKH");
            e.Property(x => x.TenKh).HasColumnName("TenKH");
            e.Property(x => x.Sdt).HasColumnName("SDT");
            e.Property(x => x.CccdPassport).HasColumnName("CCCD/Passport");
            e.Property(x => x.QuocTich).HasColumnName("QuocTich");
            e.Property(x => x.GioiTinh).HasColumnName("GioiTinh");
            e.Property(x => x.DaXoa).HasColumnName("DaXoa");
        });
        modelBuilder.Entity<LoaiPhong>(e =>
        {
            e.ToTable("LoaiPhong");
            e.HasKey(x => x.MaLph);
            e.Property(x => x.MaLph).HasColumnName("MaLPH");
            e.Property(x => x.TenLph).HasColumnName("TenLPH");
            e.Property(x => x.SoGiuong).HasColumnName("SoGiuong");
            e.Property(x => x.SoNguoiToiDa).HasColumnName("SoNguoiToiDa");
            e.Property(x => x.GiaNgay).HasColumnName("GiaNgay").HasColumnType("money");
            e.Property(x => x.GiaGio).HasColumnName("GiaGio").HasColumnType("money");
        });
        modelBuilder.Entity<Phong>(e =>
        {
            e.ToTable("Phong");
            e.HasKey(x => x.MaPh);
            e.Property(x => x.MaPh).HasColumnName("MaPH");
            e.Property(x => x.Ttph).HasColumnName("TTPH");
            e.Property(x => x.Ttdd).HasColumnName("TTDD");
            e.Property(x => x.GhiChu).HasColumnName("GhiChu");
            e.Property(x => x.MaLph).HasColumnName("MaLPH");
            e.Property(x => x.DaXoa).HasColumnName("DaXoa");
            e.HasOne(x => x.MaLphNavigation).WithMany(p => p.Phongs).HasForeignKey(x => x.MaLph).OnDelete(DeleteBehavior.ClientSetNull);
        });
        modelBuilder.Entity<PhieuThue>(e =>
        {
            e.ToTable("PhieuThue");
            e.HasKey(x => x.MaPt);
            e.Property(x => x.MaPt).HasColumnName("MaPT");
            e.Property(x => x.NgPt).HasColumnName("NgPT").HasColumnType("smalldatetime");
            e.Property(x => x.MaKh).HasColumnName("MaKH");
            e.Property(x => x.MaNv).HasColumnName("MaNV");
            e.Property(x => x.DaXoa).HasColumnName("DaXoa");
            e.HasOne(x => x.MaKhNavigation).WithMany(p => p.PhieuThues).HasForeignKey(x => x.MaKh).OnDelete(DeleteBehavior.ClientSetNull);
            e.HasOne(x => x.MaNvNavigation).WithMany(p => p.PhieuThues).HasForeignKey(x => x.MaNv).OnDelete(DeleteBehavior.ClientSetNull);
        });
        modelBuilder.Entity<Ctdp>(e =>
        {
            e.ToTable("CTDP");
            e.HasKey(x => x.MaCtdp);
            e.Property(x => x.MaCtdp).HasColumnName("MaCTDP");
            e.Property(x => x.SoNguoi).HasColumnName("SoNguoi");
            e.Property(x => x.MaPt).HasColumnName("MaPT");
            e.Property(x => x.MaPh).HasColumnName("MaPH");
            e.Property(x => x.CheckIn).HasColumnName("CheckIn").HasColumnType("smalldatetime");
            e.Property(x => x.CheckOut).HasColumnName("CheckOut").HasColumnType("smalldatetime");
            e.Property(x => x.TrangThai).HasColumnName("TrangThai");
            e.Property(x => x.DonGia).HasColumnName("DonGia").HasColumnType("money");
            e.Property(x => x.ThanhTien).HasColumnName("ThanhTien").HasColumnType("money");
            e.Property(x => x.DaXoa).HasColumnName("DaXoa");
            e.Property(x => x.TheoGio).HasColumnName("TheoGio");
            e.HasOne(x => x.MaPtNavigation).WithMany(p => p.Ctdps).HasForeignKey(x => x.MaPt).OnDelete(DeleteBehavior.ClientSetNull);
            e.HasOne(x => x.MaPhNavigation).WithMany(p => p.Ctdps).HasForeignKey(x => x.MaPh).OnDelete(DeleteBehavior.ClientSetNull);
        });
        modelBuilder.Entity<HoaDon>(e =>
        {
            e.ToTable("HoaDon");
            e.HasKey(x => x.MaHd);
            e.Property(x => x.MaHd).HasColumnName("MaHD");
            e.Property(x => x.NgHd).HasColumnName("NgHD").HasColumnType("smalldatetime");
            e.Property(x => x.TriGia).HasColumnName("TriGia").HasColumnType("money");
            e.Property(x => x.MaNv).HasColumnName("MaNV");
            e.Property(x => x.TrangThai).HasColumnName("TrangThai");
            e.Property(x => x.MaCtdp).HasColumnName("MaCTDP");
            e.Property(x => x.DaXoa).HasColumnName("DaXoa");
            e.HasOne(x => x.MaNvNavigation).WithMany(p => p.HoaDons).HasForeignKey(x => x.MaNv).OnDelete(DeleteBehavior.ClientSetNull);
            e.HasOne(x => x.MaCtdpNavigation).WithMany(p => p.HoaDons).HasForeignKey(x => x.MaCtdp).OnDelete(DeleteBehavior.ClientSetNull);
        });
        modelBuilder.Entity<TienNghi>(e =>
        {
            e.ToTable("TienNghi");
            e.HasKey(x => x.MaTn);
            e.Property(x => x.MaTn).HasColumnName("MaTN");
            e.Property(x => x.TenTn).HasColumnName("TenTN");
            e.Property(x => x.DaXoa).HasColumnName("DaXoa");
        });
        modelBuilder.Entity<Cttn>(e =>
        {
            e.ToTable("CTTN");
            e.HasKey(x => new { x.MaLph, x.MaTn });
            e.Property(x => x.MaLph).HasColumnName("MaLPH");
            e.Property(x => x.MaTn).HasColumnName("MaTN");
            e.Property(x => x.Sl).HasColumnName("SL");
            e.Property(x => x.DaXoa).HasColumnName("DaXoa");
            e.HasOne(x => x.MaLphNavigation).WithMany(p => p.Cttns).HasForeignKey(x => x.MaLph).OnDelete(DeleteBehavior.ClientSetNull);
            e.HasOne(x => x.MaTnNavigation).WithMany(p => p.Cttns).HasForeignKey(x => x.MaTn).OnDelete(DeleteBehavior.ClientSetNull);
        });
        modelBuilder.Entity<DichVu>(e =>
        {
            e.ToTable("DichVu");
            e.HasKey(x => x.MaDv);
            e.Property(x => x.MaDv).HasColumnName("MaDV");
            e.Property(x => x.TenDv).HasColumnName("TenDV");
            e.Property(x => x.DonGia).HasColumnName("DonGia").HasColumnType("money");
            e.Property(x => x.SlConLai).HasColumnName("SLConLai");
            e.Property(x => x.LoaiDv).HasColumnName("LoaiDV");
            e.Property(x => x.DaXoa).HasColumnName("DaXoa");
        });
        modelBuilder.Entity<Ctdv>(e =>
        {
            e.ToTable("CTDV");
            e.HasKey(x => new { x.MaCtdp, x.MaDv });
            e.Property(x => x.MaCtdp).HasColumnName("MaCTDP");
            e.Property(x => x.MaDv).HasColumnName("MaDV");
            e.Property(x => x.Sl).HasColumnName("SL");
            e.Property(x => x.DaXoa).HasColumnName("DaXoa");
            e.Property(x => x.ThanhTien).HasColumnName("ThanhTien").HasColumnType("money");
            e.HasOne(x => x.MaCtdpNavigation).WithMany(p => p.Ctdvs).HasForeignKey(x => x.MaCtdp).OnDelete(DeleteBehavior.ClientSetNull);
            e.HasOne(x => x.MaDvNavigation).WithMany(p => p.Ctdvs).HasForeignKey(x => x.MaDv).OnDelete(DeleteBehavior.ClientSetNull);
        });
    }
}
