using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Transactions;
using LinqKit;
using MetricsCorporation.BL.Interfaces;
using MetricsCorporation.BL.Mapping;
using MetricsCorporation.Data;
using MetricsCorporation.EFCorePrim;
using MetricsCorporation.Models;
using prim = MetricsCorporation.Entities.prim;
using System.Data.Objects.SqlClient;
using System.Data.Linq.SqlClient;
using System.Linq.Expressions;
using System.Text;

namespace MetricsCorporation.BL.Services
{
    public class CompanyModelService : ICrud<CompanyModel>
    {
        private readonly MetricsPrimCombEntitesUnitOfWork _unit;
        private readonly MetricsPrimCombModelEntities _unit2;
        private readonly MetricsPrimaryDataModelEntities _unit3;

        private readonly object _locker = new object();
        private readonly IMapper _mapper;

        public CompanyModelService(IMapper mapper)
        {
            lock (_locker)
            {
                if (_unit == null)
                {
                    _unit = new MetricsPrimCombEntitesUnitOfWork();
                    _unit2 = new MetricsPrimCombModelEntities();
                    _unit3 = new MetricsPrimaryDataModelEntities();
                    _unit3.primarydatas.MergeOption = MergeOption.NoTracking;
                    _unit3.contactinformations.MergeOption = MergeOption.NoTracking;
                    _unit3.carriers.MergeOption = MergeOption.NoTracking;
                    _unit3.countyinformations.MergeOption = MergeOption.NoTracking;
                    _mapper = mapper;
                }
            }
        }

        public CompanyModel Create(CompanyModel value)
        {
            throw new NotImplementedException();
        }

        public void Update(CompanyModel value)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CompanyModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CompanyModel> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public SearchResponseModel GetAllByCompanyModel(CompanyModel model, List<string> States)
        {
            IQueryable<Data.statecountycode> StateCountyCollection = _unit3.statecountycodes;
            List<long?> countyArray = new List<long?>();

            foreach (var state in States)
            {
                countyArray.AddRange(StateCountyCollection.Where(p => p.State_Description == state.Trim()).Select(p => p.County_Number).ToList().ConvertAll<long?>(p => p));
            }
            countyArray.AddRange(model.CountyCodes);
            model.CountyCodes = countyArray.ToArray();

            List<int?> empsizeArray = new List<int?>();
            foreach (var range in model.EmpSize)
            {
                empsizeArray.Add(int.Parse(range));
            }

            int totalItems = 0;
            var items = GetSearchResults(model, empsizeArray, out totalItems);

            var response = new SearchResponseModel
            {
                Companies = items,
                Showed = 200,
                Total = totalItems,
            };
            return response;
        }

        /// <summary>
        /// Get the search result with selected criteria
        /// </summary>
        /// <param name="companyModel"></param>
        /// <param name="employeeSizeCollection"></param>
        /// <param name="totalItems"></param>
        /// <returns></returns>
        public List<CompanyGrid> GetSearchResults(CompanyModel companyModel, List<int?> employeeSizeCollection, out int totalItems)
        {

            IQueryable<Data.primarydata> items = _unit3.primarydatas;

            if (companyModel.CountyCodes.Any())
                items = items.Where(p => companyModel.CountyCodes.Contains(p.countyCode));
            else if (companyModel.States.Any())
                items = items.Where(a => companyModel.States.Contains(a.state));

            //if (companyModel.HasPhoneNumber)
            //    items = items.Where(p => p.contactinformations.FirstOrDefault().phoneNumber != string.Empty);           

            if (employeeSizeCollection.Any())
                items = items.Where(p => employeeSizeCollection.Contains(p.empSizeCode));

            if (companyModel.RenewalMonths.Any())
                items = items.Where(a => companyModel.RenewalMonths.Contains(a.effectiveMonth));

            if (companyModel.CarrierNumbers.Any())
                items = items.Where(p => companyModel.CarrierNumbers.Contains(p.naicNumber));

            //Expression<Func<Data.primarydata, bool>> whereclause = null;

            //whereclause = p => p.sicCode == "0111";

            //Expression<Func<Data.primarydata, bool>> whereclause1 = null;

            //whereclause1 = p => p.sicCode == "0112";

            //var aaaa = PredicateBuilder.Or(whereclause, whereclause1);

            //items = items.AsExpandable().Where(aaaa);


            if (companyModel.ClassCodes.Any() || companyModel.SicCodes.Any())
            {
                if (companyModel.ClassCodes.Any() && companyModel.SicCodes.Any())
                    items = items.Where(p => (companyModel.ClassCodes.Contains(p.classCode)) || (companyModel.SicCodes.Contains(p.sicCode)));
                else
                {
                    if (companyModel.ClassCodes.Any())
                        items = items.Where(p => companyModel.ClassCodes.Contains(p.classCode));

                    if (companyModel.SicCodes.Any())
                        items = items.Where(p => companyModel.SicCodes.Contains(p.sicCode));
                }
            }

            if (!string.IsNullOrEmpty(companyModel.Zip))
                items = items.Where(p => p.zip.Contains(companyModel.Zip));

            if (!string.IsNullOrEmpty(companyModel.City))
                items = items.Where(p => p.city.Contains(companyModel.City));

            if (!string.IsNullOrEmpty(companyModel.CompanyName))
                items = items.Where(p => p.description.Contains(companyModel.CompanyName));

            totalItems = 0;
            //totalItems = items.ToList().Count();
            var sql112 = ((System.Data.Objects.ObjectQuery)items).ToTraceString();
            return items.Select(p => new CompanyGrid { CompanyName = p.description, State = p.state, City = p.city, Status = p.statusCode, Id = (long)p.masterUId, CarrierGroup = p.carrier.naicGroupName, EmployeeSize = p.employeesizecode.description, SicCode = p.sicCode, IsExport = false }).Take(200).ToList();
        }

        public static string ToTraceString<T>(IQueryable<T> t)
        {
            string sql = "";
            ObjectQuery<T> oqt = t as ObjectQuery<T>;
            if (oqt != null)
                sql = oqt.ToTraceString();
            return sql;
        }

        public CompanyModel Get(long id)
        {
            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
            {
                IQueryable<Data.prim> items = _unit2.prims;
                string masterId = id.ToString();
                return _mapper.Map<Data.prim, CompanyModel>(items.First(p => p.MasterUID == masterId));
            }
        }

        public CompanyModel GetById(string id)
        {
            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
            {
                IQueryable<Data.prim> items = _unit2.prims;
                return _mapper.Map<Data.prim, CompanyModel>(items.First(p => p.MasterUID == id));
            }
        }

        public CompanyModel GetPrimaryById(string id)
        {
            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
            {
                IQueryable<Data.primarydata> items = _unit3.primarydatas;
                long Id = long.Parse(id);
                CompanyModel company = _mapper.Map<Data.primarydata, CompanyModel>(items.First(p => p.masterUId == Id));

                if (company.RecordType == "1")
                {
                    var result = items.Where(p => p.recordType == 2 && p.rmId == company.RMID).Take(2).ToList();
                    foreach (var item in result)
                    {
                        company.AdditionalInfo += item.description + "<br/>" + item.address + "," + item.city + "<br/>" + item.state + "," + item.zip + "<br/>";
                    }
                }
                else
                {
                    CompanyModel PrimaryRecord = _mapper.Map<Data.primarydata, CompanyModel>(items.FirstOrDefault(p => p.recordType == 1 && p.rmId == company.RMID));
                    PrimaryRecord.AdditionalInfo = company.CompanyName + "<br/>" + company.Address + "," + company.City + "<br/>" + company.State + "," + company.Zip + "<br/>";
                    return PrimaryRecord;
                }

                return company;
            }
        }

        public IEnumerable<CompanyModel> GetByIds(List<string> ids)
        {
            using (var tc = new TransactionScope(TransactionScopeOption.Suppress))
            {
                IQueryable<Data.prim> items = _unit2.prims;

                if (ids.Any())
                {
                    //var idsredicate = PredicateBuilder.False<Data.prim>();
                    //foreach (string id in ids)
                    //{
                    //    idsredicate = idsredicate.Or(p => p.MasterUID == id);
                    //}

                    //items = items.Where(idsredicate);
                    items = items.Where(a => ids.Contains(a.MasterUID));
                    return _mapper.Map<IEnumerable<Data.prim>, IEnumerable<CompanyModel>>(items);
                }

                return null;
            }
        }

        private string[] GetItemsArray(string items)
        {
            var countyArray = new string[0];
            if (!string.IsNullOrEmpty(items) && items != "\"\"")
            {
                countyArray = items.Replace("[", "").Replace("]", "").Split(',');
            }
            return countyArray;
        }

        private string[] EmpsizeArray(string items)
        {
            string[] empsizeItems = items.Split(',');
            var empsizeArray = new string[0];

            if (empsizeItems.Length == 2 && empsizeItems[0] == empsizeItems[1])
            {
                return empsizeArray;
            }

            if (!string.IsNullOrEmpty(items) && items != "0,7")
            {
                int start = int.Parse(empsizeItems[0]);
                int finish = int.Parse(empsizeItems[1]);

                empsizeArray = new string[finish - start];
                int j = 0;
                for (int i = start; i < finish; i++)
                {
                    empsizeArray[j] = this.GetEmployeeSizeDescription(i);
                    j++;
                }
            }
            return empsizeArray;
        }

        private string GetEmployeeSizeDescription(int id)
        {
            switch (id)
            {
                case 0:
                    return "0 TO 4";
                case 1:
                    return "5 TO 9";
                case 2:
                    return "10 TO 19";
                case 3:
                    return "20 TO 49";
                case 4:
                    return "50 TO 99";
                case 5:
                    return "100 TO 499";
                case 6:
                    return "500 PLUS";
                default:
                    return "";
            }
        }

        //public string GetAdditionalInformation(string companyId)
        //{
        //    IQueryable<Data.primarydata> items = _unit3.primarydatas;
        //    long Id = long.Parse(companyId);
        //    CompanyModel company = _mapper.Map<Data.primarydata, CompanyModel>(items.First(p => p.masterUId == Id));
        //    string additionalInfo = string.Empty;
        //    if (company.RecordType == "1")
        //    {
        //        var result = items.Where(p => p.recordType == 2 && p.rmId == company.RMID).Take(2).ToList();
        //        foreach (var item in result)
        //        {
        //            additionalInfo += item.description + "<br/>" + item.address + "," + item.city + "<br/>" + item.state + "," + item.zip + "<br/>";
        //        }
        //    }
        //    return additionalInfo;
        //}
    }
}
