using System;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Microsoft.Xrm.Sdk;

namespace SandboxFramework.Tools
{
    public class TypeConverters
    {
        public class StatusConverter : DefaultTypeConverter
        {
            public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
            {
                switch (text)
                {
                    case "active":
                        return new OptionSetValue(1); // 1 is often the value for "active" status
                    case "inactive":
                        return new OptionSetValue(2); // 2 is often the value for "inactive" status
                    // add other statuses as needed
                    default:
                        throw new Exception($"Invalid status: {text}");
                }
            }
        }
    }
}