using System;
using System.Collections.Generic;

namespace DataMap
{
    using Example;
    class Program
    {
        static void Main(string[] args)
        {
            RunTestCase(new TestCatalog());
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