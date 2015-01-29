using AdvancedTechniques.UP.Services;
using Microsoft.Practices.Unity;
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
        private ICustomerService customerService;
        private IBookingService bookingService;
        private ITableService tableService;

        #region Forms 
        
        private CreateBooking createBookingWpfForm;
        private CreateCustomer createCustomerForm;
        private SearchBookings searchBookingsForm;
        private SearchCustomers searchCustomersForm;
        private UpdateBooking updateBookingForm;
        private UpdateCustomer updateCustomerForm;

        #endregion

        public MainWindow(ICustomerService customerService, IBookingService bookingService, ITableService tableService)
        {
            InitializeComponent();

            this.customerService = customerService;
            this.bookingService = bookingService;
            this.tableService = tableService;

            this.searchCustomersForm = new SearchCustomers();
            this.createCustomerForm = new CreateCustomer(this.customerService);
        }

        private void MenuItemSearchBooking_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemCreateBooking_Click(object sender, RoutedEventArgs e)
        {
            this.ShowModalWindow(this.createBookingWpfForm);
        }

        private void MenuItemEditBooking_Click(object sender, RoutedEventArgs e)
        {
            this.ShowModalWindow(this.updateBookingForm);
        }

        private void MenuItemDeleteBooking_Click(object sender, RoutedEventArgs e)
        {
        }

        private void MenuItemCreateCustomer_Click(object sender, RoutedEventArgs e)
        {
            this.ShowModalWindow(this.createCustomerForm);
        }

        private void MenuItemUpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            this.ShowModalWindow(this.updateCustomerForm);
        }

        private void MenuItemDeletecustomer_Click(object sender, RoutedEventArgs e)
        {
        }

        private void MenuItemSearchCustomer_Click(object sender, RoutedEventArgs e)
        {
            this.ShowModalWindow(this.searchCustomersForm);
        }

        private void MenuItemSearchTable_Click(object sender, RoutedEventArgs e)
        {
        }

        private void MenuItemCreateTable_Click(object sender, RoutedEventArgs e)
        {
        }

        private void MenuItemUpdateUpdateTable_Click(object sender, RoutedEventArgs e)
        {
        }

        private void MenuItemDeleteTable_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ShowModalWindow(Window window) 
        {
            if (window != null)
            {
                var modalDialog = (IModalWindow)window;
                modalDialog.Clear();

                window.Show();
                window.Closed += CloseModalWindow;
                this.IsEnabled = false;
            }
        }

        private void CloseModalWindow(object sender, EventArgs e)
        {
            this.IsEnabled = true;
        }
    }
}
