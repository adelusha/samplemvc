using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using ILogging;
using Logging;
using ServiceDesk.Infrastructure;
using ServiceDesk.Ticketing.CommandStack.Commands;
using ServiceDesk.Ticketing.CommandStack.Handlers;
using ServiceDesk.Ticketing.DataAccess;
using ServiceDesk.Ticketing.DataAccess.Repositories;
using ServiceDesk.Ticketing.Domain.CategoryAggregate;
using ServiceDesk.Ticketing.Domain.Events;
using ServiceDesk.Ticketing.Domain.TaskAggregate;
using ServiceDesk.Ticketing.Domain.TicketAggregate;
using ServiceDesk.Ticketing.Domain.UserAggregate;
using ServiceDesk.Ticketing.QueryStack;
using ServiceDeskSVC.DataAccess.Models;
using ServiceDeskSVC.WorkerServices;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ServiceDeskSVC
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            var scope = RegisterAutofac();
            var logger = (ILogger)scope.GetService(typeof(ILogger));
            
            logger.Info("Service Desk SVC started...");
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            using (var context = new ServiceDeskContext())
            {
                context.HelpDesk_Tickets.Count();
            }
        }

        private AutofacWebApiDependencyResolver RegisterAutofac()
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            var assemblyDomain = Assembly.Load("ServiceDeskSVC.Domain");
            var assemblyDataAccessServiceDesk = Assembly.Load("ServiceDeskSVC.DataAccess");
            var assemblyManagers = Assembly.Load("ServiceDeskSVC.Managers");

            var builder = new ContainerBuilder();
            builder.RegisterControllers(currentAssembly);
            builder.RegisterApiControllers(currentAssembly);
            builder.RegisterSource(new ViewRegistrationSource());

            ConfigureInfrastructureComponents(builder);
            ConfigureTicketingBoundedContext(builder);
            ConfigureAssetManagementBoundedContext(builder);

            // REGISTER DATABASE CONTEXTS

            builder.RegisterType<ServiceDeskContext>().InstancePerRequest();

            // REGISTER DataAccess ASSEMBLY REPOSITORIES

            builder.RegisterAssemblyTypes(assemblyDataAccessServiceDesk)
                .Where(x => x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            // REGISTER Domain ASSEMBLY SERVICES AND MANAGERS

            builder.RegisterAssemblyTypes(assemblyDomain)
                .Where(x => x.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder.RegisterAssemblyTypes(assemblyManagers)
                .Where(x => x.Name.EndsWith("Manager"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder.RegisterType<NSLogger>().As<ILogger>().SingleInstance();
            var container = builder.Build();

            // SET MVC RESOLVER

            // DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // SET WEBAPI RESOLVER

            var webAPIResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = webAPIResolver;
            return webAPIResolver;
        }

        private static void ConfigureInfrastructureComponents(ContainerBuilder builder)
        {
            builder.RegisterType<DefaultBus>().As<IBus>();
        }

        private void ConfigureTicketingBoundedContext(ContainerBuilder builder)
        {
            builder.RegisterType<TicketingDbContext>().InstancePerRequest();
            builder.RegisterType<TicketingQueryDatabase>().As<ITicketingQueryDatabase>().InstancePerRequest();

            //register worker services
            builder.RegisterType<TicketingControllerWorkerService>().InstancePerRequest();

            //TODO: register this type of components automatically based on whole assembly

            //register commands with handlers
            builder.RegisterType<CreateTicketCommandHandler>().As<IMessageHandler<CreateTicketCommand>>().InstancePerRequest();
            builder.RegisterType<CreateTaskCommandHandler>().As<IMessageHandler<CreateTaskCommand>>().InstancePerRequest();
            builder.RegisterType<UpdateTicketCommandHandler>().As<IMessageHandler<UpdateTicketCommand>>().InstancePerRequest();
            builder.RegisterType<CreateTicketCommentCommandHandler>().As<IMessageHandler<CreateTicketCommentCommand>>().InstancePerRequest();
            builder.RegisterType<UpdateTaskCommandHandler>().As<IMessageHandler<UpdateTaskCommand>>().InstancePerRequest();
            builder.RegisterType<RefreshUsersCommandHandler>().As<IMessageHandler<RefreshUsersCommand>>().InstancePerRequest();

            //registger events with handlers
            builder.RegisterType<TicketOpenedEventHandler>().As<IMessageHandler<TicketOpenedEvent>>(). InstancePerRequest();
            builder.RegisterType<TicketOpenedEventHandler2>().As<IMessageHandler<TicketOpenedEvent>>().InstancePerRequest();

            //register repositories
            builder.RegisterType<TicketRepository>().As<ITicketRepository>().InstancePerRequest();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerRequest();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().InstancePerRequest();

            //TODO: register this type of components automatically based on whole assembly
        }

        private void ConfigureAssetManagementBoundedContext(ContainerBuilder builder)
        {
            //this will get used later
        }
    }
}
