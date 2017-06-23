
//O NINJECT e tipo um Hospedeiro, ele sobe(inicializar) junto com o projeto WEB
//Quem monitora o projeto na inicializa��o e finializa��o � o WebActivator
[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Unip.SuperSisAmigo.UI.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Unip.SuperSisAmigo.UI.Web.App_Start.NinjectWebCommon), "Stop")]

//Pra inicializar as dependencias (Classes) criamos um m�dulo injetor um m�dulo de inicializa��o de classes
//Existem diversas bibliotecas (Containers de Inicializa��o)
//Unity, Autofac, Simple Injector
//N�s estamos usasndo a biblioteca NINJECT


namespace Unip.SuperSisAmigo.UI.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Unip.SuperSisAmigos.Service;
    using Unip.SuperSisAmigo.DataAccess.Repository;
    using Unip.SuperSisAmigo.DataAccess;

    public static class NinjectWebCommon 
    {
        //Bootstrapper � uma palavra classica na programa��o, � o m�dulo inicializador do NINJECT
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
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
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //Nesse comando RegisterServices � onde fazemos as inicializa��es, as inje��es das classes via Ninject
            kernel.Bind<AmigoService>().To<AmigoService>();
            kernel.Bind<AmigoRepository>().To<AmigoRepository>();
            kernel.Bind<SexoRepository>().To<SexoRepository>();
            kernel.Bind<EstadoCivilRepository>().To<EstadoCivilRepository>();
            kernel.Bind<Conexao>().To<Conexao>();
        }        
    }
}
