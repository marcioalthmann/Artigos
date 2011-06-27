using System;

namespace Collatz
{
    class Program
    {
        static void Main(string[] args)
        {
            Collatz(50);
            Console.Read();
        }

        static void Collatz(int numero)
        {
            Console.WriteLine(numero);

            if(numero == 1)
                return;

            if(numero % 2 == 0)
                Collatz(numero / 2);
            else
                Collatz(3 * numero + 1);
        }
    }
}
