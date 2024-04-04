using System;
using System.Collections.Generic;

namespace OAUTHandJWT.Models;

public partial class Order
{
    public int IdOrder { get; set; }

    public string StatusOrder { get; set; } = null!;

    public int ProductId { get; set; }

    public int NumberId { get; set; }


}
