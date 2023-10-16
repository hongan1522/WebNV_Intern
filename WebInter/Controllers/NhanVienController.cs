using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using WebIntern.Models;
using WebIntern.Services;

namespace WebIntern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        public List<NhanVien>? nhanVien;

        public readonly NhanVienService _NhanVienService = new();

        private string GenerateMaNhanVien(List<NhanVien> danhSachNhanVien, string chucVu)
        {
            int maxSoThuTu = 0;

            // Tìm số thứ tự lớn nhất của nhân viên có cùng chức vụ
            foreach (var nhanVien in danhSachNhanVien)
            {
                if (nhanVien.ChucVu == chucVu && int.TryParse(nhanVien.MaNhanVien.Substring(2), out int soThuTu))
                {
                    if (soThuTu > maxSoThuTu)
                    {
                        maxSoThuTu = soThuTu;
                    }
                }
            }

            // Sinh mã nhân viên mới
            string chucVuDangSau = string.Empty;
            switch (chucVu)
            {
                case "Backend":
                    chucVuDangSau = "BE";
                    break;
                case "Frontend":
                    chucVuDangSau = "FE";
                    break;
                case "Teamlead":
                    chucVuDangSau = "TL";
                    break;
            }

            string newMaNhanVien = chucVuDangSau + (maxSoThuTu + 1).ToString("D5");

            return newMaNhanVien;
        }
        private List<string> GetInvalidFields(NhanVien nhanVien, List<NhanVien> danhSachNhanVien)
        {
            List<string> invalidFields = new List<string>();

            // Kiểm tra SDT phải là số, bắt đầu từ 0, và có 10 chữ số
            Regex sdtRegex = new Regex("^0[0-9]{9}$");
            if (!sdtRegex.IsMatch(nhanVien.SDT))
            {
                invalidFields.Add("SĐT bắt đầu từ 0 có có 10 chữ số");
            }

            // Kiểm tra Email đúng định dạng
            Regex emailRegex = new Regex(@"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$");
            if (!emailRegex.IsMatch(nhanVien.Email))
            {
                invalidFields.Add("Email đúng định dạng example@gmail.com");
            }

            // Kiểm tra số điện thoại không trùng
            if (danhSachNhanVien.Any(nv => nv.SDT == nhanVien.SDT))
            {
                invalidFields.Add("SĐT đã tồn tại");
            }

            // Kiểm tra email không trùng
            if (danhSachNhanVien.Any(nv => nv.Email == nhanVien.Email))
            {
                invalidFields.Add("Email đã tồn tại");
            }

            // Kiểm tra NgaySinh không thể là ngày hiện tại
            if (nhanVien.NgaySinh >= DateTime.Now.Date)
            {
                invalidFields.Add("Ngày sinh không thể là ngày hiện tại");
            }

            // Kiểm tra các trường không để rỗng
            if (string.IsNullOrWhiteSpace(nhanVien.SDT))
            {
                invalidFields.Add("SĐT không được rỗng");
            }
            if (string.IsNullOrWhiteSpace(nhanVien.Email))
            {
                invalidFields.Add("Email không được rỗng");
            }
            if (string.IsNullOrWhiteSpace(nhanVien.TenNhanVien))
            {
                invalidFields.Add("Tên nhân viên không được rỗng");
            }

            return invalidFields;
        }

        [HttpGet]
        public ActionResult<List<NhanVien>> Get()
        {
            List<NhanVien> danhSachNhanVien = _NhanVienService.GetNhanVien();

            // Phân loại theo chức vụ và sắp xếp mã tăng dần
            danhSachNhanVien = danhSachNhanVien
                .OrderBy(nv => {
                    switch (nv.ChucVu)
                    {
                        case "Teamlead":
                            return 1;
                        case "Backend":
                            return 2;
                        case "Frontend":
                            return 3;
                        default:
                            return 0;
                    }
                })
                .ThenBy(nv => int.Parse(nv.MaNhanVien.Substring(2))).ToList();

            return danhSachNhanVien;
        }

        [HttpPost("{MaNhanVien?}")]
        public ActionResult<NhanVien> UpsertNhanVien(string MaNhanVien, NhanVien NhanVien)
        {
            List<NhanVien> danhSachNhanVien = _NhanVienService.GetNhanVien();
            List<string> invalidFields = GetInvalidFields(NhanVien, danhSachNhanVien);

            var existingNhanVien = danhSachNhanVien.FirstOrDefault(e => e.MaNhanVien == MaNhanVien);

            if (existingNhanVien == null)
            {
                NhanVien.MaNhanVien = GenerateMaNhanVien(danhSachNhanVien, NhanVien.ChucVu);
                danhSachNhanVien.Add(NhanVien);
            }
            else
            {
                // Kiểm tra tính hợp lệ và lưu danh sách
                if (invalidFields.Count > 0)
                {
                    string errorMessage = "Lỗi: " + string.Join(", ", invalidFields);
                    return BadRequest(errorMessage);
                }

                // Lưu lại mã chức vụ cũ
                string oldChucVu = existingNhanVien.ChucVu;

                // Cập nhật thông tin nhân viên
                existingNhanVien.SDT = NhanVien.SDT;
                existingNhanVien.TenNhanVien = NhanVien.TenNhanVien;
                existingNhanVien.NgaySinh = NhanVien.NgaySinh;
                existingNhanVien.DiaChi = NhanVien.DiaChi;
                existingNhanVien.Email = NhanVien.Email;

                // Nếu chức vụ đã bị thay đổi, cập nhật lại mã nhân viên
                if (oldChucVu != NhanVien.ChucVu)
                {
                    danhSachNhanVien.RemoveAll(e => e.MaNhanVien == MaNhanVien);
                    NhanVien.MaNhanVien = GenerateMaNhanVien(danhSachNhanVien, NhanVien.ChucVu);
                    danhSachNhanVien.Add(NhanVien);
                }
            }

            // Kiểm tra tính hợp lệ và lưu danh sách
            if (invalidFields.Count > 0)
            {
                string errorMessage = "Lỗi: " + string.Join(", ", invalidFields);
                return BadRequest(errorMessage);
            }

            _NhanVienService.SaveNhanVien(danhSachNhanVien);

            return NhanVien;
        }

        [HttpDelete("{MaNhanVien}")]
        public IActionResult Delete(string MaNhanVien)
        {
            List<NhanVien> nhanVien = _NhanVienService.GetNhanVien();
            var existingNhanVien = nhanVien.FirstOrDefault(e => e.MaNhanVien == MaNhanVien);

            if (existingNhanVien == null)
            {
                return NotFound();
            }

            string deletedMaNhanVien = existingNhanVien.MaNhanVien;
            string chucVu = deletedMaNhanVien.Substring(0, 2);

            nhanVien.Remove(existingNhanVien);

            // Lọc danh sách nhân viên theo chức vụ của nhân viên bị xóa
            var filteredList = nhanVien.Where(nv => nv.MaNhanVien.StartsWith(chucVu)).ToList();

            // Sắp xếp lại danh sách theo mã nhân viên
            filteredList = filteredList.OrderBy(nv => int.Parse(nv.MaNhanVien.Substring(2))).ToList();

            // Cập nhật lại mã nhân viên
            for (int i = 0; i < filteredList.Count; i++)
            {
                filteredList[i].MaNhanVien = chucVu + (i + 1).ToString("D5");
            }

            // Cập nhật lại danh sách gốc
            foreach (var nv in nhanVien)
            {
                var index = filteredList.FindIndex(n => n.MaNhanVien == nv.MaNhanVien);
                if (index >= 0)
                {
                    nv.MaNhanVien = filteredList[index].MaNhanVien;
                }
            }

            _NhanVienService.SaveNhanVien(nhanVien);
            return Ok("Đã xóa nhân viên " + deletedMaNhanVien + " và cập nhật lại mã.");
        }

    }
}
