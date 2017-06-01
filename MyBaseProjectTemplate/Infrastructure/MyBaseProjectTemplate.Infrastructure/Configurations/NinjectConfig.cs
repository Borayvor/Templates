using System;
using MyBaseProjectTemplate.Data.Common;
using MyBaseProjectTemplate.Data.Common.Repositories;
using MyBaseProjectTemplate.Data.Contracts;
using Ninject;
using Ninject.Web.Common;

namespace MyBaseProjectTemplate.Infrastructure.Configurations
{


    public static class NinjectConfig
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static IKernel Kernel
        {
            get;
            private set;
        }

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        public static IKernel CreateKernel()
        {
            Kernel = new StandardKernel();
            try
            {
                Kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                ////Kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(Kernel);

                return Kernel;
            }
            catch
            {
                Kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IMyBaseProjectTemplateEfDBContext>().To<MyBaseProjectTemplateEfDBContext>().InRequestScope();
            kernel.Bind<IDbContextSaveChanges>().To<MyBaseProjectTemplateEfDBContext>().InRequestScope();

            kernel.Bind(typeof(IRepository<>)).To(typeof(EfRepository<>)).InRequestScope();
        }
    }
}
