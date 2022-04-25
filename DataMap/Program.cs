using System;
using System.Collections.Generic;

namespace DataMap
{
    class Program
    {
        static void Main(string[] args)
        {
            DataMap watchmen = DataMap.Create(
                DataMap.MapOf(
        "isbn", "978-1779501127",
                    "title", "Watchmen",
                    "publicationYear", 1987,
                    "authors", DataMap.ListOf("alan-moore", "dave-gibbons"),
                    "bookItems", DataMap.ListOf(
                        DataMap.MapOf(
                            "id", "book-item-1",
                            "libId", "nyc-central-lib",
                            "isLent", true
                        ), 
                        DataMap.MapOf(
                            "id", "book-item-2",
                            "libId", "nyc-central-lib",
                            "isLent", false
                        )
                    )
                )    
            );
            
            Console.WriteLine(watchmen.GetData("isbn"));
            Console.WriteLine(watchmen.GetData("title"));
            Console.WriteLine(watchmen.GetData("publicationYear"));

            var authors = watchmen.GetData("authors");
            foreach (var author in authors)
            {
                Console.WriteLine(author);
            }

            var bookItems = watchmen.GetData("bookItems");
            foreach (var item in bookItems)
            {
                DataMap data = DataMap.Create(item);
                Console.WriteLine(data.GetData("id"));
                Console.WriteLine(data.GetData("libId"));
                Console.WriteLine(data.GetData("isLent"));
            }
        }
    }
}