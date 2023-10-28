using RestSharp;
using Newtonsoft.Json;
using WebIntern.Models;
using OfficeOpenXml;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace FormIntern
{
    public partial class UC_Employees : UserControl
    {
        private string apiUrl = "https://localhost:44353/api/Employees";
        private RestClient restClient = new RestClient();

        private EmpManagerContext dbContext;

        public UC_Employees()
        {
            InitializeComponent();
            var options = new DbContextOptionsBuilder<EmpManagerContext>()
                .UseSqlServer("Server=DESKTOP-CMSGFMS\\HONGAN; Database=EmpManager; Integrated Security=True; Trusted_Connection=True; TrustServerCertificate=True; MultipleActiveResultSets=true")
                .Options;
            dbContext = new EmpManagerContext(options);

            txtId.Enabled = false;
            SendGetRequest();
        }
        private async Task<List<Employee>> SendGetRequest()
        {
            RestRequest request = new RestRequest(apiUrl + "/GetEmp", Method.Get);

            RestResponse response = await restClient.ExecuteAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string content = response.Content;
                List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(content);
                DisplayEmployees(employees);
                return employees;
            }
            else
            {
                MessageBox.Show("Kết nối thất bại: " + response.StatusCode, "Error");
                return new List<Employee>();
            }
        }
        private void DisplayEmployees(List<Employee> employees)
        {
            dgvEmp.AutoGenerateColumns = true;
            dgvEmp.DataSource = employees;
            cbPosition.SelectedItem = "Frontend";
            dgvEmp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Không cho phép người dùng thay đổi kích thước các cột
            foreach (DataGridViewColumn column in dgvEmp.Columns)
            {
                column.Resizable = DataGridViewTriState.False;
            }

            // Chỉnh tiêu đề căn giữa và in đậm
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.Font = new Font(dgvEmp.Font, FontStyle.Bold);

            foreach (DataGridViewColumn column in dgvEmp.Columns)
            {
                column.HeaderCell.Style = headerStyle;
            }
        }
        private bool IsPhoneNumberValid(string phoneNumber, string employeeId)
        {
            // Kiểm tra định dạng số điện thoại (bắt đầu từ 0, 10 chữ số)
            string phonePattern = @"^0\d{9}$";
            Regex regex = new Regex(phonePattern);
            Match match = regex.Match(phoneNumber);

            // Nếu số điện thoại đúng định dạng
            if (match.Success)
            {
                var options = new DbContextOptionsBuilder<EmpManagerContext>()
                    .UseSqlServer("Server=DESKTOP-CMSGFMS\\HONGAN; Database=EmpManager; Integrated Security=True; Trusted_Connection=True; TrustServerCertificate=True; MultipleActiveResultSets=true")
                    .Options;

                // Kiểm tra xem có trùng lặp trong cơ sở dữ liệu hay không, loại trừ nhân viên đang cập nhật
                using (var context = new EmpManagerContext(options))
                {
                    return !context.Employees.Any(emp => emp.Phone == phoneNumber && emp.Id != employeeId);
                }
            }

            return false;
        }
        private bool IsEmailValid(string email, string employeeId)
        {
            // Kiểm tra định dạng email
            string emailPattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            Regex regex = new Regex(emailPattern);
            Match match = regex.Match(email);

            // Nếu email đúng định dạng
            if (match.Success)
            {
                var options = new DbContextOptionsBuilder<EmpManagerContext>()
                    .UseSqlServer("Server=DESKTOP-CMSGFMS\\HONGAN; Database=EmpManager; Integrated Security=True; Trusted_Connection=True; TrustServerCertificate=True; MultipleActiveResultSets=true")
                    .Options;

                // Kiểm tra xem có trùng lặp trong cơ sở dữ liệu hay không, loại trừ nhân viên đang cập nhật
                using (var context = new EmpManagerContext(options))
                {
                    return !context.Employees.Any(emp => emp.Email == email && emp.Id != employeeId);
                }
            }

            return false;
        }
        private void DgvEmp_SelectionChanged(object sender, EventArgs e)
        {
            dtpBd.Format = DateTimePickerFormat.Custom;
            dtpBd.CustomFormat = "dd/MM/yyyy";
            if (dgvEmp.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvEmp.SelectedRows[0];

                txtId.Text = selectedRow.Cells["Id"].Value.ToString();
                txtName.Text = selectedRow.Cells["Name_Emp"].Value.ToString();
                cbPosition.Text = selectedRow.Cells["Position"].Value.ToString();
                txtEmail.Text = selectedRow.Cells["Email"].Value.ToString();
                txtPhone.Text = selectedRow.Cells["Phone"].Value.ToString();
                txtAddress.Text = selectedRow.Cells["Address"].Value.ToString();
                dtpBd.Value = (DateTime)selectedRow.Cells["Birthday"].Value;
            }
        }
        private void dgvEmp_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // Lấy số thứ tự của hàng (bắt đầu từ 1)
            int rowIndex = e.RowIndex + 1;

            // Tạo một brush để vẽ số thứ tự
            using (SolidBrush brush = new SolidBrush(dgvEmp.RowHeadersDefaultCellStyle.ForeColor))
            {
                // Xác định vị trí để vẽ số thứ tự trên hàng tiêu đề
                float x = e.RowBounds.Left + 20; 
                float y = e.RowBounds.Top + (e.RowBounds.Height - e.InheritedRowStyle.Font.Height) / 2;

                // Vẽ số thứ tự
                e.Graphics.DrawString(rowIndex.ToString(), e.InheritedRowStyle.Font, brush, x, y);
            }
        }
        private async Task RefreshEmployeeData()
        {
            List<Employee> employees = await SendGetRequest();
            DisplayEmployees(employees);
        }
        private async void btnAddEmp_Click(object sender, EventArgs e)
        {
            string phoneNumber = txtPhone.Text;
            string email = txtEmail.Text;
            string id = txtId.Text;
            DateTime birthday = dtpBd.Value;

            if (!IsPhoneNumberValid(phoneNumber, id))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!", "Error");
                return;
            }

            if (!IsEmailValid(email, id))
            {
                MessageBox.Show("Email không hợp lệ!", "Error");
                return;
            }

            if (birthday.Date >= DateTime.Now.Date)
            {
                MessageBox.Show("Ngày sinh không hợp lệ!", "Error");
                return;
            }

            Employee newEmployee = new Employee
            {
                Id = txtId.Text,
                Name = txtName.Text,
                Position = cbPosition.SelectedItem.ToString(),
                Birthday = dtpBd.Value,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                Address = txtAddress.Text
            };

            RestRequest request = new RestRequest(apiUrl + "/AddEmp", Method.Post);
            request.AddJsonBody(newEmployee);

            RestResponse response = await restClient.ExecuteAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                var responseData = JsonConvert.DeserializeObject<Employee>(response.Content);
                string newEmployeeId = responseData.Id;

                await RefreshEmployeeData();
                MessageBox.Show("Nhân viên có mã " + newEmployeeId + " đã được thêm thành công!", "Success");
            }
            else
            {
                MessageBox.Show("Thêm nhân viên thất bại: " + response.StatusCode, "Error");
            }
        }
        private void btnRefreshEmp_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtName.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            cbPosition.SelectedItem = "Frontend";
            dtpBd.Value = DateTime.Now;
        }
        private async void btnDeleteEmp_Click(object sender, EventArgs e)
        {
            List<string> deletedEmployeeIds = new List<string>();

            // Lặp qua tất cả các hàng đã chọn
            foreach (DataGridViewRow row in dgvEmp.SelectedRows)
            {
                string employeeId = row.Cells["Id"].Value.ToString();

                RestRequest request = new RestRequest(apiUrl + $"/DeleteEmp/{employeeId}", Method.Delete);
                RestResponse response = await restClient.ExecuteAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    deletedEmployeeIds.Add(employeeId);
                }
                else
                {
                    MessageBox.Show("Xóa nhân viên thất bại: " + response.StatusCode, "Error");
                }
            }

            // Cập nhật lại dữ liệu
            await RefreshEmployeeData();

            if (deletedEmployeeIds.Count > 0)
            {
                string deletedEmployeeIdsString = string.Join(", ", deletedEmployeeIds);
                MessageBox.Show("Đã xóa thành công nhân viên có mã: " + deletedEmployeeIdsString, "Thành công");
            }
            else
            {
                MessageBox.Show("Không có nhân viên nào được chọn hoặc xóa không thành công.", "Thông báo");
            }
        }
        private async void btnUpdateEmp_Click(object sender, EventArgs e)
        {
            if (dgvEmp.SelectedRows.Count > 0)
            {
                string employeeId = dgvEmp.SelectedRows[0].Cells["Id"].Value.ToString();

                DateTime birthday = dtpBd.Value;

                if (dgvEmp.Columns.Contains("Phone"))
                {
                    int phoneColumnIndex = dgvEmp.Columns["Phone"].Index;
                    string phoneNumber = dgvEmp.SelectedRows[0].Cells[phoneColumnIndex].Value.ToString();

                    if (!IsPhoneNumberValid(phoneNumber, employeeId))
                    {
                        MessageBox.Show("Số điện thoại không hợp lệ!", "Error");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy cột 'Phone'");
                }

                if (dgvEmp.Columns.Contains("Email"))
                {
                    int emailIndex = dgvEmp.Columns["Email"].Index;
                    string email = dgvEmp.SelectedRows[0].Cells[emailIndex].Value.ToString();

                    if (!IsEmailValid(email, employeeId))
                    {
                        MessageBox.Show("Email không hợp lệ!", "Error");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy cột 'Phone'");
                }

                if (birthday.Date >= DateTime.Now.Date)
                {
                    MessageBox.Show("Ngày sinh không hợp lệ!", "Error");
                    return;
                }

                Employee updatedEmployee = new Employee
                {
                    Id = employeeId,
                    Name = txtName.Text,
                    Position = cbPosition.SelectedItem.ToString(),
                    Birthday = dtpBd.Value,
                    Email = txtEmail.Text,
                    Phone = txtPhone.Text,
                    Address = txtAddress.Text
                };

                RestRequest request = new RestRequest(apiUrl + $"/UpdateEmp/{employeeId}", Method.Put);
                request.AddJsonBody(updatedEmployee);

                RestResponse response = await restClient.ExecuteAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    await RefreshEmployeeData();
                    MessageBox.Show("Nhân viên có mã " + employeeId + " đã được cập nhật thành công!", "Success");
                }
                else
                {
                    MessageBox.Show("Cập nhật nhân viên thất bại: " + response.StatusCode, "Error");
                }
            }
        }
        private bool IsIdValid(string id, string position)
        {
            switch (position)
            {
                case "Backend":
                    return Regex.IsMatch(id, @"^BE\d{4}$");
                case "Frontend":
                    return Regex.IsMatch(id, @"^FE\d{4}$");
                case "Teamlead":
                    return Regex.IsMatch(id, @"^TL\d{4}$");
                default:
                    return false;
            }
        }
        private bool IsIdDuplicate(string id)
        {
            var options = new DbContextOptionsBuilder<EmpManagerContext>()
                .UseSqlServer("Server=DESKTOP-CMSGFMS\\HONGAN; Database=EmpManager; Integrated Security=True; Trusted_Connection=True; TrustServerCertificate=True; MultipleActiveResultSets=true")
                .Options;
            using (var context = new EmpManagerContext(options))
            {
                return context.Employees.Any(emp => emp.Id == id);
            }
        }
        private async void btnImportEmp_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
            openFileDialog.Title = "Select an Excel File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileInfo = new FileInfo(openFileDialog.FileName);

                using (ExcelPackage package = new ExcelPackage(fileInfo))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                    List<Employee> importedEmployees = new List<Employee>();
                    List<string> importedEmployeeIds = new List<string>(); // Danh sách mã nhân viên đã import

                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                    {
                        try
                        {
                            Employee employee = new Employee
                            {
                                Id = worksheet.Cells[row, 1].Value.ToString(),
                                Name = worksheet.Cells[row, 2].Value.ToString(),
                                Position = worksheet.Cells[row, 3].Value.ToString(),
                                Birthday = DateTime.FromOADate(double.Parse(worksheet.Cells[row, 4].Value.ToString())),
                                Email = worksheet.Cells[row, 5].Value.ToString(),
                                Phone = worksheet.Cells[row, 6].Value.ToString(),
                                Address = worksheet.Cells[row, 7].Value.ToString()
                            };

                            if (IsIdValid(employee.Id, employee.Position) && !IsIdDuplicate(employee.Id))
                            {
                                importedEmployees.Add(employee);
                                importedEmployeeIds.Add(employee.Id);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi xảy ra trong quá trình import dòng " + row + ": " + ex.Message);
                        }
                    }

                    foreach (var employee in importedEmployees)
                    {
                        dbContext.Employees.Add(employee);
                    }
                    await dbContext.SaveChangesAsync();

                    await RefreshEmployeeData();

                    if (importedEmployeeIds.Any())
                    {
                        string importedIdsMessage = "Đã import thành công các nhân viên có mã:\n" + string.Join(", ", importedEmployeeIds);
                        MessageBox.Show(importedIdsMessage, "Success");
                    }
                }
            }
        }
        private void btnExportEmp_Click(object sender, EventArgs e)
        {
            dtpBd.Format = DateTimePickerFormat.Custom;
            dtpBd.CustomFormat = "dd/MM/yyyy";

            using (var package = new OfficeOpenXml.ExcelPackage())
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                var worksheet = package.Workbook.Worksheets.Add("Employees");

                // Ghi tiêu đề
                for (int i = 1; i <= dgvEmp.Columns.Count; i++)
                {
                    worksheet.Cells[1, i].Value = dgvEmp.Columns[i - 1].HeaderText;
                }

                // Lấy chỉ số của cột Birthday
                int columnIndex = dgvEmp.Columns["Birthday"].Index;

                // Thiết lập định dạng ngày tháng cho cột Birthday
                worksheet.Column(columnIndex + 1).Style.Numberformat.Format = "dd/MM/yyyy";

                // Ghi dữ liệu
                for (int i = 0; i < dgvEmp.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvEmp.Columns.Count; j++)
                    {
                        if (j == columnIndex) // Kiểm tra xem đang ở cột Birthday
                        {
                            if (dgvEmp.Rows[i].Cells[j].Value != null &&
                                DateTime.TryParse(dgvEmp.Rows[i].Cells[j].Value.ToString(), out DateTime birthday))
                            {
                                worksheet.Cells[i + 2, j + 1].Value = birthday;
                            }
                            else
                            {
                                MessageBox.Show("Không thể chuyển đổi giá trị ngày tháng.");
                            }
                        }
                        else
                        {
                            worksheet.Cells[i + 2, j + 1].Value = dgvEmp.Rows[i].Cells[j].Value;
                        }
                    }
                }

                // Lưu workbook vào một tệp Excel
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Save an Excel File";
                saveFileDialog.FileName = "exportEmp";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var fileInfo = new FileInfo(saveFileDialog.FileName);
                    package.SaveAs(fileInfo);
                    MessageBox.Show("Dữ liệu đã được xuất thành công!", "Success");
                }
            }
        }
    }
}
