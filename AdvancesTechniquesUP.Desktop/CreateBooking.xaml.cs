using AdvancedTechniques.UP.Business.ViewModel;
using AdvancedTechniques.UP.Common.Helper;
using AdvancedTechniques.UP.Common.Extensions;
using AdvancedTechniques.UP.Services;
using System;
using System.Linq;
using System.Windows;
using AdvancedTechniques.UP.Common.Utils;
using AdvancedTechniques.UP.Business.Model;

namespace AdvancedTechniquesUP.Desktop
{
    /// <summary>
    /// Interaction logic for CreateBooking.xaml
    /// </summary>
    public partial class CreateBooking : Window, IModalWindow
    {
        private IBookingService bookingService;
        private ICustomerService customerService;
        private ITableService tableService;

        public CreateBooking(IBookingService bookingService, ICustomerService customerService, ITableService tableService)
        {
            this.bookingService = bookingService;
            this.customerService = customerService;
            this.tableService = tableService;
            InitializeComponent();
        }

        public void Clear()
        {
            this.txtCustomer.Text = string.Empty;
            this.txtFromTime.Text = string.Empty;
            this.txtToTime.Text = string.Empty;

            this.lblErrors.Visibility = Visibility.Hidden;
            this.lblShowErrors.Visibility = Visibility.Hidden;
        }

        private void btnCreateBooking_Click(object sender, RoutedEventArgs e)
        {
            int customerId;
            Int32.TryParse(this.txtCustomer.Text, out customerId);

            var fromTime = txtFromTime.Text.ParseDateTime();
            var toTime = txtFromTime.Text.ParseDateTime();
            var dinnersQuantity = txtDinnerQuantity.Value.HasValue ? (byte)txtDinnerQuantity.Value : 0;

            var customer = this.customerService.GetById(customerId);

            CustomerViewModel customerViewModel = new CustomerViewModel();
                
            if (customer != null)
	        {
		        customerViewModel = new CustomerViewModel()
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Telephone = customer.Telephone,
                    Email = customer.Email
                };
	        }

            BookingViewModel bookingViewModel = new BookingViewModel()
            {   
                Customer = customerViewModel,
                FromTime = fromTime,
                ToTime = toTime,
                DinersQuantity = dinnersQuantity,
                salesChannel = AdvancedTechniques.UP.Business.Model.SalesChannel.Desktop
            };

            var validationErrors = ValidationHelper.ValidateEntity<BookingViewModel>(bookingViewModel);

            if (!validationErrors.HasError)
            {
                Table table = this.tableService.GetAvailableTable(fromTime.Value, toTime.Value, dinnersQuantity);
                if (table != null)
                {
                    Booking newBooking = new Booking()
                    {
                        Customer = customer,
                        FromTime = fromTime.Value,
                        ToTime = toTime.Value,
                        salesChannel = SalesChannel.Web,
                        Table = table
                    };

                    this.bookingService.Add(newBooking);

                    this.DialogResult = true;
                }
            }

            this.ShowErrors(validationErrors);
        }

        private void ShowErrors(EntityValidationResult validationErrors) 
        {
            var formmatedErrors = validationErrors.Errors.Select(x => string.Format("* {0} {1}", x.ErrorMessage, System.Environment.NewLine));

            lblErrors.Visibility = Visibility.Visible;
            lblShowErrors.Visibility = Visibility.Visible;
            lblShowErrors.Content = string.Join(string.Empty, formmatedErrors);

        }

        private void btnSearchCustomer_Click(object sender, RoutedEventArgs e)
        {
            SearchCustomers searchCustomerForm = new SearchCustomers(this.customerService);

            this.ShowModalWindow(searchCustomerForm);

            var customerViewModel = searchCustomerForm.customerViewModel;

            if (customerViewModel != null)
	        {
                this.txtCustomer.Text = customerViewModel.Id.ToString();
	        }
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.DialogResult = false;
            this.Visibility = Visibility.Hidden;
            e.Cancel = true;
        }
    }
}
