using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.Requests;

public class JobSearchQueryParams
{
    public string JobWord { get; set; } = default!;
    public JobTypeEnum JobType { get; set; } = default!;
    public StudyLevelEnum StudyLevel { get; set; } = default!;
    public CareerLevelEnum CareerLevel { get; set; } = default!;
    public string Industry { get; set; } = default!;
}
