using System;
using System.Collections.Generic;

namespace OAUTHandJWT.Models;

public partial class Service
{
    public int IdService { get; set; }

    public string NameService { get; set; } = null!;

    public decimal? PriceService { get; set; }

    public string DescriptionService { get; set; } = null!;

    public int TypeServiceId { get; set; }


}
