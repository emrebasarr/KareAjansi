using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjansi.BLL.DTOs
{
    public class OrganizasyonMankenDTO
    {
        public int Id { get; set; }
        public int OrganizasyonId { get; set; }
        public DateTime KatilmaTarihi { get; set; }
        public int MankenId { get; set; }
    }
}