using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.CompanyService
{
    public interface ICompanyService
    {
        public List<Company> GetAllCompanies();
        public Company GetCompanyById(int id);
        public object CreateCompany(Company company);
        public object UpdateCompany(Company company);
        public object DeleteCompany(int companyId);
    }
}
