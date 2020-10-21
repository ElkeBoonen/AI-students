using System;

namespace _05_Recursie
{
    class Program
    {
        static int Factorial(int number)
        {
            int fact = 1;
            for (int i = 1; i <= number; i++)
            {
                fact = fact * i;
            }
            return fact;
        }

        static int FactorialRec(int number)
        {
            if (number > 1) //recursive case
                return (number * FactorialRec(number - 1));
            else return 1; //base case
        }

        static void MoveTower(int number, char from, char to, char other)
        {
            if (number == 1) Console.WriteLine("Verplaats disk 1 van {0} naar {1}", from, to);
            if (number > 1)
            {
                MoveTower(number - 1, from, other, to); //from A to B
                Console.WriteLine("Verplaats disk {0} van {1} naar {2}", number, from, to);
                MoveTower(number - 1, other, to, from); //from B to C
            }
        }

        //in main
        

        static void Main(string[] args)
        {
            Console.WriteLine("Factorial of 5: " + Factorial(5));
            Console.WriteLine("Factorial of 5: " + FactorialRec(5));

            MoveTower(3, 'A', 'C', 'B');
        }
    }
}
