namespace SportsStore.WebUI.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Ninject;
    using SportsStore.Domain.Abstract;
    using SportsStore.Domain.Concrete;

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
            kernel.Bind<IProductsRepository>().To<EFProductRepository>();
        }
    }
}