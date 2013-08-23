MetricsCorporationApp.QuickSearchModel = function () {

    var that = {};
    that.viewName = "QuickSearch";
    that.navigation = null;
    that.init = function () {
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

        $("#QSCompanyAutoComplete").kendoAutoComplete({
            dataSource: QsCompanyAutocompletedataSource,
            dataTextField: "Description"
        });

    };

    self.Sources = new MetricsCorporationApp.DataSources();
    that.Sources = new MetricsCorporationApp.DataSources();
    that.koBindings = new MetricsCorporationApp.KoBindings();

    return that;
};