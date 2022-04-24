using System;

namespace DataMap
{
    class Program
    {
        static void Main(string[] args)
        {
            DataMap map = DataMap.Create();
            map.SetData(1, "root", "first");

            var first = map.GetData("root", "first");
            Console.WriteLine(first);

            var second = map.GetData("root", "second");
            Console.WriteLine(second);
        }
    }
}