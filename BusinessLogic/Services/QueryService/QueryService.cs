using Data_Access.Context;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.QueryService
{
    public class QueryService : IQueryService
    {
        private readonly ApplicationDbContext _context;
        public QueryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public string CreateQuery(Query query)
        {
            try
            {
                if (query != null)
                {
                    _context.Queries.Add(query);
                    _context.SaveChanges();
                    return "Query Added Successfully";
                }
                return "Failure";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public List<Query> GetQueriesByProjectCompanyId(int ProjectId, int CompanyId)
        {
            try
            {
                List<Query> querieslist = new List<Query>();
                if (ProjectId != null && CompanyId != null)
                {
                    querieslist = _context.Queries.Where(x => x.ProjectId == ProjectId && x.CompanyId == CompanyId).ToList();
                    if (querieslist.Any())
                    {
                        return querieslist;
                    }
                    return querieslist;
                }
                return querieslist;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public object UpdateQuery(Query query)
        {
            try
            {
                if (query != null)
                {
                    _context.Queries.Update(query);
                    _context.SaveChanges();
                    Query queryobj = _context.Queries.FirstOrDefault(x => x.Id == query.Id);
                    return new { result = "Query updated successfully", queryobj };
                }
                return "Failure";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
