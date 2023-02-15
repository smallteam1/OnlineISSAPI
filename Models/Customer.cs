using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineISSAPI.Properties.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string GroupKey { get; set; }
        public DateTime LastContactedDate { get; set; }
        public string LAAC { get; set; }
        public string LMU_Managed { get; set; }
        public string Notes { get; set; }
    }
}
