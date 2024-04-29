using Data_Access.Context;
using Data_Access.Generic_Repository;
using Entities.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.CompanyService
{
    public class CompanyService : ICompanyService
    {
        private IGenericRepository<Company> _companyRepository;
        public CompanyService(IGenericRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public List<Company> GetAllCompanies()
        {
            List<Company> result = _companyRepository.GetAll(x => x.IsDeleted != true).OrderByDescending(x => x.Id).ToList();
            return result == null ? null : result;
        }
        public Company GetCompanyById(int companyid)
        {
            if (companyid != null)
            {
                Company company = _companyRepository.Get(x => x.Id == companyid);
                return company == null ? null : company;
            }
            return null;
        }
        public object CreateCompany(Company company)
        {
            if (company != null)
            {
                try
                {
                    var companyObj = _companyRepository.Get(x => x.EmailAddress == company.EmailAddress);
                    if (companyObj != null)
                    {
                        return new { message = "Email already exist", status = 0, result = string.Empty };
                    }
                    _companyRepository.Add(company);
                    _companyRepository.SaveChanges();
                    return new { message = "Company added successfully",status=1, result = string.Empty };
                }
                catch (Exception ex)
                {
                    return new { message = ex.Message, result = string.Empty };
                }

            }
            return null;
        }
        public Object UpdateCompany(Company company)
        {
            if (company.Id != null)
            {
                if (company != null)
                {
                    try
                    {
                        _companyRepository.Update(company);
                        _companyRepository.SaveChanges();
                        Company result = _companyRepository.Get(x => x.Id == company.Id);
                        return new {message="Company updated successfully", result };
                    }
                    catch (Exception ex)
                    {
                        return new { message = ex.Message, result = string.Empty };
                    }
                }
                return new { message = "Company not found", result=string.Empty };
            }
            return new { message = "Error in company model", result = string.Empty };
        }
        public object DeleteCompany(int companyid)
        {
            try
            {
                Company company = _companyRepository.Get(x => x.Id == companyid);
                if (company != null)
                {
                    if (company.IsDeleted == true)
                    {
                        return new { message = "Company already deleted", result = string.Empty };
                    }
                    else
                    {
                        company.IsDeleted = true;
                        _companyRepository.Update(company);
                        _companyRepository.SaveChanges();
                        return  new { message = "Company deleted successfully", result = string.Empty };
                    }
                }
                return new { message = "Company not found", result = string.Empty };
            }
            catch (Exception ex)
            {
                return new { message = ex.Message, result = string.Empty };
            }
        }
    }
}
