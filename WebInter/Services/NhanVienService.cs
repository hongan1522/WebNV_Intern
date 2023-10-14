using Newtonsoft.Json;
using System.Globalization;
using WebIntern.Models;

namespace WebIntern.Services
{
    public class NhanVienService
    {
        private const string FilePath = "Models/NhanVien.json";



        public List<NhanVien> GetNhanVien()
        {
            List<NhanVien> nv;

            using (StreamReader reader = new StreamReader(FilePath))
            {
                string jsonContent = reader.ReadToEnd();
                nv = JsonConvert.DeserializeObject<List<NhanVien>>(jsonContent);
            }

            return nv;
        }

        public void SaveNhanVien(List<NhanVien> nv)
        {
            string jsonContent = JsonConvert.SerializeObject(nv);

            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                writer.Write(jsonContent);
            }
        }
    }
}
