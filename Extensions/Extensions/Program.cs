using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Extensions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("testando times");
            3.Times(x => Console.Write("{0} ", x));
            Console.WriteLine();
            Console.WriteLine("testando upto");
            5.UpTo(10).Each(x => Console.Write("{0} ", x));
            Console.WriteLine();
            Console.WriteLine("testando downto");
            10.DownTo(5).Each(x => Console.Write("{0} ", x));

            Console.ReadLine();
        }
    }

    public static class Extensions
    {
        public static void Times(this int value, Action<int> action)
        {
            for (int i = 0; i < value; i++)
            {
                action(i);
            }
        }

        public static IEnumerable<int> UpTo(this int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                yield return i;
            }
        }

        public static IEnumerable<int> DownTo(this int start, int end)
        {
            for (int i = start; i >= end; i--)
            {
                yield return i;
            }
        }

        public static void Each<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var value in enumerable)
            {
                action(value);
            }
        }
    }
}
