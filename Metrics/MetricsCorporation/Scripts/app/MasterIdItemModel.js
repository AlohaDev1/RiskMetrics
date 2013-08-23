MetricsCorporationApp.MasterIdItemModel = function (item, isEditMode, isCopyMode) {
    var self = this;

    //don't set id if we copy item with exist data
    self.Id = ko.observable(item != null && (isCopyMode == null || (isCopyMode != null && isCopyMode == false)) ? item.Id : "");

    self.UserName = ko.observable(item != null ? item.UserName : "");
    self.Password = ko.observable(item != null ? item.Password : "");
    self.CompanyName = ko.observable(item != null ? item.CompanyName : "");
    self.FirstName = ko.observable(item != null ? item.FirstName : "");
    self.LastName = ko.observable(item != null ? item.LastName : "");
    self.Headline = ko.observable(item != null ? item.Headline : "");
    self.ProfileRequest = ko.observable(item != null ? item.ProfileRequest : "");

    this.FullName = ko.computed(function () {
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
    };

};