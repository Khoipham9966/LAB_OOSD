using System;

namespace EShopping.Service
{
    public class DonHangService
    {
        // Xử lý nghiệp vụ tính phí giao hàng theo quy định của cửa hàng
        public double TinhPhiGiaoHang(double tongTienHienTai, string loaiPhieuGiao)
        {
            // Miễn phí chuyển phát nhanh nếu tổng tiền >= 1.000.000đ
            if (tongTienHienTai >= 1000000 && loaiPhieuGiao == "Chuyển phát nhanh")
            {
                return 0;
            }
            // Miễn phí chuyển phát nhanh trong ngày nếu tổng tiền >= 5.000.000đ
            if (tongTienHienTai >= 5000000 && loaiPhieuGiao == "Chuyển phát nhanh trong ngày")
            {
                return 0;
            }
            
            // Trả về phí mặc định nếu không đạt điều kiện miễn phí
            return 30000; 
        }
    }
}