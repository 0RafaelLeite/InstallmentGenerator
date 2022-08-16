using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallmentGenerator
{
    public class EnglishView : CheckWorkingDays
    {
        private string dayPosition;

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
                    break;
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

                if (yearProvided < 1583)
                {
                    Console.WriteLine("  Type a valid year: ");
                }
                else
                {
                    year = yearProvided;
                }
            }

            Console.WriteLine("\n  Checking...\n");
            Thread.Sleep(1500);
            DateTime DateProvided = new DateTime(year, month, day);


            var InstallmentDays = new List<DateTime>();

            InstallmentDays.Add(this.DateProvided.AddMonths(1));
            InstallmentDays.Add(this.DateProvided.AddMonths(2));
            InstallmentDays.Add(this.DateProvided.AddMonths(3));
            InstallmentDays.Add(this.DateProvided.AddMonths(4));
            InstallmentDays.Add(this.DateProvided.AddMonths(5));
            InstallmentDays.Add(this.DateProvided.AddMonths(6));
            InstallmentDays.Add(this.DateProvided.AddMonths(7));
            InstallmentDays.Add(this.DateProvided.AddMonths(8));
            InstallmentDays.Add(this.DateProvided.AddMonths(9));
            InstallmentDays.Add(this.DateProvided.AddMonths(10));
            InstallmentDays.Add(this.DateProvided.AddMonths(11));
            InstallmentDays.Add(this.DateProvided.AddMonths(12));
        }


        public void SetDayPosition()
        {

            if (this.DateProvided.Day == 1 || this.DateProvided.Day == 21 || this.DateProvided.Day == 31)
            {
                dayPosition = "st";
            }
            else if (this.DateProvided.Day == 2 || this.DateProvided.Day == 22)
            {
                dayPosition = "nd";
            }
            else if (this.DateProvided.Day == 3 || this.DateProvided.Day == 23)
            {
                dayPosition = "rd";
            }
            else
            {
                dayPosition = "th";
            }
        }

        public string GetDayPosition()
        {
            return dayPosition;
        }

       
        public EnglishView()
        {
            SetDayPosition();

 
        }

    }

}
