﻿namespace CreateDocumentAPP_2.Entities.Model
{
    public class ProjeDiyagram
    {
        public int Id { get; set; }
        public int ProjeID { get; set; }
        public string? DiyagramAdi { get; set; }
        public string? DiyagramUrl { get; set; }
        public virtual Proje? Proje { get; set; }
    }
}
