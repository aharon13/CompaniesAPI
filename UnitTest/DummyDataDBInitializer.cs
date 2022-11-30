using CompaniesAPI.Entities;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class DummyDataDBInitializer
    {
        public DummyDataDBInitializer() { }

        public void Seed(CompanyContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Companies.AddRange(
                new Company() { Name = "Dell", Exchange = "ExDell", Ticker = "TDell", Isin = "IS_dell", Website = "dell.com" },
                new Company() { Name = "Apple", Exchange = "Exapple", Ticker = "Tappl", Isin = "IS_app", Website = "apple.com" },
                new Company() { Name = "Lenovo", Exchange = "ExLenovo", Ticker = "Tlen", Isin = "IS_len" }
            );
            
            context.SaveChanges();
        }
    }
}
