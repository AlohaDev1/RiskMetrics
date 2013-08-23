using Autofac;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.BL.Mapping;
using MetricsCorporation.BL.Services;
using MetricsCorporation.Models;

namespace MetricsCorporation.Orchard.Api
{
    public class ApiAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MetricsMapper>().As<IMapper>();
            //builder.RegisterType<FileListService>().As<ICrud<FileListModel>>();
            builder.RegisterType<CompanyModelService>().As<ICrud<CompanyModel>>();
            //builder.RegisterType<MasterIdService>().As<ICrud<MasterIdModel>>();
            builder.RegisterType<NumberOfLoginsService>().As<ICrud<NumberOfLoginsModel>>();
            builder.RegisterType<SearchLogService>().As<ICrud<SearchLogModel>>();
            builder.RegisterType<CountyService>().As<ICrud<CountyModel>>();
            builder.RegisterType<CombService>().As<ICrud<CombModel>>();
            builder.RegisterType<EmployeeSizeService>().As<ICrud<EmployeeSizeModel>>();
            builder.RegisterType<UserCreditsService>().As<ICrud<UserCreditsModel>>();
            builder.RegisterType<UsageInfoService>().As<ICrud<UsageInfoModel>>();
            builder.RegisterType<ExportedService>().As<ICrud<ExportedModel>>();
            builder.RegisterType<UserStatesService>().As<ICrud<UserStatesModel>>();
            builder.RegisterType<UserService>().As<ICrud<UserModel>>();
            builder.RegisterType<StateCountyService>().As<ICrud<StateCountyModel>>();
            builder.RegisterType<CompanyAutocompleteService>().As<ICrud<CompanyAutocompleteModel>>();
            builder.RegisterType<SicCodeService>().As<ICrud<SicCodeModel>>();
            builder.RegisterType<ClassCodeService>().As<ICrud<ClassCodeModel>>();
            builder.RegisterType<carrierNameAutocompleteService>().As<ICrud<CarrierNameAutocompleteModel>>();
        }
    }
}