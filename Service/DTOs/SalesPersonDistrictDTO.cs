using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class SalesPersonDistrictDTO
    {
        public string DistrictName { get; set; }
        public int DistrictId { get; set; }
        public int DistrictSalespersonId { get; set; }
        public string Position { get; set; }

       
    }
}
