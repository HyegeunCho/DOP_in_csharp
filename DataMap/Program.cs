using System;
using System.Collections.Generic;

namespace DataMap
{
    using Example;
    class Program
    {
        static void Main(string[] args)
        {
            ITestCase[] cases = new ITestCase[]
            {
                new TestWatchmen(),
                new TestCatalog(), 
                new TestMapFunction()
            };

            foreach (var item in cases)
            {
                Console.WriteLine($"===== [{item.GetType()}] =====");
                RunTestCase(item);
                Console.WriteLine("================================");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
            }
        }

        private static void RunTestCase(ITestCase inTest)
        {
            bool result = false;
            try
            {
                result = inTest.Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result = false;
            }
            Console.WriteLine($"[{inTest.GetType()}] {result}");
        }
    }
}