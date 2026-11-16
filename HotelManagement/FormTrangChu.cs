namespace HotelManagement;

/// <summary>Màn hình chào ở trang chủ (UserControl): ảnh khách sạn phủ kín vùng nội dung.</summary>
public class FormTrangChu : UserControl
{
    public FormTrangChu()
    {
        var pictureBox1 = new PictureBox
        {
            Dock = DockStyle.Fill,
            Image = Properties.Resources.pictureIcon,
            SizeMode = PictureBoxSizeMode.StretchImage,
            TabStop = false
        };
        Controls.Add(pictureBox1);
    }
}
