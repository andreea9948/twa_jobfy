using Ardalis.SmartEnum;
using Ardalis.SmartEnum.SystemTextJson;
using System.Text.Json.Serialization;

namespace MobyLabWebProgramming.Core.Enums;

[JsonConverter(typeof(SmartEnumNameConverter<UserRoleEnum, string>))]
public sealed class UserRoleEnum : SmartEnum<UserRoleEnum, string>
{
    public static readonly UserRoleEnum Admin = new(nameof(Admin), "Admin");
    public static readonly UserRoleEnum Employer = new(nameof(Employer), "Employer");
    public static readonly UserRoleEnum Applicant = new(nameof(Applicant), "Applicant");

    private UserRoleEnum(string name, string value) : base(name, value)
    {
    }
}
