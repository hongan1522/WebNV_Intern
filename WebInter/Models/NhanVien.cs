namespace WebIntern.Models
{
    public class NhanVien
    {
        public string? MaNhanVien { get; set; }
        public string? TenNhanVien { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? Email { get; set; }
        public string? SDT { get; set; }
        public string? DiaChi { get; set; }
        private string? _chucVu;
        public string ChucVu
        {
            get => _chucVu;
            set
            {
                if (value == "Backend" || value == "Frontend" || value == "Teamlead")
                    _chucVu = value;
                else
                    throw new ArgumentException("Chức vụ phải là 'Backend', 'Frontend', hoặc 'Teamlead'.");
            }
        }
    }
}
