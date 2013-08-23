using System;
using System.Globalization;
using System.Linq;
using AutoMapper;
using MetricsCorporation.Data;
using MetricsCorporation.Entities;
using MetricsCorporation.Models;
using comb = MetricsCorporation.Entities.comb;
using county = MetricsCorporation.Data.county;
using employeesize = MetricsCorporation.Data.employeesize;
using exported = MetricsCorporation.Data.exported;
using jigsaw_logins = MetricsCorporation.Data.jigsaw_logins;
using number_of_logins = MetricsCorporation.Data.number_of_logins;
using searchlog = MetricsCorporation.Data.searchlog;
using usageinfo = MetricsCorporation.Data.usageinfo;
using user_states = MetricsCorporation.Data.user_states;
using usercredit = MetricsCorporation.Data.usercredit;

namespace MetricsCorporation.BL.Mapping
{
    public class GeneralProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Role, role>();
            CreateMap<role, Role>();

            CreateMap<UserModel, user>()
                .ForMember(a => a.roles, b => b.Ignore())
                .ForMember(a => a.activationdate, b => b.MapFrom(c => c.ActivationDate))
                .ForMember(a => a.admin, b => b.MapFrom(c => c.Admin))
                .ForMember(a => a.canexportlist, b => b.MapFrom(c => c.CanexportList))
                .ForMember(a => a.companyName, b => b.MapFrom(c => c.CompanyName))
                .ForMember(a => a.email, b => b.MapFrom(c => c.Email))
                .ForMember(a => a.expirationdate, b => b.MapFrom(c => c.ExpirationDate))
                .ForMember(a => a.filePath, b => b.MapFrom(c => c.FilePath))
                .ForMember(a => a.firstName, b => b.MapFrom(c => c.FirstName))
                .ForMember(a => a.headline, b => b.MapFrom(c => c.Headline))
                .ForMember(a => a.id, b => b.MapFrom(c => c.Id))
                .ForMember(a => a.internalaccount, b => b.MapFrom(c => c.InternalAccount))
                .ForMember(a => a.lastloginDate, b => b.MapFrom(c => c.LastLoginDate))
                .ForMember(a => a.lastName, b => b.MapFrom(c => c.LastName))
                .ForMember(a => a.linkedinId, b => b.MapFrom(c => c.LinkedInId))
                .ForMember(a => a.maxexports, b => b.MapFrom(c => c.MaxExports))
                .ForMember(a => a.maxjigsawexports, b => b.MapFrom(c => c.MaxJigsawExports))
                .ForMember(a => a.maxjigsawreportsviewspermonth, b => b.MapFrom(c => c.MaxJigsawReportsViewsPerMonth))
                .ForMember(a => a.maxjigsawreportsviewsperyear, b => b.MapFrom(c => c.MaxJigsawReportsViewsPerYear))
                .ForMember(a => a.maxreportviewspermonth, b => b.MapFrom(c => c.MaxReportViewsPerMonth))
                .ForMember(a => a.maxreportviewsperyear, b => b.MapFrom(c => c.MaxReportViewsPerYear))
                .ForMember(a => a.password, b => b.MapFrom(c => c.Password))
                .ForMember(a => a.profilerequest, b => b.MapFrom(c => c.ProfileRequest))
                .ForMember(a => a.renewaldate, b => b.MapFrom(c => c.RenewalDate))
                .ForMember(a => a.reportsJigwasByMonth, b => b.MapFrom(c => c.ReportsJigwasByMonth))
                .ForMember(a => a.reportsViewByMonth, b => b.MapFrom(c => c.ReportsViewByMonth))
                .ForMember(a => a.showcarrier, b => b.MapFrom(c => c.ShowCarrier))
                .ForMember(a => a.showstatusfld, b => b.MapFrom(c => c.ShowStatusFld))
                .ForMember(a => a.testaccount, b => b.MapFrom(c => c.TestAccount))
                .ForMember(a => a.userName, b => b.MapFrom(c => c.UserName));


            CreateMap<user, UserModel>()
                .ForMember(a => a.States, b => b.MapFrom(c => string.Join(",", c.user_states.Select(y => y.state_name))));


            CreateMap<ExportedModel, exported>();
            CreateMap<exported, ExportedModel>().ForMember(a => a.CompanyIds, b => b.ResolveUsing(c => c.exported_company.Select(e => e.CompanyId.ToString(CultureInfo.InvariantCulture))));

            CreateMap<FileListModel, filelist>();
            CreateMap<filelist, FileListModel>();

            CreateMap<UsageInfoModel, usageinfo>()
                .ForMember(a => a.carriername, b => b.MapFrom(c => c.CarrierNum))
                .ForMember(a => a.carriernum, b => b.MapFrom(c => c.CarrierNum))
                .ForMember(a => a.contactname, b => b.MapFrom(c => c.ContactName))
                .ForMember(a => a.countyname, b => b.MapFrom(c => c.CountyName))
                .ForMember(a => a.description, b => b.MapFrom(c => c.Description));
            CreateMap<usageinfo, UsageInfoModel>();


            CreateMap<CompanyModel, UsageInfoModel>()
                .ForMember(a => a.Id, b => b.Ignore())
                .ForMember(a => a.ClassCode, b => b.Ignore())
                .ForMember(a => a.CarrierNum, b => b.MapFrom(c => c.CarrierOfRecord))
                .ForMember(a => a.CarrierNum, b => b.MapFrom(c => c.CarrierGroupName))
                .ForMember(a => a.EffectiveDate, b => b.MapFrom(c => c.PolicyRenewalDate))
                .ForMember(a => a.EmpsizeRange, b => b.MapFrom(c => c.EmployeeSize))
                .ForMember(a => a.NaicCarrierNumber, b => b.UseValue(""))
                .ForMember(a => a.NaicGroupName, b => b.UseValue(""))
                .ForMember(a => a.Name, b => b.MapFrom(c => c.CompanyName))
                .ForMember(a => a.PhoneEmp, b => b.MapFrom(c => c.Phone))
                .ForMember(a => a.SalesVolRange, b => b.UseValue(""))
                .ForMember(a => a.UserName, b => b.UseValue(""))
                .ForMember(a => a.ZipPlus4, b => b.UseValue(""))
                .ForMember(a => a.CountyName, b => b.MapFrom(c => c.County))
                .ForMember(a => a.Description, b => b.UseValue(""));




            //TODO: remove for member after corret db 
            CreateMap<MasterIdModel, masterid>().ForMember(a => a.uername, b => b.MapFrom(c => c.UserName));
            CreateMap<masterid, MasterIdModel>().ForMember(a => a.UserName, b => b.MapFrom(c => c.uername)); ;

            CreateMap<CombModel, comb>();
            CreateMap<comb, CombModel>();


            CreateMap<CompanyModel, Data.prim>();
            CreateMap<Data.prim, CompanyModel>()
                    .ForMember(a => a.Id, b => b.MapFrom(c => c.MasterUID))
                    .ForMember(a => a.CompanyName, b => b.MapFrom(c => c.Description))
                    .ForMember(a => a.City, b => b.MapFrom(c => c.PhysicalAddressCity))
                    .ForMember(a => a.State, b => b.MapFrom(c => c.PhysicalAddressState))
                    .ForMember(a => a.EmployeeSize, b => b.MapFrom(c => c.EmployeeSizeRange))
                    .ForMember(a => a.SicCode, b => b.MapFrom(c => c.SICCode))
                    .ForMember(a => a.CarrierGroup, b => b.MapFrom(c => c.NAICGroupName))
                    .ForMember(a => a.County, b => b.MapFrom(c => c.CountyName))
                    .ForMember(a => a.Phone, b => b.MapFrom(c => c.PhoneEmp))
                    .ForMember(a => a.Zip, b => b.MapFrom(c => c.PhysicalAddressZip))
                    .ForMember(a => a.Address, b => b.MapFrom(c => c.PhysicalAddress))
                    .ForMember(a => a.Status, b => b.UseValue(""))
                    .ForMember(a => a.RenewalMonth, b => b.MapFrom(c => c.EffectiveMonth))
                    .ForMember(a => a.CarrierGroupName, b => b.MapFrom(c => c.NAICGroupName))
                    .ForMember(a => a.CarrierOfRecord, b => b.MapFrom(c => c.NAICCarrierName))
                    .ForMember(a => a.PolicyRenewalDate, b => b.MapFrom(c => c.EffectiveDate));

            //Added By Aloha

            CreateMap<Data.primarydata, CompanyModel>()
                    .ForMember(a => a.Id, b => b.MapFrom(c => c.masterUId))
                    .ForMember(a => a.RMID, b => b.MapFrom(c => c.rmId))
                    .ForMember(a => a.CompanyName, b => b.MapFrom(c => c.description))
                    .ForMember(a => a.City, b => b.MapFrom(c => c.city))
                    .ForMember(a => a.State, b => b.MapFrom(c => c.state))
                    .ForMember(a => a.EmployeeSize, b => b.MapFrom(c => c.employeesizecode.description))

                    .ForMember(a => a.SicCode, b => b.MapFrom(c => c.sicCode))
                    .ForMember(a => a.CarrierGroup, b => b.MapFrom(c => c.carrier.naicGroupName))
                    .ForMember(a => a.County, b => b.MapFrom(c => c.countyinformation.countyName))
                    .ForMember(a => a.Phone, b => b.MapFrom(c => c.contactinformations.FirstOrDefault().phoneNumber))
                    .ForMember(a => a.Zip, b => b.MapFrom(c => c.zip))
                    .ForMember(a => a.Address, b => b.MapFrom(c => c.address))                     
                    .ForMember(a => a.Status, b => b.MapFrom(c => c.statusCode))
                    .ForMember(a => a.RenewalMonth, b => b.MapFrom(c => c.effectiveMonth))
                    .ForMember(a => a.CarrierGroupName, b => b.MapFrom(c => c.carrier.naicGroupName))
                    .ForMember(a => a.CarrierOfRecord, b => b.MapFrom(c => c.carrier.naicName))
                    .ForMember(a => a.PolicyRenewalDate, b => b.MapFrom(c => c.effectiveDate))
                    .ForMember(a => a.ContactName, b => b.MapFrom(c => c.contactinformations.FirstOrDefault().contactName))
                    .ForMember(a => a.RecordType, b => b.MapFrom(c => c.recordType));

            CreateMap<Data.statecountycode, StateCountyModel>()
               .ForMember(a => a.CountyDescription, b => b.MapFrom(c => c.County_Description))
               .ForMember(a => a.CountyId, b => b.MapFrom(c => c.County_Number))
               .ForMember(a => a.StateDescription, b => b.MapFrom(c => c.State_Description))
               .ForMember(a => a.StatePrefix, b => b.MapFrom(c => c.State_Prefix));


            CreateMap<Data.siccode, SicCodeModel>()
            .ForMember(a => a.Id, b => b.MapFrom(c => c.Id))
            .ForMember(a => a.Division_Letter, b => b.MapFrom(c => c.Division_Letter))
            .ForMember(a => a.Division_Name, b => b.MapFrom(c => c.Division_Name))
            .ForMember(a => a.SIC_2_Digit_Code, b => b.MapFrom(c => c.SIC_2_Digit_Code))
            .ForMember(a => a.SIC_2_Digit_Code_Name, b => b.MapFrom(c => c.SIC_2_Digit_Code_Name))
            .ForMember(a => a.SIC_3_Digit_Code, b => b.MapFrom(c => c.SIC_3_Digit_Code))
            .ForMember(a => a.SIC_3_Digit_Code_Name, b => b.MapFrom(c => c.SIC_3_Digit_Code_Name))
            .ForMember(a => a.SIC_4_Digit_Code, b => b.MapFrom(c => c.SIC_4_Digit_Code))
            .ForMember(a => a.SIC_4_Digit_Code_Name, b => b.MapFrom(c => c.SIC_4_Digit_Code_Name));


            CreateMap<Data.classcode, ClassCodeModel>()
            .ForMember(a => a.Id, b => b.MapFrom(c => c.Id))
            .ForMember(a => a.Code, b => b.MapFrom(c => c.Code))
            .ForMember(a => a.Description, b => b.MapFrom(c => c.Description));


            CreateMap<Data.primarydata, CompanyAutocompleteModel>()
              .ForMember(a => a.Id, b => b.MapFrom(c => c.masterUId))
              .ForMember(a => a.Description, b => b.MapFrom(c => c.description));    




            CreateMap<Data.carrier, CarrierNameAutocompleteModel>()
            .ForMember(a => a.Id, b => b.MapFrom(c => c.naicNumber))
            .ForMember(a => a.Description, b => b.MapFrom(c => c.naicName))
            .ForMember(a => a.CarrierGroup, b => b.MapFrom(c => c.naicGroupName))
            .ForMember(a => a.CarrierName, b => b.MapFrom(c => c.naicName));

            //CreateMap<Data.carrier, CarrierNameModel>()
            //.ForMember(a => a.Id, b => b.MapFrom(c => c.NAICNumber))
            //.ForMember(a => a.CarrierGroup, b => b.MapFrom(c => c.NAICGroupName))
            //.ForMember(a => a.CarrierName, b => b.MapFrom(c => c.NAICName));


            CreateMap<CountyModel, county>();
            CreateMap<county, CountyModel>();

            CreateMap<EmployeeSizeModel, employeesize>();
            CreateMap<employeesize, EmployeeSizeModel>();

            CreateMap<SubscribtionModel, UserModel>();
            CreateMap<UserModel, SubscribtionModel>();


            CreateMap<NumberOfLoginsModel, number_of_logins>()
                .ForMember(a => a.loginCount, b => b.MapFrom(c => c.Count));
            //.ForMember(a => a.user_id, b => b.MapFrom(c => c.UserId));

            CreateMap<number_of_logins, NumberOfLoginsModel>()
                .ForMember(a => a.Count, b => b.MapFrom(c => c.loginCount));
            //.ForMember(a => a.UserId, b => b.MapFrom(c => c.user_id));

            CreateMap<SearchLogModel, searchlog>().ForMember(a => a.id, b => b.MapFrom(c => c.UserId));
            CreateMap<searchlog, SearchLogModel>().ForMember(a => a.UserId, b => b.MapFrom(c => c.id));

            CreateMap<MasterIdModel, UserModel>();
            CreateMap<UserModel, MasterIdModel>();


            CreateMap<SearchModel, SearchLogModel>()
                .ForMember(a => a.EmpSizeRange, b => b.MapFrom(c => string.Join(",", c.EmployeeSize)))
                .ForMember(a => a.EffectiveMonth, b => b.MapFrom(c => string.Join(",", c.RenewalMonths)))
                .ForMember(a => a.Description, b => b.MapFrom(c => c.CompanyName))
                .ForMember(a => a.Address, b => b.UseValue(""));

            CreateMap<SearchModel, CompanyModel>()
                .ForMember(a => a.CountyCodes, b => b.MapFrom(c => c.CountyName))
                .ForMember(a => a.Phone, b => b.MapFrom(c => c.PhoneNumber))
                .ForMember(a => a.EmpSize, b => b.MapFrom(c => c.EmployeeSize));

            CreateMap<JigsawLogins, jigsaw_logins>();
            CreateMap<jigsaw_logins, JigsawLogins>();

            CreateMap<UserCreditsModel, usercredit>().ForMember(a => a.user_id, b => b.MapFrom(c => c.UserId));
            CreateMap<usercredit, UserCreditsModel>().ForMember(a => a.UserId, b => b.MapFrom(c => c.user_id));

            CreateMap<UserStatesModel, user_states>();
            CreateMap<user_states, UserStatesModel>();

        }

    }
}