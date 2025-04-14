namespace CreateDocumentAPP_2.Entities.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ProjeDetay
    {
        public int Id { get; set; }
        public int ProjeID { get; set; }
        public string? TeknikGereksinimler { get; set; }
        public string? FinansalBilgiler { get; set; }
        public string? StratejikHedefler { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime SonGuncelleme { get; set; }

        public Proje? Proje { get; set; }
    }

}