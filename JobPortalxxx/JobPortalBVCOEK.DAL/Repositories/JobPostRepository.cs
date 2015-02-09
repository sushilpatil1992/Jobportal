using System.Collections.Generic;
using System.Linq;

namespace JobPortalBVCOEK.DAL.Repositories
{
    public class JobPostRepository :  IBaseRepository<Jobpost>
    {
        private JobPortalDB _context;
        public JobPostRepository(JobPortalDB context)
        {
            _context = context;
        }
        public void Add(Jobpost value)
        {
            _context.Jobposts.Add(value);
        }

        public void Update(Jobpost value)
        {
            
        }

        public void Delete(Jobpost value)
        {
            _context.Jobposts.Remove(value);
        }

        public Jobpost GetById(long id)
        {
            return _context.Jobposts.FirstOrDefault(j => j.Id == id);
        }

        public IEnumerable<Jobpost> GetAll()
        {
            return _context.Jobposts.ToList();
        }
    }
}
