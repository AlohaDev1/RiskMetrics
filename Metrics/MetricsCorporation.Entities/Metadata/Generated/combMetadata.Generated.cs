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
    
    public partial class combMetadata : IEntityMetadata
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
    		    		 UniqueIDPropertyName
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
    		    		 UniqueIDPropertyName
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
    			pk.Add(CountyNumPropertyName, "Optional");
    			pk.Add(DescriptionPropertyName, "Optional");
    			pk.Add(DUNS_LocPropertyName, "Optional");
    			pk.Add(DUNS_ULTPropertyName, "Optional");
    			pk.Add(FEINPropertyName, "Optional");
    			pk.Add(MailingAddressPropertyName, "Optional");
    			pk.Add(MailingAddressCityPropertyName, "Optional");
    			pk.Add(MailingAddressStatePropertyName, "Optional");
    			pk.Add(MailingAddressZipPropertyName, "Optional");
    			pk.Add(MailingAddressZip4PropertyName, "Optional");
    			pk.Add(MasterUIDPropertyName, "Optional");
    			pk.Add(PhoneEmpPropertyName, "Optional");
    			pk.Add(PhysicalAddressPropertyName, "Optional");
    			pk.Add(PhysicalAddressCityPropertyName, "Optional");
    			pk.Add(PhysicalAddressStatePropertyName, "Optional");
    			pk.Add(PhysicalAddressZipPropertyName, "Optional");
    			pk.Add(PhysicalAddressZip4PropertyName, "Optional");
    			pk.Add(RecordTypePropertyName, "Optional");
    			pk.Add(ReportingStatePropertyName, "Optional");
    			pk.Add(UniqueIDPropertyName, "Mandatory");
                return pk;
            }
        }
    	
    	/// <summary>
        /// Strong typed property names
        /// </summary>
        #region Property Names Metadata
    	public string CountyNumPropertyName 
    	{
    	    get { return "CountyNum";}
    		set { throw new NotSupportedException(); }
        }
    	public string DescriptionPropertyName 
    	{
    	    get { return "Description";}
    		set { throw new NotSupportedException(); }
        }
    	public string DUNS_LocPropertyName 
    	{
    	    get { return "DUNS_Loc";}
    		set { throw new NotSupportedException(); }
        }
    	public string DUNS_ULTPropertyName 
    	{
    	    get { return "DUNS_ULT";}
    		set { throw new NotSupportedException(); }
        }
    	public string FEINPropertyName 
    	{
    	    get { return "FEIN";}
    		set { throw new NotSupportedException(); }
        }
    	public string MailingAddressPropertyName 
    	{
    	    get { return "MailingAddress";}
    		set { throw new NotSupportedException(); }
        }
    	public string MailingAddressCityPropertyName 
    	{
    	    get { return "MailingAddressCity";}
    		set { throw new NotSupportedException(); }
        }
    	public string MailingAddressStatePropertyName 
    	{
    	    get { return "MailingAddressState";}
    		set { throw new NotSupportedException(); }
        }
    	public string MailingAddressZipPropertyName 
    	{
    	    get { return "MailingAddressZip";}
    		set { throw new NotSupportedException(); }
        }
    	public string MailingAddressZip4PropertyName 
    	{
    	    get { return "MailingAddressZip4";}
    		set { throw new NotSupportedException(); }
        }
    	public string MasterUIDPropertyName 
    	{
    	    get { return "MasterUID";}
    		set { throw new NotSupportedException(); }
        }
    	public string PhoneEmpPropertyName 
    	{
    	    get { return "PhoneEmp";}
    		set { throw new NotSupportedException(); }
        }
    	public string PhysicalAddressPropertyName 
    	{
    	    get { return "PhysicalAddress";}
    		set { throw new NotSupportedException(); }
        }
    	public string PhysicalAddressCityPropertyName 
    	{
    	    get { return "PhysicalAddressCity";}
    		set { throw new NotSupportedException(); }
        }
    	public string PhysicalAddressStatePropertyName 
    	{
    	    get { return "PhysicalAddressState";}
    		set { throw new NotSupportedException(); }
        }
    	public string PhysicalAddressZipPropertyName 
    	{
    	    get { return "PhysicalAddressZip";}
    		set { throw new NotSupportedException(); }
        }
    	public string PhysicalAddressZip4PropertyName 
    	{
    	    get { return "PhysicalAddressZip4";}
    		set { throw new NotSupportedException(); }
        }
    	public string RecordTypePropertyName 
    	{
    	    get { return "RecordType";}
    		set { throw new NotSupportedException(); }
        }
    	public string ReportingStatePropertyName 
    	{
    	    get { return "ReportingState";}
    		set { throw new NotSupportedException(); }
        }
    	public string UniqueIDPropertyName 
    	{
    	    get { return "UniqueID";}
    		set { throw new NotSupportedException(); }
        }
    	#endregion
    
    }
}
