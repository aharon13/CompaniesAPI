using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CompaniesAPI.BusinessServices.Interfaces;
using CompaniesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CompaniesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        // GET: api/<CompaniesController>
        [HttpGet]
        public IEnumerable<CompanyModel> Get()
        {
            List<CompanyModel> companies = _companyService.GetCompanies().ToList();
            return companies;
        }

        // GET api/<CompaniesController>/5
        [HttpGet("{id}")]
        public CompanyModel Get(long? id)
        {
            CompanyModel company = _companyService.GetCompanyById(id);

            return company;
        }

        // GET api/<CompaniesController>/string

        [HttpGet("isin/{isin}")]
        public CompanyModel GetIsin(string isin)
        {
            CompanyModel company = _companyService.GetCompanyByIsin(isin);

            return company;
        }

        // POST api/<CompaniesController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CompanyModel Company)
        {
            try
            {
                _companyService.AddCompany(Company);

            }
            catch (Exception ex)
            {
                //todo handle teh exceptions
                //logging
                throw;
            }

            return Ok();
        }

        // PUT api/<CompaniesController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(long id, [FromBody] CompanyModel Company)
        {
            try
            {
                Company.Id = id;
                _companyService.UpdateCompany(Company);

            }
            catch (Exception ex)
            {
                //todo handle the exceptions
                //logging
                throw;
            }

            return Ok();
        }

        // DELETE api/<CompaniesController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(long id)
        {
            try
            {
                _companyService.DeleteCompany(id);

            }
            catch (Exception ex)
            {
                //todo handle the exceptions
                //logging
                throw;
            }

            return Ok();

        }
    }
}
