using Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class DistrictDTO
    {
            public int DistrictId { get; set; }
            public string Name { get; set; }
            public List<SalesPersonDTO> SalesPersons { get; set;}

    }
}
