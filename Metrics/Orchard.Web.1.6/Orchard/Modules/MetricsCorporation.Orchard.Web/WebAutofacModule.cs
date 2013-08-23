using Autofac;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.BL.Mapping;
using MetricsCorporation.BL.Services;
using MetricsCorporation.Models;
using MetricsCorporation.Orchard.Api.Controllers;

namespace MetricsCorporation.Orchard.Web
{
    public class WebAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            
            builder.RegisterType<MetricsMapper>().As<IMapper>();

            builder.RegisterType<UserService>().As<ICrud<UserModel>>();
            builder.RegisterType<NumberOfLoginsService>().As<ICrud<NumberOfLoginsModel>>();
            
        }
    }
}