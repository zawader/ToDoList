[assembly: WebActivator.PostApplicationStartMethod(typeof(ToDoList.Infra.CrossCutting.Ioc.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace ToDoList.Infra.CrossCutting.Ioc.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;

    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    using ToDoList.App.AppServices;
    using ToDoList.App.Interface;
    using ToDoList.Domain.Interface.Repositories;
    using ToDoList.Domain.Services;
    using ToDoList.Infra.Data.Repositories;

    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
            container.Register<IToDoAppService, ToDoAppService>(Lifestyle.Scoped);
            container.Register<ToDoService, ToDoService>(Lifestyle.Scoped);
            container.Register<IToDoRepository, ToDoRepository>(Lifestyle.Scoped);

        }
    }
}