using AdvancedTechniques.UP.Business.Model;
using AdvancedTechniques.UP.Services;
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
using System.Windows.Shapes;

namespace AdvancedTechniquesUP.Desktop
{
    /// <summary>
    /// Interaction logic for CreateCustomer.xaml
    /// </summary>
    public partial class CreateCustomer : Window, ICreateCustomer
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
        }
    }
}
