using System.Net;
using MobyLabWebProgramming.Core.Constants;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;
using MobyLabWebProgramming.Core.Enums;
using MobyLabWebProgramming.Core.Errors;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;
using MobyLabWebProgramming.Core.Specifications;
using MobyLabWebProgramming.Infrastructure.Database;
using MobyLabWebProgramming.Infrastructure.Repositories.Interfaces;
using MobyLabWebProgramming.Infrastructure.Services.Interfaces;

namespace MobyLabWebProgramming.Infrastructure.Services.Implementations;

public class JobService : IJobService
{
    private readonly IRepository<WebAppDatabaseContext> _repository;
    private readonly ILoginService _loginService;

    public JobService(IRepository<WebAppDatabaseContext> repository, ILoginService loginService)
    {
        _repository = repository;
        _loginService = loginService;
    }

    public async Task<ServiceResponse<JobDTO>> GetJob(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAsync(new JobProjectionSpec(id), cancellationToken); 

        return result != null ?
            ServiceResponse<JobDTO>.ForSuccess(result) :
            ServiceResponse<JobDTO>.FromError(CommonErrors.JobNotFound);
    }

    public async Task<ServiceResponse<List<JobDTO>>> GetJobs(JobSearchQueryParams query, CancellationToken cancellationToken = default)
    {
        var result = await _repository.ListAsync(new JobProjectionSpec(query), cancellationToken);

        return ServiceResponse<List<JobDTO>>.ForSuccess(result);
    }

    public async Task<ServiceResponse<int>> GetJobCount(CancellationToken cancellationToken = default) =>
        ServiceResponse<int>.ForSuccess(await _repository.GetCountAsync<Job>(cancellationToken)); 

    public async Task<ServiceResponse> AddJob(JobAddDTO job, UserDTO? requestingUser, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAsync(new JobSpec(job.JobName), cancellationToken);

        if (result != null)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Conflict, "The Job already exists!", ErrorCodes.JobAlreadyExists));
        }

        await _repository.AddAsync(new Job
        {
            JobName = job.JobName,
            JobType = job.JobType,
            StudyLevel = job.StudyLevel,
            CareerLevel = job.CareerLevel,
            Industry = job.Industry,
            Requirements = job.Requirements,
            Responsibilities = job.Responsibilities,
            Offerings = job.Offerings
        }, cancellationToken); 


        return ServiceResponse.ForSuccess();
    }

    public async Task<ServiceResponse> UpdateJob(JobUpdateDTO Job, UserDTO? requestingUser, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetAsync(new JobSpec(Job.Id), cancellationToken);

        if (entity != null) 
        {
            entity.JobName = Job.JobName ?? entity.JobName;
            entity.JobType = Job.JobType ?? entity.JobType;
            entity.StudyLevel = Job.StudyLevel ?? entity.StudyLevel;
            entity.CareerLevel = Job.CareerLevel ?? entity.CareerLevel;
            entity.Industry = Job.Industry ?? entity.Industry;
            entity.Requirements = Job.Requirements ?? entity.Requirements;
            entity.Responsibilities = Job.Responsibilities ?? entity.Responsibilities;
            entity.Offerings = Job.Offerings ?? entity.Offerings;

            await _repository.UpdateAsync(entity, cancellationToken);
        }

        return ServiceResponse.ForSuccess();
    }

    public async Task<ServiceResponse> DeleteJob(Guid id, UserDTO? requestingUser = default, CancellationToken cancellationToken = default)
    {
        await _repository.DeleteAsync<Job>(id, cancellationToken); 

        return ServiceResponse.ForSuccess();
    }
}
