using System;
using InstallmentGenerator;
class Program
{
    static void Main(string[] args)
    {
        bool validAnswer = false;

        //Console.Write("  Before we start choose a language, [1] to English [2] to Brazilian Portuguese \n   Response: ");

        //while (!validAnswer)
        //{
         //   string Language = Console.ReadLine();

           // if (Language == "1")
           // {
                //var EnglishView = new EnglishView();
                //Console.ReadLine();
           // }
           // else if (Language == "2")
          //  {
                var PortugueseView = new PortugueseView();
                Console.ReadLine();
          //  }
            //else
            //{
                //Console.Write("\n  invalid answer \n Responde:");
           // }
       // }


        //Below you can see all 2022 holidays those are under code's sight
        //Uncomment and test it!


        // 2022/01/01  new year
        // 2022/03/01  carnival
        // 2022/05/01  International labor
        // 2022/04/21  Tira Dente's
        // 2022/09/07  Brazil's independence
        // 2022/10/12  Our Lady
        // 2022/11/02  All Souls'
        // 2022/11/15  Proclamation of the republic
        // 2022/12/25  Christmas
        // 2022/04/17  2022 Easter
        // 2022/06/16  2022 corpus christ
        // 2022/04/15  2022 good friday
        // 2022/03/02  2022 ash wednesday
    }
}