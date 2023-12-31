using KareAjansi.DAL.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjansi.DAL.Models.Entity
{
    public class Organizasyon:BaseClass
    {
        //Property
        public string Ad { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public string Sehir { get; set; }
        public string Firma { get; set; }
        public int GunSayisi { get; set; }

        //Bir Organizasyonda birden fazla manken olabilir
        public List<OrganizasyonManken> OrganizasyonMankenler {  get; set; }

        //Bir Organizasyonda birden fazla Ödeme olabilir.
        public List<Odeme> Odemeler { get; set; }
    }
}