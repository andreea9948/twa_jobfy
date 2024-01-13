using Ardalis.SmartEnum;
using Ardalis.SmartEnum.SystemTextJson;
using System.Security;
using System.Text.Json.Serialization;

namespace MobyLabWebProgramming.Core.Enums;

[JsonConverter(typeof(SmartEnumNameConverter<JobTypeEnum, string>))]
public sealed class JobTypeEnum : SmartEnum<JobTypeEnum, string>
{
    public static readonly JobTypeEnum Full_time = new(nameof(Full_time), "Full-time");
    public static readonly JobTypeEnum Part_time = new(nameof(Part_time), "Part-time");
    public static readonly JobTypeEnum Internship = new(nameof(Internship), "Internship");

    private JobTypeEnum(string name, string value) : base(name, value)
    {
    }
}
