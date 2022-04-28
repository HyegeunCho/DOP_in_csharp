using System;

namespace DataMap.Example
{
    using Models;
    
    public static class TestWatchmen
    {
        public static bool Execute()
        {
            Console.WriteLine(DataModel.Watchmen.GetData("reviews", "reader1"));
            Console.WriteLine(DataModel.Watchmen.GetData("reviews", "me"));
            
            Console.WriteLine(DataModel.Watchmen.GetData("isbn"));
            Console.WriteLine(DataModel.Watchmen.GetData("title"));
            Console.WriteLine(DataModel.Watchmen.GetData("publicationYear"));

            var authors = DataModel.Watchmen.GetData("authors");
            foreach (var author in authors)
            {
                Console.WriteLine(author);
            }

            var bookItems = DataModel.Watchmen.GetData("bookItems");
            foreach (var item in bookItems)
            {
                DataMap data = DataMap.Create(item);
                Console.WriteLine(data.GetData("id"));
                Console.WriteLine(data.GetData("libId"));
                Console.WriteLine(data.GetData("isLent"));
            }

            return true;
        }
    }
}