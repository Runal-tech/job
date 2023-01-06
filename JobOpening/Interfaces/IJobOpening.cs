using JobOpening.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobOpening.Interfaces
{
    public interface IJobOpening
    {
        Task<CommonResponse> InsertJobDetails(JobDetails lstJobDetails);
        Task<CommonResponse> UpdateJobDetails(int Id, JobDetails lstJobDetails);

        Task<JobDetails> JobDetailsList(int Id);

        Task<JobDetailsModel> GetJobDetails(GetAllDetails pagination);

        Task<CommonResponse> InsertLocation(LocationModel location);

        Task<CommonResponse> UpdateLocation(int Id, LocationModel location);

        Task<List<LocationModel>> GetLocation();

        Task<CommonResponse> InsertDepartment(DepartmentModel department);

        Task<CommonResponse> UpdateDepartment(int Id, DepartmentModel department);

        Task<List<DepartmentModel>> GetDepartment();

        //Task<CommonResponse> Jobs(List<JobOpeningModel> lstJobDtlsUpd, int ID);
        //Task<List<JobDetailsModel>> GetAllJobDtls(JobParaModel jobDtls);
    }
}
