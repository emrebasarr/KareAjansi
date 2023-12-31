using KareAjansi.DAL.Models.Base;
using KareAjansi.DAL.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjansi.BLL.DTOs
{
    public class YorumDTO
    {
        public int id {  get; set; }
        public string Yazari { get; set; }
        public string Yorumu { get; set; }
        //Bir yorum bir Manken için
        public int MankenId { get; set; }
        public Manken Manken { get; set; }
    }
}