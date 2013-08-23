// We will do ko.applyBindings on the ShellModel
MetricsCorporationApp.AdminLogsModel = function () {
    var self = this;

    self.numberOfLoginsModel = new MetricsCorporationApp.NumberOfLoginsModel();
    self.totalReportsViewedModel = new MetricsCorporationApp.TotalReportsViewedModel();
    self.usersModel = new MetricsCorporationApp.UsersModel();

    // Store a reference in MetricsCorporationApp.navigation for easy access from other view models
    self.navigation = MetricsCorporationApp.navigation = new ko.navigation.ShellNavigationModel({
        // The vm to initialize with, either an instance or factory/accessor function
        defaultViewModel: self.usersModel
        //maxStackSize: 20 // Expire items after a certain point to cap memory usage
    });


    // Navigating to the File List screen
    self.goToFileListView = function () {
        self.fileListModel.loadGridData();
        self.navigation.navigateTo(self.fileListModel);
    };


    // Navigating to the File List screen
    self.goToMasterIdView = function () {
        self.masterIdModel.loadGridData();
        self.navigation.navigateTo(self.masterIdModel);
    };

    // Initializing AdminModel and assigning navigation to it
    self.init = function () {
        self.numberOfLoginsModel.init(self.navigation);
        self.totalReportsViewedModel.init(self.navigation);
        self.usersModel.init(self.navigation);
    };



};


//TODO: move to common helpers
if (typeof String.isNullOrEmpty == 'undefined') {
    String.isNullOrEmpty = function (str) {
        return str == undefined || str == null || str === "";
    };
}