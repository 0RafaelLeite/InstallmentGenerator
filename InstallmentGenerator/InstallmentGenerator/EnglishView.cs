using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallmentGenerator
{
    public class EnglishView : CheckWorkingDays
    {
        public override void SetGreetings()
        {
            Greetings = "~~~~~~~~~~~~~~~~ Installment generator ~~~~~~~~~~~~~~~~\n  Enter a purchase date to get all installment payment dates!!\n\n  First, was the purchase made today? enter [1] to YES and [2] to NO \n Response: ";
        }

        public override void SetLoading()
        {
            Loading = "\n  Checking...\n";
        }


        public override void SetDate()
        {

            Console.WriteLine(" ");
            Console.Write("  Type a day: ");
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
                    Console.Write("  Type a valid day: ");
                }
            }

            Console.WriteLine(" ");
            Console.Write("  Type a month: ");
            int month = 0;

            while (month == 0)
            {
                string monthName = Console.ReadLine().ToUpper().Trim();
                var teste = Int32.TryParse(monthName, out month);

                if (teste)
                {
                    if (month > 12)
                    {
                        month = 0;
                    }
                    else
                    {
                        break;
                    }
                }

                if (monthName == "JANUARY")
                {
                    month = 1;
                }
                else if (monthName == "FEBRUARY")
                {
                    month = 2;
                }
                else if (monthName == "MARCH")
                {
                    month = 3;
                }
                else if (monthName == "APRIL")
                {
                    month = 4;
                }
                else if (monthName == "MAY")
                {
                    month = 5;
                }
                else if (monthName == "JUNE")
                {
                    month = 6;
                }
                else if (monthName == "JULY")
                {
                    month = 7;
                }
                else if (monthName == "AUGUST")
                {
                    month = 8;
                }
                else if (monthName == "SEPTEMBER")
                {
                    month = 9;
                }
                else if (monthName == "OCTOBER")
                {
                    month = 10;
                }
                else if (monthName == "NOVEMBER")
                {
                    month = 11;
                }
                else if (monthName == "DECEMBER")
                {
                    month = 12;
                }
                else
                {
                    Console.Write("  Type a valid month: ");
                }
            }

            Console.WriteLine(" ");
            Console.Write("  Type an year: ");

            int year = 0;

            while (year == 0)
            {
                int yearProvided = Int32.Parse(Console.ReadLine());

                if (yearProvided < 1583 || yearProvided > 2100)
                {
                    Console.WriteLine("  Type a valid year: ");
                }
                else
                {
                    year = yearProvided;
                }
            }


            DateProvided = new DateTime(year, month, day);

            InstallmentDays = new List<DateTime>();

            Console.Write("\n  In how many installments was the purchase made? ");
            int NumberOfInstallments = Int32.Parse(Console.ReadLine());

            for (int i = 1; i <= NumberOfInstallments; i++)
            {
                InstallmentDays.Add(DateProvided.AddMonths(i));
            }


            Console.WriteLine("\n  Checking...\n");
            Thread.Sleep(1500);

            SetHolidayDates();

        }

        public EnglishView()
        {
            for (int a = 0; a < 26; a++)
            {
                Thread.Sleep(50);
                Console.Write("~");
            }

            Console.Write("  Installment  ");

            for (int b = 0; b < 26; b++)
            {
                Thread.Sleep(50);
                Console.Write("~");
            }

            Console.WriteLine("\n");

            for (int i = 0; i < InstallmentDays.Count; i++)
            {
                for (int j = 0; j < HolidayDates.Count; j++)
                {
                    while (InstallmentDays[i].Equals(HolidayDates[j]) || (int)InstallmentDays[i].DayOfWeek == 0 || (int)InstallmentDays[i].DayOfWeek == 6)
                    {
                        InstallmentDays[i] = InstallmentDays[i].AddDays(1);
                    }
                }
                Thread.Sleep(400);
                Console.WriteLine("\n  " + InstallmentDays[i] + " -- " + InstallmentDays[i].DayOfWeek);
            }
        }
    }
}
