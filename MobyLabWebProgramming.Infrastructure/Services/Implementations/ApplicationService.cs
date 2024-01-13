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

public class ApplicationService : IApplicationService
{
    private readonly IRepository<WebAppDatabaseContext> _repository;
    private readonly ILoginService _loginService;

    public ApplicationService(IRepository<WebAppDatabaseContext> repository, ILoginService loginService)
    {
        _repository = repository;
        _loginService = loginService;
    }

    public async Task<ServiceResponse<ApplicationDTO>> GetApplication(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAsync(new ApplicationProjectionSpec(id), cancellationToken);

        return result != null ?
            ServiceResponse<ApplicationDTO>.ForSuccess(result) :
            ServiceResponse<ApplicationDTO>.FromError(CommonErrors.ApplicationNotFound);
    }

    public async Task<ServiceResponse<int>> GetApplicationCount(CancellationToken cancellationToken = default) =>
        ServiceResponse<int>.ForSuccess(await _repository.GetCountAsync<Application>(cancellationToken));

    public async Task<ServiceResponse> AddApplication(ApplicationAddDTO Application, UserDTO requestingUser, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAsync(new ApplicationSpec(Application.Education), cancellationToken);

        if (result != null)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Conflict, "The Application already exists!", ErrorCodes.ApplicationAlreadyExists));
        }

        await _repository.AddAsync(new Application
        {
            Education = Application.Education,
            WorkExperience = Application.WorkExperience,
            Projects = Application.Projects,
            Skills = Application.Skills,
            JobId = Application.JobId,
            UserId = requestingUser.Id
        }, cancellationToken);


        return ServiceResponse.ForSuccess();
    }

    public async Task<ServiceResponse> UpdateApplication(ApplicationUpdateDTO Application, UserDTO? requestingUser, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetAsync(new ApplicationSpec(Application.Id), cancellationToken);

        if (entity != null)
        {
            entity.Education = Application.Education ?? entity.Education;
            entity.WorkExperience = Application.WorkExperience ?? entity.WorkExperience;
            entity.Projects = Application.Projects ?? entity.Projects;
            entity.Skills = Application.Skills ?? entity.Skills;

            await _repository.UpdateAsync(entity, cancellationToken);
        }

        return ServiceResponse.ForSuccess();
    }

    public async Task<ServiceResponse> DeleteApplication(Guid id, UserDTO? requestingUser = default, CancellationToken cancellationToken = default)
    {
        await _repository.DeleteAsync<Application>(id, cancellationToken);

        return ServiceResponse.ForSuccess();
    }
}
