namespace DataMap.Example.Models
{
    public static class DataModel
    {
        public static DataMap Watchmen = DataMap.Create(
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
                ), 
                "reviews", DataMap.MapOf(
                    "reader1", "Interesting",
                    "me", "5 of 5!"
                )
            )    
        );

        public static DataMap Catalog = DataMap.Create(
            DataMap.MapOf(
                "booksByIsbn", DataMap.MapOf(
                    "978-1779501127", DataMap.MapOf(
                        "isbn", "978-1779501127",
                        "title", "Watchmen",
                        "publicationYear", 1987,
                        "authorIds", DataMap.ListOf("alan-moore", "dave-gibbons"),
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
                ), 
                "authorsById", DataMap.MapOf(
                    "alan-moore", DataMap.MapOf(
                        "name", "Alan Moore",
                        "bookIsbns", DataMap.ListOf("978-1779501127")
                    ),
                    "dave-gibbons", DataMap.MapOf(
                        "name", "Dave Gibbons",
                        "bookIsbns", DataMap.ListOf("978-1779501127")
                    )
                )
            ) 
        );
    } 
}