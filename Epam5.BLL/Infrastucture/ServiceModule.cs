using Epam5.ADODAL.Repositories;
using Epam5.EFDAL.Interfaces;
using Epam5.EFDAL.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epam5.BLL.Infrastucture
{
    class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<IUnitOfWork>().To<EFUnitOfWork>();
        }
    }
}
