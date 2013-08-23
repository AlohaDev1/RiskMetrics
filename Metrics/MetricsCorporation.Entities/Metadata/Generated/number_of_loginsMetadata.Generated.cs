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
    
    public partial class number_of_loginsMetadata : IEntityMetadata
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
    		    		 countPropertyName
    		    		, idPropertyName
    		    		, login_datePropertyName
    		    		, user_idPropertyName
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
    			pk.Add(countPropertyName, "Mandatory");
    			pk.Add(idPropertyName, "Mandatory");
    			pk.Add(login_datePropertyName, "Mandatory");
    			pk.Add(number_of_logins1PropertyName, "Optional");
    			pk.Add(user_idPropertyName, "Mandatory");
                return pk;
            }
        }
    	
    	/// <summary>
        /// Strong typed property names
        /// </summary>
        #region Property Names Metadata
    	public string countPropertyName 
    	{
    	    get { return "count";}
    		set { throw new NotSupportedException(); }
        }
    	public string idPropertyName 
    	{
    	    get { return "id";}
    		set { throw new NotSupportedException(); }
        }
    	public string login_datePropertyName 
    	{
    	    get { return "login_date";}
    		set { throw new NotSupportedException(); }
        }
    	public string number_of_logins1PropertyName 
    	{
    	    get { return "number_of_logins1";}
    		set { throw new NotSupportedException(); }
        }
    	public string user_idPropertyName 
    	{
    	    get { return "user_id";}
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
