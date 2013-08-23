// We will do ko.applyBindings on the ShellModel
MetricsCorporationApp.AdminModel = function () {
    var self = this;

    self.masterIdModel = new MetricsCorporationApp.MasterIdModel();
    self.fileListModel = new MetricsCorporationApp.FileListModel();

    // Store a reference in MetricsCorporationApp.navigation for easy access from other view models
    self.navigation = MetricsCorporationApp.navigation = new ko.navigation.ShellNavigationModel({
        // The vm to initialize with, either an instance or factory/accessor function
        defaultViewModel: self.fileListModel
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
        self.fileListModel.init(self.navigation);
        self.fileListModel.loadGridData();
        self.masterIdModel.init(self.navigation);
    };



};


//TODO: move to common helpers
if (typeof String.isNullOrEmpty == 'undefined') {
    String.isNullOrEmpty = function (str) {
        return str == undefined || str == null || str === "";
    };
}