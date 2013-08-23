
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.BL.Services;
using MetricsCorporation.Models;
using MetricsCorporation.BL.Mapping;
using System.Data.Sql;
using Orchard;
using Orchard.Localization;
using Orchard.Mvc;

namespace MetricsCorporation.Orchard.Api.Controllers
{
    [Authorize]
    public class UsageInfoController : ApiController
    {
        private readonly ICrud<UsageInfoModel> _usageService;
        public IOrchardServices Services { get; private set; }
        public Localizer T { get; set; }
        private readonly IHttpContextAccessor _accessor;
        private readonly IMapper _mapper;
        private readonly ICrud<UsageInfoModel> _serviceUsageInfo;
        private readonly ICrud<CompanyModel> _service;


        public UsageInfoController(ICrud<CompanyModel> service, ICrud<UsageInfoModel> serviceUsageInfo, IMapper mapper, IHttpContextAccessor accessor, IOrchardServices orchardServices, ICrud<UsageInfoModel> usageService)
        {
            Services = orchardServices;
            T = NullLocalizer.Instance;
            _usageService = usageService;
            _accessor = accessor;
            _serviceUsageInfo = serviceUsageInfo;
            _mapper = mapper;
            _service = service;
        }


        public IEnumerable<UsageInfoModel> Get(string userName)
        {
            return ((UsageInfoService)_usageService).GetAllByName(userName).OrderByDescending(o => o.CreatedAt);
        }

        [HttpGet]
        [ActionName("VerifyGetReport")]
        public ViewreportModel VerifyGetReport(string reportId)
        {

            UserModel currentUser = null;
            ViewreportModel result = new ViewreportModel();

            var session = _accessor.Current().Session;
            if (session != null)
            {
                currentUser = session["CurrentUser"] as UserModel;

                var reportItems = ((UsageInfoService)_serviceUsageInfo).
                GetByUserNameAndDate(currentUser.Email, !(currentUser.ReportsViewByMonth));

                if (currentUser.ReportsViewByMonth)
                {
                    if (reportItems.Count() < currentUser.MaxReportViewsPerMonth)
                    {
                        //commented by aloha
                        //var companyModel = ((CompanyModelService)_service).GetById(reportId);

                        //get company
                        CompanyModel companyModel = ((CompanyModelService)_service).GetPrimaryById(reportId);

                        //save count for report view 
                        var usageModel = _mapper.Map<CompanyModel, UsageInfoModel>(companyModel);
                        usageModel.UserName = currentUser.Email;
                        _serviceUsageInfo.Create(usageModel);

                        result.Company = companyModel;
                        result.ViewReportbit = true;
                        return result;
                        //return true;
                    }
                }
                else
                {
                    if (reportItems.Count() < currentUser.MaxReportViewsPerYear)
                    {
                        //commented by aloha
                        //var companyModel = ((CompanyModelService)_service).GetById(reportId);

                        //get company
                        var companyModel = ((CompanyModelService)_service).GetPrimaryById(reportId);

                        //save count for report view 
                        var usageModel = _mapper.Map<CompanyModel, UsageInfoModel>(companyModel);
                        usageModel.UserName = currentUser.Email;
                        _serviceUsageInfo.Create(usageModel);

                        result.Company = companyModel;
                        result.ViewReportbit = true;
                        //return true;
                        return result;
                    }
                }
                result.ViewReportbit = false;
                return result;
                //return false;
            }

            //TODO: not return true, need clear auth when session null
            result.ViewReportbit = true;
            return result;

            //return true;

        }

        //[ActionName("GetAdditionalInfo")]
        //public string GetAdditionalInfo(string companyId)
        //{
        //    return ((CompanyModelService)_service).GetAdditionalInformation(companyId);
        //}

    }
}