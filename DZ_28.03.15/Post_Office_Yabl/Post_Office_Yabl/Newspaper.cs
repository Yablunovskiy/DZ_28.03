using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post_Office_Yabl
{
    class Newspaper
    {
        public string Name;
        int Count_year;
        public int issue;

        public Newspaper()
        {
                
        }

        public Newspaper(string name, int count_year)
        {
            Name = name;
            Count_year = count_year;
            issue = Taim();
         }

        public override string ToString()
        {
            return String.Format("\n\tНазвание газеты: {0}, \n\t Кол-во экземпляров в году: {1}, \n\t  Выпуск на сегодня: {2}", Name, Count_year, issue);
        }

        public int Taim()
        {
            DateTime thisDay = DateTime.Today;
            string dateString = "01/01/2015";
            DateTime date1 = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
            TimeSpan q = thisDay.Subtract(date1);
            int n = Convert.ToInt32(q.TotalDays);
            int k = 365/Count_year;
            int I = Count_year-((365-n)/k);
            return I;
        }          
        
    }
}
