using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.DataTransferObjects;

public record ApplicationUpdateDTO(Guid Id, string? Education = default, string? WorkExperience = default, string? Projects = default, string? Skills = default);
