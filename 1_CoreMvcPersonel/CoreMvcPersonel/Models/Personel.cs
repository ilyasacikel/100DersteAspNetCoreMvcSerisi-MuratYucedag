using System.ComponentModel.DataAnnotations;

namespace CoreMvcDepartman.Models
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Sehir { get; set; }
        public int DepartmanId { get; set; }
        public Departman Departman { get; set; }
    }
}
