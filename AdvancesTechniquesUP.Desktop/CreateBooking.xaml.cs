using AdvancedTechniques.UP.Business.ViewModel;
using AdvancedTechniques.UP.Common.Helper;
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
        }

        private void btnCreatBooking_Click(object sender, RoutedEventArgs e)
        {
            BookingViewModel bookingViewModel = new BookingViewModel()
            {
            };

            var isValid = ValidationHelper.ValidateEntity<BookingViewModel>(bookingViewModel);

        }

        private void btnSearchTable_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSearchCustomer_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
