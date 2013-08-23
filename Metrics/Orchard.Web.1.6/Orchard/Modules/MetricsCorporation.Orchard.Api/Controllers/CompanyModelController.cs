using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.BL.Mapping;
using MetricsCorporation.Models;
using MetricsCorporation.BL.Services;
using Orchard;
using Orchard.Localization;
using Orchard.Mvc;

namespace MetricsCorporation.Orchard.Api.Controllers
{
    [Authorize]
    public class CompanyModelController : ApiController
    {
        private readonly ICrud<CompanyModel> _service;
        private readonly ICrud<ClassCodeModel> _serviceClassCode;
        private readonly ICrud<SearchLogModel> _serviceSearchLog;
        private readonly ICrud<UsageInfoModel> _serviceUsageInfo;
        private readonly ICrud<UserStatesModel> _serviceUserStates;
        private readonly ICrud<SicCodeModel> _serviceSicCodes;
        private readonly ICrud<CarrierNameAutocompleteModel> _serviceCarrierName;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _accessor;

        public IOrchardServices Services { get; set; }
        public Localizer T { get; set; }

        public CompanyModelController(IOrchardServices orchardServices, ICrud<CompanyModel> service, ICrud<SearchLogModel> serviceSearchLog, ICrud<UsageInfoModel> serviceUsageInfo, IMapper mapper, ICrud<UserStatesModel> serviceUserStates, ICrud<ClassCodeModel> serviceClassCode, ICrud<SicCodeModel> serviceSicCode, ICrud<CarrierNameAutocompleteModel> carrierService, IHttpContextAccessor accessor)
        {
            Services = orchardServices;
            T = NullLocalizer.Instance;

            _service = service;
            _serviceSearchLog = serviceSearchLog;
            _serviceUsageInfo = serviceUsageInfo;
            _serviceUserStates = serviceUserStates;
            _serviceClassCode = serviceClassCode;
            _serviceSicCodes = serviceSicCode;
            _serviceCarrierName = carrierService;

            _mapper = mapper;
            _accessor = accessor;
        }

        [HttpPost]
        public SearchResponseModel Get(SearchModel searchModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel currentUser = null;
                    List<string> States = new List<string>();
                    var session = _accessor.Current().Session;
                    if (session != null)
                        currentUser = session["CurrentUser"] as UserModel;

                    if (currentUser != null)
                    {
                        var searchLogModel = _mapper.Map<SearchModel, SearchLogModel>(searchModel);
                        if (!string.IsNullOrEmpty(searchModel.SearchName))
                        {
                            searchLogModel.UserId = currentUser.Id;
                            searchLogModel.SicCode = string.Join(",", searchModel.SicCodes);
                            searchLogModel.ClassCode = string.Join(",", searchModel.ClassCodes);
                            searchLogModel.PhoneEmp = searchModel.HasPhoneNumber;
                            _serviceSearchLog.Create(searchLogModel);
                        }

                        List<decimal?> carrierNumbers = new List<decimal?>();
                        foreach (string group in searchModel.CarrierGroups)
                        {
                            carrierNumbers.AddRange(((carrierNameAutocompleteService)_serviceCarrierName).GetCarrierGroupName(group.Trim()).ConvertAll<decimal?>(p => p));
                        }

                        carrierNumbers.AddRange(searchModel.CarrierNumbers.ToList());
                        searchModel.CarrierNumbers = carrierNumbers.ToArray();

                        List<string> classcodeitem = new List<string>();
                        List<string> sicCodeItem = new List<string>();
                        foreach (string classcode in searchModel.ClassCodes)
                        {
                            if (classcode.Length == 1)
                                classcodeitem.AddRange(((ClassCodeService)_serviceClassCode).GetClassCodeByPrefix(classcode));
                            else
                                classcodeitem.Add(classcode);
                        }
                        searchModel.ClassCodes = classcodeitem.ToArray();

                        foreach (string sicCode in searchModel.SicCodes)
                        {
                            if (sicCode.Split(',').Length == 2)
                                sicCodeItem.AddRange(((SicCodeService)_serviceSicCodes).GetSicCodeByRange(sicCode.Split(',')[0], sicCode.Split(',')[1]));
                            else
                                sicCodeItem.Add(sicCode);
                        }
                        searchModel.SicCodes = sicCodeItem.ToArray();

                        var companyModel = _mapper.Map<SearchModel, CompanyModel>(searchModel);
                        companyModel.UserId = currentUser.Id;
                        companyModel.ShowCarrier = currentUser.ShowCarrier;
                        companyModel.ShowStatusFld = currentUser.ShowStatusFld;

                        if (searchModel.States != null) { States = searchModel.States.ToList(); }

                        companyModel.States = ((UserStatesService)_serviceUserStates).GetAllStatesByUserId(currentUser.Id).ToList();

                        var response = ((CompanyModelService)_service).GetAllByCompanyModel(companyModel, States);

                        response.UserId = currentUser.Id;
                        response.ShowCarrier = currentUser.ShowCarrier;
                        response.ShowStatusFld = currentUser.ShowStatusFld;
                        return response;
                    }
                    else
                    {
                        var companyModel = _mapper.Map<SearchModel, CompanyModel>(searchModel);
                        States = searchModel.States.ToList();
                        return ((CompanyModelService)_service).GetAllByCompanyModel(companyModel, States);
                    }

                }

                return null;
            }
            catch (Exception ex) { return null; }
        }


        private string ClearCounty(string countyName)
        {
            if (string.IsNullOrEmpty(countyName)) return string.Empty;
            var arr = countyName.Split(',').ToList();
            arr.RemoveAll(t => string.IsNullOrWhiteSpace(t.ToLower()));
            return string.Join(",", arr);
        }


        //[HttpGet]
        //[ActionName("getbyid")]
        //[AllowAnonymous]
        //public CompanyModel Get(string id)
        //{
        //    return ((CompanyModelService)_service).Get(long.Parse(id));
        //}


        [HttpGet]
        [ActionName("getReport")]
        public CompanyModel GetReport(string id)
        {
            UserModel currentUser = null;
            var session = _accessor.Current().Session;
            if (session != null)
                currentUser = session["CurrentUser"] as UserModel;

            if (currentUser != null)
            {

                var reportItems = ((UsageInfoService)_serviceUsageInfo).
                GetByUserNameAndDate(currentUser.Email, currentUser.ReportsViewByMonth);

                if (currentUser.ReportsViewByMonth)
                {
                    if (reportItems.Count() < currentUser.MaxReportViewsPerMonth)
                    {
                        //get company
                        var companyModel = ((CompanyModelService)_service).GetById(id);

                        //save count for report view 
                        var usageModel = _mapper.Map<CompanyModel, UsageInfoModel>(companyModel);
                        usageModel.UserName = currentUser.Email;
                        _serviceUsageInfo.Create(usageModel);

                        return companyModel;
                    }
                }
                else
                {
                    if (reportItems.Count() < currentUser.MaxReportViewsPerYear)
                    {
                        //get company
                        var companyModel = ((CompanyModelService)_service).GetById(id);

                        //save count for report view 
                        var usageModel = _mapper.Map<CompanyModel, UsageInfoModel>(companyModel);
                        usageModel.UserName = currentUser.Email;
                        _serviceUsageInfo.Create(usageModel);

                        return companyModel;
                    }
                }


            }
            else
            {
                return ((CompanyModelService)_service).GetById(id);
            }

            return null;
        }


        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}