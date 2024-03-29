using System;
using System.Collections.Generic;

namespace OAUTHandJWT.Models;

public partial class Client
{
    public int IdClient { get; set; }

    public string SurnameClient { get; set; } = null!;

    public string NameClient { get; set; } = null!;

    public string? MiddlenameClient { get; set; }

    public string SerialPassClient { get; set; } = null!;

    public string NumPassClient { get; set; } = null!;

    public string LoginClient { get; set; } = null!;

    public string PasswordClient { get; set; } = null!;

    public string Salt { get; set; } = null!;

}
