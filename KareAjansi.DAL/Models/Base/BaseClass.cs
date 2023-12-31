using KareAjansi.DAL.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjansi.DAL.Models.Base
{
    public abstract class BaseClass
    {
        public int Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreatedComputerName { get; set; }
        public string? CreatedIpAddress { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdatedComputerName { get;set; }
        public string? UpdatedIpAddress { get;set; }
        public Status Status { get; set; }
    }
}