//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Transactions;
//using MetricsCorporation.BL.Interfaces;
//using MetricsCorporation.BL.Mapping;
//using MetricsCorporation.Entities;
//using MetricsCorporation.Models;

//namespace MetricsCorporation.BL.Services
//{
//    public class MasterIdService : ICrud<MasterIdModel>
//    {
//        private readonly Data.MetricsEntities _unit;
//        private readonly object _locker = new object();
//        private readonly IMapper _mapper;

//        public MasterIdService(IMapper mapper)
//        {
//            lock (_locker)
//            {
//                if (_unit == null)
//                {
//                    _unit = new Data.MetricsEntities();
//                    _mapper = mapper;
//                }
//            }
//        }

//        public MasterIdModel Create(MasterIdModel value)
//        {
//            var dbItem = _mapper.Map<MasterIdModel, Data.masterid>(value);
//            _unit.masterids.AddObject(dbItem);
//            _unit.SaveChanges();

//            return _mapper.Map<Data.masterid, MasterIdModel>(dbItem);
//        }

//        public void Update(MasterIdModel value)
//        {
//            _unit.masterids.Attach(_mapper.Map<MasterIdModel, Data.masterid>(value));
//            _unit.SaveChanges();
//        }

//        public void Delete(int id)
//        {
//            _unit.masterids.DeleteObject(_unit.masterids.FirstOrDefault(u=>u.id == id));
//            _unit.SaveChanges();
//        }

//        public MasterIdModel Login(string userName, string password)
//        {
//            //var users = _mapper.Map<IEnumerable<masterid>, IEnumerable<MasterIdModel>>(_unit.masteridRepository.Items);
//            var user =_unit.masterids.FirstOrDefault(u => u.uername.Equals(userName) && u.password.Equals(password));
//            return _mapper.Map<Data.masterid, MasterIdModel>(user);
            
//        }

//        public IEnumerable<MasterIdModel> GetAll()
//        {
//            //need to integrate to already opened orchard connection
//            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
//            {
//                return _mapper.Map<IEnumerable<Data.masterid>, IEnumerable<MasterIdModel>>(_unit.masterids);
//            }
//        }

//        public IEnumerable<MasterIdModel> GetAllById(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public MasterIdModel Get(long id)
//        {
//            throw new NotImplementedException();
//        }

//        public MasterIdModel GetByName(string name)
//        {
//            return _mapper.Map<Data.masterid, MasterIdModel>(_unit.masterids.FirstOrDefault(u=>u.uername == name));
//        }
//    }
//}
