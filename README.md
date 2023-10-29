# WebNV_Intern
Đây là báo cáo kết quả về task web API sau khoảng thời gian làm của tôi tại Gonsa

## **WebIntern.Project NhanVien**

Phuong thức Get
![Ảnh chụp màn hình 2023-10-16 164250](https://github.com/hongan1522/WebNV_Intern/assets/95673805/85f102b7-dfea-4438-960e-10511b021e2c)

Phương thức Post và Put gộp chung
![Ảnh chụp màn hình 2023-10-16 164405](https://github.com/hongan1522/WebNV_Intern/assets/95673805/c8f82676-e4bf-4d91-942f-56bd9802ae95)

Phương thức Delete
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
- Post để thêm nhân viên, Put để cập nhật thông tin nhân viên lại, trừ mã (chức năng Post và Put gộp lại thành 1) có thể đổi các trường cũng như khi đổi chức vụ sẽ cập nhật mã chức vụ mới và xóa mã cũ. Khi không tìm thấy mã sẽ Post nhân viên mới, tìm thấy mã thì Put lại thông tin nhân viên đó
- Deleted dùng xóa nhân viên, khi xóa các mã sẽ tự cập nhật mã lại theo thứ tự

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

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

## **SQL Server** 

Dữ liệu lưu vào table Employee
![image](https://github.com/hongan1522/WebNV_Intern/assets/95673805/80fce3a8-753f-49b1-8869-970759be4ddd)


## **Project FormIntern**

Giao diện người dùng khi load lên cũng như khi bấm nút Refresh
![image](https://github.com/hongan1522/WebNV_Intern/assets/95673805/bc1313a7-fb46-49f1-83a7-dc1eb0387435)

Giao diện khi chọn nhân viên trên bảng dữ liệu thì hiển thị thông tin lên các TextBox
![image](https://github.com/hongan1522/WebNV_Intern/assets/95673805/1444246f-e8ab-4860-a6f5-fadd5a5fe0eb)

Giao diện khi thêm 1 nhân viên
![image](https://github.com/hongan1522/WebNV_Intern/assets/95673805/0de65eac-f925-400b-93b3-ff9e91350f14)

Giao diện khi sửa 1 nhân viên
![image](https://github.com/hongan1522/WebNV_Intern/assets/95673805/09b03734-99b8-4619-8042-f713d51416ea)

Giao diện khi xóa 1 nhân viên
![image](https://github.com/hongan1522/WebNV_Intern/assets/95673805/8ac2fcce-f6eb-4430-9215-1ac39ad5858e)

Giao diện khi xóa nhiều nhân viên
![image](https://github.com/hongan1522/WebNV_Intern/assets/95673805/f9aae1f8-d1a7-4746-8f96-fbd0e4e0af66)

Giao diện khi Export ra file Excel
![image](https://github.com/hongan1522/WebNV_Intern/assets/95673805/4faf9469-e662-4346-ada8-776aef3ceb1a)

Giao diện khi Import từ file Excel, sẽ có các Id trùng trong CSDL hoặc không đúng định dạng trong file Excel
![image](https://github.com/hongan1522/WebNV_Intern/assets/95673805/52a94420-cdc4-4874-8715-3794084fd86b)

Giao diện Import thành công các Id nhân viên mới và đúng định dạng
![image](https://github.com/hongan1522/WebNV_Intern/assets/95673805/626b2ad1-4239-4cf9-a136-5b3c6d2e15a5)





Project FormIntern sẽ lấy API từ project WebIntern.Employee và lưu dữ liệu vào CSDL. Khi load Form lên thì sử dụng API Method.Get từ WebIntern.Employee để lấy dữ liệu hiển thị lên DataGridView cho người dùng xem thông tin các nhân viên. Với các chức năng chính:
- Thêm 1 nhân viên mới đúng định dạng và lưu vào CSDL, sau đó load lên DataGridView cho người dùng xem thông tin nhân viên mới thêm với việc sử dụng API Method.Post từ WebIntern.Employee 
- Refresh là xóa nội dung trong các TextBox 
- Xóa 1 nhân viên khi dùng API Method.Delete từ WebIntern.Employee
- Sửa 1 nhân viên mới đúng định dạng và lưu vào CSDL, sau đó load lên DataGridView cho người dùng xem thông tin nhân viên mới cập nhật với việc sử dụng API Method.Put từ WebIntern.Employee
- Import nhân viên từ file Excel, kiểm tra Id trùng hay không đúng định dạng thì không Import nhân viên đó, khi Import thành công sẽ thông báo và load thông tin các nhân viên mới Import lên DataGridView
- Export nhân viên ra file Excel, lưu các thông tin đầy đủ danh sách nhân viên vào file excel

## **Cách cài đặt**-
- Copy link HTTPS trong phần Code trên Github
- Tại máy tính, ta mở git bash gõ lệnh "git clone https://github.com/hongan1522/WebNV_Intern.git" rồi Enter
- Trong SQL Server:
  + Tạo Database tên EmpManager
  + Trong Folder đã clone về có file .sql, mở file đó và Excute toàn bộ
- Trong Project WebIntern: Đổi đường dẫn trong appsetting.json 

"ConnectionStrings": {
  *"ConnectEmpManager": "Server=**your-server**; Database=EmpManager; Integrated Security=True; Trusted_Connection=True; TrustServerCertificate=True; MultipleActiveResultSets=true"
}*
- Trong Project FormIntern: Đổi các đường dẫn trong UC_Employeess.cs với line 20, line 80, line 103, line 342

*var options = new DbContextOptionsBuilder<EmpManagerContext>()
    .UseSqlServer("Server=**your-server**; Database=EmpManager; Integrated Security=True; Trusted_Connection=True; TrustServerCertificate=True; MultipleActiveResultSets=true")
    .Options;
dbContext = new EmpManagerContext(options);*
- Sau đó bấm chạy, Project sẽ mở song song Web API và Form, thực hiện các phương thức trên Form 
