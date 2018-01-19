using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Entities
{
    public class DistrictSalesPerson
    {
        public DistrictSalesPerson()
        {

        }
        public int DistrictSalesPersonId { get; set; }
        public int SPId { get; set; }
        public int DistrictId { get; set; }
    }
}
