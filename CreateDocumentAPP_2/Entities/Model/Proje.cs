namespace CreateDocumentAPP_2.Entities.Model
{

    using CreateDocumentAPP_2.Entities.Enum;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Proje
    {
        public int ProjeID { get; set; }
        public string ProjeAdi { get; set; }
        public string? Aciklama { get; set; }
        public DateTime? BaslangicTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }
        public ProjeDurumu Durum { get; set; }
        public int? KategoriID { get; set; }
        public ProjeKategori? Kategori { get; set; }
        public int? OlusturanID { get; set; }
        public Kullanici? Olusturan { get; set; }
        public int? CompanyID { get; set; }
        public Company? Company { get; set; }

        public virtual ProjeDetay? ProjeDetay { get; set; }
        public virtual ICollection<ProjeTakim> ProjeUyeleri { get; set; } = new List<ProjeTakim>();
        public virtual ICollection<FinansalBilgi> FinansalBilgiler { get; set; } = new List<FinansalBilgi>();
        public virtual ICollection<TeknikGereksinim> TeknikGereksinimler { get; set; } = new List<TeknikGereksinim>();
        public virtual ICollection<FonksiyonelGereksinim> FonksiyonelGereksinimler { get; set; } = new List<FonksiyonelGereksinim>();
        public virtual ICollection<ProjeDiyagram> ProjeDiyagramlari { get; set; } = new List<ProjeDiyagram>();
    }
}