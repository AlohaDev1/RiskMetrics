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
    
    public partial class filelistMetadata : IEntityMetadata
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
    		    		 adminPropertyName
    		    		, canexportlistPropertyName
    		    		, CompanyNamePropertyName
    		    		, filepathPropertyName
    		    		, idPropertyName
    		    		, maxexportsPropertyName
    		    		, maxjigsawexportsPropertyName
    		    		, maxjigsawreportsviewspermonthPropertyName
    		    		, maxreportviewspermonthPropertyName
    		    		, namePropertyName
    		    		, passwordPropertyName
    		    		, statesPropertyName
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
    			pk.Add(activationdatePropertyName, "Optional");
    			pk.Add(adminPropertyName, "Mandatory");
    			pk.Add(canexportlistPropertyName, "Mandatory");
    			pk.Add(CompanyNamePropertyName, "Mandatory");
    			pk.Add(expirationdatePropertyName, "Optional");
    			pk.Add(filepathPropertyName, "Mandatory");
    			pk.Add(idPropertyName, "Mandatory");
    			pk.Add(lastloginDatePropertyName, "Optional");
    			pk.Add(maxexportsPropertyName, "Mandatory");
    			pk.Add(maxjigsawexportsPropertyName, "Mandatory");
    			pk.Add(maxjigsawreportsviewspermonthPropertyName, "Mandatory");
    			pk.Add(maxreportviewspermonthPropertyName, "Mandatory");
    			pk.Add(namePropertyName, "Mandatory");
    			pk.Add(passwordPropertyName, "Mandatory");
    			pk.Add(renewaldatePropertyName, "Optional");
    			pk.Add(statesPropertyName, "Mandatory");
    			pk.Add(usernamePropertyName, "Mandatory");
                return pk;
            }
        }
    	
    	/// <summary>
        /// Strong typed property names
        /// </summary>
        #region Property Names Metadata
    	public string activationdatePropertyName 
    	{
    	    get { return "activationdate";}
    		set { throw new NotSupportedException(); }
        }
    	public string adminPropertyName 
    	{
    	    get { return "admin";}
    		set { throw new NotSupportedException(); }
        }
    	public string canexportlistPropertyName 
    	{
    	    get { return "canexportlist";}
    		set { throw new NotSupportedException(); }
        }
    	public string CompanyNamePropertyName 
    	{
    	    get { return "CompanyName";}
    		set { throw new NotSupportedException(); }
        }
    	public string expirationdatePropertyName 
    	{
    	    get { return "expirationdate";}
    		set { throw new NotSupportedException(); }
        }
    	public string filepathPropertyName 
    	{
    	    get { return "filepath";}
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
    	public string maxexportsPropertyName 
    	{
    	    get { return "maxexports";}
    		set { throw new NotSupportedException(); }
        }
    	public string maxjigsawexportsPropertyName 
    	{
    	    get { return "maxjigsawexports";}
    		set { throw new NotSupportedException(); }
        }
    	public string maxjigsawreportsviewspermonthPropertyName 
    	{
    	    get { return "maxjigsawreportsviewspermonth";}
    		set { throw new NotSupportedException(); }
        }
    	public string maxreportviewspermonthPropertyName 
    	{
    	    get { return "maxreportviewspermonth";}
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
    	public string renewaldatePropertyName 
    	{
    	    get { return "renewaldate";}
    		set { throw new NotSupportedException(); }
        }
    	public string statesPropertyName 
    	{
    	    get { return "states";}
    		set { throw new NotSupportedException(); }
        }
    	public string usernamePropertyName 
    	{
    	    get { return "username";}
    		set { throw new NotSupportedException(); }
        }
    	public string searchlogsPropertyName
    	{
    	    get { return "searchlogs";}
    		set { throw new NotSupportedException(); }
        }
    	public string number_of_loginsPropertyName
    	{
    	    get { return "number_of_logins";}
    		set { throw new NotSupportedException(); }
        }
    	public string jigsaw_loginsPropertyName
    	{
    	    get { return "jigsaw_logins";}
    		set { throw new NotSupportedException(); }
        }
    	public string user_statesPropertyName
    	{
    	    get { return "user_states";}
    		set { throw new NotSupportedException(); }
        }
    	#endregion
    
    }
}
