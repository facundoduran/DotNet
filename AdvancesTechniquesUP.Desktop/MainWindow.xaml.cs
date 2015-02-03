using AdvancedTechniques.UP.Business.Model;
using AdvancedTechniques.UP.Common.Extensions;
using AdvancedTechniques.UP.Services;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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
        
        private CreateBooking createBookingForm;
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

            this.searchCustomersForm = new SearchCustomers(this.customerService);
            this.createCustomerForm = new CreateCustomer(this.customerService);
            this.createBookingForm = new CreateBooking(this.bookingService, this.customerService, this.tableService);
        }

        private void MenuItemSearchBooking_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemCreateBooking_Click(object sender, RoutedEventArgs e)
        {
            this.ShowModalWindow(this.createBookingForm);
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
            this.ShowModalWindow(this.searchCustomersForm);
        }

        private void MenuItemDeletecustomer_Click(object sender, RoutedEventArgs e)
        {
            this.ShowModalWindow(this.searchCustomersForm);
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

        private void MenuItemSynchronize_Click(object sender, RoutedEventArgs e)
        {
            SynchronizeBookings.BookingWcfServiceClient client = new SynchronizeBookings.BookingWcfServiceClient();

            var lastSynchronized = System.Configuration.ConfigurationManager.AppSettings.Get("lastSynchronizedDate");

            var lastSyncrhonizedDate = lastSynchronized.ParseDateTime().HasValue ? lastSynchronized.ParseDateTime().Value : DateTime.Now;

            var syncrhonizeBookings = client.SynchronizeBookings(lastSyncrhonizedDate);

            foreach (var syncBooking in syncrhonizeBookings)
            {
                Table table = new Table{
                    Capacity = syncBooking.Table.Capacity,
                    Name = syncBooking.Table.Name
                };

                Customer customer = new Customer()
                {
                    FirstName = syncBooking.Customer.FirstName,
                    LastName = syncBooking.Customer.LastName,
                    Telephone = syncBooking.Customer.Telephone,
                    Email = syncBooking.Customer.Email
                };

                Booking booking = new Booking()
                {
                    Customer = customer,
                    FromTime = syncBooking.FromTime.Value,
                    ToTime = syncBooking.ToTime.Value,
                    Table = table,
                    salesChannel = SalesChannel.Web
                };

                this.bookingService.Add(booking);
            }

            System.Configuration.ConfigurationManager.AppSettings.Set("lastSynchronizedDate", DateTime.Now.ParseString());
        }

        private void ShowModalWindow(Window window) 
        {
            if (window != null)
            {
                var modalDialog = (IModalWindow)window;
                modalDialog.Clear();

                if (window.ShowDialog().HasValue)
                {
                    this.IsEnabled = true;
                }
            }
        }
    }
}
