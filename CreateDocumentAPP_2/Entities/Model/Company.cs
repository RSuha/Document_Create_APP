namespace CreateDocumentAPP_2.Entities.Model
{
    using System.ComponentModel.DataAnnotations;

    public class Company
    {
        [Key]
        public int CompanyID { get; set; }
        public string Ad { get; set; } = string.Empty;
        public DateTime KurulusTarihi { get; set; }

        public virtual ICollection<Kullanici> Kullanicilar { get; set; } = new List<Kullanici>();
        public virtual ICollection<Departman> Departmanlar { get; set; } = new List<Departman>();
    }

}