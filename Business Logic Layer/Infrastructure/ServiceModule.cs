using Business_Logic_Layer.Interfaces;
using Business_Logic_Layer.Services;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Repository;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Infrastructure
{
    public class ServiceModule : NinjectModule
    {

        public ServiceModule()
        {

        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().InRequestScope();
        }
    }
}
