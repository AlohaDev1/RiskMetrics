MetricsCorporationApp.UsersModel = function () {
    var self = this;
    self.viewName = "UsersView";


    self.navigation = null;
    self.dataSources = new MetricsCorporationApp.DataSources();
    self.koBindings = new MetricsCorporationApp.KoBindings();

    self.users = ko.observableArray();

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

                        self.openDetailsView(dataItem, "view");
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

                        self.openDetailsView(dataItem, "edit");
                    }
                },
                title: " "
            },
            { field: "FullName", title: "Name" },
            { field: "UserName", title: "User Name" },
            { field: "NumberOfLogins", title: "Number Of Logins" },
            { field: "LastLoginDate", title: "Last Login Date" },
            { field: "TotalReportsViewed", title: "Total Reports Viewed" }
        ],
        editable: false
    };

    self.loadGridData = function () {
        $.ajax({
            url: self.dataSources.masterIdUri,
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

    self.init = function (nav) {
        self.loadGridData();
        self.navigation = nav;
    };
};