using JobPortal.Models;
using JobPortal.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Controllers
{
    [Route("/api/v1/jobs/")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private IJobsService _repo;

        public JobsController(IJobsService repo)
        {
            _repo = repo;
        }


        [HttpPost]
        [Route("/api/jobs/list")]
        public async Task<IActionResult> GetJobList(JobsDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _repo.GetJobList(dto));
        }

        [HttpGet]
        [Route("/api/v1/jobs/{id:int}")]

        public async Task<IActionResult> GetJobDetailsAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _repo.GetJobDetails(id));
        }

        [HttpPut]
        public async Task<IActionResult> Create(JobsDTO dto)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _repo.Create(dto);
                return Created("~/api/jobs/1055", dto);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("{jobId:int}")]
        public async Task<IActionResult> Update(int jobId, JobsDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _repo.Update(jobId, dto);
                return Ok();
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}
