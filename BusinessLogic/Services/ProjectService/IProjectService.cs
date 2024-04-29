using Entities.DTOs;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.ProjectService
{
    public interface IProjectService
    {
        public object CreateProject(Project project);
        public object UpdateProject(Project project);
        public object GetAllProjects();
        public Project GetProjectById(int Id);
        public object DeleteProject(int ProjectId);
        public List<Project> SearchProjectByName(string searchName);
    }
}
