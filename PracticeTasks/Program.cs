using PracticeTasks.Extensions;
using PracticeTasks.Models;
using BenchmarkDotNet.Attributes;
using System.Text;


runThis();
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

string name = "Diana";

//var address = GetAddressByNameSubstring(addressDictionary, name);
TernarySearchTreeDictionary addressTree = new TernarySearchTreeDictionary();
addressTree.Insert(addressDictionary);
Console.WriteLine(addressTree.PartialSearch(name));


// Task 2

var minValue1 = new[] { 5, 3, 8, 1, 4 }.CustomMin();
Console.WriteLine($"Minimum value: {minValue1}");

// Task 3
Console.WriteLine($"Fibanochi value: {FindFibanochi(6)}");

// Task 5

List<int> minValue2 = new[] { 5, 3, 8, 1, 4, 3, 7, 9 }.CustomMin2(3);
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




// Hash set compare parameters
//Two differnt insance of class

ClassA classA = new ClassA(1);
ClassA classB = new ClassA(2);
ClassA classC = new ClassA(1);

HashSet<ClassA> hashSet1 = new HashSet<ClassA>();
hashSet1.Add(classA);
hashSet1.Add(classB);
hashSet1.Add(classA);
Console.WriteLine($"HashSet1 (ABA) count: {hashSet1.Count}"); // Output: 2

HashSet<ClassA> hashSet2 = new HashSet<ClassA>();
hashSet2.Add(classA);
hashSet2.Add(classB);
hashSet2.Add(classC);
Console.WriteLine($"HashSet2 (ABC) count: {hashSet2.Count}"); // Output: 3


// =======

StructA structA = new StructA(1);
StructA structB = new StructA(2);
StructA structC = new StructA(1);

HashSet<StructA> hashSet3 = new HashSet<StructA>();
hashSet3.Add(structA);
hashSet3.Add(structB);
hashSet3.Add(structA);
Console.WriteLine($"HashSet3 (ABA) count: {hashSet3.Count}"); // Output: 2

HashSet<StructA> hashSet4 = new HashSet<StructA>();
hashSet4.Add(structA);
hashSet4.Add(structB);
hashSet4.Add(structC);
Console.WriteLine($"HashSet4 (ABC) count: {hashSet4.Count}"); // Output: 2
// GetHashcode and equalas and IEquitable (Dictionary or hashset)
// Benchmark process bigcollection of 1mil elements and try to et element
// How to handle case ignoring for stings as a key in dictionary



//What is struct?
// How .Map works?
//O notation of alghorithm performance
// Packing and Unpacking operations in C#


// Queue, Stack, LinkedList, List, HashSet, Dictionary, SortedDictionary,SortedSet.
// Write at beggining, at end, at random, Read element from beginning, From the end, Search operation(Except queue and stack)
[Benchmark] 
string GetAddressByNameSubstring(Dictionary<string, string> addressDict, string nameSubstring)
{
    var address = addressDict.Where(x => x.Key.Contains(nameSubstring, StringComparison.OrdinalIgnoreCase)).First().Value;
    return address ?? "Address not found";
}

int FindFibanochi(int n)
{
    List<int> FibSeqance = new List<int>(); // Agrgate function
    Enumerable.Range(0, n)
        .ToList()
        .ForEach(index => FibSeqance.Add((index == 0 ? 0 : index ==1 ? 1 : FibSeqance[index - 2] + FibSeqance[index - 1])));
    return FibSeqance[n-1];
} // Write witout using LINQ

int FindFibanochi2(int n)
{
    List<int> fibonachi = new List<int>() { 0, 1};
    for (int i = 0; i < n; i++)
    {
        fibonachi.Add(fibonachi[i] + fibonachi[i+1]);
    }
    return fibonachi[n];
}
int FindFibanochi3(int n)
{
    int first = 0;
    int second = 1;
    if (n == 0) return first;
    else if (n == 1) return second;
    for (int i = 0; i < n; i++)
    {
        int temp = first + second;
        first = second;
        second = temp;
    }
    return first;
}

int FindFibanochi4(int n)
{
    List<int> fibonachi = new List<int>() { 0, 1 };


    var fib = Enumerable.Range(0, n).Aggregate((first: 0, second: 1), (acc, n) => (acc.second, acc.first + acc.second));
    var sum = Enumerable.Range(0, n).Aggregate(0, (acc, n) => acc + n);
    var max = Enumerable.Repeat(0, n).Aggregate(default(int?), (acc, n) => acc.HasValue ? Math.Max(acc.Value, n) : n);

    var gList = new List<string> { "apple", "banana", "cherry" };

    var concatenated = gList.Aggregate(new StringBuilder(), 
        (current, next) => (current.Length > 0 ? current.Append(","): current).Append(next));

    Enumerable.Range(0, n)
        .ToList()
        .ForEach(index => { fibonachi.Add(fibonachi.Aggregate((a, b) => a + b)); fibonachi.RemoveAt(0); });
    return fibonachi[0];
}

void runThis()
{

    var list = new List<int> { 1, 2, 4, 5, 6, 7, 8, 9 };

    var items = list.Where(x => x > 5).Where(s => s % 2 == 1).Select(x => PrintValues(x)).ToList();
    Console.WriteLine("!!!!!");
    if (items.Any())
    {
        var firstItem = items.First();
        Console.WriteLine($"First item greater than 5: {firstItem}");
    }

    var result = new List<int>();
    foreach (var i in list)
    {
        
        if (i > 5)
        {
            if (i % 2 == 1)
            { 
            //result.Add(PrintValues(i)); // PrintValues(i) is not needed here, as we are collecting values in result
                result.Add(i);

                PrintValues(i);
            }
            //break;
        }
    }

    //var selectItems = new List<int>();
    //foreach(var x in list)
    //{
    //    selectItems.Add(PrintValues(x));
    //}

    //var whereItems = new List<int>();
    //foreach(var x in selectItems)
    //{
    //    if (x > 5)
    //    {
    //        whereItems.Add(x);
    //    }
    //}


    int PrintValues(int value)
    {
        Console.WriteLine(value);
        return value;
    }
}
