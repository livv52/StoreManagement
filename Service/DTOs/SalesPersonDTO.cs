using Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class SalesPersonDTO
    {
        public int SPId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Description { get; set; }
        public string Position { get; set; }
        public int DistrictSalespersonId { get; set;}
    }
}
