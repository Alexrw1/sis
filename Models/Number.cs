using System;
using System.Collections.Generic;

namespace OAUTHandJWT.Models;

public partial class Number
{
    public int IdNumber { get; set; }

    public int Number1 { get; set; }

    public string StatusNumber { get; set; } = null!;

    public decimal? PriceNumber { get; set; }

    public int ClassNumberId { get; set; }

    public int TypeNumberId { get; set; }


}
