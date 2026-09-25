using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

// ================= FORM MENU CHÍNH =================
public class FormMain : Form
{
    public FormMain()
    {
        this.Text = "Quản lý khách sạn";
        this.Size = new Size(600, 350);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.BackColor = Color.WhiteSmoke;

        Label lblTitle = new Label { Text = "HỆ THỐNG QUẢN LÝ KHÁCH SẠN", Font = new Font("Arial", 16, FontStyle.Bold), ForeColor = Color.SteelBlue, AutoSize = true, Location = new Point(110, 30) };
        this.Controls.Add(lblTitle);

        Button btnDanhMuc = CreateButton("Danh mục", 50, 90);
        btnDanhMuc.Click += (s, e) => new FormDanhMuc().ShowDialog();

        Button btnPhong = CreateButton("Phòng - Tiện nghi", 215, 90);
        btnPhong.Click += (s, e) => new FormPhong().ShowDialog();

        Button btnDatPhong = CreateButton("Đặt / Nhận phòng", 380, 90);
        btnDatPhong.Click += (s, e) => new FormDatPhong().ShowDialog();

        Button btnDichVu = CreateButton("Sử dụng dịch vụ", 50, 150);
        btnDichVu.Click += (s, e) => new FormDichVu().ShowDialog();

        Button btnTraPhong = CreateButton("Trả phòng - Thanh toán", 215, 150);
        btnTraPhong.Click += (s, e) => new FormTraPhong().ShowDialog();

        Button btnThongKe = CreateButton("Thống kê", 380, 150);
        btnThongKe.Click += (s, e) => new FormThongKe().ShowDialog();
        
        Button btnThoat = CreateButton("Thoát", 215, 210);
        btnThoat.Click += (s, e) => Application.Exit();

        this.Controls.Add(btnDanhMuc); this.Controls.Add(btnPhong); this.Controls.Add(btnDatPhong);
        this.Controls.Add(btnDichVu); this.Controls.Add(btnTraPhong); this.Controls.Add(btnThongKe);
        this.Controls.Add(btnThoat);
    }

    private Button CreateButton(string text, int x, int y)
    {
        return new Button { Text = text, Location = new Point(x, y), Size = new Size(150, 40), BackColor = Color.White, FlatStyle = FlatStyle.Standard };
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new FormMain());
    }
}

// ================= LỚP CƠ SỞ TẠO FORM NHẬP LIỆU =================
public class BaseForm : Form
{
    public DataTable dt;
    public DataGridView dgv;
    public TextBox txt1, txt2, txt3;
    public Label lbl1, lbl2, lbl3;

    public BaseForm(string title, string col1, string col2, string col3)
    {
        this.Text = title;
        this.Size = new Size(580, 400);
        this.StartPosition = FormStartPosition.CenterParent;

        lbl1 = new Label { Location = new Point(20, 20), AutoSize = true };
        txt1 = new TextBox { Location = new Point(100, 20), Width = 120 };

        lbl2 = new Label { Location = new Point(250, 20), AutoSize = true };
        txt2 = new TextBox { Location = new Point(330, 20), Width = 120 };

        lbl3 = new Label { Location = new Point(20, 60), AutoSize = true };
        txt3 = new TextBox { Location = new Point(100, 60), Width = 120 };

        Button btnThem = new Button { Text = "Thêm mới", Location = new Point(250, 60), Size = new Size(80, 25) };
        btnThem.Click += (s, e) => { dt.Rows.Add(txt1.Text, txt2.Text, txt3.Text); txt1.Clear(); txt2.Clear(); txt3.Clear(); };

        dgv = new DataGridView { Location = new Point(20, 110), Size = new Size(520, 220), AllowUserToAddRows = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
        dt = new DataTable();
        dt.Columns.Add(col1); dt.Columns.Add(col2); dt.Columns.Add(col3);
        dgv.DataSource = dt;

        this.Controls.Add(lbl1); this.Controls.Add(txt1);
        this.Controls.Add(lbl2); this.Controls.Add(txt2);
        this.Controls.Add(lbl3); this.Controls.Add(txt3);
        this.Controls.Add(btnThem); this.Controls.Add(dgv);
    }
}

// ================= 6 FORM CHỨC NĂNG =================
public class FormDanhMuc : BaseForm {
    public FormDanhMuc() : base("Danh mục Khu Vực", "Mã Khu Vực", "Tên Khu Vực", "Mô Tả") {
        lbl1.Text = "Mã KV:"; lbl2.Text = "Tên KV:"; lbl3.Text = "Mô tả:";
        dt.Rows.Add("KV01", "Tầng 1", "Khu vực thường");
    }
}

public class FormPhong : BaseForm {
    public FormPhong() : base("Phòng - Tiện nghi", "Số Phòng", "Số Người", "Đơn Giá") {
        lbl1.Text = "Số Phòng:"; lbl2.Text = "Số Người:"; lbl3.Text = "Đơn giá:";
        dt.Rows.Add("P101", "2", "500000");
    }
}

public class FormDatPhong : BaseForm {
    public FormDatPhong() : base("Đặt / Nhận phòng", "Mã Phiếu", "Tên Khách", "SĐT") {
        lbl1.Text = "Mã Phiếu:"; lbl2.Text = "Tên Khách:"; lbl3.Text = "SĐT:";
        dt.Rows.Add("DP01", "Nguyễn Văn A", "0909123456");
    }
}

public class FormDichVu : BaseForm {
    public FormDichVu() : base("Sử dụng dịch vụ", "Số Phòng", "Tên Dịch Vụ", "Số Lượng") {
        lbl1.Text = "Số Phòng:"; lbl2.Text = "Tên DV:"; lbl3.Text = "Số lượng:";
        dt.Rows.Add("P101", "Giặt ủi", "2");
    }
}

public class FormTraPhong : BaseForm {
    public FormTraPhong() : base("Trả phòng - Thanh toán", "Mã Hóa Đơn", "Số Phòng", "Tổng Tiền") {
        lbl1.Text = "Mã HĐ:"; lbl2.Text = "Số Phòng:"; lbl3.Text = "Tổng Tiền:";
        dt.Rows.Add("HD01", "P101", "1500000");
    }
}

public class FormThongKe : BaseForm {
    public FormThongKe() : base("Thống kê", "Tháng", "Số Lượt Khách", "Tổng Doanh Thu") {
        lbl1.Text = "Tháng:"; lbl2.Text = "Lượt khách:"; lbl3.Text = "Doanh thu:";
        dt.Rows.Add("10/2025", "45", "45000000");
    }
}