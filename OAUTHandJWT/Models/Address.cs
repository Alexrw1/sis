using System;
using System.Collections.Generic;

namespace OAUTHandJWT.Models;

public partial class Address
{
    public int IdAddress { get; set; }

    public string NumberAddress { get; set; } = null!;

    public string StatusAddress { get; set; } = null!;

    public int? StaffId { get; set; }

    public int ClientId { get; set; }


}
