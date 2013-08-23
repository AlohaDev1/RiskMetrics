MetricsCorporationApp.DetailsSearchViewModel = function () {

    var self = this;
    self.viewName = "DetailsSearchView";
    self.navigation = null;
    self.Sources = new MetricsCorporationApp.DataSources();

    self.GoogleIframeUrl = "/MetricsCorporation.Orchard.Web/Search/Earth";
    self.LinkedInIframeUrl = "/MetricsCorporation.Orchard.Web/Search/LinkedIn/";

    self.showCarrier = ko.observable();
    self.showStatusFld = ko.observable();
    self.companies = ko.observableArray();
    self.dataGridViewInstance = null;
    self.SearchViewModelInstance = null;

    self.init = function (nav, response) {
        self.navigation = nav;

        self.CompanyName(response.CompanyName);
        self.City(response.City);
        self.State(response.State);
        self.Zip(response.Zip);
        self.County(response.County);
        self.Phone(response.Phone);
        self.SicCode(response.SicCode);
        self.RenewalMonth(response.RenewalMonth);
        self.PolicyRenewalDate(response.PolicyRenewalDate);
        self.EmployeeSize(response.EmployeeSize);
        self.CarrierGroup(response.CarrierGroup);
        self.CarrierGroupName(response.CarrierGroupName);
        self.CarrierOfRecord(response.CarrierOfRecord);
        self.ContactName(response.ContactName);
        self.Address(response.Address);
        self.Id(response.Id);
        self.ClassCode(response.ClassCode);
        self.Status(response.Status);
        self.AdditionalInfo(response.AdditionalInfo);

        var companyName = self.CompanyName();
        companyName = companyName.toLowerCase().replace(" inc", "");
        companyName = companyName.replace(" llc", "");

        $.ajax({
            url: self.Sources.linkedInCompanyIdUrl + companyName,
            dataType: 'jsonp',
            success: function (obj) {
                self.LoadLinkedInId(obj);
            }
        });
    };


    self.CompanyName = ko.observable("");
    self.City = ko.observable("");
    self.State = ko.observable("");
    self.Zip = ko.observable("");
    self.County = ko.observable("");
    self.Phone = ko.observable("");
    self.SicCode = ko.observable("");
    self.RenewalMonth = ko.observable("");
    self.PolicyRenewalDate = ko.observable("");
    self.EmployeeSize = ko.observable("");
    self.CarrierGroup = ko.observable("");
    self.CarrierGroupName = ko.observable("");
    self.CarrierOfRecord = ko.observable("");
    self.ContactName = ko.observable("");
    self.ClassCode = ko.observable("");
    self.Address = ko.observable("");
    self.Status = ko.observable("");
    self.AdditionalInfo = ko.observable("");
    self.Id = ko.observable("");
    self.isOpen = ko.observable(false);
    self.contacts = ko.observableArray();


    // User purchased details properties
    self.isDetailsOpen = ko.observable(false);
    self.userTitle = ko.observable();
    self.graveyardStatus = ko.observable();
    self.firstname = ko.observable();
    self.lastname = ko.observable();
    self.state = ko.observable();
    self.country = ko.observable();
    self.city = ko.observable();
    self.zip = ko.observable();
    self.areaCode = ko.observable();
    self.phone = ko.observable();
    self.email = ko.observable();
    self.address = ko.observable();

    ko.bindingHandlers.Googlemap = {
        update: function (element, valueAccessor, allBindingsAccessor, viewModel) {
            var mapObj = ko.utils.unwrapObservable(valueAccessor());
            var latLng = new google.maps.LatLng( ko.utils.unwrapObservable(mapObj.lat), ko.utils.unwrapObservable(mapObj.lng));
            var mapOptions = {
                center: latLng,
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

            var pinIcon = {
                url: 'http://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=%E2%80%A2|FE7569',
                size: new google.maps.Size(42, 68)
            };

            mapObj.marker = new google.maps.Marker({
                map: mapObj.googleMap,
                position: latLng,
                title: "Company Name:",
                draggable: false,
                icon: pinIcon
            });

            var infowindow = new google.maps.InfoWindow({
                content: 'Location info:<br/>Country Name:<br/>LatLng:',
                disableAutoPan: false
            });

            google.maps.event.addListener(mapObj.marker, 'click', function () {
                // Calling the open method of the infoWindow 
                infowindow.open(mapObj.googleMap, mapObj.marker);
            });

            $("#" + element.getAttribute("id")).data("mapObj", mapObj);

        }
    };

    self.LoadLinkedInId = function (companyInfo) {

        var str = '<iframe width="425" height="250" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="';
        str += self.LinkedInIframeUrl;
        str += "162479"; //[TO-DO] need to replace with linkedIn CompanyId from data base
        str += '"></iframe>';

        $(self.Sources.linkedInDivId).html("\r\n");
        $(self.Sources.linkedInDivId).html(str);
        $(self.Sources.linkedInDivId).removeAttr("id");
        self.contacts([]);
    };

    self.get_companyContacts = function () {
        $.ajax({
            url: self.Sources.contactsUri,
            beforeSend: function () {
                $(self.Sources.contactsGridId).block({ message: '<h2 style="color:#fff;"></h2><div class="loading-icon"></div>', css: { border: "none", backgroundColor: 'transparent'} });
            },
            data: {
                companyName: self.CompanyName()
            },
            dataType: 'json',
            success: function (contacts) {
                self.contacts(contacts);
                $(self.Sources.contactsGridId).unblock();
            }
        });
    };

    self.rankRecord = function () {

    };


    self.contactsGridOptions = {
        pageable: true,
        pageSize: 5,
        height: 250,
        sortable: true,
        columns: [
                { command: { text: "View Details", click: function (e) {
                    e.preventDefault();

                    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));

                    self.OpenPurchaseDetailsWindow(dataItem);
                }
                }, title: " "
                },
                { field: "Title", title: "Title" },
                { field: "FirstName", title: "First Name" },
                { field: "LastName", title: "Last Name" },
                { field: "State" },
                { field: "Country" }
            ],
        editable: false
    };

    self.OpenPurchaseDetailsWindow = function (obj) {
        $.ajax({
            url: self.Sources.contactsUri + '/' + obj.ContactId,
            dataType: 'json',
            success: function (item) {
                if (item == null) {
                    alert('This action not allowed. Please buy credits.');
                    return;
                }
                self.isDetailsOpen(true);
                self.userTitle(item.Title);
                self.graveyardStatus(item.GraveyardStatus);
                self.firstname(item.FirstName);
                self.lastname(item.LastName);
                self.state(item.State);
                self.country(item.Country);
                self.city(item.City);
                self.zip(item.Zip);
                self.areaCode(item.AreaCode);
                self.phone(item.Phone);
                self.email(item.Email);
                self.address(item.Address);
            }
        });
    };

    self.backToSearchResults = function () {
        self.navigation.navigateTo(self.dataGridViewInstance);
    };


    // Navigating to the Search screen
    self.goToSearchView = function () { // View model navigation
        self.SearchViewModelInstance.do_reset();
        self.navigation.navigateTo(self.SearchViewModelInstance);
    };
}
