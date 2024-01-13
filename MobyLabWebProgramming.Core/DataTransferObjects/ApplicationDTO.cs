using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class ApplicationDTO
{
    public Guid Id { get; set; }
    public string Education { get; set; } = default!;
    public string WorkExperience { get; set; } = default!;
    public string Projects { get; set; } = default!;
    public string Skills { get; set; } = default!;
}
