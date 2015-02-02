using AdvancedTechniques.UP.Business.Model;
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
    /// Interaction logic for CreateCustomer.xaml
    /// </summary>
    public partial class CreateCustomer : Window, IModalWindow
    {
        private ICustomerService customerService;

        public CreateCustomer(ICustomerService customerService)
        {
            InitializeComponent();
            
            this.customerService = customerService;
        }

        private void btnCreateCustomer_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer()
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Telephone = txtPhone.Text,
                Email = txtEmail.Text
            };

            this.customerService.Add(customer);

            this.DialogResult = true;
        }

        public void Clear() 
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.DialogResult = false;
            this.Visibility = Visibility.Hidden;
            e.Cancel = true;
        }
    }
}
