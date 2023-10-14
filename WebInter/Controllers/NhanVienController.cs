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
        public List<NhanVien> nhanVien;

        public readonly NhanVienService _NhanVienService = new();

        private bool IsValidMaNhanVien(string maNhanVien)
        {
            // Sử dụng biểu thức chính quy để kiểm tra định dạng
            Regex regex = new Regex("^NV\\d+$"); 

            return regex.IsMatch(maNhanVien);
        }
        private string GenerateNewMaNhanVien(List<NhanVien> danhSachNhanVien)
        {
            int maxMaNhanVien = 0;

            // Tìm mã nhân viên lớn nhất
            foreach (var nhanVien in danhSachNhanVien)
            {
                if (int.TryParse(nhanVien.MaNhanVien.Substring(2), out int ma))
                {
                    if (ma > maxMaNhanVien)
                    {
                        maxMaNhanVien = ma;
                    }
                }
            }

            string newMaNhanVien = "NV" + (maxMaNhanVien + 1).ToString();

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
                invalidFields.Add("Email đúng định dạng unknow@example.com");
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

            // Sắp xếp lại danh sách theo mã nhân viên
            danhSachNhanVien = danhSachNhanVien.OrderBy(nv => int.Parse(nv.MaNhanVien.Substring(2))).ToList();

            return danhSachNhanVien;
        }

        [HttpPost("{MaNhanVien?}")]
        public ActionResult<NhanVien> UpsertNhanVien(string MaNhanVien, NhanVien NhanVien)
        {
            List<NhanVien> danhSachNhanVien = _NhanVienService.GetNhanVien();
            List<string> invalidFields = GetInvalidFields(NhanVien, danhSachNhanVien);

            // Kiểm tra xem có tồn tại Nhân viên có mã MaNhanVien hay không
            var existingNhanVien = danhSachNhanVien.FirstOrDefault(e => e.MaNhanVien == MaNhanVien);

            if (existingNhanVien == null)
            {
                // Nếu không tồn tại, thực hiện tạo mới (POST)
                if (!IsValidMaNhanVien(NhanVien.MaNhanVien))
                {
                    NhanVien.MaNhanVien = GenerateNewMaNhanVien(danhSachNhanVien);
                }
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

                // Nếu tồn tại, thực hiện cập nhật (PUT)
                existingNhanVien.SDT = NhanVien.SDT;
                existingNhanVien.TenNhanVien = NhanVien.TenNhanVien;
                existingNhanVien.NgaySinh = NhanVien.NgaySinh;
                existingNhanVien.DiaChi = NhanVien.DiaChi;
                existingNhanVien.Email = NhanVien.Email;
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

            nhanVien.Remove(existingNhanVien);
            _NhanVienService.SaveNhanVien(nhanVien);
            return NoContent();
        }
    }
}
