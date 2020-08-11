using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryTest.NET.Data.Models
{
    public class Right
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
