using System.Collections.Generic;

namespace JIPP_Projekt_Sem4.Models;

public class UserGroup
{
    public required int Id { get; init; }
    public required string Username { get; set; }
    public List<User> Users { get; } = [];
}