var _newAddressFormValidation = function () {

    $("#new-address-form").validate({
        errorClass: "error jquery-error",
        rules: {
            FirstName: {
                required: true,
                minlength: 2,
                maxlength: 100,
                regex: $.__nameRegex,
                normalizer: function (value) {
                    return $.trim(value);
                }
            },
            LastName: {
                required: true,
                minlength: 2,
                maxlength: 100,
                regex: $.__nameRegex,
                normalizer: function (value) {
                    return $.trim(value);
                }
            },
            CompanyName: {
                required: true,
            },
            'AddressToEdit.SmsAlertNumber': {
                required: true,
                minlength: 2,
                regex: $.__phoneRegex,
                normalizer: function(value) {
                    return $.trim(value);
                }
            },
            'AddressToEdit.Country': {
              required: true
            },
            'AddressToEdit.PostalCode': {
                required: true,
                minlength: 2,
            },
            'AddressToEdit.StreetLine1': {
              required: true
            },
            'AddressToEdit.City': {
              required: true
            },
            'AddressToEdit.StateOrProvince': {
              required: true
            }
        },
        messages: {
            FirstName: {
                required: "Please enter a first name.",
                minlength: "Please enter at least {0} characters.",
                maxlength: "Maximum character length: {0}.",
                regex: "Only letters and the following symbols: -,'.  are accepted."
            },
           LastName: {
                required: "Please enter a last name.",
                minlength: "Please enter at least {0} characters.",
                maxlength: "Maximum character length: {0}.",
                regex: "Only letters and the following symbols: -,'.  are accepted."
            },
            company: {
                required: "Please enter a company.",
            },
            'AddressToEdit.SmsAlertNumber': {
                required: "Please enter a phone number.",
                regex: "Only US numbers are allowed."
            },
            'AddressToEdit.Country': {
                required: "Please select a country.",
            },
            'AddressToEdit.PostalCode': {
                required: "Please enter a postal code.",
            },
            'AddressToEdit.StreetLine1': {
                required: "Please enter a address line.",
            },
            'AddressToEdit.City': {
                required: "Please select a city.",
            },
            'AddressToEdit.StateOrProvince': {
                required: "Please select a state.",
            },
        },
        submitHandler: function (form) {   
            form.submit();        
            return true;
        }
    });
}