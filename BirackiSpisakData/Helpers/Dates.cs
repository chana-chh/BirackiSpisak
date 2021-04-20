using System;
using System.Collections.Generic;
using System.Text;

namespace BirackiSpisakDataManager.Helpers
{
    public class Dates
    {

        // Posle ove godine se ide na 1000, a pre na 2000
        // Ako je trenutno 2019 prelomna godina ce biti 20
        public static int BreakYear()
        {
            DateTime date = DateTime.Now;
            int year = (date.Year % 1000) + 1;
            return year;
        }

        public static DateTime? DobFromJmbg(string jmbg)
        {
            DateTime? date = null;

            if (jmbg.Length != 13)
            {
                return null;
            }

            string d = jmbg.Substring(0, 2);
            string m = jmbg.Substring(2, 2);
            string y = jmbg.Substring(4, 3);
            string year;

            bool yearOK = Int32.TryParse(y, out int yearNumber);

            if (yearOK)
            {
                if (yearNumber <= BreakYear())
                {
                    year = $"2{y}";
                }
                else
                {
                    year = $"1{y}";
                }
                string fullDate = $"{d}.{m}.{year}";
                date = DateTime.ParseExact(fullDate, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }

            return date;
        }

        public static DateTime? TextToDate(string text)
        {
            string d;
            string m;
            string y;

            if (text.Length < 8 || text.Length > 11)
            {
                return null;
            }

            int dotIndex = text.IndexOf(".");

            if (dotIndex != -1)
            {
                return DateTime.Parse(text);
            }

            int dashIndex = text.IndexOf("-");

            if (dashIndex != -1)
            {
                d = text.Substring(8, 2);
                m = text.Substring(5, 2);
                y = text.Substring(0, 4);
            }
            else
            {
                d = text.Substring(0, 2);
                m = text.Substring(2, 2);
                y = text.Substring(4, 4);
            }

            string fullDate = $"{d}.{m}.{y}";
            DateTime? date = DateTime.ParseExact(fullDate, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);

            return date;
        }

        public static bool jePunoletstvo(string text)
        {
            DateTime? datum = TextToDate(text);

            if (datum != null)
            {
                DateTime dat = (DateTime)datum;
                DateTime trenutniDatum = DateTime.Now;
                int razlika = (dat.Date - trenutniDatum.Date).Days;
                if (razlika > -2 && razlika < 2)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
