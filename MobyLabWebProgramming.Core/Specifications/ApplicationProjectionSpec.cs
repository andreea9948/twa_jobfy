using System.Linq.Expressions;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Core.Specifications;

public sealed class ApplicationProjectionSpec : BaseSpec<ApplicationProjectionSpec, Application, ApplicationDTO>
{
    protected override Expression<Func<Application, ApplicationDTO>> Spec => e => new()
    {
        Id = e.Id,
        Education = e.Education,
        WorkExperience = e.WorkExperience,
        Projects = e.Projects,
        Skills = e.Skills,
    };

    public ApplicationProjectionSpec(bool orderByCreatedAt = true) : base(orderByCreatedAt)
    {
    }

    public ApplicationProjectionSpec(Guid id) : base(id)
    {
    }
}
