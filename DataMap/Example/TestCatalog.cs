using System;

namespace DataMap.Example
{
    public class TestCatalog : ITestCase
    {
        public bool Execute()
        {
            var map = Models.DataModel.Catalog;
            // List 3.6
            try
            {
                string title = map.GetData("booksByIsbn", "978-1779501127", "title");
                Console.WriteLine(title);
            }
            catch (Exception e)
            {
                throw new Exception("[TestFail::List3.6]");
            }

            return true;
        }
    }
}