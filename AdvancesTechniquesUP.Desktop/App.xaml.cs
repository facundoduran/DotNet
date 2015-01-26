using AdvancedTechniques.UP.Persistence.Sql;
using AdvancedTechniques.UP.Services;
using AdvancedTechniquesUP.Desktop.Interfaces;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AdvancedTechniquesUP.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            string dataDirectory = Directory.GetCurrentDirectory();

            AppDomain.CurrentDomain.SetData("DataDirectory", dataDirectory);

            IUnityContainer container = new UnityContainer();

            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));
            container.RegisterType<IBookingService, BookingService>();
            container.RegisterType<ITableService, TableService>();
            container.RegisterType<ICustomerService, CustomerService>();
            container.RegisterType<IDbContext, RestaurantDbContextAdapter>(new PerThreadLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>();

            container.RegisterType<ICreateCustomer, CreateCustomer>();

            var mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();

        }
    }
}
