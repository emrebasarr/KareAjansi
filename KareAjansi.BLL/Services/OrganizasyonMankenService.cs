using KareAjansi.BLL.DTOs;
using KareAjansi.BLL.Repositories;
using KareAjansi.DAL.Models.Context;
using KareAjansi.DAL.Models.Entity;
using KareAjansi.DAL.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjansi.BLL.Services
{
    public class OrganizasyonMankenService : IOrganizasyonMankenRepository
    {
        private readonly KareAjansiContext _kareAjansiContext;

        public OrganizasyonMankenService(KareAjansiContext kareAjansiContext)
        {
            _kareAjansiContext = kareAjansiContext;
        }
        public List<OrganizasyonMankenDTO> GetOrganizasyonMankenDetails()
        {
            var organizasyonMankenler = from om in _kareAjansiContext.OrganizasyonMankenler
                                        join m in _kareAjansiContext.Mankenler on om.MankenId equals m.Id
                                        where om.Status == Status.Active || om.Status == Status.Updated
                                        select new OrganizasyonMankenDTO
                                        {
                                            Id = om.Id,
                                            OrganizasyonId = om.OrganizasyonId,
                                            MankenId = om.MankenId,
                                            KatilmaTarihi = om.KatilmaTarihi              
                                        };
            return organizasyonMankenler.ToList();
        }
        public void AddOrganizasyonManken(OrganizasyonMankenDTO organizasyonMankenDTO)
        {
            OrganizasyonManken yeniOrganizasyonManken = new OrganizasyonManken
            {
                OrganizasyonId = organizasyonMankenDTO.OrganizasyonId,
                MankenId = organizasyonMankenDTO.MankenId,
                KatilmaTarihi = organizasyonMankenDTO.KatilmaTarihi
                // Diğer özellikleri buraya ekleyin
            };
            _kareAjansiContext.OrganizasyonMankenler.Add(yeniOrganizasyonManken);
            _kareAjansiContext.SaveChanges();
        }
        public string DeleteOrganizasyonManken(int id)
        {
            var organizasyonManken = _kareAjansiContext.OrganizasyonMankenler.Where(x => x.Id == id).FirstOrDefault();
            if (organizasyonManken == null)
            {
                return "OrganizasyonManken bulunamadı";
            }
            else
            {
                // Güncelleme 
                organizasyonManken.Status = Status.Deleted;
                _kareAjansiContext.SaveChanges();
                return organizasyonManken + "silindi";
            }
        }

        public List<OrganizasyonMankenDTO> SearchOrganizasyonManken(string value)
        {
            var searchOrganizasyonManken = _kareAjansiContext.OrganizasyonMankenler
            .Where(om => om.OrganizasyonId.ToString().Contains(value) || om.MankenId.ToString().Contains(value))
            .Select(om => new OrganizasyonMankenDTO
            {
                Id = om.Id,
                OrganizasyonId = om.OrganizasyonId,
                MankenId = om.MankenId,
                KatilmaTarihi = om.KatilmaTarihi
            }).ToList();
            return searchOrganizasyonManken;
        }
    }
}