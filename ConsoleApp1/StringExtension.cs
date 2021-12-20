using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class StringExtension
    {
            public static IEnumerable<T> FromCSV<T>(this string[] lines, Func<string[], T> converter, char separator = ',')
            {
                return lines.AnyAndNotNull() && converter != null
                    ? lines.Where(l => !String.IsNullOrEmpty(l)).Select(line => converter(line.Split(separator))).AsEnumerable()
                    : Enumerable.Empty<T>();
            }

            public static bool AnyAndNotNull(this string[] lines) => lines?.Any() ?? false;
    }
}
