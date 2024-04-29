using BusinessLogic.Services.DialSheetService;
using Entities.DTOs;
using Entities.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TBDMonitoringWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DialSheetController : ControllerBase
    {
        private readonly IDialSheetService _dialSheetService;
        public DialSheetController(IDialSheetService dialSheetService)
        {
            _dialSheetService = dialSheetService;
        }
        [HttpGet]
        [Route("GetDialSheetCompaniesByProjectId/{projectId}")]
        public IActionResult GetDialSheetCompaniesByProjectId(int projectId)
        {
            return Ok(_dialSheetService.GetDialSheetCompaniesByProjectId(projectId));
        }
        [HttpPost]
        [Route("AddCompanyToDialSheet")]
        public IActionResult AddCompanyToDialSheet(CompanyToDialSheet companiesToDialsheet)
        {
            return Ok(_dialSheetService.AddCompanyToDialSheet(companiesToDialsheet));
        }
        [HttpPost]
        [Route("RemoveCompanyFromDialSheet")]
        public IActionResult RemoveCompanyFromDialSheet(CompanyToDialSheet companiesToDialsheet)
        {
            return Ok(_dialSheetService.RemoveCompanyFromDialSheet(companiesToDialsheet));
        }
        [HttpPost]
        [Route("AddAgentToDialSheet")]
        public IActionResult AddAgentToDialSheet(AgentToDialSheet agentToDialSheet)
        {
            return Ok(_dialSheetService.AddAgentToDialSheet(agentToDialSheet));
        }
        [HttpPost]
        [Route("RemoveAgentFromDialSheet")]
        public IActionResult RemoveAgentFromDialSheet(AgentToDialSheet agentToDialSheet)
        {
            return Ok(_dialSheetService.RemoveAgentFromDialSheet(agentToDialSheet));
        }
        [HttpGet]
        [Route("GetDialSheetAgentsByProjectId/{projectId}")]
        public IActionResult GetDialSheetAgentsByProjectId(int projectId)
        {
            return Ok(_dialSheetService.GetDialSheetAgentsByProjectId(projectId));
        }
        [HttpGet]
        [Route("GetDialSheetsList")]
        public ActionResult GetDialSheetsList()
        {
            return Ok(_dialSheetService.GetDialSheetsList());
        }
        [HttpGet]
        [Route("GetDialSheetByProjectId/{projectId}")]
        public ActionResult GetDialSheetByProjectId(int projectId)
        {
            return Ok(_dialSheetService.GetProjectDialSheetByProjectId(projectId));
        }
        [HttpPost]
        [Route("UpdateCallSheetDetails")]
        public ActionResult UpdateCallSheetDetails(CallHistory callHistory)
        {
            return Ok(_dialSheetService.UpdateCallSheetDetails(callHistory));
        }
        [HttpPost]
        [Route("GetCallSheetDetails")]
        public ActionResult GetCallSheetDetails(ProjectIdCompanyId pcObj)
        {
            return Ok(_dialSheetService.GetCallSheetDetails(pcObj));
        }
    }
}
