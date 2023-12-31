using KareAjansi.DAL.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjansi.DAL.Models.Entity
{
    public class Resim:BaseClass
    {
        //Property
        public string ResimData { get; set; }

        //Resim ile Manken ilişkisi
        public int MankenId { get; set; }
        public Manken Manken { get; set; }
    }
}