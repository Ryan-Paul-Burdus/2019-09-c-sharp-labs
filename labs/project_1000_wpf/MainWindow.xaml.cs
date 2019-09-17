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
using System.Windows.Threading;
using System.Diagnostics;

namespace project_1000_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Customer> customers1;
        static List<Customer> customers2;
        static List<Customer> customers3;

        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        Stopwatch stopwatch = new Stopwatch();

        Stopwatch c1stopwatch = new Stopwatch();
        Stopwatch c2stopwatch = new Stopwatch();


        string time = "00:00:00";

        private double x = 10;
        private double y = 10;
        private bool customer1Finished = false;
        private bool customer2Finished = false;
        public double c1MovesPerTick;
        public double c2MovesPerTick;

        public MainWindow()
        {
            InitializeComponent();
            Initialise();
            dispatcherTimer.Tick += new EventHandler(_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
        }

        void Initialise()
        {
            using (var db = new ShopDbEntities())
            {
                customers3 = db.Customers.ToList();
                CustomerList.ItemsSource = customers3;
            }
            ResetButton.IsEnabled = false;


            //- make these move independantly and move dpeending on 
            //    amount of time it takes to complete

            customers1 = new List<Customer>();
            c1stopwatch.Start();
            using (var db = new ShopDbEntities())
            {
                for (int i = 0; i < 1000; i++)
                {
                    db.Customers.ToList();
                    var customer = (Customer)db.Customers.Find(i + 1);
                    customers1.Add(customer);
                }
            }
            c1stopwatch.Stop();
            customer2Label.Content = c2stopwatch.Elapsed;

            customers2 = new List<Customer>();
            c2stopwatch.Start();
            for (int i = 0; i < 1000; i++)
            {
                using (var db = new ShopDbEntities())
                {
                    db.Customers.ToList();
                    var customer = (Customer)db.Customers.Find(i + 1);
                    customers2.Add(customer);
                }
            }
            c2stopwatch.Stop();
            customer2Label.Content = c2stopwatch.Elapsed;
        }

        void _Tick(object sender, EventArgs e)
        {
            if (stopwatch.IsRunning)
            {
                TimeSpan ts = stopwatch.Elapsed;
                time = String.Format("{0:00}:{1:00}:{2:00}",
                    ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                StopWatchText.Text = time;

                c2MovesPerTick = 350 / c2stopwatch.Elapsed.Milliseconds;
                c1MovesPerTick = 350 / c1stopwatch.Elapsed.Milliseconds;

                if (Canvas.GetLeft(Customer1) >= 350)
                {
                    if (!customer1Finished)
                    {
                        Canvas.SetLeft(Customer1, 350);
                        
                        customer1Label.Content = stopwatch.Elapsed;
                        customer1Label.Visibility = Visibility.Visible;
                        customer1Finished = true;
                    }
                }
                else
                {
                    x += c1MovesPerTick;
                    Canvas.SetLeft(Customer1, x);
                }
                if (Canvas.GetLeft(Customer2) >= 350)
                {
                    if (!customer2Finished)
                    {
                        Canvas.SetLeft(Customer2, 350);
                        customer2Label.Content = stopwatch.Elapsed;
                        customer2Label.Visibility = Visibility.Visible;
                        customer2Finished = true;
                    }
                }
                else
                {
                    y += c2MovesPerTick;
                    Canvas.SetLeft(Customer2, y);
                }
                if (customer1Finished && customer2Finished)
                {
                    stopwatch.Stop();
                    StartButton.Content = "Start";
                    StartButton.IsEnabled = false;
                    ResetButton.IsEnabled = true;
                }
            }
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            stopwatch.Reset();
            StopWatchText.Text = "00:00:00";
            StartButton.Content = "Start";
            StartButton.IsEnabled = true;

            customer1Label.Visibility = Visibility.Hidden;
            customer2Label.Visibility = Visibility.Hidden;

            customer1Finished = false;
            customer2Finished = false;

            Canvas.SetLeft(Customer1, 10);
            Canvas.SetLeft(Customer2, 10);
            x = 10;
            y = 10;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (StartButton.Content.Equals("Start"))
            {
                StartButton.Content = "Stop";
                ResetButton.IsEnabled = false;

                stopwatch.Start();
                dispatcherTimer.Start();
            }
            else
            {
                StartButton.Content = "Start";
                ResetButton.IsEnabled = true;

                stopwatch.Stop();
            }
        }
    }
}
