using KareAjansi.DAL.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjansi.DAL.Models.Entity
{
    public class Odeme:BaseClass
    {
        //Property
        public DateTime Tarih { get; set; }
        public decimal Ucret { get; set; }
        public string OdemeTipi { get; set; }
        public decimal GunlukUcret { get; set; }
        public decimal KonaklamaUcreti { get; set; }
        public decimal YemekUcreti { get; set; }
        // Manken ile ilişki
        public int MankenId { get; set; }
        public Manken Manken { get; set; }
        // Organizasyon ile ilişki
        public int OrganizasyonId { get; set; }
        public Organizasyon Organizasyon { get; set; }
    }
}