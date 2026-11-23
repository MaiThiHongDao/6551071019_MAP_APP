using HotelManagement.DangNhap;
using HotelManagement.LoaiPhong;
using HotelManagement.Phong;
using HotelManagement.SoDoPhong;

namespace HotelManagement;

public partial class FormMain : Form
{
    private Panel panelMenu = null!;
    private Panel panelMain = null!;
    private Label lblTenNguoiDung = null!;

    public FormMain()
    {
        KhoiTaoGiaoDien();
        HienThiThongTinNguoiDung();
        Load += (_, _) => HienThiTrangChu();
    }

    private void KhoiTaoGiaoDien()
    {
        Text = "Quản lý khách sạn";
        ClientSize = new Size(1280, 800);
        StartPosition = FormStartPosition.CenterScreen;
        WindowState = FormWindowState.Maximized;
        Font = new Font("Microsoft Sans Serif", 11F);

        // ---- Vùng nội dung (Honeydew) ----
        panelMain = new Panel { Dock = DockStyle.Fill, BackColor = Color.Honeydew, AutoScroll = true };

        // ---- Thanh tiêu đề (SeaGreen): icon menu + tên khách sạn ----
        var panelHeader = new Panel { Dock = DockStyle.Top, Height = 92, BackColor = Color.SeaGreen };
        var picMenu = new PictureBox
        {
            Image = Properties.Resources.Menu,
            Location = new Point(3, 4),
            Size = new Size(48, 78),
            SizeMode = PictureBoxSizeMode.StretchImage,
            TabStop = false
        };
        var lblTenKhachSan = new Label
        {
            Text = "Hotel Management",
            AutoSize = true,
            BackColor = Color.Transparent,
            Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold),
            ForeColor = Color.LightSalmon,
            Location = new Point(66, 19)
        };
        panelHeader.Controls.Add(lblTenKhachSan);
        panelHeader.Controls.Add(picMenu);

        // ---- Menu bên trái (DarkCyan) ----
        panelMenu = new Panel { Dock = DockStyle.Left, Width = 304, BackColor = Color.DarkCyan, AutoScroll = true };

        // Nút menu: tạo theo thứ tự hiển thị rồi Add ngược lại (Dock = Top)
        var muc = new List<(string Ten, Image Anh, EventHandler Click)>
        {
            ("Trang chủ",            Properties.Resources.MenuTrangChu,         (_, _) => HienThiTrangChu()),
            ("Sơ đồ phòng",          Properties.Resources.MenuSoDoPhong,        (_, _) => LoadFormCon(new FormSoDoPhong())),
            ("Phòng",                Properties.Resources.MenuPhong,            (_, _) => LoadFormCon(new FormDanhSachPhong())),
            ("Loại phòng",           Properties.Resources.MenuLoaiPhong,        (_, _) => LoadFormCon(new FormDanhSachLoaiPhong())),
            ("Danh sách đặt phòng",  Properties.Resources.MenuDatPhong,         (_, _) => HienThiDangPhatTrien("Danh sách đặt phòng")),
            ("Danh sách hóa đơn",    Properties.Resources.MenuDanhSachHoaDon,   (_, _) => HienThiDangPhatTrien("Danh sách hóa đơn")),
            ("Danh sách dịch vụ",    Properties.Resources.MenuQuanLyDichVu,     (_, _) => HienThiDangPhatTrien("Danh sách dịch vụ")),
            ("Danh sách tiện nghi",  Properties.Resources.MenuTienNghi,         (_, _) => HienThiDangPhatTrien("Danh sách tiện nghi")),
            ("Danh sách khách hàng", Properties.Resources.MenuQuanLyKhachHang,  (_, _) => HienThiDangPhatTrien("Danh sách khách hàng")),
            ("Danh sách nhân viên",  Properties.Resources.MenuQuanLyNhanVien,   (_, _) => HienThiDangPhatTrien("Danh sách nhân viên")),
            ("Danh sách tài khoản",  Properties.Resources.MenuQuanLyTaiKhoan,   (_, _) => HienThiDangPhatTrien("Danh sách tài khoản")),
            ("Thống kê",             Properties.Resources.MenuThongKe,          (_, _) => HienThiDangPhatTrien("Thống kê")),
        };
        for (int i = muc.Count - 1; i >= 0; i--)
        {
            var nut = new Button
            {
                Text = muc[i].Ten,
                Image = muc[i].Anh,
                ImageAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Top,
                Height = 51,
                BackColor = Color.DarkCyan,
                ForeColor = SystemColors.ButtonHighlight,
                Font = new Font("Microsoft Sans Serif", 13F),
                UseVisualStyleBackColor = false
            };
            nut.Click += muc[i].Click;
            panelMenu.Controls.Add(nut);
        }

        // ---- Khu vực thông tin người dùng (MediumSeaGreen): đăng xuất + avatar + tên ----
        var panelUser = new Panel { Dock = DockStyle.Top, Height = 198, BackColor = Color.MediumSeaGreen };
        var lnkDangXuat = new LinkLabel
        {
            Text = "Đăng xuất",
            AutoSize = true,
            Font = new Font("Microsoft Sans Serif", 13F),
            ForeColor = Color.MidnightBlue,
            Location = new Point(4, 11),
            TabStop = true
        };
        lnkDangXuat.LinkClicked += lnkDangXuat_LinkClicked;
        var picUser = new PictureBox
        {
            Image = Properties.Resources.user,
            Location = new Point(108, 40),
            Size = new Size(87, 108),
            SizeMode = PictureBoxSizeMode.StretchImage,
            TabStop = false
        };
        // Tên người dùng căn giữa theo chiều ngang của panel
        lblTenNguoiDung = new Label
        {
            AutoSize = false,
            Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold),
            TextAlign = ContentAlignment.MiddleCenter,
            Location = new Point(0, 158),
            Size = new Size(304, 32)
        };
        panelUser.Controls.Add(lblTenNguoiDung);
        panelUser.Controls.Add(picUser);
        panelUser.Controls.Add(lnkDangXuat);
        panelMenu.Controls.Add(panelUser);

        // Thứ tự Add: Fill trước, rồi Left, rồi Top (Top chiếm ngang toàn form)
        Controls.Add(panelMain);
        Controls.Add(panelMenu);
        Controls.Add(panelHeader);
        panelMain.BringToFront();   // để panelMain (Fill) chiếm phần còn lại
    }

    private void lnkDangXuat_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
    {
        if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Đăng xuất",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            return;

        Hide();
        using var formLogin = new FormDangNhap();
        if (formLogin.ShowDialog() == DialogResult.OK)
        {
            HienThiThongTinNguoiDung();
            HienThiTrangChu();
            Show();
        }
        else
        {
            Close();
        }
    }

    private void HienThiThongTinNguoiDung()
    {
        lblTenNguoiDung.Text = FormDangNhap.TenNV_DangNhap;
    }

    private void XoaNoiDungPanelMain()
    {
        foreach (Control c in panelMain.Controls.Cast<Control>().ToList())
        {
            panelMain.Controls.Remove(c);
            c.Dispose();
        }
    }

    private void LoadUserControl(UserControl uc)
    {
        XoaNoiDungPanelMain();
        uc.Dock = DockStyle.Fill;
        panelMain.Controls.Add(uc);
        uc.BringToFront();
    }

    private void LoadFormCon(Form formCon)
    {
        XoaNoiDungPanelMain();
        formCon.TopLevel = false;
        formCon.FormBorderStyle = FormBorderStyle.None;
        formCon.Dock = DockStyle.Fill;
        panelMain.Controls.Add(formCon);
        formCon.Show();
    }

    private void HienThiTrangChu() => LoadUserControl(new FormTrangChu());

    private void HienThiDangPhatTrien(string tenChucNang)
    {
        XoaNoiDungPanelMain();
        panelMain.Controls.Add(new Label
        {
            Dock = DockStyle.Fill,
            Text = tenChucNang + Environment.NewLine + "(chức năng đang được xây dựng)",
            Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Italic),
            ForeColor = Color.DarkCyan,
            TextAlign = ContentAlignment.MiddleCenter
        });
    }
}
