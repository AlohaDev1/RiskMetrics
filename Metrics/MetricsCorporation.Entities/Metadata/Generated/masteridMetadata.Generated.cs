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
    
    public partial class masteridMetadata : IEntityMetadata
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
    		    		 companynamePropertyName
    		    		, firstnamePropertyName
    		    		, headlinePropertyName
    		    		, idPropertyName
    		    		, lastnamePropertyName
    		    		, passwordPropertyName
    		    		, profilerequestPropertyName
    		    		, uernamePropertyName
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
    			pk.Add(companynamePropertyName, "Mandatory");
    			pk.Add(firstnamePropertyName, "Mandatory");
    			pk.Add(headlinePropertyName, "Mandatory");
    			pk.Add(idPropertyName, "Mandatory");
    			pk.Add(lastnamePropertyName, "Mandatory");
    			pk.Add(passwordPropertyName, "Mandatory");
    			pk.Add(profilerequestPropertyName, "Mandatory");
    			pk.Add(uernamePropertyName, "Mandatory");
                return pk;
            }
        }
    	
    	/// <summary>
        /// Strong typed property names
        /// </summary>
        #region Property Names Metadata
    	public string companynamePropertyName 
    	{
    	    get { return "companyname";}
    		set { throw new NotSupportedException(); }
        }
    	public string firstnamePropertyName 
    	{
    	    get { return "firstname";}
    		set { throw new NotSupportedException(); }
        }
    	public string headlinePropertyName 
    	{
    	    get { return "headline";}
    		set { throw new NotSupportedException(); }
        }
    	public string idPropertyName 
    	{
    	    get { return "id";}
    		set { throw new NotSupportedException(); }
        }
    	public string lastnamePropertyName 
    	{
    	    get { return "lastname";}
    		set { throw new NotSupportedException(); }
        }
    	public string passwordPropertyName 
    	{
    	    get { return "password";}
    		set { throw new NotSupportedException(); }
        }
    	public string profilerequestPropertyName 
    	{
    	    get { return "profilerequest";}
    		set { throw new NotSupportedException(); }
        }
    	public string uernamePropertyName 
    	{
    	    get { return "uername";}
    		set { throw new NotSupportedException(); }
        }
    	#endregion
    
    }
}
