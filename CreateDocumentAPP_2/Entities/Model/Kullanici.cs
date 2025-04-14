namespace CreateDocumentAPP_2.Entities.Model
{

    using CreateDocumentAPP_2.Entities.Enum;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.EntityFrameworkCore;

    [Index(nameof(Email), IsUnique = true)]
    public class Kullanici
    {
        [Key]
        public int UserID { get; set; }

        [Required, MaxLength(100)]
        public string Ad { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Soyad { get; set; } = string.Empty;

        [Required, MaxLength(255), EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string SifreHash { get; set; } = string.Empty;

        [Required]
        public KullaniciRol Rol { get; set; } = KullaniciRol.TakimUyesi;

        [Required]
        public UserTitle Title { get; set; } = UserTitle.Belirtilmemis;

        public DateTime OlusturmaTarihi { get; set; } = DateTime.UtcNow;
        public DateTime? SonGiris { get; set; }

        public int? CompanyID { get; set; }
        [ForeignKey("CompanyID")]
        public virtual Company? Company { get; set; }

        public int? DepartmanID { get; set; }
        [ForeignKey("DepartmanID")]
        public virtual Departman? Departman { get; set; }

        public virtual ICollection<ProjeTakim> ProjeUyelikleri { get; set; } = new List<ProjeTakim>();
    }

}