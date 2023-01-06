using Dapper;
using JobOpening.Interfaces;
using JobOpening.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace JobOpening.Repository
{
    public class JobOpeningRepository : IJobOpening
    {
        private readonly IConfiguration _configuration;
        private readonly DapperContext _dapperContext;

        public JobOpeningRepository(IConfiguration configuration,
            DapperContext dapperContext)
        {
            _configuration = configuration;
            _dapperContext = dapperContext;
        }

        public async Task<CommonResponse> InsertJobDetails(JobDetails lstJobDetails)
        {
            try
            {
                DateTime postedDate = DateTime.UtcNow;
                var query = "SELECT count(*) FROM JobOpening";
                using (var connection = _dapperContext.CreateConnection())
                {
                    var parameters = await connection.QueryAsync<int>(query);
                    int job_code = Convert.ToInt32(parameters.FirstOrDefault()) + 1;

                    string code = "JOB-" + job_code;

                    string sp_Insert = "dbo.USP_INSERT_JOBSDETAILS";
                    var queryParameters = new { lstJobDetails.Title, lstJobDetails.Description, lstJobDetails.LocationID, lstJobDetails.DepartmentID, lstJobDetails.ClosingDate, postedDate , code};
                    connection.Execute(sp_Insert, queryParameters, commandType: CommandType.StoredProcedure);
                }

                CommonResponse objResponse = new CommonResponse();
                objResponse.Success = true;
                objResponse.Message = "success";

           
                return objResponse;
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }


        public async Task<CommonResponse> UpdateJobDetails(int Id, JobDetails lstJobDetails)
        {
            try
            {
                using (var connection = _dapperContext.CreateConnection())
                {
                    string sp_Update = "dbo.USP_UPDATE_JOBSDETAILS";
                    var parameters = new {Id, lstJobDetails.Title, lstJobDetails.Description, lstJobDetails.LocationID, lstJobDetails.DepartmentID, lstJobDetails.ClosingDate };
                    connection.Execute(sp_Update, parameters, commandType: CommandType.StoredProcedure);
                }

                CommonResponse objResponse = new CommonResponse();
                objResponse.Success = true;
                objResponse.Message = "success";


                return objResponse;
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }


          public async Task<JobDetails> JobDetailsList(int Id)
          {
                try
                {

                    var query = "SELECT * FROM JobOpening WHERE Id =" + "'" + Id + "'";
                    using (var connection = _dapperContext.CreateConnection())
                    {
                    var parameters = await connection.QueryFirstOrDefaultAsync<JobDetails>(query); // job = parameters;
                    return parameters;
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception(exp.Message, exp);
                }
          }


        public async Task<JobDetailsModel> GetJobDetails(GetAllDetails pagination)
        {
            try
            {
               

                var query = "select j.Id, code, Title,l.location,d.department,PostedDate,ClosingDate from JOBOPENING j join location l on j.locationId = l.Id join Department d on j.departmentId = d.Id" ;
                using (var connection = _dapperContext.CreateConnection())
                {
                    var validFilter = new GetAllDetails(pagination.PageNumber, pagination.PageSize);
                    var parameters = await connection.QueryAsync<Job>(query);
                    var pagedData =  parameters.ToList()
                    .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                    .Take(validFilter.PageSize).ToList();

                    JobDetailsModel detailsModel = new JobDetailsModel();
                    detailsModel.total = parameters.Count();
                    detailsModel.data = pagedData;

                    return detailsModel;
                }

            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }


        public async Task<CommonResponse> InsertLocation(LocationModel location)
        {
            try
            {
                using (var connection = _dapperContext.CreateConnection())
                {
                    string sp_Insert = "dbo.USP_INSERT_LOCATION";
                    var parameters = new { location.Location };
                    connection.Execute(sp_Insert, parameters, commandType: CommandType.StoredProcedure);
                }

                CommonResponse objResponse = new CommonResponse();
                objResponse.Success = true;
                objResponse.Message = "success";


                return objResponse;
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }



        public async Task<CommonResponse> UpdateLocation(int Id, LocationModel location)
        {
            try
            {
                using (var connection = _dapperContext.CreateConnection())
                {
                    string sp_Update = "dbo.USP_UPDATE_LOCATION";
                    var parameters = new { Id, location.Location };
                    connection.Execute(sp_Update, parameters, commandType: CommandType.StoredProcedure);
                }

                CommonResponse objResponse = new CommonResponse();
                objResponse.Success = true;
                objResponse.Message = "success";

                return objResponse;
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }


        public async Task<List<LocationModel>> GetLocation()
        {
            try
            {
                JobDetails job = new JobDetails();

                var query = "SELECT * FROM Location";
                using (var connection = _dapperContext.CreateConnection())
                {

                    var parameters = await connection.QueryAsync<LocationModel>(query);
                    return (List<LocationModel>)parameters;

                }

            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }


        public async Task<CommonResponse> InsertDepartment(DepartmentModel department)
        {
            try
            {
                using (var connection = _dapperContext.CreateConnection())
                {
                    string sp_Insert = "dbo.USP_INSERT_DEPARTMENT";
                    var parameters = new { department.Department };
                    connection.Execute(sp_Insert, parameters, commandType: CommandType.StoredProcedure);
                }

                CommonResponse objResponse = new CommonResponse();
                objResponse.Success = true;
                objResponse.Message = "success";


                return objResponse;
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }



        public async Task<CommonResponse> UpdateDepartment(int Id, DepartmentModel department)
        {
            try
            {
                using (var connection = _dapperContext.CreateConnection())
                {
                    string sp_Update = "dbo.USP_UPDATE_DEPARTMENT";
                    var parameters = new { Id, department.Department };
                    connection.Execute(sp_Update, parameters, commandType: CommandType.StoredProcedure);
                }

                CommonResponse objResponse = new CommonResponse();
                objResponse.Success = true;
                objResponse.Message = "success";


                return objResponse;
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        public async Task<List<DepartmentModel>> GetDepartment()
        {
            try
            {
                JobDetails job = new JobDetails();

                var query = "SELECT * FROM Department";
                using (var connection = _dapperContext.CreateConnection())
                {

                    var parameters = await connection.QueryAsync<DepartmentModel>(query);
                    return (List<DepartmentModel>)parameters;

                }


            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }


    }
}