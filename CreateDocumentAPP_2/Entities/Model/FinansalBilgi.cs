namespace CreateDocumentAPP_2.Entities.Model
{
    public class FinansalBilgi
    {
        public int Id { get; set; }
        public int ProjeID { get; set; }
        public string? AyrilanButce { get; set; }
        public string? IlgiliIs { get; set; }
        public virtual Proje? Proje { get; set; }
    }
}
