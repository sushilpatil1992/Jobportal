

using JobPortalBVCOEK.DAL;
using JobPortalBVCOEK.DAL.Repositories;
using System.Collections.Generic;
namespace JobPortalBVCOEK.BLL
{
    public class JobService
    {
        private JobPostRepository _jobPostRepository;
        public JobService(JobPostRepository jobPostRepository)
        {
            _jobPostRepository = jobPostRepository;
        }

        public IEnumerable<Jobpost> GetAllJobs()
        {
            return _jobPostRepository.GetAll();
        }
    }
}
