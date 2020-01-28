$(document).ready(function () {
    //Shipping address form validations
    $("#existing-address-form").validate({
        rules: {
            existingAddress: {
                required: true
            }
        },
        messages: {
            existingAddress: {
                required: "Please, select an existing address."
            }
        },
        submitHandler: function (form) {
            //Do SOMETHING
            form.submit();
        }
    });
    $("#new-address-form").validate({
        rules: {
            firstName: {
                required: true,
                minlength: 2,
                maxlength: 100,
                regex: $.__nameRegex,
                normalizer: function (value) {
                    return $.trim(value);
                }
            },
            lastName: {
                required: true,
                minlength: 2,
                maxlength: 100,
                regex: $.__nameRegex,
                normalizer: function (value) {
                    return $.trim(value);
                }
            },
            company: {
                required: true
            },
            phoneNumber: {
                required: true,
                number: true
            },
            country: {
                required: true
            },
            zipCode: {
                required: true
            },
            addressLineOne: {
                required: true
            },
            city: {
                required: true
            },
            state: {
                required: true
            }
        },
        messages: {
            firstName: {
                required: "Please enter a first name.",
                minlength: "Please enter at least {0} characters.",
                maxlength: "Maximum character length: {0}.",
                regex: "Only letters and the following symbols: -,'.  are accepted."
            },
            lastName: {
                required: "Please enter a last name.",
                minlength: "Please enter at least {0} characters.",
                maxlength: "Maximum character length: {0}.",
                regex: "Only letters and the following symbols: -,'.  are accepted."
            },
            country: {
                required: "Please, select a country."
            },
            state: {
                required: "Please, select a state."
            }
        },
        submitHandler: function (form) {
            //Do SOMETHING
            form.submit();
        }
    });
    //Additional details form validations
    $("#additional-details-form").validate({
        rules: {
            projectName: {
                required: true
            }
        },
        submitHandler: function (form) {
            //Do SOMETHING
            form.submit();
        }
    });
});
