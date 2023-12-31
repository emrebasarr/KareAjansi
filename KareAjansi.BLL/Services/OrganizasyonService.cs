using KareAjansi.BLL.DTOs;
using KareAjansi.BLL.Repositories;
using KareAjansi.DAL.Models.Context;
using KareAjansi.DAL.Models.Entity;
using KareAjansi.DAL.Models.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjansi.BLL.Services
{
    public class OrganizasyonService : IOrganizasyonRepository
    {
        private readonly KareAjansiContext _kareAjansiContext;

        public OrganizasyonService(KareAjansiContext kareAjansiContext)
        {
            _kareAjansiContext = kareAjansiContext;
        }
        public void AddOrganizasyon(OrganizasyonDTO organizasyon)
        {
            var addOrganizasyon = new Organizasyon
            {
                Ad = organizasyon.Ad,
                BaslangicTarihi = organizasyon.BaslangicTarihi,
                BitisTarihi = organizasyon.BitisTarihi,
                Sehir = organizasyon.Sehir,
                Firma = organizasyon.Firma,
                GunSayisi = organizasyon.GunSayisi,
                Status = Status.Active
            };
            _kareAjansiContext.Organizasyonlar.Add(addOrganizasyon);
            _kareAjansiContext.SaveChanges();
        }
        public string DeleteOrganizasyon(int id)
        {
            var organizasyon = _kareAjansiContext.Organizasyonlar.Where(x => x.Id == id).FirstOrDefault();
            if (organizasyon == null)
            {
                return "Organizasyon bulunamadı";
            }
            else
            {
                // Güncelleme 
                organizasyon.Status = Status.Deleted;
                _kareAjansiContext.SaveChanges();
                return organizasyon.Ad + " silindi";
            }
        }
        public List<OrganizasyonDTO> GetAllOrganizasyonlar()
        {
                var organizasyonlar = _kareAjansiContext.Organizasyonlar
                                       .Where(o => o.Status == Status.Active || o.Status == Status.Updated)
                                       .Select(o => new OrganizasyonDTO
                                       {
                                           Id = o.Id,
                                           Ad = o.Ad,
                                           BaslangicTarihi = o.BaslangicTarihi,
                                           BitisTarihi = o.BitisTarihi,
                                           Sehir = o.Sehir,
                                           Firma = o.Firma,
                                           GunSayisi = o.GunSayisi
                                       })
                                       .ToList();
                return organizasyonlar;
        }
        public OrganizasyonDTO GetOrganizasyonById(int id)
        {
            var organizasyon = _kareAjansiContext.Organizasyonlar.Where(o => o.Id == id).Select(o => new OrganizasyonDTO
            {
                Id = o.Id,
                Ad = o.Ad,
                BaslangicTarihi = o.BaslangicTarihi,
                BitisTarihi = o.BitisTarihi,
                Sehir = o.Sehir,
                Firma = o.Firma,
                GunSayisi = o.GunSayisi
            }).FirstOrDefault();
            return organizasyon;
        }

        public List<OrganizasyonDTO> SearchOrganizasyon(string value)
        {
            var searchOrganizasyon = _kareAjansiContext.Organizasyonlar.Where(o => o.Ad.Contains(value)).Select(o => new OrganizasyonDTO
            {
                Id = o.Id,
                Ad = o.Ad,
                BaslangicTarihi = o.BaslangicTarihi,
                BitisTarihi = o.BitisTarihi,
                Sehir = o.Sehir,
                Firma = o.Firma,
                GunSayisi = o.GunSayisi
            }).ToList();
            return searchOrganizasyon;
        }

        public OrganizasyonDTO UpdateOrganizasyon(OrganizasyonDTO organizasyon)
        {
            var updateOrganizasyon = _kareAjansiContext.Organizasyonlar.Find(organizasyon.Id);
            if (updateOrganizasyon != null)
            {
                updateOrganizasyon.Ad = organizasyon.Ad;
                updateOrganizasyon.BaslangicTarihi = organizasyon.BaslangicTarihi;
                updateOrganizasyon.BitisTarihi = organizasyon.BitisTarihi;
                updateOrganizasyon.Sehir = organizasyon.Sehir;
                updateOrganizasyon.Firma = organizasyon.Firma;
                updateOrganizasyon.GunSayisi = organizasyon.GunSayisi;
                // Güncelleme
                updateOrganizasyon.Status = Status.Updated;
                _kareAjansiContext.SaveChanges();
            }
            return organizasyon;
        }
    }
}