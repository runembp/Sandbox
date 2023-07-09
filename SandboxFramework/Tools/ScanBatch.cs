using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SandboxFramework.Tools
{
    public static class ScanBatch
    {
        public static List<string> ScanBatchText()
        {
            const string regExPattern = @"\bnew_\w+\b";
            
            var batchFields = new HashSet<string>();
            var fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "batchtext.txt");

            var fileContents = File.ReadAllText(fullPath);
            var matches = Regex.Matches(fileContents, regExPattern);
            
            foreach (Match match in matches)
            {
                batchFields.Add(match.Value);
            }

            var unnecessaryFields = new string[]
            {
                "new_batchid",
                "new_name",
                "new_identifier",
                "new_data",
                "new_sourcefrom",
                "new_uniqueid",
                "new_processaction",
                "new_errortext",
                "statuscode",
                
                // Entity names
                "new_policy",
                "new_batchcountsummary",
                "new_dailyjob"
            };

            return batchFields.Where(x => !x.Contains("_base")).Where(x => !unnecessaryFields.Contains(x)).ToList();
        }
    }
}