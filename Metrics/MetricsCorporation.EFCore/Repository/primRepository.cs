/************************************************************
*
*	Repository module generated from MetricsCorporationModel.edmx
*
*************************************************************/

using System.Collections.Generic;
using System.Linq;
using LinqKit;
using MetricsCorporation.Entities;
using MetricsCorporation.Models;

namespace MetricsCorporation.EFCore.Repository
{

    public partial class primRepository
    {
        public IEnumerable<prim> GetSearchResults(CompanyModel companyModel, string[] countyCollection, string[] sicCodeCollection, int[] employeeSizeCollection)
        {
            var predicate = PredicateBuilder.True<prim>();

            if (!string.IsNullOrEmpty(companyModel.City))
            {
                predicate = predicate.And(p => p.PhysicalAddressCity != null && p.PhysicalAddressCity.ToLowerInvariant().Contains(companyModel.City.ToLowerInvariant()));
            }

            if (!string.IsNullOrEmpty(companyModel.CompanyName))
            {
                predicate = predicate.And(p => p.Description != null);
                predicate = predicate.And(p => p.Description.ToLowerInvariant().Contains(companyModel.CompanyName.ToLowerInvariant()));
            }

            if (countyCollection.Any())
            {
                var countyPredicate = PredicateBuilder.False<prim>();
                foreach (var s in countyCollection)
                {
                    countyPredicate = countyPredicate.Or(p => p.CountyNum != null && p.CountyNum == s.ToString());
                }

                predicate = predicate.And(countyPredicate);
            }

            if (sicCodeCollection.Any())
            {
                var sicPredicate = PredicateBuilder.False<prim>();
                foreach (var s in sicCodeCollection)
                {
                    sicPredicate = sicPredicate.Or(p => p.SICCode != null && p.SICCode == s.ToString());
                }

                predicate = predicate.And(sicPredicate);
            }

            if (employeeSizeCollection.Any())
            {
                var employeePredicate = PredicateBuilder.False<prim>();
                foreach (var s in employeeSizeCollection)
                {
                    employeePredicate = employeePredicate.Or(p => p.EmployeeSizeId == s);
                }

                predicate = predicate.And(employeePredicate);
            }

            if (!string.IsNullOrEmpty(companyModel.Phone))
            {
                predicate = predicate.And(p => !string.IsNullOrEmpty(p.PhoneEmp));
            }

            if (!string.IsNullOrEmpty(companyModel.RenewalMonth))
            {
                predicate = predicate.And(p => p.EffectiveMonth != null && p.EffectiveMonth == companyModel.RenewalMonth.ToLowerInvariant());
            }

            if (!string.IsNullOrEmpty(companyModel.State))
            {
                predicate = predicate.And(p => p.PhysicalAddressState != null && p.PhysicalAddressState.ToLowerInvariant().Contains(companyModel.State.ToLowerInvariant()));
            }

            if (!string.IsNullOrEmpty(companyModel.Zip))
            {
                predicate = predicate.And(p => p.PhysicalAddressZip != null && p.PhysicalAddressZip.ToLowerInvariant().Contains(companyModel.Zip.ToLowerInvariant()));
            }

            var primItems = Items.AsQueryable();

            var prims = primItems.AsExpandable().Where(predicate.Compile());

            return prims.Take(200);
        }

        public prim GetById(string id)
        {
            var item = from p in Items
                       where p.MasterUID == id
                       select p;

            return item.FirstOrDefault();
        }

        public IEnumerable<prim> GetByIds(List<string> ids)
        {
            return Items.Where(i => ids.Contains(i.MasterUID));
            // var rTestResults = from rT in mDataContext.TestSamplesViews 
            //where rMTCPlates.Contains(rT.PlateID ?? 0) 
            //select rT; 
        }
    }
}
