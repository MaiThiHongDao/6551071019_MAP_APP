using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.DangNhap;

public partial class FormDangNhap : Form
{
    // Thông tin người đăng nhập, dùng ở các form khác: FormDangNhap.MaNV_DangNhap
    public static string MaNV_DangNhap = string.Empty;
    public static string TenNV_DangNhap = string.Empty;
    public static int CapDoQuyen_DangNhap;   // 1: Nhân viên, 2: Quản lý, 3: Admin (theo dữ liệu mẫu)

    private TextBox txtTenDangNhap = null!;
    private TextBox txtMatKhau = null!;
    private Button btnDangNhap = null!;
    private LinkLabel lnkQuenMatKhau = null!;

    public FormDangNhap()
    {
        KhoiTaoGiaoDien();
        ActiveControl = txtTenDangNhap;
    }

    private void KhoiTaoGiaoDien()
    {
        Text = "Đăng nhập";
        ClientSize = new Size(855, 562);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        BackColor = Color.Beige;
        Font = new Font("Microsoft Sans Serif", 11F);

        // Ảnh khách sạn bên trái (Resources.pictureIcon)
        var pictureBox1 = new PictureBox
        {
            Image = Properties.Resources.pictureIcon,
            Location = new Point(-16, 20),
            Size = new Size(458, 524),
            SizeMode = PictureBoxSizeMode.StretchImage,
            TabStop = false
        };

        // Panel bên phải chứa các điều khiển đăng nhập
        var panel2 = new Panel
        {
            Location = new Point(448, 16),
            Size = new Size(395, 531)
        };

        // Ảnh tiêu đề "Đăng nhập" (Resources.DangNhap)
        var pictureBox2 = new PictureBox
        {
            Image = Properties.Resources.DangNhap,
            Location = new Point(97, 44),
            Size = new Size(203, 75),
            SizeMode = PictureBoxSizeMode.StretchImage,
            TabStop = false
        };

        var lblTen = new Label { Text = "Tên đăng nhập", AutoSize = true, Location = new Point(19, 182), ForeColor = Color.FromArgb(192, 0, 0) };
        txtTenDangNhap = new TextBox { Location = new Point(177, 170), Size = new Size(192, 34), Font = new Font("Microsoft Sans Serif", 14F) };

        var lblMk = new Label { Text = "Mật khẩu", AutoSize = true, Location = new Point(62, 265), ForeColor = Color.FromArgb(192, 0, 0) };
        txtMatKhau = new TextBox { Location = new Point(177, 255), Size = new Size(192, 34), PasswordChar = '*', Font = new Font("Microsoft Sans Serif", 14F) };
        txtMatKhau.KeyDown += txtMatKhau_KeyDown;

        lnkQuenMatKhau = new LinkLabel
        {
            Text = "Quên mật khẩu",
            AutoSize = true,
            Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Italic),
            Location = new Point(222, 328),
            TabStop = true
        };
        lnkQuenMatKhau.LinkClicked += (_, _) =>
            MessageBox.Show("Chức năng quên mật khẩu đang được xây dựng.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

        btnDangNhap = new Button
        {
            Text = "Đăng nhập",
            Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold),
            BackColor = Color.FromArgb(192, 192, 255),
            UseVisualStyleBackColor = false,
            Location = new Point(117, 380),
            Size = new Size(134, 66)
        };
        btnDangNhap.Click += btnDangNhap_Click;

        panel2.Controls.AddRange(new Control[] { lblTen, txtTenDangNhap, lblMk, txtMatKhau, pictureBox2, lnkQuenMatKhau, btnDangNhap });

        Controls.Add(pictureBox1);
        Controls.Add(panel2);
        AcceptButton = btnDangNhap;
    }

    private async void btnDangNhap_Click(object? sender, EventArgs e)
    {
        string tenDangNhap = txtTenDangNhap.Text.Trim();
        string matKhau = txtMatKhau.Text;

        if (tenDangNhap.Length == 0 || matKhau.Length == 0)
        {
            MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        btnDangNhap.Enabled = false;   // tránh bấm nhiều lần khi đang chờ CSDL
        try
        {
            bool hopLe = await KiemTraDangNhapAsync(tenDangNhap, matKhau);
            if (hopLe)
            {
                DialogResult = DialogResult.OK;   // Program.cs sẽ mở form chính
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.", "Đăng nhập thất bại",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Clear();
                txtMatKhau.Focus();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnDangNhap.Enabled = true;
        }
    }

    private async Task<bool> KiemTraDangNhapAsync(string tenDangNhap, string matKhau)
    {
        await using var db = new HotelManagementContext();

        var tk = await db.TaiKhoans
            .AsNoTracking()
            .Where(t => t.TenTk == tenDangNhap && t.DaXoa != true)
            .Select(t => new
            {
                t.Password,
                t.MaNv,
                t.CapDoQuyen,
                TenNv = t.MaNvNavigation.TenNv,
                NhanVienDaXoa = t.MaNvNavigation.DaXoa
            })
            .FirstOrDefaultAsync();

        if (tk == null || tk.NhanVienDaXoa == true)
            return false;

        // So sánh phân biệt hoa/thường (mặc định SQL Server không phân biệt)
        if (!string.Equals(tk.Password, matKhau, StringComparison.Ordinal))
            return false;

        MaNV_DangNhap = tk.MaNv;
        TenNV_DangNhap = tk.TenNv;
        CapDoQuyen_DangNhap = tk.CapDoQuyen;
        return true;
    }

    private void txtMatKhau_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true;
            btnDangNhap.PerformClick();
        }
    }
}
