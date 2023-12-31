using KareAjansi.DAL.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjansi.DAL.Models.Entity
{
    public class OrganizasyonManken:BaseClass
    {
        //Property
        public int OrganizasyonId { get; set; }
        public Organizasyon Organizasyon { get; set; }
        public int MankenId { get; set; }
        public Manken Manken { get; set; }
        public DateTime KatilmaTarihi { get; set; }
    }
}