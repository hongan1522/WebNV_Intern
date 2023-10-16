# WebNV_Intern
Đây là báo cáo kết quả về task web API sau khoảng thời gian làm của tôi tại Gonsa


![Ảnh chụp màn hình 2023-10-16 164250](https://github.com/hongan1522/WebNV_Intern/assets/95673805/85f102b7-dfea-4438-960e-10511b021e2c)

![Ảnh chụp màn hình 2023-10-16 164405](https://github.com/hongan1522/WebNV_Intern/assets/95673805/c8f82676-e4bf-4d91-942f-56bd9802ae95)

![Ảnh chụp màn hình 2023-10-16 164505](https://github.com/hongan1522/WebNV_Intern/assets/95673805/9a79bab3-f7a8-477b-bca6-cf1cbcd739b8)

Nhân viên có các trường dữ liệu:
- Mã nhân viên (string)
- Tên nhân viên (string)
- Ngày sinh (Datetime)
- Email (string)
- SĐT (string)
- Địa chỉ (string)
- Chức vụ chỉ có 3 giá trị: "Backend", "Frontend", "Teamlead" (string). Với chức vụ "Backend" thì mã sẽ là "BE00001", chức vụ "Frontend" thì mã sẽ là "FE00001", chức vụ "Teamlead" thì mã sẽ là "TL00001". Và mã sẽ tự tăng khi cập nhật.  

Project đọc dữ liệu từ file json để xử lý các phương thức và mỗi khi thực hiện sẽ cập nhật vào file json
- Get sắp xếp theo các chức vụ cũng như thữ tự tăng dần
- Post (chức năng Post và Put gộp lại thành 1) có thể đổi các trường cũng như khi đổi chức vụ sẽ cập nhật mã chức vụ mới và xóa mã cũ
- Delete xóa các mã sẽ tự cập nhật mã lại theo thứ tự 



