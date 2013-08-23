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
    
    public partial class exported_companyMetadata : IEntityMetadata
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
    		    		 IdPropertyName
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
    		    		 IdPropertyName
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
    			pk.Add(CompanyIdPropertyName, "Optional");
    			pk.Add(ExportedIdPropertyName, "Optional");
    			pk.Add(IdPropertyName, "Mandatory");
                return pk;
            }
        }
    	
    	/// <summary>
        /// Strong typed property names
        /// </summary>
        #region Property Names Metadata
    	public string CompanyIdPropertyName 
    	{
    	    get { return "CompanyId";}
    		set { throw new NotSupportedException(); }
        }
    	public string ExportedIdPropertyName 
    	{
    	    get { return "ExportedId";}
    		set { throw new NotSupportedException(); }
        }
    	public string IdPropertyName 
    	{
    	    get { return "Id";}
    		set { throw new NotSupportedException(); }
        }
    	public string exportedPropertyName
    	{
    	    get { return "exported";}
    		set { throw new NotSupportedException(); }
        }
    	#endregion
    
    }
}
