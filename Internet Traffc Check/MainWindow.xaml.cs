using System;
using System.Collections.Generic;
using System.Windows;

namespace Internet_Traffc_Check
{
    public partial class MainWindow : Window
    {
        private const int FullGB = 120;

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
            if (DatePickerReplenished.SelectedDate == null)
            {
                TXTPayDay.Text = "Вы не выбрали дату";
            }
            else
            {
                TXTPayDay.Text = DatePickerReplenished.SelectedDate.Value.AddDays(28).ToString();

                DataContext = new DiagramView(new Diagram
                {
                    Percent = Calc()
                });
            }
           
        }

        public double Calc()
        {
            var usageInterval = DateTime.Now - DatePickerReplenished.SelectedDate.Value;

            return FullGB - ((int)usageInterval.TotalDays * 4);
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
            }
        }
    }


}
