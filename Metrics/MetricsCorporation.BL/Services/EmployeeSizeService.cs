using System;
using System.Collections.Generic;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.BL.Mapping;
using MetricsCorporation.Entities;
using MetricsCorporation.Models;

namespace MetricsCorporation.BL.Services
{
    public class EmployeeSizeService : ICrud<EmployeeSizeModel>
    {
        private readonly Data.MetricsEntities _unit;
        private readonly object _locker = new object();
        private readonly IMapper _mapper;

        public EmployeeSizeService(IMapper mapper)
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


        public EmployeeSizeModel Create(EmployeeSizeModel value)
        {
            throw new NotImplementedException();
        }

        public void Update(EmployeeSizeModel value)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeSizeModel> GetAll()
        {
            return _mapper.Map<IEnumerable<Data.employeesize>, IEnumerable<EmployeeSizeModel>>(_unit.employeesizes);
        }

        public IEnumerable<EmployeeSizeModel> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public EmployeeSizeModel Get(long id)
        {
            throw new NotImplementedException();
        }
    }
}
