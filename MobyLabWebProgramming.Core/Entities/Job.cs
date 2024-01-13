using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.Entities;

public class Job : BaseEntity
{
    public string JobName { get; set; } = default!;
    public JobTypeEnum JobType { get; set; } = default!;
    public StudyLevelEnum StudyLevel { get; set; } = default!;
    public CareerLevelEnum CareerLevel { get; set; } = default!;
    public string Industry { get; set; } = default!;
    public string Requirements { get; set; } = default!;
    public string Responsibilities { get; set; } = default!;
    public string Offerings { get; set; } = default!;
    public Guid UserId { get; set; } = default!;
    public User User { get; set; } = default!;
    public ICollection<Application> Applications { get; set; } = default!;
}
