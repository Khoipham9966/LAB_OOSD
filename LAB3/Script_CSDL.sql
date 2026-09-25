-- Tạo bảng Khu Vực
CREATE TABLE KhuVuc (
    MaKhuVuc TEXT PRIMARY KEY,
    TenKhuVuc TEXT
);

-- Tạo bảng Phòng có liên kết khóa ngoại với Khu Vực
CREATE TABLE Phong (
    SoPhong TEXT PRIMARY KEY,
    SoNguoiToiDa INTEGER,
    DonGiaNgay REAL,
    TrangThai TEXT,
    MaKhuVuc TEXT,
    FOREIGN KEY(MaKhuVuc) REFERENCES KhuVuc(MaKhuVuc)
);

-- Tạo bảng Khách Hàng
CREATE TABLE KhachHang (
    MaKhach TEXT PRIMARY KEY,
    HoTen TEXT,
    SoCMND TEXT,
    QuocTich TEXT,
    SoDienThoai TEXT
);

-- Tạo bảng Nhân Viên
CREATE TABLE NhanVien (
    MaNV TEXT PRIMARY KEY,
    HoTen TEXT,
    VaiTro TEXT,
    SoDienThoai TEXT
);

-- Tạo bảng Phiếu Đặt Phòng liên kết với Khách Hàng
CREATE TABLE PhieuDatPhong (
    SoPhieuDat TEXT PRIMARY KEY,
    NgayLap TEXT,
    NgayNhan TEXT,
    NgayTraDuKien TEXT,
    TienCoc REAL,
    KenhDat TEXT,
    TrangThai TEXT,
    NgayNhanThucTe TEXT,
    NgayTraThucTe TEXT,
    MaKhach TEXT,
    FOREIGN KEY(MaKhach) REFERENCES KhachHang(MaKhach)
);

-- Thêm dữ liệu mẫu để chụp minh chứng
INSERT INTO KhuVuc VALUES ('KV01', 'Tang 1'), ('KV02', 'Tang 2');
INSERT INTO Phong VALUES ('P101', 2, 500000, 'Trong', 'KV01'), ('P201', 4, 800000, 'Da dat', 'KV02');
INSERT INTO KhachHang VALUES ('KH01', 'Nguyen Van A', '0123456789', 'Viet Nam', '0909123456');
INSERT INTO NhanVien VALUES ('NV01', 'Tran Thi B', 'Tiep tan', '0988111222');
INSERT INTO PhieuDatPhong VALUES ('DP01', '2025-10-25', '2025-10-26', '2025-10-28', 500000, 'Truc tiep', 'Cho nhan', '', '', 'KH01');

-- Lệnh hiển thị bảng
SELECT * FROM Phong;
SELECT * FROM PhieuDatPhong;