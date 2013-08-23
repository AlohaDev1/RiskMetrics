// Define application Descriptionspace

var MetricsCorporationApp = window.MetricsCorporationApp = {};

// Define class with static variables like sic codes or monthes
// Also here stord url's  for webapis
MetricsCorporationApp.DataSources = function () {
    var self = this;

    //Url's for weabpis
    self.protocol = window.location.protocol;
    self.host = window.location.host;

    self.fileListUri = '/api/MetricsCorporation.Orchard.Api/filelist';
    self.masterIdUri = '/api/MetricsCorporation.Orchard.Api/masterid';
    self.numberOfLoginsUri = '/api/MetricsCorporation.Orchard.Api/numberOfLogins';
    self.searchLogUri = '/api/MetricsCorporation.Orchard.Api/searchLogs';
};


