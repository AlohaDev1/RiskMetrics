MetricsCorporationApp.KoBindings = function() {
    var self = this;

    //Binding handlers for Kendo Grid

    ko.bindingHandlers.kendoGrid = {
        init: function(element, valueAccessor, allBindingsAccessor, viewModel) {
            var unwrap = ko.utils.unwrapObservable;
            var dataSource = valueAccessor();
            var binding = allBindingsAccessor();
            var options = { };
            var source;

            if (binding.gridOptions) {
                options = $.extend(options, binding.gridOptions);
            }

            var handleValueChange = function(arg) {
                var selectedItems = this.select();
                var selected = $.map(selectedItems, function(column) {
                    return $(item).text();
                });

                if (options.selected)
                    options.selected(arg);
            };

            var dataChange = function(e) {
                var keyProp = binding.key;

                //Use this keyProp to find the model obj edited in the observable Array 
                // and edit each of its properties manually from the kendo DataSource

            };

            options.change = handleValueChange;
            if (options.dataBound)
                options.dataBound = options.dataBound;

            if (unwrap(dataSource) instanceof Array) {
                if (!ko.isObservable(dataSource)) {
                    source = ko.observableArray(dataSource);
                } else
                    source = dataSource;

                var mappedSource = ko.dependentObservable(function() {
                    var mapped = ko.utils.arrayMap(unwrap(dataSource), function(item) {
                        var result = { };
                        for (var prop in item) {
                            if (item.hasOwnProperty(prop)) {
                                result[prop] = unwrap(item[prop]);
                            }
                        }
                        return result;
                    });
                    return mapped;
                }, viewModel);

                //Subscribe to the knockout observable array to get new/remove items
                mappedSource.subscribe(function(newValues) {
                    var grid = $(element).data('kendoGrid');
                    grid.dataSource.data(newValues);
                    grid.refresh();
                });
            } else
                throw 'The dataSource defined must be a javascript object array or knockout observable array!';

            options.dataSource = new kendo.data.DataSource({
                data: mappedSource(),
                pageSize: binding.pageSize || options.pageSize,
                //schema: binding.schema,
                change: dataChange
            });
            $(element).kendoGrid(options);
        }
    };


};


ko.bindingHandlers.select2 = {
    init: function (element, valueAccessor, allBindingsAccessor) {
        var obj = valueAccessor(),
            allBindings = allBindingsAccessor(),
            lookupKey = allBindings.lookupKey;
        $(element).select2(obj);
        if (lookupKey) {
            var value = ko.utils.unwrapObservable(allBindings.value);
            $(element).select2('data', ko.utils.arrayFirst(obj.data.results, function (item) {
                return item[lookupKey] === value;
            }));
        }

        ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
            $(element).select2('destroy');
        });
    },
    update: function (element) {
        $(element).trigger('change');
    }
};