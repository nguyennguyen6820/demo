namespace StudentMVC.Models
{
    public class SinhVien
    {
        public int MaSV { get; set; }
        public string TenSV { get; set; }
        public bool GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public int MaLop { get; set; }
        public Lop Lop { get; set; }
    }
}
