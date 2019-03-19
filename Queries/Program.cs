using System;
using System.Collections.Generic;
using System.Linq;


namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var movies = new List<Movie>
            {
                new Movie {Title = "Shutter Island", Rating = 8.5f, Year = 2015},
                new Movie {Title = "A Star Is Born", Rating = 7.6f, Year = 2018},
                new Movie {Title = "Mr. Bean", Rating = 9.5f, Year = 2001}
            };

            var query = movies.Where(m => m.Year > 2013);

            foreach (var movie in query)
            {
                //System.Console.WriteLine("Title: \"" + movie.Title + "\"");
            }

            Console.WriteLine("**********FILTER**********");

            var query2 = movies.Filter(m => m.year > 2010);
            foreach (var movie in query2)
            {
                Console.WriteLine(movie.Title);
            }

            Console.WriteLine("**********FILTER**********");

            var query3 = movies.Filter(m => m.year > 2010);
            var enumerator = query3.GetEnumerator();
            var q = movies.Where(m => m.Year > 2000).ToList();
            Console.WriteLine("q.Count");
            Console.WriteLine(q.Count());

            while (enumerator.MoveNext())
            {
                Console.WriteLine((enumerator.Current.Title));
            }

            Console.WriteLine("Exceptions and Deferred Queries");
            var queryExc = Enumerable.Empty<Movie>();
            try
            {
                queryExc = movies.Where(m => m.Year > 2000).ToList();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.ReadLine();
            
        }
    }
}