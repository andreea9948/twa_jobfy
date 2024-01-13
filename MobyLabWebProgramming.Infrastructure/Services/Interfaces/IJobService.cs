using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;

namespace MobyLabWebProgramming.Infrastructure.Services.Interfaces;

public interface IJobService
{
    public Task<ServiceResponse<JobDTO>> GetJob(Guid id, CancellationToken cancellationToken = default);
    public Task<ServiceResponse<List<JobDTO>>> GetJobs(JobSearchQueryParams query, CancellationToken cancellationToken = default);
    public Task<ServiceResponse<int>> GetJobCount(CancellationToken cancellationToken = default);
    public Task<ServiceResponse> AddJob(JobAddDTO Job, UserDTO? requestingUser = default, CancellationToken cancellationToken = default);
    public Task<ServiceResponse> UpdateJob(JobUpdateDTO Job, UserDTO? requestingUser = default, CancellationToken cancellationToken = default);
    public Task<ServiceResponse> DeleteJob(Guid id, UserDTO? requestingUser = default, CancellationToken cancellationToken = default);
}
