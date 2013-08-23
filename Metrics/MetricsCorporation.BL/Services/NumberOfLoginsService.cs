using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.BL.Mapping;
using MetricsCorporation.Entities;
using MetricsCorporation.Models;

namespace MetricsCorporation.BL.Services
{
    public class NumberOfLoginsService : ICrud<NumberOfLoginsModel>
    {
        private readonly Data.MetricsEntities _unit;
        private readonly object _locker = new object();
        private readonly IMapper _mapper;

        public NumberOfLoginsService(IMapper mapper)
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

        public NumberOfLoginsModel Create(NumberOfLoginsModel value)
        {
            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
            {
                var dbItem = _mapper.Map<NumberOfLoginsModel, Data.number_of_logins>(value);

                var obj = _unit.number_of_logins.FirstOrDefault(p => p.userId == dbItem.userId && p.loginDate.Year == dbItem.loginDate.Year &&
                        p.loginDate.Month == dbItem.loginDate.Month &&
                        p.loginDate.Day == dbItem.loginDate.Day);

                if (obj == null)
                {
                    dbItem.loginCount = 1;
                    _unit.number_of_logins.AddObject(dbItem);
                }
                else
                {
                    obj.loginCount++;
                    //_unit.number_of_logins.Attach(obj);
                }

                _unit.SaveChanges();

                return _mapper.Map<Data.number_of_logins, NumberOfLoginsModel>(dbItem);
            }   
        }

        public void Update(NumberOfLoginsModel value)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NumberOfLoginsModel> GetAll()
        {
            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
            {
                return _mapper.Map<IEnumerable<Data.number_of_logins>, IEnumerable<NumberOfLoginsModel>>(_unit.number_of_logins);
            }
        }

        public IEnumerable<NumberOfLoginsModel> GetAllById(int id)
        {
            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
            {
                return _mapper.Map<IEnumerable<Data.number_of_logins>, IEnumerable<NumberOfLoginsModel>>(_unit.number_of_logins.Where(u=> u.userId == id));
            }
        }

        //public IEnumerable<NumberOfLoginsModel> GetAllByName(int name)
        //{
        //    using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
        //    {
        //        return _mapper.Map<IEnumerable<number_of_logins>, IEnumerable<NumberOfLoginsModel>>(_unit.number_of_loginsRepository.AllItems.Where(i=>i.));
        //    }
        //}

        public NumberOfLoginsModel Get(long id)
        {
            throw new NotImplementedException();
        }

        public NumberOfLoginsModel CreateModel(number_of_logins k)
        {
            throw new NotImplementedException();
        }
    }
}
