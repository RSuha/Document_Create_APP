using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreateDocumentAPP_2.Entities.Model
{
    public class DiyagramKategori
    {
        [Key]
        public int KategoriID { get; set; }

        [Required]
        [MaxLength(100)]
        public string KategoriAdi { get; set; } = string.Empty;

        // İlişki: Bir kategori birden fazla diyagramda kullanılabilir
        public ICollection<ProjeDiyagram> ProjeDiyagramlari { get; set; } = new List<ProjeDiyagram>();
    }
}
