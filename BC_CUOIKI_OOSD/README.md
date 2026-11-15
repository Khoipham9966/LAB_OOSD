Đề tài: EDU-05 – Hệ thống cố vấn học tập dựa trên hồ sơ năng lực
Sinh viên thực hiện: Phạm Ngọc Khôi
MSSV: 1250080086

1. Công nghệ sử dụng

• Backend: Java 25, Spring Boot 4.0.9, Spring Web MVC, Spring JDBC và Spring Security.
• Frontend: React 19.2 và Vite 7.
• Cơ sở dữ liệu: PostgreSQL.
• Công cụ phát triển: Maven, Node.js và npm.

Ứng dụng được tổ chức theo mô hình frontend gọi REST API của backend; backend xử lý nghiệp vụ và truy cập PostgreSQL. Trong phiên bản hiện tại, phần xử lý nghiệp vụ và truy vấn dữ liệu chủ yếu được đặt trong ApiController.java.


2. Cấu trúc thư mục

EDU05_PhanMem_Mau/
├── backend/
│   ├── pom.xml
│   └── src/main/
│       ├── java/vn/edu05/
│       │   ├── Edu05Application.java
│       │   ├── ApiController.java
│       │   └── SecurityConfig.java
│       └── resources/application.properties
├── frontend/
│   ├── package.json
│   ├── vite.config.js
│   └── src/
│       ├── App.jsx
│       ├── api.js
│       ├── main.jsx
│       └── style.css
└── database/
    ├── 01_schema.sql
    └── 02_du_lieu_mau.sql

3. Cơ sở dữ liệu

Cơ sở dữ liệu sử dụng PostgreSQL. Hai tệp SQL nằm trong thư mục database:

• 01_schema.sql: tạo cấu trúc gồm 12 bảng và các ràng buộc dữ liệu.
• 02_du_lieu_mau.sql: thêm tài khoản và dữ liệu giả lập để phục vụ việc xem các luồng chức năng.

4. Cài đặt và chạy chương trình

Yêu cầu môi trường

• JDK 25.
• Apache Maven 3.9 trở lên.
• Node.js phiên bản LTS và npm.
• PostgreSQL và pgAdmin 4.

Khởi tạo cơ sở dữ liệu

1. Mở pgAdmin 4 và kết nối PostgreSQL.
2. Tạo database có tên edu05.
3. Mở Query Tool của database vừa tạo.
4. Chạy lần lượt database/01_schema.sql và database/02_du_lieu_mau.sql.

Chạy backend

Mở PowerShell tại thư mục EDU05_PhanMem_Mau:

cd backend
$env:DB_USER="postgres"
$env:DB_PASSWORD="MAT_KHAU_POSTGRES_CUA_BAN"
mvn spring-boot:run

Thay MAT_KHAU_POSTGRES_CUA_BAN bằng mật khẩu PostgreSQL đang sử dụng trên máy. Backend mặc định chạy tại cổng 8080.

Chạy frontend

Mở thêm một cửa sổ PowerShell khác tại thư mục EDU05_PhanMem_Mau, sau đó chạy:

cd frontend
npm install
npm run dev

Sau khi Vite khởi động, mở địa chỉ http://localhost:5173 trên trình duyệt. Cần giữ cả hai cửa sổ terminal hoạt động trong thời gian sử dụng ứng dụng.

5. Tài khoản dữ liệu mẫu

|Vai trò      |Tài khoản  |
|-------------|-----------|
|Quản trị viên|`admin`    |
|Cố vấn       |`covan`    |
|Người học    |`sinhvien1`|
|Người học    |`sinhvien2`|

Mật khẩu dùng cho các tài khoản dữ liệu mẫu: Demo@123.

6. Một số API chính

Các endpoint được khai báo trong backend/src/main/java/vn/edu05/ApiController.java:

|Phương thức|Endpoint                        |Chức năng                               |
|-----------|--------------------------------|----------------------------------------|
|GET        |`/api/health`                   |Kiểm tra trạng thái backend             |
|GET        |`/api/me`                       |Lấy thông tin tài khoản hiện tại        |
|GET        |`/api/students`                 |Danh sách người học thuộc phạm vi cố vấn|
|GET        |`/api/profiles/{studentId}`     |Xem hồ sơ năng lực                      |
|GET        |`/api/alerts`                   |Danh sách cảnh báo                      |
|POST       |`/api/alerts/generate`          |Kích hoạt sinh cảnh báo thủ công        |
|PATCH      |`/api/alerts/{alertId}/review`  |Duyệt hoặc từ chối cảnh báo             |
|POST       |`/api/alerts/{alertId}/feedback`|Gửi phản hồi                            |
|PATCH      |`/api/alerts/{alertId}/resolve` |Cập nhật xử lý cảnh báo                 |
|POST       |`/api/alerts/{alertId}/plans`   |Tạo kế hoạch can thiệp                  |
|GET        |`/api/plans`                    |Danh sách kế hoạch can thiệp            |
|GET/POST   |`/api/admin/users`              |Xem và tạo tài khoản                    |
|GET/POST   |`/api/admin/rules`              |Xem và tạo quy tắc cảnh báo             |
|PUT        |`/api/password`                 |Đổi mật khẩu                            |


