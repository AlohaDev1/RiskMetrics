
 

/************************************************************
*
*	UnitOfWork module generated from MetricsCorporationModel.edmx
*
*   Usage Reference 
*	http://www.asp.net/mvc/tutorials/getting-started-with-ef-using-mvc/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
*
*************************************************************/
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MetricsCorporation.EFCorePrim.Repository;

namespace MetricsCorporation.EFCorePrim
{
    
    public partial class MetricsPrimCombEntitesUnitOfWork 
    {
        private MetricsCorporationPrimComb _context = new MetricsCorporationPrimComb();
        private combRepository _comb = null;
        private primRepository _prim = null;
        
        public combRepository combRepository
        {
        	get
            {
        		if (_comb == null)
                {
                	_comb = new combRepository(_context);
                }
                return _comb;
            }
        }
        
        public primRepository primRepository
        {
        	get
            {
        		if (_prim == null)
                {
                	_prim = new primRepository(_context);
                }
                return _prim;
            }
        }
    }
}