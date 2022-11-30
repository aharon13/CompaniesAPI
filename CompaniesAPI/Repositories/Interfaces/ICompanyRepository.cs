using CompaniesAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompaniesAPI.Repositories.Interfaces
{
    public interface ICompanyRepository : IGenericRepository<Entities.Company>
    {
        Company GetByIsin(string isin);
    }
}
