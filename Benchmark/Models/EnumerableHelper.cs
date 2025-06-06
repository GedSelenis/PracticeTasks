using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark.Models
{
    [SimpleJob(launchCount: 1, warmupCount: 10, iterationCount: 100, invocationCount: 10)]
    public class EnumerableHelper
    {
        private const int Iterations = 10000;
        private const int BegginingListSize = 5;
        private const int RandomSeed = 5;
        private static int RandomSize = 100;
        private List<int> _list = new List<int>();
        private LinkedList<int> _linkedList = new LinkedList<int>();
        private HashSet<int> _hashSet = new HashSet<int>();
        private Dictionary<int, int> _dict = new Dictionary<int, int>();
        private SortedDictionary<int, int> _sortedDict = new SortedDictionary<int, int>();
        private SortedSet<int> _sortedSet = new SortedSet<int>();
        private Queue<int> _queue = new Queue<int>();
        private Stack<int> _stack = new Stack<int>();

        public EnumerableHelper() 
        {
        }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _list = GenerateList(BegginingListSize);
            _linkedList = GenerateLinkedList(BegginingListSize);
            _hashSet = GenerateHashSet(BegginingListSize);
            _dict = GenerateDictionary(BegginingListSize);
            _sortedDict = GenerateSortedDictionary(BegginingListSize);
            _sortedSet = GenerateSortedSet(BegginingListSize);
            _queue = GenerateQueue(BegginingListSize);
            _stack = GenerateStack(BegginingListSize);
        }

        #region List Operations
        [Benchmark]
        public void AddToListEnd()
        {
            int value = 5;
            for (int i = 0; i < Iterations; i++)
            {
                _list.Add(value);
            }
        }
        [Benchmark]
        public void AddToListBegining()
        {
            int value = 5;
            for (int i = 0; i < Iterations; i++)
            {
                _list.Insert(0, value);
            }
        }
        [Benchmark]
        public void AddToListRandom()
        {
            int value = 5;
            for (int i = 0; i < Iterations; i++)
            {
                Random random = new Random(RandomSeed);
                _list.Insert(random.Next(_list.Count - 1), value);
            }
        }
        [Benchmark]
        public void ReadFromListBeggining()
        {
            for (int i = 0; i < Iterations; i++)
            {
                _list.First();
            }
        }
        [Benchmark]
        public void ReadFromListEnd()
        {
            for (int i = 0; i < Iterations; i++)
            {
                _list.Last();
            }
        }
        [Benchmark]
        public void SearchList()
        {
            int value = 5;
            for (int i = 0; i < Iterations; i++)
            {
                for (int j = 0; j < _list.Count; j++)
                {
                    if (_list[j] == value)
                    {
                        int a = _list[j]; // Found value
                        break;
                    }
                }
            }
        }
        public List<int> GenerateList(int count)
        {
            List<int> list = new List<int>();
            Random random = new Random(RandomSeed);
            for (int i = 0; i < count; i++)
            {
                list.Add(random.Next(RandomSize));
            }
            return list;
        }
        #endregion

        #region LinkedList Operations
        [Benchmark]
        public void AddToLinkedListEnd()
        {
            int value = 5;
            for (int i = 0; i < Iterations; i++)
            {
                _linkedList.AddLast(value);
            }
        }
        [Benchmark]
        public void AddToLinkedListBegining()
        {
            int value = 5;
            for (int i = 0; i < Iterations; i++)
            {
                _linkedList.AddFirst(value);
            }
        }
        [Benchmark]
        public void AddToLinkedListRandom()
        {
            int value = 5;
            Random random = new Random();
            for (int i = 0; i < Iterations; i++)
            {
                int index = random.Next(_linkedList.Count - 1);
                LinkedListNode<int> currentNode = _linkedList.First;
                for (int j = 0; j < index; j++)
                {
                    currentNode = currentNode.Next;
                }
                _linkedList.AddAfter(currentNode, value);
            }
        }
        [Benchmark]
        public void ReadFromLinkedListBeggining()
        {
            int value = 5;
            for (int i = 0; i < Iterations; i++)
            {
                _linkedList.First();
            }
        }
        [Benchmark]
        public void ReadFromLinkedListEnd()
        {
            int value = 5;
            for (int i = 0; i < Iterations; i++)
            {
                _linkedList.Last();
            }
        }
        [Benchmark]
        public void SearchLinkedList()
        {
            int value = 5;
            for (int i = 0; i < Iterations; i++)
            {
                LinkedListNode<int> currentNode = _linkedList.First;
                while (currentNode != _linkedList.Last)
                {
                    if (currentNode.Value == value)
                    {
                        int foundValue = currentNode.Value; // Found value
                        break;
                    }
                    currentNode = currentNode.Next;
                }
            }
        }
        public LinkedList<int> GenerateLinkedList(int count)
        {
            LinkedList<int> list = new LinkedList<int>();
            Random  random = new Random(RandomSeed);
            for (int i = 0; i < count; i++)
            {
                list.AddLast(random.Next(RandomSize));
            }
            return list;
        }
        #endregion

        #region HashSet Operations
        [Benchmark]
        public void AddToHashSetEnd()
        {
            int value;
            for (int i = 0; i < Iterations; i++)
            {
                value = _hashSet.Max() + 1;
                _hashSet.Append(value);
                value++;
            }
        }
        [Benchmark]
        public void AddToHashSetSimple()
        {
            int value;
            for (int i = 0; i < Iterations; i++)
            {
                value = _hashSet.Max() + 1;
                _hashSet.Add(value);
                value++;
            }
        }
        //[Benchmark] // Not sure how to do this
        //public void AddToHashSetRandom()
        //{
        //    int value = 5;
        //    Random random = new Random();
        //    for (int i = 0; i < Iterations; i++)
        //    {
               
        //    }
        //}
        [Benchmark]
        public void ReadFromHashSetBeggining()
        {
            for (int i = 0; i < Iterations; i++)
            {
                _hashSet.First();
            }
        }
        [Benchmark]
        public void ReadFromHashSetEnd()
        {
            int value = 5;
            for (int i = 0; i < Iterations; i++)
            {
                _hashSet.Last();
            }
        }
        [Benchmark]
        public void SearchHashSet()
        {
            int value = 5;
            for (int i = 0; i < Iterations; i++)
            {
                _hashSet.TryGetValue(value,out int foundValue);
            }
        }
        public HashSet<int> GenerateHashSet(int count)
        {
            HashSet<int> hashSet = new HashSet<int>();
            Random random = new Random(RandomSeed);
            for (int i = 0; i < count; i++)
            {
                hashSet.Add(random.Next(RandomSize) * i);
            }
            return hashSet;
        }
        #endregion

        #region Dictionary Operations
        [Benchmark]
        public void AddToDictionaryEnd()
        {
            int value = 5;
            for (int i = 0; i < Iterations; i++)
            {
                _dict.Append(new KeyValuePair<int, int>( _dict.Keys.Max() + 1,value));
            }
        }
        [Benchmark]
        public void AddToDictionarySimple()
        {
            int value = 5;
            for (int i = 0; i < Iterations; i++)
            {
                _dict.Add(_dict.Keys.Max() + 1, value);
            }
        }
        //[Benchmark]
        //public void AddToDictionaryRandom()
        //{
        //    int value = 5;
        //    Random random = new Random();
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        int index = random.Next(_linkedList.Count - 1);
        //    }
        //}
        [Benchmark]
        public void ReadFromDictionaryBeggining()
        {
            for (int i = 0; i < Iterations; i++)
            {
                _dict.First();
            }
        }
        [Benchmark]
        public void ReadFromDictionaryEnd()
        {
            for (int i = 0; i < Iterations; i++)
            {
                _dict.Last();
            }
        }
        [Benchmark]
        public void SearchDictionary()
        {
            int value = 5;
            for (int i = 0; i < Iterations; i++)
            {
                foreach (var kvp in _dict)
                {
                    if (kvp.Value == value)
                    {
                        int foundValue = kvp.Value; // Found value
                        break;
                    }
                }
            }
        }
        public Dictionary<int,int> GenerateDictionary(int count)
        {
            Dictionary<int, int> dict = new Dictionary<int,int>();
            Random random = new Random(RandomSeed);
            for (int i = 0; i < count; i++)
            {
                dict.Add(i,random.Next(RandomSize));
            }
            return dict;
        }
        #endregion

        #region SortedDictionary Operations
        [Benchmark]
        public void AddToSortedDictionaryEnd()
        {
            int value = 5;
            for (int i = 0; i < Iterations; i++)
            {
                _sortedDict.Append(new KeyValuePair<int, int>(_dict.Keys.Max() + 1, value));
            }
        }
        [Benchmark]
        public void AddToSortedDictionarySimple()
        {
            int value = 5;
            for (int i = 0; i < Iterations; i++)
            {
                _sortedDict.Add(_dict.Keys.Max() + 1, value);
            }
        }
        //[Benchmark]
        //public void AddToSortedDictionaryRandom()
        //{
        //    int value = 5;
        //    Random random = new Random();
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        int index = random.Next(_linkedList.Count - 1);
        //    }
        //}
        [Benchmark]
        public void ReadFromSortedDictionaryBeggining()
        {
            for (int i = 0; i < Iterations; i++)
            {
                _sortedDict.First();
            }
        }
        [Benchmark]
        public void ReadFromSortedDictionaryEnd()
        {
            for (int i = 0; i < Iterations; i++)
            {
                _sortedDict.Last();
            }
        }
        [Benchmark]
        public void SearchSortedDictionary()
        {
            int value = 5;
            for (int i = 0; i < Iterations; i++)
            {
                foreach (var kvp in _sortedDict)
                {
                    if (kvp.Value == value)
                    {
                        int foundValue = kvp.Value; // Found value
                        break;
                    }
                }
            }
        }
        public SortedDictionary<int, int> GenerateSortedDictionary(int count)
        {
            SortedDictionary<int, int> dict = new SortedDictionary<int, int>();
            Random random = new Random(RandomSeed);
            for (int i = 0; i < count; i++)
            {
                dict.Add(i, random.Next(RandomSize));
            }
            return dict;
        }
        #endregion

        #region SortedSet Operations
        [Benchmark]
        public void AddToSortedSetEnd()
        {
            int value;
            for (int i = 0; i < Iterations; i++)
            {
                value = _sortedSet.Max + 1;
                _sortedSet.Append(value);
            }
        }
        [Benchmark]
        public void AddToSortedSetSimple()
        {
            int value = 5;
            for (int i = 0; i < Iterations; i++)
            {
                value = _sortedSet.Max + 1;
                _sortedSet.Add(value);
            }
        }
        //[Benchmark]
        //public void AddToSortedSetRandom()
        //{
        //    int value = 5;
        //    Random random = new Random();
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        int index = random.Next(_linkedList.Count - 1);
        //    }
        //}
        [Benchmark]
        public void ReadFromSortedSetBeggining()
        {
            for (int i = 0; i < Iterations; i++)
            {
                _sortedSet.First();
            }
        }
        [Benchmark]
        public void ReadFromSortedSetEnd()
        {
            for (int i = 0; i < Iterations; i++)
            {
                _sortedSet.Last();
            }
        }
        [Benchmark]
        public void SearchSortedSet()
        {
            int value = 5;
            for (int i = 0; i < Iterations; i++)
            {
                _sortedSet.TryGetValue(value, out int foundValue);
            }
        }
        public SortedSet<int> GenerateSortedSet(int count)
        {
            SortedSet<int> set = new SortedSet<int>();
            Random random = new Random(RandomSeed);
            for (int i = 0; i < count; i++)
            {
                set.Add(random.Next(RandomSize) * i);
            }
            return set;
        }
        #endregion

        #region Queue Operations
        [Benchmark]
        public void AddToQueueEnd()
        {
            int value = 5;
            for (int i = 0; i < Iterations; i++)
            {
                _queue.Enqueue(value);
            }
        }
        //[Benchmark] // Not Possible
        //public void AddToQueueBeginning()
        //{
        //    int value;
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        _queue.
        //    }
        //}
        //[Benchmark] // Not sure how to do this
        //public void AddToQueueRandom()
        //{
        //    int value = 5;
        //    Random random = new Random();
        //    for (int i = 0; i < Iterations; i++)
        //    {

        //    }
        //}
        [Benchmark]
        public void ReadFromQueueBeggining()
        {
            for (int i = 0; i < Iterations; i++)
            {
                _queue.First();
            }
        }
        [Benchmark]
        public void ReadFromQueueEnd()
        {
            int value = 5;
            for (int i = 0; i < Iterations; i++)
            {
                _queue.Last();
            }
        }
        public Queue<int> GenerateQueue(int count)
        {
            Queue<int> queue = new Queue<int>();
            Random random = new Random(RandomSeed);
            for (int i = 0; i < count; i++)
            {
                queue.Enqueue(random.Next(RandomSize));
            }
            return queue;
        }
        #endregion

        #region Stack Operations
        [Benchmark]
        public void AddToStackTop()
        {
            int value = 5;
            for (int i = 0; i < Iterations; i++)
            {
                _stack.Push(value);
            }
        }
        //[Benchmark] // Not Possible
        //public void AddToStackBeginning()
        //{
        //    int value;
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        _queue.
        //    }
        //}
        //[Benchmark] // Not sure how to do this
        //public void AddToStackRandom()
        //{
        //    int value = 5;
        //    Random random = new Random();
        //    for (int i = 0; i < Iterations; i++)
        //    {

        //    }
        //}
        [Benchmark]
        public void ReadFromStackBeggining()
        {
            for (int i = 0; i < Iterations; i++)
            {
                _stack.First();
            }
        }
        [Benchmark]
        public void ReadFromStackEnd()
        {
            int value = 5;
            for (int i = 0; i < Iterations; i++)
            {
                _stack.Last();
            }
        }
        public Stack<int> GenerateStack(int count)
        {
            Stack<int> stack = new Stack<int>();
            Random random = new Random(RandomSeed);
            for (int i = 0; i < count; i++)
            {
                stack.Push(random.Next(RandomSize));
            }
            return stack;
        }
        #endregion
    }
}
