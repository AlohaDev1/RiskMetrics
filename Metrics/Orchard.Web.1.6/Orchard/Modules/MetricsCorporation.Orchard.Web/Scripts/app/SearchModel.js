MetricsCorporationApp.SearchViewModel = function () {
    var self = this;
    self.navigation = null;
    self.viewName = "SearchView";

    self.init = function (nav) {

        self.navigation = nav;
                
        self.doAjaxCallAsync(self.Sources.carrierName, function (resultdata) {
            if (resultdata == "False")
                self.showCarrierTree(false);
            else {
                self.showCarrierTree(true);
                resultdata = eval('(' + resultdata + ')');
                self.carrierNameTree = resultdata;
            }
        });

        self.doAjaxCall1(self.Sources.sicCode, function (data) {
            data = eval('(' + data + ')');
            self.treeDataSicCodes = data;
        });

        self.doAjaxCall1(self.Sources.classCode, function (data) {
            data = eval('(' + data + ')');
            self.treeDataClassCodes = data;
        });

        self.doAjaxCall1(self.Sources.geography, function (data) {
            data = eval('(' + data + ')');
            self.GeographyCode = data;
        });

        self.loadCombos();
    };

    self.Sources = new MetricsCorporationApp.DataSources();
    // Aloha 
    //    self.gClassCodes = new MetricsCorporationApp.gClassCodes();
    //    self.gSicCodes2 = new MetricsCorporationApp.gSicCodes2();

    //.extend({ required: true });
    //not need require for company name
    self.companyInput = ko.observable();
    self.cityInput = ko.observable("");
    self.zipInput = ko.observable("");
    self.countyNameInput = ko.observable("");
    self.phoneNumberInput = ko.observable(true);
    self.sicCodeInput = [];

    self.renewalMonthInput = ko.observable("");
    self.selectMonths = ko.observableArray();

    self.searchNameInput = ko.observable("");
    self.showCarrierTree = ko.observable(false);

    self.employeeSizeInput = ko.observableArray([0, 7]);

    self.maxSplitterSize = ko.observable("100px");

    self.showRenewalMonth = ko.observable(true);
    self.showRenewalMonth.subscribe(function (newValue) {
        if (newValue === true) {
            $("#renewals").select2("enable");
        } else {
            $("#renewals").select2("disable");
        }
    });

    $(document).ready(function () {
        //added for Carrier Name Srarch
        //        var dataSource = new kendo.data.DataSource({
        //            serverFiltering: true,
        //            serverPaging: true,
        //            type: 'odata',
        //            transport: {
        //                read: {
        //                    url: self.Sources.carrierNameAutocompleteUri,
        //                    dataType: "json"
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

        //        $("#CarrierName").kendoAutoComplete({
        //            dataSource: dataSource,
        //            dataTextField: "Description"
        //        }).removeClass('k-input').removeAttr('style').parent().removeClass();

        //        var CompanyAutocompletedataSource = new kendo.data.DataSource({
        //            serverFiltering: true,
        //            serverPaging: true,
        //            type: 'odata',
        //            transport: {
        //                read: {
        //                    url: self.Sources.companyAutocompleteUri,
        //                    dataType: "json",
        //                    data: function () {
        //                        return {
        //                            str: $("#CompanyAutoComplete").val()
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

        //        $("#CompanyAutoComplete").kendoAutoComplete({
        //            dataSource: CompanyAutocompletedataSource,
        //            dataTextField: "Description"
        //        }).removeClass('k-input').removeAttr('style').parent().removeClass();
    });

    self.showMoreThan1Page = ko.observable(true);

    self.companies = ko.observableArray();
    // self.combs = ko.observableArray();
    self.companyAutocomplete = ko.observableArray();
    self.carrierNameAutocomplete = ko.observableArray();
    self.counties = ko.observableArray();
    self.employeesize = ko.observableArray();
    self.siccode = ko.observableArray();
    self.topsearches = ko.observableArray();
    self.renewals = ko.observableArray(self.Sources.Monthes);
    self.empsizeArray = [];

    self.inlineDefault = new kendo.data.HierarchicalDataSource({
        data: self.Sources.SicCodes
    });


    self.goTosearch = function (item) {
        $("#search-div").block({ message: '<h2 style="color:#fff;">Please wait...<br/></h2><div class="loading-icon"></div>', css: { border: "none", backgroundColor: 'transparent'} });

        self.companyInput(item.Description);
        self.cityInput(item.City);
        self.zipInput(item.Zip);
        self.countyNameInput(item.CountyName);
        self.phoneNumberInput(item.PhoneEmp);
        //self.renewalMonthInput(item.EffectiveMonth);

        var efMonths = item.EffectiveMonth.split(',');
        self.selectMonths([]);
        for (var k = 0; k < efMonths.length; k++) {
            if (efMonths[k] != null && efMonths[k] != "")
                self.selectMonths.push(efMonths[k]);
        }

        self.searchNameInput(item.SearchName);

        var emSize = item.EmpSizeRange.split(",");
        if (emSize.length == 2) {
            self.employeeSizeInput([parseInt(emSize[0]), parseInt(emSize[1])]);
        }
        else {
            self.employeeSizeInput([0, 7]);
        }

        var allSic = item.SicCode.split(",");
        $("#treeview-sic-code").jstree("uncheck_all");

        for (var i = 0; i < allSic.length; i++) {
            var sicCode = allSic[i];
            if (sicCode != null && sicCode != "") {
                var node = $("li.cb-sicCode[data-siccode=" + sicCode + "]");
                $("#treeview-sic-code").jstree("check_node", node);
            }
        }

        var allClassCode = item.ClassCode.split(",");
        $("#treeview-class-code").jstree("uncheck_all");

        for (var j = 0; j < allClassCode.length; j++) {
            var classCode = allClassCode[j];
            if (classCode != null && classCode != "") {
                var nodeClass = $("li.classCode[data-classCode=" + classCode + "]");
                $("#treeview-class-code").jstree("check_node", nodeClass);
            }
        }
        $("#treeview-sic-code").jstree("close_all");
        $("#treeview-Geography").jstree("uncheck_all");
        $("#selectedCriteriaPanel ul").html("");

        $("#search-div").unblock();
    };

    var modelDataGridView = new MetricsCorporationApp.DataGridViewModel();
    self.do_search = function (obj) {


        if (self.errors().length != 0) {
            self.errors.showAllMessages();
            return false;
        }

        var sicCodes = [];

        $("#treeview-sic-code").jstree("get_checked", null, false).each(function (item) {
            sicCodes.push($(this).data().siccode);
        });

        var classCodes = [];
        $("#treeview-class-code").jstree("get_checked", null, false).each(function () {
            var classCode = $(this).data().classcode;
            if (classCode != null) {
                if ($.inArray(classCode, classCodes) == -1)
                    classCodes.push(classCode);
            }
        });

        var GeographyCountyCodes = [];
        var GeographyStateCodes = [];

        $("#treeview-Geography").jstree("get_checked", null, false).each(function (item) {
            if ($(this).attr('code') == undefined) {
                GeographyCountyCodes.push($(this).attr("id"));
            } else {
                GeographyStateCodes.push($(this).attr("id"));
            }
        });

        var CarrierNumber = [];
        var CarrierGroup = [];

        $("#treeview-CarrierGroup").jstree("get_checked", null, false).each(function (item) {
            if ($(this).attr('code') == undefined) {
                CarrierNumber.push($(this).attr("id"));
            } else {
                CarrierGroup.push($(this).children("a:first").text());
            }
        });


        self.EmpsizeArray(self.employeeSizeInput().toString());

        var dataToSend = {
            CompanyName: $("#CompanyAutoComplete").val(),
            City: self.cityInput(),
            State: '',
            Zip: self.zipInput(),
            CountyName: GeographyCountyCodes,
            HasPhoneNumber: self.phoneNumberInput(),
            SicCodes: sicCodes,
            ClassCodes: classCodes,
            RenewalMonths: self.selectMonths(),
            EmployeeSize: self.employeesize,
            SearchName: self.searchNameInput(),
            States: GeographyStateCodes,
            CarrierNumbers: CarrierNumber,
            CarrierGroups: CarrierGroup
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
                modelDataGridView.companies(response.Companies);

                //set it only once to be sure for dublicate column
                if (modelDataGridView.showCarrier() == null)
                    modelDataGridView.showCarrier(response.ShowCarrier);
                //set it only once to be sure for dublicate column
                if (modelDataGridView.showStatusFld() == null)
                    modelDataGridView.showStatusFld(response.ShowStatusFld);

                modelDataGridView.showRenewalMonth(self.showRenewalMonth());
                modelDataGridView.showMoreThan1Page(self.showMoreThan1Page());

                modelDataGridView.init();
                modelDataGridView.SearchViewModelInstance = self;
                modelDataGridView.navigation = self.navigation;

                modelDataGridView.TotalCompanies(response.Total);

                //Quick Search Parameters
                modelDataGridView.QScompanyInput($("#CompanyAutoComplete").val());
                modelDataGridView.QSselectMonths(self.selectMonths());
                modelDataGridView.QSphoneNumberInput(self.phoneNumberInput());
                var StrEmpSize = '';
                if ((self.employeeSizeInput()[1] - self.employeeSizeInput()[0]) != 7) {
                    for (var count = 0; count < (self.employeeSizeInput()[1] - self.employeeSizeInput()[0]); count++) {
                        StrEmpSize = StrEmpSize + (self.employeeSizeInput()[0] + count + 1) + ',';
                    }
                    modelDataGridView.QSEmployeeSize(StrEmpSize);
                } else {
                    modelDataGridView.QSEmployeeSize([]);
                }
                StrEmpSize = '';

                if (response.Companies.length > 0) {
                    modelDataGridView.searchResultText("Displaying 1 to " + ((response.Total < response.Showed) ? response.Total : response.Showed) + " Of " + response.Total + " Records Matching Your Search Criteria");
                } else {
                    modelDataGridView.searchResultText("No Records Matching Your Search Criteria");
                }



                self.navigation.navigateTo(modelDataGridView);

                if (self.searchNameInput() != '') {
                    self.gettopSearches();
                }

                self.LoadSelectedCriateria()
                //  modelQuickSearch.init();
                //self.clearSearches();
                $.unblockUI();

                //Adjust scroll of the quicksearch div list view
                adjustPanelScroll("tdGridView");
            }
        });
    };

    self.LoadSelectedCriateria = function () {

        ClassCodeArray = [];
        SicCodeArray = [];
        sicCodeParents = [];
        classCodeParents = [];
        sicCodeText = [];
        classCodeText = [];

        $("#treeview-class-code").jstree("get_checked", null, false).each(function (item) {
            var parents = "";
            $(this).parents("li").each(function () {
                if ($(this).attr("id") != undefined) {
                    parents += $(this).attr("id") + ",";
                }
            });
            ClassCodeArray.push($(this).attr("id"));
            classCodeText.push($(this).text().trim().substr(0, 4));
            if (parents.length != 0) {
                parents = parents.slice(0, -1);
                classCodeParents.push(parents);
            }
        });

        $("#treeview-sic-code").jstree("get_checked", null, false).each(function (item) {
            var parents = "";
            $(this).parents("li").each(function () {
                if ($(this).attr("id") != undefined) {
                    parents += $(this).attr("id") + ",";
                }
            });
            SicCodeArray.push($(this).attr("id"));
            sicCodeText.push($(this).text().trim().substr(0, 4));
            if (parents.length != 0) {
                parents = parents.slice(0, -1);
                sicCodeParents.push(parents);
            }
        });

        self.SetSicClassCodes();
    };


    self.SetSicClassCodes = function () {

        $("#divSicQuickSearch ul").html("");
        $("#divClassQuickSearch ul").html("");

        for (var count = 0; count < classCodeText.length; count++) {
            var clonedItem = $("#listItem").clone(true);
            clonedItem.removeAttr("style");
            clonedItem.removeAttr("id");
            clonedItem.find("span").text(classCodeText[count]);
            clonedItem.find("img").attr("id", "0");
            $("#divClassQuickSearch ul").append(clonedItem);
        }

        for (var count = 0; count < sicCodeText.length; count++) {
            var clonedItem = $("#listItem").clone(true);
            clonedItem.removeAttr("style");
            clonedItem.removeAttr("id");
            clonedItem.find("span").text(sicCodeText[count]);
            clonedItem.find("img").attr("id", "0");
            $("#divSicQuickSearch ul").append(clonedItem);
        }
    }

    self.EmpsizeArray = function (items) {
        self.employeesize = [];
        var empsizeItems = items.split(',');
        var empsizeArray; //= new string[0];

        if (empsizeItems.length == 2 && empsizeItems[0] == empsizeItems[1]) {
            self.employeesize = [];
        }
        else if (items != undefined && items != "0,7") {
            var start = empsizeItems[0];
            var finish = empsizeItems[1];

            var j = 0;
            for (var i = start; i < finish; i++) {
                self.employeesize[j] = (parseInt(i) + 1).toString(); // self.Sources.EmployeeSize[i].name;
                j++;
            }
        }
    };

    self.do_reset = function () {
        self.clearSearches();
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
        $.blockUI({ message: '<h2 style="color:#fff;">Please wait...<br/></h2><div class="loading-icon"></div>', css: { border: "none", backgroundColor: 'transparent'} });
        self.loadCounties();
        //  self.getUserSettings();
    };

    self.loadCounties = function () {
        self.doAjaxCall(self.Sources.countyUri, self.counties, self.loadEmployeeList);
    };

    self.loadEmployeeList = function () {
        //  self.doAjaxCall(self.Sources.employeeSizeUri, self.employeesize, self.loadCombis);
        self.doAjaxCall(self.Sources.employeeSizeUri, self.employeesize, self.loadControls);
    };

    //    self.loadCombis = function () {
    //        self.doAjaxCall(self.Sources.combUri, self.combs, self.loadControls);
    //    };

    //    self.loadCarrierNameAutocomplete = function () {
    //        self.doAjaxCall(self.Sources.carrierNameAutocompleteUri, self.carrierNameAutocomplete, self.loadCompanyAutocomplete);
    //    };

    //    self.loadCompanyAutocomplete = function () {
    //        self.doAjaxCall(self.Sources.companyAutocompleteUri, self.companyAutocomplete, self.loadControls);
    //    };

    self.getUserSettings = function () {
        $.ajax({
            url: self.Sources.userSettings,
            dataType: 'json',
            success: function (response) {

                if (response != null) {
                    response = JSON.parse(response);

                    self.showRenewalMonth(response.ShowRenewalMonth);
                    self.showMoreThan1Page(response.ShowMoreThan1Page);
                }
            }
        });
    };

    self.loadControls = function () {
        self.gettopSearches();
        self.loadSlider();
        self.LoadSicCodeTreeView();
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

    self.doAjaxCall1 = function (url, callBack) {
        $.ajax({
            url: url,
            type: "POST",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            async: false,
            success: callBack
        });
    };

    self.doAjaxCallAsync = function (url, callBack) {
        $.ajax({
            url: url,
            type: "POST",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: callBack
        });
    };

    self.clearSearches = function () {

        $("#CompanyAutoComplete").val("");
        $("#CarrierName").val("");
        //self.companyInput('');
        self.cityInput('');
        self.zipInput('');
        self.countyNameInput('');
        //self.renewalMonthInput('');
        //$("#CarrierName").valueOf("");
        self.searchNameInput('');
        self.selectMonths([]);
        self.employeeSizeInput([0, 7]);
        $("#treeview-sic-code").jstree("uncheck_all");
        $("#treeview-sic-code").jstree("close_all");

        $("#treeview-class-code").jstree("uncheck_all");
        $("#treeview-class-code").jstree("close_all");

        $("#treeview-Geography").jstree("uncheck_all");
        $("#treeview-Geography").jstree("close_all");

        $("#treeview-CarrierGroup").jstree("uncheck_all");
        $("#treeview-CarrierGroup").jstree("close_all");

        $("#selectedCriteriaPanel ul").html("");
    };

    self.LoadSicCodeTreeView = function () {

        setTimeout(function () {

            $("#treeview-sic-code").jstree({
                json_data: {
                    data: self.treeDataSicCodes, progressive_render: true
                },
                "themes": {
                    "theme": "default",
                    "dots": false,
                    "icons": false
                },
                plugins: ["themes", "json_data", "ui", "checkbox"]

            }).bind('check_node.jstree', function (e, data) {
                self.updateSelectedCriteria();
            }).bind('uncheck_node.jstree', function (e, data) {
                self.updateSelectedCriteria();
            });


            $("#treeview-class-code").bind("loaded.jstree", function (event, data) {

                //$(".jstree-checkbox").css("display", "none");               
                //
            }).jstree({
                json_data: {
                    data: self.treeDataClassCodes, progressive_render: true
                },
                "themes": {
                    "theme": "default",
                    "dots": false,
                    "icons": false
                },
                plugins: ["themes", "json_data", "ui", "checkbox"]

            }).bind('check_node.jstree', function (e, data) {
                self.updateSelectedCriteria();
            }).bind('uncheck_node.jstree', function (e, data) {
                self.updateSelectedCriteria();
            });

            $("#treeview-Geography").jstree({
                json_data: {
                    data: self.GeographyCode, progressive_render: true
                },
                "themes": {
                    "theme": "default",
                    "dots": false,
                    "icons": false
                },
                plugins: ["themes", "json_data", "ui", "checkbox"]
            }).bind('check_node.jstree', function (e, data) {
                self.updateSelectedCriteria();
            }).bind('uncheck_node.jstree', function (e, data) {
                self.updateSelectedCriteria();
            });

            //            $("#treeview-Geography").bind("loaded.jstree", function (event, data) {
            //                $("#treeview-Geography ul li").each(function () {
            //                    if ($(this).attr("rel") == 'disabled') {
            //                        $(this).find('a').css("color", "gray")
            //                    }
            //                });
            //            }).jstree({
            //                json_data: {
            //                    data: self.GeographyCode, progressive_render: true
            //                },
            //                "themes": {
            //                    "theme": "default",
            //                    "dots": false,
            //                    "icons": false
            //                },
            //                'plugins': ['themes', 'json_data', 'checkbox', 'types'],
            //                'checkbox': {
            //                    'two_state': false
            //                },
            //                "types": {
            //                    "types": {
            //                        "disabled": {
            //                            "check_node": false,
            //                            "uncheck_node": false,
            //                            "select_node": false,
            //                            "open_node": false,
            //                            "close_node": false,
            //                            "create_node": false,
            //                            "delete_node": false,
            //                            "hover_node": false
            //                        },
            //                        "default": {
            //                            "check_node": function (node) {
            //                                $(node).children('.jstree-checkbox').click();
            //                                return true;
            //                            },
            //                            "uncheck_node": function (node) {
            //                                $(node).children('.jstree-checkbox').click();
            //                                return true;
            //                            }
            //                        }
            //                    }
            //                }
            //            }).bind('check_node.jstree', function (e, data) {
            //                self.updateSelectedCriteria();
            //            }).bind('uncheck_node.jstree', function (e, data) {
            //                self.updateSelectedCriteria();
            //            });

            //Load tree of the quick search page

            $("#treeview-sic-code-QuickSearch").jstree({
                json_data: {
                    data: self.treeDataSicCodes, progressive_render: true
                },
                "themes": {
                    "theme": "default",
                    "dots": false,
                    "icons": false
                },
                plugins: ["themes", "json_data", "ui", "checkbox"]
            });

            $("#treeview-class-code-QuickSearch").jstree({
                json_data: {
                    data: self.treeDataClassCodes, progressive_render: true
                },
                "themes": {
                    "theme": "default",
                    "dots": false,
                    "icons": false
                },
                plugins: ["themes", "json_data", "ui", "checkbox"]
            });


            $("#treeview-Geography-QuickSearch").jstree({
                json_data: {
                    data: self.GeographyCode, progressive_render: true
                },
                "themes": {
                    "theme": "default",
                    "dots": false,
                    "icons": false
                },
                plugins: ["themes", "json_data", "ui", "checkbox"]
            });


            $("#treeview-CarrierGroup").jstree({
                json_data: {
                    data: self.carrierNameTree, progressive_render: true
                },
                "themes": {
                    "theme": "default",
                    "dots": false,
                    "icons": false
                },
                plugins: ["themes", "json_data", "ui", "checkbox"]
            });

            $.unblockUI();
        }, 50);
    };

    self.updateSelectedCriteria = function () {
        $("#selectedCriteriaPanel ul").html("");
        $("#treeview-Geography").jstree("get_checked", null, false).each(function (item) {
            if ($("#selectedCriteriaPanel ul li").find("img#" + $(this).attr("id")).length == 0) {
                var clonedItem = $("#listItem").clone(true);
                clonedItem.removeAttr("style");
                clonedItem.removeAttr("id");
                clonedItem.find("span").text("Geography =" + $(this).find("a:first").text());
                clonedItem.find("img").attr("id", $(this).attr("id"));
                $("#selectedCriteriaPanel ul").append(clonedItem);
            }
        });

        $("#treeview-class-code").jstree("get_checked", null, false).each(function (item) {
            if ($("#selectedCriteriaPanel ul li").find("img#" + $(this).attr("id")).length == 0) {
                var clonedItem = $("#listItem").clone(true);
                clonedItem.removeAttr("style");
                clonedItem.removeAttr("id");
                clonedItem.find("span").text("NAICS =" + $(this).find("a:first").text());
                clonedItem.find("img").attr("id", $(this).attr("id"));
                $("#selectedCriteriaPanel ul").append(clonedItem);
            }
        });

        $("#treeview-sic-code").jstree("get_checked", null, false).each(function (item) {
            if ($("#selectedCriteriaPanel ul li").find("img#" + $(this).attr("id")).length == 0) {
                var clonedItem = $("#listItem").clone(true);
                clonedItem.removeAttr("style");
                clonedItem.removeAttr("id");
                clonedItem.find("span").text("Sic =" + $(this).find("a:first").text());
                clonedItem.find("img").attr("id", $(this).attr("id"));
                $("#selectedCriteriaPanel ul").append(clonedItem);
            }
        });
    };

    //Remove the node from selected criteria and uncheck it
    self.removeCriteria = function (data, event) {

        var section = $(event.target).prev().text().split('=');
        switch (section[0].trim()) {
            case "Geography":
                $(event.target).parent().remove();
                $.jstree._reference('#treeview-Geography').uncheck_node('#' + event.target.id);
                break;
            case "Sic":
                $(event.target).parent().remove();
                $.jstree._reference('#treeview-sic-code').uncheck_node('#' + event.target.id);
                break;
            case "NAICS":
                $(event.target).parent().remove();
                $.jstree._reference('#treeview-class-code').uncheck_node('#' + event.target.id);
                break;
        }
    };


    self.loadSlider = function () {
        var slider = $("#slider");

        var sliderItems = slider.siblings(".k-slider-items");

        $.each(self.employeesize(), function (index, value) {
            var item = sliderItems.find("li:eq(" + (index) + ")");
            item.attr("title", value.Description);
            item.attr("textContent", value.Description);

            if (item.find("span").length == 0) {
                item.html("<span class='k-label'></span>");
            }

            item.find("span").text(value.Description);
        });
    };

    self.clearSicCode = function () {
        var treeView = $(self.Sources.treeViewSicCodesSelector).data("kendoTreeView");

        for (var x in self.sicCodeInput) {
            var id = self.sicCodeInput[x];
            treeView.dataSource.get(id).checked = false;

        }

        treeView.dataSource.read();
    };

    self.toogleExportDialog = function () {
        $(self.Sources.exportDialogId).modal('toggle');
    };

    self.disableCopy = function () {
        //below javascript is used for Disabling right-click on HTML page
        document.oncontextmenu = new Function("return false"); //Disabling right-click


        //below javascript is used for Disabling text selection in web page
        document.onselectstart = new Function("return false"); //Disabling text selection in web page
        if (window.sidebar) {
            document.onmousedown = new Function("return false");
            document.onclick = new Function("return true");


            //Disable Cut into HTML form using Javascript 
            document.oncut = new Function("return false");


            //Disable Copy into HTML form using Javascript 
            document.oncopy = new Function("return false");


            //Disable Paste into HTML form using Javascript  
            document.onpaste = new Function("return false");
        }
    };

    self.switchCodesPanel = function (item, evt) {

        evt.preventDefault();
        $(evt).tab('show');

    };

    self.updateZip = function () {

    }

    //remove element from array
    self.removeArrayElement = function (array) {
        var what, a = arguments, L = a.length, ax;
        while (L > 1 && array.length) {
            what = a[--L];
            while ((ax = array.indexOf(what)) !== -1) {
                array.splice(ax, 1);
            }
        }
        return array;
    }

    //TODO: uncomment for release
    //self.disableCopy();

};

//Fix the selected Criteria div position
function adjustPanelScroll(divId) {

    var msie6 = $.browser == 'msie' && $.browser.version < 7;

    if (!msie6) {

        var top = $('#' + divId).offset().top - parseFloat($('#' + divId).css('margin-top').replace(/auto/, 0));
        $(window).scroll(function (event) {

            var y = $(this).scrollTop();

            if (y >= top) {
                $('#' + divId).addClass('fixed');
            } else {
                $('#' + divId).removeClass('fixed');
            }
        });
    }
}