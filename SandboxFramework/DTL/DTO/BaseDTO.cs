using System;
using CsvHelper.Configuration.Attributes;

namespace DTL.DTO
{
    public class BaseDTO
    {
        [Ignore] public string DataRow { get; set; }
        [Ignore] public Guid DailyJobGuid { get; set; }
    }
}