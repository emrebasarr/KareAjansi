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
    public class YorumService : IYorumRepository
    {
        private readonly KareAjansiContext _kareAjansiContext;

        public YorumService(KareAjansiContext kareAjansiContext) 
        {
            _kareAjansiContext = kareAjansiContext;
        }
        public void AddYorum(YorumDTO yorum)
        {
            var addYorum = new Yorum
            {

                Yazari = yorum.Yazari,
                Yorumu = yorum.Yorumu,
                MankenId = yorum.MankenId,
                Status = Status.Active
            };
            _kareAjansiContext.Yorumlar.Add(addYorum);
            _kareAjansiContext.SaveChanges();
        }

        public string DeleteYorum(int yorumId)
        {
            var yorum = _kareAjansiContext.Yorumlar.Where(x => x.Id == yorumId).FirstOrDefault();
            if (yorum == null)
            {
                return "Yorum bulunamadı";
            }
            else
            {
                // Güncelleme 
                yorum.Status = Status.Deleted;
                _kareAjansiContext.SaveChanges();
                return yorum.Id + " silindi";
            }
        }

        public List<YorumDTO> GetYorumlarByMankenId(int yorumId)
        {
            var yorumlar = _kareAjansiContext.Yorumlar
            .Where(y => y.MankenId == yorumId && (y.Status == Status.Active || y.Status == Status.Updated))
            .Select(y => new YorumDTO
            {
                id = y.Id,
                Yazari = y.Yazari,
                Yorumu = y.Yorumu,
                MankenId = y.MankenId,
            }).ToList();
            return yorumlar;
        }

        public YorumDTO UpdateYorum(YorumDTO yorum)
        {
            var updateYorum = _kareAjansiContext.Yorumlar.Find(yorum.id);
            if (updateYorum != null)
            {
                updateYorum.Yazari = yorum.Yazari;
                updateYorum.Yorumu = yorum.Yorumu;
                updateYorum.MankenId = yorum.MankenId;
           
                updateYorum.Status = Status.Updated;
                _kareAjansiContext.SaveChanges();
            }
            return yorum;
        }
    }
}