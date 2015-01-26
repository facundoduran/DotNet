using AdvancedTechniquesUP.Desktop.Interfaces;
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

namespace AdvancedTechniquesUP.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ICreateCustomer createCustomerWpfForm;

        public MainWindow(ICreateCustomer createCustomerWpfForm)
        {
            InitializeComponent();
            this.createCustomerWpfForm = createCustomerWpfForm;
        }

        private void MenuItemCreateBooking_Click(object sender, RoutedEventArgs e)
        {
            CreateBooking createBookingWpfForm = new CreateBooking();
            createBookingWpfForm.Show();
        }

        private void MenuItemEditBooking_Click(object sender, RoutedEventArgs e)
        {
            this.ShowSearchCustomerWpfForm();
        }

        private void MenuItemDeleteBooking_Click(object sender, RoutedEventArgs e)
        {
            this.ShowSearchCustomerWpfForm();
        }

        private void BtnCreateBooking_Click(object sender, RoutedEventArgs e)
        {
            CreateBooking createBookingWpfForm = new CreateBooking();
            createBookingWpfForm.Show();
        }

        private void BtnEditBooking_Click(object sender, RoutedEventArgs e)
        {
            this.ShowSearchBookingWpfForm();
        }

        private void BtnDeleteBooking_Click(object sender, RoutedEventArgs e)
        {
            this.ShowSearchBookingWpfForm();
        }

        private void MenuItemCreateCustomer_Click(object sender, RoutedEventArgs e)
        {
            this.createCustomerWpfForm.Show();
        }

        private void MenuItemUpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            this.ShowSearchCustomerWpfForm();
        }

        private void MenuItemDeletecustomer_Click(object sender, RoutedEventArgs e)
        {
            this.ShowSearchCustomerWpfForm();
        }

        private void ShowSearchBookingWpfForm() 
        {
            SearchBookings searchBookingWpfForm = new SearchBookings();
            searchBookingWpfForm.Show();
        }

        private void ShowSearchCustomerWpfForm()
        {
            SearchCustomers searchCustomer = new SearchCustomers();
            searchCustomer.Show();
        }
    }
}
