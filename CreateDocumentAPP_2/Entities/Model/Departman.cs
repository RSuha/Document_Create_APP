namespace CreateDocumentAPP_2.Entities.Model
{

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Departman
    {
        [Key]
        public int DepartmanID { get; set; }

        [Required, MaxLength(255)]
        public string Ad { get; set; } = string.Empty;

        [Required]
        public int CompanyID { get; set; }

        [ForeignKey("CompanyID")]
        public virtual Company? Company { get; set; }

        public virtual ICollection<Kullanici> Kullanicilar { get; set; } = new List<Kullanici>();
    }

}