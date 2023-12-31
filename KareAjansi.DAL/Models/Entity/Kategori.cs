using KareAjansi.DAL.Models.Base;
using KareAjansi.DAL.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjansi.DAL.Models.Entity
{
    public class Kategori:BaseClass
    {
        //Property
        public string Ad { get; set; }
        public decimal KategoriThree { get; set; }
        public Fiyat Fiyat { get; set; }

        //Bir kategoride birden fazla manken olabilir.
        public List<Manken> Mankenler { get; set; }
    }
}