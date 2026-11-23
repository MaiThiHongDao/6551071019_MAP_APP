namespace HotelManagement.Helpers;

/// <summary>Form nền dùng chung cho các hộp thoại Thêm/Sửa: lưới "nhãn - ô nhập" + nút Lưu/Hủy.</summary>
public class FormNhapLieu : Form
{
    protected readonly TableLayoutPanel Bang = new()
    {
        Dock = DockStyle.Top,
        AutoSize = true,
        ColumnCount = 2,
        Padding = new Padding(16, 16, 16, 0)
    };
    protected readonly Button BtnLuu = new() { Text = "Lưu", Width = 100, Height = 36 };
    protected readonly Button BtnHuy = new() { Text = "Hủy", Width = 100, Height = 36, DialogResult = DialogResult.Cancel };

    public FormNhapLieu(string tieuDe)
    {
        Text = tieuDe;
        Font = new Font("Segoe UI", 11F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        StartPosition = FormStartPosition.CenterParent;
        MaximizeBox = false;
        MinimizeBox = false;
        ShowInTaskbar = false;
        ClientSize = new Size(520, 440);

        Bang.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160));
        Bang.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

        var pnlNut = new FlowLayoutPanel
        {
            Dock = DockStyle.Bottom,
            Height = 60,
            FlowDirection = FlowDirection.RightToLeft,
            Padding = new Padding(12)
        };
        pnlNut.Controls.Add(BtnHuy);
        pnlNut.Controls.Add(BtnLuu);

        Controls.Add(Bang);
        Controls.Add(pnlNut);
        AcceptButton = BtnLuu;
        CancelButton = BtnHuy;
        BtnLuu.Click += (_, _) => Luu();
    }

    protected T ThemTruong<T>(string nhan, T control) where T : Control
    {
        control.Dock = DockStyle.Fill;
        control.Margin = new Padding(3, 6, 3, 6);
        int hang = Bang.RowCount;
        Bang.RowCount++;
        Bang.Controls.Add(new Label
        {
            Text = nhan,
            AutoSize = true,
            Anchor = AnchorStyles.Left,
            Margin = new Padding(3, 10, 3, 6)
        }, 0, hang);
        Bang.Controls.Add(control, 1, hang);
        return control;
    }

    protected virtual void Luu() { }

    protected void LuuXong()
    {
        DialogResult = DialogResult.OK;
        Close();
    }

    protected static void Loi(string noiDung) =>
        MessageBox.Show(noiDung, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
}
