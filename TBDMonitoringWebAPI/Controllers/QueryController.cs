using BusinessLogic.Services.QueryService;
using Entities.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TBDMonitoringWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryController : ControllerBase
    {
        private readonly IQueryService _queryService;
        public QueryController(IQueryService queryService)
        {
            _queryService = queryService;
        }
        [HttpGet]
        [Route("GetQueriesByProjectId")]
        public ActionResult GetQueriesByProjectCompanyId(int ProjectId, int CompanyId)
        {
            return Ok(_queryService.GetQueriesByProjectCompanyId(ProjectId, CompanyId));
        }
        [HttpPost]
        [Route("CreateQuery")]
        public ActionResult CreateQuery(Query query)
        {
            return Ok(_queryService.CreateQuery(query));
        }
        [HttpPut]
        [Route("UpdateQuery")]
        public ActionResult UpdateQuery(Query query)
        {
            return Ok(_queryService.UpdateQuery(query));
        }
    }
}
