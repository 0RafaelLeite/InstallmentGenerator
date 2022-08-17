using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallmentGenerator
{
    public abstract class CheckWorkingDays
    {
        public string Language { get; set; }
        public DateTime DateProvided { get; set; }

        public string Greetings;

        public List<DateTime> HolidayDates;

        public abstract void SetGreetings();
        public string GetGreetings()
        {
            return Greetings;
        }

        public List<DateTime> InstallmentDays;


        public string Loading;

        public abstract void SetLoading();
        public string GetLoading()
        {
            return Loading;
        }

        public abstract void SetDate();
        public  List<DateTime> GetDate()
        {
            return InstallmentDays;
        }

        public CheckWorkingDays()
        {
            SetGreetings();
            SetLoading();
            
            Console.Write(GetGreetings());

            int today = Int32.Parse(Console.ReadLine());

            if (today == 1)
            {
                Console.WriteLine(GetLoading());
                Thread.Sleep(1500);
                DateProvided = DateTime.Today;

                SetHolidayDates();

                InstallmentDays = new List<DateTime>();

                if (GetLoading() == "\n  Checking...\n")
                {
                    Console.Write("\n  In how many installments was the purchase made? ");
                    int NumberOfInstallments = Int32.Parse(Console.ReadLine());

                    for (int i = 1; i <= NumberOfInstallments; i++)
                    {
                        InstallmentDays.Add(DateProvided.AddMonths(i));
                    }

                    Console.ReadLine();
                }
                else if (GetLoading() == "\n  Verificando...\n")
                {
                    Console.Write("\n  Em quantas parcelas foi feita a compra? ");
                    int NumberOfInstallments = Int32.Parse(Console.ReadLine());

                    for (int i = 1; i <= NumberOfInstallments; i++)
                    {
                        InstallmentDays.Add(DateProvided.AddMonths(i));
                    }
                    Console.ReadLine();
                }
            }
            else
            {
                this.SetDate();
            }

        }

        public DateTime GetEasterDate(int year)
        {
            int day;
            int month;

            int lunarCyclePosition = year % 19;
            int century = year / 100;
            int daysFromEquinoxToNextFullMoon = (century - (int)(century / 4) - (int)((8 * century + 13) / 25) + 19 * lunarCyclePosition + 15) % 30;
            int daysFromFullMoonToFirstSunday = daysFromEquinoxToNextFullMoon - (int)(daysFromEquinoxToNextFullMoon / 28) * (1 - (int)(daysFromEquinoxToNextFullMoon / 28) * (int)(29 / (daysFromEquinoxToNextFullMoon + 1)) * (int)((21 - lunarCyclePosition) / 11));

            day = daysFromFullMoonToFirstSunday - ((year + (int)(year / 4) + daysFromFullMoonToFirstSunday + 2 - century + (int)(century / 4)) % 7) + 28;
            month = 3;

            if (day > 31)
            {
                month++;
                day -= 31;
            }

            //where did all of this math come from https://stackoverflow.com/questions/2510383/how-can-i-calculate-what-date-good-friday-falls-on-given-a-year

            return new DateTime(year, month, day);
        }

        public void SetHolidayDates()
        {

             HolidayDates = new List<DateTime>();

            var easter = GetEasterDate(DateProvided.Year);

            DateTime NextYear = this.DateProvided.AddYears(1);
            var NextEaster = GetEasterDate(NextYear.Year);

            HolidayDates.Add(easter);
            HolidayDates.Add(easter.AddDays(60));
            HolidayDates.Add(easter.AddDays(-47));
            HolidayDates.Add(easter.AddDays(-46));
            HolidayDates.Add(easter.AddDays(-2));
            HolidayDates.Add(NextEaster);
            HolidayDates.Add(NextEaster.AddDays(60));
            HolidayDates.Add(NextEaster.AddDays(-47));
            HolidayDates.Add(NextEaster.AddDays(-46));
            HolidayDates.Add(NextEaster.AddDays(-2));
            HolidayDates.Add(new DateTime(this.DateProvided.Year, 1, 1));
            HolidayDates.Add(new DateTime(this.DateProvided.Year, 12, 25));
            HolidayDates.Add(new DateTime(this.DateProvided.Year, 4, 21));
            HolidayDates.Add(new DateTime(this.DateProvided.Year, 11, 15));
            HolidayDates.Add(new DateTime(this.DateProvided.Year, 11, 2));
            HolidayDates.Add(new DateTime(this.DateProvided.Year, 10, 12));
            HolidayDates.Add(new DateTime(this.DateProvided.Year, 9, 7));
            HolidayDates.Add(new DateTime(this.DateProvided.Year, 5, 1));
            HolidayDates.Add(new DateTime(this.DateProvided.Year, 1, 1).AddYears(1));
            HolidayDates.Add(new DateTime(this.DateProvided.Year, 12, 25).AddYears(1));
            HolidayDates.Add(new DateTime(this.DateProvided.Year, 4, 21).AddYears(1));
            HolidayDates.Add(new DateTime(this.DateProvided.Year, 11, 15).AddYears(1));
            HolidayDates.Add(new DateTime(this.DateProvided.Year, 11, 2).AddYears(1));
            HolidayDates.Add(new DateTime(this.DateProvided.Year, 10, 12).AddYears(1));
            HolidayDates.Add(new DateTime(this.DateProvided.Year, 9, 7).AddYears(1));
            HolidayDates.Add(new DateTime(this.DateProvided.Year, 5, 1).AddYears(1));

        }

        public List<DateTime> GetHolidayDates()
        {
            return HolidayDates;
        }
    }
}