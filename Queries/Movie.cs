using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries
{
    class Movie
    {
        public string Title { get; set; }
        public float Rating { get; set; }
        public int year;

        public int Year
        {
            get
            {
                throw new Exception("Error!");
                /*Console.WriteLine($"Returning {year} for {Title}");
                return year;*/
            }
            set
            {
                year = value;
            }
        }


    }
}
