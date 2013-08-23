using System;
using System.Collections.Generic;
using System.Linq;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.BL.Mapping;
using MetricsCorporation.Entities;
using MetricsCorporation.Models;

namespace MetricsCorporation.BL.Services
{
    public class UserStatesService : ICrud<UserStatesModel>
    {
        private readonly Data.MetricsEntities _unit;
        private readonly object _locker = new object();
        private readonly IMapper _mapper;

        public UserStatesService(IMapper mapper)
        {
            lock (_locker)
            {
                if (_unit == null)
                {
                    _unit = new Data.MetricsEntities();
                    _mapper = mapper;
                }
            }
        }

        public UserStatesModel Create(UserStatesModel value)
        {
            throw new NotImplementedException();
        }

        public void CreateByUserId(string states, int userId)
        {
            var items = states.Split(',');
            if (items.Length == 1 && string.IsNullOrEmpty(items[0]))
                return;

            states.Split(',').ToList().ForEach(s => _unit.user_states.AddObject(new Data.user_states() { userId = userId, state_name = s }));

            _unit.SaveChanges();
        }

        public void Update(UserStatesModel value)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteByUserId(int id)
        {
            var states = _unit.user_states.Where(s => s.userId == id);

            foreach (var userState in states)
            {
                _unit.user_states.DeleteObject(userState);
            }

            _unit.SaveChanges();
        }

        public IEnumerable<UserStatesModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserStatesModel> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAllStatesByUserId(int id)
        {
            return _unit.user_states.Where(s => s.userId == id).Select(s => s.state_name);
        }

        public UserStatesModel Get(long id)
        {
            throw new NotImplementedException();
        }
    }
}
