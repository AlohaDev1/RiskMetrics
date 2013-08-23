
 

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
using MetricsCorporation.EFCore.Repository;

namespace MetricsCorporation.EFCore
{
    
    public partial class MetricsCorporationUnitOfWork 
    {
        private state_schematicEntities _context = new state_schematicEntities();
        private countyRepository _county = null;
        private employeesizeRepository _employeesize = null;
        private exportedRepository _exported = null;
        private exported_companyRepository _exported_company = null;
        private filelistRepository _filelist = null;
        private jigsaw_loginsRepository _jigsaw_logins = null;
        private loginfoRepository _loginfo = null;
        private masteridRepository _masterid = null;
        private number_of_loginsRepository _number_of_logins = null;
        private searchlogRepository _searchlog = null;
        private siccodeRepository _siccode = null;
        private usageinfoRepository _usageinfo = null;
        private user_statesRepository _user_states = null;
        private usercreditRepository _usercredit = null;
        
        public countyRepository countyRepository
        {
        	get
            {
        		if (_county == null)
                {
                	_county = new countyRepository(_context);
                }
                return _county;
            }
        }
        
        public employeesizeRepository employeesizeRepository
        {
        	get
            {
        		if (_employeesize == null)
                {
                	_employeesize = new employeesizeRepository(_context);
                }
                return _employeesize;
            }
        }
        
        public exportedRepository exportedRepository
        {
        	get
            {
        		if (_exported == null)
                {
                	_exported = new exportedRepository(_context);
                }
                return _exported;
            }
        }
        
        public exported_companyRepository exported_companyRepository
        {
        	get
            {
        		if (_exported_company == null)
                {
                	_exported_company = new exported_companyRepository(_context);
                }
                return _exported_company;
            }
        }
        
        public filelistRepository filelistRepository
        {
        	get
            {
        		if (_filelist == null)
                {
                	_filelist = new filelistRepository(_context);
                }
                return _filelist;
            }
        }
        
        public jigsaw_loginsRepository jigsaw_loginsRepository
        {
        	get
            {
        		if (_jigsaw_logins == null)
                {
                	_jigsaw_logins = new jigsaw_loginsRepository(_context);
                }
                return _jigsaw_logins;
            }
        }
        
        public loginfoRepository loginfoRepository
        {
        	get
            {
        		if (_loginfo == null)
                {
                	_loginfo = new loginfoRepository(_context);
                }
                return _loginfo;
            }
        }
        
        public masteridRepository masteridRepository
        {
        	get
            {
        		if (_masterid == null)
                {
                	_masterid = new masteridRepository(_context);
                }
                return _masterid;
            }
        }
        
        public number_of_loginsRepository number_of_loginsRepository
        {
        	get
            {
        		if (_number_of_logins == null)
                {
                	_number_of_logins = new number_of_loginsRepository(_context);
                }
                return _number_of_logins;
            }
        }
        
        public searchlogRepository searchlogRepository
        {
        	get
            {
        		if (_searchlog == null)
                {
                	_searchlog = new searchlogRepository(_context);
                }
                return _searchlog;
            }
        }
        
        public siccodeRepository siccodeRepository
        {
        	get
            {
        		if (_siccode == null)
                {
                	_siccode = new siccodeRepository(_context);
                }
                return _siccode;
            }
        }
        
        public usageinfoRepository usageinfoRepository
        {
        	get
            {
        		if (_usageinfo == null)
                {
                	_usageinfo = new usageinfoRepository(_context);
                }
                return _usageinfo;
            }
        }
        
        public user_statesRepository user_statesRepository
        {
        	get
            {
        		if (_user_states == null)
                {
                	_user_states = new user_statesRepository(_context);
                }
                return _user_states;
            }
        }
        
        public usercreditRepository usercreditRepository
        {
        	get
            {
        		if (_usercredit == null)
                {
                	_usercredit = new usercreditRepository(_context);
                }
                return _usercredit;
            }
        }
    }
}