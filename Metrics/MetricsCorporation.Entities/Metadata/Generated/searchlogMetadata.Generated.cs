//-------------------------------------------------------------------------------------------------
//    Metadata class
//    Hisory Changes:
//
//    2011/10/29
//    - generate PrimaryKey property
//    - define strong typed PropertyNames 
//-------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MetricsCorporation.Infrastructure.Interfaces;

namespace MetricsCorporation.Entities.Metadata
{
    
    public partial class searchlogMetadata : IEntityMetadata
    {	
        /// <summary>
        /// Returns primary key as List
        /// </summary>
    	public List<string> PrimaryKey
    	{
            get
    		{
                List<string> pk = new List<string>();
                pk.AddRange(
                    new string[] {					
    		    		 quiPropertyName
    				});
                return pk;
            }
        }
    	
        /// <summary>
        /// Returns primary key as List
        /// </summary>
    	public List<string> MandatoryFields
    	{
            get
    		{
                List<string> pk = new List<string>();
                pk.AddRange(
                    new string[] {					
    		    		 addressPropertyName
    		    		, cityPropertyName
    		    		, CountyNamePropertyName
    		    		, descriptionPropertyName
    		    		, EffectiveMonthPropertyName
    		    		, EmpSizeRangePropertyName
    		    		, idPropertyName
    		    		, PhoneEmpPropertyName
    		    		, quiPropertyName
    		    		, searchnamePropertyName
    		    		, SICCodePropertyName
    		    		, statePropertyName
    		    		, zipPropertyName
    				});
                return pk;
            }
        }
    	
        /// <summary>
        /// Returns primary key as List
        /// </summary>
    	public Dictionary<string, string> Fields
    	{
            get
    		{
                Dictionary<string, string> pk = new Dictionary<string, string>();
    			pk.Add(ActivePropertyName, "Optional");
    			pk.Add(addressPropertyName, "Mandatory");
    			pk.Add(cityPropertyName, "Mandatory");
    			pk.Add(CountyNamePropertyName, "Mandatory");
    			pk.Add(descriptionPropertyName, "Mandatory");
    			pk.Add(EffectiveMonthPropertyName, "Mandatory");
    			pk.Add(EmpSizeRangePropertyName, "Mandatory");
    			pk.Add(idPropertyName, "Mandatory");
    			pk.Add(PhoneEmpPropertyName, "Mandatory");
    			pk.Add(quiPropertyName, "Mandatory");
    			pk.Add(searchlogcolPropertyName, "Optional");
    			pk.Add(searchnamePropertyName, "Mandatory");
    			pk.Add(SICCodePropertyName, "Mandatory");
    			pk.Add(statePropertyName, "Mandatory");
    			pk.Add(zipPropertyName, "Mandatory");
                return pk;
            }
        }
    	
    	/// <summary>
        /// Strong typed property names
        /// </summary>
        #region Property Names Metadata
    	public string ActivePropertyName 
    	{
    	    get { return "Active";}
    		set { throw new NotSupportedException(); }
        }
    	public string addressPropertyName 
    	{
    	    get { return "address";}
    		set { throw new NotSupportedException(); }
        }
    	public string cityPropertyName 
    	{
    	    get { return "city";}
    		set { throw new NotSupportedException(); }
        }
    	public string CountyNamePropertyName 
    	{
    	    get { return "CountyName";}
    		set { throw new NotSupportedException(); }
        }
    	public string descriptionPropertyName 
    	{
    	    get { return "description";}
    		set { throw new NotSupportedException(); }
        }
    	public string EffectiveMonthPropertyName 
    	{
    	    get { return "EffectiveMonth";}
    		set { throw new NotSupportedException(); }
        }
    	public string EmpSizeRangePropertyName 
    	{
    	    get { return "EmpSizeRange";}
    		set { throw new NotSupportedException(); }
        }
    	public string idPropertyName 
    	{
    	    get { return "id";}
    		set { throw new NotSupportedException(); }
        }
    	public string PhoneEmpPropertyName 
    	{
    	    get { return "PhoneEmp";}
    		set { throw new NotSupportedException(); }
        }
    	public string quiPropertyName 
    	{
    	    get { return "qui";}
    		set { throw new NotSupportedException(); }
        }
    	public string searchlogcolPropertyName 
    	{
    	    get { return "searchlogcol";}
    		set { throw new NotSupportedException(); }
        }
    	public string searchnamePropertyName 
    	{
    	    get { return "searchname";}
    		set { throw new NotSupportedException(); }
        }
    	public string SICCodePropertyName 
    	{
    	    get { return "SICCode";}
    		set { throw new NotSupportedException(); }
        }
    	public string statePropertyName 
    	{
    	    get { return "state";}
    		set { throw new NotSupportedException(); }
        }
    	public string zipPropertyName 
    	{
    	    get { return "zip";}
    		set { throw new NotSupportedException(); }
        }
    	public string filelistPropertyName
    	{
    	    get { return "filelist";}
    		set { throw new NotSupportedException(); }
        }
    	#endregion
    
    }
}
