namespace CreateDocumentAPP_2.Entities.Model
{
        public class TeknikGereksinim
        {
            public int Id { get; set; }
            public int ProjeID { get; set; }
            public string? Gereksinim { get; set; }

            public virtual ICollection<GereksinimNotu> Notlar { get; set; } = new List<GereksinimNotu>();
            public virtual Proje? Proje { get; set; }
        }
}
