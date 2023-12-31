using KareAjansi.Common;
using KareAjansi.DAL.Models.Base;
using KareAjansi.DAL.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KareAjansi.DAL.Models.Context
{
    public class KareAjansiContext:DbContext
    {
        public KareAjansiContext(DbContextOptions<KareAjansiContext> options) : base(options)
        {

        }

        //Dbset
        public DbSet<Manken> Mankenler { get; set; }
        public DbSet<Resim> Resimler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Organizasyon> Organizasyonlar { get; set; }
        public DbSet<OrganizasyonManken> OrganizasyonMankenler { get; set; }
        public DbSet<Odeme> Odemeler { get; set; }
        public DbSet<Yorum> Yorumlar { get; set; }

        //veritabanı tanımlama metodu
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-R1GI7QV\\SQLEXPRESS;Database=KareAjansiDb;Trusted_Connection=True;TrustServerCertificate=True");
            }
            base.OnConfiguring(optionsBuilder);
        }

        //Custom validation (veritabanı oluşturulurken)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Mapping
            //Manken - Kategori ilişkisi
            modelBuilder.Entity<Manken>()
                .HasOne(m => m.Kategori)
                .WithMany(k => k.Mankenler)
                .HasForeignKey(m => m.KategoriId);

            //Kategori - Manken ilişkisi
            modelBuilder.Entity<Kategori>()
                .HasMany(k => k.Mankenler)
                .WithOne(m => m.Kategori)
                .HasForeignKey(m => m.KategoriId);

            //Resim - Manken ilişkisi
            modelBuilder.Entity<Resim>()
                .HasOne(r => r.Manken)
                .WithMany(m => m.Resimler)
                .HasForeignKey(r => r.MankenId);
         
            //Yorum - Manken ilişkisi
            modelBuilder.Entity<Yorum>()
                .HasOne(y => y.Manken)
                .WithMany(m => m.yorumlar)
                .HasForeignKey(y => y.MankenId);

            // OrganizasyonManken anahtar ilişkisi
            modelBuilder.Entity<OrganizasyonManken>()
                .HasKey(om => new { om.OrganizasyonId, om.MankenId }); //İki anahtar OrganizasyonId ve MankenId

            modelBuilder.Entity<OrganizasyonManken>()
                .HasOne(om => om.Organizasyon)
                .WithMany(o => o.OrganizasyonMankenler)
                .HasForeignKey(om => om.OrganizasyonId);

            // OrganizasyonManken - Manken ilişkisi
            modelBuilder.Entity<OrganizasyonManken>()
                .HasOne(om => om.Manken)
                .WithMany(m => m.OrganizasyonMankenler)
                .HasForeignKey(om => om.MankenId);

            // Odeme - Manken ilişkisi
            modelBuilder.Entity<Odeme>()
                .HasOne(o => o.Manken)
                .WithMany(m => m.Odemeler)
                .HasForeignKey(o => o.MankenId);

            // Odeme - Organizasyon ilişkisi
            modelBuilder.Entity<Odeme>()
                .HasOne(o => o.Organizasyon)
                .WithMany(o => o.Odemeler)
                .HasForeignKey(o => o.OrganizasyonId);

            //Seeding
            //Kategoriler
            List<Kategori> kategoriler = new List<Kategori>()
            {
                new Kategori
                {
                    Id = 1,
                    Ad = "Kategori1",
                    Fiyat = Enum.Fiyat.Kategori1
                },
                new Kategori
                {
                    Id= 2,
                    Ad = "Kategori2",
                    Fiyat = Enum.Fiyat.Kategori2
                }
            };
            modelBuilder.Entity<Kategori>().HasData(kategoriler);

            //Mankenler
            List<Manken> mankenler = new List<Manken>()
            {
                new Manken
                {
                    Id = 1,
                    Ad = "Emre",
                    Soyad = "Bilge",
                    Adres = "Ornek Adres",
                    Tel1  = "555-555-5555",
                    Tel2  = "555-555-5556",
                    AyakkabiNo = "42",
                    Beden = "Medium",
                    Kilo = "65",
                    SacRengi = "Siyah",
                    GozRengi = "Kahverengi",
                    SehirDisiCalisabilmeDurumu = true,
                    Ehliyet = true,
                    YabanciDil = "İngilizce",
                    Ozellik = "Ornek Ozellik",
                    Cinsiyet = "Bay",
                    KategoriId = 1
                }
            };
            modelBuilder.Entity<Manken>().HasData(mankenler);

            List<Organizasyon> organizasyonlar = new List<Organizasyon>()
            {
               new Organizasyon
               {
                   Id = 1,
                   Ad = "Ornek Organizasyon",
                   BaslangicTarihi = new DateTime(2023, 1, 1),
                   BitisTarihi = new DateTime(2023, 1, 7),
                   Sehir = "İstanbul",
                   Firma = "Ornek Firma",
                   GunSayisi = 7
               }
            };
            modelBuilder.Entity<Organizasyon>().HasData(organizasyonlar);

            List<OrganizasyonManken> organizasyonMankenler = new List<OrganizasyonManken>
            {
                new OrganizasyonManken
                {
                  Id = 1,
                  MankenId = 1,
                  OrganizasyonId = 1,
                  KatilmaTarihi = new DateTime(2023, 1, 1)
                }
            };
            modelBuilder.Entity<OrganizasyonManken>().HasData(organizasyonMankenler);

            List<Yorum> yorum = new List<Yorum>()
            {
                new Yorum
                {
                    Id=1,
                    Yazari = "Emre",
                    Yorumu = "Böyle devam et",
                    MankenId=1,
                }
            };
            modelBuilder.Entity<Yorum>().HasData(yorum);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var modifierEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified || x.State == EntityState.Added);
            try
            {
                foreach (var item in modifierEntries)
                {
                    var entityRepostiory = item.Entity as BaseClass;
                    if (item.State == EntityState.Added)
                    {
                        //veri yeni eklenirken
                        entityRepostiory.CreateDate = DateTime.Now;
                        entityRepostiory.CreatedIpAddress = "222222";
                        entityRepostiory.CreatedComputerName = Environment.MachineName;
                        entityRepostiory.CreatedIpAddress = IpAddressFinder.GetIpAddress();
                    }
                    else if (item.State == EntityState.Modified)
                    {
                        //veri güncellenirken 
                        entityRepostiory.UpdateDate = DateTime.Now;
                        entityRepostiory.UpdatedIpAddress = "111111";
                        entityRepostiory.UpdatedComputerName = Environment.MachineName;
                        entityRepostiory.UpdatedIpAddress = IpAddressFinder.GetIpAddress();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return base.SaveChanges();
        }
    }
}