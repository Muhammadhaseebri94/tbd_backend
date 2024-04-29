using Data_Access.Context;
using Data_Access.Generic_Repository;
using Entities.DTOs;
using Entities.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.ProjectService
{
    public class ProjectService : IProjectService
    {
        private readonly IGenericRepository<Project> _projectRepository;
        private readonly IGenericRepository<DialSheet> _dialSheetRepository;
        private readonly IGenericRepository<ProjectType> _projectTypeRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        public ProjectService(IGenericRepository<Project> projectRepository,IGenericRepository<DialSheet> dialSheetRepository, IGenericRepository<ProjectType> projectTypeRepository, IHttpContextAccessor contextAccessor)
        {
            _projectRepository = projectRepository;
            _dialSheetRepository = dialSheetRepository;
            _projectTypeRepository = projectTypeRepository;
            _contextAccessor = contextAccessor;
        }
        public object CreateProject(Project project)
        {
            try
            {
                if (project != null)
                {
                    project.CreatedAt= DateTime.Now;
                    project.CreatedById = _contextAccessor.HttpContext.Items["UserId"].ToString();
                    _projectRepository.Add(project);
                    _projectRepository.SaveChanges();
                    DialSheet dialSheet = new DialSheet { ProjectId = project.Id };
                    _dialSheetRepository.Add(dialSheet);
                    _dialSheetRepository.SaveChanges();

                    return new { result = string.Empty, message = "Project created successfully" };
                }
                return null;
            }
            catch (Exception ex)
            {
                return new { result = string.Empty, message = ex.Message };
            }
        }
        public object GetAllProjects()
        {
            try
            {
                List<Project> projectlist = _projectRepository.GetAll(x => x.IsDeleted == false).OrderByDescending(x => x.Id).ToList();
                if (projectlist.Any())
                {

                    //foreach (Project project in projectlist)
                    //{
                    //    project.ProjectType = _projectTypeRepository.Get(x=>x.Id==project.ProjectTypeId).ProjectTypeName;
                    //}
                    return new { result = projectlist}; ;
                }
                else {
                    return new { result = new List<string>() };
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Project GetProjectById(int Id)
        {
            try
            {
                Project projectobj = _projectRepository.Get(x=>x.Id == Id);
                return projectobj != null ? projectobj : null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public object UpdateProject(Project project)
        {
            try
            {
                if (project != null)
                {
                    project.ModifiedById = _contextAccessor.HttpContext.Items["UserId"].ToString();
                    project.ModifiedAt=DateTime.Now;
                    _projectRepository.Update(project);
                    _projectRepository.SaveChanges();
                    Project result = _projectRepository.Get(x => x.Id == project.Id);
                    return new { message = "Project updated successfully", result };
                }
                return new { message = "Project updated successfully", result=string.Empty };
            }
            catch (Exception ex)
            {
                return  new { message = ex.Message, result = string.Empty };
            }
        }
        public object DeleteProject(int projectId)
        {
            try
            {
                Project project = _projectRepository.Get(x => x.Id == projectId);
                if(project != null)
                {
                    if (project.IsDeleted == true)
                    {
                        return  new { message = "Project already deleted", result = string.Empty };
                    }
                    else
                    {
                        project.IsDeleted = true;
                        _projectRepository.Update(project);
                        _projectRepository.SaveChanges();
                        return new { message = "Project deleted successfullly", result = string.Empty};
                    }
                }
                return new { message = "Project not found", result = string.Empty };
            }
            catch (Exception ex)
            {
                return  new { message = ex.Message, result = string.Empty };
            }
        }
        public List<Project> SearchProjectByName (string searchName)
        {
            List<Project> projectsList = new List<Project>();
            try
            {
                projectsList = _projectRepository.GetAll(x => x.ProjectTitle.ToLower().Contains(searchName.ToLower())).ToList();
                return projectsList;
            }
            catch (Exception ex)
            {
                return projectsList;
            }
        }
    }
}
