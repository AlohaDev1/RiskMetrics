
﻿MetricsCorporationApp.UsersModel = function () {
    var self = this;
    self.viewName = "UsersModelView";
﻿    self.userEditId = "#userEditDialog";
﻿    
    self.navigation = null;
    self.dataSources = new MetricsCorporationApp.DataSources();
    self.koBindings = new MetricsCorporationApp.KoBindings();

﻿    self.roles = ko.observableArray();

     self.init = function (nav) {
        self.navigation = nav;
     };
﻿    
     self.StatesCollection = ko.observableArray(self.dataSources.StatesCollection);
﻿    
     self.GetStatesNamesById = function (obj) {
         var stateNames = '';
         $.each(obj.split(','), function (key, value) {
             var stateName = $.grep(self.StatesCollection(), function (e) { return e.id == value; });

             if (stateName.length > 0) {
                 if (stateNames != '') {
                     stateNames += ',';
                 }

                 stateNames += stateName[0].name;
             }
         });

         return stateNames;
     };
﻿    


     self.GetStatesIdsByName = function (obj) {
         var stateNames = '';
         $.each(obj.split(','), function (key, value) {
             var stateName = $.grep(self.StatesCollection(), function (e) { return e.name == value; });

             if (stateName.length > 0) {
                 if (stateNames != '') {
                     stateNames += ',';
                 }

                 stateNames += stateName[0].id;
             }
         });

         return stateNames;
    };
﻿    
    

    self.users = ko.observableArray();

﻿    self.currentPage = ko.observable(1);
﻿    self.currentFilter = ko.observable("All Users");
    self.selectedUser = ko.observable();
﻿    
    self.filtredUsers = ko.computed(function () {
        return ko.utils.arrayFilter(self.users(), function (user) {
            //if (user.Roles() != null && user.Roles().length > 0)
                return ko.utils.arrayFirst(user.Roles(), function(r) {
                    return r.Name() == self.currentFilter() || self.currentFilter() == "All Users";
                });
            //else
               // return true;
        });
    }, self);

    
﻿    self.switchTab = function(item, evt) {
             var evt = evt || window.event; 
             var current = $(evt.target || evt.srcElement).text();
             self.currentFilter(current);
             evt.preventDefault();
             $(evt.target || evt.srcElement).tab('show');
//    var text = $(evt.srcElement).text();
//﻿        self.currentFilter(text);
//﻿        
//         evt.preventDefault();
//         $(evt.srcElement).tab('show');
﻿    };

    self.loadGridData = function () {
        $.ajax({
            url: self.dataSources.usersUri,
            dataType: 'json',
             beforeSend: function () {
                $.blockUI({ message: '<h2 style="color:#fff;"></h2><div class="loading-icon"></div>', css: { border: "none", backgroundColor: 'transparent'} });
            },
            success: function (response) {

                var array = [];
                for (var i = 0; i < response.length; i++) {
                    response[i].States = self.GetStatesNamesById(response[i].States);
                    array.push(new MetricsCorporationApp.UserItemModel(response[i]));
                }
                self.users(array);
                
                $.unblockUI();
            }
        });    
        
        $.ajax({
            url: self.dataSources.rolesUri,
            dataType: 'json',
//             beforeSend: function () {
//                $.blockUI({ message: '<h2 style="color:#fff;"></h2><div class="loading-icon"></div>', css: { border: "none", backgroundColor: 'transparent'} });
//            },
            success: function (response) {

                var array = [];
                for (var i = 0; i < response.length; i++) {
                    array.push(new MetricsCorporationApp.Role(response[i]));
                }
                self.roles(array);
                
                //$.unblockUI();
            }
        });
    };
﻿    

    self.saveItem = function () {
        var item = self.selectedUser();
        
        if (item != null) {
            var data;
            var additionalPath = "";
            var methodType = "POST";

            item.Roles(ko.utils.arrayFilter(self.roles(), function(s) {
                if (s.Checked()) return true;
            }));

            item.States(self.GetStatesIdsByName(item.States()));

            if (!String.isNullOrEmpty(item.Id()) && (item.isCopyMode() || item.isEditMode())) {
                additionalPath = "/" + item.Id();
                methodType = "PUT";
                data = ko.toJSON(item);
            } else {
                //need clear id because it will be empty string 
                item.Id(0);
                data = ko.toJSON(item);
            }

            item.States(self.GetStatesNamesById(item.States()));


            $.ajax({
                url: self.dataSources.usersUri + additionalPath,
                type: methodType,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                data: data,
                success: function (response, statusText) {
                    if (statusText == "success") {

                        //for edit/update response
                        if (methodType == "PUT") {
                            var currentItem = ko.utils.arrayFirst(self.users(), function (currentUserItem) {
                                if (currentUserItem.Id() == item.Id()) return currentUserItem;
                            });
                            var model = ko.toJS(item);
                            if (currentItem != null) {
                                currentItem.updateWithData(model);
                            }

                        } else {
                            self.selectedUser().Id(response.Id);
                            self.users.push(self.selectedUser());
                        }

                        $(self.userEditId).modal('hide');
                        self.selectedUser(null);
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
﻿    
    self.deleteItem = function () {


        if (confirm("Are you sure?")) {


            var item = self.selectedUser();
            if (item != null) {
                var id = item.Id();

                $.ajax({
                    url: self.dataSources.usersUri + "/" + id,
                    type: "DELETE",
                    dataType: 'json',
                    success: function (response, statusText) {
                        if (statusText == "success") {
                            self.users.remove(function (currentUserItem) {
                                return currentUserItem.Id() == item.Id();
                            });
                            self.selectedUser(null);
                            $(self.userEditId).modal('hide');
                        }
                    },
                    error: function (response) {
                        alert(response.statusText);
                    }
                });
            }
        }
    };

    self.openDetails = function (item) {
        item.isEditMode(false);
        item.isCopyMode(false);
        self.selectedUser(item);

      self.setUserRoles();

        $(self.userEditId).modal('show');
    };
﻿    
    self.backToList = function () {
        $(self.userEditId).modal('hide');
        self.selectedUser(null);
    };
﻿   
    self.beginAddItem = function () {
        self.selectedUser(new MetricsCorporationApp.UserItemModel());
        self.selectedUser().isEditMode(true);
        self.selectedUser().isCopyMode(true);
        self.setUserRoles();

        $(self.userEditId).modal('show');
    };

    self.beginEditItem = function (item) {
        self.selectedUser().isEditMode(true);
    };

    self.beginCopyItem = function (item) {
        self.selectedUser(item);
        self.selectedUser().isEditMode(true);
        self.selectedUser().isCopyMode(true);
        self.setUserRoles();
        $(self.userEditId).modal('show');
    };

﻿    self.setUserRoles = function(user) {
        var roles = self.roles();
        for (var i = 0; i < roles.length; i++) {
            var gRole = roles[i];
            gRole.Checked(false);
            var uRole = ko.utils.arrayFirst(self.selectedUser().Roles(), function(s) {
                if (s.Id() == gRole.Id()) return true;
            });
            if (uRole != null) {
                gRole.Checked(true);
            }
        }     
﻿    };
    
};
﻿

﻿MetricsCorporationApp.Role = function(item) {
﻿    var self = this;
﻿    
﻿    self.Id = ko.observable(item != null ? item.Id : "");
﻿    self.Name = ko.observable(item != null ? item.Name : "");
﻿    self.Checked = ko.observable(false);
﻿};
﻿
MetricsCorporationApp.UserItemModel = function (item, isEditMode, isCopyMode) {
    var self = this;

    //don't set id if we copy item with exist data
    self.Id = ko.observable(item != null ? item.Id : "");
    
    //self.dataSources = new MetricsCorporationApp.DataSources();
    //self.StatesCollection = ko.observableArray(self.dataSources.StatesCollection);

    self.UserName = ko.observable(item != null ? item.UserName : "");
    self.Email = ko.observable(item != null ? item.Email : "");
    self.Password = ko.observable(item != null ? item.Password : "");
    self.FilePath = ko.observable(item != null ? item.FilePath : "");
    self.LastLoginDate = ko.observable(item != null ? formatDate(item.LastLoginDate) : "");
    self.States = ko.observable(item != null ? item.States : "");
    self.ActivationDate = ko.observable(item != null ? formatDate(item.ActivationDate) : "");
    self.RenewalDate = ko.observable(item != null ? formatDate(item.RenewalDate) : "");
    self.ExpirationDate = ko.observable(item != null ? formatDate(item.ExpirationDate) : "");
    self.CompanyName = ko.observable(item != null ? item.CompanyName : "");
    self.ShowCarrier = ko.observable(item != null ? item.ShowCarrier : false);
    self.ShowStatusFld = ko.observable(item != null ? item.ShowStatusFld : false);
    self.TestAccount = ko.observable(item != null ? item.TestAccount : false);
    
    self.Admin = ko.observable(item != null ? item.Admin : false);
    self.CanexportList = ko.observable(item != null ? item.CanexportList : false);
    
    self.MaxReportViewsPerMonth = ko.observable(item != null ? item.MaxReportViewsPerMonth : 0);
    self.MaxReportViewsPerYear = ko.observable(item != null ? item.MaxReportViewsPerYear : 0);

    self.ReportsViewByMonth = ko.observable(item != null ? item.ReportsViewByMonth.toString() : "false");
    self.ReportsJigwasByMonth = ko.observable(item != null ? item.ReportsJigwasByMonth.toString() : "false");
   
    
    self.MaxExports = ko.observable(item != null ? item.MaxExports : 0);
    
    self.FirstName = ko.observable(item != null ? item.FirstName : "");
    self.LastName = ko.observable(item != null ? item.LastName : "");
    
    self.MaxJigsawReportsViewsPerMonth = ko.observable(item != null ? item.MaxJigsawReportsViewsPerMonth : 0);
    self.MaxJigsawReportsViewsPerYear = ko.observable(item != null ? item.MaxJigsawReportsViewsPerYear : 0);

    self.MaxJigsawExports = ko.observable(item != null ? item.MaxJigsawExports : 0);
    
    self.LoginCount = ko.observable(item != null ? item.LoginCount : 0);
    self.TotalReportsViewed = ko.observable(item != null ? item.TotalReportsViewed : 0);
    self.TotalReportsExported = ko.observable(item != null ? item.TotalReportsExported : 0);
    
    self.Roles = ko.observableArray();
    
    self.isEditMode = ko.observable(isEditMode != null ? isEditMode : false);

    self.isCopyMode = ko.observable(isCopyMode != null ? isCopyMode : false);


    var array = [];
    if (item != null && item.Roles != null) {
        for (var i = 0; i < item.Roles.length; i++) {
            array.push(new MetricsCorporationApp.Role(item.Roles[i]));
        }    
    }
    
    self.Roles(array);

    self.updateWithData = function(data) {
        
        self.Id(data.Id);
        self.UserName(data.UserName);
        self.Email(data.Email);
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
        self.MaxExports(data.MaxExports);
        self.FirstName(data.FirstName);
        self.LastName(data.LastName);
        
        self.ReportsViewByMonth(data.ReportsViewByMonth);
        self.ReportsJigwasByMonth(data.ReportsJigwasByMonth);

        self.MaxReportViewsPerYear(data.MaxReportViewsPerYear);
        self.MaxJigsawReportsViewsPerYear(data.MaxJigsawReportsViewsPerYear);

    };

    self.addRole = function(role, elem) {
        var $checkBox = $(elem.srcElement);
        var isChecked = $checkBox.is(':checked');
        //If it is checked and not in the array, add it
        if (isChecked && viewModel.selectedPeople.indexOf(role) < 0) {
            viewModel.selectedPeople.push(role);
        }
            //If it is in the array and not checked remove it                
        else if (!isChecked && viewModel.selectedPeople.indexOf(role) >= 0) {
            viewModel.selectedPeople.remove(role);
        }
        //Need to return to to allow the Checkbox to process checked/unchecked
        return true;
    };

    //self.ReportsViewByMonth = ko.observable(item != null ? item.ReportsViewByMonth : false);
    //self.ReportsJigwasByMonth = ko.observable(item != null ? item.ReportsJigwasByMonth : false);
    self.activeReportsModeDisplay = ko.computed(function () {
        return self.ReportsViewByMonth() == "true" ? "By month" : "By year";
    }, self);

    self.activeReportsJiqwasModeDisplay = ko.computed(function () {
        return self.ReportsJigwasByMonth() == "true" ? "By month" : "By year";
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

