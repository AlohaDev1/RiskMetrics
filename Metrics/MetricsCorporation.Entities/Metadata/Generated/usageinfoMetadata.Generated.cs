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
    
    public partial class usageinfoMetadata : IEntityMetadata
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
    		    		 addressPropertyName
    		    		, carriernamePropertyName
    		    		, carriernumPropertyName
    		    		, cityPropertyName
    		    		, classcodePropertyName
    		    		, contactnamePropertyName
    		    		, countynamePropertyName
    		    		, createdAtPropertyName
    		    		, descriptionPropertyName
    		    		, effectivedatePropertyName
    		    		, empsizerangePropertyName
    		    		, idPropertyName
    		    		, NAICCarrierNumberPropertyName
    		    		, NAICGroupNamePropertyName
    		    		, namePropertyName
    		    		, phoneempPropertyName
    		    		, reportidPropertyName
    		    		, salesvolrangePropertyName
    		    		, siccodePropertyName
    		    		, statePropertyName
    		    		, statusPropertyName
    		    		, usernamePropertyName
    		    		, zipPropertyName
    		    		, zipplus4PropertyName
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
    			pk.Add(addressPropertyName, "Mandatory");
    			pk.Add(carriernamePropertyName, "Mandatory");
    			pk.Add(carriernumPropertyName, "Mandatory");
    			pk.Add(cityPropertyName, "Mandatory");
    			pk.Add(classcodePropertyName, "Mandatory");
    			pk.Add(contactnamePropertyName, "Mandatory");
    			pk.Add(countynamePropertyName, "Mandatory");
    			pk.Add(createdAtPropertyName, "Mandatory");
    			pk.Add(descriptionPropertyName, "Mandatory");
    			pk.Add(effectivedatePropertyName, "Mandatory");
    			pk.Add(empsizerangePropertyName, "Mandatory");
    			pk.Add(idPropertyName, "Mandatory");
    			pk.Add(NAICCarrierNumberPropertyName, "Mandatory");
    			pk.Add(NAICGroupNamePropertyName, "Mandatory");
    			pk.Add(namePropertyName, "Mandatory");
    			pk.Add(phoneempPropertyName, "Mandatory");
    			pk.Add(reportidPropertyName, "Mandatory");
    			pk.Add(salesvolrangePropertyName, "Mandatory");
    			pk.Add(siccodePropertyName, "Mandatory");
    			pk.Add(statePropertyName, "Mandatory");
    			pk.Add(statusPropertyName, "Mandatory");
    			pk.Add(usernamePropertyName, "Mandatory");
    			pk.Add(zipPropertyName, "Mandatory");
    			pk.Add(zipplus4PropertyName, "Mandatory");
                return pk;
            }
        }
    	
    	/// <summary>
        /// Strong typed property names
        /// </summary>
        #region Property Names Metadata
    	public string addressPropertyName 
    	{
    	    get { return "address";}
    		set { throw new NotSupportedException(); }
        }
    	public string carriernamePropertyName 
    	{
    	    get { return "carriername";}
    		set { throw new NotSupportedException(); }
        }
    	public string carriernumPropertyName 
    	{
    	    get { return "carriernum";}
    		set { throw new NotSupportedException(); }
        }
    	public string cityPropertyName 
    	{
    	    get { return "city";}
    		set { throw new NotSupportedException(); }
        }
    	public string classcodePropertyName 
    	{
    	    get { return "classcode";}
    		set { throw new NotSupportedException(); }
        }
    	public string contactnamePropertyName 
    	{
    	    get { return "contactname";}
    		set { throw new NotSupportedException(); }
        }
    	public string countynamePropertyName 
    	{
    	    get { return "countyname";}
    		set { throw new NotSupportedException(); }
        }
    	public string createdAtPropertyName 
    	{
    	    get { return "createdAt";}
    		set { throw new NotSupportedException(); }
        }
    	public string descriptionPropertyName 
    	{
    	    get { return "description";}
    		set { throw new NotSupportedException(); }
        }
    	public string effectivedatePropertyName 
    	{
    	    get { return "effectivedate";}
    		set { throw new NotSupportedException(); }
        }
    	public string empsizerangePropertyName 
    	{
    	    get { return "empsizerange";}
    		set { throw new NotSupportedException(); }
        }
    	public string idPropertyName 
    	{
    	    get { return "id";}
    		set { throw new NotSupportedException(); }
        }
    	public string NAICCarrierNumberPropertyName 
    	{
    	    get { return "NAICCarrierNumber";}
    		set { throw new NotSupportedException(); }
        }
    	public string NAICGroupNamePropertyName 
    	{
    	    get { return "NAICGroupName";}
    		set { throw new NotSupportedException(); }
        }
    	public string namePropertyName 
    	{
    	    get { return "name";}
    		set { throw new NotSupportedException(); }
        }
    	public string phoneempPropertyName 
    	{
    	    get { return "phoneemp";}
    		set { throw new NotSupportedException(); }
        }
    	public string reportidPropertyName 
    	{
    	    get { return "reportid";}
    		set { throw new NotSupportedException(); }
        }
    	public string salesvolrangePropertyName 
    	{
    	    get { return "salesvolrange";}
    		set { throw new NotSupportedException(); }
        }
    	public string siccodePropertyName 
    	{
    	    get { return "siccode";}
    		set { throw new NotSupportedException(); }
        }
    	public string statePropertyName 
    	{
    	    get { return "state";}
    		set { throw new NotSupportedException(); }
        }
    	public string statusPropertyName 
    	{
    	    get { return "status";}
    		set { throw new NotSupportedException(); }
        }
    	public string usernamePropertyName 
    	{
    	    get { return "username";}
    		set { throw new NotSupportedException(); }
        }
    	public string zipPropertyName 
    	{
    	    get { return "zip";}
    		set { throw new NotSupportedException(); }
        }
    	public string zipplus4PropertyName 
    	{
    	    get { return "zipplus4";}
    		set { throw new NotSupportedException(); }
        }
    	#endregion
    
    }
}
