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
    
    public partial class primMetadata : IEntityMetadata
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
    		    		 MasterUIDPropertyName
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
    		    		 MasterUIDPropertyName
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
    			pk.Add(AmbulancePropertyName, "Optional");
    			pk.Add(AssessedImprovementValuePropertyName, "Optional");
    			pk.Add(AssessedLandValuePropertyName, "Optional");
    			pk.Add(AssessmentYearPropertyName, "Optional");
    			pk.Add(Basic_Economy_CarPropertyName, "Optional");
    			pk.Add(Basic_Luxury_CarPropertyName, "Optional");
    			pk.Add(Basic_Sporty_CarPropertyName, "Optional");
    			pk.Add(BuildingAreaPropertyName, "Optional");
    			pk.Add(BusPropertyName, "Optional");
    			pk.Add(Cab_ChassisPropertyName, "Optional");
    			pk.Add(Camper_Motor_DrivenPropertyName, "Optional");
    			pk.Add(Car_CarrierPropertyName, "Optional");
    			pk.Add(Car_FleetPropertyName, "Optional");
    			pk.Add(ClassCodePropertyName, "Optional");
    			pk.Add(Compact_PickupPropertyName, "Optional");
    			pk.Add(ContactNamePropertyName, "Optional");
    			pk.Add(CountyNamePropertyName, "Optional");
    			pk.Add(CountyNumPropertyName, "Optional");
    			pk.Add(CurrentOwnerAddressPropertyName, "Optional");
    			pk.Add(CurrentOwnerCareOfPropertyName, "Optional");
    			pk.Add(CurrentOwnerCityPropertyName, "Optional");
    			pk.Add(CurrentOwnerNamePropertyName, "Optional");
    			pk.Add(CurrentOwnerStatePropertyName, "Optional");
    			pk.Add(CurrentOwnerZipPropertyName, "Optional");
    			pk.Add(CurrentOwnerZip4PropertyName, "Optional");
    			pk.Add(Cutaway_VanPropertyName, "Optional");
    			pk.Add(DescriptionPropertyName, "Optional");
    			pk.Add(Dump_TruckPropertyName, "Optional");
    			pk.Add(DUNS_LocPropertyName, "Optional");
    			pk.Add(DUNS_ULTPropertyName, "Optional");
    			pk.Add(DUNSConfidenceCodePropertyName, "Optional");
    			pk.Add(EffectiveDatePropertyName, "Optional");
    			pk.Add(EffectiveMonthPropertyName, "Optional");
    			pk.Add(ElevatorPropertyName, "Optional");
    			pk.Add(EmployeeSizeRangePropertyName, "Optional");
    			pk.Add(Entry_Level_CarPropertyName, "Optional");
    			pk.Add(FEINPropertyName, "Optional");
    			pk.Add(Flat_BedPropertyName, "Optional");
    			pk.Add(Fullsize_PickupPropertyName, "Optional");
    			pk.Add(Fullsize_UtilityPropertyName, "Optional");
    			pk.Add(Fullsize_Van_CargoPropertyName, "Optional");
    			pk.Add(Heavy_Duty_Station_WagonPropertyName, "Optional");
    			pk.Add(Log_CarrierPropertyName, "Optional");
    			pk.Add(Lower_Middle_CarPropertyName, "Optional");
    			pk.Add(Luxury_PickupPropertyName, "Optional");
    			pk.Add(MailingAddressPropertyName, "Optional");
    			pk.Add(MailingAddressCityPropertyName, "Optional");
    			pk.Add(MailingAddressStatePropertyName, "Optional");
    			pk.Add(MailingAddressZipPropertyName, "Optional");
    			pk.Add(MailingAddressZip4PropertyName, "Optional");
    			pk.Add(MarketValueImprovementPropertyName, "Optional");
    			pk.Add(MarketValueLandPropertyName, "Optional");
    			pk.Add(MarketValueYearPropertyName, "Optional");
    			pk.Add(MasterUIDPropertyName, "Mandatory");
    			pk.Add(Mid_Luxury_CarPropertyName, "Optional");
    			pk.Add(Mid_Sporty_CarPropertyName, "Optional");
    			pk.Add(Midsize_PickupPropertyName, "Optional");
    			pk.Add(Mini_Sport_UtilityPropertyName, "Optional");
    			pk.Add(Minivan_CargoPropertyName, "Optional");
    			pk.Add(Minivan_PassengerPropertyName, "Optional");
    			pk.Add(MotorhomePropertyName, "Optional");
    			pk.Add(NAICCarrierNamePropertyName, "Optional");
    			pk.Add(NAICGroupNamePropertyName, "Optional");
    			pk.Add(NoOfBuildingsPropertyName, "Optional");
    			pk.Add(NoOfStoriesPropertyName, "Optional");
    			pk.Add(OriginalContractDatePropertyName, "Optional");
    			pk.Add(OriginalLotSizePropertyName, "Optional");
    			pk.Add(Panel_TruckPropertyName, "Optional");
    			pk.Add(PhoneEmpPropertyName, "Optional");
    			pk.Add(PhysicalAddressPropertyName, "Optional");
    			pk.Add(PhysicalAddressCityPropertyName, "Optional");
    			pk.Add(PhysicalAddressStatePropertyName, "Optional");
    			pk.Add(PhysicalAddressZipPropertyName, "Optional");
    			pk.Add(PhysicalAddressZip4PropertyName, "Optional");
    			pk.Add(Pickup_CamperPropertyName, "Optional");
    			pk.Add(PolicySelfPropertyName, "Optional");
    			pk.Add(PoolPropertyName, "Optional");
    			pk.Add(Prestige_Luxury_CarPropertyName, "Optional");
    			pk.Add(Prestige_Sporty_CarPropertyName, "Optional");
    			pk.Add(RecordingDateAssessmentPropertyName, "Optional");
    			pk.Add(Refrigerator_TruckPropertyName, "Optional");
    			pk.Add(ReportingStatePropertyName, "Optional");
    			pk.Add(SalesPricePropertyName, "Optional");
    			pk.Add(Sedan_DeliveryPropertyName, "Optional");
    			pk.Add(SICCodePropertyName, "Optional");
    			pk.Add(SICCode2PropertyName, "Optional");
    			pk.Add(Sport_UtilityPropertyName, "Optional");
    			pk.Add(Stake_TruckPropertyName, "Optional");
    			pk.Add(StateNumPropertyName, "Optional");
    			pk.Add(Station_Wagon_TruckPropertyName, "Optional");
    			pk.Add(Step_VanPropertyName, "Optional");
    			pk.Add(Tank_TruckPropertyName, "Optional");
    			pk.Add(Total_FleetPropertyName, "Optional");
    			pk.Add(TotalAssessedValuePropertyName, "Optional");
    			pk.Add(TotalMarketValuePropertyName, "Optional");
    			pk.Add(Tractor_TruckPropertyName, "Optional");
    			pk.Add(Traditional_Large_CarPropertyName, "Optional");
    			pk.Add(Transit_MixerPropertyName, "Optional");
    			pk.Add(Truck_FleetPropertyName, "Optional");
    			pk.Add(Upper_Middle_CarPropertyName, "Optional");
    			pk.Add(Upper_Middle_Specialty_CarPropertyName, "Optional");
    			pk.Add(Van_CamperPropertyName, "Optional");
    			pk.Add(Window_Van_PassengerPropertyName, "Optional");
    			pk.Add(WreckerPropertyName, "Optional");
    			pk.Add(YearBuiltPropertyName, "Optional");
    			pk.Add(ZoningPropertyName, "Optional");
                return pk;
            }
        }
    	
    	/// <summary>
        /// Strong typed property names
        /// </summary>
        #region Property Names Metadata
    	public string AmbulancePropertyName 
    	{
    	    get { return "Ambulance";}
    		set { throw new NotSupportedException(); }
        }
    	public string AssessedImprovementValuePropertyName 
    	{
    	    get { return "AssessedImprovementValue";}
    		set { throw new NotSupportedException(); }
        }
    	public string AssessedLandValuePropertyName 
    	{
    	    get { return "AssessedLandValue";}
    		set { throw new NotSupportedException(); }
        }
    	public string AssessmentYearPropertyName 
    	{
    	    get { return "AssessmentYear";}
    		set { throw new NotSupportedException(); }
        }
    	public string Basic_Economy_CarPropertyName 
    	{
    	    get { return "Basic_Economy_Car";}
    		set { throw new NotSupportedException(); }
        }
    	public string Basic_Luxury_CarPropertyName 
    	{
    	    get { return "Basic_Luxury_Car";}
    		set { throw new NotSupportedException(); }
        }
    	public string Basic_Sporty_CarPropertyName 
    	{
    	    get { return "Basic_Sporty_Car";}
    		set { throw new NotSupportedException(); }
        }
    	public string BuildingAreaPropertyName 
    	{
    	    get { return "BuildingArea";}
    		set { throw new NotSupportedException(); }
        }
    	public string BusPropertyName 
    	{
    	    get { return "Bus";}
    		set { throw new NotSupportedException(); }
        }
    	public string Cab_ChassisPropertyName 
    	{
    	    get { return "Cab_Chassis";}
    		set { throw new NotSupportedException(); }
        }
    	public string Camper_Motor_DrivenPropertyName 
    	{
    	    get { return "Camper_Motor_Driven";}
    		set { throw new NotSupportedException(); }
        }
    	public string Car_CarrierPropertyName 
    	{
    	    get { return "Car_Carrier";}
    		set { throw new NotSupportedException(); }
        }
    	public string Car_FleetPropertyName 
    	{
    	    get { return "Car_Fleet";}
    		set { throw new NotSupportedException(); }
        }
    	public string ClassCodePropertyName 
    	{
    	    get { return "ClassCode";}
    		set { throw new NotSupportedException(); }
        }
    	public string Compact_PickupPropertyName 
    	{
    	    get { return "Compact_Pickup";}
    		set { throw new NotSupportedException(); }
        }
    	public string ContactNamePropertyName 
    	{
    	    get { return "ContactName";}
    		set { throw new NotSupportedException(); }
        }
    	public string CountyNamePropertyName 
    	{
    	    get { return "CountyName";}
    		set { throw new NotSupportedException(); }
        }
    	public string CountyNumPropertyName 
    	{
    	    get { return "CountyNum";}
    		set { throw new NotSupportedException(); }
        }
    	public string CurrentOwnerAddressPropertyName 
    	{
    	    get { return "CurrentOwnerAddress";}
    		set { throw new NotSupportedException(); }
        }
    	public string CurrentOwnerCareOfPropertyName 
    	{
    	    get { return "CurrentOwnerCareOf";}
    		set { throw new NotSupportedException(); }
        }
    	public string CurrentOwnerCityPropertyName 
    	{
    	    get { return "CurrentOwnerCity";}
    		set { throw new NotSupportedException(); }
        }
    	public string CurrentOwnerNamePropertyName 
    	{
    	    get { return "CurrentOwnerName";}
    		set { throw new NotSupportedException(); }
        }
    	public string CurrentOwnerStatePropertyName 
    	{
    	    get { return "CurrentOwnerState";}
    		set { throw new NotSupportedException(); }
        }
    	public string CurrentOwnerZipPropertyName 
    	{
    	    get { return "CurrentOwnerZip";}
    		set { throw new NotSupportedException(); }
        }
    	public string CurrentOwnerZip4PropertyName 
    	{
    	    get { return "CurrentOwnerZip4";}
    		set { throw new NotSupportedException(); }
        }
    	public string Cutaway_VanPropertyName 
    	{
    	    get { return "Cutaway_Van";}
    		set { throw new NotSupportedException(); }
        }
    	public string DescriptionPropertyName 
    	{
    	    get { return "Description";}
    		set { throw new NotSupportedException(); }
        }
    	public string Dump_TruckPropertyName 
    	{
    	    get { return "Dump_Truck";}
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
    	public string DUNSConfidenceCodePropertyName 
    	{
    	    get { return "DUNSConfidenceCode";}
    		set { throw new NotSupportedException(); }
        }
    	public string EffectiveDatePropertyName 
    	{
    	    get { return "EffectiveDate";}
    		set { throw new NotSupportedException(); }
        }
    	public string EffectiveMonthPropertyName 
    	{
    	    get { return "EffectiveMonth";}
    		set { throw new NotSupportedException(); }
        }
    	public string ElevatorPropertyName 
    	{
    	    get { return "Elevator";}
    		set { throw new NotSupportedException(); }
        }
    	public string EmployeeSizeRangePropertyName 
    	{
    	    get { return "EmployeeSizeRange";}
    		set { throw new NotSupportedException(); }
        }
    	public string Entry_Level_CarPropertyName 
    	{
    	    get { return "Entry_Level_Car";}
    		set { throw new NotSupportedException(); }
        }
    	public string FEINPropertyName 
    	{
    	    get { return "FEIN";}
    		set { throw new NotSupportedException(); }
        }
    	public string Flat_BedPropertyName 
    	{
    	    get { return "Flat_Bed";}
    		set { throw new NotSupportedException(); }
        }
    	public string Fullsize_PickupPropertyName 
    	{
    	    get { return "Fullsize_Pickup";}
    		set { throw new NotSupportedException(); }
        }
    	public string Fullsize_UtilityPropertyName 
    	{
    	    get { return "Fullsize_Utility";}
    		set { throw new NotSupportedException(); }
        }
    	public string Fullsize_Van_CargoPropertyName 
    	{
    	    get { return "Fullsize_Van_Cargo";}
    		set { throw new NotSupportedException(); }
        }
    	public string Heavy_Duty_Station_WagonPropertyName 
    	{
    	    get { return "Heavy_Duty_Station_Wagon";}
    		set { throw new NotSupportedException(); }
        }
    	public string Log_CarrierPropertyName 
    	{
    	    get { return "Log_Carrier";}
    		set { throw new NotSupportedException(); }
        }
    	public string Lower_Middle_CarPropertyName 
    	{
    	    get { return "Lower_Middle_Car";}
    		set { throw new NotSupportedException(); }
        }
    	public string Luxury_PickupPropertyName 
    	{
    	    get { return "Luxury_Pickup";}
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
    	public string MarketValueImprovementPropertyName 
    	{
    	    get { return "MarketValueImprovement";}
    		set { throw new NotSupportedException(); }
        }
    	public string MarketValueLandPropertyName 
    	{
    	    get { return "MarketValueLand";}
    		set { throw new NotSupportedException(); }
        }
    	public string MarketValueYearPropertyName 
    	{
    	    get { return "MarketValueYear";}
    		set { throw new NotSupportedException(); }
        }
    	public string MasterUIDPropertyName 
    	{
    	    get { return "MasterUID";}
    		set { throw new NotSupportedException(); }
        }
    	public string Mid_Luxury_CarPropertyName 
    	{
    	    get { return "Mid_Luxury_Car";}
    		set { throw new NotSupportedException(); }
        }
    	public string Mid_Sporty_CarPropertyName 
    	{
    	    get { return "Mid_Sporty_Car";}
    		set { throw new NotSupportedException(); }
        }
    	public string Midsize_PickupPropertyName 
    	{
    	    get { return "Midsize_Pickup";}
    		set { throw new NotSupportedException(); }
        }
    	public string Mini_Sport_UtilityPropertyName 
    	{
    	    get { return "Mini_Sport_Utility";}
    		set { throw new NotSupportedException(); }
        }
    	public string Minivan_CargoPropertyName 
    	{
    	    get { return "Minivan_Cargo";}
    		set { throw new NotSupportedException(); }
        }
    	public string Minivan_PassengerPropertyName 
    	{
    	    get { return "Minivan_Passenger";}
    		set { throw new NotSupportedException(); }
        }
    	public string MotorhomePropertyName 
    	{
    	    get { return "Motorhome";}
    		set { throw new NotSupportedException(); }
        }
    	public string NAICCarrierNamePropertyName 
    	{
    	    get { return "NAICCarrierName";}
    		set { throw new NotSupportedException(); }
        }
    	public string NAICGroupNamePropertyName 
    	{
    	    get { return "NAICGroupName";}
    		set { throw new NotSupportedException(); }
        }
    	public string NoOfBuildingsPropertyName 
    	{
    	    get { return "NoOfBuildings";}
    		set { throw new NotSupportedException(); }
        }
    	public string NoOfStoriesPropertyName 
    	{
    	    get { return "NoOfStories";}
    		set { throw new NotSupportedException(); }
        }
    	public string OriginalContractDatePropertyName 
    	{
    	    get { return "OriginalContractDate";}
    		set { throw new NotSupportedException(); }
        }
    	public string OriginalLotSizePropertyName 
    	{
    	    get { return "OriginalLotSize";}
    		set { throw new NotSupportedException(); }
        }
    	public string Panel_TruckPropertyName 
    	{
    	    get { return "Panel_Truck";}
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
    	public string Pickup_CamperPropertyName 
    	{
    	    get { return "Pickup_Camper";}
    		set { throw new NotSupportedException(); }
        }
    	public string PolicySelfPropertyName 
    	{
    	    get { return "PolicySelf";}
    		set { throw new NotSupportedException(); }
        }
    	public string PoolPropertyName 
    	{
    	    get { return "Pool";}
    		set { throw new NotSupportedException(); }
        }
    	public string Prestige_Luxury_CarPropertyName 
    	{
    	    get { return "Prestige_Luxury_Car";}
    		set { throw new NotSupportedException(); }
        }
    	public string Prestige_Sporty_CarPropertyName 
    	{
    	    get { return "Prestige_Sporty_Car";}
    		set { throw new NotSupportedException(); }
        }
    	public string RecordingDateAssessmentPropertyName 
    	{
    	    get { return "RecordingDateAssessment";}
    		set { throw new NotSupportedException(); }
        }
    	public string Refrigerator_TruckPropertyName 
    	{
    	    get { return "Refrigerator_Truck";}
    		set { throw new NotSupportedException(); }
        }
    	public string ReportingStatePropertyName 
    	{
    	    get { return "ReportingState";}
    		set { throw new NotSupportedException(); }
        }
    	public string SalesPricePropertyName 
    	{
    	    get { return "SalesPrice";}
    		set { throw new NotSupportedException(); }
        }
    	public string Sedan_DeliveryPropertyName 
    	{
    	    get { return "Sedan_Delivery";}
    		set { throw new NotSupportedException(); }
        }
    	public string SICCodePropertyName 
    	{
    	    get { return "SICCode";}
    		set { throw new NotSupportedException(); }
        }
    	public string SICCode2PropertyName 
    	{
    	    get { return "SICCode2";}
    		set { throw new NotSupportedException(); }
        }
    	public string Sport_UtilityPropertyName 
    	{
    	    get { return "Sport_Utility";}
    		set { throw new NotSupportedException(); }
        }
    	public string Stake_TruckPropertyName 
    	{
    	    get { return "Stake_Truck";}
    		set { throw new NotSupportedException(); }
        }
    	public string StateNumPropertyName 
    	{
    	    get { return "StateNum";}
    		set { throw new NotSupportedException(); }
        }
    	public string Station_Wagon_TruckPropertyName 
    	{
    	    get { return "Station_Wagon_Truck";}
    		set { throw new NotSupportedException(); }
        }
    	public string Step_VanPropertyName 
    	{
    	    get { return "Step_Van";}
    		set { throw new NotSupportedException(); }
        }
    	public string Tank_TruckPropertyName 
    	{
    	    get { return "Tank_Truck";}
    		set { throw new NotSupportedException(); }
        }
    	public string Total_FleetPropertyName 
    	{
    	    get { return "Total_Fleet";}
    		set { throw new NotSupportedException(); }
        }
    	public string TotalAssessedValuePropertyName 
    	{
    	    get { return "TotalAssessedValue";}
    		set { throw new NotSupportedException(); }
        }
    	public string TotalMarketValuePropertyName 
    	{
    	    get { return "TotalMarketValue";}
    		set { throw new NotSupportedException(); }
        }
    	public string Tractor_TruckPropertyName 
    	{
    	    get { return "Tractor_Truck";}
    		set { throw new NotSupportedException(); }
        }
    	public string Traditional_Large_CarPropertyName 
    	{
    	    get { return "Traditional_Large_Car";}
    		set { throw new NotSupportedException(); }
        }
    	public string Transit_MixerPropertyName 
    	{
    	    get { return "Transit_Mixer";}
    		set { throw new NotSupportedException(); }
        }
    	public string Truck_FleetPropertyName 
    	{
    	    get { return "Truck_Fleet";}
    		set { throw new NotSupportedException(); }
        }
    	public string Upper_Middle_CarPropertyName 
    	{
    	    get { return "Upper_Middle_Car";}
    		set { throw new NotSupportedException(); }
        }
    	public string Upper_Middle_Specialty_CarPropertyName 
    	{
    	    get { return "Upper_Middle_Specialty_Car";}
    		set { throw new NotSupportedException(); }
        }
    	public string Van_CamperPropertyName 
    	{
    	    get { return "Van_Camper";}
    		set { throw new NotSupportedException(); }
        }
    	public string Window_Van_PassengerPropertyName 
    	{
    	    get { return "Window_Van_Passenger";}
    		set { throw new NotSupportedException(); }
        }
    	public string WreckerPropertyName 
    	{
    	    get { return "Wrecker";}
    		set { throw new NotSupportedException(); }
        }
    	public string YearBuiltPropertyName 
    	{
    	    get { return "YearBuilt";}
    		set { throw new NotSupportedException(); }
        }
    	public string ZoningPropertyName 
    	{
    	    get { return "Zoning";}
    		set { throw new NotSupportedException(); }
        }
    	#endregion
    
    }
}
