using System;
using System.Collections.Generic;

namespace JIPP_Projekt_Sem4.Models;

public class User
{
    public required int Id { get; init; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public DateTime? Birthday { get; set; }
    public List<UserGroup> Groups { get; } = [];
    
    public Cryptocurrency? Cryptocurrency { get; set; }
    public override string ToString() => Username;

}