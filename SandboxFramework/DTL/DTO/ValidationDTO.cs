using DTL.Entities;

namespace DTL.DTO
{
    public class ValidationDTO
    {
        public DailyJobEntity DailyJobEntity { get; set; } = new DailyJobEntity();
        public bool ValidationSucceeded { get; set; }
    }
}