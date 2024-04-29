using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.StaticDataService
{
    public interface ISDService
    {
        public List<ProjectType> GetAllProjectTypes();
        public List<CallStatus> GetAllCallStatuses();
    }
}
