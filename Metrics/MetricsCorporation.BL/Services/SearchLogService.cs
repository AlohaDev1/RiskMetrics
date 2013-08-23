using System;
using System.Linq;
using System.Collections.Generic;
using System.Transactions;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.BL.Mapping;
using MetricsCorporation.Entities;
using MetricsCorporation.Models;

namespace MetricsCorporation.BL.Services
{
    public class SearchLogService : ICrud<SearchLogModel>
    {
        private readonly Data.MetricsEntities _unit;
        private readonly object _locker = new object();
        private readonly IMapper _mapper;

        public SearchLogService(IMapper mapper)
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

        public SearchLogModel Create(SearchLogModel value)
        {

            if (value.Description == null) value.Description = string.Empty;
            if (value.SicCode == null) value.SicCode = string.Empty;
            
            var dbItem = _unit.searchlogs.FirstOrDefault(t => t.searchname.ToLower() == value.SearchName.ToLower());
            if (dbItem == null)
            {
                _unit.searchlogs.AddObject(_mapper.Map<SearchLogModel, Data.searchlog>(value));
                _unit.SaveChanges();
            }
                
            return _mapper.Map<Data.searchlog, SearchLogModel>(dbItem);

        }

        public void Update(SearchLogModel value)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SearchLogModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SearchLogModel> GetAllById(int id)
        {
            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
            {
                var items = _unit.searchlogs.OrderByDescending(p => p.qui).Where(p => p.id == id).Take(10);
                return _mapper.Map<IEnumerable<Data.searchlog>, IEnumerable<SearchLogModel>>(items);
            }
        }

        public IEnumerable<SearchLogModel> GetAllByUserId(int id)
        {
            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
            {
                var items = _unit.searchlogs.Where(p => p.id == id).ToList();
                return _mapper.Map<IEnumerable<Data.searchlog>, IEnumerable<SearchLogModel>>(items);
            }

        }

        public SearchLogModel Get(long id)
        {
            throw new NotImplementedException();
        }


    }
}
