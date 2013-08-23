// Define application Descriptionspace

var MetricsCorporationApp = window.MetricsCorporationApp = {};

// Define class with static variables like sic codes or monthes
// Also here stord url's  for webapis
MetricsCorporationApp.DataSources = function () {
    var self = this;

    //Url's for weabpis
    self.protocol = window.location.protocol;
    self.host = window.location.host;

    self.fileListUri = '/api/filelist';
    self.masterIdUri = '/api/masterid';
};


