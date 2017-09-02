using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace nametools
{
    public class nametools
    {
        public static DateTime parseDate(string date)
        {
            DateTime dt;
            int year = 0, month = 0, day = 0;
            bool yearParsed = false, monthParsed = false, dayParsed = false;
            // Check if date string is in the dashed format
            if(2 == date.Count(x => (x == '-')))
            {
                string[] delims = date.Split('-');
                foreach (string s in delims)
                {
                    if (s.Length == 4)
                    {
                        if(Int32.TryParse(s, out year))
                            yearParsed = true;
                    }
                    if(s.Length == 2)
                    {
                        int tmp;
                        Int32.TryParse(s, out tmp);
                        if (tmp > 12 && tmp != 0)
                            month = tmp;

                    }
                }
            }


            if(yearParsed && monthParsed && dayParsed)
                dt = new DateTime(year, month, day);
            else
                dt = new DateTime(2017, 1, 1);
            return dt;
        }
    }
}
