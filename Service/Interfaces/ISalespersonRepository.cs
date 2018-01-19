using Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ISalespersonRepository
    {
        Salesperson Insert(Salesperson salesperson);
        Salesperson Get(int id);
        bool Update(Salesperson salesperson);
        void Delete(int id);
        List<Salesperson> List();
    }
}
