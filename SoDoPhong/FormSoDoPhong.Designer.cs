#nullable disable
namespace HotelManagement.SoDoPhong
{
    partial class FormSoDoPhong
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
            components = new System.ComponentModel.Container();
            toolTip1 = new ToolTip(components);
            txtSearchMaPhong = new TextBox();
            grpTrangThaiPhong = new GroupBox();
            rdbPhongDangSuaChua = new RadioButton();
            rdbPhongDangThue = new RadioButton();
            rdbPhongDaDat = new RadioButton();
            rdbPhongTrong = new RadioButton();
            rdbTatCaTrangThaiPhong = new RadioButton();
            grpLoaiPhong = new GroupBox();
            rdbPhongThuongDoi = new RadioButton();
            rdbPhongThuongDon = new RadioButton();
            rdbPhongVipDoi = new RadioButton();
            rdbPhongVipDon = new RadioButton();
            rdbTatCaLoaiPhong = new RadioButton();
            grpDonDep = new GroupBox();
            rdbPhongChuaDon = new RadioButton();
            rdbPhongDaDonDep = new RadioButton();
            rdbTatCaPhong = new RadioButton();
            dtNgayChon = new DateTimePicker();
            lblNgay = new Label();
            lblTimKiem = new Label();
            btnDatPhong = new Button();
            dataGridViewPhong = new DataGridView();
            grpTrangThaiPhong.SuspendLayout();
            grpLoaiPhong.SuspendLayout();
            grpDonDep.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPhong).BeginInit();
            SuspendLayout();
            // 
            // txtSearchMaPhong
            // 
            txtSearchMaPhong.Font = new Font("Segoe UI", 10F);
            txtSearchMaPhong.Location = new Point(140, 18);
            txtSearchMaPhong.Name = "txtSearchMaPhong";
            txtSearchMaPhong.Size = new Size(180, 30);
            txtSearchMaPhong.TabIndex = 1;
            txtSearchMaPhong.TextChanged += txtSearchMaPhong_TextChanged;
            // 
            // grpTrangThaiPhong
            // 
            grpTrangThaiPhong.Controls.Add(rdbPhongDangSuaChua);
            grpTrangThaiPhong.Controls.Add(rdbPhongDangThue);
            grpTrangThaiPhong.Controls.Add(rdbPhongDaDat);
            grpTrangThaiPhong.Controls.Add(rdbPhongTrong);
            grpTrangThaiPhong.Controls.Add(rdbTatCaTrangThaiPhong);
            grpTrangThaiPhong.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpTrangThaiPhong.Location = new Point(16, 60);
            grpTrangThaiPhong.Name = "grpTrangThaiPhong";
            grpTrangThaiPhong.Size = new Size(330, 150);
            grpTrangThaiPhong.TabIndex = 4;
            grpTrangThaiPhong.TabStop = false;
            grpTrangThaiPhong.Text = "Trạng thái phòng";
            // 
            // rdbPhongDangSuaChua
            // 
            rdbPhongDangSuaChua.AutoSize = true;
            rdbPhongDangSuaChua.Font = new Font("Segoe UI", 9F);
            rdbPhongDangSuaChua.Location = new Point(160, 65);
            rdbPhongDangSuaChua.Name = "rdbPhongDangSuaChua";
            rdbPhongDangSuaChua.Size = new Size(149, 24);
            rdbPhongDangSuaChua.TabIndex = 4;
            rdbPhongDangSuaChua.TabStop = true;
            rdbPhongDangSuaChua.Text = "Đang sửa chữa";
            rdbPhongDangSuaChua.UseVisualStyleBackColor = true;
            rdbPhongDangSuaChua.CheckedChanged += rdbPhongDangSuaChua_CheckedChanged;
            // 
            // rdbPhongDangThue
            // 
            rdbPhongDangThue.AutoSize = true;
            rdbPhongDangThue.Font = new Font("Segoe UI", 9F);
            rdbPhongDangThue.Location = new Point(160, 30);
            rdbPhongDangThue.Name = "rdbPhongDangThue";
            rdbPhongDangThue.Size = new Size(119, 24);
            rdbPhongDangThue.TabIndex = 3;
            rdbPhongDangThue.TabStop = true;
            rdbPhongDangThue.Text = "Đang thuê";
            rdbPhongDangThue.UseVisualStyleBackColor = true;
            rdbPhongDangThue.CheckedChanged += rdbPhongDangThue_CheckedChanged;
            // 
            // rdbPhongDaDat
            // 
            rdbPhongDaDat.AutoSize = true;
            rdbPhongDaDat.Font = new Font("Segoe UI", 9F);
            rdbPhongDaDat.Location = new Point(15, 100);
            rdbPhongDaDat.Name = "rdbPhongDaDat";
            rdbPhongDaDat.Size = new Size(95, 24);
            rdbPhongDaDat.TabIndex = 2;
            rdbPhongDaDat.TabStop = true;
            rdbPhongDaDat.Text = "Đã đặt";
            rdbPhongDaDat.UseVisualStyleBackColor = true;
            rdbPhongDaDat.CheckedChanged += rdbPhongDaDat_CheckedChanged;
            // 
            // rdbPhongTrong
            // 
            rdbPhongTrong.AutoSize = true;
            rdbPhongTrong.Font = new Font("Segoe UI", 9F);
            rdbPhongTrong.Location = new Point(15, 65);
            rdbPhongTrong.Name = "rdbPhongTrong";
            rdbPhongTrong.Size = new Size(128, 24);
            rdbPhongTrong.TabIndex = 1;
            rdbPhongTrong.TabStop = true;
            rdbPhongTrong.Text = "Bình thường";
            rdbPhongTrong.UseVisualStyleBackColor = true;
            rdbPhongTrong.CheckedChanged += rdbPhongTrong_CheckedChanged;
            // 
            // rdbTatCaTrangThaiPhong
            // 
            rdbTatCaTrangThaiPhong.AutoSize = true;
            rdbTatCaTrangThaiPhong.Font = new Font("Segoe UI", 9F);
            rdbTatCaTrangThaiPhong.Location = new Point(15, 30);
            rdbTatCaTrangThaiPhong.Name = "rdbTatCaTrangThaiPhong";
            rdbTatCaTrangThaiPhong.Size = new Size(90, 24);
            rdbTatCaTrangThaiPhong.TabIndex = 0;
            rdbTatCaTrangThaiPhong.TabStop = true;
            rdbTatCaTrangThaiPhong.Text = "Tất cả";
            rdbTatCaTrangThaiPhong.UseVisualStyleBackColor = true;
            rdbTatCaTrangThaiPhong.CheckedChanged += rdbTatCaTrangThaiPhong_CheckedChanged;
            // 
            // grpLoaiPhong
            // 
            grpLoaiPhong.Controls.Add(rdbPhongThuongDoi);
            grpLoaiPhong.Controls.Add(rdbPhongThuongDon);
            grpLoaiPhong.Controls.Add(rdbPhongVipDoi);
            grpLoaiPhong.Controls.Add(rdbPhongVipDon);
            grpLoaiPhong.Controls.Add(rdbTatCaLoaiPhong);
            grpLoaiPhong.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpLoaiPhong.Location = new Point(360, 60);
            grpLoaiPhong.Name = "grpLoaiPhong";
            grpLoaiPhong.Size = new Size(330, 150);
            grpLoaiPhong.TabIndex = 5;
            grpLoaiPhong.TabStop = false;
            grpLoaiPhong.Text = "Loại phòng";
            // 
            // rdbPhongThuongDoi
            // 
            rdbPhongThuongDoi.AutoSize = true;
            rdbPhongThuongDoi.Font = new Font("Segoe UI", 9F);
            rdbPhongThuongDoi.Location = new Point(160, 65);
            rdbPhongThuongDoi.Name = "rdbPhongThuongDoi";
            rdbPhongThuongDoi.Size = new Size(130, 24);
            rdbPhongThuongDoi.TabIndex = 4;
            rdbPhongThuongDoi.TabStop = true;
            rdbPhongThuongDoi.Text = "Thường đôi";
            rdbPhongThuongDoi.UseVisualStyleBackColor = true;
            rdbPhongThuongDoi.CheckedChanged += rdbPhongThuongDoi_CheckedChanged;
            // 
            // rdbPhongThuongDon
            // 
            rdbPhongThuongDon.AutoSize = true;
            rdbPhongThuongDon.Font = new Font("Segoe UI", 9F);
            rdbPhongThuongDon.Location = new Point(160, 30);
            rdbPhongThuongDon.Name = "rdbPhongThuongDon";
            rdbPhongThuongDon.Size = new Size(134, 24);
            rdbPhongThuongDon.TabIndex = 3;
            rdbPhongThuongDon.TabStop = true;
            rdbPhongThuongDon.Text = "Thường đơn";
            rdbPhongThuongDon.UseVisualStyleBackColor = true;
            rdbPhongThuongDon.CheckedChanged += rdbPhongThuongDon_CheckedChanged;
            // 
            // rdbPhongVipDoi
            // 
            rdbPhongVipDoi.AutoSize = true;
            rdbPhongVipDoi.Font = new Font("Segoe UI", 9F);
            rdbPhongVipDoi.Location = new Point(15, 100);
            rdbPhongVipDoi.Name = "rdbPhongVipDoi";
            rdbPhongVipDoi.Size = new Size(97, 24);
            rdbPhongVipDoi.TabIndex = 2;
            rdbPhongVipDoi.TabStop = true;
            rdbPhongVipDoi.Text = "VIP đôi";
            rdbPhongVipDoi.UseVisualStyleBackColor = true;
            rdbPhongVipDoi.CheckedChanged += rdbPhongVipDoi_CheckedChanged;
            // 
            // rdbPhongVipDon
            // 
            rdbPhongVipDon.AutoSize = true;
            rdbPhongVipDon.Font = new Font("Segoe UI", 9F);
            rdbPhongVipDon.Location = new Point(15, 65);
            rdbPhongVipDon.Name = "rdbPhongVipDon";
            rdbPhongVipDon.Size = new Size(101, 24);
            rdbPhongVipDon.TabIndex = 1;
            rdbPhongVipDon.TabStop = true;
            rdbPhongVipDon.Text = "VIP đơn";
            rdbPhongVipDon.UseVisualStyleBackColor = true;
            rdbPhongVipDon.CheckedChanged += rdbPhongVipDon_CheckedChanged;
            // 
            // rdbTatCaLoaiPhong
            // 
            rdbTatCaLoaiPhong.AutoSize = true;
            rdbTatCaLoaiPhong.Font = new Font("Segoe UI", 9F);
            rdbTatCaLoaiPhong.Location = new Point(15, 30);
            rdbTatCaLoaiPhong.Name = "rdbTatCaLoaiPhong";
            rdbTatCaLoaiPhong.Size = new Size(90, 24);
            rdbTatCaLoaiPhong.TabIndex = 0;
            rdbTatCaLoaiPhong.TabStop = true;
            rdbTatCaLoaiPhong.Text = "Tất cả";
            rdbTatCaLoaiPhong.UseVisualStyleBackColor = true;
            rdbTatCaLoaiPhong.CheckedChanged += rdbTatCaLoaiPhong_CheckedChanged;
            // 
            // grpDonDep
            // 
            grpDonDep.Controls.Add(rdbPhongChuaDon);
            grpDonDep.Controls.Add(rdbPhongDaDonDep);
            grpDonDep.Controls.Add(rdbTatCaPhong);
            grpDonDep.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpDonDep.Location = new Point(705, 60);
            grpDonDep.Name = "grpDonDep";
            grpDonDep.Size = new Size(318, 150);
            grpDonDep.TabIndex = 6;
            grpDonDep.TabStop = false;
            grpDonDep.Text = "Tình trạng dọn dẹp";
            // 
            // rdbPhongChuaDon
            // 
            rdbPhongChuaDon.AutoSize = true;
            rdbPhongChuaDon.Font = new Font("Segoe UI", 9F);
            rdbPhongChuaDon.Location = new Point(15, 100);
            rdbPhongChuaDon.Name = "rdbPhongChuaDon";
            rdbPhongChuaDon.Size = new Size(137, 24);
            rdbPhongChuaDon.TabIndex = 2;
            rdbPhongChuaDon.TabStop = true;
            rdbPhongChuaDon.Text = "Chưa dọn dẹp";
            rdbPhongChuaDon.UseVisualStyleBackColor = true;
            rdbPhongChuaDon.CheckedChanged += rdbPhongChuaDon_CheckedChanged;
            // 
            // rdbPhongDaDonDep
            // 
            rdbPhongDaDonDep.AutoSize = true;
            rdbPhongDaDonDep.Font = new Font("Segoe UI", 9F);
            rdbPhongDaDonDep.Location = new Point(15, 65);
            rdbPhongDaDonDep.Name = "rdbPhongDaDonDep";
            rdbPhongDaDonDep.Size = new Size(123, 24);
            rdbPhongDaDonDep.TabIndex = 1;
            rdbPhongDaDonDep.TabStop = true;
            rdbPhongDaDonDep.Text = "Đã dọn dẹp";
            rdbPhongDaDonDep.UseVisualStyleBackColor = true;
            rdbPhongDaDonDep.CheckedChanged += rdbPhongDaDonDep_CheckedChanged;
            // 
            // rdbTatCaPhong
            // 
            rdbTatCaPhong.AutoSize = true;
            rdbTatCaPhong.Font = new Font("Segoe UI", 9F);
            rdbTatCaPhong.Location = new Point(15, 30);
            rdbTatCaPhong.Name = "rdbTatCaPhong";
            rdbTatCaPhong.Size = new Size(90, 24);
            rdbTatCaPhong.TabIndex = 0;
            rdbTatCaPhong.TabStop = true;
            rdbTatCaPhong.Text = "Tất cả";
            rdbTatCaPhong.UseVisualStyleBackColor = true;
            rdbTatCaPhong.CheckedChanged += rdbTatCaPhong_CheckedChanged;
            // 
            // dtNgayChon
            // 
            dtNgayChon.CustomFormat = "dd/MM/yyyy";
            dtNgayChon.Font = new Font("Segoe UI", 10F);
            dtNgayChon.Format = DateTimePickerFormat.Custom;
            dtNgayChon.Location = new Point(480, 18);
            dtNgayChon.Name = "dtNgayChon";
            dtNgayChon.Size = new Size(210, 30);
            dtNgayChon.TabIndex = 3;
            dtNgayChon.ValueChanged += dtNgayChon_ValueChanged;
            // 
            // lblNgay
            // 
            lblNgay.AutoSize = true;
            lblNgay.Font = new Font("Segoe UI", 10F);
            lblNgay.Location = new Point(360, 21);
            lblNgay.Name = "lblNgay";
            lblNgay.Size = new Size(107, 23);
            lblNgay.TabIndex = 2;
            lblNgay.Text = "Xem theo ngày:";
            // 
            // lblTimKiem
            // 
            lblTimKiem.AutoSize = true;
            lblTimKiem.Font = new Font("Segoe UI", 10F);
            lblTimKiem.Location = new Point(16, 21);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(116, 23);
            lblTimKiem.TabIndex = 0;
            lblTimKiem.Text = "Tìm mã phòng:";
            // 
            // btnDatPhong
            // 
            btnDatPhong.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDatPhong.BackColor = Color.LightSkyBlue;
            btnDatPhong.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnDatPhong.Location = new Point(880, 12);
            btnDatPhong.Name = "btnDatPhong";
            btnDatPhong.Size = new Size(143, 42);
            btnDatPhong.TabIndex = 7;
            btnDatPhong.Text = "Đặt phòng";
            btnDatPhong.UseVisualStyleBackColor = false;
            btnDatPhong.Click += btnDatPhong_Click;
            // 
            // dataGridViewPhong
            // 
            dataGridViewPhong.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewPhong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPhong.Location = new Point(16, 225);
            dataGridViewPhong.Name = "dataGridViewPhong";
            dataGridViewPhong.RowHeadersWidth = 51;
            dataGridViewPhong.RowTemplate.Height = 29;
            dataGridViewPhong.Size = new Size(1007, 460);
            dataGridViewPhong.TabIndex = 8;
            // 
            // FormSoDoPhong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1039, 699);
            Controls.Add(dataGridViewPhong);
            Controls.Add(btnDatPhong);
            Controls.Add(lblNgay);
            Controls.Add(dtNgayChon);
            Controls.Add(grpDonDep);
            Controls.Add(grpLoaiPhong);
            Controls.Add(grpTrangThaiPhong);
            Controls.Add(txtSearchMaPhong);
            Controls.Add(lblTimKiem);
            Name = "FormSoDoPhong";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sơ đồ phòng";
            Load += FormSoDoPhong_Load;
            grpTrangThaiPhong.ResumeLayout(false);
            grpTrangThaiPhong.PerformLayout();
            grpLoaiPhong.ResumeLayout(false);
            grpLoaiPhong.PerformLayout();
            grpDonDep.ResumeLayout(false);
            grpDonDep.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPhong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolTip toolTip1;
        private TextBox txtSearchMaPhong;
        private GroupBox grpTrangThaiPhong;
        private RadioButton rdbPhongDangSuaChua;
        private RadioButton rdbPhongDangThue;
        private RadioButton rdbPhongDaDat;
        private RadioButton rdbPhongTrong;
        private RadioButton rdbTatCaTrangThaiPhong;
        private GroupBox grpLoaiPhong;
        private RadioButton rdbPhongThuongDoi;
        private RadioButton rdbPhongThuongDon;
        private RadioButton rdbPhongVipDoi;
        private RadioButton rdbPhongVipDon;
        private RadioButton rdbTatCaLoaiPhong;
        private GroupBox grpDonDep;
        private RadioButton rdbPhongChuaDon;
        private RadioButton rdbPhongDaDonDep;
        private RadioButton rdbTatCaPhong;
        private DateTimePicker dtNgayChon;
        private Label lblNgay;
        private Label lblTimKiem;
        private Button btnDatPhong;
        private DataGridView dataGridViewPhong;
    }
}
