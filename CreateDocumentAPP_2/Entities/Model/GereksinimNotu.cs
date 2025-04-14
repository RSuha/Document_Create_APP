namespace CreateDocumentAPP_2.Entities.Model
{
    public class GereksinimNotu
    {
        public int Id { get; set; }

        public int? TeknikGereksinimID { get; set; }
        public TeknikGereksinim? TeknikGereksinim { get; set; }

        public int? FonksiyonelGereksinimID { get; set; }
        public FonksiyonelGereksinim? FonksiyonelGereksinim { get; set; }

        public string Icerik { get; set; } = string.Empty;

        public string? IlgiliGorselUrl { get; set; }

        public DateTime EklenmeTarihi { get; set; } = DateTime.UtcNow;


    }
}
