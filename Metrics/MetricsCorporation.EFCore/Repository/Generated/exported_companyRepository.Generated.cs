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
    
    public partial class exported_companyRepository : GenericRepository<exported_company>
    {
    	public exported_companyRepository(state_schematicEntities context) : base(context)
    	{}
    }
}
