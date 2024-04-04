using System;
using System.Collections.Generic;

namespace OAUTHandJWT.Models;

public partial class Staff
{
    public int IdStaff { get; set; }

    public string SurnameStaff { get; set; } = null!;

    public string NameStaff { get; set; } = null!;

    public string? MiddlenameStaff { get; set; }

    public string SerialPassStaff { get; set; } = null!;

    public string NumPassStaff { get; set; } = null!;

    public string LoginStaff { get; set; } = null!;

    public string PasswordStaff { get; set; } = null!;

    public string Salt { get; set; } = null!;

}
