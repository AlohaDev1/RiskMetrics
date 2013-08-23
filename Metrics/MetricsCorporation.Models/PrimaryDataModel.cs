using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetricsCorporation.Models
{
    class PrimaryDataModel
    {

        public Int64 MasterUID
        {
            get { return _MasterUID; }
            set
            {
                _MasterUID = value;
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
        public SByte RecordType
        {
            get { return _RecordType; }
            set
            {
                _RecordType = value;
            }
        }
        public string Description
        {
            get { return _Description; }
            set
            {
                if (value == null)
                {
                    value = "";
                }

                _Description = value;
            }
        }
        public string Address
        {
            get { return _Address; }
            set
            {
                if (value == null)
                {
                    value = "";
                }

                _Address = value;
            }
        }
        public string City
        {
            get { return _City; }
            set
            {
                if (value == null)
                {
                    value = "";
                }

                _City = value;
            }
        }
        public string State
        {
            get { return _State; }
            set
            {
                if (value == null)
                {
                    value = "";
                }

                _State = value;
            }
        }
        public string Zip
        {
            get { return _Zip; }
            set
            {
                if (value == null)
                {
                    value = "";
                }

                _Zip = value;
            }
        }
        public string ZipExt
        {
            get { return _zipExt; }
            set
            {
                if (value == null)
                {
                    value = "";
                }

                _zipExt = value;
            }
        }
        public Int16 CountyCode
        {
            get { return _CountyCode; }
            set
            {
                _CountyCode = value;
            }
        }
        public SByte EmpSizeCode
        {
            get { return _EmpSizeCode; }
            set
            {
                _EmpSizeCode = value;
            }
        }
        public Int64 CarrierNumber
        {
            get { return _CarrierNumber; }
            set
            {
                _CarrierNumber = value;
            }
        }
        public string SICCode
        {
            get { return _SICCode; }
            set
            {
                if (value == null)
                {
                    value = "";
                }

                _SICCode = value;
            }
        }
        public string ClassCode
        {
            get { return _ClassCode; }
            set
            {
                if (value == null)
                {
                    value = "";
                }

                _ClassCode = value;
            }
        }
        public string NAICCode
        {
            get { return _NAICCode; }
            set
            {
                if (value == null)
                {
                    value = "";
                }

                _NAICCode = value;
            }
        }
        public string StatusCode
        {
            get { return _StatusCode; }
            set
            {
                if (value == null)
                {
                    value = "";
                }

                _StatusCode = value;
            }
        }
        public string DUNSNumber
        {
            get { return _DUNSNumber; }
            set
            {
                if (value == null)
                {
                    value = "";
                }

                _DUNSNumber = value;
            }
        }
        public string ExperianID
        {
            get { return _ExperianID; }
            set
            {
                if (value == null)
                {
                    value = "";
                }

                _ExperianID = value;
            }
        }
        public string EffectiveDate
        {
            get { return _EffectiveDate; }
            set
            {
                if (value == null)
                {
                    value = "";
                }

                _EffectiveDate = value;
            }
        }
        public string EffectiveMonth
        {
            get { return _EffectiveMonth; }
            set
            {
                if (value == null)
                {
                    value = "";
                }

                _EffectiveMonth = value;
            }
        }
        public string ContactName
        {
            get { return _ContactName; }
            set
            {
                if (value == null)
                {
                    value = "";
                }

                _ContactName = value;
            }
        }
        public string PhoneNum
        {
            get { return _Phonenumber; }
            set
            {
                if (value == null)
                {
                    value = "";
                }

                _Phonenumber = value;
            }
        }

        private Int64 _MasterUID;
        private string _RMID;
        private SByte _RecordType;
        private string _Description;
        private string _Address;
        private string _City;
        private string _State;
        private string _Zip;
        private string _zipExt;
        private Int16 _CountyCode;
        private SByte _EmpSizeCode;
        private Int64 _CarrierNumber;
        private string _SICCode;
        private string _ClassCode;
        private string _NAICCode;
        private string _NAICSCode;
        private string _StatusCode;
        private string _DUNSNumber;
        private string _ExperianID;
        private string _EffectiveDate;
        private string _EffectiveMonth;
        private string _ContactName;
        private string _Phonenumber;
    }
}
