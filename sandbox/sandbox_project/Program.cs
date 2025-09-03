using System;
using System.Globalization;

public class Program
{
    static void Main(string[] args)
    {
        // This project is here for you to use as a "Sandbox" to play around
        // with any code or ideas you have that do not directly apply to
        // one of your projects.

        Console.WriteLine("Hello Sandbox World!");


        int[] numbers = { 1, 2, 3, 4, 5 };

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = numbers[i] * 2;
        }

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(numbers[i]);
            Console.WriteLine(string.Join("/ ", numbers));
        }

    }
}