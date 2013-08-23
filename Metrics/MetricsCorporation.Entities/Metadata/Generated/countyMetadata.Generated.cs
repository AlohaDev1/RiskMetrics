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
    
    public partial class countyMetadata : IEntityMetadata
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
    		    		 idPropertyName
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
    		    		 descriptionPropertyName
    		    		, idPropertyName
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
    			pk.Add(descriptionPropertyName, "Mandatory");
    			pk.Add(idPropertyName, "Mandatory");
    			pk.Add(selectflagPropertyName, "Optional");
    			pk.Add(statePropertyName, "Optional");
                return pk;
            }
        }
    	
    	/// <summary>
        /// Strong typed property names
        /// </summary>
        #region Property Names Metadata
    	public string descriptionPropertyName 
    	{
    	    get { return "description";}
    		set { throw new NotSupportedException(); }
        }
    	public string idPropertyName 
    	{
    	    get { return "id";}
    		set { throw new NotSupportedException(); }
        }
    	public string selectflagPropertyName 
    	{
    	    get { return "selectflag";}
    		set { throw new NotSupportedException(); }
        }
    	public string statePropertyName 
    	{
    	    get { return "state";}
    		set { throw new NotSupportedException(); }
        }
    	#endregion
    
    }
}
