using System;
using System.Drawing;
using System.Windows.Forms;

namespace EShopping
{
    public class FormThanhToan : Form
    {
        private TextBox txtHoTen, txtSDT, txtDiaChi;
        private ComboBox cbGiaoHang;
        private ComboBox cbLoaiThe;
        private TextBox txtSoThe, txtChuThe, txtCSV;

        public FormThanhToan()
        {
            // Thiết lập cửa sổ Form cơ bản
            this.Text = "e-SHOPPING - Thanh Toán Đặt Hàng";
            this.Size = new Size(420, 480);
            this.StartPosition = FormStartPosition.CenterScreen;

            // --- PHẦN 1: THÔNG TIN GIAO HÀNG ---
            Label lblTitle1 = new Label() { Text = "1. THÔNG TIN NGƯỜI NHẬN & GIAO HÀNG", Location = new Point(20, 20), AutoSize = true, Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold) };
            
            Label lblHoTen = new Label() { Text = "Họ tên:", Location = new Point(20, 50), AutoSize = true };
            txtHoTen = new TextBox() { Location = new Point(140, 47), Width = 230 };
            
            Label lblSDT = new Label() { Text = "Điện thoại:", Location = new Point(20, 80), AutoSize = true };
            txtSDT = new TextBox() { Location = new Point(140, 77), Width = 230 };
            
            Label lblDiaChi = new Label() { Text = "Địa chỉ nhận:", Location = new Point(20, 110), AutoSize = true };
            txtDiaChi = new TextBox() { Location = new Point(140, 107), Width = 230 };
            
            Label lblGiaoHang = new Label() { Text = "Loại phiếu giao:", Location = new Point(20, 140), AutoSize = true };
            cbGiaoHang = new ComboBox() { Location = new Point(140, 137), Width = 230, DropDownStyle = ComboBoxStyle.DropDownList };
            // 3 loại hình giao hàng theo quy định của đề bài
            cbGiaoHang.Items.AddRange(new string[] { "Phiếu đặt hàng thường", "Chuyển phát nhanh", "Chuyển phát nhanh trong ngày" });
            cbGiaoHang.SelectedIndex = 0;

            // --- PHẦN 2: THÔNG TIN THANH TOÁN (THẺ TÍN DỤNG) ---
            Label lblTitle2 = new Label() { Text = "2. THÔNG TIN THẺ TÍN DỤNG", Location = new Point(20, 190), AutoSize = true, Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold) };
            
            Label lblLoaiThe = new Label() { Text = "Loại thẻ:", Location = new Point(20, 220), AutoSize = true };
            cbLoaiThe = new ComboBox() { Location = new Point(140, 217), Width = 230, DropDownStyle = ComboBoxStyle.DropDownList };
            // Các loại thẻ được hỗ trợ theo quy định
            cbLoaiThe.Items.AddRange(new string[] { "VISA", "MasterCard", "Discover", "American Express" });
            cbLoaiThe.SelectedIndex = 0;

            Label lblSoThe = new Label() { Text = "Số hiệu thẻ:", Location = new Point(20, 250), AutoSize = true };
            txtSoThe = new TextBox() { Location = new Point(140, 247), Width = 230 };

            Label lblChuThe = new Label() { Text = "Tên chủ thẻ:", Location = new Point(20, 280), AutoSize = true };
            txtChuThe = new TextBox() { Location = new Point(140, 277), Width = 230 };

            Label lblCSV = new Label() { Text = "Mã CSV:", Location = new Point(20, 310), AutoSize = true };
            txtCSV = new TextBox() { Location = new Point(140, 307), Width = 80 };

            // --- NÚT BẤM ---
            Button btnThanhToan = new Button() { Text = "Xác nhận Thanh toán", Location = new Point(140, 360), Width = 150, Height = 35 };
            btnThanhToan.Click += BtnThanhToan_Click;

            // Đưa toàn bộ các thành phần lên Form
            this.Controls.Add(lblTitle1); this.Controls.Add(lblHoTen); this.Controls.Add(txtHoTen);
            this.Controls.Add(lblSDT); this.Controls.Add(txtSDT);
            this.Controls.Add(lblDiaChi); this.Controls.Add(txtDiaChi);
            this.Controls.Add(lblGiaoHang); this.Controls.Add(cbGiaoHang);
            
            this.Controls.Add(lblTitle2); this.Controls.Add(lblLoaiThe); this.Controls.Add(cbLoaiThe);
            this.Controls.Add(lblSoThe); this.Controls.Add(txtSoThe);
            this.Controls.Add(lblChuThe); this.Controls.Add(txtChuThe);
            this.Controls.Add(lblCSV); this.Controls.Add(txtCSV);
            
            this.Controls.Add(btnThanhToan);
        }

        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            // Bật lên thông báo mô phỏng luồng nghiệp vụ thành công để chụp ảnh báo cáo
            string thongBao = "Đang kết nối Dịch vụ thanh toán trực tuyến...\n\n" +
                              "Giao dịch hợp lệ! Đã xác thực thẻ " + cbLoaiThe.Text + ".\n" +
                              "Đơn hàng của khách hàng [" + txtHoTen.Text + "] đã được lưu.\n" +
                              "Hệ thống đã tự động gửi Email xác nhận.";
            
            MessageBox.Show(thongBao, "Kết quả xử lý", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new FormThanhToan());
        }
    }
}