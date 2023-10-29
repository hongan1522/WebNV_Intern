# WebNV_Intern
Đây là báo cáo kết quả về task web API sau khoảng thời gian làm của tôi tại Gonsa

## **WebIntern.Project NhanVien**


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

Project WebIntern.NhanVien đọc dữ liệu từ file json để xử lý các phương thức và mỗi khi thực hiện sẽ cập nhật vào file json
- Get để xem dữ liệu, được sắp xếp theo các chức vụ cũng như thữ tự tăng dần
- Post để thêm nhân viên, Put để cập nhật thông tin nhân viên lại, trừ mã (chức năng Post và Put gộp lại thành 1) có thể đổi các trường cũng như khi đổi chức vụ sẽ cập nhật mã chức vụ mới và xóa mã cũ
- Deleted dùng xóa nhân viên, khi xóa các mã sẽ tự cập nhật mã lại theo thứ tự

## **Project WebIntern.Employees**

Phương thức GetEmp
![image](https://github.com/hongan1522/WebNV_Intern/assets/95673805/92a11bfe-2c66-4180-80e5-b97398114a10)

Phương thức AddEmp
![image](https://github.com/hongan1522/WebNV_Intern/assets/95673805/5c3099ce-9c08-4923-a6b2-b33fa58faf98)

Phương thức UpdateEmp
![image](https://github.com/hongan1522/WebNV_Intern/assets/95673805/8cfb203f-c865-449a-95f2-739230237c4f)

Phương thức DeleteEmp
![image](https://github.com/hongan1522/WebNV_Intern/assets/95673805/e75925d5-4c04-41f3-afc1-6846fec50f7e)


Employee có các trường dữ liệu:
- Id (string)
- Name (string)
- Birthday (Datetime)
- Email (string)
- Phone (string)
- Address (string)
- Position chỉ có 3 giá trị: "Backend", "Frontend", "Teamlead" (string). Với chức vụ "Backend" thì mã sẽ là "BE0001", chức vụ "Frontend" thì mã sẽ là "FE0001", chức vụ "Teamlead" thì mã sẽ là "TL0001". Và mã sẽ tự tăng khi thêm.
  
Project WebIntern.Employee đọc dữ liệu từ cơ sở dữ liệu (CSDL) SQL Server để xử lý các phương thức và mỗi khi cập nhật sẽ lưu vào CSDL 
- Get để xem dữ liệu, sắp xếp theo các chức vụ cũng như thữ tự tăng dần
- Post để thêm mới 1 Employee, khi thêm sẽ tự động tạo mã mới mà không trùng nhau trong CSDL, tạo mã đúng định dạng theo từng Position
- Put để sửa lại thông tin Employee 
- Delete dùng để xóa Employee

## **Project FormIntern**

Giao diện người dùng
![image](https://github.com/hongan1522/WebNV_Intern/assets/95673805/bc1313a7-fb46-49f1-83a7-dc1eb0387435)

Giao diện khi chọn nhân viên trên bảng dữ liệu thì hiển thị thông tin lên các TextBox
![image](https://github.com/hongan1522/WebNV_Intern/assets/95673805/1444246f-e8ab-4860-a6f5-fadd5a5fe0eb)



Project FormIntern sẽ lấp API từ project WebIntern.Employee và lưu dữ liệu vào CSDL. Khi load Form lên thì sử dụng API Method.Get từ WebIntern.Employee để lấy dữ liệu hiển thị lên DataGridView cho người dùng xem thông tin các nhân viên. Với các chức năng chính:
- Thêm 1 nhân viên mới đúng định dạng và lưu vào CSDL, sau đó load lên DataGridView cho người dùng xem thông tin nhân viên mới thêm với việc sử dụng API Method.Post từ WebIntern.Employee 
- Refresh là xóa nội dung trong các TextBox 
- Xóa 1 nhân viên khi dùng API Method.Delete từ WebIntern.Employee
- Sửa 1 nhân viên mới đúng định dạng và lưu vào CSDL, sau đó load lên DataGridView cho người dùng xem thông tin nhân viên mới cập nhật với việc sử dụng API Method.Put từ WebIntern.Employee
- Import nhân viên từ file Excel, kiểm tra Id trùng hay không đúng định dạng thì không Import nhân viên đó, khi Import thành công sẽ thông báo và load thông tin các nhân viên mới Import lên DataGridView
- Export nhân viên ra file Excel, lưu các thông tin đầy đủ danh sách nhân viên vào file excel


