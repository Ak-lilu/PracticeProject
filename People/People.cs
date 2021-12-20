using System;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    public class People : IPeople
    {
        public void Get()
        {
            var lines = File.ReadAllLines("test.csv").Select(a => a.EndsWith("a"));
        }
    }
}
