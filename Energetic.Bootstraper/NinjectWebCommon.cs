using System;
using System.Web;
using System.Web.Mvc;
using Energetic.Bootstraper;
using Energetic.Domain;
using Energetic.Repository;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using Ninject.Web.Mvc;
using WebActivatorEx;


[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: ApplicationShutdownMethod(typeof(NinjectWebCommon), "Stop")]
namespace Energetic.Bootstraper
{
        public static class NinjectWebCommon
        {
            private static readonly Ninject.Web.Common.Bootstrapper Bootstrapper = new Ninject.Web.Common.Bootstrapper();

            /// <summary>
            ///     Starts the application
            /// </summary>
            public static void Start()
            {
                DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
                DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
                Bootstrapper.Initialize(CreateKernel);
                DependencyResolver.SetResolver(new NinjectDependencyResolver(CreateKernel()));
            }

            /// <summary>
            ///     Stops the application.
            /// </summary>
            public static void Stop()
            {
                Bootstrapper.ShutDown();
            }

            /// <summary>
            ///     Creates the kernel that will manage your application.
            /// </summary>
            /// <returns>The created kernel.</returns>
            private static IKernel CreateKernel()
            {
                var kernel = new StandardKernel();
                try
                {
                    kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                    kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                    RegisterServices(kernel);
                    return kernel;
                }
                catch
                {
                    kernel.Dispose();
                    throw;
                }
            }

            /// <summary>
            ///     Load your modules or register your services here!
            /// </summary>
            /// <param name="kernel">The kernel.</param>
            private static void RegisterServices(IKernel kernel)
            {
                kernel.Bind<IDataProvider>().To<DataProvider>();
                kernel.Bind<IDataService>().To<DataService>();
            }
        }
    }
