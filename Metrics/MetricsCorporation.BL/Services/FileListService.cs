//using System.Collections.Generic;
//using System.Linq;
//using System.Transactions;
//using MetricsCorporation.BL.Interfaces;
//using MetricsCorporation.BL.Mapping;
//using MetricsCorporation.Entities;
//using MetricsCorporation.Models;
//using System.Linq;

//namespace MetricsCorporation.BL.Services
//{
//    public class FileListService : ICrud<FileListModel>
//    {
//        private readonly Data.MetricsEntities _unit;
//        private readonly object _locker = new object();

//        private readonly IMapper _mapper;
//        public FileListService(IMapper mapper)
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

//        public FileListModel Create(FileListModel value)
//        {
//            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
//            {
//                Data.filelist dbItem = _mapper.Map<FileListModel, Data.filelist>(value);
//                _unit.filelists.AddObject(dbItem);
//                _unit.SaveChanges();

//                return _mapper.Map<Data.filelist, FileListModel>(dbItem);
//            }
//        }

//        public void Update(FileListModel value)
//        {
//            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
//            {
//                _unit.filelists.Attach(_mapper.Map<FileListModel, Data.filelist>(value));
//                _unit.SaveChanges();
//            }
//        }

//        public void Delete(int id)
//        {
//            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
//            {
//                _unit.filelists.DeleteObject(_unit.filelists.FirstOrDefault(f=>f.id == id));
//                _unit.SaveChanges();
//            }
//        }

//        public FileListModel Login(string userName, string password)
//        {
//            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
//            {
//                var fileListModel = _mapper.Map<Data.filelist, FileListModel>(_unit.filelists.FirstOrDefault(f=> f.username.ToUpper().Equals(userName.ToUpper()) 
//                                                                                && f.password.ToUpper().Equals(password.ToUpper())));
//                if (fileListModel != null)
//                {
//                    var states = _unit.user_states.Where(u=>u.userId == fileListModel.Id);
//                    fileListModel.States = string.Join(",", states);
//                }
                
//                return fileListModel;
//            }
//        }

//        public IEnumerable<FileListModel> GetAll()
//        {
//            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
//            {
//                var fileLists =
//                _mapper.Map<IEnumerable<Data.filelist>, IEnumerable<FileListModel>>(_unit.filelists);

//                foreach (FileListModel fileListModel in fileLists)
//                {
//                    var states = _unit.user_states.Where(u=>u.userId == fileListModel.Id);

//                    fileListModel.States = string.Join(",", states);
//                }

//                return fileLists;
//            }
//        }

//        public IEnumerable<FileListModel> GetAllById(int id)
//        {
//            throw new System.NotImplementedException();
//        }

//        public FileListModel Get(long id)
//        {
//            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
//            {
//                return _mapper.Map<Data.filelist, FileListModel>(_unit.filelists.FirstOrDefault(u=>u.id == id));
//            }
//        }

//        public FileListModel GetByName(string name)
//        {
//            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
//            {
//                return _mapper.Map<Data.filelist, FileListModel>(_unit.filelists.FirstOrDefault(u=> u.username.ToUpper().Equals(name.ToUpper())));
//            }

//        }

//        public IEnumerable<FileListModel> GetByCompanyName(string name)
//        {
//            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
//            {
//                return _mapper.Map<IEnumerable<Data.filelist>, IEnumerable<FileListModel>>(_unit.filelists.Where(i => i.CompanyName.ToLower().Equals(name.ToLower())));
//            }

//        }
//    }
//}
