using System;
using System.Collections.Generic;
using System.Linq;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.BL.Mapping;
using MetricsCorporation.Entities;
using MetricsCorporation.Models;

namespace MetricsCorporation.BL.Services
{
    public class SicCodeService : ICrud<SicCodeModel>
    {
        private readonly Data.MetricsPrimaryDataModelEntities _unit;
        private readonly object _locker = new object();
        private readonly IMapper _mapper;

        public SicCodeService(IMapper mapper)
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

        public SicCodeModel Create(SicCodeModel value)
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

        public void Update(SicCodeModel value)
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

        public IEnumerable<SicCodeModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SicCodeModel> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SicCodeModel> GetAllSicCodes()
        {           
            return _mapper.Map<IEnumerable<Data.siccode>, IEnumerable<SicCodeModel>>(_unit.siccodes);
        }

        public SicCodeModel Get(long id)
        {
            throw new NotImplementedException();
        }

        public List<string> GetSicCodeByRange(string start, string end)
        {
            return _mapper.Map<IEnumerable<Data.siccode>, IEnumerable<SicCodeModel>>(_unit.siccodes).Where(p => p.SIC_4_Digit_Code.CompareTo(start) >= 0 && p.SIC_4_Digit_Code.CompareTo(end) <= 0).Select(p => p.SIC_4_Digit_Code).Distinct().ToList();            
        }
    }
}
