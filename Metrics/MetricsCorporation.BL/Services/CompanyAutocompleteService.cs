using System.Collections.Generic;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.BL.Mapping;
using MetricsCorporation.Data;
using MetricsCorporation.Entities;
using MetricsCorporation.Models;
using System.Linq;

namespace MetricsCorporation.BL.Services
{
    public class CompanyAutocompleteService : ICrud<CompanyAutocompleteModel>
    {
        private readonly MetricsPrimaryDataModelEntities _unit;
        private readonly object _locker = new object();
        private readonly IMapper _mapper;

        public CompanyAutocompleteService(IMapper mapper)
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

        public CompanyAutocompleteModel Create(CompanyAutocompleteModel value)
        {
            var t = new MetricsCorporation.Data.MetricsPrimaryDataModelEntities();

            throw new System.NotImplementedException();
        }

        public void Update(CompanyAutocompleteModel value)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CompanyAutocompleteModel> GetAll()
        {
            return _mapper.Map<IEnumerable<primarydata>, IEnumerable<CompanyAutocompleteModel>>(_unit.primarydatas.Take(100));
        }

        public IEnumerable<CompanyAutocompleteModel> GetCompany(string description)
        {
            IQueryable<Data.primarydata> items = _unit.primarydatas;

            items = from p in items
                    where p.description.ToLower().StartsWith(description.ToLower())
                    select p;

            return _mapper.Map<IEnumerable<primarydata>, IEnumerable<CompanyAutocompleteModel>>(items.Take(100));
        }

        public IEnumerable<CompanyAutocompleteModel> GetAllById(int id)
        {
            throw new System.NotImplementedException();
        }

        public CompanyAutocompleteModel Get(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}
