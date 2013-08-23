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
    
    public partial class loginfoMetadata : IEntityMetadata
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
    		    		 CompanyNamePropertyName
    		    		, eventtypePropertyName
    		    		, idPropertyName
    		    		, lastloginDatePropertyName
    		    		, namePropertyName
    		    		, passwordPropertyName
    		    		, ReportCountPropertyName
    		    		, usernamePropertyName
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
    			pk.Add(CompanyNamePropertyName, "Mandatory");
    			pk.Add(eventtypePropertyName, "Mandatory");
    			pk.Add(idPropertyName, "Mandatory");
    			pk.Add(lastloginDatePropertyName, "Mandatory");
    			pk.Add(lastlogoutDatePropertyName, "Optional");
    			pk.Add(namePropertyName, "Mandatory");
    			pk.Add(passwordPropertyName, "Mandatory");
    			pk.Add(ReportCountPropertyName, "Mandatory");
    			pk.Add(usernamePropertyName, "Mandatory");
                return pk;
            }
        }
    	
    	/// <summary>
        /// Strong typed property names
        /// </summary>
        #region Property Names Metadata
    	public string CompanyNamePropertyName 
    	{
    	    get { return "CompanyName";}
    		set { throw new NotSupportedException(); }
        }
    	public string eventtypePropertyName 
    	{
    	    get { return "eventtype";}
    		set { throw new NotSupportedException(); }
        }
    	public string idPropertyName 
    	{
    	    get { return "id";}
    		set { throw new NotSupportedException(); }
        }
    	public string lastloginDatePropertyName 
    	{
    	    get { return "lastloginDate";}
    		set { throw new NotSupportedException(); }
        }
    	public string lastlogoutDatePropertyName 
    	{
    	    get { return "lastlogoutDate";}
    		set { throw new NotSupportedException(); }
        }
    	public string namePropertyName 
    	{
    	    get { return "name";}
    		set { throw new NotSupportedException(); }
        }
    	public string passwordPropertyName 
    	{
    	    get { return "password";}
    		set { throw new NotSupportedException(); }
        }
    	public string ReportCountPropertyName 
    	{
    	    get { return "ReportCount";}
    		set { throw new NotSupportedException(); }
        }
    	public string usernamePropertyName 
    	{
    	    get { return "username";}
    		set { throw new NotSupportedException(); }
        }
    	#endregion
    
    }
}
