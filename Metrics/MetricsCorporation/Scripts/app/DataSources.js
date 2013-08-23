// Define application Descriptionspace

var MetricsCorporationApp = window.MetricsCorporationApp = {};

// Define class with static variables like sic codes or monthes
// Also here stord url's  for webapis
MetricsCorporationApp.DataSources = function () {
    var self = this;


    //Url's for weabpis

    self.baseUri = '/api/companymodel';
    self.countyUri = '/api/county/';
    self.employeeSizeUri = '/api/employeesize';
    self.sicCodeUri = '/api/siccode';
    self.topSearchesUri = '/api/topsearches';
    self.combUri = '/api/comb';
    self.downloadUrl = '/Home/Download/';
    self.downloadClientUrl = '/Home/DownloadClient/';
    self.linkedInCompanyIdUrl = 'http://www.linkedin.com/ta/federator?types=company&query=';
    self.contactsUri = '/api/contacts';


    //Selectors
    self.linkedInDivId = '#linkedInProfile';
    self.treeViewSicCodesSelector = '#treeview-sic-code';


    //Static datasources

    self.SicCodes = [{
        id: '0001',
        text: "01 AGRICULTURAL PRODUCTION CROPS",
        items: [
            {
                id: '0011',
                text: "011 CASH GRAINS",
                items: [
                    { id: '0111', text: "0111 WHEAT" },
                    { id: '0112', text: "0112 RICE" },
                    { id: '0115', text: "0115 CORN" },
                    { id: '0116', text: "0116 SOYBEANS" },
                    { id: '0119', text: "0119 CASH GRAINS, NOT ELSEWHERE CLASSIFIED" }
                ]
            },
            {
                id: '0013',
                text: "013 FIELD CROPS, EXCEPT CASH GRAINS",
                items: [
                    { id: '0131', text: "0131 COTTON" },
                    { id: '0132', text: "0132 TOBACCO" },
                    { id: '0133', text: "0133 SUGARCANE AND SUGAR BEETS" },
                    { id: '0134', text: "0134 IRISH POTATOES" },
                    { id: '0139', text: "0139 FIELD CROPS, EXCEPT CASH GRAINS, NOT ELSEWHERE CLASSIFIED" }
                ]
            }
        ]
    },
        {
            id: '0002',
            text: "02 AGRICULTURAL PRODUCTION LIVESTOCK",
            items: [
                {
                    id: '0021',
                    text: "021 LIVESTOCK, EXCEPT DAIRY AND POULTRY",
                    items: [
                        { id: '0211', text: "0211 BEEF CATTLE FEEDLOTS" },
                        { id: '0212', text: "0212 BEEF CATTLE, EXCEPT FEEDLOTS" },
                        { id: '0213', text: "0213 HOGS" },
                        { id: '0214', text: "0214 SHEEP AND GOATS" },
                        { id: '0219', text: "0219 GENERAL LIVESTOCK, EXCEPT DAIRY AND POULTRY" }
                    ]
                },
                {
                    id: '024',
                    text: "024 DAIRY FARMS",
                    items: [
                        { id: '0241', text: "0241 DAIRY FARMS" }
                    ]
                }
            ]
        },
        {
            id: '0007',
            text: "07 AGRICULTURAL SERVICES",
            items: [
                {
                    id: '0071',
                    text: "071 SOIL PREPARATION SERVICES",
                    items: [
                        { id: '0711', text: "0711 SOIL PREPARATION SERICES" }
                    ]
                },
                {
                    id: '0072',
                    text: "072 CROP SERVICES",
                    items: [
                        { id: '0721', text: "0721 CROP PLANTING, CULTIVATING, AND PROTECTING" },
                        { id: '0722', text: "0722 CROP HARVESTING, PRIMARILY BY MACHINE" },
                        { id: '0723', text: "0723 CROP PREPARATION SERVICES FOR MARKET, EXCEPT COTTON GINNING" },
                        { id: '0724', text: "0724 COTTON GINNING" }
                    ]
                }
            ]
        }
    ];


    self.Monthes = [
        { id: "", name: "Select" },
        { id: "01", name: "January" },
        { id: "02", name: "February" },
        { id: "03", name: "March" },
        { id: "04", name: "April" },
        { id: "05", name: "May" },
        { id: "06", name: "June" },
        { id: "07", name: "July" },
        { id: "08", name: "August" },
        { id: "09", name: "September" },
        { id: "10", name: "October" },
        { id: "11", name: "November" },
        { id: "12", name: "December" }
    ];
};


