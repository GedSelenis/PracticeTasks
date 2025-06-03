using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTasks.Models
{
    public class A
    {
        public void Do()
        {
            Console.WriteLine("A");
        }
    }
    public class B : A
    {
        public void Do()
        {
            Console.WriteLine("B");
        }
    }
}
