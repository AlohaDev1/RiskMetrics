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

namespace MetricsCorporation.EFCorePrim.Repository
{

    public partial class primRepository
    {
        public IEnumerable<prim> GetSearchResults(CompanyModel companyModel, string[] countyCollection, string[] sicCodeCollection, string[] employeeSizeCollection, out int totalItems)
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
                    employeePredicate = employeePredicate.Or(p => p.EmployeeSizeRange == s);
                }

                predicate = predicate.And(employeePredicate);
            }

            if (companyModel.HasPhoneNumber)
            {
                predicate = predicate.And(p => !string.IsNullOrEmpty(p.PhoneEmp));
            }

            if (!string.IsNullOrEmpty(companyModel.RenewalMonth))
            {
                predicate = predicate.And(p => p.EffectiveMonth != null && p.EffectiveMonth == companyModel.RenewalMonth.ToLowerInvariant());
            }

            if (companyModel.States.Any())
            {
                var statePredicate = PredicateBuilder.False<prim>();
                foreach (var state in companyModel.States)
                {
                    statePredicate = statePredicate.Or(p => p.PhysicalAddressState != null && p.PhysicalAddressState.ToLowerInvariant().Contains(state.ToLowerInvariant()));
                }

                predicate = predicate.And(statePredicate);
            }

            if (!string.IsNullOrEmpty(companyModel.Zip))
            {
                predicate = predicate.And(p => p.PhysicalAddressZip != null && p.PhysicalAddressZip.ToLowerInvariant().Contains(companyModel.Zip.ToLowerInvariant()));
            }

            var primItems = Items.AsQueryable();

            var prims = Extensions.AsExpandable(primItems).Where(predicate.Compile());

            totalItems = Items.Count(predicate.Compile());

            return prims.Take(200);
        }

        public prim GetById(string id)
        {
            var item = from p in Items
                       where p.MasterUID == id
                       select p;

            return item.First();
        }


        public IEnumerable<prim> GetByIds(List<string> ids)
        {
            return Items.Where(p => ids.Contains(p.MasterUID));
        }
    }
}
