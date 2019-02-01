using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ind_zad_18
{
    public class Date // дата
    {
    }
}
       /* string supply; // дата поставки
        string theDate; 
        private int day, month, year;
        DateTime theD;

        public Date()//сегодняшняя дата
        {
            theDate = DateTime.Now.ToShortDateString();
            day = Convert.ToInt32(theDate.Substring(0, 2));
            month = Convert.ToInt32(theDate.Substring(3, 2));
            year = Convert.ToInt32(theDate.Substring(6, 4));
            theD = new DateTime(year, month, day);
        }

        ~Date()  // деструктор
        {
            string s = "Объект уничтожен!";
        }
        * public Date(int d, int m, int y)
        {
            day = d;
            month = m;
            year = y;
            theD = new DateTime(year, month, day);
        }
        public Date(string d)
        {
            supply = d;
            day = Convert.ToInt32(d.Substring(0, 1));
            month = Convert.ToInt32(d.Substring(0, 1));
            year = Convert.ToInt32(d.Substring(0, 1));
            theD = new DateTime(year, month, day);

        }// дата поставки

        public DateTime TheDay
        {
            get { return theD; }
            set { theD = value; }
        }
        public int Day
        {
            set { day = value; }
            get { return day; }
        }
        public int Month
        {
            set { month = value; }
            get { return month; }
        }
        public int Year
        {
            set { year = value; }
            get { return year; }
        }
    }
}
    */