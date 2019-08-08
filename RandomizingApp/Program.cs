using System;
using static System.Console;
using CryptographyLib;

namespace RandomizingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("How big do you want the key (in bytes): ");
            string size = ReadLine();
            byte[] Key = Protector.GetRandomKeyOrIV(int.Parse(size));
            WriteLine("Key as a byte array:");
            for (int b = 0; b < Key.Length; b++)
            {
                Write($"{Key[b]:x2}\t");
                if (((b + 1) % 16) == 0) WriteLine();
            }
            WriteLine();
        }
    }
}
