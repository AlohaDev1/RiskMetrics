MetricsCorporationApp.SearchViewModel = function () {
    var self = this;
    self.navigation = null;

    self.init = function (nav) {
        self.navigation = nav;
        self.loadCombos();
    };

    self.Sources = new MetricsCorporationApp.DataSources();

    self.companyInput = ko.observable().extend({ required: true });
    self.cityInput = ko.observable("");
    self.stateInput = ko.observable("");
    self.zipInput = ko.observable("");
    self.countyNameInput = ko.observable("");
    self.phoneNumberInput = ko.observable(true);
    self.sicCodeInput = [];
    self.renewalMonthInput = ko.observable("");
    self.employeeSizeInput = ko.observable("");
    self.searchNameInput = ko.observable("");

    self.maxSplitterSize = ko.observable("100px");


    self.companies = ko.observableArray();
    self.combs = ko.observableArray();
    self.counties = ko.observableArray();
    self.employeesize = ko.observableArray();
    self.siccode = ko.observableArray();
    self.topsearches = ko.observableArray();
    self.renewals = ko.observableArray(self.Sources.Monthes);


    self.inlineDefault = new kendo.data.HierarchicalDataSource({
        data: self.Sources.SicCodes
    });


    self.goTosearch = function () {
        self.companyInput(this.Description);
        self.cityInput(this.City);
        self.stateInput(this.State);
        self.zipInput(this.Zip);
        self.countyNameInput(this.CountyName);
        self.phoneNumberInput(this.PhoneEmp);
        self.renewalMonthInput(this.EffectiveMonth);
        self.searchNameInput(this.SearchName);
    };


    self.do_search = function (obj) {

        if (self.errors().length != 0) {
            self.errors.showAllMessages();
            return false;
        }

        var slider = $("#slider").kendoRangeSlider().data("kendoRangeSlider");

        var dataToSend = {
            CompanyName: self.companyInput(),
            City: self.cityInput(),
            State: self.stateInput(),
            Zip: self.zipInput(),
            CountyName: JSON.stringify(ko.toJS(self.countyNameInput), null, 0),
            PhoneNumber: self.phoneNumberInput(),
            SicCode: self.sicCodeInput.toString(),
            RenewalMonth: self.renewalMonthInput(),
            EmployeeSize: slider.values().toString(),
            SearchName: self.searchNameInput()
        };

        $.ajax({
            url: self.Sources.baseUri + "/Get",
            type: "POST",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            data: JSON.stringify(dataToSend),
            success: function (companies) {
                var modelDataGridView = new MetricsCorporationApp.DataGridViewModel(companies, self);
                modelDataGridView.companies(companies);
                modelDataGridView.nav = self.navigation;
                self.navigation.navigateTo(modelDataGridView);

                if (self.searchNameInput() != '') {
                    self.gettopSearches();
                }

                self.clearSearches();
            }
        });


    };

    self.do_reset = function () {

    };

    //Getting users latest searches
    self.gettopSearches = function () {
        $.ajax({
            url: self.Sources.topSearchesUri,
            dataType: 'json',
            success: function (topsearches) {
                self.topsearches(topsearches);
            }
        });
    };


    //Loading data to the controls
    self.loadCombos = function () {
        self.loadCounties();
    };

    self.loadCounties = function () {
        self.doAjaxCall(self.Sources.countyUri, self.counties, self.loadEmployeeList);
    };

    self.loadEmployeeList = function () {
        self.doAjaxCall(self.Sources.employeeSizeUri, self.employeesize, self.loadCombis);
    };

    self.loadCombis = function () {
        self.doAjaxCall(self.Sources.combUri, self.combs, self.loadControls);
    };

    self.loadControls = function () {
        self.LoadSicCodeTreeView();
        self.gettopSearches();
        self.loadSlider();
    };


    self.doAjaxCall = function (url, obj, callBack) {
        $.ajax({
            url: url,
            dataType: 'json',
            success: function (data) {
                obj(data);
                callBack();
            }
        });
    };


    self.clearSearches = function () {
        self.companyInput('');
        self.cityInput('');
        self.stateInput('');
        self.zipInput('');
        self.countyNameInput('');
        self.renewalMonthInput('');
        self.employeeSizeInput('');
        self.searchNameInput('');
    };

    self.LoadSicCodeTreeView = function () {

        $(self.Sources.treeViewSicCodesSelector).kendoTreeView({
            select: self.SicCodeOnSelect,
            dataSource: self.inlineDefault,
            checkboxes: { checkChildren: true }
        });

        var treeview = $(self.Sources.treeViewSicCodesSelector).data("kendoTreeView");

        treeview.dataSource.bind("change", function (e) {
            if (e.field == "checked") {
                var item = e.items[0];

                if (item.checked) {
                    self.sicCodeInput.push(item.id);
                } else {
                    var index = self.sicCodeInput.indexOf(item.id);
                    self.sicCodeInput.splice(index);
                }
            }
        });
    };

    self.loadSlider = function () {
        var slider = $("#slider").kendoRangeSlider({
            increaseButtonTitle: "Right",
            decreaseButtonTitle: "Left",
            showButtons: true,
            min: 0,
            max: 6,
            largeStep: 1,
            tooltip: {
                enabled: false
            }
        });

        var sliderItems = slider.siblings(".k-slider-items");

        $.each(self.employeesize(), function (index, value) {
            var item = sliderItems.find("li:eq(" + (index) + ")");
            item.attr("title", value.Description);
            item.find("span").text(value.Description);
        });
    };

    self.clearSicCode = function () {
        var treeView = $(self.Sources.treeViewSicCodesSelector).data("kendoTreeView");

        for (var x in self.Sources.sicCodeInput) {
            var id = self.sicCodeInput[x];
            treeView.dataSource.get(id).checked = false;
        }

    };
};