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
﻿};
﻿
﻿MetricsCorporationApp.Subscription = function(item) {
﻿    var self = this;
﻿    
    //self.Id = ko.observable(item != null ? item.Id : "");
﻿    self.UserName = ko.observable(item != null ? item.UserName : "");
﻿    self.Name = ko.observable(item != null ? item.Name : "");
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

MetricsCorporationApp.Role = function(item) {
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