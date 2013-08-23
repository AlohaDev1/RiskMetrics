// Define application Descriptionspace

var MetricsCorporationApp = window.MetricsCorporationApp = {};

// Define class with static variables like sic codes or monthes
// Also here stord url's  for webapis
MetricsCorporationApp.DataSources = function () {
    var self = this;

    //Url's for weabpis
    self.protocol = window.location.protocol;
    self.host = window.location.host;

    self.exportedUri = '/api/MetricsCorporation.Orchard.Api/Exported';
    self.downloadReportUrl = '/MetricsCorporation.Orchard.Web/Account/DownloadReport';
    self.subcribtionDetails = '/MetricsCorporation.Orchard.Web/Account/SubcribtionDetails';
    self.allUsers = '/MetricsCorporation.Orchard.Web/Account/GetAllUsers';
    //self.fileListUri = '/api/MetricsCorporation.Orchard.Api/filelist';
    //self.masterIdUri = '/api/MetricsCorporation.Orchard.Api/masterid';
};


