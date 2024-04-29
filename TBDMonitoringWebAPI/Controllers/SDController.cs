using BusinessLogic.Services.StaticDataService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TBDMonitoringWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SDController : ControllerBase
    {
        private readonly ISDService _service;
        public SDController(ISDService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetAllProjectTypes")]
        public ActionResult GetAllProjectTypes()
        {
            return Ok(_service.GetAllProjectTypes());
        }
        [HttpGet]
        [Route("GetAllCallStatuses")]
        public ActionResult GetAllCallStatuses()
        {
            return Ok(_service.GetAllCallStatuses());
        }
    }
}
