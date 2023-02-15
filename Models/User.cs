using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineISSAPI.Properties.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserSalaryId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserRole { get; set; }
        public string UserEmail { get; set; }

    }
}
