using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace AdvancedTechniques.Web.App_Start
{
    public class UnityServiceHost : ServiceHost
    {
        public UnityServiceHost()
            : base()
        {
        }

        public UnityServiceHost(Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
        }

        protected override void OnOpening()
        {
            this.Description.Behaviors.Add(new UnityServiceBehavior());
            base.OnOpening();
        }
    }
}