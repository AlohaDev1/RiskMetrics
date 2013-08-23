MetricsCorporationApp.DataGridViewModel = function () {

    var that = {};
    that.viewName = "DataGridView";

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
    that.QSSicInput = ko.observable("");
    that.QSClassInput = ko.observable("");
    that.QScompanyInput = ko.observable();
    that.QSselectMonths = ko.observableArray();
    that.QSEmployeeSize = ko.observableArray();
    that.QSphoneNumberInput = ko.observable(true);

    that.TotalCompanies = ko.observable();

    that.companies = ko.observableArray();
    that.SearchViewModelInstance = null;

    self.mapOne = ko.observable({
        lat: ko.observable(),
        lng: ko.observable()
    });

    $(document).ready(function () {
        var QsCompanyAutocompletedataSource = new kendo.data.DataSource({
            serverFiltering: true,
            serverPaging: true,
            type: 'odata',
            transport: {
                read: {
                    url: self.Sources.companyAutocompleteUri,
                    dataType: "json",
                    data: function () {
                        return {
                            str: $("#QSCompanyAutoComplete").val()
                        }
                    }
                },
                parameterMap: function (options, type) {
                    var paramMap = kendo.data.transports.odata.parameterMap(options);

                    delete paramMap.$inlinecount;
                    delete paramMap.$format;

                    return paramMap;
                }
            },
            schema: {
                data: function (data) {
                    return data;
                },
                total: function (data) {
                    return data.length;
                }
            }
        });

    });

    ko.bindingHandlers.map = {
        update: function (element, valueAccessor, allBindingsAccessor, viewModel) {
            var mapObj = ko.utils.unwrapObservable(valueAccessor());
            var latLng = new google.maps.LatLng(ko.utils.unwrapObservable(mapObj.lat), ko.utils.unwrapObservable(mapObj.lng));

            var locations = [
                              ['Bondi Beach', -33.890542, 151.274856, 4],
                              ['Coogee Beach', -33.923036, 151.259052, 5],
                              ['Cronulla Beach', -34.028249, 151.157507, 3],
                              ['Manly Beach', -33.80010128657071, 151.28747820854187, 2],
                              ['Maroubra Beach', -33.950198, 151.259302, 1]
                            ];

            var mapOptions = {
                center: new google.maps.LatLng(-33.92, 151.25),
                zoom: 6,
                mapTypeId: google.maps.MapTypeId.ROADMAP,
                mapTypeControl: true,
                mapTypeControlOptions: {
                    style: google.maps.MapTypeControlStyle.DEFAULT,
                    poistion: google.maps.ControlPosition.TOP_RIGHT,
                    mapTypeIds: [google.maps.MapTypeId.ROADMAP,
                    google.maps.MapTypeId.TERRAIN,
                    google.maps.MapTypeId.HYBRID,
                    google.maps.MapTypeId.SATELLITE]
                },
                zoomControl: true,
                zoomControlOptions: {
                    style: google.maps.ZoomControlStyle.SMALL
                }
            };

            mapObj.googleMap = new google.maps.Map(element, mapOptions);

            var infowindow = new google.maps.InfoWindow();

            var marker, i;
            var markers = [];
            for (i = 0; i < locations.length; i++) {
                marker = new google.maps.Marker({
                    position: new google.maps.LatLng(locations[i][1], locations[i][2]),
                    map: mapObj.googleMap
                });

                google.maps.event.addListener(marker, 'click', (function (marker, i) {
                    return function () {
                        infowindow.setContent(locations[i][0]);
                        infowindow.open(mapObj.googleMap, marker);
                    }
                })(marker, i));

                markers.push(marker);
            }

            var markerCluster = new MarkerClusterer(mapObj.googleMap, markers);


            //            mapObj.marker = new google.maps.Marker({
            //                map: mapObj.googleMap,
            //                position: latLng,
            //                title: "Company Name:",
            //                draggable: false,
            //                icon: pinIcon
            //            });

            //            var infowindow = new google.maps.InfoWindow({
            //                content: 'Location info:<br/>Country Name:<br/>LatLng:'
            //            });
            //            google.maps.event.addListener(mapObj.marker, 'click', function () {
            //                // Calling the open method of the infoWindow 
            //                infowindow.open(mapObj.googleMap, mapObj.marker);
            //            });

            //                mapObj.onChangedCoord = function (newValue) {
            //                    var latLng = new google.maps.LatLng(
            //            ko.utils.unwrapObservable(mapObj.lat),
            //            ko.utils.unwrapObservable(mapObj.lng));
            //                    mapObj.googleMap.setCenter(latLng);
            //                };

            //                mapObj.onMarkerMoved = function (dragEnd) {
            //                    var latLng = mapObj.marker.getPosition();
            //                    mapObj.lat(latLng.lat());
            //                    mapObj.lng(latLng.lng());
            //                };

            //                mapObj.lat.subscribe(mapObj.onChangedCoord);
            //                mapObj.lng.subscribe(mapObj.onChangedCoord);

            //                google.maps.event.addListener(mapObj.marker, 'dragend', mapObj.onMarkerMoved);
            $("#" + element.getAttribute("id")).data("mapObj", mapObj);
        }
    };
    var gridColumns = [
        { field: "IsExport", title: "", headerTemplate: "Export <br/><input id ='chkAll' type='checkbox' onclick='self.selectAll()'/>", template: '<input type="checkbox" class="check-box" #= IsExport ? checked="checked" : "" # ></input>' },
        { field: "CompanyName", title: "Company Name" },
        { field: "City" },
        { field: "State", width: 50 },
        { field: "EmployeeSize", title: "Employee Size", width: 120 },
        { field: "SicCode", title: "Sic Code", width: 100 }
    ];


    that.showCarrier = ko.observable();
    that.showCarrier.subscribe(function (newValue, oldValue) {
        if (newValue === true) {
            gridColumns.push({ field: "CarrierGroup", title: "Carrier Group" });
        }
    });

    that.showStatusFld = ko.observable();
    that.showStatusFld.subscribe(function (newValue, oldValue) {
        if (newValue === true) {
            gridColumns.push({ field: "Status", title: "Status", width: 100 });
        }
    });


    that.gridOptions = {

        pageable: true,
        pageSize: 25,
        sortable: false,
        scrollable: false,
        columns: gridColumns,
        editable: false,
        dataBound: function (e) {

            var grid = this;

            $('#gridCompanies table tr td:not(:first-child)').click(function (event) {
                var index = $(this).closest("tr")[0].rowIndex - 1;
                if (index > -1) {
                    that.GoToDetailsView(e.sender._data[index]);
                }
            });

            $('#gridCompanies table tr td:first-child').click(function (event) {
                if ($(event.target).is("input")) {
                    var index = $(this).closest("tr")[0].rowIndex - 1;
                    grid.dataSource._data[index].IsExport = $(event.target).is(":checked");
                    that.SetExportFlag(e.sender._data[index].Id, $(event.target).is(":checked"));
                    
                    if (!$(event.target).is(":checked")) {
                        $("#gridCompanies table tr th:first-child").find("input").removeAttr("checked", "");
                    }
                }
            });

            //self.selectAll();

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

    self.showRanking = function () {

        var slider = $(".rankBar").kendoSlider({
            orientation: "horizontal",
            min: 0,
            max: 10,
            largeStep: 1,
            showButtons: false
        });

        var steps = {};
        steps[0] = '0';
        steps[1] = '1';
        steps[2] = '2';
        steps[3] = '3';
        steps[4] = '4';
        steps[5] = '5';
        steps[6] = '6';
        steps[7] = '7';
        steps[8] = '8';
        steps[9] = '9';
        steps[10] = '10';


        var sliderItems = slider.siblings(".k-slider-items");

        $.each(steps, function (index, value) {
            var item = sliderItems.find("li:eq(" + (index) + ")");
            item.append("<span class='k-label'>" + index + "</span>");
        });
    };

    self.selectAll = function () {
        if ($("#chkAll").attr("checked")) {
            $(".check-box").attr("Checked", "Checked");
            for (var index = 0; index < $("#gridCompanies").data("kendoGrid").dataSource._data.length; index++) {
                $("#gridCompanies").data("kendoGrid").dataSource._data[index].IsExport = true;
            }
            ko.utils.arrayMap(that.companies(), function (item) {
                item.IsExport = true;
            });
        }
        else {
            $(".check-box").removeAttr("checked");
            for (var index = 0; index < $("#gridCompanies").data("kendoGrid").dataSource._data.length; index++) {
                $("#gridCompanies").data("kendoGrid").dataSource._data[index].IsExport = false;
            }
            ko.utils.arrayMap(that.companies(), function (item) {
                item.IsExport = false;
            });
        }
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
                    modelDataGridView.showCarrier(that.showCarrier());
                    modelDataGridView.dataGridViewInstance = that;
                    modelDataGridView.SearchViewModelInstance = that.SearchViewModelInstance;
                    // removed mannual logic to display google map instead we are using thsi model information in knockout js to bind
                    modelDataGridView.companymarker = ko.observable({
                        //[TO-DO] need make dynamic calls
                        lat: ko.observable(27.371767),
                        lng: ko.observable(-81.542244)
                    });
                    that.navigation.navigateTo(modelDataGridView);

                    self.showRanking();

                } else {
                    $.unblockUI();
                    alert("Your subcription max view report limit is full.");
                }

                $.unblockUI();
            },
            error: function () {
                $.unblockUI();
            }
        });


    };

    that.SetExportFlag = function (companyModelId, checkFlag) {
        ko.utils.arrayMap(this.companies(), function (item) {
            if (item.Id == companyModelId) {
                item.IsExport = checkFlag;
            }
        });
    }



    self.LoadSelectedCriateria = function () {

        ClassCodeArray = [];
        SicCodeArray = [];
        sicCodeParents = [];
        classCodeParents = [];
        sicCodeText = [];
        classCodeText = [];

        $("#treeview-class-code-QuickSearch").jstree("get_checked", null, false).each(function (item) {
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

        $("#treeview-sic-code-QuickSearch").jstree("get_checked", null, false).each(function (item) {
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

        $("#ClassSicCodes").modal('toggle');
        self.do_Quicksearch();
    }

    self.do_Quicksearch = function (obj) {
        var EmployeeSize = [];
        if ($("#EmployeeSizeQuickSearch").val() != undefined) {
            for (var i = 0; i < $("#EmployeeSizeQuickSearch").val().length; i++) {
                EmployeeSize.push($("#EmployeeSizeQuickSearch").val()[i]);
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

        var carrierNumbers = [];
        var dataToSend = {
            CompanyName: that.QScompanyInput(),
            // CarrierName: '',
            City: '', // that.QScityInput(),
            State: '',
            Zip: '', //that.QSzipInput(),
            CountyName: GeographyCountyCodes,
            HasPhoneNumber: that.QSphoneNumberInput(),
            SicCodes: sicCodes, //that.QSSicInput(),
            ClassCodes: classCodes, //that.QSClassInput(),
            RenewalMonths: that.QSselectMonths(), //RenewalMonth,
            EmployeeSize: EmployeeSize, //EmployeeSize.toString(),
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
                //set it only once to be sure for dublicate column
                if (that.showCarrier() == null)
                    that.showCarrier(response.ShowCarrier);
                //set it only once to be sure for dublicate column
                if (that.showStatusFld() == null)
                    that.showStatusFld(response.ShowStatusFld);

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

    self.SwichtoMapView = function (obj) {
        var MapView = new MetricsCorporationApp.MapViewModel();
        MapView.init();
        MapView.dataGridViewInstance = that;
        MapView.SearchViewModelInstance = that.SearchViewModelInstance;
        MapView.companies = that.companies;
        MapView.navigation = that.navigation;

        self.mapOne = ko.observable({
            lat: ko.observable(36.738884),
            lng: ko.observable(42.608127)
        });
        MapView.QScompanyInput(that.QScompanyInput());
        MapView.QSselectMonths(that.QSselectMonths());
        MapView.QSEmployeeSize(that.QSEmployeeSize());
        MapView.QSphoneNumberInput(that.QSphoneNumberInput());
        that.navigation.navigateTo(MapView);

        //Adjust scroll of the quicksearch div map view
        adjustPanelScroll("tdGridView1");
    };

    self.clearSearches = function () {
        that.QScompanyInput('');
        that.QSSicInput('');
        that.QSClassInput('');
        that.QSselectMonths([]);
        that.QSEmployeeSize([]);
        $("#divSicQuickSearch ul").html("");
        $("#divClassQuickSearch ul").html("");
    };

    self.do_QSreset = function () {
        self.clearSearches();
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