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
    
    public partial class exportedMetadata : IEntityMetadata
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
    			pk.Add(ExportedOnPropertyName, "Optional");
    			pk.Add(FileNamePropertyName, "Optional");
    			pk.Add(IdPropertyName, "Mandatory");
    			pk.Add(RecordsExportedCountPropertyName, "Optional");
    			pk.Add(UserIdPropertyName, "Optional");
                return pk;
            }
        }
    	
    	/// <summary>
        /// Strong typed property names
        /// </summary>
        #region Property Names Metadata
    	public string ExportedOnPropertyName 
    	{
    	    get { return "ExportedOn";}
    		set { throw new NotSupportedException(); }
        }
    	public string FileNamePropertyName 
    	{
    	    get { return "FileName";}
    		set { throw new NotSupportedException(); }
        }
    	public string IdPropertyName 
    	{
    	    get { return "Id";}
    		set { throw new NotSupportedException(); }
        }
    	public string RecordsExportedCountPropertyName 
    	{
    	    get { return "RecordsExportedCount";}
    		set { throw new NotSupportedException(); }
        }
    	public string UserIdPropertyName 
    	{
    	    get { return "UserId";}
    		set { throw new NotSupportedException(); }
        }
    	public string exported_companyPropertyName
    	{
    	    get { return "exported_company";}
    		set { throw new NotSupportedException(); }
        }
    	#endregion
    
    }
}
