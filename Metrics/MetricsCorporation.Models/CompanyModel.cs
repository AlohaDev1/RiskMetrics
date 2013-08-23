using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MetricsCorporation.Models
{
    public class CompanyModel
    {
        [ExcludeFromCsvExport]
        public string Id
        {
            get { return _id; }
            set
            {
                if (value == null)
                {
                    value = "";
                }

                _id = value;
            }
        }

        public string RMID
        {
            get { return _RMID; }
            set
            {
                if (value == null)
                {
                    value = "";
                }

                _RMID = value;
            }
        }

        public string RecordType
        {
            get { return _RecordType; }
            set
            {
                if (value == null)
                {
                    value = "";
                }

                _RecordType = value;
            }
        }

        public string CompanyName
        {
            get { return _companyName; }
            set
            {
                if (value == null)
                {
                    value = "";
                }

                _companyName = value;
            }
        }

        public string CarrierName
        {
            get { return _CarrierName; }
            set
            {
                if (value == null)
                {
                    value = "";
                }

                _CarrierName = value;
            }
        }

        public string City
        {
            get { return _city; }
            set
            {
                if (value == null)
                {
                    value = "";
                }

                _city = value;
            }
        }

        public string State
        {
            get { return _state; }
            set
            {
                if (value == null)
                {
                    value = "";
                }

                _state = value;
            }
        }

        public string Zip
        {
            get { return _zip; }
            set
            {
                if (value == null)
                {
                    value = "";
                }

                _zip = value;
            }
        }

        public string County
        {
            get { return _county; }
            set
            {
                if (value == null)
                {
                    value = "";
                }

                _county = value;
            }
        }

        public string Phone
        {
            get { return _phone; }
            set
            {
                if (value == null)
                {
                    value = "";
                }

                _phone = value;
            }
        }

        [ExcludeFromCsvExport]
        public bool HavePhone { get; set; }

        [DisplayName("Sic Code")]
        public string SicCode
        {
            get { return _sicCode; }
            set
            {
                if (value == null)
                {
                    value = "";
                }

                _sicCode = value;
            }
        }

        [ExcludeFromCsvExport]
        public string RenewalMonth
        {
            get { return _renewalMonth; }
            set
            {
                if (value == null)
                {
                    value = "";
                }

                _renewalMonth = value;
            }
        }

        public string EmployeeSize
        {
            get { return _employeeSize; }
            set
            {
                if (value == null)
                {
                    value = "";
                }

                _employeeSize = value;
            }
        }

        public string CarrierGroup
        {
            get { return _carrierGroup; }
            set
            {
                if (value == null)
                {
                    value = "";
                }

                _carrierGroup = value;
            }
        }

        [ExcludeFromCsvExport]
        public string SearchName
        {
            get
            {
                if (_searchName == null)
                {
                    _searchName = "";
                }
                return _searchName;
            }
            set
            {
                if (value == null)
                {
                    value = "";
                }

                _searchName = value;
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                if (value == null)
                {
                    value = "";
                }

                _address = value;
            }
        }

        public string ClassCode
        {
            get { return _classCode; }
            set
            {
                if (value == null)
                {
                    value = "";
                }

                _classCode = value;
            }
        }

        public string Status
        {
            get { return _status; }
            set
            {
                if (value == null)
                {
                    value = "";
                }

                _status = value;
            }
        }

        public string AdditionalInfo
        {
            get { return _additionalInfo; }
            set
            {
                if (value == null)
                {
                    value = "";
                }

                _additionalInfo = value;
            }
        }

        [ExcludeFromCsvExport]
        public int UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
            }
        }

        public string PolicyRenewalDate { get; set; }
        [ExcludeFromCsvExport]
        public string CarrierOfRecord
        {
            get { return _carrierOfRecord; }
            set { _carrierOfRecord = value; }
        }
        public string CarrierGroupName
        {
            get { return _carrierGroupName; }
            set { _carrierGroupName = value; }
        }
        [ExcludeFromCsvExport]
        public List<string> States
        {
            get { return _states; }
            set { _states = value; }
        }
        [ExcludeFromCsvExport]
        public bool ShowCarrier { get; set; }
        [ExcludeFromCsvExport]
        public bool ShowStatusFld { get; set; }
        [ExcludeFromCsvExport]
        public string[] RenewalMonths { get; set; }
        public decimal?[] CarrierNumbers { get; set; }

        private List<string> _states = new List<string>();

        public string ContactName { get; set; }

        private string _id;
        private string _RMID;
        private string _RecordType;
        private string _companyName;
        private string _CarrierName;
        private string _city;
        private string _state;
        private string _zip;
        private string _county;
        private string _phone;
        private string _sicCode;
        private string _renewalMonth;
        private string _employeeSize;
        private string _carrierGroup;
        private string _carrierGroupName;
        private string _carrierOfRecord;
        private string _searchName;
        private string _address;
        private string _classCode;
        private string _status;
        private int _userId { get; set; }
        private string _additionalInfo;

        [ExcludeFromCsvExportAttribute]
        public long?[] CountyCodes { get; set; }
        [ExcludeFromCsvExportAttribute]
        public string[] EmpSize { get; set; }
        [ExcludeFromCsvExportAttribute]
        public string[] SicCodes { get; set; }
        [ExcludeFromCsvExportAttribute]
        public string[] ClassCodes { get; set; }
        [ExcludeFromCsvExportAttribute]
        public bool HasPhoneNumber { get; set; }
    }

    public class ViewreportModel
    {
        public CompanyModel Company { get; set; }
        public bool ViewReportbit { get; set; }
    }

    public class ExcludeFromCsvExportAttribute : Attribute
    {

    }

    public class CompanyGrid
    {
        public string EmployeeSize { get; set; }

        public string CarrierGroup { get; set; }

        public long Id { get; set; }

        public string Status { get; set; }

        public string City { get; set; }

        public string CompanyName { get; set; }

        public string State { get; set; }

        public string SicCode { get; set; }

        public bool IsExport { get; set; }
    }

    public class AdditionalInfo
    {

        public string Address { get; set; }

        public string State { get; set; }

        public string CompanyName { get; set; }

        public string City { get; set; }

        public string Zip { get; set; }
    }

    public class CompanyInfoModel
    {
        public string EmployeeSize { get; set; }

        public string CarrierGroup { get; set; }

        public long Id { get; set; }

        public string Status { get; set; }

        public string City { get; set; }

        public string CompanyName { get; set; }

        public string State { get; set; }

        public string SicCode { get; set; }
    }
}
