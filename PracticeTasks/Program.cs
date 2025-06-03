using PracticeTasks.Extensions;
using PracticeTasks.Models;
using BenchmarkDotNet.Attributes;

// Task 1
Dictionary<string,string> addressDictionary = new Dictionary<string, string>()
{
    ["John Smith"] = "123 Main St, Springfield, IL",
    ["Jane Doe"] = "456 Elm St, Springfield, IL",
    ["Alice Johnson"] = "789 Oak St, Springfield, IL",
    ["Bob Brown"] = "101 Pine St, Springfield, IL",
    ["Charlie White"] = "202 Maple St, Springfield, IL",
    ["Diana Green"] = "303 Cedar St, Springfield, IL",
    ["Ethan Blue"] = "404 Birch St, Springfield, IL",
    ["Fiona Black"] = "505 Walnut St, Springfield, IL",
    ["George Gray"] = "606 Cherry St, Springfield, IL",
    ["Hannah Purple"] = "707 Ash St, Springfield, IL"
};

string name = "John";

var address = GetAddressByNameSubstring(addressDictionary, name);
Console.WriteLine(address);


// Task 2

var minValue1 = new[] { 5, 3, 8, 1, 4 }.CustomMin();
Console.WriteLine($"Minimum value: {minValue1}");

// Task 3
Console.WriteLine($"Fibanochi value: {FindFibanochi(6)}");

// Task 5

List<int> minValue2 = new[] { 5, 3, 8, 1, 4, 3, 7, 9 }.CustomMin(3);
foreach (var minValue in minValue2)
{
    Console.WriteLine(minValue);
}

// Task 6

A a = new A();
A b = new B();

a.Do(); // Output: A
b.Do(); // Output: A

// Task 7

IEnumerable<int> list = new List<int> { 15, 1, 2, 10, 19 };
var value = list.First(el => el > 10);
//if (filteredList.Any()){
//    var value = filteredList.First();
//}

// Task 8

var dict = new Dictionary<int, string> { { 1,"1"}, { 3,"3"} };
dict.TryGetValue(2, out string el);//dict.Where(k => k.Key == 2).Select(p => p.Value).FirstOrDefault();

Console.WriteLine(el ?? "Element not found");







[Benchmark]
string GetAddressByNameSubstring(Dictionary<string, string> addressDict, string nameSubstring)
{
    var address = addressDict.FirstOrDefault(x => x.Key.Contains(nameSubstring, StringComparison.OrdinalIgnoreCase)).Value;
    return address ?? "Address not found";
}

int FindFibanochi(int n)
{
    List<int> FibSeqance = new List<int>();
    Enumerable.Range(0, n)
        .ToList()
        .ForEach(index => FibSeqance.Add((index == 0 ? 0 : index ==1 ? 1 : FibSeqance[index - 2] + FibSeqance[index - 1])));
    return FibSeqance[n-1];
}
