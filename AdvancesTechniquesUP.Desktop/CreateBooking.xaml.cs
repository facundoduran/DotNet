using AdvancedTechniques.UP.Business.ViewModel;
using AdvancedTechniques.UP.Common.Helper;
using AdvancedTechniques.UP.Common.Extensions;
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
using AdvancedTechniques.UP.Common.Utils;

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
            this.txtTable.Text = string.Empty;
            this.txtFromTime.Text = string.Empty;
            this.txtToTime.Text = string.Empty;

            this.lblErrors.Visibility = Visibility.Hidden;
            this.lblShowErrors.Visibility = Visibility.Hidden;
        }

        private void btnCreatBooking_Click(object sender, RoutedEventArgs e)
        {
            var customerId = txtCustomer.Text;
            var fromTime = txtFromTime.Text.ParseDateTime();
            var toTime = txtFromTime.Text.ParseDateTime();
            var dinnersQuantity = txtDinnerQuantity.Value.HasValue ? (byte)txtDinnerQuantity.Value : 0;




            BookingViewModel bookingViewModel = new BookingViewModel()
            {   
                
                FromTime = fromTime,
                ToTime = toTime,
                DinersQuantity = dinnersQuantity,
                salesChannel = AdvancedTechniques.UP.Business.Model.SalesChannel.Desktop
            };

            var validationErrors = ValidationHelper.ValidateEntity<BookingViewModel>(bookingViewModel);

            this.ShowErrors(validationErrors);
        }

        private void ShowErrors(EntityValidationResult validationErrors) 
        {
            var formmatedErrors = validationErrors.Errors.Select(x => string.Format("* {0} {1}", x.ErrorMessage, System.Environment.NewLine));

            if (validationErrors.HasError)
            {
                lblErrors.Visibility = Visibility.Visible;
                lblShowErrors.Visibility = Visibility.Visible;
                lblShowErrors.Content = string.Join(string.Empty, formmatedErrors);
            }
            else
            {
                this.DialogResult = true;
            }
        }

        private void btnSearchTable_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSearchCustomer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.DialogResult = false;
            this.Visibility = Visibility.Hidden;
            e.Cancel = true;
        }
    }
}
