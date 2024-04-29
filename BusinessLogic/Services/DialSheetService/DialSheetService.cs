using Data_Access.Context;
using Data_Access.Generic_Repository;
using Entities.DTOs;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.DialSheetService
{
    public class DialSheetService : IDialSheetService
    {
        private readonly ApplicationDbContext _context;
        private readonly IGenericRepository<Project> _projectRepository;
        private readonly IGenericRepository<Company> _companyRepository;
        private readonly IGenericRepository<DialSheetCompany> _dialSheetCompanyRepository;
        private readonly IGenericRepository<DialSheetAgent> _dialSheetAgentRepository;
        private readonly IGenericRepository<DialSheet> _dialSheetRepository;
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<CallHistory> _callHistoryRepository;
        public DialSheetService(ApplicationDbContext context,
            IGenericRepository<Project> projectRepository,
            IGenericRepository<Company> companyRepository,
            IGenericRepository<DialSheetCompany> dialSheetCompanyRepository,
            IGenericRepository<DialSheetAgent> dialSheetAgentRepository,
            IGenericRepository<DialSheet> dialSheetRepository,
            IGenericRepository<User> userRepository,
            IGenericRepository<CallHistory> callHistoryRepository)
        {
            _context = context;
            _projectRepository = projectRepository;
            _companyRepository = companyRepository;
            _dialSheetAgentRepository = dialSheetAgentRepository;
            _dialSheetCompanyRepository = dialSheetCompanyRepository;
            _dialSheetRepository = dialSheetRepository;
            _userRepository = userRepository;
            _callHistoryRepository = callHistoryRepository;
        }
        public object AddCompanyToDialSheet(CompanyToDialSheet companiestodialsheet)
        {
            if (companiestodialsheet != null)
            {
                int dialsheetid = GetDialSheetByProjectId(companiestodialsheet.ProjectId).Id;
                var result = _context.DialSheetCompanies.Where(x => x.DialSheetId == dialsheetid).ToList();
                foreach (var item in result)
                {
                    if (item.CompanyId == companiestodialsheet.CompanyId)
                    {
                        return new { message = "Already added to dialSheet", result = string.Empty };
                    }
                }
                DialSheetCompany dialSheetCompany = new DialSheetCompany
                {
                    DialSheetId = _context.DialSheets.FirstOrDefault(x => x.ProjectId == companiestodialsheet.ProjectId).Id,
                    CompanyId = companiestodialsheet.CompanyId
                };
                _context.DialSheetCompanies.Add(dialSheetCompany);
                _context.SaveChanges();
                return new { message = "Company added to dialsheet", result = string.Empty };
            }
            return new { message = "Unknown error occured", result = string.Empty };
        }
        public object RemoveCompanyFromDialSheet(CompanyToDialSheet companiestodialsheet)
        {
            if (companiestodialsheet != null)
            {
                int dialsheetid = GetDialSheetByProjectId(companiestodialsheet.ProjectId).Id;
                var result = _context.DialSheetCompanies.Where(x => x.DialSheetId == dialsheetid).ToList();
                foreach (var item in result)
                {
                    if (item.CompanyId == companiestodialsheet.CompanyId)
                    {
                        DialSheetCompany dialSheetCompany = _context.DialSheetCompanies.FirstOrDefault(x => x.CompanyId == item.CompanyId);
                        _context.DialSheetCompanies.Remove(dialSheetCompany);
                        _context.SaveChanges();
                        return new { message = "Company removed successfully", result = string.Empty };
                    }

                }
                return new { message = "Company not present in the dialsheet", result = string.Empty };

            }
            return new { message = "Unknow error occured", result = string.Empty };
        }
        public object CreateDialSheet(DialSheet dialsheet)
        {
            if (dialsheet != null)
            {
                _context.DialSheets.Add(dialsheet);
                _context.SaveChanges();
                return new { message = "Dial sheet added successfully", result = string.Empty };
            }
            return null;
        }
        public DialSheet GetDialSheetByProjectId(int projectId)
        {
            if (projectId != 0)
            {
                DialSheet dialsheetobj = _context.DialSheets.FirstOrDefault(x => x.ProjectId == projectId);
                if (dialsheetobj != null)
                {
                    return dialsheetobj;
                }
                return null;
            }
            return null;
        }
        public List<Company> GetDialSheetCompaniesByProjectId(int projectId)
        {
            try
            {
                List<Company> dialsheetcompanies = new List<Company>();
                if (projectId != 0)
                {
                    int dialsheetid = GetDialSheetByProjectId(projectId).Id;
                    var result = _context.DialSheetCompanies.Where(x => x.DialSheetId == dialsheetid).ToList();
                    if (dialsheetid != 0 && result.Any())
                    {
                        foreach (var dialsheetcompany in result)
                        {
                            if (dialsheetcompany.DialSheetId == dialsheetid)
                            {
                                dialsheetcompanies.Add(_context.Companies.FirstOrDefault(x => x.Id == dialsheetcompany.CompanyId));
                            }
                        }
                        if (dialsheetcompanies.Any())
                        {
                            return dialsheetcompanies;
                        }
                    }
                    return dialsheetcompanies;
                }
                return dialsheetcompanies;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<User> GetDialSheetAgentsByProjectId(int projectId)
        {
            try
            {
                List<User> agentsList = new List<User>();
                if (projectId != 0)
                {
                    int dialsheetid = GetDialSheetByProjectId(projectId).Id;
                    if (dialsheetid != 0)
                    {
                        List<DialSheetAgent> dialsheetagents = _context.DialSheetAgents.Where(x => x.DialSheetId == dialsheetid).ToList();
                        if (dialsheetagents != null)
                        {

                            foreach (var dialsheetagent in dialsheetagents)
                            {
                                agentsList.Add(_context.Users.FirstOrDefault(u => u.Id == dialsheetagent.AgentId));
                            }
                            return agentsList;
                        }
                    }
                    return agentsList;
                }
                return agentsList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public object AddAgentToDialSheet(AgentToDialSheet agentToDialSheet)
        {
            if (agentToDialSheet != null)
            {
                int dialsheetid = GetDialSheetByProjectId(agentToDialSheet.ProjectId).Id;
                var result = _context.DialSheetAgents.Where(x => x.DialSheetId == dialsheetid).ToList();
                foreach (var item in result)
                {
                    if (item.AgentId == agentToDialSheet.AgentId)
                    {
                        return new { message = "Agent already added to dialseet", result = string.Empty };
                    }
                }
                DialSheetAgent dialSheetAgent = new DialSheetAgent
                {
                    DialSheetId = _context.DialSheets.FirstOrDefault(x => x.ProjectId == agentToDialSheet.ProjectId).Id,
                    AgentId = agentToDialSheet.AgentId
                };
                _context.DialSheetAgents.Add(dialSheetAgent);
                _context.SaveChanges();
                return new { message = "Agent assigned to dialsheet", result = string.Empty };
            }
            return new { message = "Unknown error occured", result = string.Empty };
        }
        public object RemoveAgentFromDialSheet(AgentToDialSheet agentToDialSheet)
        {
            if (agentToDialSheet != null)
            {
                int dialsheetid = GetDialSheetByProjectId(agentToDialSheet.ProjectId).Id;
                var result = _context.DialSheetAgents.Where(x => x.DialSheetId == dialsheetid).ToList();
                foreach (var item in result)
                {
                    if (item.AgentId == agentToDialSheet.AgentId)
                    {
                        DialSheetAgent dialSheetCompany = _context.DialSheetAgents.FirstOrDefault(x => x.AgentId == item.AgentId);
                        _context.DialSheetAgents.Remove(dialSheetCompany);
                        _context.SaveChanges();
                        return new { message = "Agent removed successfully", result = string.Empty };
                    }
                }
                return new { message = "Agent not present in the dialSheet", result = string.Empty };
            }
            return new { message = "Unknown error occured", result = string.Empty };
        }

        public List<object> GetDialSheetsList()
        {
            List<object> DialSheetsList = new List<object>();
            try
            {
                List<Project> projectsList = _projectRepository.GetAll(x => x.IsDeleted == false).ToList();
                List<DialSheet> dialSheetsList = _dialSheetRepository.GetAll(null).ToList();
                List<DialSheetCompany> dialSheetCompanies = new List<DialSheetCompany>();
                foreach (var project in projectsList)
                {
                    int dialSheetId = dialSheetsList.FirstOrDefault(x => x.ProjectId == project.Id).Id;
                    dialSheetCompanies = _dialSheetCompanyRepository.GetAll(x => x.DialSheetId == dialSheetId).ToList();
                    List<Company> companiesList = new List<Company>();
                    foreach (var dialSheetCompany in dialSheetCompanies)
                    {
                        companiesList.Add(_companyRepository.Get(x => x.Id == dialSheetCompany.CompanyId));
                    }
                    DialSheetsList.Add(new { project, companiesList });
                }
                return DialSheetsList;
            }
            catch (Exception ex)
            {
                return new List<object>();
            }
        }
        public object GetProjectDialSheetByProjectId(int projectId)
        {
            object DialSheetsList = new object();
            try
            {
                Project projectobj = _projectRepository.Get(x => x.IsDeleted == false && x.Id == projectId);
                int dialSheetId = _dialSheetRepository.Get(x => x.ProjectId == projectobj.Id).Id;
                List<DialSheetCompany> dialSheetCompanies = _dialSheetCompanyRepository.GetAll(x => x.DialSheetId == dialSheetId).ToList();
                List<DialSheetAgent> dialSheetAgents =_dialSheetAgentRepository.GetAll(x=>x.DialSheetId==dialSheetId).ToList(); 
                List<Company> companiesList = new List<Company>();
                List<User> assignedAgentsList = new List<User>();
                foreach (var dialSheetCompany in dialSheetCompanies)
                {
                    companiesList.Add(_companyRepository.Get(x => x.Id == dialSheetCompany.CompanyId));
                }
                foreach (var dialSheetAgent in dialSheetAgents)
                {
                    assignedAgentsList.Add(_userRepository.Get(x => x.Id == dialSheetAgent.AgentId));
                }
                DialSheetsList = new { projectobj, companiesList,assignedAgentsList};
                return DialSheetsList;
            }
            catch (Exception ex)
            {
                return new { };
            }
        }

        public object UpdateCallSheetDetails(CallHistory callHistory)
        {
            CallHistory callHistory1 = new CallHistory();
            try
            {
                if (callHistory != null)
                {
                    if (callHistory.Id == 0)
                    {
                        _callHistoryRepository.Add(callHistory);
                        _callHistoryRepository.SaveChanges();
                        return new { message = "Call Details Added Successfully", result = callHistory };
                    }
                    else
                    {
                        _callHistoryRepository.Update(callHistory);
                        _callHistoryRepository.SaveChanges();
                        callHistory1=_callHistoryRepository.Get(x=>x.Id == callHistory.Id);
                        return new { message = "Call Details Updated Successfully", result = callHistory1 };
                    }
                }
                return new { message = "Unexpected Error Occured", result = callHistory1 };
            }
            catch (Exception ex)
            {
                return new { message = ex.Message, result = callHistory };
            }
        }

        public object GetCallSheetDetails(ProjectIdCompanyId pcObj)
        {
            CallHistory callHistory = new CallHistory();
            try
            {
                if(pcObj!= null)
                {
                   var result= _callHistoryRepository.Get(x => x.ProjectId == pcObj.ProjectId && x.CompanyId == pcObj.CompanyId);
                    return new { result };
                }
                return new { result ="Unknown Error Occured" };
            }
            catch(Exception ex)
            {
                return new { result = "" };
            }
        }
    }
}
