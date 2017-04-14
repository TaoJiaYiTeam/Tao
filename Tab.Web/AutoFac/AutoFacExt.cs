using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Tao.Application;
using Tao.Repository;

namespace Tab.Web.AutoFac
{
    public class AutoFacExt
    {
        private static IContainer _container;
        private static readonly ContainerBuilder _builder = new ContainerBuilder();

        public static void RegisterApplication()
        {

            //注册AppService
            _builder.RegisterAssemblyTypes(typeof(ProductApp).Assembly)
                .Where(t => t.Name.EndsWith("App"));

            //注册DomainService
            //_builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(CompenateDomService))).Where
            //   (t => t.Name.EndsWith("Service"));

            //注册Repository
            _builder.RegisterAssemblyTypes(typeof(ProductRepo).Assembly)
                .Where(t => t.Namespace.Equals("Tao.Repository"))
                .AsImplementedInterfaces().InstancePerDependency();

        }

        public static ContainerBuilder Builder { get { return _builder; } }

        public static void SetContainer(IContainer container)
        {
            _container = container;
        }

        public static T GetFromFac<T>()
        {
            return _container.Resolve<T>();
        }
    }
}