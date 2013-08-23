// We will do ko.applyBindings on the ShellModel
MetricsCorporationApp.ShellModel = function () {
    var self = this;

    self.searchViewModel = new MetricsCorporationApp.SearchViewModel();
    //self.detailsViewModel = new MetricsCorporationApp.DataGridViewModel();

    self.Sources = new MetricsCorporationApp.DataSources();

    // Store a reference in MetricsCorporationApp.navigation for easy access from other view models
    self.navigation = MetricsCorporationApp.navigation = new ko.navigation.ShellNavigationModel({
        // The vm to initialize with, either an instance or factory/accessor function
        defaultViewModel: self.searchViewModel
        //maxStackSize: 5 // Expire items after a certain point to cap memory usage
    });

    // Navigating to the Search screen
    self.GoToSearchView = function () { // View model navigation

        if (self.navigation.currentItem().Id != null) {
            if (self.navigation.currentItem().Id() != null && self.navigation.currentItem().Id() != "") {
                self.navigation.currentItem().Id("");
            }
        }

        self.navigation.navigateTo(self.searchViewModel);
    };

    self.saveFileName = ko.observable();
    self.exportCounts = ko.observable();

    self.toggleExportDialog = function () {

        $(self.Sources.exportDialogId).modal('toggle');

        $(".exportStep1").show();
        $(".exportError").hide();
        $(".exportStep2").hide();

        self.saveFileName("");

        if (self.navigation.currentItem().viewName == "DetailsSearchView") {
            $(self.Sources.exportDialogId + " h3").text("Export Report");
            self.exportCounts(1);
            $(".xml-export").show();
        } else {
            $(self.Sources.exportDialogId + " h3").text("Export List");
            // self.exportCounts(self.navigation.currentItem().TotalCompanies());
            var count = 0;          
            ko.utils.arrayMap(this.companies(), function (item) {
                if (item.IsExport)
                    count++;
            });
            self.exportCounts(count);
            $(".xml-export").hide();
        }
    };
    //added for Quick Search Sic and Class Code update pop up
    self.toggleClassSicCodesDialog = function () {

        $("#ClassSicCodes").modal('toggle');
        $("#treeview-class-code-QuickSearch").jstree("uncheck_all");
        $("#treeview-sic-code-QuickSearch").jstree("uncheck_all");

        for (var i = 0; i < classCodeParents.length; i++) {
            var parents = classCodeParents[i].trim().split(",");
            for (var j = parents.length; j >= 0; j--) {
                $('#treeview-class-code-QuickSearch').jstree("open_node", '#' + parents[j]);
            }
        }

        for (var i = 0; i < sicCodeParents.length; i++) {
            var parents = sicCodeParents[i].split(",");
            for (var j = parents.length; j >= 0; j--) {
                $('#treeview-sic-code-QuickSearch').jstree("open_node", '#' + parents[j]);
            }
        }

        for (var i = 0; i < SicCodeArray.length; i++) {
            $.jstree._reference("#treeview-sic-code-QuickSearch").check_node('#' + SicCodeArray[i]);
        }

        for (var i = 0; i < ClassCodeArray.length; i++) {
            $.jstree._reference("#treeview-class-code-QuickSearch").check_node('#' + ClassCodeArray[i]);
        }

        for (var i = 0; i < classCodeParents.length; i++) {
            var parents = classCodeParents[i].trim().split(",");
            for (var j = parents.length; j >= 0; j--) {
                $('#treeview-class-code-QuickSearch').jstree("close_node", '#' + parents[j]);
            }
        }

        for (var i = 0; i < sicCodeParents.length; i++) {
            var parents = sicCodeParents[i].split(",");
            for (var j = parents.length; j >= 0; j--) {
                $('#treeview-sic-code-QuickSearch').jstree("close_node", '#' + parents[j]);
            }
        }

    };

    //Colse Model popup
    self.CloseClassSicCodesDialog = function () {
        $("#ClassSicCodes").modal('toggle');
    };

    //Make Ajax call to fetch data from data base
    self.doAjaxCall = function (url, successFunction) {

        $.ajax({
            url: url,
            type: "POST",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            async: false,
            error: function () {
                alert("error");
            },
            success: successFunction
        });
    };

    self.goToStep2 = function () {  

        $("#saveFileName").parent().removeClass("error");
        if (self.saveFileName() == null || self.saveFileName() == "") {
            $("#saveFileName").parent().addClass("error");
            return;
        }
        self.saveExportItems();
    };

    self.exportItems = function (obj, el) {
        //var r = console.log("te");

        debugger;
        var currentModel = self.navigation.currentItem();
        if (currentModel != null && currentModel.companies() != null) {
            var exportIds = [];
            if (currentModel.viewName == "DetailsSearchView") {
                exportIds.push(currentModel.Id());
            } else {
                var ids = ko.utils.arrayMap(currentModel.companies(), function (item) {
                    if (item.IsExport == true) {
                        return exportIds.push(item.Id);
                    }
                });

                //exportIds.push(ids);
            }

            var exportType = $(el.toElement || el.target).hasClass("csv-export") ? "csv" : "xml";
            //$("#exportForm").submit();
            var model = {
                CompanyIds: exportIds,
                ExportType: exportType,
                ExportFileName: self.saveFileName()
                //__RequestVerificationToken: antiForgeryToken
            };

            $("#exportForm").attr("action", self.Sources.exportUrl);
            // var exportForm = $("<form action='" + self.Sources.exportUrl + "' method='POST' style='display:none;'></form>");
            $("#exportForm").append("<input type='hidden' name='ExportType' value='" + model.ExportType + "'></input>");
            $("#exportForm").append("<input type='hidden' name='ExportFileName' value='" + model.ExportFileName + "'></input>");
            for (var i = 0; i < model.CompanyIds.length; i++) {
                $("#exportForm").append("<input type='hidden' name='CompanyIds' value='" + model.CompanyIds[i] + "'></input>");
            }
            //alert(exportForm.html());
            //exportForm.append("#exportDialog");
            $("#exportForm").submit();

        }
    };

    self.saveExportItems = function (obj, el) {
        //var r = console.log("te");
        var currentModel = self.navigation.currentItem();
        if (currentModel != null && currentModel.companies() != null) {
            var exportIds = [];
            if (currentModel.viewName == "DetailsSearchView") {
                exportIds.push(currentModel.Id());
            } else {
                var ids = ko.utils.arrayMap(currentModel.companies(), function (item) {
                    if (item.IsExport == true) {
                        return exportIds.push(item.Id);
                    }
                });

                //exportIds.push(ids);
            }

            //var exportType = $(el.toElement).hasClass("csv-export") ? "csv" : "xml";
            //$("#exportForm").submit();
            var model = {
                CompanyIds: exportIds,
                //ExportType: exportType,
                ExportFileName: self.saveFileName()
                //__RequestVerificationToken: antiForgeryToken
            };

            //            var dataToSend = {
            //                model: model
            //            };

            $.ajax({
                url: self.Sources.saveExportUrl,
                type: "POST",
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                data: JSON.stringify(model),
                //                data: {
                //                    //model: JSON.stringify(model)
                //                    //__RequestVerificationToken: antiForgeryToken
                //                },
                beforeSend: function () {
                    //$.blockUI({ message: '<h2 style="color:#fff;">Please wait...<br/></h2><div class="loading-icon"></div>', css: { border: "none", backgroundColor: 'transparent'} });
                },
                error: function () {
                    //$.unblockUI();
                    alert("Unknow error");
                },
                success: function (response) {
                    //response = JSON.parse(response);

                    if (response === true) {
                        $(".exportStep1").hide();
                        $(".exportStep2").show();

                    } else {
                        //alert("ee");
                        $(".exportStep1").hide();
                        $(".exportStep2").hide();
                        $(".exportError").show();
                        $(".textError").text("You have reached your limit for exporting records. Your contract allows you to export " + response.TotalPerMonthAvailable + " records. You have exported (excluding current request) " + response.TotalPerMonthExported + " records. Your current request is for " + response.CurrentRequest + " records");
                    }

                    //$.unblockUI();
                }
            });


        }
    };

    // Initializing searchViewModel and assigning navigation to it
    self.init = function () {
        self.searchViewModel.errors = ko.validation.group(self.searchViewModel);
        self.searchViewModel.init(self.navigation);
        //self.detailsViewModel.init(self.navigation);
    };
};