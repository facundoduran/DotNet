using AdvancedTechniques.UP.Business.Model;
using AdvancedTechniques.UP.Business.ViewModel;
using AdvancedTechniques.UP.Common.Extensions;
using AdvancedTechniques.UP.Common.Utils;
using AdvancedTechniques.UP.Services;
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
using System.Windows.Shapes;

namespace AdvancedTechniquesUP.Desktop
{
    /// <summary>
    /// Interaction logic for SearchBookings.xaml
    /// </summary>
    public partial class SearchBookings : Window, IModalWindow
    {
        private IBookingService bookingService;
        private ICustomerService customerService;
        private ITableService tableService;

        public BookingViewModel bookingViewModel { get; set; }

        public SearchBookings(IBookingService bookingService, ICustomerService customerService, ITableService tableService)
        {
            this.bookingService = bookingService;
            this.customerService = customerService;
            this.tableService = tableService;

            InitializeComponent();
        }

        public void Clear()
        {
            this.txtCheckIn.Text = string.Empty;
            this.txtCheckOut.Text = string.Empty;
            this.txtCustomer.Text = string.Empty;
            this.txtDinners.Text = string.Empty;

            this.bookingViewModel = new BookingViewModel();
        }

        private void EditBooking_Click(object sender, RoutedEventArgs e)
        {
            var booking = (Booking)this.bookingsGrid.SelectedItem;

            UpdateBooking updateBookingForm = new UpdateBooking(booking, this.bookingService, this.customerService, this.tableService);

            this.ShowModalWindow(updateBookingForm);

            updateBookingForm.FillControls();
        }

        private void DeleteBooking_Click(object sender, RoutedEventArgs e)
        {
            var booking = (Booking)this.bookingsGrid.SelectedItem;

            this.bookingService.Delete(booking);
        }

        private void BtnSearchCustomer_Click(object sender, RoutedEventArgs e)
        {
            SearchCustomers searchCustomerForm = new SearchCustomers(this.customerService);

            this.ShowModalWindow(searchCustomerForm);

            var customerViewModel = searchCustomerForm.customerViewModel;

            if (customerViewModel != null)
            {
                this.txtCustomer.Text = customerViewModel.Id.ToString();
            }
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            DateTime? checkIn = txtCheckIn.Text.ParseDateTime();
            DateTime? checkOut = txtCheckOut.Text.ParseDateTime();
            int dinnersQuantity;
            int customerId;

            var criteria = PredicateBuilder.True<Booking>();

            if (int.TryParse(txtDinners.Text, out dinnersQuantity))
            {
                criteria = criteria.And(x => x.Table != null && x.Table.Capacity == dinnersQuantity);
            }

            if (int.TryParse(txtCustomer.Text, out customerId))
            {
                criteria = criteria.And(x => x.CustomerId == customerId);
            }

            if (checkIn.HasValue)
            {
                criteria = criteria.And(x => x.FromTime >= checkIn);
            }

            if (checkOut.HasValue)
            {
                criteria = criteria.And(x => x.ToTime <= checkOut);
            }

            this.bookingsGrid.ItemsSource = this.bookingService.Find(criteria);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            e.Cancel = true;
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
