using System;
using CryptographyLib;
using static System.Console;

namespace SignatureApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Enter some text to sign: ");
            string data = ReadLine();
            var signature = Protector.GenerateSignature(data);
            WriteLine($"Signature : {signature}");
            WriteLine($"Publick key used to check signature:");
            WriteLine(Protector.PublickKey);

            if (Protector.ValidateSignature(data, signature))            
                WriteLine("Correct! Signature is valid");            
            else            
                WriteLine("Invalid signature");

            // Создаём поддельную подпись, заменив первый символ на Х
            var fakeSignature = signature.Replace(signature[0], 'X');
            if (Protector.ValidateSignature(data, fakeSignature))
                WriteLine("Correct! Signature is valid");
            else
                WriteLine($"Invalid signature: {fakeSignature}");

        }
    }
}
