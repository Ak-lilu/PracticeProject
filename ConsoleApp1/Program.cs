using AutoMapper;
using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IMapper mp=null;
            var people = new PeopleData(mp);
            var women = people.Get().Where(x => x.LastName.EndsWith("a")).GroupBy(x => x.LastName)
                .Select(x => x.First()).ToList();   
            var millenials = people.Get().Where(x => x.BirthDate > Convert.ToDateTime("1999-12-31")).GroupBy(x => x.LastName)
                .Select(x => x.First()).ToList();
            women.ForEach(x => Console.WriteLine(x.FirstName + "   " + x.LastName + "    " + x.BirthDate));
            Console.WriteLine();
            Console.WriteLine();
            millenials.ForEach(x => Console.WriteLine(x.FirstName+"   "+x.LastName+"    "+x.BirthDate));
        }
    }
}
