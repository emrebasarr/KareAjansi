using KareAjansi.BLL.DTOs;
using KareAjansi.BLL.Repositories;
using KareAjansi.DAL.Models.Context;
using KareAjansi.DAL.Models.Entity;
using KareAjansi.DAL.Models.Enum;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjansi.BLL.Services
{
    public class MankenService : IMankenRepository
    {
        private readonly KareAjansiContext _kareAjansiContext;

        public MankenService(KareAjansiContext kareAjansiContext) 
        {
            _kareAjansiContext = kareAjansiContext;
        }
        public void AddManken(MankenDTO manken)
        {
            var addManken = new Manken
            {
                Ad = manken.Ad,
                Soyad = manken.Soyad,
                Adres = manken.Adres,
                Tel1 = manken.Tel1,
                Tel2 = manken.Tel2,
                AyakkabiNo = manken.AyakkabiNo,
                Beden = manken.Beden,
                Kilo = manken.Kilo,
                SacRengi = manken.SacRengi,
                GozRengi = manken.GozRengi,
                SehirDisiCalisabilmeDurumu = manken.SehirDisiCalisabilmeDurumu,
                Ehliyet = manken.Ehliyet,
                YabanciDil = manken.YabanciDil,
                Ozellik = manken.Ozellik,
                Cinsiyet = manken.Cinsiyet,
                KategoriId = manken.KategoriId,
                Status = Status.Active
            };
            _kareAjansiContext.Mankenler.Add(addManken);
            _kareAjansiContext.SaveChanges();
        }
        public string DeleteManken(int id)
        {
            var manken = _kareAjansiContext.Mankenler.Where(x => x.Id == id).FirstOrDefault();
            if (manken == null)
            {
                return "Manken bulunamadı";
            }
            else
            {
                // Güncelleme 
                manken.Status = Status.Deleted;
                _kareAjansiContext.SaveChanges();
                return manken.Ad + " silindi";
            }
        }
        public List<MankenDTO> GetAllMankenler()
        {
            var mankenler = from m in _kareAjansiContext.Mankenler
                            where m.Status == Status.Active || m.Status == Status.Updated
                            select new MankenDTO
                            {                               
                                Id = m.Id,
                                Ad = m.Ad,
                                Soyad = m.Soyad,
                                Adres = m.Adres,
                                Tel1 = m.Tel1,
                                Tel2 = m.Tel2,
                                AyakkabiNo = m.AyakkabiNo,
                                Beden = m.Beden,
                                Kilo = m.Kilo,
                                SacRengi = m.SacRengi,
                                GozRengi = m.GozRengi,
                                SehirDisiCalisabilmeDurumu = m.SehirDisiCalisabilmeDurumu,
                                Ehliyet = m.Ehliyet,
                                YabanciDil = m.YabanciDil,
                                Ozellik = m.Ozellik,
                                Cinsiyet = m.Cinsiyet,
                                KategoriId = m.KategoriId,
                                Status = m.Status
                            };
            return mankenler.ToList();
        }
        public MankenDTO GetMankenById(int id)
        {
            var manken = _kareAjansiContext.Mankenler.Where(m => m.Id == id).Select(m => new MankenDTO
            {
                Id = m.Id,
                Ad = m.Ad,
                Soyad = m.Soyad,
                Adres = m.Adres,
                Tel1 = m.Tel1,
                Tel2 = m.Tel2,
                AyakkabiNo = m.AyakkabiNo,
                Beden = m.Beden,
                Kilo = m.Kilo,
                SacRengi = m.SacRengi,
                GozRengi = m.GozRengi,
                SehirDisiCalisabilmeDurumu = m.SehirDisiCalisabilmeDurumu,
                Ehliyet = m.Ehliyet,
                YabanciDil = m.YabanciDil,
                Ozellik = m.Ozellik,
                Cinsiyet = m.Cinsiyet,
                KategoriId = m.KategoriId,
                Status = m.Status
            }).FirstOrDefault();
            return manken;
        }
        public List<MankenDTO> SearchManken(string value)
        {
            var searchManken = _kareAjansiContext.Mankenler.Where(m => m.Ad.Contains(value)).Select(m => new MankenDTO
            {
                Id = m.Id,
                Ad = m.Ad,
                Soyad = m.Soyad,
                GozRengi = m.GozRengi,
                SacRengi = m.SacRengi,
                KategoriId = m.KategoriId
            }).ToList();
            return searchManken;
        }
        public MankenDTO UpdateManken(MankenDTO manken)
        {
            var updateManken = _kareAjansiContext.Mankenler.Find(manken.Id);
            if (updateManken != null)
            {
                updateManken.Ad = manken.Ad;
                updateManken.Soyad = manken.Soyad;
                updateManken.Adres = manken.Adres;
                updateManken.Tel1 = manken.Tel1;
                updateManken.Tel2 = manken.Tel2;
                updateManken.AyakkabiNo = manken.AyakkabiNo;
                updateManken.Beden = manken.Beden;
                updateManken.Kilo = manken.Kilo;
                updateManken.SacRengi = manken.SacRengi;
                updateManken.GozRengi = manken.GozRengi;
                updateManken.SehirDisiCalisabilmeDurumu = manken.SehirDisiCalisabilmeDurumu;
                updateManken.Ehliyet = manken.Ehliyet;
                updateManken.YabanciDil = manken.YabanciDil;
                updateManken.Ozellik = manken.Ozellik;
                updateManken.Cinsiyet = manken.Cinsiyet;
                updateManken.KategoriId = manken.KategoriId;

                // Güncelleme
                updateManken.Status = Status.Updated;
                _kareAjansiContext.SaveChanges();
            }
            return manken;
        }
    }
}