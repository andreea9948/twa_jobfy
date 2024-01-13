using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.Entities;

public class Application : BaseEntity
{
    public string Education { get; set; } = default!;
    public string WorkExperience { get; set; } = default!;
    public string Projects { get; set; } = default!;
    public string Skills { get; set; } = default!;
    public Guid JobId { get; set; } = default!;
    public Job Job { get; set; } = default!;
    public Guid UserId { get; set; } = default!;
    public User User { get; set; } = default!;
}
