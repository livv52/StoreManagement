using Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IStoreRepository
    {
        Store Insert(Store store);
        Store Get(int id);
        bool Update(Store store);
        void Delete(int id);
        List<Store> List();
    }
}
