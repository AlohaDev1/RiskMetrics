
﻿MetricsCorporationApp.AccountModel = function () {
    var self = this;
    self.viewName = "AccountModelView";


    self.navigation = null;
    self.dataSources = new MetricsCorporationApp.DataSources();
    self.koBindings = new MetricsCorporationApp.KoBindings();

    
    self.exported = ko.observableArray();
    self.currentNumberOfLogins = ko.observableArray();
    self.currentTotalReportsViewed = ko.observableArray();
    self.users = ko.observableArray();
﻿    self.subscribtion = ko.observable();
﻿    self.currentViewUserName = ko.observable("");
﻿    self.DisplayAdmin = ko.observable(false);
﻿    
    self.init = function (nav) {
        self.navigation = nav;
    };

﻿    self.viewLogins = function() {
﻿        alert("test");
﻿    };

    self.loadExportedData = function () {
        $.ajax({
            url: self.dataSources.exportedUri,
            dataType: 'json',
            success: function (response) {

                var array = [];
                for (var i = 0; i < response.length; i++) {
                    array.push(new MetricsCorporationApp.ExportedModel(response[i]));
                }
                self.exported(array);
            }
        });
    };

﻿    self.loadAll = function() {
        $(document).delegate('#accountTabs a', "click", function(e) {
    ﻿        e.preventDefault();
    ﻿        $(this).tab('show');
    ﻿    });

﻿        self.loadExportedData();
﻿        self.loadSubcribtionDetails();

﻿    };

﻿    self.loadSubcribtionDetails = function() {
        $.ajax({
            url: self.dataSources.subcribtionDetails,
            dataType: 'json',
            beforeSend: function () {
                $.blockUI({ message: '<h2 style="color:#fff;"></h2><div class="loading-icon"></div>', css: { border: "none", backgroundColor: 'transparent'} });
            },
            success: function (response) {
                if (response != null) {
                    response = JSON.parse(response);
                    
                    self.subscribtion(new MetricsCorporationApp.Subscription(response)); 
                    if (response.Admin) {
                        self.DisplayAdmin(true);
                ﻿        self.loadAllUsers();
                    }
                        
                }
                $.unblockUI();
            }
        });
﻿    };
﻿    
    self.loadAllUsers = function() {
        $.ajax({
            url: self.dataSources.allUsers,
            dataType: 'json',
            success: function (response) {
                if (response != null) {
                    response = JSON.parse(response);
                    
                    var array = [];
                    for (var i = 0; i < response.length; i++) {
                        array.push(new MetricsCorporationApp.UserModel(response[i]));
                    }
                    self.users(array);
                    self.loadUsersChart();
                }

            }
        });
﻿    };

﻿    self.loadUsersChart = function() {

﻿        var categories = [];
﻿        var data = [];
﻿        var reportsSum = 0;
﻿        
﻿        for (var i = 0; i < self.users().length; i++) {
﻿            var user = self.users()[i];
﻿            var userName = user.Name() +  " (" + user.UserName() + ")";
﻿            categories.push(userName);
﻿            data.push(user.TotalReportsViewed());
﻿            reportsSum = reportsSum + user.TotalReportsViewed();
﻿        }
﻿        var chartTitle = "Reports Viewed By All Users Of " + self.users()[0].CompanyName();

//﻿        
﻿        setTimeout(function() {
                $("#allUserChartGoogle").kendoChart({
                        theme: "default",
                        title: {
                            text:  chartTitle
                        },
                        legend: {
                            position: "bottom"
                        },
                        chartArea: {
                            background: ""
                        },
                        seriesDefaults: {
                            type: "bar"
                        },
                        series: [{
                            name: "Total = " + reportsSum,
                            data: data
                        }],
                        valueAxis: {
                            majorUnit: 1
                        },
                        categoryAxis: {
                            categories: categories
                        },
                        tooltip: {
                            visible: true,
                            format: "{0} Views"
                        }
                    });
﻿        }, 200);
            
﻿    };



﻿    self.viewLogins = function(item) {
﻿        alert("ewrw");
﻿    };
﻿    
﻿    self.viewReports = function(item) {

﻿    };
﻿    
};
﻿
function drawChart() {
     
     var mappedData = [['UserName', 'TotalReportsViewed']];
        ko.utils.arrayMap(vm.accountModel.users(), function (item) {
            //return mappedData.push([()];
            var userName = item.Name() +  " (" + item.UserName() + ")";
            return mappedData.push([userName, item.TotalReportsViewed()]);
    });
    var data = google.visualization.arrayToDataTable(mappedData);

    var options = {
        title: 'Reports Viewed By All Users Of Risk Metrics',
        width: 800
        
        //vAxis: {title: 'Year'}
    };

    var chart = new google.visualization.BarChart(document.getElementById('allUserChartGoogle'));
    chart.draw(data, options);
}

﻿MetricsCorporationApp.ExportedModel = function(item) {
﻿    var self = this;

﻿    self.Id = ko.observable(item != null ? item.Id : "");
﻿    self.ExportedOn = ko.observable(item != null ? formatDate(item.ExportedOn) : "");
﻿    self.RecordsExportedCount = ko.observable(item != null ? item.RecordsExportedCount : "");
﻿    self.FileName = ko.observable(item != null ? item.FileName : "");
﻿    self.ExportType =  ko.computed(function () {
        return self.RecordsExportedCount() > 1 ? "List" : "Report";
    }, self);
﻿    
﻿    self.CsvFileName =  ko.computed(function () {
        return self.FileName() + ".csv";
    }, self);
﻿    
﻿    self.XmlFileName = ko.computed(function () {
        return self.RecordsExportedCount() == 1 ? (self.FileName() + ".xml" ) : "";
    }, self);
﻿    
    self.CsvFileUrl =  ko.computed(function () {
        return "/MetricsCorporation.Orchard.Web/Account/DownloadReport" + "?reportId=" + self.Id() + "&type=csv";
    }, self);
﻿    
﻿    self.XmlFileUrl = ko.computed(function () {
        return "/MetricsCorporation.Orchard.Web/Account/DownloadReport" + "?reportId=" + self.Id() + "&type=xml";
    }, self);
﻿    

﻿    
﻿};
﻿
﻿MetricsCorporationApp.Subscription = function(item) {
﻿    var self = this;

﻿    
//    self.Id = ko.observable(item != null ? item.Id : "");
﻿    self.UserName = ko.observable(item != null ? item.UserName : "");
﻿    self.Name = ko.observable(item != null ? item.FirstName : "");
﻿    self.CompanyName = ko.observable(item != null ? item.CompanyName : "");
﻿    self.ExpirationDate = ko.observable(item != null ? formatDate(item.ExpirationDate) : "");
﻿    self.MaxReportViewsPerMonth = ko.observable(item != null ? item.MaxReportViewsPerMonth : "");
﻿    self.ReportsViewed = ko.observable(item != null ? item.ReportsViewed : "");
﻿    self.CanexportList = ko.observable(item != null ? item.CanexportList : "");
﻿    self.MaxExports = ko.observable(item != null ? item.MaxExports : "");
﻿    self.RecordsExported = ko.observable(item != null ? item.RecordsExported : "");
﻿    self.States = ko.observable(item != null ? item.States : "");
    self.LinkedInId = ko.observable(item != null ? item.LinkedInId : "");

﻿    self.ReportsViewLeft =  ko.computed(function () {
        return self.MaxReportViewsPerMonth() - self.ReportsViewed();
    }, self);
﻿    
    self.ReportsExportedLeft =  ko.computed(function () {
        return self.MaxExports() - self.RecordsExported();
    }, self);

    self.DisplayLinkedInLink = ko.computed(function () {
        if (self.LinkedInId() == null || self.LinkedInId() == "") {
            return true;
        } else {
            return false;
        }
    }, self);
﻿};


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
    self.CreatedAt = ko.observable(data != null ? data.CreatedAt : "");

    self.reportDateFormatted = ko.computed(function () {
        //return "11/11/2011 10:33:33 AM";
        return formatDate(self.CreatedAt());
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

MetricsCorporationApp.UserModel = function (item, isEditMode, isCopyMode) {
    var self = this;

    self.Id = ko.observable(item != null ? item.Id : "");
    
    self.UserName = ko.observable(item != null ? item.UserName : "");
  
    self.Password = ko.observable(item != null ? item.Password : "");
    self.CompanyName = ko.observable(item != null ? item.CompanyName : "");
    self.FirstName = ko.observable(item != null ? item.FirstName : "");
    self.LastName = ko.observable(item != null ? item.LastName : "");
    self.Headline = ko.observable(item != null ? item.Headline : "");
    self.ProfileRequest = ko.observable(item != null ? item.ProfileRequest : "");
    self.LinkedInId = ko.observable(item != null ? item.LinkedInId : "");
    self.Admin = ko.observable(item != null ? item.Admin : false);
    
    self.DisplayLinkedInLink =  ko.computed(function () {
       if (self.LinkedInId() == null || self.LinkedInId() == "") {
           return true;
       }else {
           return false;
       }
    }, self);

    self.LastLoginDate = ko.observable(item != null ? item.LastLoginDate : "");
    self.LastLoginFormatted = ko.computed(function () {
        var lData = formatDate(self.LastLoginDate());
        return (lData == null || lData == "") ? "Never" : lData;
    }, self);
    
    self.Name =  ko.computed(function () {
        return self.LastName()+ " " + self.FirstName();
    }, self);
    
    self.LoginCount = ko.observable(item != null ? item.LoginCount : 0);
    self.TotalReportsViewed = ko.observable(item != null ? item.TotalReportsViewed : 0);
    self.TotalReportsExported = ko.observable(item != null ? item.TotalReportsExported : 0);
    
    self.ExpirationDate = ko.observable(item != null ? formatDate(item.ExpirationDate) : "");
    self.SubscriptionStatus = ko.computed(function () {
        return (self.ExpirationDate() == null || self.ExpirationDate() == "") ? "Expaired" : "Active";
    }, self);
    
    self.FullName = ko.computed(function () {
        return self.FirstName() + " " + self.LastName();
    }, self);


    self.isEditMode = ko.observable(isEditMode != null ? isEditMode : false);
    self.isCopyMode = ko.observable(isCopyMode != null ? isCopyMode : false);

    self.updateWithData = function (data) {

        self.Id(data.Id);
        self.UserName(data.UserName);
        self.Password(data.Password);
        self.CompanyName(data.CompanyName);
        self.FirstName(data.FirstName);
        self.LastName(data.LastName);
        self.Headline(data.Headline);
        self.ProfileRequest(data.ProfileRequest);
        self.LastLogin(data.LastLogin);
        self.LoginCount(data.LoginCount);
        self.TotalReportsViewed(data.TotalReportsViewed);
    };


    self.viewLogins = function(data) {

﻿        vm.accountModel.currentViewUserName(data.Name());
        
           $.ajax({
            url: "/api/MetricsCorporation.Orchard.Api/numberOfLogins" + "?userId=" + data.Id(),
            dataType: 'json',
            success: function (response) {

                var array = [];
                for (var i = 0; i < response.length; i++) {
                    array.push(new MetricsCorporationApp.NumberOfLoginsItemModel(response[i]));
                }
                vm.accountModel.currentNumberOfLogins(array);

            ﻿    $("#loginCountDialog").modal('toggle');
                
            }
        });
﻿    };
﻿    
﻿    self.viewReports = function(data) {

﻿        vm.accountModel.currentViewUserName(data.Name());
       ﻿        
        $.ajax({
            //url: "/api/MetricsCorporation.Orchard.Api/searchLogs" + "?userId=" + data.Id(),
            url: "/api/MetricsCorporation.Orchard.Api/UsageInfo" + "?userName=" + data.UserName(),
            dataType: 'json',
            success: function (response) {

                var array = [];
                for (var i = 0; i < response.length; i++) {
                    array.push(new MetricsCorporationApp.ReportLogItemModel(response[i]));
                }
                vm.accountModel.currentTotalReportsViewed(array);

                var total = response.length;
                var start = 1;
//                var callback = function(evt) {
//                    //alert("twet");
//                    var gt = (evt - 1) * 10;
//                    var lt = (evt)
//                    $("#reportsViewsDialog table tr:gt(2):lt(2)");
//                };
                var options = {
                    pageRows: 10,
                    onChange: callback,
                    next: 'Next',
                    prev: 'Prev',
                    length: 10,
                    initLoad: false
                };
                
                $('#paginationReports').pagination(options);
                $('#paginationReports').pagination('show', total, start);

                ﻿$("#reportsViewsDialog").modal('toggle');
                
            }
        });
﻿    };
};


function formatDate(inputString, format) {

    if (format == null)
        format = "MM/dd/yyyy";
    
    var date = Date.parse(inputString);
    
    if (date != null)
        return date.toString(format);

    return null;

}