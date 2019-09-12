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
using System.Threading;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Collections;

namespace Just_Do_It_12_Rabbit_Explosion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DispatcherTimer timer = new DispatcherTimer();
        List<Rabbit> rabbits;

        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }

        void Initialise()
        {
            var db = new RabbitDbEntities();
            rabbits = db.Rabbits.ToList();

            foreach (Rabbit r in rabbits)
            {
                //RabbitList.Items.Add($"Name: {r.Name,-25}, Age: {r.Age}");
                RabbitListBox.Items.Add($"Name: {r.Name,-25}, Age: {r.Age}");
            }

            RabbitImage = new Image
            {
                Width = 300,
                Height = 200,
                Source = new BitmapImage(new Uri("C:/Users/Ryan Burdus/Downloads/51-510783_rabbit-png-image-rabbit-png-transparent-png.png"))
            };

        }

        void TimerTick(object sender, EventArgs e)
        {

        }

        private void ShowRabbit()
        {
            Stopwatch stopwatch = new Stopwatch();
            Canvas02.Children.Add(RabbitImage);
            stopwatch.Start();
            if (stopwatch.Elapsed.Seconds >= 1)
            {
                //Canvas02.Children.Remove(RabbitImage);
                Canvas01.Background = new SolidColorBrush(Color.FromRgb((byte)2, (byte)3, (byte)150));
                stopwatch.Stop();
            }
        }

        private void UpdateRabbitsList()
        {
            using (var db = new RabbitDbEntities())
            {
                List<Rabbit> rabbits = db.Rabbits.ToList();

                foreach (Rabbit r in rabbits)
                {
                    RabbitList.Items.Add($"Name: {r.Name,-25}, Age: {r.Age}");
                    RabbitListBox.Items.Add($"Name: {r.Name,-25}, Age: {r.Age}");
                }
            }
        }

        private void Button01_Click(object sender, RoutedEventArgs e)
        {
            if (NameInput != null && AgeInput != null)
            {
                if (Regex.IsMatch(NameInput.Text, "^[a-zA-Z ]+$") &&  Regex.IsMatch(AgeInput.Text, "^[0-9]+$"))
                {
                    ShowRabbit();
                    

                    using (var db = new RabbitDbEntities())
                    {
                        Rabbit newRabbit = new Rabbit();
                        newRabbit.Name = NameInput.Text;
                        newRabbit.Age = Convert.ToInt32(AgeInput.Text);
                        db.Rabbits.Add(newRabbit);
                        db.SaveChanges();

                        //RabbitListBox.Items.Add($"Name: {newRabbit.Name,-25}, Age: {newRabbit.Age}");
                    }


                    RabbitListBox.Items.Refresh();



                    NameInput.Text = "";
                    AgeInput.Text = "";
                }
            }
        }
    }
}
