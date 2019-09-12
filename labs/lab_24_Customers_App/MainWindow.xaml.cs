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

namespace lab_24_Customers_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Customer> customers;
        static List<Order> orders;
        static List<Order_Detail> orderDetails;

        public string currentCustomerID;
        public string currentOrderChosen;

        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }

        void Initialise()
        {
            ShowPanel1();

            using (var db = new NorthwindEntities())
            {
                customers = db.Customers.ToList();
                ListBoxCustomers01.ItemsSource = customers;

                orders = db.Orders.ToList();
                ListBoxCustomers02.ItemsSource = orders;

                orderDetails = db.Order_Details.ToList();
                ListBoxCustomers03.ItemsSource = orderDetails;
            }

        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            if (StackPanel01.Visibility == Visibility.Visible) { ShowPanel3(); }
            else if (StackPanel02.Visibility == Visibility.Visible){ ShowPanel1(); }
            else if (StackPanel03.Visibility == Visibility.Visible){ ShowPanel2(); }
        }

        private void ButtonForward_Click(object sender, RoutedEventArgs e)
        {
            if (StackPanel01.Visibility == Visibility.Visible) { ShowPanel2(); }
            else if (StackPanel02.Visibility == Visibility.Visible){ ShowPanel3(); }
            else if (StackPanel03.Visibility == Visibility.Visible) { ShowPanel1(); }
        }

        private void ShowPanel1()
        {
            StackPanel01.Visibility = Visibility.Visible;
            StackPanel02.Visibility = Visibility.Collapsed;
            StackPanel03.Visibility = Visibility.Collapsed;
        }
        private void ShowPanel2()
        {
            StackPanel01.Visibility = Visibility.Collapsed;
            StackPanel02.Visibility = Visibility.Visible;
            StackPanel03.Visibility = Visibility.Collapsed;
        }
        private void ShowPanel3()
        {
            StackPanel01.Visibility = Visibility.Collapsed;
            StackPanel02.Visibility = Visibility.Collapsed;
            StackPanel03.Visibility = Visibility.Visible;
        }

        private void CustomerNameSearch_KeyUp(object sender, KeyEventArgs e)
        {
            SearchCustomerList();
        }

        private void CustomerCitySearch_KeyUp(object sender, KeyEventArgs e)
        {
            SearchCustomerList();
        }

        private void SearchCustomerList()
        {
            ListBoxCustomers01.ItemsSource = customers.Where(c => c.City.ToLower().Contains(CustomerCitySearch.Text.ToLower())
                && c.ContactName.ToLower().Contains(CustomerNameSearch.Text.ToLower())).ToList();
        }

        private void SearchOrdersList()
        {
            if (currentCustomerID == null)
            {
                //show all the orders
            }
            else
            {
                ListBoxCustomers02.ItemsSource = orders.Where(o => o.OrderID.ToString().Contains(CustomerOrderSearch.Text)
                && o.CustomerID == currentCustomerID).ToList();
            }
            
        }

        private void ListBoxCustomers01_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void ViewOrders(object sender, MouseButtonEventArgs e)
        {
            ShowPanel2();
            Customer currentlySelected = (Customer)ListBoxCustomers01.SelectedItem;
            ListBoxCustomers02.ItemsSource = orders.Where(o => o.CustomerID == currentlySelected.CustomerID);
            currentCustomerID = currentlySelected.CustomerID;
        }

        private void CustomerOrderSearch_KeyUp(object sender, KeyEventArgs e)
        {
            SearchOrdersList();
        }

        private void SearchOrderProductsList()
        {
            //do this
        }

        private void ViewOrderDetails(object sender, MouseButtonEventArgs e)
        {
            ShowPanel3();
            Order ordercurrentlyselected = (Order)ListBoxCustomers02.SelectedItem;
            ListBoxCustomers03.ItemsSource = orderDetails.Where(od => od.OrderID == ordercurrentlyselected.OrderID);
        }

        private void CustomerProductSearch_KeyUp(object sender, KeyEventArgs e)
        {
            SearchOrderProductsList();
        }
    }
}
