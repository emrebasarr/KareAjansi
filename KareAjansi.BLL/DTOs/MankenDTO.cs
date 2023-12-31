using KareAjansi.DAL.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjansi.BLL.DTOs
{
    public class MankenDTO
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Adres { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public string AyakkabiNo { get; set; }
        public string Beden { get; set; }
        public string Kilo { get; set; }
        public string SacRengi { get; set; }
        public string GozRengi { get; set; }
        public bool SehirDisiCalisabilmeDurumu { get; set; }
        public bool Ehliyet { get; set; }
        public string YabanciDil { get; set; }
        public string Ozellik { get; set; }
        public string Cinsiyet { get; set; }
        public int KategoriId { get; set; }
        public Status Status { get; set; }
    }
}