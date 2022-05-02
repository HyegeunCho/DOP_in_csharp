using System;
using System.Diagnostics;
using System.Linq;
using DataMap.Example.Models;

namespace DataMap.Example
{
    public class TestMapFunction : ITestCase
    {
        
        public bool Execute()
        {
            var book = _.Get(DataModel.Catalog, "booksByIsbn", "978-1779501127") as Map;
            Debug.Assert(book != null, "book == null");

            var names = authorNames(DataModel.Catalog, book);
            foreach (var item in names)
            {
                Console.WriteLine($"{item}");
            }
            
            return true;
        }

        private List authorNames(Map inData, Map inBook)
        {
            var authorIds = (_.Get(inBook, "authorIds") as List).Select(v => $"{v}").ToList();

            List names = _.Map(authorIds, id =>
            {
                return _.Get(inData, "authorsById", id, "name");
            });
            return names;
        }
    }
}