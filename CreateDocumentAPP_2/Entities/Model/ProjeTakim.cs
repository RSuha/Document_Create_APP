namespace CreateDocumentAPP_2.Entities.Model
{

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ProjeTakim
    {
        public int Id { get; set; }
        public int ProjeID { get; set; }
        public int UserID { get; set; }
        public DateTime AtanmaTarihi { get; set; }

        public Proje? Proje { get; set; }
        public Kullanici? Kullanici { get; set; }
    }

}