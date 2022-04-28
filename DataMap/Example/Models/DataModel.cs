namespace DataMap.Example.Models
{
    public static class DataModel
    {
        public static Map Watchmen = Map.of(
            "isbn", "978-1779501127",
            "title", "Watchmen",
            "publicationYear", 1987,
            "authors", List.of("alan-moore", "dave-gibbons"),
            "bookItems", List.of(
                Map.of(
                    "id", "book-item-1",
                    "libId", "nyc-central-lib",
                    "isLent", true
                ),
                Map.of(
                    "id", "book-item-2",
                    "libId", "nyc-central-lib",
                    "isLent", false
                )
            ),
            "reviews", Map.of(
                "reader1", "Interesting",
                "me", "5 of 5!"
            )
        );

        public static Map Catalog = Map.of(
            "booksByIsbn", Map.of(
                "978-1779501127", Map.of(
                    "isbn", "978-1779501127",
                    "title", "Watchmen",
                    "publicationYear", 1987,
                    "authorIds", List.of("alan-moore", "dave-gibbons"),
                    "bookItems", List.of(
                        Map.of(
                            "id", "book-item-1",
                            "libId", "nyc-central-lib",
                            "isLent", true
                        ),
                        Map.of(
                            "id", "book-item-2",
                            "libId", "nyc-central-lib",
                            "isLent", false
                        )
                    )
                )
            ),
            "authorsById", Map.of(
                "alan-moore", Map.of(
                    "name", "Alan Moore",
                    "bookIsbns", List.of("978-1779501127")
                ),
                "dave-gibbons", Map.of(
                    "name", "Dave Gibbons",
                    "bookIsbns", List.of("978-1779501127")
                )
            )
        );
    } 
}