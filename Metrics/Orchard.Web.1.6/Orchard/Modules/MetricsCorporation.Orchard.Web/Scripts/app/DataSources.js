// Define application Descriptionspace

var MetricsCorporationApp = window.MetricsCorporationApp = {};

var SicCodeArray = [];
var ClassCodeArray = [];
var sicCodeParents = [];
var classCodeParents = [];
var sicCodeText = [];
var classCodeText = [];

// Define class with static variables like sic codes or monthes
// Also here stord url's  for webapis
MetricsCorporationApp.DataSources = function () {
    var self = this;

    //Url's for weabpis

    self.baseUri = '/api/MetricsCorporation.Orchard.Api/companymodel';
    self.countyUri = '/api/MetricsCorporation.Orchard.Api/county/';
    self.employeeSizeUri = '/api/MetricsCorporation.Orchard.Api/employeesize';
    self.sicCodeUri = '/api/MetricsCorporation.Orchard.Api/siccode';
    self.topSearchesUri = '/api/MetricsCorporation.Orchard.Api/topsearches';
    self.combUri = '/api/MetricsCorporation.Orchard.Api/comb';
    self.companyAutocompleteUri = '/api/MetricsCorporation.Orchard.Api/companyAutocomplete?';
    self.carrierNameAutocompleteUri = '/api/MetricsCorporation.Orchard.Api/carrierNameAutocomplete';
    self.downloadUrl = '/MetricsCorporation.Orchard.Web/Search/Download/';
    self.exportUrl = '/MetricsCorporation.Orchard.Web/Search/ExportCompanies/';
    self.saveExportUrl = '/MetricsCorporation.Orchard.Web/Search/SaveExportCompanies/';
    self.downloadClientUrl = '/MetricsCorporation.Orchard.Web/Search/DownloadClient/';
    self.linkedInCompanyIdUrl = 'http://www.linkedin.com/ta/federator?types=company&query=';
    self.contactsUri = '/api/MetricsCorporation.Orchard.Api/contacts';
    self.userSettings = '/MetricsCorporation.Orchard.Web/Account/GetUserSettings';
    self.companyReport = '/api/MetricsCorporation.Orchard.Api/UsageInfo/VerifyGetReport';
    self.geography = '/api/MetricsCorporation.Orchard.Api/statecounty/Get';
    self.sicCode = '/api/MetricsCorporation.Orchard.Api/siccode/Get';
    self.classCode = '/api/MetricsCorporation.Orchard.Api/classcode/Get';
    self.carrierName = '/api/MetricsCorporation.Orchard.Api/carrierName/Get';    
    


    //Selectors
    self.linkedInDivId = '#linkedInProfile';
    self.treeViewSicCodesSelector = '#treeview-sic-code';
    self.treeViewClassCodeSelector = '#treeview-class-code'

    self.companyReportId = "#companyReport";
    self.searchResultsId = "#searchResults";
    self.contactsGridId = "#contactsGrid";
    self.exportDialogId = "#exportDialog";


    //Static datasources

    //self.SicCodes = gSicCodes2;
    //self.ClassCode = gSicCodes2;

    self.Monthes = [
        { id: "", name: "" },
        { id: "01", name: "January" },
        { id: "02", name: "February" },
        { id: "03", name: "March" },
        { id: "04", name: "April" },
        { id: "05", name: "May" },
        { id: "06", name: "June" },
        { id: "07", name: "July" },
        { id: "08", name: "August" },
        { id: "09", name: "September" },
        { id: "10", name: "October" },
        { id: "11", name: "November" },
        { id: "12", name: "December" }
    ];


    self.EmployeeSize = [
            { id: "0", name: "Unknown" },
            { id: "1", name: "0 TO 4" },
            { id: "2", name: "5 TO 9" },
            { id: "3", name: "10 TO 19" },
            { id: "4", name: "20 TO 49" },
            { id: "5", name: "50 TO 99" },
            { id: "6", name: "100 TO 499" },
            { id: "7", name: "500 PLUS" }
        ];



};


