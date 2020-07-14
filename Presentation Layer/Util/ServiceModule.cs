using Business_Logic_Layer.Interfaces;
using Business_Logic_Layer.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation_Layer.Util
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISoundService>().To<SoundService>();
            //Bind<ISoundService, SoundService>().To<SoundService>().InSingletonScope();//singleton
        }
    }
}