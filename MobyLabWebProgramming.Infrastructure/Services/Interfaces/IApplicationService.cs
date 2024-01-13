using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;

namespace MobyLabWebProgramming.Infrastructure.Services.Interfaces;

public interface IApplicationService
{
    public Task<ServiceResponse<ApplicationDTO>> GetApplication(Guid id, CancellationToken cancellationToken = default);
    public Task<ServiceResponse<int>> GetApplicationCount(CancellationToken cancellationToken = default);
    public Task<ServiceResponse> AddApplication(ApplicationAddDTO Application, UserDTO requestingUser = default, CancellationToken cancellationToken = default);
    public Task<ServiceResponse> UpdateApplication(ApplicationUpdateDTO Application, UserDTO? requestingUser = default, CancellationToken cancellationToken = default);
    public Task<ServiceResponse> DeleteApplication(Guid id, UserDTO? requestingUser = default, CancellationToken cancellationToken = default);
}
