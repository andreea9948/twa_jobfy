using Ardalis.SmartEnum;
using Ardalis.SmartEnum.SystemTextJson;
using System.Security;
using System.Text.Json.Serialization;

namespace MobyLabWebProgramming.Core.Enums;

[JsonConverter(typeof(SmartEnumNameConverter<StudyLevelEnum, string>))]
public sealed class StudyLevelEnum : SmartEnum<StudyLevelEnum, string>
{
    public static readonly StudyLevelEnum Qualified = new(nameof(Qualified), "Qualified");
    public static readonly StudyLevelEnum Unqualified = new(nameof(Unqualified), "Unqualified");
    public static readonly StudyLevelEnum Student = new(nameof(Student), "Student");
    public static readonly StudyLevelEnum Graduate = new(nameof(Graduate), "Graduate");

    private StudyLevelEnum(string name, string value) : base(name, value)
    {
    }
}
