using System;
using System.Collections.Generic;

namespace OAUTHandJWT.Models;

public partial class Check
{
    public int IdCheck { get; set; }

    public string NumberCheck { get; set; } = null!;

    public DateTime? DateTimeCheck { get; set; }

    public int ScoreId { get; set; }

}
