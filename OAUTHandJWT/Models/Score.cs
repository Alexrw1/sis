using System;
using System.Collections.Generic;

namespace OAUTHandJWT.Models;

public partial class Score
{
    public int IdScore { get; set; }

    public decimal? MoneyScore { get; set; }

    public int ServiceId { get; set; }

    public string StatusScore { get; set; } = null!;

    public int? StaffId { get; set; }

    public int NumberClientId { get; set; }

}
