using System.Collections.Generic;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.BL.Mapping;
using MetricsCorporation.Entities;
using MetricsCorporation.Models;

namespace MetricsCorporation.BL.Services
{
    public class CountyService : ICrud<CountyModel>
    {
        private readonly Data.MetricsEntities _unit;
        private readonly object _locker = new object();
        private readonly IMapper _mapper;

        public CountyService(IMapper mapper)
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


        public CountyModel Create(CountyModel value)
        {
            throw new System.NotImplementedException();
        }

        public void Update(CountyModel value)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CountyModel> GetAll()
        {
            return _mapper.Map<IEnumerable<Data.county>, IEnumerable<CountyModel>>(_unit.counties);
        }

        public IEnumerable<CountyModel> GetAllById(int id)
        {
            throw new System.NotImplementedException();
        }

        public CountyModel Get(long id)
        {
            throw new System.NotImplementedException();
        }

    }
}
