using JobPortal.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Services
{
    public interface IJobsService
    {
        Task<JobsDTO> GetJobList(JobsDTO dto);
        Task<TblJob> GetJobDetails(int jobID);
        Task Create(JobsDTO dto);
        Task Update(int jobId, JobsDTO dto);
    }
    public class JobsService : IJobsService
    {

        private JobsContext _db;
        public JobsService(JobsContext db)
        {
            _db = db;
        }

        public async Task<JobsDTO> GetJobList(JobsDTO dto)
        {
            try
            {

                var jobList = await _db.TblJobs.Include(x => x.Department).Where(x => x.DepartmentId == dto.DepartmentId && x.LocationId == dto.LocationId).Select(x => new JobsDTO
                {
                    Department = x.Department.Department,
                    LocationTitle = x.Location.Title,
                    Title = x.Title,
                    ClosingDate = x.ClosingDate,
                    PostedDate = x.PostedDate,
                }).ToListAsync(); ;


                return new JobsDTO
                {
                    Total = jobList.Count(),
                    JobList = jobList.OrderBy(x => x.Title).Skip((dto.PageNo - 1) * dto.PageSize).Take(dto.PageSize).ToList()

                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




        public async Task Create(JobsDTO dto)
        {
            try
            {
                Random rd = new Random();
                var date = DateTime.UtcNow;
                TblJob jb = new TblJob
                {
                    Title = dto.Title,
                    Code = "JOB-" + rd.Next(1, 100).ToString(),
                    DepartmentId = dto.DepartmentId,
                    LocationId = dto.LocationId,
                    PostedDate = date,
                    ClosingDate = dto.ClosingDate,
                    Description = dto.Description,

                };
                _db.TblJobs.Add(jb);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Update(int jobId, JobsDTO dto)
        {
            try
            {
                var existingJob = await _db.TblJobs.FirstOrDefaultAsync(x => x.JobId == jobId);
                var date = DateTime.UtcNow;

                if (existingJob != null)
                {
                    existingJob.JobId = jobId;
                    existingJob.DepartmentId = dto.DepartmentId;
                    existingJob.Title = dto.Title;
                    existingJob.Description = dto.Description;
                    existingJob.PostedDate = date;
                    existingJob.ClosingDate = dto.ClosingDate;

                }

                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TblJob> GetJobDetails(int jobID)
        {
            try
            {


                TblJob job = await _db.TblJobs.Include(x => x.Department).Include(x => x.Location).Where(x => x.JobId == jobID).FirstOrDefaultAsync();


                return job;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}