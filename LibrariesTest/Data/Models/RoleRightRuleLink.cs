using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryTest.NET.Data.Models
{
    public class RoleRightRuleLink
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public Guid RightId { get; set; }
        public Guid RuleId { get; set; }
    }
}
