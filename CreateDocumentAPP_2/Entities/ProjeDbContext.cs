using CreateDocumentAPP_2.Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace CreateDocumentAPP_2.Entities
{
    public class ProjeDbContext : DbContext
    {
        public ProjeDbContext(DbContextOptions<ProjeDbContext> options) : base(options) { }

        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Proje> Projeler { get; set; }
        public DbSet<ProjeTakim> ProjeTakimlari { get; set; }
        public DbSet<Company> Sirketler { get; set; }
        public DbSet<Departman> Departmanlar { get; set; }
        public DbSet<ProjeKategori> ProjeKategorileri { get; set; }
        public DbSet<ProjeDetay> ProjeDetaylari { get; set; }

        // ✅ Yeni tablolar
        public DbSet<FinansalBilgi> FinansalBilgiler { get; set; }
        public DbSet<TeknikGereksinim> TeknikGereksinimler { get; set; }
        public DbSet<FonksiyonelGereksinim> FonksiyonelGereksinimler { get; set; }
        public DbSet<ProjeDiyagram> ProjeDiyagramlari { get; set; }
        public DbSet<GereksinimNotu> GereksinimNotlari { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Kullanıcı-Şirket
            modelBuilder.Entity<Kullanici>()
                .HasOne(k => k.Company)
                .WithMany(c => c.Kullanicilar)
                .HasForeignKey(k => k.CompanyID)
                .OnDelete(DeleteBehavior.NoAction);

            // Kullanıcı-Departman
            modelBuilder.Entity<Kullanici>()
                .HasOne(k => k.Departman)
                .WithMany(d => d.Kullanicilar)
                .HasForeignKey(k => k.DepartmanID)
                .OnDelete(DeleteBehavior.NoAction);

            // Departman-Şirket
            modelBuilder.Entity<Departman>()
                .HasOne(d => d.Company)
                .WithMany(c => c.Departmanlar)
                .HasForeignKey(d => d.CompanyID)
                .OnDelete(DeleteBehavior.Cascade);

            // Proje-Kategori
            modelBuilder.Entity<Proje>()
                .HasOne(p => p.Kategori)
                .WithMany(k => k.Projeler)
                .HasForeignKey(p => p.KategoriID)
                .OnDelete(DeleteBehavior.Restrict);

            // Proje-Şirket
            modelBuilder.Entity<Proje>()
                .HasOne(p => p.Company)
                .WithMany()
                .HasForeignKey(p => p.CompanyID)
                .OnDelete(DeleteBehavior.SetNull);

            // ProjeDetay - Proje (1:1)
            modelBuilder.Entity<ProjeDetay>()
                .HasOne(pd => pd.Proje)
                .WithOne(p => p.ProjeDetay)
                .HasForeignKey<ProjeDetay>(pd => pd.ProjeID)
                .OnDelete(DeleteBehavior.Cascade);

            // ProjeTakim - Proje & Kullanici
            modelBuilder.Entity<ProjeTakim>()
                .HasOne(pt => pt.Proje)
                .WithMany(p => p.ProjeUyeleri)
                .HasForeignKey(pt => pt.ProjeID);

            modelBuilder.Entity<ProjeTakim>()
                .HasOne(pt => pt.Kullanici)
                .WithMany()
                .HasForeignKey(pt => pt.UserID);

            // GereksinimNotu - TeknikGereksinim ilişkisi
            modelBuilder.Entity<GereksinimNotu>()
                .HasOne(n => n.TeknikGereksinim)
                .WithMany(t => t.Notlar)
                .HasForeignKey(n => n.TeknikGereksinimID)
                .OnDelete(DeleteBehavior.Restrict);

            // GereksinimNotu - FonksiyonelGereksinim ilişkisi
            modelBuilder.Entity<GereksinimNotu>()
                .HasOne(n => n.FonksiyonelGereksinim)
                .WithMany(f => f.Notlar)
                .HasForeignKey(n => n.FonksiyonelGereksinimID)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}

