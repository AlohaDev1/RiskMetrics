using System.Collections.Generic;
using System.Web.Http;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.BL.Mapping;
using MetricsCorporation.Helpers;
using MetricsCorporation.Models;
using MetricsCorporation.BL.Services;

namespace MetricsCorporation.Controllers
{
    [Authorize]
    public class CompanyModelController : ApiController
    {
        private readonly ICrud<CompanyModel> _service;
        private readonly ICrud<SearchLogModel> _serviceSearchLog;
        private readonly IMapper _mapper;

        public CompanyModelController(ICrud<CompanyModel> service, ICrud<SearchLogModel> serviceSearchLog, IMapper mapper)
        {
            _service = service;
            _serviceSearchLog = serviceSearchLog;
            _mapper = mapper;
        }

        [HttpPost]
        public SearchResponseModel Get(SearchModel searchModel)
        {
            if (ModelState.IsValid)
            {
                List<string> States = new List<string>();
                var searchLogModel = _mapper.Map<SearchModel, SearchLogModel>(searchModel);
                if (!string.IsNullOrEmpty(searchModel.SearchName))
                {
                    
                    searchLogModel.UserId = SessionHelper.CurrentUser.Id;
                    _serviceSearchLog.Create(searchLogModel);    
                }

                var companyModel = _mapper.Map<SearchModel, CompanyModel>(searchModel);
                companyModel.UserId = SessionHelper.CurrentUser.Id;
                
                return ((CompanyModelService)_service).GetAllByCompanyModel(companyModel,States);
            }

            return null;
        }

        // GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //public void PostCreate([FromBody]string value)
        //{
        //}

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