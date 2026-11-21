#nullable enable
using BlazorApp.Application.Common.Interfaces;
using BlazorApp.Application.Common.Interfaces.Services;
using BlazorApp.Web.Data.Models;
using MongoDB.Driver;

namespace BlazorApp.Application.Services
{
    public class RespondentsService : IRespondentsService
    {
        private readonly IApplicationDbContext _context;

        public RespondentsService(IApplicationDbContext context)
        {
            _context = context;
        }

        public List<Respondents> Get()
        {
            return _context.Respondents.Find(FilterDefinition<Respondents>.Empty).ToList();
        }

        public Respondents? Get(string id)
        {
            return _context.Respondents.Find(x => x._id == id).FirstOrDefault();
        }

        public Respondents Create(Respondents respondents)
        {
            _context.Respondents.InsertOne(respondents);
            return respondents;
        }

        public void Update(string id, Respondents updatedRespondents)
        {
            _context.Respondents.ReplaceOne(x => x._id == id, updatedRespondents);
        }

        public void Delete(Respondents respondentsForDeletion)
        {
            if (respondentsForDeletion._id != null)
            {
                Delete(respondentsForDeletion._id);
            }
        }

        public void Delete(string id)
        {
            _context.Respondents.DeleteOne(x => x._id == id);
        }
    }
}

