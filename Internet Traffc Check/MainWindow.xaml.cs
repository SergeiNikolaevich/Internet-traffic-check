using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;
using System.Net;
using System.IO;
using System.Windows.Threading;
using LiveCharts.Defaults;
using LiveCharts.Configurations;

namespace Internet_Traffc_Check
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
         private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BTNCheck_Click(object sender, RoutedEventArgs e)
        {
            Gb.Visibility = Visibility.Visible;

            DateTime newDate = new DateTime();
            string date = Convert.ToString(DatePickerReplenished);
            newDate = Convert.ToDateTime(date);
            newDate = newDate.AddDays(28);
            date = Convert.ToString(newDate);

            TXTPayDay.Text = date;

            //------------------------- отрисовка
            Diagram diagram = new Diagram();
            DataContext = new DiagramView(diagram);
        }
        public double Calc()
        {

            DateTime todaysDate = DateTime.Now;
            DateTime? dateReplenishment = DatePickerReplenished.SelectedDate;
            string str = dateReplenishment.ToString();
            DateTime payDay = new DateTime();
            payDay = Convert.ToDateTime(str);
            System.TimeSpan result = todaysDate - payDay;

            int fullGB = 120;
            int totalDays = (int)result.TotalDays;
            double spentGB = totalDays * 4;
            double balance = fullGB - spentGB;

            return balance;

        }

        public class DiagramView
        {
            public List<Diagram> Diagram { get; private set; }

            public DiagramView(Diagram diagram)
            {
                Diagram = new List<Diagram>();
                Diagram.Add(diagram);
            }
        }

        public class Diagram
        {
            public string Title { get; private set; }
            public double Percent { get; set; }

            public Diagram()
            {

                Title = "_____________";
                Percent = PercentCalc();

            }

            public double PercentCalc()
            {
              
                double y = 1;
                //MainWindow a = new MainWindow(); 
                //y = a.Calc();

                return y;
            }
        }
    }


}
