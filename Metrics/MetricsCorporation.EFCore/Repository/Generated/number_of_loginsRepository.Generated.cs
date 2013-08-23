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

namespace MetricsCorporation.EFCore.Repository
{
    
    public partial class number_of_loginsRepository : GenericRepository<number_of_logins>
    {
    	public number_of_loginsRepository(state_schematicEntities context) : base(context)
    	{}
    }
}
