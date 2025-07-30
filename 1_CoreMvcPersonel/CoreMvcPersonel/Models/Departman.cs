using System.ComponentModel.DataAnnotations;

namespace CoreMvcDepartman.Models
{
    public class Departman
    {
        [Key]
        public int DepartmanId { get; set; }
        public string DepartmanAd { get; set; }
        public IList<Personel> Personeller { get; set; }
    }
}
