using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class ApplicationAddDTO
{
    public string Education { get; set; } = default!;
    public string WorkExperience { get; set; } = default!;
    public string Projects { get; set; } = default!;
    public string Skills { get; set; } = default!;
    public Guid JobId { get; set; } = default!;
    public Guid UserId { get; set; } = default!;

}
