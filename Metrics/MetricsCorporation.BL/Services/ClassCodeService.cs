using System;
using System.Collections.Generic;
using System.Linq;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.BL.Mapping;
using MetricsCorporation.Entities;
using MetricsCorporation.Models;

namespace MetricsCorporation.BL.Services
{
    public class ClassCodeService : ICrud<ClassCodeModel>
    {
        private readonly Data.MetricsPrimaryDataModelEntities _unit;
        private readonly object _locker = new object();
        private readonly IMapper _mapper;

        public ClassCodeService(IMapper mapper)
        {
            lock (_locker)
            {
                if (_unit == null)
                {
                    _unit = new Data.MetricsPrimaryDataModelEntities();
                    _mapper = mapper;
                }
            }
        }

        public ClassCodeModel Create(ClassCodeModel value)
        {
            throw new NotImplementedException();
        }

        //public void CreateByUserId(string states, int userId)
        //{
        //    var items = states.Split(',');
        //    if (items.Length == 1 && string.IsNullOrEmpty(items[0]))
        //        return;

        //    states.Split(',').ToList().ForEach(s => _unit.user_states.AddObject(new Data.user_states() { userId = userId, state_name = s }));

        //    _unit.SaveChanges();
        //}

        public void Update(ClassCodeModel value)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        //public void DeleteByUserId(int id)
        //{
        //    var states = _unit.user_states.Where(s => s.userId == id);

        //    foreach (var userState in states)
        //    {
        //        _unit.user_states.DeleteObject(userState);
        //    }

        //    _unit.SaveChanges();
        //}

        public IEnumerable<ClassCodeModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClassCodeModel> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClassCodeModel> GetAllClassCodes()
        {                    
            return _mapper.Map<IEnumerable<Data.classcode>, IEnumerable<ClassCodeModel>>(_unit.classcodes);
        }

        public List<string> GetClassCodeByPrefix(string prefix)
        {
            return _mapper.Map<IEnumerable<Data.classcode>, IEnumerable<ClassCodeModel>>(_unit.classcodes).Where(p => p.Code.StartsWith(prefix)).Select(x => x.Code).Distinct().ToList();            
        }    

        public ClassCodeModel Get(long id)
        {
            throw new NotImplementedException();
        }
    }
}
