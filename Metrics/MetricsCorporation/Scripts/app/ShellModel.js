// We will do ko.applyBindings on the ShellModel
MetricsCorporationApp.ShellModel = function () {
    var self = this;
    
    self.searchViewModel = new MetricsCorporationApp.SearchViewModel();
    self.Sources = new MetricsCorporationApp.DataSources();

    // Store a reference in MetricsCorporationApp.navigation for easy access from other view models
    self.navigation = MetricsCorporationApp.navigation = new ko.navigation.ShellNavigationModel({
        // The vm to initialize with, either an instance or factory/accessor function
        defaultViewModel: self.searchViewModel
        //maxStackSize: 5 // Expire items after a certain point to cap memory usage
    });


    // Navigating to the Search screen
    self.GoToSearchView = function () { // View model navigation
        self.navigation.navigateTo(self.searchViewModel);
    };

    // Initializing searchViewModel and assigning navigation to it
    self.init = function () {
        self.searchViewModel.errors = ko.validation.group(self.searchViewModel);
        self.searchViewModel.init(self.navigation);
    };
};