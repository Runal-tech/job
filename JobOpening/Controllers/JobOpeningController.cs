using JobOpening.Interfaces;
using JobOpening.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobOpening.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobOpeningController : ControllerBase
    {
        private readonly IJobOpening _jobOpeningQueryRepository;
        public JobOpeningController(IJobOpening JobOpeningQueryRepository)
        {
            _jobOpeningQueryRepository = JobOpeningQueryRepository;
        }


        [HttpPost]
        [Route("InsertJobDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> InsertJobDetails(JobDetails lstJobDetails)
        {

            var data = await _jobOpeningQueryRepository.InsertJobDetails(lstJobDetails);
            return Ok(data);
        }

        [HttpPut]
        [Route("UpdateJobDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateJobDetails(int Id , JobDetails lstJobDetails)
        {

            var data = _jobOpeningQueryRepository.UpdateJobDetails(Id , lstJobDetails);
            return Ok(data);
        }


        [HttpGet]
        [Route("JobDetailsList")]
        public async Task<IActionResult> JobDetailsList(int Id)
        {

            var data = await _jobOpeningQueryRepository.JobDetailsList(Id);
            return Ok(data);
        }


        [HttpGet]
        [Route("GetJobDetails")]
        public async Task<IActionResult> GetJobDetails([FromQuery] GetAllDetails pagination)
        {

            var data = await _jobOpeningQueryRepository.GetJobDetails(pagination);
            return Ok(data);
        }


        [HttpPost]
        [Route("InsertLocation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> InsertLocation(LocationModel location)
        {

            var data = _jobOpeningQueryRepository.InsertLocation(location);
            return Ok(data);
        }

        [HttpPut]
        [Route("UpdateLocation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateLocation(int Id, LocationModel location)
        {

            var data = _jobOpeningQueryRepository.UpdateLocation(Id, location);
            return Ok(data);
        }


        [HttpGet]
        [Route("GetLocation")]
        /*[ProducesResponseType(StatusCodes.Status200OK)]*/
        public async Task<IActionResult> GetLocation()
        {

            var data = await _jobOpeningQueryRepository.GetLocation();
            return Ok(data);
        }


        [HttpPost]
        [Route("InsertDepartment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> InsertDepartment(DepartmentModel department)
        {

            var data = _jobOpeningQueryRepository.InsertDepartment(department);
            return Ok(data);
        }


        [HttpPut]
        [Route("UpdateDepartment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateDepartment(int Id, DepartmentModel department)
        {

            var data = _jobOpeningQueryRepository.UpdateDepartment(Id, department);
            return Ok(data);
        }



        [HttpGet]
        [Route("GetDepartment")]
        /*[ProducesResponseType(StatusCodes.Status200OK)]*/
        public async Task<IActionResult> GetDepartment()
        {

            var data = await _jobOpeningQueryRepository.GetDepartment();
            return Ok(data);
        }



    }
}
