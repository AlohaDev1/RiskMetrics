ko.validation.rules.pattern.message = 'Invalid.';


ko.validation.configure({
    registerExtenders: true,
    messagesOnModified: true,
    insertMessages: true,
    parseInputAttributes: true,
    messageTemplate: null
});


var loginViewModel = {
    userName: ko.observable().extend({ required: "Please enter a user name" }),
    password: ko.observable().extend({ required: "Please enter a password" }),

    submit: function () {
        if (loginViewModel.errors().length > 0) {
            loginViewModel.errors.showAllMessages();
        } else {
            return true;
        }
    }
};

loginViewModel.errors = ko.validation.group(loginViewModel);