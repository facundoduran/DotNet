using AdvancedTechniques.UP.Business.Model;
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

        public SearchCustomers(ICustomerService customerService)
        {
            this.customerService = customerService;
            InitializeComponent();
        }

        public void Clear()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtTelephone.Text = string.Empty;
            txtEmail.Text = string.Empty;
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

        private void EditClient_Click(object sender, RoutedEventArgs e)
        {
            var customer = (Customer)this.customersGrid.SelectedItem;

            UpdateCustomer updateCustomerForm = new UpdateCustomer(customer, this.customerService);

            this.ShowModalWindow(updateCustomerForm);

            updateCustomerForm.FillControls();
        }

        private void DeleteClient_Click(object sender, RoutedEventArgs e)
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

                window.Show();
                window.Closed += CloseModalWindow;
                this.IsEnabled = false;
            }
        }

        private void CloseModalWindow(object sender, EventArgs e)
        {
            this.IsEnabled = true;
            this.customersGrid.ItemsSource = new List<Customer>();
        }
    }
}




