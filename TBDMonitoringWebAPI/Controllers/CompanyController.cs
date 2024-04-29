using BusinessLogic.Services.CompanyService;
using Entities.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace TBDMonitoringWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        [HttpGet]
        [Route("GetAllCompanies")]
        public ActionResult<List<Company>> GetAllCompanies()
        {
            return Ok(_companyService.GetAllCompanies());
        }
        [HttpGet]
        [Route("GetCompanyById/{id}")]
        public ActionResult<Company> GetCompanyById(int id)
        {
            return Ok(_companyService.GetCompanyById(id));
        }
        [HttpPost]
        [Route("CreateCompany")]
        public ActionResult CreateCompany(Company company)
        {
            return Ok(_companyService.CreateCompany(company));
        }
        [HttpPut]
        [Route("UpdateCompany")]
        public ActionResult UpdateCompany(Company company)
        {
            return Ok(_companyService.UpdateCompany(company));
        }
        [HttpDelete]
        [Route("DeleteCompany/{companyId}")]
        public IActionResult DeleteCompany(int companyId) 
        {
            return  Ok(_companyService.DeleteCompany(companyId));
        }
    }
}
