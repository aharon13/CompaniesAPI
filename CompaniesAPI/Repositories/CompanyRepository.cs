using CompaniesAPI.Entities;
using CompaniesAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompaniesAPI.Repositories
{
    public class CompanyRepository : GenericRepository<Entities.Company>, ICompanyRepository
    {
        private CompanyContext _companyContext;

        public CompanyRepository(CompanyContext companyContext)
            : base(companyContext)
        {
            _companyContext = companyContext;
        }

        public Company GetByIsin(string isin)
        {
            return DbSet.FirstOrDefault(a => a.Isin == isin);
        }
    }
}
