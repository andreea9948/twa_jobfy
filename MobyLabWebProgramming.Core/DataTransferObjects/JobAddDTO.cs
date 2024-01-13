using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class JobAddDTO
{
    public string JobName { get; set; } = default!;
    public JobTypeEnum JobType { get; set; } = default!;
    public StudyLevelEnum StudyLevel { get; set; } = default!;
    public CareerLevelEnum CareerLevel { get; set; } = default!;
    public string Industry { get; set; } = default!;
    public string Requirements { get; set; } = default!;
    public string Responsibilities { get; set; } = default!;
    public string Offerings { get; set; } = default!;
}
