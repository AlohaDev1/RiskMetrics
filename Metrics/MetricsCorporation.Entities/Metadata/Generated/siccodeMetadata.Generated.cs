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
    
    public partial class siccodeMetadata : IEntityMetadata
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
    		    		 CodePropertyName
    		    		, DescriptionPropertyName
    		    		, IdPropertyName
    		    		, ParentIdPropertyName
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
    			pk.Add(CodePropertyName, "Mandatory");
    			pk.Add(DescriptionPropertyName, "Mandatory");
    			pk.Add(IdPropertyName, "Mandatory");
    			pk.Add(ParentIdPropertyName, "Mandatory");
                return pk;
            }
        }
    	
    	/// <summary>
        /// Strong typed property names
        /// </summary>
        #region Property Names Metadata
    	public string CodePropertyName 
    	{
    	    get { return "Code";}
    		set { throw new NotSupportedException(); }
        }
    	public string DescriptionPropertyName 
    	{
    	    get { return "Description";}
    		set { throw new NotSupportedException(); }
        }
    	public string IdPropertyName 
    	{
    	    get { return "Id";}
    		set { throw new NotSupportedException(); }
        }
    	public string ParentIdPropertyName 
    	{
    	    get { return "ParentId";}
    		set { throw new NotSupportedException(); }
        }
    	#endregion
    
    }
}
