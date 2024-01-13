using MobyLabWebProgramming.Core.Entities;
using Ardalis.Specification;

namespace MobyLabWebProgramming.Core.Specifications;

public sealed class JobSpec : BaseSpec<JobSpec, Job>
{
    public JobSpec(Guid id) : base(id)
    {
    }

    public JobSpec(string name)
    {
        Query.Where(e => e.JobName == name);
    }
}