using Autofac;
using Autofac.Integration.WebApi;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Web.Http;

namespace GoalTracerAPI.DependencyIniection
{
    public static class AutofacProvider
    {

        public static IContainer Container { get; set; }
        public static void BuildContainer(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterApiControllers(assembly);

            builder.RegisterAssemblyTypes(assembly)
                    .AsImplementedInterfaces()
                    .AsSelf()
                    .InstancePerRequest();

            foreach (var asm in GetAssemblies())
                builder.RegisterAssemblyTypes(asm)
                    .AsImplementedInterfaces()
                    .AsSelf()
                    .InstancePerRequest();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            Container = container;
        }

        private static IEnumerable<Assembly> GetAssemblies()
        {
            var projects = new List<string>
            {
                "Infrastructure",
                "ApplicationCore"
            };
            var x = typeof(AutofacProvider).Assembly.GetReferencedAssemblies();
            var ret = new List<Assembly>();

            foreach (var asmName in x)
            {
                if (projects.Contains(asmName.Name))
                    ret.Add(Assembly.Load(asmName));
            }

            return ret;
        }
    }
}