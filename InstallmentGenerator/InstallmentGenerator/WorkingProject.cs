using System;
using InstallmentGenerator;
class Program
{
    static void Main(string[] args)
    {
        bool validAnswer = false;

        Console.Write("  Before we start choose a language, [1] to English [2] to Brazilian Portuguese \n   Response: ");

        while (!validAnswer)
        {
            string Language = Console.ReadLine();

            if (Language == "1")
            {
                var EnglishView = new EnglishView();
                Console.ReadLine();
            }
            else if (Language == "2")
            {
                var PortugueseView = new PortugueseView();
                Console.ReadLine();
            }
            else
            {
                Console.Write("\n  invalid answer \n Responde:");
            }
        }
    }
}