using Autofac;
using Model.Interfaces.Services;
using Services.Services;

namespace Services.Configurations
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerRequest();
        }

    }
}
