using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using weather.Models;

namespace weather.ViewModels
{
    public class WeatherViewModel
    {
        public DateTime Day { get; set; }
        public int Temperature { get; set; }
        public int Period { get; set; }
        public int Symbol{ get; set; }

        public WeatherViewModel(Forecast forecast)
        {
            Day = forecast.Day;
            Temperature = forecast.Temperature;
            Period = forecast.Period;
            Symbol = forecast.Symbol;
        }

        // Printa läsbar text
        public string DayInText
        {
            get
            {
                // Jämför datans dag med nuvarande
                var dayCount = checkDay(Day);

                string text = "";

                switch (dayCount)
                {
                    case 0:
                        text = "Idag";
                        break;

                    case 1:
                        text = "Imorgon";
                        break;

                    case 2:
                        text = Day.ToString("dddd");
                        break;

                    case 3:
                        text = Day.ToString("dddd");
                        break;

                    case 4:
                        text = Day.ToString("dddd");
                        break;

                    default:
                        break;
                }

                return text;
            }
            
        }

        public int checkDay(DateTime day)
        {
            int dayCount = 0;

            // Jämför dagara
            for (int i = 0; i < 5; i++)
            {
                var newDay = DateTime.ParseExact(day.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                var today = DateTime.ParseExact(DateTime.Today.AddDays(i).ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);

                var result = DateTime.Compare(newDay, today);

                if (result == 0)
                {
                    dayCount = i;
                }
            }

            return dayCount;
        }
    }
}