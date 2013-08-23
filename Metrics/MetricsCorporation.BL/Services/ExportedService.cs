using System;
using System.Collections.Generic;
using System.Globalization;
using System.Transactions;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.BL.Mapping;
using MetricsCorporation.EFCorePrim;
using MetricsCorporation.Entities;
using MetricsCorporation.Models;
using System.Linq;

namespace MetricsCorporation.BL.Services
{
    public class ExportedService : ICrud<ExportedModel>
    {
        private readonly Data.MetricsEntities _unit;
        private readonly object _locker = new object();
        private readonly IMapper _mapper;

        public ExportedService(IMapper mapper)
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

        public ExportedModel Create(ExportedModel value)
        {
            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
            {

                var dbValue = new Data.exported()
                {
                    UserId = value.UserId,
                    FileName = value.FileName,
                    ExportedOn = DateTime.UtcNow,
                    RecordsExportedCount = value.CompanyIds.Count,
                    //exported_company = new List<Data.exported_company>(value.CompanyIds.Select(s=> new exported_company(){ExportedId = Id }))
                };
                _unit.exporteds.AddObject(dbValue);
                foreach (var companyId in value.CompanyIds)
                {
                    _unit.exported_company.AddObject(new Data.exported_company() { ExportedId = dbValue.Id, CompanyId = companyId.ToString(CultureInfo.InvariantCulture) });
                }
                _unit.SaveChanges();
                value.Id = dbValue.Id;

                return value;
            }

        }

        public void Update(ExportedModel value)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ExportedModel> GetAll()
        {
            throw new System.NotImplementedException();
            //return _mapper.Map<IEnumerable<comb>, IEnumerable<CombModel>>(_unit.combRepository.AllItems.Take(100));
        }

        public IEnumerable<ExportedModel> GetAllById(int id)
        {
            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
            {
                return
                    _mapper.Map<IEnumerable<Data.exported>, IEnumerable<ExportedModel>>(
                        _unit.exporteds.Where(i => i.UserId == id));
            }
        }

        public ExportedModel Get(long id)
        {
            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
            {
                return _mapper.Map<Data.exported, ExportedModel>(_unit.exporteds.FirstOrDefault(i => i.Id == id));
            }

        }
    }
}
