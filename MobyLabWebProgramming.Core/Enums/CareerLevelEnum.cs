using Ardalis.SmartEnum;
using Ardalis.SmartEnum.SystemTextJson;
using System.Security;
using System.Text.Json.Serialization;

namespace MobyLabWebProgramming.Core.Enums;

[JsonConverter(typeof(SmartEnumNameConverter<CareerLevelEnum, string>))]
public sealed class CareerLevelEnum : SmartEnum<CareerLevelEnum, string>
{
    public static readonly CareerLevelEnum No_experience = new(nameof(No_experience), "No_experience");
    public static readonly CareerLevelEnum Entry_level = new(nameof(Entry_level), "Entry_level");
    public static readonly CareerLevelEnum Mid_level = new(nameof(Mid_level), "Mid_level");
    public static readonly CareerLevelEnum Senior = new(nameof(Senior), "Senior");
    public static readonly CareerLevelEnum Manager = new(nameof(Manager), "Manager");

    private CareerLevelEnum(string name, string value) : base(name, value)
    {
    }
}
