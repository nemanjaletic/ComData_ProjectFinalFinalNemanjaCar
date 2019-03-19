using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqSamples
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
                        Func<int, int> square = x => x * x;
                        Console.WriteLine(square(5));
                        Func<int, int, int> add = (int x, int y) => x + y;
                        Console.WriteLine(add(5, 3));
                        //poslednji int je izlaz
                        Func<int, int, int> kvadrat = (int x, int y) => x * x + 2 * x * y + y * y;
                        Console.WriteLine(kvadrat(2, 5));

                */


            Func<int, int> square = x => x * x;
            Func<int, int, int> add = (x, y) =>
            {
                int temp = x + y;
                return temp;
            };
            Action<int> write = x => Console.WriteLine(x);

            write(square(add(2, 2)));

            //  Console.WriteLine("WRITE: " + write);

            Console.WriteLine("********************************");
            Employee[] developers = new Employee[]
            {
                new Employee { Id=123, Name="Nemanja"},
                new Employee { Id=222, Name="Petar"}
            };

            //List<Employee> sales = new List<Employee>()
            //{
            //    new Employee { Id = 3, Name = "Milana"}
            //};

            IEnumerable<Employee> sales = new List<Employee>()
            {
                new Employee { Id = 3, Name = "Alex" }
            };


            IEnumerator<Employee> enumerator = sales.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Name.Count());
            }


            //IEnumerable<Employee> sale = new List<Employee>()
            //{
            //    new Employee {Id=5, Name="Petar" }
            //};

            //foreach (var employee in developers.Where(NameStartsWith))
            //{
            //    Console.WriteLine(employee.Name);

            //}

            //IEnumerable<Employee> sale = new List<Employee>()
            //{
            //    new Employee {Id=5, Name="Petar" }
            //};

            //foreach (var employee in developers.Where(delegate (Employee employee)
            //{
            //    return employee.Name.StartsWith("P");
            //})) 
            //{
            //    Console.WriteLine(employee.Name);

            //}

            IEnumerable<Employee> sale = new List<Employee>()
            {
                new Employee {Id=5, Name="Petar"}
             };

            foreach (var employee in developers.Where(e => e.Name.Length == 7/*StartsWith("P")*/).OrderBy(e => e.Name))

            {

                Console.WriteLine("Lenght: " + employee.Name);
                //Console.WriteLine(employee.Name);

            }





            var query = from dev in developers
                        where dev.Name.StartsWith("N") && dev.Name.Length < 15
                        orderby dev.Name descending
                        select dev;

            var query2 = developers.Where(e => e.Name.Length < 15 && e.Name.StartsWith("N"))
                                            .OrderBy(e => e.Name)
                                            .Select(e => e);
            

            foreach(var employee in query)
            {
                Console.WriteLine("Developer name \"N\" and lenght < 15: "+employee.Name);
            }


            foreach (var employee in query2)
            {
                Console.WriteLine("Developer name \"N\" and lenght < 15: " + employee.Name);
            }
            Console.ReadLine();
        }

        //private static bool NameStartsWith(Employee employee)
        //    {
        //        return employee.Name.StartsWith("P");
        //    }







    }
}
