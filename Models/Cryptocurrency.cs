using System;

namespace JIPP_Projekt_Sem4.Models;

public class Cryptocurrency
{
    public required int Id { get; init; }
    public required int UserId { get; set; }
    public decimal Bitcoin { get; set; }
    public decimal Ethereum { get; set; }
    public decimal Tether { get; set; }
    public decimal ZCash { get; set; }
    public User User { get; set; } = null!;
}