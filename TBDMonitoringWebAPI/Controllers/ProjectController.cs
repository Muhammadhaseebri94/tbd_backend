using BusinessLogic.Services.ProjectService;
using Entities.Entity;
using Microsoft.AspNetCore.Mvc;

namespace TBDMonitoringWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectservice)
        {
            _projectService = projectservice;
        }
        [HttpGet]
        [Route("GetAllProjects")]
        public ActionResult GetAllProjects()
        {
            return Ok(_projectService.GetAllProjects());
        }
        [HttpGet]
        [Route("GetProjectById/{projectid}")]
        public ActionResult GetProject(int projectid)
        {
            return Ok(_projectService.GetProjectById(projectid));

        }
        [HttpPost]
        [Route("CreateProject")]
        public ActionResult CreateProject([FromBody] Project project)
        {
            return Ok(_projectService.CreateProject(project));
        }
        [HttpPut]
        [Route("UpdateProject")]
        public ActionResult UpdateProject(Project project)
        {
            return Ok(_projectService.UpdateProject(project));
        }
        [HttpDelete]
        [Route("DeleteProject/{projectId}")]
        public ActionResult DeleteProject(int projectId)
        {
            return Ok(_projectService.DeleteProject(projectId));
        }
        [HttpGet]
        [Route("SearchProjectByName/{searchName}")]
        public ActionResult SearchProjectByName(string searchName)
        {
            return Ok(_projectService.SearchProjectByName(searchName));
        }
    }
}
