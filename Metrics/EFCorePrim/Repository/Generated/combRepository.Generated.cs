/************************************************************
*
*	Repository module generated from MetricsCorporationModel.edmx
*
*************************************************************/
using System;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using MetricsCorporation.Entities;

namespace MetricsCorporation.EFCorePrim.Repository
{
    
    public partial class combRepository : GenericRepository<comb>
    {
    	public combRepository(MetricsCorporationPrimComb context) : base(context)
    	{}
    }
}
