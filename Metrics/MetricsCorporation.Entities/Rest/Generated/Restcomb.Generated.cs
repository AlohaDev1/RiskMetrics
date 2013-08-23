/************************************************************
*
*	Entity class generated from MetricsCorporationModel.edmx
*
*************************************************************/
using System;
using System.Collections.Generic;

namespace MetricsCorporation.Entities.Rest
{
    
    public partial class Restcomb
    {
    
        public int UniqueID { get; set; }
        public string MasterUID { get; set; }
        public string DUNS_ULT { get; set; }
        public string DUNS_Loc { get; set; }
        public string Description { get; set; }
        public string MailingAddress { get; set; }
        public string MailingAddressCity { get; set; }
        public string MailingAddressState { get; set; }
        public string MailingAddressZip { get; set; }
        public string MailingAddressZip4 { get; set; }
        public string PhysicalAddress { get; set; }
        public string PhysicalAddressCity { get; set; }
        public string PhysicalAddressState { get; set; }
        public string PhysicalAddressZip { get; set; }
        public string PhysicalAddressZip4 { get; set; }
        public string PhoneEmp { get; set; }
        public string FEIN { get; set; }
        public string CountyNum { get; set; }
        public string RecordType { get; set; }
        public string ReportingState { get; set; }
    
    }
}
