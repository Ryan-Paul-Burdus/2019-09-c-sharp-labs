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

namespace lab_16_wpf_rabbit_explosion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DispatcherTimer timer = new DispatcherTimer();
        int x = 0;

        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }

        void Initialise()
        {
            Button01.Content = "Click Here";
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += timerTick;

            timer.Start();
        }


        void timerTick(object sender, EventArgs e)
        {
            Label01.Background = RandomColor();
            Label02.Background = RandomColor();
            Label03.Background = RandomColor();
            Label04.Background = RandomColor();
            Label05.Background = RandomColor();
            Label06.Background = RandomColor();
            Label07.Background = RandomColor();
            Label08.Background = RandomColor();
            Label09.Background = RandomColor();



        }

        public SolidColorBrush RandomColor()
        {
            Random r = new Random();
            var randomColor = new SolidColorBrush(Color.FromRgb((byte)r.Next(0, 256), (byte)r.Next(0, 256), (byte)r.Next(0, 256)));
            return randomColor;
        }

        private void Button01_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }
    }
}
