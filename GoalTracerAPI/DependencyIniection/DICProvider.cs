using Autofac;
using Autofac.Integration.WebApi;
using GoalTracerAPI.Models;
using System.Reflection;
using System.Web.Http;

namespace GoalTracerAPI.DependencyIniection
{
    public static class AutofacProvider
    {
        public static void BuildContainer(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterApiControllers(assembly);

            builder.RegisterAssemblyTypes(assembly)
                .AsImplementedInterfaces()
                .InstancePerRequest();

            config.DependencyResolver = new AutofacWebApiDependencyResolver( builder.Build());
        }
    }
}