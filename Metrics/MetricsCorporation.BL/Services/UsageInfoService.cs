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
    public class UsageInfoService : ICrud<UsageInfoModel>
    {
        private readonly Data.MetricsEntities _unit;
        private readonly object _locker = new object();
        private readonly IMapper _mapper;

        public UsageInfoService(IMapper mapper)
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

        public UsageInfoModel Create(UsageInfoModel value)
        {
            
            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
            {
                var dbItem = _mapper.Map<UsageInfoModel, Data.usageinfo>(value);
                dbItem.createdAt = DateTime.Now;

                _unit.usageinfoes.AddObject(dbItem);
                _unit.SaveChanges();

                return _mapper.Map<Data.usageinfo, UsageInfoModel>(dbItem);
            }

        }

        public void Update(UsageInfoModel value)
        {
            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
            {
                _unit.usageinfoes.Attach(_mapper.Map<UsageInfoModel, Data.usageinfo>(value));
                _unit.SaveChanges();
            }

        }

        public void Delete(int id)
        {
            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
            {
                _unit.searchlogs.DeleteObject(_unit.searchlogs.FirstOrDefault(u=>u.id == id));
                _unit.SaveChanges();
            }
        }

        public IEnumerable<UsageInfoModel> GetAll()
        {
            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
            {
                return _mapper.Map<IEnumerable<Data.usageinfo>, IEnumerable<UsageInfoModel>>(_unit.usageinfoes);
            }
        }

        public IEnumerable<UsageInfoModel> GetAllById(int id)
        {
            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
            {

                var items = _unit.usageinfoes.Where(i => i.id == id);

                return _mapper.Map<IEnumerable<Data.usageinfo>, IEnumerable<UsageInfoModel>>(items);
            }
        }

        public IEnumerable<UsageInfoModel> GetAllByName(string userName)
        {
            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
            {

                var items = _unit.usageinfoes.Where(i => i.username.Equals(userName));

                return _mapper.Map<IEnumerable<Data.usageinfo>, IEnumerable<UsageInfoModel>>(items);
            }
        }

        public IEnumerable<UsageInfoModel> GetByUserNameAndDate(string userName, bool onlyYear, DateTime? date = null)
        {
            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
            {
                var dateToCompare = date.HasValue ? date : DateTime.Now;
                IEnumerable<Data.usageinfo> items;
                if (onlyYear)
                {
                    items = _unit.usageinfoes.Where(i => i.username.Equals(userName))
                        .Where(u => u.createdAt.Value.Year == dateToCompare.Value.Year
                                && u.createdAt.Value.Month == dateToCompare.Value.Month);
                }
                else
                {
                    items = _unit.usageinfoes.Where(i => i.username.Equals(userName))
                       .Where(u => u.createdAt.Value.Year == dateToCompare.Value.Year);
                }
               
                return _mapper.Map<IEnumerable<Data.usageinfo>, IEnumerable<UsageInfoModel>>(items);
            }
        }


        public UsageInfoModel Get(long id)
        {
            throw new NotImplementedException();
        }

        public int GetAllByEmail(string email)
        {
            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
            {
                var items = _unit.usageinfoes.Where(i => i.username == email);
                return _mapper.Map<IEnumerable<Data.usageinfo>, IEnumerable<UsageInfoModel>>(items).Count();
            }
        }
    }
}
