using System;
using System.Collections.Generic;

namespace OAUTHandJWT.Models;

public partial class Product
{
    public int IdProduct { get; set; }

    public string NameProduct { get; set; } = null!;

    public decimal? PriceProduct { get; set; }

    public int CategoryProductId { get; set; }

}
