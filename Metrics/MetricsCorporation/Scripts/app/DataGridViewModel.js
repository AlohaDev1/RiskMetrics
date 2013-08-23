MetricsCorporationApp.DataGridViewModel = function () {

    var that = {};
    that.viewName = "DataGridView";
    that.nav = "";

    that.Sources = new MetricsCorporationApp.DataSources();
    self.koBindings = new MetricsCorporationApp.KoBindings();

    that.CompanyName = ko.observable("");
    that.City = ko.observable("");
    that.State = ko.observable("");
    that.Zip = ko.observable("");
    that.County = ko.observable("");
    that.Phone = ko.observable("");
    that.SicCode = ko.observable("");
    that.RenewalMonth = ko.observable("");
    that.EmployeeSize = ko.observable("");
    that.CarrierGroup = ko.observable("");
    that.Address = ko.observable("");
    that.Id = ko.observable("");
    that.isOpen = ko.observable(false);
    that.contacts = ko.observableArray();


    // User purchased details properties
    that.isDetailsOpen = ko.observable(false);
    that.userTitle = ko.observable();
    that.graveyardStatus = ko.observable();
    that.firstname = ko.observable();
    that.lastname = ko.observable();
    that.state = ko.observable();
    that.country = ko.observable();
    that.city = ko.observable();
    that.zip = ko.observable();
    that.areaCode = ko.observable();
    that.phone = ko.observable();
    that.email = ko.observable();
    that.address = ko.observable();

    that.gridOptions = {
        pageable: true,
        pageSize: 10,
        height: 500,
        sortable: true,
        columns: [
                { command: { text: "View Details", click: function (e) {
                    e.preventDefault();

                    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));

                    that.GoToDetailsView(dataItem);
                }
                }, title: " "
                },
                { field: "CompanyName", title: "Company Name" },
                { field: "City" },
                { field: "State" },
                { field: "SicCode", title: "Sic Code" },
                { field: "CarrierGroup", title: "Carrier Group" }
            ],
        editable: true
    };

    that.contactsGridOptions = {
        pageable: true,
        pageSize: 5,
        height: 250,
        sortable: true,
        columns: [
                { command: { text: "View Details", click: function (e) {
                    e.preventDefault();

                    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));

                    that.OpenPurchaseDetailsWindow(dataItem);
                }
                }, title: " "
                },
                { field: "Title", title: "Title" },
                { field: "FirstName", title: "First Name" },
                { field: "LastName", title: "Last Name" },
                { field: "State" },
                { field: "Country" }
            ],
        editable: true
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

    that.OpenPurchaseDetailsWindow = function (obj) {
        $.ajax({
            url: that.Sources.contactsUri + '/' + obj.ContactId,
            dataType: 'json',
            success: function (item) {
                if (item == null) {
                    alert('This action not allowed. Please buy credits.');
                    return;
                }
                that.isDetailsOpen(true);
                that.userTitle(item.Title);
                that.graveyardStatus(item.GraveyardStatus);
                that.firstname(item.FirstName);
                that.lastname(item.LastName);
                that.state(item.State);
                that.country(item.Country);
                that.city(item.City);
                that.zip(item.Zip);
                that.areaCode(item.AreaCode);
                that.phone(item.Phone);
                that.email(item.Email);
                that.address(item.Address);
            }
        });
    };

    that.companies = ko.observableArray();

    that.GoToDetailsView = function (e) {
        that.CompanyName(e.CompanyName);
        that.City(e.City);
        that.State(e.State);
        that.Zip(e.Zip);
        that.County(e.County);
        that.Phone(e.Phone);
        that.SicCode(e.SicCode);
        that.RenewalMonth(e.RenewalMonth);
        that.EmployeeSize(e.EmployeeSize);
        that.CarrierGroup(e.CarrierGroup);
        that.Address(e.Address);
        that.Id(e.Id);

        var companyName = that.CompanyName();
        companyName = companyName.toLowerCase().replace(" inc", "");
        companyName = companyName.replace(" llc", "");

        $.ajax({
            url: that.Sources.linkedInCompanyIdUrl + companyName,
            dataType: 'jsonp',
            success: function (obj) {
                that.LoadLinkedInId(obj);
            }
        });
    };

    that.LoadLinkedInId = function (companyInfo) {
        var id = 0;

        if (companyInfo.company.resultList != '') {
            id = companyInfo.company.resultList[0].id;
        }

        var str = '<iframe width="425" height="350" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="/Home/Earth';
        str += '?Name=';
        str += that.CompanyName();
        str += '&Address=';
        str += that.Address();
        str += '&City=';
        str += that.City();
        str += '&State=';
        str += that.State();
        str += '&Zip=';
        str += that.Zip();
        str += '"></iframe>';

        if (id > 0) {
            str += '<iframe width="425" height="350" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="/Home/LinkedIn/';
            str += id;
            str += '"></iframe>';
        }

        $(that.Sources.linkedInDivId).empty();
        $(that.Sources.linkedInDivId).append(str);
        that.contacts([]);
        that.isOpen(true);
    };

    that.get_companyContacts = function () {
        $.ajax({
            url: that.Sources.contactsUri,
            data: {
                companyName: that.CompanyName()
            },
            dataType: 'json',
            success: function (contacts) {
                that.contacts(contacts);
            }
        });
    };

    return that;


};