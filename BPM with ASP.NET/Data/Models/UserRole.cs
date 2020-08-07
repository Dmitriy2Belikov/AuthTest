using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPM_with_ASP.NET.Data.Models
{
    public class UserRole
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
