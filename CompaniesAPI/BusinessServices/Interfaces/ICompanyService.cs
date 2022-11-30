using CompaniesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompaniesAPI.BusinessServices.Interfaces
{
    public interface ICompanyService
    {
        IList<CompanyModel> GetCompanies();
        CompanyModel GetCompanyById(long? id);
        CompanyModel GetCompanyByIsin(string isin);
        void AddCompany(CompanyModel Company);
        void UpdateCompany(CompanyModel Company);
        void DeleteCompany(long id);
    }
}
