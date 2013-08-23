using System.Web.Http;
using System.Web.Mvc;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.BL.Mapping;
using MetricsCorporation.BL.Services;
using MetricsCorporation.Models;
using Microsoft.Practices.Unity;
using Unity.Mvc3;

namespace MetricsCorporation
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            // register dependency resolver for WebAPI RC
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
            // if you still use the beta version - change above line to:
            //GlobalConfiguration.Configuration.ServiceResolver.SetResolver(new Unity.WebApi.UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<ICrud<CombModel>, CombService>();
            container.RegisterType<ICrud<CountyModel>, CountyService>();
            container.RegisterType<ICrud<EmployeeSizeModel>, EmployeeSizeService>();
            container.RegisterType<ICrud<UserModel>, UserService>();
            container.RegisterType<ICrud<SearchLogModel>, SearchLogService>();
            container.RegisterType<ICrud<CompanyModel>, CompanyModelService>();
            container.RegisterType<ICrud<NumberOfLoginsModel>, NumberOfLoginsService>();
            container.RegisterType<ICrud<UserCreditsModel>, UserCreditsService>();
            container.RegisterType<ICrud<StateCountyModel>, StateCountyService>();
            container.RegisterType<ICrud<CompanyAutocompleteModel>, CompanyAutocompleteService>();
            container.RegisterType<ICrud<SicCodeModel>, SicCodeService>();
            container.RegisterType<ICrud<ClassCodeModel>, ClassCodeService>();
            //container.RegisterType<ICrud<CarrierNameModel>, CarrierNameService>();
            container.RegisterType<ICrud<CarrierNameAutocompleteModel>, carrierNameAutocompleteService>();
            container.RegisterType<IMapper, MetricsMapper>();

            return container;
        }
    }
}