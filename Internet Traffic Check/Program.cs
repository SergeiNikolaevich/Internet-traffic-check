using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_Traffic_Check
{
    class Program
    {
        class Internet
        {
            double gb;
            DateTime date;
            public Internet(double gb, DateTime date)
            {
                this.date = date;
                this.gb = gb;
            }

            public void Result()
            {
                
            }


        }

        static void Main(string[] args)
        {
            int fullGB = 119;

            Console.Write("Введите дату пополнения: ");
            string dateRepl = Console.ReadLine();   

            Console.Clear();

            DateTime dateReplenishment = Convert.ToDateTime(dateRepl);
            DateTime todaysDate = DateTime.Now;
            System.TimeSpan result = todaysDate - dateReplenishment;
            
            int days =(int) result.TotalDays;
            double spentGB = days * 4;
          double balance = fullGB - spentGB;

            Console.Write("Oсталось гб: {0} \t", balance);
            Console.WriteLine("Следующая дата пополнения до: {0}", dateReplenishment.AddDays(28));
           

            Console.ReadKey();

        }
    }
}
