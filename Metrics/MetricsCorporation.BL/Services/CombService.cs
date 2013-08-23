using System.Collections.Generic;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.BL.Mapping;
using MetricsCorporation.EFCorePrim;
using MetricsCorporation.Entities;
using MetricsCorporation.Models;
using System.Linq;

namespace MetricsCorporation.BL.Services
{
    public class CombService : ICrud<CombModel>
    {
        private readonly MetricsPrimCombEntitesUnitOfWork _unit;
        private readonly object _locker = new object();
        private readonly IMapper _mapper;

        public CombService(IMapper mapper)
        {
            lock (_locker)
            {
                if (_unit == null)
                {
                    _unit = new MetricsPrimCombEntitesUnitOfWork();
                    _mapper = mapper;
                }
            }
        }

        public CombModel Create(CombModel value)
        {
            var t = new MetricsCorporation.Data.MetricsEntities();

            throw new System.NotImplementedException();
        }

        public void Update(CombModel value)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CombModel> GetAll()
        {
            return _mapper.Map<IEnumerable<comb>, IEnumerable<CombModel>>(_unit.combRepository.AllItems.Take(100));
        }

        public IEnumerable<CombModel> GetAllById(int id)
        {
            throw new System.NotImplementedException();
        }

        public CombModel Get(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}
