
using System.Collections.Generic;
using System.Web.Http;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.BL.Services;
using MetricsCorporation.Models;

using Orchard;
using Orchard.Localization;

namespace MetricsCorporation.Orchard.Api.Controllers
{
    [Authorize]
    public class SearchLogsController : ApiController
    {
        private readonly ICrud<SearchLogModel> _searchLogService;
        public IOrchardServices Services { get; private set; }
        public Localizer T { get; set; }

        public SearchLogsController(IOrchardServices orchardServices, ICrud<SearchLogModel> searchLogService)
        {
            Services = orchardServices;
            T = NullLocalizer.Instance;
            _searchLogService = searchLogService;
        }

        
        public IEnumerable<SearchLogModel> Get(int userId)
        {
            return ((SearchLogService) _searchLogService).GetAllByUserId(userId);
        }

    }

  

}