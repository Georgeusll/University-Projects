using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Program by Giorgi Bokhochadze 82359037


namespace COMPE361
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = new List<int>() { 2,5,2,7,3,2,5 };
            var second = new List<int>() {10,20,20,20,20,20,10,10,10,10,10,4};
            var third = new List<double>() {1.5, 2.2, 2.5, 2.2,7.7};
            var fourth = new List<double>() { 3.7, 6.1, 82.82,44444.22222 };

            var set1 = new Set<int>(first);
            var set2 = new Set<int>(second);
            Console.WriteLine(set1.ToString());
            Console.WriteLine(set2.ToString());

            set1 = set1 + set2;

            Console.WriteLine(set1.ToString());
            set1.Add(7);
            set2.Remove(4);

            var set4 = new Set<double>(fourth);

            Console.WriteLine(set4.ToString());
            set4.Add(1.55556555555);

            var setS1 = new SortedSet<int>(first);
            Console.WriteLine(setS1.ToString());
            
            var setS2 = new SortedSet<double>(third);
            setS2.Add(1.4381283409);
            Console.WriteLine(setS2.ToString());

            var s = new List<string>() { "E", "b", "a", "abc", "T", "QQQQQ", "Nig" , "a"};
            var setstr = new Set<string>(s);
            Console.WriteLine(setstr.ToString());
            setstr.Add("c");
            Console.WriteLine(setstr.ToString());




            var s1 = new List<string>() { "Nigggggu", "E", "gIQ", "CHAD", "E", "IQ", "CHAD",  };
            s1.Add("Hi");
            s1.Remove("ac");
            var setstr1 = new Set<string>(s1);
            Console.WriteLine(setstr1.ToString());
            Console.WriteLine(setstr + setstr1);

            var sS1 = new SortedSet<string>(s1);
            var sS2 = new SortedSet<string>(s);
            Console.WriteLine(sS1.ToString());
            Console.WriteLine(sS2
                .ToString());



        }
    }
}
