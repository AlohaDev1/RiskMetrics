MetricsCorporationApp.MapViewModel = function () {

    var that = {};
    that.viewName = "MapView";
    that.navigation = null;
    that.init = function () {
        that.EmployeeSize = self.Sources.EmployeeSize;
        $.ajax({
            url: self.Sources.combUri,
            dataType: 'json',
            success: function (data) {
                that.combs(data);
            }
        });
        //        var QsCompanyAutocompletedataSource = new kendo.data.DataSource({
        //            serverFiltering: true,
        //            serverPaging: true,
        //            type: 'odata',
        //            transport: {
        //                read: {
        //                    url: self.Sources.companyAutocompleteUri,
        //                    dataType: "json",
        //                    data: function () {
        //                        return {
        //                            str: $("#QSCompanyAutoComplete").val()
        //                        }
        //                    }
        //                },
        //                parameterMap: function (options, type) {
        //                    var paramMap = kendo.data.transports.odata.parameterMap(options);

        //                    delete paramMap.$inlinecount;
        //                    delete paramMap.$format;

        //                    return paramMap;
        //                }
        //            },
        //            schema: {
        //                data: function (data) {
        //                    return data;
        //                },
        //                total: function (data) {
        //                    return data.length;
        //                }
        //            }
        //        });

        //        $("#QSCompanyAutoComplete").kendoAutoComplete({
        //            dataSource: QsCompanyAutocompletedataSource,
        //            dataTextField: "Description"
        //        });
    };

    self.Sources = new MetricsCorporationApp.DataSources();
    that.Sources = new MetricsCorporationApp.DataSources();
    that.koBindings = new MetricsCorporationApp.KoBindings();

    that.searchResultText = ko.observable("");

    that.showRenewalMonth = ko.observable(true);
    that.showMoreThan1Page = ko.observable(true);
    that.EmployeeSize = ko.observableArray();
    that.combs = ko.observableArray();
    that.counties = ko.observableArray();
    that.renewals = ko.observableArray(self.Sources.Monthes);

    that.TotalCompanies = ko.observable();

    that.companies = ko.observableArray();
    self.dataGridViewInstance = null;
    self.SearchViewModelInstance = null;

    that.QSSicInput = ko.observable("");
    that.QSClassInput = ko.observable("");
    that.QScompanyInput = ko.observable();
    that.QSselectMonths = ko.observableArray();
    that.QSEmployeeSize = ko.observableArray();
    that.QSphoneNumberInput = ko.observable(true);

    //    $(document).ready(function () {
    //        var QsCompanyAutocompletedataSource = new kendo.data.DataSource({
    //            serverFiltering: true,
    //            serverPaging: true,
    //            type: 'odata',
    //            transport: {
    //                read: {
    //                    url: self.Sources.companyAutocompleteUri,
    //                    dataType: "json",
    //                    data: function () {
    //                        return {
    //                            str: $("#QSCompanyAutoComplete").val()
    //                        }
    //                    }
    //                },
    //                parameterMap: function (options, type) {
    //                    var paramMap = kendo.data.transports.odata.parameterMap(options);

    //                    delete paramMap.$inlinecount;
    //                    delete paramMap.$format;

    //                    return paramMap;
    //                }
    //            },
    //            schema: {
    //                data: function (data) {
    //                    return data;
    //                },
    //                total: function (data) {
    //                    return data.length;
    //                }
    //            }
    //        });

    //        $("#QSCompanyAutoComplete").kendoAutoComplete({
    //            dataSource: QsCompanyAutocompletedataSource,
    //            dataTextField: "Description"
    //        });
    //    });


    var gridColumns = [
        { field: "CompanyName", title: "Company Name", width: 50 }
    ];

    that.gridOptions = {

        pageable: true,
        pageSize: 25,
        sortable: false,
        scrollable: false,
        columns: gridColumns,
        editable: false,
        dataBound: function (e) {
            $('#gridCompanies table tr').click(function () {
                var index = $(this).closest("tr")[0].rowIndex - 1;
                if (index > -1) {
                    that.GoToDetailsView(e.sender._data[index]);
                }
            });

            if (!that.showMoreThan1Page()) {
                this.pager.element.hide();
            }

        }
    };

    self.DownloadXml = function () {
        document.location = that.Sources.downloadUrl + this.Id();
    };

    self.DownloadUserXml = function (obj) {
        var str = that.Sources.downloadClientUrl;
        str += '?CompanyId=0';
        str += '&ContactId=0';
        str += '&Title=' + obj.userTitle();
        str += '&CompanyName=' + that.CompanyName();
        str += '&UpdatedDate=11.11.2011';
        str += '&GraveyardStatus=' + obj.graveyardStatus();
        str += '&FirstName=' + obj.firstname();
        str += '&LastName=' + obj.lastname();
        str += '&City=' + obj.city();
        str += '&State=' + obj.state();
        str += '&Country=' + obj.country();
        str += '&Zip=' + obj.zip();
        str += '&ContactUrl=' + 'url';
        str += '&SeoContactUrl=' + 'url';
        str += '&AreaCode=' + obj.areaCode();
        str += '&Phone=' + obj.phone();
        str += '&Email=' + obj.email();
        str += '&Address=' + obj.address();
        str += '&Owned=true';
        str += '&OwnedType=' + 'own';

        document.location = str;
    };


    that.GoToDetailsView = function (e) {

        var companyId = e.Id;
        $.ajax({
            url: that.Sources.companyReport + "?reportId=" + companyId,
            dataType: 'json',
            beforeSend: function () {
                $.blockUI({ message: '<h2 style="color:#fff;"></h2><div class="loading-icon"></div>', css: { border: "none", backgroundColor: 'transparent'} });
            },
            success: function (response) {

                if (response != null && response.ViewReportbit == true) {
                    var modelDataGridView = new MetricsCorporationApp.DetailsSearchViewModel();
                    modelDataGridView.init(that.navigation, response.Company);
                    modelDataGridView.dataGridViewInstance = that;
                    modelDataGridView.SearchViewModelInstance = that.SearchViewModelInstance;
                    // removed mannual logic to display google map instead we are using thsi model information in knockout js to bind
                    modelDataGridView.companymarker = ko.observable({
                        //[TO-DO] need make dynamic calls
                        lat: ko.observable(27.371767),
                        lng: ko.observable(-81.542244)
                    });
                    that.navigation.navigateTo(modelDataGridView);

                } else {
                    $.unblockUI();
                    alert("Your subcribtion max view report limit is full.");
                }
                $.unblockUI();
            },
            error: function () {
                $.unblockUI();
            }
        });
    };

    self.do_Quicksearch = function (obj) {
        var EmployeeSize = [];
        if (that.QSEmployeeSize() != undefined) {
            for (var i = 0; i < that.QSEmployeeSize().length; i++) {
                EmployeeSize.push(that.QSEmployeeSize()[i]);
            }
        }

        var sicCodes = [];
        $("#treeview-sic-code-QuickSearch").jstree("get_checked", null, false).each(function (item) {
            sicCodes.push($(this).data().siccode);
        });

        var classCodes = [];
        $("#treeview-class-code-QuickSearch").jstree("get_checked", null, false).each(function () {
            var classCode = $(this).data().classcode;
            if (classCode != null) {
                if ($.inArray(classCode, classCodes) == -1)
                    classCodes.push(classCode);
            }
        });

        var GeographyCountyCodes = [];
        var GeographyStateCodes = [];
        $("#treeview-Geography-QuickSearch").jstree("get_checked", null, false).each(function (item) {
            if ($(this).attr('code') == undefined) {
                GeographyCountyCodes.push($(this).attr("id"));
            } else {
                GeographyStateCodes.push($(this).attr("id"));
            }
        });

        // var CountyCollection = [];
        var SicCodes = [];
        var ClassCodes = [];
        var carrierNumbers = [];

        var dataToSend = {
            CompanyName: that.QScompanyInput(),
            City: '',
            State: '',
            Zip: '',
            CountyName: GeographyCountyCodes,
            HasPhoneNumber: that.QSphoneNumberInput(),
            SicCodes: SicCodes,
            ClassCodes: ClassCodes,
            RenewalMonths: that.QSselectMonths(),
            EmployeeSize: EmployeeSize,
            SearchName: that.SearchViewModelInstance.searchNameInput(),
            States: GeographyStateCodes,
            CarrierNumbers: carrierNumbers
        };

        $.ajax({
            url: self.Sources.baseUri + "/Get",
            type: "POST",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            data: JSON.stringify(dataToSend),
            beforeSend: function () {
                $.blockUI({ message: '<h2 style="color:#fff;">Please wait...<br/></h2><div class="loading-icon"></div>', css: { border: "none", backgroundColor: 'transparent'} });
            },
            error: function () {
                $.unblockUI();
                alert("Unknow error");
            },
            success: function (response) {
                that.companies(response.Companies);
                that.init();
                that.TotalCompanies(response.Total);
                if (response.Companies.length > 0) {
                    that.searchResultText("Displaying 1 to " + ((response.Total < response.Showed) ? response.Total : response.Showed) + " Of " + response.Total + " Records Matching Your Search Criteria");
                } else {
                    that.searchResultText("No Records Matching Your Search Criteria");
                }
                $.unblockUI();
            }
        });
    };

    self.SwichtoListView = function (obj) {
        that.dataGridViewInstance.mapOne = ko.observable({
            lat: ko.observable(),
            lng: ko.observable()
        });
        that.dataGridViewInstance.QScompanyInput(that.QScompanyInput());
        that.dataGridViewInstance.QSselectMonths(that.QSselectMonths());
        that.dataGridViewInstance.QSEmployeeSize(that.QSEmployeeSize());
        that.dataGridViewInstance.QSphoneNumberInput(that.QSphoneNumberInput());
        that.navigation.navigateTo(that.dataGridViewInstance);
    };

    self.GoToSearchView = function (obj) {
        that.SearchViewModelInstance.do_reset();
        that.navigation.navigateTo(that.SearchViewModelInstance);
    };

    that.exportCompanyReport = function () {
        $(".exportStep1").show();
        $(".exportStep2").hide();
        $("#saveFileName").val("");
        $(that.Sources.exportDialogId).modal('toggle');
    };

    return that;
};