using System;
using System.Collections.Generic;

namespace OAUTHandJWT.Models;

public partial class Position
{
    public int IdPosition { get; set; }

    public string NamePosition { get; set; } = null!;

    public int StaffId { get; set; }

}
