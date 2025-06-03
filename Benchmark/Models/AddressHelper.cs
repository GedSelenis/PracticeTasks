using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark.Models
{
    public class AddressHelper
    {
        string GetAddressByNameSubstring(Dictionary<string, string> addressDict, string nameSubstring)
        {
            var address = addressDict.FirstOrDefault(x => x.Key.Contains(nameSubstring, StringComparison.OrdinalIgnoreCase)).Value;
            return address ?? "Address not found";
        }

        [Benchmark]
        public void RunBenchmark()
        {
            var addressDictionary = new Dictionary<string, string>
            {
                ["John Doe"] = "123 Main St, Springfield, IL",
                ["Jane Smith"] = "456 Elm St, Springfield, IL",
                ["George Gray"] = "606 Cherry St, Springfield, IL",
                ["Hannah Purple"] = "707 Ash St, Springfield, IL"
            };
            string nameSubstring = "John";
            string address = GetAddressByNameSubstring(addressDictionary, nameSubstring);
            Console.WriteLine(address);
        }
    }
}
