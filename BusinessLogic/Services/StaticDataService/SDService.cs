using Data_Access.Context;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.StaticDataService
{
    public class SDService : ISDService
    {
        private readonly ApplicationDbContext _context;
        public SDService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<CallStatus> GetAllCallStatuses()
        {
            var result = _context.CallStatuses.ToList();
            return result;
        }
        public List<ProjectType> GetAllProjectTypes()
        {
            var result=_context.ProjectTypes.ToList();
            return result;
        }
    }
}
