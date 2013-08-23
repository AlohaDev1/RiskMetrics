MetricsCorporationApp.MasterIdModel = function () {
    var self = this;
    self.viewName = "MasterIdView";


    self.navigation = null;
    self.dataSources = new MetricsCorporationApp.DataSources();
    self.koBindings = new MetricsCorporationApp.KoBindings();

    //for detail view kendo window
    self.isOpenDetailView = ko.observable(false);
    self.selectedItem = ko.observable();
    self.detailsWindowId = "masterIdItemDetail";

    self.masterids = ko.observableArray();

    self.init = function (nav) {
        self.navigation = nav;
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
                self.masterids(array);
            }
        });
    };


    // Master Id Grid Options for the columns and another stuff
    self.gridOptions = {
        pageable: true,
        pageSize: 5,
        height: 500,
        sortable: true,
        columns: [
            { command: { text: "view", click: function (e) {
                e.preventDefault();

                var dataItem = this.dataItem($(e.currentTarget).closest("tr"));

                self.openDetailsView(dataItem, "view");
            }
            }, title: " "
            },
            { command: { text: "edit", click: function (e) {
                e.preventDefault();

                var dataItem = this.dataItem($(e.currentTarget).closest("tr"));

                self.openDetailsView(dataItem, "edit");
            }
            }, title: " "
            },
            { command: { text: "copy", click: function (e) {
                e.preventDefault();

                var dataItem = this.dataItem($(e.currentTarget).closest("tr"));

                self.openDetailsView(dataItem, "copy");
            }
            }, title: " "
            },
            { command: { text: "delete", click: function (e) {
                e.preventDefault();

                var dataItem = this.dataItem($(e.currentTarget).closest("tr"));

                self.selectedItem(new MetricsCorporationApp.MasterIdItemModel(dataItem));
                self.deleteItem(dataItem);
            }
            }, title: " "
            },
                { field: "UserName", title: "User Name" },
                { field: "CompanyName", title: "Company Name" },
                { field: "FirstName", title: "First Name" },
                { field: "LastName", title: "Last Name" },
                { field: "Headline", title: "Headline" },
                { field: "ProfileRequest", title: "Profile Request" }
            ],
        editable: false
    };

    self.openDetailsView = function (item, mode) {

        switch (mode) {
            case "view":
                self.beginViewItem(item);
                break;
            case "edit":
                self.beginEditItem(item);
                break;
            case "copy":
                self.beginCopyItem(item);
                break;

        }

        $("#" + self.detailsWindowId).data("kendoWindow").center();
        self.isOpenDetailView(true);

    };

    self.beginViewItem = function (item) {
        self.selectedItem(new MetricsCorporationApp.MasterIdItemModel(item));
    };

    self.beginAddItem = function () {
        self.selectedItem(new MetricsCorporationApp.MasterIdItemModel());
        self.selectedItem().isEditMode(true);
    };

    self.beginEditItem = function (item) {
        if (self.selectedItem() == null) {
            self.selectedItem(new MetricsCorporationApp.MasterIdItemModel(item, true));
        }

        self.selectedItem().isEditMode(true);
    };

    self.beginCopyItem = function (item) {

        if (self.selectedItem() == null) {
            self.selectedItem(new MetricsCorporationApp.MasterIdItemModel(item, true, true));
        } else {
            self.selectedItem().isEditMode(true);
            self.selectedItem().isCopyMode(true);
        }
    };

    self.deleteItem = function () {
        if (confirm("Are you sure?")) {

            var item = self.selectedItem();
            if (item != null) {
                var id = item.Id();

                $.ajax({
                    url: self.dataSources.masterIdUri + "/" + id,
                    type: "DELETE",
                    dataType: 'json',
                    success: function (response, statusText) {
                        if (statusText == "success") {
                            self.masterids.remove(function (currentMasterItem) {
                                return currentMasterItem.Id() == item.Id();
                            });
                            self.selectedItem(null);
                            self.isOpenDetailView(false);
                        }
                    },
                    error: function (response) {
                        alert(response.statusText);
                    }
                });
            }
        }
    };


    self.saveItem = function () {
        var item = self.selectedItem();
        if (item != null) {
            var data;
            var additionalPath = "";
            var methodType = "POST";

            if (!String.isNullOrEmpty(item.Id()) && !item.isCopyMode()) {
                additionalPath = "/" + item.Id();
                methodType = "PUT";
                data = ko.toJSON(item);
            } else {
                //need clear id because it will be empty string 
                item.Id(0);
                data = ko.toJSON(item);
            }

            $.ajax({
                url: self.dataSources.masterIdUri + additionalPath,
                type: methodType,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                data: data,
                success: function (response, statusText) {
                    if (statusText == "success") {

                        //for edit/update response
                        if (methodType == "PUT") {
                            var currentItem = ko.utils.arrayFirst(self.masterids(), function (currentMasterItem) {
                                if (currentMasterItem.Id() == item.Id()) return currentMasterItem;
                            });
                            var model = ko.toJS(item);
                            if (currentItem != null) {
                                currentItem.updateWithData(model);
                            }

                        } else {
                            if (response != null) {
                                self.selectedItem().Id(response.Id);
                                self.masterids.push(self.selectedItem());
                            } else {
                                alert("Unknow error");
                            }

                        }

                        self.isOpenDetailView(false);
                        self.selectedItem(null);
                    } else {
                        alert("Unknow error");
                    }
                },
                error: function (response) {
                    alert(response.statusText);
                }
            });
        }
    };

    self.backToList = function () {
        self.isOpenDetailView(false);
        self.selectedItem(null);
    };
};