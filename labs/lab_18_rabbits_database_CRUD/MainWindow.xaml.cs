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

namespace lab_18_rabbits_database_CRUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Rabbit> rabbits;
        static Rabbit rabbit = new Rabbit();

        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }

        void Initialise()
        {
            //using -> has automatic cleanup (c# doesnt know when we're done so this helps it understand and clean all memory)
            using (var db = new RabbitDbEntities())
            {
                rabbits = db.Rabbits.ToList();
            }


            //=== MANUAL METHOD ===
            //fancy 'lambda' - loops rabbits
            //               - each loop(for each rabbit) adds an item(adds the rabbit) to the listbox
            //rabbits.ForEach(rabbit => ListBoxRabbits.Items.Add(rabbit));

            //=== BINDING METHOD ===
            //better way to bind the list and database
            ListBoxRabbits.ItemsSource = rabbits;

            TextBoxAge.IsReadOnly = true;
            TextBoxName.IsReadOnly = true;

            ButtonEdit.IsEnabled = false;
            ButtonDelete.IsEnabled = false;
            ButtonCancel.IsEnabled = false;

            ListBoxRabbits.Focus();
        }

        private void ListBoxRabbits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxRabbits.SelectedItem != null)
            {
                //Whenever we select an item in the list, cast it from Object type to Rabbit type in the global rabbit variable
                rabbit = (Rabbit)ListBoxRabbits.SelectedItem;
                

                //Enable edit and delete if not adding already
                if (ButtonAdd.Content.Equals("Add"))
                {
                    TextBoxName.Text = rabbit.Name;
                    TextBoxAge.Text = rabbit.Age.ToString();
                    ButtonEdit.IsEnabled = true;
                    ButtonDelete.IsEnabled = true;
                    ButtonAdd.IsEnabled = true;
                }
                if (ButtonAdd.Content.Equals("Save"))
                {
                    TextBoxName.Text = "";
                    TextBoxAge.Text = "";
                }
                
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (ButtonAdd.Content.Equals("Add"))
            {
                TextBoxName.Focus();
                ButtonAdd.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#facdcd");
                ButtonAdd.Content = "Save";
                TextBoxName.Text = "";
                TextBoxAge.Text = "";
                TextBoxName.IsReadOnly = false;
                TextBoxAge.IsReadOnly = false;
                ButtonEdit.IsEnabled = false;
                ButtonDelete.IsEnabled = false;
                ButtonCancel.IsEnabled = true;
                TextBoxName.Background = (SolidColorBrush)Brushes.White;
                TextBoxAge.Background = (SolidColorBrush)Brushes.White;
            }
            else
            {
                
                saveAdditions();
            }
        }

        private void saveAdditions()
        {
            ButtonAdd.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#bd5555"); ;
            ButtonAdd.Content = "Add";
            TextBoxName.IsReadOnly = true;
            TextBoxAge.IsReadOnly = true;
            ButtonEdit.IsEnabled = true;
            ButtonDelete.IsEnabled = true;
            ButtonCancel.IsEnabled = true;
            TextBoxName.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#cf7c7c");
            TextBoxAge.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#cf7c7c");

            //=== COMMIT CHANGES ===
            if ((TextBoxName.Text.Length > 0) && (TextBoxAge.Text.Length > 0))
            {
                //get the age
                if (int.TryParse(TextBoxAge.Text, out int age))
                {
                    var RabbitToAdd = new Rabbit()
                    {
                        Name = TextBoxName.Text,
                        Age = age
                    };
                    //read database and add the new rabbit
                    using (var db = new RabbitDbEntities())
                    {
                        db.Rabbits.Add(RabbitToAdd);
                        db.SaveChanges();
                        //Update the view
                        rabbits = db.Rabbits.ToList();//gets rabbits
                        ListBoxRabbits.ItemsSource = rabbits;//binds to listbox
                    }
                }
                else
                {
                    
                }
                TextBoxName.Text = "";
                TextBoxAge.Text = "";
                ButtonEdit.IsEnabled = false;
                ButtonCancel.IsEnabled = false;
                ButtonDelete.IsEnabled = false;
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonEdit.Content.Equals("Edit"))
            {
                ButtonEdit.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#facdcd");
                ButtonEdit.Content = "Save";
                TextBoxName.Text = rabbit.Name;
                TextBoxAge.Text = rabbit.Age.ToString();
                TextBoxName.IsReadOnly = false;
                TextBoxAge.IsReadOnly = false;
                ListBoxRabbits.IsEnabled = false;
                //change background
                ButtonAdd.IsEnabled = false;
                ButtonDelete.IsEnabled = false;
                ButtonCancel.IsEnabled = true;
                TextBoxName.Background = (SolidColorBrush)Brushes.White;
                TextBoxAge.Background = (SolidColorBrush)Brushes.White;
            }
            else
            {
                ButtonEdit.Background = (SolidColorBrush) new BrushConverter().ConvertFrom("#bd5555");
                ButtonEdit.Content = "Edit";
                TextBoxName.IsReadOnly = true;
                TextBoxAge.IsReadOnly = true;
                ListBoxRabbits.IsEnabled = true;
                //change background
                TextBoxName.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#cf7c7c");
                TextBoxAge.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#cf7c7c");

                if ((TextBoxAge.Text.Length > 0) && (TextBoxName.Text.Length) > 0)
                {
                    //must have a rabbit selected
                    if (rabbit != null)
                    {
                        rabbit.Name = TextBoxName.Text;
                        if (int.TryParse(TextBoxAge.Text, out int age))
                        {
                            rabbit.Age = age;
                        }

                        using (var db = new RabbitDbEntities())
                        {
                            //- read rabbit from database by ID
                            var rabbitToUpdate = db.Rabbits.Find(rabbit.RabbitId);
                            //- Update rabbit 
                            rabbitToUpdate.Name = rabbit.Name;
                            rabbitToUpdate.Age = rabbit.Age;
                            //- save rabbit back to database
                            db.SaveChanges();
                            //- Repopulate the listbox (re-read from the database)
                            rabbits = db.Rabbits.ToList();//gets rabbits
                            ListBoxRabbits.ItemsSource = rabbits;//binds to listbox
                        }
                    }
                }
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonDelete.Content.Equals("Delete"))
            {
                ButtonDelete.Content = "Confirm Delete";
                ButtonAdd.IsEnabled = false;
                ButtonEdit.IsEnabled = false;
                ButtonCancel.IsEnabled = true;
                ListBoxRabbits.IsEnabled = false;
            }
            else
            {
                deleteConfirmation();
            }
        }

        private void deleteConfirmation()
        {
            //=== DELETE RECORD ===
            //- Find record in database which matches selected rabbit
            if (rabbit != null)
            {
                using (var db = new RabbitDbEntities())
                {
                    var rabbitToDelete = db.Rabbits.Find(rabbit.RabbitId);
                    db.Rabbits.Remove(rabbitToDelete);
                    db.SaveChanges();
                    //- Repopulate the listbox (re-read from the database)
                    rabbits = db.Rabbits.ToList();//gets rabbits
                    ListBoxRabbits.ItemsSource = rabbits;//binds to listbox
                }
            }
            ButtonDelete.Content = "Delete";
            ButtonDelete.IsEnabled = false;
            ButtonCancel.IsEnabled = false;
            ButtonAdd.IsEnabled = true;
            ListBoxRabbits.IsEnabled = true;
            TextBoxName.Text = "";
            TextBoxAge.Text = "";

            ListBoxRabbits.Focus();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            TextBoxName.Text = "";
            TextBoxAge.Text = "";
            ButtonAdd.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#bd5555"); ;
            ButtonAdd.Content = "Add";
            ButtonEdit.Content = "Edit";
            ButtonDelete.Content = "Delete";
            ButtonDeleteAll.Content = "Delete All";
            ButtonEdit.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#bd5555");
            ButtonAdd.IsEnabled = true;
            ButtonEdit.IsEnabled = false;
            ButtonDelete.IsEnabled = false;
            ButtonCancel.IsEnabled = false;

            ListBoxRabbits.IsEnabled = true;
            TextBoxName.IsReadOnly = true;
            TextBoxAge.IsReadOnly = true;
            TextBoxName.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#cf7c7c");
            TextBoxAge.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#cf7c7c");
            
        }

        private void KeyboardShortcuts(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.A) && Keyboard.IsKeyDown(Key.LeftShift))
            {
                ButtonAdd_Click(sender, e);
            }

            if (Keyboard.IsKeyDown(Key.Delete) && ButtonDelete.IsEnabled) { ButtonDelete_Click(sender, e); }
            if (Keyboard.IsKeyDown(Key.Delete) && Keyboard.IsKeyDown(Key.LeftCtrl) && ButtonDeleteAll.IsEnabled)
            {
                ButtonDeleteAll_Click(sender, e);
            }
            //if (Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.E) && ButtonEdit.IsEnabled) { ButtonEdit_Click(sender, e); }
            //if (Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.Back))
            //{
            //    ButtonCancel_Click(sender, e);
            //}

            if (Keyboard.IsKeyDown(Key.Enter))
            { 
                if (ButtonAdd.Content.Equals("Save"))
                {
                    if (TextBoxName.Text.Length > 0 && TextBoxAge.Text.Length == 0) { TextBoxAge.Focus(); }
                    else
                    {
                        saveAdditions();
                        ButtonEdit.IsEnabled = false;
                        ButtonCancel.IsEnabled = false;
                        ButtonDelete.IsEnabled = false;
                        ListBoxRabbits.Focus();
                    }
                    
                }
                if (ButtonDelete.IsEnabled && ButtonDelete.Content.Equals("Confirm Delete"))
                {
                    deleteConfirmation();
                    ButtonAdd.IsEnabled = true;
                }
                if (ButtonDeleteAll.IsEnabled && ButtonDeleteAll.Content.Equals("Confirm Delete"))
                {

                    DeleteAllConfirmation();
                }
            }
        }

        private void DeleteAllConfirmation()
        {
            foreach (Rabbit r in rabbits)
            {
                using (var db = new RabbitDbEntities())
                {
                    var rabbitToDelete = db.Rabbits.Find(r.RabbitId);
                    db.Rabbits.Remove(rabbitToDelete);
                    db.SaveChanges();
                    //- Repopulate the listbox (re-read from the database)
                    rabbits = db.Rabbits.ToList();//gets rabbits
                    ListBoxRabbits.ItemsSource = rabbits;//binds to listbox
                }
            }

            ButtonDeleteAll.Content = "Delete All";
            ButtonDelete.IsEnabled = false;
            ButtonCancel.IsEnabled = false;
            ListBoxRabbits.IsEnabled = true;
            ButtonAdd.IsEnabled = true;
        }

        private void ButtonDeleteAll_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonDeleteAll.Content.Equals("Delete All"))
            {
                ButtonDeleteAll.Content = "Confirm Delete";
                ButtonDelete.IsEnabled = false;
                ButtonAdd.IsEnabled = false;
                ButtonEdit.IsEnabled = false;
                ButtonCancel.IsEnabled = true;
                ListBoxRabbits.IsEnabled = false;
            }
            else
            {
                DeleteAllConfirmation();
            }
        }
    }
}
