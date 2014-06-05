using System;
using System.Collections.Generic;

namespace EssentialTools.Infrastructure
{
    using System.Web.Mvc;
    using EssentialTools.Models;
    using Ninject;
    using Ninject.Web.Common;

    public class NinjectDependencyResolver : IDependencyResolver
    {
        readonly IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        void AddBindings()
        {
            kernel.Bind<IValueCalculator>().To<LinqValueCalculator>().InRequestScope();
            //kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithPropertyValue("DiscountSize", 50M);
            kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithConstructorArgument("discountSize", 50M);
            kernel.Bind<IDiscountHelper>().To<FlexibleDiscountHelper>().WhenInjectedInto<LinqValueCalculator>();
        }
    }
}