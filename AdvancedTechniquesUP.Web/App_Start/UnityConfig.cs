using System.Web.Mvc;
using AdvancedTechniques.UP.Persistence.Sql;
using AdvancedTechniques.UP.Services;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Microsoft.AspNet.SignalR;
using AdvancedTechniques.Web.SignalR;
using AdvancedTechniques.Web.App_Start;

namespace AdvancedTechniques.UP.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));
            //container.RegisterType(typeof(IService<>), typeof(IService<>));

            container.RegisterType<IBookingService, BookingService>();
            container.RegisterType<ITableService, TableService>();
            container.RegisterType<ICustomerService, CustomerService>();

            container.RegisterType<IDbContext, RestaurantDbContextAdapter>(new PerThreadLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            //For SignalR
            GlobalHost.DependencyResolver = new SignalRUnityDependencyResolver(container);
            container.RegisterType<OffersByDateHub>(new InjectionFactory(CreateMyHub));
        }

        private static object CreateMyHub(IUnityContainer p)
        {
            var myHub = new OffersByDateHub(p.Resolve<IBookingService>());

            return myHub;
        }
    }
}