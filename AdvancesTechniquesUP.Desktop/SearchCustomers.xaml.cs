using AdvancedTechniques.UP.Business.Model;
using AdvancedTechniques.UP.Business.ViewModel;
using AdvancedTechniques.UP.Common.Utils;
using AdvancedTechniques.UP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    /// Interaction logic for SearchCustomers.xaml
    /// </summary>
    public partial class SearchCustomers : Window, IModalWindow
    {
        private ICustomerService customerService;
        public CustomerViewModel customerViewModel { get; set; }

        public SearchCustomers(ICustomerService customerService)
        {
            this.customerService = customerService;
            this.customerViewModel = new CustomerViewModel();

            InitializeComponent();
        }

        public void Clear()
        {
            this.txtFirstName.Text = string.Empty;
            this.txtLastName.Text = string.Empty;
            this.txtTelephone.Text = string.Empty;
            this.txtEmail.Text = string.Empty;

            this.customerViewModel = new CustomerViewModel();
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string telephone = txtTelephone.Text;
            string email = txtEmail.Text;

            var criteria = PredicateBuilder.True<Customer>(); 

            if (!string.IsNullOrEmpty(txtFirstName.Text))
            {
                criteria = criteria.And(x => x.FirstName == firstName);
            }

            if (!string.IsNullOrEmpty(txtLastName.Text))
            {
                criteria = criteria.And(x => x.LastName == lastName);
            }

            if (!string.IsNullOrEmpty(txtTelephone.Text))
            {
                criteria = criteria.And(x => x.Telephone == telephone);
            }

            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                criteria = criteria.And(x => x.Email == email);
            }

            this.customersGrid.ItemsSource = this.customerService.Find(criteria).ToList(); 
        }

        private void SelectCustomer_Click(object sender, RoutedEventArgs e)
        {
            var customer = (Customer)this.customersGrid.SelectedItem;

            this.customerViewModel = new CustomerViewModel()
            {
                Id = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Telephone = customer.Telephone,
                Email = customer.Email
            };

            this.DialogResult = true;
        }

        private void EditCustomer_Click(object sender, RoutedEventArgs e)
        {
            var customer = (Customer)this.customersGrid.SelectedItem;

            UpdateCustomer updateCustomerForm = new UpdateCustomer(customer, this.customerService);

            this.ShowModalWindow(updateCustomerForm);

            updateCustomerForm.FillControls();
        }

        private void DeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            var customer = (Customer)this.customersGrid.SelectedItem;

            this.customerService.Delete(customer);
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
            this.Visibility = Visibility.Hidden;
            e.Cancel = true;
        }
    }
}




