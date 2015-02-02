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
    /// Interaction logic for UpdateCustomer.xaml
    /// </summary>
    public partial class UpdateCustomer : Window, IModalWindow
    {
        private Customer customer { get; set; }

        private ICustomerService customerService;

        public UpdateCustomer(Customer customer, ICustomerService customerService)
        {
            InitializeComponent();

            this.customer = customer;
            this.customerService = customerService;
        }

        public void FillControls() 
        {
            if (this.customer != null)
            {
                this.txtFirstName.Text = this.customer.FirstName;
                this.txtLastName.Text = this.customer.LastName;
                this.txtPhone.Text = this.customer.Telephone;
                this.txtEmail.Text = this.customer.Email;   
            }
        }

        private void btnUpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            this.customer.FirstName = this.txtFirstName.Text;
            this.customer.LastName = this.txtLastName.Text;
            this.customer.Telephone = this.txtPhone.Text;
            this.customer.Email = txtEmail.Text;

            this.customerService.Edit(this.customer);

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
