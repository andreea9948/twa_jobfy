﻿using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.Entities;

public class User : BaseEntity
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public UserRoleEnum Role { get; set; } = default!;
    public string City { get; set; } = default!;
    public string Phone { get; set; } = default!;
    public ICollection<UserFile> UserFiles { get; set; } = default!;
    public ICollection<Job> Jobs { get; set; } = default!;
    public ICollection<Application> Applications { get; set; } = default!;

}
