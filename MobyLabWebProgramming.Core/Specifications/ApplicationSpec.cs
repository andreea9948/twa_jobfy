using MobyLabWebProgramming.Core.Entities;
using Ardalis.Specification;

namespace MobyLabWebProgramming.Core.Specifications;

public sealed class ApplicationSpec : BaseSpec<ApplicationSpec, Application>
{
    public ApplicationSpec(Guid id) : base(id)
    {
    }

    public ApplicationSpec(string education)
    {
        Query.Where(e => e.Education == education);
    }
}