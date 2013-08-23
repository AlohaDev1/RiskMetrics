using System.Collections.Generic;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.BL.Mapping;
using MetricsCorporation.Data;
using MetricsCorporation.Entities;
using MetricsCorporation.Models;
using System.Linq;

namespace MetricsCorporation.BL.Services
{
    public class carrierNameAutocompleteService : ICrud<CarrierNameAutocompleteModel>
    {
        private readonly MetricsPrimaryDataModelEntities _unit;
        private readonly object _locker = new object();
        private readonly IMapper _mapper;

        public carrierNameAutocompleteService(IMapper mapper)
        {
            lock (_locker)
            {
                if (_unit == null)
                {
                    _unit = new MetricsPrimaryDataModelEntities();
                    _mapper = mapper;
                }
            }
        }

        public CarrierNameAutocompleteModel Create(CarrierNameAutocompleteModel value)
        {
            var t = new MetricsCorporation.Data.MetricsPrimaryDataModelEntities();

            throw new System.NotImplementedException();
        }

        public void Update(CarrierNameAutocompleteModel value)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CarrierNameAutocompleteModel> GetAll()
        {
            return _mapper.Map<IEnumerable<carrier>, IEnumerable<CarrierNameAutocompleteModel>>(_unit.carriers.Take(100));
        }

        public IEnumerable<CarrierNameAutocompleteModel> GetCarrier()
        {
            return _mapper.Map<IEnumerable<carrier>, IEnumerable<CarrierNameAutocompleteModel>>(_unit.carriers); ;
        }

        public IEnumerable<CarrierNameAutocompleteModel> GetAllById(int id)
        {
            throw new System.NotImplementedException();
        }

        public CarrierNameAutocompleteModel Get(long id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CarrierNameAutocompleteModel> GetCarrierGroupAndName()
        {
            return _mapper.Map<IEnumerable<Data.carrier>, IEnumerable<CarrierNameAutocompleteModel>>(_unit.carriers);
        }

        public List<decimal> GetCarrierGroupName(string groupName)
        {
            return _unit.carriers.Where(p => p.naicGroupName == groupName).Select(p => p.naicNumber).ToList();
        }

    }
}
