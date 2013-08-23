using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.BL.Mapping;
using MetricsCorporation.BL.Services;
using MetricsCorporation.Models;

using Orchard;
using Orchard.Localization;

namespace MetricsCorporation.Orchard.Api.Controllers
{
    [Authorize]
    public class NumberOfLoginsController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ICrud<NumberOfLoginsModel> _service;
        private readonly ICrud<UserModel> _userService;
        private readonly ICrud<SearchLogModel> _searchLogService;
        private readonly ICrud<UsageInfoModel> _serviceUsageInfo;
        public IOrchardServices Services { get; private set; }
        public Localizer T { get; set; }

        public NumberOfLoginsController(IOrchardServices orchardServices, ICrud<NumberOfLoginsModel> service, ICrud<UserModel> userService, ICrud<SearchLogModel> searchLogservice, ICrud<UsageInfoModel> serviceUsageInfo)
        {
            Services = orchardServices;
            T = NullLocalizer.Instance;
            _mapper = new MetricsMapper();
            _service = service;
            _userService = userService;
            _searchLogService = searchLogservice;
            _serviceUsageInfo = serviceUsageInfo;
        }

        // GET api/NumberOfLogins
        //public IEnumerable<NumberOfLoginsModel> Get()
        //{
        //    return _service.GetAll();
        //}
        public IEnumerable<UserModel> Get()
        {
            var users = _userService.GetAll().ToList();
            var numberOfLogins = _service.GetAll().ToList();

            foreach (var userModel in users)
            {
                UserModel model = userModel;
                userModel.LoginCount = numberOfLogins.Where(u => u.UserId == model.Id).Sum(u => u.Count);
                userModel.TotalReportsViewed = ((UsageInfoService)_serviceUsageInfo).GetAllById(userModel.Id).Count(); ;

                var numberOfLoginsModel = numberOfLogins.Where(u => u.UserId == model.Id).OrderByDescending(d => d.LoginDate).FirstOrDefault();
                if (numberOfLoginsModel != null)
                    userModel.LastLoginDate = numberOfLoginsModel.LoginDate;
            }

            return users;
        }


        // GET api/NumberOfLogins/5
        public IEnumerable<NumberOfLoginsModel> Get(int userId)
        {
            return _service.GetAllById(userId).OrderByDescending(n => n.LoginDate);
        }

        // POST api/NumberOfLogins
        public NumberOfLoginsModel Post(NumberOfLoginsModel value)
        {
            if (ModelState.IsValid)
            {
                return _service.Create(value);
            }

            return null;
        }
    }



}