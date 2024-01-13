using System.Linq.Expressions;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;
using MobyLabWebProgramming.Core.Requests;

namespace MobyLabWebProgramming.Core.Specifications;

public sealed class JobProjectionSpec : BaseSpec<JobProjectionSpec, Job, JobDTO>
{
    protected override Expression<Func<Job, JobDTO>> Spec => e => new()
    {
        Id = e.Id,
        JobName = e.JobName,
        JobType = e.JobType,
        StudyLevel = e.StudyLevel,
        CareerLevel = e.CareerLevel,
        Industry = e.Industry,
        Requirements = e.Requirements,
        Responsibilities = e.Responsibilities,
        Offerings = e.Offerings
    };

    public JobProjectionSpec(bool orderByCreatedAt = true) : base(orderByCreatedAt)
    {
    }

    public JobProjectionSpec(Guid id) : base(id)
    {
    }

    public JobProjectionSpec(JobSearchQueryParams query)
    {

        if (query == null)
            return;

        if (!string.IsNullOrEmpty(query.JobWord))
        {
            var searchExpr = $"%{query.JobWord.Replace(" ", "%")}%";
            Query.Where(e => EF.Functions.ILike(e.JobName, searchExpr));
        }

        if (query.JobType != default)
        {
            Query.Where(e => e.JobType == query.JobType);
        }

        if (query.StudyLevel != default)
        {
            Query.Where(e => e.StudyLevel == query.StudyLevel);
        }

        if (query.CareerLevel != default)
        {
            Query.Where(e => e.CareerLevel == query.CareerLevel);
        }

        if (query.Industry != default)
        {
            Query.Where(e => e.Industry == query.Industry);
        }

    }
}
