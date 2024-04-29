using Entities.DTOs;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.DialSheetService
{
    public interface IDialSheetService
    {
        public object CreateDialSheet(DialSheet dialsheet);
        public object AddCompanyToDialSheet(CompanyToDialSheet companiestodialsheet);
        public object RemoveCompanyFromDialSheet(CompanyToDialSheet companiestodialsheet);

        public DialSheet GetDialSheetByProjectId(int projectId);
        public List<Company> GetDialSheetCompaniesByProjectId(int projectId);
        public List<User> GetDialSheetAgentsByProjectId(int projectId);
        public object AddAgentToDialSheet(AgentToDialSheet agentToDialSheet);
        public object RemoveAgentFromDialSheet(AgentToDialSheet agentToDialSheet);
        public List<object> GetDialSheetsList();
        public object GetProjectDialSheetByProjectId(int projectId);
        public object UpdateCallSheetDetails(CallHistory callHistory);
        public object GetCallSheetDetails(ProjectIdCompanyId pcObj);

    }
}
