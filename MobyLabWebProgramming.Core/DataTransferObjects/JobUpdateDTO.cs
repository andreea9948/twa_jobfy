using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.DataTransferObjects;

public record JobUpdateDTO(Guid Id, string? JobName = default, JobTypeEnum? JobType = default, StudyLevelEnum? StudyLevel = default, CareerLevelEnum? CareerLevel = default, string? Industry = default, string? Requirements = default, string? Responsibilities = default, string? Offerings = default);
