
﻿MetricsCorporationApp.FileListModel = function () {
    var self = this;
    self.viewName = "FileListView";


    self.navigation = null;
    self.dataSources = new MetricsCorporationApp.DataSources();
    self.koBindings = new MetricsCorporationApp.KoBindings();

    //for detail view kendo window
    self.isOpenDetailView = ko.observable(false);
    self.selectedItem = ko.observable();
    self.detailsWindowId = "fileListItemDetail";
    
    self.filelists = ko.observableArray();

    self.init = function (nav) {
        self.navigation = nav;
    };

    self.loadGridData = function () {
        $.ajax({
            url: self.dataSources.fileListUri,
            dataType: 'json',
            success: function (response) {

                var array = [];
                for (var i = 0; i < response.length; i++) {
                    array.push(new MetricsCorporationApp.FileListItemModel(response[i]));
                }
                self.filelists(array);
            }
        });
    };


    // File List Grid Options for the columns and another stuff
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

                self.selectedItem(new MetricsCorporationApp.FileListItemModel(dataItem));
                self.deleteItem(dataItem);

            }
            }, title: " "
            },
                { field: "UserName", title: "User Name" },
                { field: "LastLoginDate", title: "Last Login Date" },
                { field: "States", title: "State" },
                { field: "ActivationDate", title: "Activation Date" },
                { field: "RenewalDate", title: "Renewal Date" },
                { field: "ExpirationDate", title: "Expiration Date" },
                { field: "CompanyName", title: "Company Name" },
                { field: "Name", title: "Name" },
                { field: "Admin", title: "Admin" },
                { field: "CanexportList", title: "Can Export List" },
                { field: "MaxReportViewsPerMonth", title: "Max Report Views Per Month" }
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
        self.selectedItem(new MetricsCorporationApp.FileListItemModel(item));
    };

    self.beginAddItem = function () {
        self.selectedItem(new MetricsCorporationApp.FileListItemModel());
        self.selectedItem().isEditMode(true);
    };

    self.beginEditItem = function (item) {
        if (self.selectedItem() == null) {
            self.selectedItem(new MetricsCorporationApp.FileListItemModel(item, true));
        }

        self.selectedItem().isEditMode(true);
    };

    self.beginCopyItem = function (item) {

        if (self.selectedItem() == null) {
            self.selectedItem(new MetricsCorporationApp.FileListItemModel(item, true, true));
        } else {
            self.selectedItem().isEditMode(true);
            self.selectedItem().isCopyMode(true);
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
                url: self.dataSources.fileListUri + additionalPath,
                type: methodType,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                data: data,
                success: function (response, statusText) {
                    if (statusText == "success") {

                        //for edit/update response
                        if (methodType == "PUT") {
                            var currentItem = ko.utils.arrayFirst(self.filelists(), function (currentFileItem) {
                                if (currentFileItem.Id() == item.Id()) return currentFileItem;
                            });
                            var model = ko.toJS(item);
                            if (currentItem != null) {
                                currentItem.updateWithData(model);
                            }

                        } else {
                            self.selectedItem().Id(response.Id);
                            self.filelists.push(self.selectedItem());
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


    self.deleteItem = function () {


        if (confirm("Are you sure?")) {


            var item = self.selectedItem();
            if (item != null) {
                var id = item.Id();

                $.ajax({
                    url: self.dataSources.fileListUri + "/" + id,
                    type: "DELETE",
                    dataType: 'json',
                    success: function (response, statusText) {
                        if (statusText == "success") {
                            self.filelists.remove(function (currentFileItem) {
                                return currentFileItem.Id() == item.Id();
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

    self.backToList = function () {
        self.isOpenDetailView(false);
        self.selectedItem(null);
    };

};

MetricsCorporationApp.FileListItemModel = function (item, isEditMode, isCopyMode) {
    var self = this;

    //don't set id if we copy item with exist data
    self.Id = ko.observable(item != null ? item.Id : "");

    self.UserName = ko.observable(item != null ? item.UserName : "");
    self.Password = ko.observable(item != null ? item.Password : "");
    self.FilePath = ko.observable(item != null ? item.FilePath : "");
    self.LastLoginDate = ko.observable(item != null ? formatDate(item.LastLoginDate) : "");
    self.States = ko.observable(item != null ? item.States : "");
    self.ActivationDate = ko.observable(item != null ? formatDate(item.ActivationDate) : "");
    self.RenewalDate = ko.observable(item != null ? formatDate(item.RenewalDate) : "");
    self.ExpirationDate = ko.observable(item != null ? formatDate(item.ExpirationDate) : "");
    self.CompanyName = ko.observable(item != null ? item.CompanyName : "");
    self.Admin = ko.observable(item != null ? item.Admin : false);
    self.CanexportList = ko.observable(item != null ? item.CanexportList : false);
    self.MaxReportViewsPerMonth = ko.observable(item != null ? item.MaxReportViewsPerMonth : 0);
    self.Name = ko.observable(item != null ? item.Name : "");

    self.isEditMode = ko.observable(isEditMode != null ? isEditMode : false);

    self.isCopyMode = ko.observable(isCopyMode != null ? isCopyMode : false);


    self.updateWithData = function(data) {
        
        self.Id(data.Id);
        self.UserName(data.UserName);
        self.Password(data.Password);
        self.FilePath(data.FilePath);
        self.LastLoginDate(data.LastLoginDate);
        self.States(data.States);
        self.ActivationDate(data.ActivationDate);
        self.RenewalDate(data.RenewalDate);
        self.ExpirationDate(data.ExpirationDate);
        self.CompanyName(data.CompanyName);
        self.Admin(data.Admin);
        self.CanexportList(data.CanexportList);
        self.MaxReportViewsPerMonth(data.MaxReportViewsPerMonth);
        self.Name(data.Name);
        
    };
};

function formatDate(inputString, format) {

    if (format == null)
        format = "MM/dd/yyyy";
    
    var date = Date.parse(inputString);
    
    if (date != null)
        return date.toString(format);

    return null;

}