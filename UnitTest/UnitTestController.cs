using CompaniesAPI.Entities;
using CompaniesAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace UnitTest
{
    public class UnitTestController
    {
        private CompanyRepository _companyRepository;

        public static DbContextOptions<CompanyContext> dbContextOptions { get; }
        public static string connectionString = "Server=localhost\\sqlexpress;Database=TestDB;Trusted_Connection=True";

        static UnitTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<CompanyContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public UnitTestController()
        {
            var context = new CompanyContext(dbContextOptions);
            DummyDataDBInitializer db = new DummyDataDBInitializer();
            db.Seed(context);

            _companyRepository = new CompanyRepository(context);
        }

        #region Get By Id

        [Fact]
        public void GetById_ReturnID()
        {
            long id = 2;
           
            //Act
            var data = _companyRepository.GetById(id);

            //Assert
            Assert.Equal(2, data.Id);
        }

        [Fact]
        public void GetById_ReturnNull()
        {
            long id = 4;

            //Act
            var data = _companyRepository.GetById(id);

            //Assert
            Assert.Null(data);
        }

        [Fact]
        public void GetById_ReturnNull_()
        {
            long? id = null;

            //Act
            var data = _companyRepository.GetById(id);

            //Assert
            Assert.Null(data);
        }
        #endregion

        #region Get All  

        [Fact]
        public void GetAll()
        {
            //Act
            var data = _companyRepository.GetAll();

            //Assert
            Assert.Equal(3, data.Count());
        }

        #endregion

        #region Add New Company  

        [Fact]
        public void Add_ValidData()
        {
            Company company = new Company() { Name = "Lenovo1", Exchange = "ExLenovo1", Ticker = "Tlen1", Isin = "IS_len1" };

            //Act
            _companyRepository.Insert(company, true);
            var data = _companyRepository.GetAll();

            //Assert
            Assert.Equal(4, data.Count());
        }

        [Fact]
        public void Add_InvalidData()
        {
            Company company = new Company() { Name = "Lenovo1", Exchange = "ExLenovo1", Ticker = "Tlen1", Isin = "IS_len1" };

            //Act
            _companyRepository.Insert(company, true);
            var data = _companyRepository.GetAll();

            //Assert
            Assert.Equal(4, data.Count());
        }

        [Fact]
        public void Add_InvalidData_Isin()
        {
            Company company = new Company() { Name = "Lenovo1", Exchange = "ExLenovo1", Ticker = "Tlen1", Isin = "I1_len1" };

            //Act
            _companyRepository.Insert(company, true);
            var data = _companyRepository.GetAll();

            //Assert
            Assert.Equal(4, data.Count());
        }

        #endregion

        #region Delete Company  

        [Fact]
        public void Delete_Existing()
        {
            //Act
            _companyRepository.Delete((long)3, true);
            var data = _companyRepository.GetAll();

            //Assert
            Assert.Equal(2, data.Count());
        }

        [Fact]
        public void Delete_NotExisting()
        {
            //Act
            _companyRepository.Delete((long)3, true);
            var data = _companyRepository.GetAll();

            //Assert
            Assert.Equal(2, data.Count());
        }

        #endregion

        #region Update Company  

        [Fact]
        public void Update()
        {
            long id = 1;
            //Act
            Company company = _companyRepository.GetById(id);
            company.Name = "Alienware";
            _companyRepository.Update(company, true);
            var data = _companyRepository.GetById(id);

            //Assert
            Assert.Equal("Alienware", data.Name);
        }

        #endregion
    }
}
