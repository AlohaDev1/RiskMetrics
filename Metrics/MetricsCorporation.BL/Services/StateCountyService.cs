using System.Collections.Generic;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.BL.Mapping;
using MetricsCorporation.Entities;
using MetricsCorporation.Models;
using Orchard;
using Orchard.Localization;
using Orchard.Mvc;
using System.Linq;


namespace MetricsCorporation.BL.Services
{
    public class StateCountyService : ICrud<StateCountyModel>
    {
        private readonly Data.MetricsPrimaryDataModelEntities _unit;
        private readonly ICrud<UserStatesModel> _serviceUserStates;
        private readonly IHttpContextAccessor _accessor;
        private readonly object _locker = new object();
        private readonly IMapper _mapper;

        public StateCountyService(IMapper mapper )
        {
            lock (_locker)
            {
                if (_unit == null)
                {
                    _unit = new Data.MetricsPrimaryDataModelEntities();
                    _mapper = mapper;
                   
                }
            }
        }


        public StateCountyModel Create(StateCountyModel value)
        {
            throw new System.NotImplementedException();
        }

        public void Update(StateCountyModel value)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<StateCountyModel> GetAll()
        {
            //UserModel currentUser = null;
            //var session = _accessor.Current().Session;
            //if (session != null)
            //    currentUser = session["CurrentUser"] as UserModel;
            //List<string> States = ((UserStatesService)_serviceUserStates).GetAllStatesByUserId(currentUser.Id).ToList();
            return _mapper.Map<IEnumerable<Data.statecountycode>, IEnumerable<StateCountyModel>>(_unit.statecountycodes);
        }

        public IEnumerable<StateCountyModel> GetAllByStatePrefix(List<string> States)
        {
            IQueryable<Data.statecountycode> items = _unit.statecountycodes;

            items = items.Where(a => States.Select(s => s.ToLower()).Contains(a.State_Prefix.ToLower()));

            return _mapper.Map<IEnumerable<Data.statecountycode>, IEnumerable<StateCountyModel>>(items);
        }

        public IQueryable<string> GetAllStates()
        {
            //IQueryable<string> items = _unit.statecountycodes.Distinct().Select(co => co.State_Description);
           IQueryable<string> items  = _unit.statecountycodes.Select(o => o.State_Description).Distinct();
            return items;
        }

        public IEnumerable<StateCountyModel> GetAllById(int id)
        {
            throw new System.NotImplementedException();
        }

        public StateCountyModel Get(long id)
        {
            throw new System.NotImplementedException();
        }


    }
}
