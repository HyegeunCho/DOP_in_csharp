using System;

namespace DataMap.Example
{
    using Models;
    
    public class TestWatchmen : ITestCase
    {
        public bool Execute()
        {
            var map = Models.DataModel.Watchmen;
            
            Console.WriteLine(_.Get(map, "reviews", "reader1"));
            Console.WriteLine(_.Get(map, "reviews", "me"));
            
            Console.WriteLine(_.Get(map, "isbn"));
            Console.WriteLine(_.Get(map, "title"));
            Console.WriteLine(_.Get(map, "publicationYear"));

            var authors = _.Get(map, "authors");
            foreach (var author in authors)
            {
                Console.WriteLine(author);
            }

            var bookItems = _.Get(map, "bookItems");
            foreach (var item in bookItems)
            {
                Map data = item as Map;
                if (data == null) throw new Exception("하위 맵도 Map 타입으로 반환되어야 함");
                
                Console.WriteLine(_.Get(data, "id"));
                Console.WriteLine(_.Get(data, "libId"));
                Console.WriteLine(_.Get(data, "isLent"));
            }

            return true;
        }
    }
}