namespace CreateDocumentAPP_2.Entities.Model
{
    public class FonksiyonelGereksinim
    {
        public int Id { get; set; }
        public int ProjeID { get; set; }
        public string? Gereklilik { get; set; }
        public string? Aciklama { get; set; }
        public string? Onem { get; set; }

        public virtual ICollection<GereksinimNotu> Notlar { get; set; } = new List<GereksinimNotu>();
        public virtual Proje? Proje { get; set; }
    }
}
