# EzSchool

EzSchool là một hệ thống quản lý trường học giúp đơn giản hóa các quy trình quản lý học sinh, giáo viên, khóa học và thời khóa biểu. Dự án này sử dụng công nghệ **ASP.NET, C#, JavaScript, SCSS** cùng với **MySQL** để lưu trữ dữ liệu. Đây là đồ án cuối kì môn lập trình web.

## 🚀 Tính năng

- **Quản lý học sinh**: Thêm, sửa, xóa và xem thông tin học sinh.
- **Quản lý giáo viên**: Cập nhật thông tin giáo viên và phân công giảng dạy.
- **Quản lý khóa học**: Tạo, sửa đổi và xóa khóa học.
- **Lịch học**: Quản lý thời khóa biểu của giáo viên và học sinh.
- **Báo cáo**: Xuất dữ liệu thống kê về học sinh, giáo viên, khóa học.
- **Giao diện thân thiện**: Dễ sử dụng và tối ưu cho trải nghiệm người dùng.

## 📥 Cài đặt

### Yêu cầu hệ thống:
- **.NET Framework 6.0+**
- **MySQL Server**
- **Visual Studio 2022**
- **Node.js (nếu sử dụng các công cụ front-end hiện đại)**

### Hướng dẫn cài đặt:
1. **Clone dự án từ GitHub**:
   ```bash
   git clone https://github.com/SmallGia/EzSchool.git
   cd EzSchool
   ```

2. **Cấu hình cơ sở dữ liệu**:
   - Tạo một database MySQL mới.
   - Import tệp `db-final.sql` vào database.

3. **Chạy dự án**:
   - Mở **EzSchool.sln** bằng **Visual Studio**.
   - Cấu hình **connection string** trong `appsettings.json` để kết nối với database.
   - Chạy ứng dụng (`F5` trong Visual Studio).

## 🖥 Sử dụng

Sau khi khởi động thành công, hệ thống có thể truy cập qua trình duyệt tại:

```
http://localhost:5000
```

## 🤝 Đóng góp

Chúng tôi hoan nghênh mọi đóng góp để cải thiện EzSchool. Vui lòng làm theo các bước sau:

1. **Fork** dự án trên GitHub.
2. **Tạo nhánh mới**:  
   ```bash
   git checkout -b feature/ten-tinh-nang
   ```
3. **Commit thay đổi**:  
   ```bash
   git commit -m "Mô tả tính năng mới"
   ```
4. **Push lên nhánh của bạn**:  
   ```bash
   git push origin feature/ten-tinh-nang
   ```
5. **Tạo Pull Request** trên GitHub.

## 📜 lIÊN HỆ

✉️ Email: thp.gia@gmail.com

---

💡 *Nếu bạn gặp bất kỳ vấn đề nào, vui lòng mở một [Issue](https://github.com/SmallGia/EzSchool/issues) trên GitHub!* 🚀
