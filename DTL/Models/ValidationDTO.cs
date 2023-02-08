using DTL.Entities;

namespace DTL.Models;

public class ValidationDTO
{
    public DailyJobEntity DailyJobEntity { get; set; } = new DailyJobEntity();
    public bool ValidationSucceeded { get; set; }
}