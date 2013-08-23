MetricsCorporationApp.TotalReportsViewedModel = function () {
    var self = this;
    self.viewName = "TotalReportsViewedView";


    self.navigation = null;
    self.dataSources = new MetricsCorporationApp.DataSources();
    self.koBindings = new MetricsCorporationApp.KoBindings();

    self.init = function (nav) {
        self.navigation = nav;
    };
}