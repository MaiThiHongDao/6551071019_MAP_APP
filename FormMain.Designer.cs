#nullable disable
namespace HotelManagement
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panel1 = new Panel();
            labelTenKhachSan = new Label();
            pictureBox1 = new PictureBox();
            panelLeft = new Panel();
            panel4 = new Panel();
            btnTrangChu = new Button();
            btnSoDoPhong = new Button();
            btnQuanLyPhong = new Button();
            button4 = new Button();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            button12 = new Button();
            button6 = new Button();
            button7 = new Button();
            button5 = new Button();
            button13 = new Button();
            panel2 = new Panel();
            lblTenNguoiDung = new Label();
            pictureBox2 = new PictureBox();
            linkLabel1 = new LinkLabel();
            panelMain = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelLeft.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            //
            // panel1 (thanh tiêu đề phía trên)
            //
            panel1.BackColor = Color.SeaGreen;
            panel1.Controls.Add(labelTenKhachSan);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Name = "panel1";
            panel1.Size = new Size(1280, 92);
            panel1.TabIndex = 0;
            //
            // labelTenKhachSan
            //
            labelTenKhachSan.AutoSize = true;
            labelTenKhachSan.BackColor = Color.Transparent;
            labelTenKhachSan.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTenKhachSan.ForeColor = Color.LightSalmon;
            labelTenKhachSan.Location = new Point(66, 19);
            labelTenKhachSan.Name = "labelTenKhachSan";
            labelTenKhachSan.Size = new Size(285, 41);
            labelTenKhachSan.TabIndex = 1;
            labelTenKhachSan.Text = "Hotel Management";
            //
            // pictureBox1 (biểu tượng menu)
            //
            pictureBox1.Image = Properties.Resources.Menu;
            pictureBox1.Location = new Point(3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(48, 78);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            //
            // panelLeft (cột bên trái: thông tin người dùng + menu)
            //
            panelLeft.Controls.Add(panel4);
            panelLeft.Controls.Add(panel2);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(304, 628);
            panelLeft.TabIndex = 1;
            //
            // panel2 (thông tin người dùng)
            //
            panel2.BackColor = Color.MediumSeaGreen;
            panel2.Controls.Add(lblTenNguoiDung);
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(linkLabel1);
            panel2.Dock = DockStyle.Top;
            panel2.Name = "panel2";
            panel2.Size = new Size(304, 198);
            panel2.TabIndex = 1;
            //
            // lblTenNguoiDung
            //
            lblTenNguoiDung.AutoSize = true;
            lblTenNguoiDung.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTenNguoiDung.Location = new Point(28, 159);
            lblTenNguoiDung.Name = "lblTenNguoiDung";
            lblTenNguoiDung.Size = new Size(76, 26);
            lblTenNguoiDung.TabIndex = 2;
            lblTenNguoiDung.Text = "label1";
            lblTenNguoiDung.TextAlign = ContentAlignment.MiddleCenter;
            //
            // pictureBox2 (ảnh người dùng)
            //
            pictureBox2.BackgroundImageLayout = ImageLayout.None;
            pictureBox2.Image = Properties.Resources.user;
            pictureBox2.Location = new Point(108, 48);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(87, 108);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            //
            // linkLabel1 (Đăng xuất)
            //
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabel1.ForeColor = Color.MidnightBlue;
            linkLabel1.LinkColor = Color.MidnightBlue;
            linkLabel1.Location = new Point(4, 11);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(88, 26);
            linkLabel1.TabIndex = 0;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Đăng xuất";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            //
            // panel4 (thanh menu bên trái)
            // Thêm nút từ dưới lên trên vì Dock = Top xếp theo thứ tự thêm ngược.
            //
            panel4.AutoScroll = true;
            panel4.BackColor = Color.DarkCyan;
            panel4.Controls.Add(button13);
            panel4.Controls.Add(button5);
            panel4.Controls.Add(button7);
            panel4.Controls.Add(button6);
            panel4.Controls.Add(button12);
            panel4.Controls.Add(button11);
            panel4.Controls.Add(button10);
            panel4.Controls.Add(button9);
            panel4.Controls.Add(button4);
            panel4.Controls.Add(btnQuanLyPhong);
            panel4.Controls.Add(btnSoDoPhong);
            panel4.Controls.Add(btnTrangChu);
            panel4.Dock = DockStyle.Fill;
            panel4.Name = "panel4";
            panel4.Size = new Size(304, 430);
            panel4.TabIndex = 4;
            //
            // btnTrangChu
            //
            btnTrangChu.BackColor = Color.DarkCyan;
            btnTrangChu.Dock = DockStyle.Top;
            btnTrangChu.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTrangChu.ForeColor = SystemColors.ButtonHighlight;
            btnTrangChu.Image = Properties.Resources.MenuTrangChu;
            btnTrangChu.ImageAlign = ContentAlignment.MiddleLeft;
            btnTrangChu.Name = "btnTrangChu";
            btnTrangChu.Size = new Size(304, 69);
            btnTrangChu.TabIndex = 3;
            btnTrangChu.Text = "Trang chủ";
            btnTrangChu.UseVisualStyleBackColor = false;
            btnTrangChu.Click += btnTrangChu_Click;
            //
            // btnSoDoPhong
            //
            btnSoDoPhong.AllowDrop = true;
            btnSoDoPhong.BackColor = Color.DarkCyan;
            btnSoDoPhong.Dock = DockStyle.Top;
            btnSoDoPhong.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSoDoPhong.ForeColor = SystemColors.ButtonHighlight;
            btnSoDoPhong.Image = Properties.Resources.MenuSoDoPhong;
            btnSoDoPhong.ImageAlign = ContentAlignment.MiddleLeft;
            btnSoDoPhong.Name = "btnSoDoPhong";
            btnSoDoPhong.Size = new Size(304, 51);
            btnSoDoPhong.TabIndex = 5;
            btnSoDoPhong.Text = "Sơ đồ phòng";
            btnSoDoPhong.UseVisualStyleBackColor = false;
            btnSoDoPhong.Click += btnSoDoPhong_Click;
            //
            // btnQuanLyPhong
            //
            btnQuanLyPhong.BackColor = Color.DarkCyan;
            btnQuanLyPhong.Dock = DockStyle.Top;
            btnQuanLyPhong.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnQuanLyPhong.ForeColor = SystemColors.ButtonHighlight;
            btnQuanLyPhong.Image = Properties.Resources.MenuPhong;
            btnQuanLyPhong.ImageAlign = ContentAlignment.MiddleLeft;
            btnQuanLyPhong.Name = "btnQuanLyPhong";
            btnQuanLyPhong.Size = new Size(304, 51);
            btnQuanLyPhong.TabIndex = 6;
            btnQuanLyPhong.Text = "Phòng";
            btnQuanLyPhong.UseVisualStyleBackColor = false;
            btnQuanLyPhong.Click += btnQuanLyPhong_Click;
            //
            // button4 (Loại phòng)
            //
            button4.BackColor = Color.DarkCyan;
            button4.Dock = DockStyle.Top;
            button4.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.ForeColor = SystemColors.ButtonHighlight;
            button4.Image = Properties.Resources.MenuLoaiPhong;
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.Name = "button4";
            button4.Size = new Size(304, 51);
            button4.TabIndex = 7;
            button4.Text = "Loại phòng";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            //
            // button9 (Danh sách đặt phòng)
            //
            button9.BackColor = Color.DarkCyan;
            button9.Dock = DockStyle.Top;
            button9.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button9.ForeColor = SystemColors.ButtonHighlight;
            button9.Image = Properties.Resources.MenuDatPhong;
            button9.ImageAlign = ContentAlignment.MiddleLeft;
            button9.Name = "button9";
            button9.Size = new Size(304, 51);
            button9.TabIndex = 12;
            button9.Text = "Danh sách đặt phòng";
            button9.UseVisualStyleBackColor = false;
            button9.Click += button9_Click;
            //
            // button10 (Danh sách hóa đơn)
            //
            button10.BackColor = Color.DarkCyan;
            button10.Dock = DockStyle.Top;
            button10.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button10.ForeColor = SystemColors.ButtonHighlight;
            button10.Image = Properties.Resources.MenuDanhSachHoaDon;
            button10.ImageAlign = ContentAlignment.MiddleLeft;
            button10.Name = "button10";
            button10.Size = new Size(304, 51);
            button10.TabIndex = 13;
            button10.Text = "Danh sách hóa đơn";
            button10.UseVisualStyleBackColor = false;
            button10.Click += button10_Click;
            //
            // button11 (Danh sách dịch vụ)
            //
            button11.BackColor = Color.DarkCyan;
            button11.Dock = DockStyle.Top;
            button11.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button11.ForeColor = SystemColors.ButtonHighlight;
            button11.Image = Properties.Resources.MenuQuanLyDichVu;
            button11.ImageAlign = ContentAlignment.MiddleLeft;
            button11.Name = "button11";
            button11.Size = new Size(304, 51);
            button11.TabIndex = 14;
            button11.Text = "Danh sách dịch vụ";
            button11.UseVisualStyleBackColor = false;
            button11.Click += button11_Click;
            //
            // button12 (Danh sách tiện nghi)
            //
            button12.BackColor = Color.DarkCyan;
            button12.Dock = DockStyle.Top;
            button12.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button12.ForeColor = SystemColors.ButtonHighlight;
            button12.Image = Properties.Resources.MenuTienNghi;
            button12.ImageAlign = ContentAlignment.MiddleLeft;
            button12.Name = "button12";
            button12.Size = new Size(304, 51);
            button12.TabIndex = 15;
            button12.Text = "Danh sách tiện nghi";
            button12.UseVisualStyleBackColor = false;
            button12.Click += button12_Click;
            //
            // button6 (Danh sách khách hàng)
            //
            button6.BackColor = Color.DarkCyan;
            button6.Dock = DockStyle.Top;
            button6.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.ForeColor = SystemColors.ButtonHighlight;
            button6.Image = Properties.Resources.MenuQuanLyKhachHang;
            button6.ImageAlign = ContentAlignment.MiddleLeft;
            button6.Name = "button6";
            button6.Size = new Size(304, 51);
            button6.TabIndex = 9;
            button6.Text = "Danh sách khách hàng";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            //
            // button7 (Danh sách nhân viên)
            //
            button7.BackColor = Color.DarkCyan;
            button7.Dock = DockStyle.Top;
            button7.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button7.ForeColor = SystemColors.ButtonHighlight;
            button7.Image = Properties.Resources.MenuQuanLyNhanVien;
            button7.ImageAlign = ContentAlignment.MiddleLeft;
            button7.Name = "button7";
            button7.Size = new Size(304, 51);
            button7.TabIndex = 10;
            button7.Text = "Danh sách nhân viên";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            //
            // button5 (Danh sách tài khoản)
            //
            button5.BackColor = Color.DarkCyan;
            button5.Dock = DockStyle.Top;
            button5.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.ForeColor = SystemColors.ButtonHighlight;
            button5.Image = Properties.Resources.MenuQuanLyTaiKhoan;
            button5.ImageAlign = ContentAlignment.MiddleLeft;
            button5.Name = "button5";
            button5.Size = new Size(304, 51);
            button5.TabIndex = 8;
            button5.Text = "Danh sách tài khoản";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            //
            // button13 (Thống kê)
            //
            button13.BackColor = Color.DarkCyan;
            button13.Dock = DockStyle.Top;
            button13.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button13.ForeColor = SystemColors.ButtonHighlight;
            button13.Image = Properties.Resources.MenuThongKe;
            button13.ImageAlign = ContentAlignment.MiddleLeft;
            button13.Name = "button13";
            button13.Size = new Size(304, 51);
            button13.TabIndex = 16;
            button13.Text = "Thống kê";
            button13.UseVisualStyleBackColor = false;
            button13.Click += button13_Click;
            //
            // panelMain (vùng nội dung chính)
            //
            panelMain.AutoScroll = true;
            panelMain.BackColor = Color.Honeydew;
            panelMain.Dock = DockStyle.Fill;
            panelMain.Name = "panelMain";
            panelMain.TabIndex = 2;
            //
            // FormMain
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1280, 720);
            Controls.Add(panelMain);
            Controls.Add(panelLeft);
            Controls.Add(panel1);
            MinimumSize = new Size(900, 600);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hotel Management";
            Load += FormMain_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelLeft.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Label labelTenKhachSan;
        private Panel panelLeft;
        private Panel panel2;
        private PictureBox pictureBox2;
        private LinkLabel linkLabel1;
        private Label lblTenNguoiDung;
        private Panel panelMain;
        private Panel panel4;
        private Button btnTrangChu;
        private Button btnSoDoPhong;
        private Button btnQuanLyPhong;
        private Button button4;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
        private Button button6;
        private Button button7;
        private Button button5;
        private Button button13;
    }
}