using Service.DTOs;
using Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IDistrictRepository
    {
        District Insert(DistrictDTO districtDto);
        District Get(int id);
        bool Update(District district);
        void Delete(int id);
        List<District> List();
        List<Store> GetStores(int districtId);
        List<SalesPersonDTO> GetSalesperson(int districtId);
        bool AddSalesPerson(DistrictSalesPerson districtSalesPerson);
        bool DeleteSalesPerson(int id);
    }
}
