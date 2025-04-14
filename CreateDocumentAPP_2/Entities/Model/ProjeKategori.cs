namespace CreateDocumentAPP_2.Entities.Model
{

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ProjeKategori
    {
        [Key]
        public int KategoriID { get; set; }
        public string Ad { get; set; }

        public virtual ICollection<Proje> Projeler { get; set; } = new List<Proje>();
    }
}