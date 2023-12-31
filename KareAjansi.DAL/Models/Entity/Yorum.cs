using KareAjansi.DAL.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjansi.DAL.Models.Entity
{
    public class Yorum:BaseClass
    {
        //Property
        public string Yazari { get; set; }
        public string Yorumu { get; set; }
        //Bir yorum bir Manken için
        public int MankenId { get; set; }
        public Manken Manken { get; set; }
    }
}