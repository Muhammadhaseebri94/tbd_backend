using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.QueryService
{
    public interface IQueryService
    {
        public string CreateQuery(Query query);
        public object UpdateQuery(Query query);
        public List<Query> GetQueriesByProjectCompanyId(int ProjectId,int CompanyId);
    }
}
