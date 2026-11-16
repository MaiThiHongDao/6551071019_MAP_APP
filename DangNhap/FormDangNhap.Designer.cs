#nullable disable
namespace HotelManagement.DangNhap
{
    partial class FormDangNhap
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
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            txtTenDangNhap = new TextBox();
            label2 = new Label();
            txtMatKhau = new TextBox();
            linkLabel1 = new LinkLabel();
            btnDangNhap = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            //
            // pictureBox1 (ảnh nền bên trái)
            //
            pictureBox1.Image = Properties.Resources.pictureIcon;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(440, 562);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            //
            // panel2 (khung đăng nhập bên phải)
            //
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtTenDangNhap);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtMatKhau);
            panel2.Controls.Add(linkLabel1);
            panel2.Controls.Add(btnDangNhap);
            panel2.Location = new Point(448, 16);
            panel2.Name = "panel2";
            panel2.Size = new Size(395, 531);
            panel2.TabIndex = 1;
            //
            // pictureBox2 (logo "Đăng nhập")
            //
            pictureBox2.Image = Properties.Resources.DangNhap;
            pictureBox2.Location = new Point(97, 44);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(203, 75);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(192, 0, 0);
            label1.Location = new Point(19, 182);
            label1.Name = "label1";
            label1.Size = new Size(141, 24);
            label1.TabIndex = 1;
            label1.Text = "Tên đăng nhập";
            //
            // txtTenDangNhap
            //
            txtTenDangNhap.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTenDangNhap.Location = new Point(177, 170);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(192, 34);
            txtTenDangNhap.TabIndex = 0;
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(192, 0, 0);
            label2.Location = new Point(62, 265);
            label2.Name = "label2";
            label2.Size = new Size(86, 24);
            label2.TabIndex = 3;
            label2.Text = "Mật khẩu";
            //
            // txtMatKhau
            //
            txtMatKhau.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMatKhau.Location = new Point(177, 255);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.Size = new Size(192, 34);
            txtMatKhau.TabIndex = 1;
            txtMatKhau.KeyDown += txtMatKhau_KeyDown;
            //
            // linkLabel1
            //
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Italic, GraphicsUnit.Point, 0);
            linkLabel1.Location = new Point(222, 328);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(161, 26);
            linkLabel1.TabIndex = 2;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Quên mật khẩu";
            //
            // btnDangNhap
            //
            btnDangNhap.BackColor = Color.FromArgb(192, 192, 255);
            btnDangNhap.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDangNhap.Location = new Point(117, 380);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(134, 66);
            btnDangNhap.TabIndex = 3;
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.UseVisualStyleBackColor = false;
            btnDangNhap.Click += btnDangNhap_Click;
            //
            // FormDangNhap
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Beige;
            ClientSize = new Size(855, 562);
            Controls.Add(panel2);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormDangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Panel panel2;
        private PictureBox pictureBox2;
        private Label label1;
        private TextBox txtTenDangNhap;
        private Label label2;
        private TextBox txtMatKhau;
        private LinkLabel linkLabel1;
        private Button btnDangNhap;
    }
}