using Microsoft.EntityFrameworkCore;
using CompaniesAPI.BusinessServices.Interfaces;
using CompaniesAPI.Entities;
using CompaniesAPI.Models;
using CompaniesAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompaniesAPI.BusinessServices
{
    public class CompanyService : ICompanyService
    {
        private ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository CompanyRepository)
        {
            if (CompanyRepository != null)
                _companyRepository = CompanyRepository;
        }

        public void AddCompany(CompanyModel Company)
        {
            Company CompanyEntity = new Company
            {
                Name = Company.Name,
                Exchange = Company.Exchange,
                Ticker = Company.Ticker,
                Isin = Company.Isin,
                Website = Company.Website
            };

            _companyRepository.Insert(CompanyEntity, true);
        }

        public void DeleteCompany(long id)
        {
            _companyRepository.Delete(id, true);
        }

        public CompanyModel GetCompanyById(long? id)
        {
            CompanyModel CompanyModel = null;
            var CompanyEntity = _companyRepository.GetById(id);
            if (CompanyEntity != null)
            {
                CompanyModel = new CompanyModel
                {
                    Id = CompanyEntity.Id,
                    Name = CompanyEntity.Name,
                    Exchange = CompanyEntity.Exchange,
                    Ticker = CompanyEntity.Ticker,
                    Isin = CompanyEntity.Isin,
                    Website = CompanyEntity.Website
                };
            }

            return CompanyModel;
        }

        public CompanyModel GetCompanyByIsin(string isin)
        {
            CompanyModel CompanyModel = null;
            var CompanyEntity = _companyRepository.GetByIsin(isin);
            if (CompanyEntity != null)
            {
                CompanyModel = new CompanyModel
                {
                    Id = CompanyEntity.Id,
                    Name = CompanyEntity.Name,
                    Exchange = CompanyEntity.Exchange,
                    Ticker = CompanyEntity.Ticker,
                    Isin = CompanyEntity.Isin,
                    Website = CompanyEntity.Website
                };
            }

            return CompanyModel;
        }

        public IList<CompanyModel> GetCompanies()
        {
            var CompanyEntites = _companyRepository.GetAll();

            return CompanyEntites.Select(p => new CompanyModel
            {
                Id = p.Id,
                Name = p.Name,
                Exchange = p.Exchange,
                Ticker = p.Ticker,
                Isin = p.Isin,
                Website = p.Website
            }).ToList();
        }

        public void UpdateCompany(CompanyModel Company)
        {
            Company CompanyEntity = new Company
            {
                Id = Company.Id,
                Name = Company.Name,
                Exchange = Company.Exchange,
                Ticker = Company.Ticker,
                Isin = Company.Isin,                
                Website = Company.Website
            };
            try
            {
                _companyRepository.Update(CompanyEntity, true);

            }
            catch (DbUpdateException ex)
            {
                //todo handle concurrency
                // if RowVersion is not matched 
                throw;
            }
        }
    }
}
