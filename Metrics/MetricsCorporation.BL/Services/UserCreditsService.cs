using System;
using System.Collections.Generic;
using System.Linq;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.BL.Mapping;
using MetricsCorporation.Entities;
using MetricsCorporation.Models;

namespace MetricsCorporation.BL.Services
{
    public class UserCreditsService : ICrud<UserCreditsModel>
    {
        private readonly Data.MetricsEntities _unit;
        private readonly object _locker = new object();
        private readonly IMapper _mapper;

        public UserCreditsService(IMapper mapper)
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

        public UserCreditsModel Create(UserCreditsModel value)
        {
            throw new NotImplementedException();
        }

        public void Update(UserCreditsModel value)
        {
            //_unit.usercreditRepository.Update(_mapper.Map<UserCreditsModel, usercredit>(value));

            var dbItem = _unit.usercredits.FirstOrDefault(i => i.user_id == value.UserId);
            if (dbItem != null)
                dbItem.credits = value.Credits;
            
            _unit.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserCreditsModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserCreditsModel> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public UserCreditsModel Get(long id)
        {
            throw new NotImplementedException();
        }

        public UserCreditsModel GetByUserId(int id)
        {
            return _mapper.Map<Data.usercredit, UserCreditsModel>(_unit.usercredits.FirstOrDefault(i => i.user_id == id));
        }
    }
}
