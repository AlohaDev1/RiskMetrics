// We will do ko.applyBindings on the ShellModel
MetricsCorporationApp.ShellModel = function () {
    var self = this;

    self.accountModel = new MetricsCorporationApp.AccountModel();

    // Store a reference in MetricsCorporationApp.navigation for easy access from other view models
    self.navigation = MetricsCorporationApp.navigation = new ko.navigation.ShellNavigationModel({
        // The vm to initialize with, either an instance or factory/accessor function
        defaultViewModel: self.accountModel
        //maxStackSize: 20 // Expire items after a certain point to cap memory usage
    });


    // Initializing AdminModel and assigning navigation to it
    self.init = function () {
        self.accountModel.init(self.navigation);
        self.accountModel.loadAll();
    };



};


//TODO: move to common helpers
if (typeof String.isNullOrEmpty == 'undefined') {
    String.isNullOrEmpty = function (str) {
        return str == undefined || str == null || str === "";
    };
}