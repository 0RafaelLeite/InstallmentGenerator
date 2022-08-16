using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallmentGenerator
{
    internal class PortugueseView : CheckWorkingDays
    {
        public override void SetGreetings()
        {
            Greetings = "~~~~~~~~~~~~~~~~ Gerador de parcelamento ~~~~~~~~~~~~~~~~\n  Digite uma data de compra para saber quando vaão ser as datas de pagamento!\n\n  Primeiro, a compra foi feita hoje? [1] para SIM [2] para NÃO \n Resposta: ";
        }

        public override void SetLoading()
        {
            Loading = "\n  Verificando...\n";
        }

        public override void SetDate()
        {

            Console.WriteLine(" ");
            Console.Write("  Digite um dia: ");
            int day = 0;

            while (day == 0)
            {
                var dayProvided = Int32.Parse(Console.ReadLine());
                if (dayProvided < 32 && dayProvided > 0)
                {
                    day = dayProvided;
                }
                else
                {
                    Console.Write("  Digite um dia válido: ");
                }
            }

            Console.WriteLine(" ");
            Console.Write("  Digite um mês: ");
            int month = 0;

            while (month == 0)
            {
                string monthName = Console.ReadLine().ToUpper().Trim();
                var teste = Int32.TryParse(monthName, out month);

                if (teste)
                {
                    break;
                }

                if (monthName == "JANEIRO")
                {
                    month = 1;
                }
                else if (monthName == "FEVEREIRO")
                {
                    month = 2;
                }
                else if (monthName == "MARÇO")
                {
                    month = 3;
                }
                else if (monthName == "ABRIL")
                {
                    month = 4;
                }
                else if (monthName == "MAIO")
                {
                    month = 5;
                }
                else if (monthName == "JUNHO")
                {
                    month = 6;
                }
                else if (monthName == "JULHO")
                {
                    month = 7;
                }
                else if (monthName == "AGOSTO")
                {
                    month = 8;
                }
                else if (monthName == "SETEMBRO")
                {
                    month = 9;
                }
                else if (monthName == "OUTUBRO")
                {
                    month = 10;
                }
                else if (monthName == "NOVEMBRO")
                {
                    month = 11;
                }
                else if (monthName == "DEZEMBRO")
                {
                    month = 12;
                }
                else
                {
                    Console.Write("  Digite um mês válido: ");
                }
            }

            Console.WriteLine(" ");
            Console.Write("  Digite um ano: ");

            int year = 0;

            while (year == 0)
            {
                int yearProvided = Int32.Parse(Console.ReadLine());

                if (yearProvided < 1583)
                {
                    Console.WriteLine("  Digite um ano válido: ");
                }
                else
                {
                    year = yearProvided;
                }
            }

            Console.WriteLine("\n  Verificando...\n");
            Thread.Sleep(1500);

            DateProvided = new DateTime(year, month, day);

            SetHolidayDates();

            InstallmentDays = new List<DateTime>();

            InstallmentDays.Add(DateProvided.AddMonths(1));
            InstallmentDays.Add(DateProvided.AddMonths(2));
            InstallmentDays.Add(DateProvided.AddMonths(3));
            InstallmentDays.Add(DateProvided.AddMonths(4));
            InstallmentDays.Add(DateProvided.AddMonths(5));
            InstallmentDays.Add(DateProvided.AddMonths(6));
            InstallmentDays.Add(DateProvided.AddMonths(7));
            InstallmentDays.Add(DateProvided.AddMonths(8));
            InstallmentDays.Add(DateProvided.AddMonths(9));
            InstallmentDays.Add(DateProvided.AddMonths(10));
            InstallmentDays.Add(DateProvided.AddMonths(11));
            InstallmentDays.Add(DateProvided.AddMonths(12));

        }


        public PortugueseView()
        {
            SetHolidayDates();


            for (int i = 0; i < InstallmentDays.Count; i++)
            {
                for (int j = 0; j < HolidayDates.Count; j++)
                {
                    while (InstallmentDays[i].Equals(HolidayDates[j]) || (int)InstallmentDays[i].DayOfWeek == 0 || (int)InstallmentDays[i].DayOfWeek == 6)
                    {
                       InstallmentDays[i] = InstallmentDays[i].AddDays(1);
                    }
                }
                Console.WriteLine(InstallmentDays[i] + " -- " + InstallmentDays[i].DayOfWeek);
            }
        }      

    }


}
