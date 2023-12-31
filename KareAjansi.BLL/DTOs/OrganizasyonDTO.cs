using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjansi.BLL.DTOs
{
    public class OrganizasyonDTO
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public string Sehir { get; set; }
        public string Firma { get; set; }
        public int GunSayisi { get; set; }
        public int MankenSayisi { get; set; }
    }
}