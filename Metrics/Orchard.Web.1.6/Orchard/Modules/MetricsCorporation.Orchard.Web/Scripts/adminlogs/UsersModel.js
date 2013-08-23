MetricsCorporationApp.UsersModel = function () {
    var self = this;
    self.viewName = "UsersView";


    self.navigation = null;
    self.dataSources = new MetricsCorporationApp.DataSources();
    self.koBindings = new MetricsCorporationApp.KoBindings();

    self.users = ko.observableArray();

    self.isNumberOfLoginsViewWindow = ko.observable(false);
    self.isTotalReportsViewWindow = ko.observable(false);
    self.currentUser = ko.observable();
    self.currentNumberOfLogins = ko.observableArray();
    self.currentTotalReportsViewed = ko.observableArray();

    // Master Id Grid Options for the columns and another stuff
    self.gridOptions = {
        pageable: true,
        pageSize: 5,
        height: 500,
        sortable: true,
        columns: [
            {
                command: {
                    text: "View Number Of Reports",
                    click: function (e) {
                        e.preventDefault();

                        var dataItem = this.dataItem($(e.currentTarget).closest("tr"));

                        self.openTotalReportsViewWindow(dataItem, "view");
                    }
                },
                title: " "
            },
            {
                command: {
                    text: "View Number Of Logins",
                    click: function (e) {
                        e.preventDefault();

                        var dataItem = this.dataItem($(e.currentTarget).closest("tr"));

                        self.openNumberOfLoginsViewWindow(dataItem, "view");
                    }
                },
                title: " "
            },
            { field: "FullName", title: "Name" },
            { field: "UserName", title: "User Name" },
            { field: "LoginCount", title: "Number Of Logins" },
            { field: "LastLoginFormatted", title: "Last Login Date" },
            { field: "TotalReportsViewed", title: "Total Reports Viewed" }
        ],
        editable: false
    };

    self.loadGridData = function () {
        $.ajax({
            url: self.dataSources.numberOfLoginsUri,
            dataType: 'json',
            success: function (response) {

                var array = [];
                for (var i = 0; i < response.length; i++) {
                    array.push(new MetricsCorporationApp.MasterIdItemModel(response[i]));
                }
                self.users(array);
            }
        });
    };

    self.openNumberOfLoginsViewWindow = function (data, type) {

       

        $.ajax({
            url: self.dataSources.numberOfLoginsUri + "?userId=" + data.Id,
            dataType: 'json',
            success: function (response) {

                var array = [];
                for (var i = 0; i < response.length; i++) {
                    array.push(new MetricsCorporationApp.NumberOfLoginsItemModel(response[i]));
                }
                self.currentNumberOfLogins(array);

                $("#NumberOfLoginsViewWindow").data("kendoWindow").center();
                self.isNumberOfLoginsViewWindow(true);
                self.currentUser(data);
            }
        });

    };

    self.openTotalReportsViewWindow = function (data, type) {

        $.ajax({
            url: self.dataSources.searchLogUri + "?userId=" + data.Id,
            dataType: 'json',
            success: function (response) {

                var array = [];
                for (var i = 0; i < response.length; i++) {
                    array.push(new MetricsCorporationApp.ReportLogItemModel(response[i]));
                }
                self.currentTotalReportsViewed(array);

                $("#TotalReportsViewWindow").data("kendoWindow").center();
                self.isTotalReportsViewWindow(true);
                self.currentUser(data);
            }
        });

    };

    self.init = function (nav) {
        self.loadGridData();
        self.navigation = nav;
    };
};

MetricsCorporationApp.NumberOfLoginsItemModel = function (data) {
    var self = this;

    //self.FullName = ko.observable(data != null ? data.FullName : "");
    self.LoginDate = ko.observable(data != null ? data.LoginDate : "");
    self.LoginDateFormat = ko.computed(function () {
        return formatDate(self.LoginDate());
    }, self);

    self.Count = ko.observable(data != null ? data.Count : 0);

};


MetricsCorporationApp.ReportLogItemModel = function (data) {
    var self = this;

    self.SearchName = ko.observable(data != null ? data.SearchName : "");
    self.Description = ko.observable(data != null ? data.Description : "");
    self.Address = ko.observable(data != null ? data.Address : "");
    self.City = ko.observable(data != null ? data.City : "");
    self.State = ko.observable(data != null ? data.State : "");
    self.Zip = ko.observable(data != null ? data.Zip : "");
    self.SicCode = ko.observable(data != null ? data.SicCode : "");
    self.EffectiveMonth = ko.observable(data != null ? data.SearchName : "");
    self.PhoneEmp = ko.observable(data != null ? data.PhoneEmp : false);
    self.EmpSizeRange = ko.observable(data != null ? data.EmpSizeRange : "");
    self.CountyName = ko.observable(data != null ? data.CountyName : "");
    self.CreateDate = ko.observable(data != null ? data.CreateDate : "");

    self.reportDateFormatted = ko.computed(function () {
        return "11/11/2011 10:33:33 AM";
        //return formatDate(self.CreateDate());
    }, self);

    self.CompanyNameAndAdress = ko.computed(function () {
        var txt = "";
        if (self.CountyName() != null && self.CountyName() != "")
            txt += self.CountyName();

        if (self.Address() != null && self.Address() != "")
            txt += self.Address() + ",";

        if (self.City() != null && self.City() != "")
            txt += self.City() + ",";

        if (self.State() != null && self.State() != "")
            txt += self.State() + ",";

        if (self.Zip() != null && self.Zip() != "")
            txt += self.Zip();

        return txt;
    }, self);

    self.AdditionalInformation = ko.computed(function () {
        var txt = "";
        if (self.SicCode() != null && self.SicCode() != "")
            txt += "SIC Code:" + self.SicCode() + ",";

        if (self.EmpSizeRange() != null && self.EmpSizeRange() != "")
            txt += "Employee Size:" + self.EmpSizeRange() + ",";

        if (self.EffectiveMonth() != null && self.EffectiveMonth() != "")
            txt += "EffectiveMonth:" + self.EffectiveMonth() + ",";

        if (self.SearchName() != null && self.SearchName() != "")
            txt += "SearchName: " + self.SearchName() + ",";

        if (self.Description() != null && self.Description() != "")
            txt += "Description:" + self.Description();

        return txt;
    }, self);

};


function formatDate(inputString, format) {

    if (format == null)
        format = "MM/dd/yyyy";

    var date = Date.parse(inputString);

    if (date != null)
        return date.toString(format);

    return null;

}