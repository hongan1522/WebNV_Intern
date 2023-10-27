using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RestSharp;
using Newtonsoft.Json;
using WebIntern.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using OfficeOpenXml;

namespace FormIntern
{
    public partial class UC_Employees : UserControl
    {
        private string apiUrl = "https://localhost:44353/api/Employees";
        private RestClient restClient = new RestClient();

        public UC_Employees()
        {
            InitializeComponent();
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
        private async Task RefreshEmployeeData()
        {
            List<Employee> employees = await SendGetRequest();
            DisplayEmployees(employees);
        }
        private async void btnAddEmp_Click(object sender, EventArgs e)
        {
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
            if (dgvEmp.SelectedRows.Count > 0)
            {
                // Lấy ID của nhân viên được chọn
                string employeeId = dgvEmp.SelectedRows[0].Cells["Id"].Value.ToString();

                RestRequest request = new RestRequest(apiUrl + $"/DeleteEmp/{employeeId}", Method.Delete);

                // Gửi request và nhận response
                RestResponse response = await restClient.ExecuteAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    await RefreshEmployeeData();
                    MessageBox.Show("Nhân viên có ID là" + employeeId + " đã được xóa thành công!", "Success");
                }
                else
                {
                    MessageBox.Show("Xóa nhân viên thất bại: " + response.StatusCode, "Error");
                }
            }
        }
        private async void btnUpdateEmp_Click(object sender, EventArgs e)
        {
            if (dgvEmp.SelectedRows.Count > 0)
            {
                string employeeId = dgvEmp.SelectedRows[0].Cells["Id"].Value.ToString();

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
        private void btnImportEmp_Click(object sender, EventArgs e)
        {

        }
        private void btnExportEmp_Click(object sender, EventArgs e)
        {
            dtpBd.Format = DateTimePickerFormat.Custom;
            dtpBd.CustomFormat = "dd/MM/yyyy";
            int columnIndex = dgvEmp.Columns["Birthday"].Index; // Get the index of the "Birthday" column

            using (var package = new OfficeOpenXml.ExcelPackage())
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                var worksheet = package.Workbook.Worksheets.Add("Employees");

                // ...

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



                // Thiết lập định dạng ngày tháng cho cột Birthday
                //worksheet.Column(4).Style.Numberformat.Format = "dd/MM/yyyy";


                //// Ghi dữ liệu
                //for (int i = 0; i < dgvEmp.Rows.Count; i++)
                //{
                //    for (int j = 0; j < dgvEmp.Columns.Count; j++)
                //    {
                //        // Nếu đang ghi cột Birthday
                //        if (j == 4)
                //        {
                //            // Ép kiểu dữ liệu và ghi giá trị với định dạng ngày tháng
                //            DateTime birthday = (DateTime)dgvEmp.Rows[i].Cells[j].Value;
                //            worksheet.Cells[i + 2, j + 1].Value = birthday;
                //            //if (dgvEmp.Rows[i].Cells[j].Value != null &&
                //            //    dgvEmp.Rows[i].Cells[j].Value is string stringValue &&
                //            //    DateTime.TryParse(stringValue, out DateTime birthday))
                //            //{
                //            //    worksheet.Cells[i + 2, j + 1].Value = birthday;
                //            //}
                //            //else
                //            //{
                //            //    MessageBox.Show("Ko convert datetime đc");
                //            //}

                //        }
                //        else
                //        {
                //            worksheet.Cells[i + 2, j + 1].Value = dgvEmp.Rows[i].Cells[j].Value;
                //        }
                //    }
                //}


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
