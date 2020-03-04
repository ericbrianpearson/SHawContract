(function () {
    var printReturnLabelPage = document.querySelector(".print-return-label");

    if (!printReturnLabelPage) {
        return;
    }

    $("#print-label-existing-address-form").validate({
        errorClass: "error jquery-error",
        rules: {
            existingAddress: {
                required: true
            },
        },
        messages: {
            existingAddress: {
                required: "Please select an existing address."
            }
        },
        submitHandler: function (form) {
            form.submit();
            return true;
        }
    });

    $("#print-label-new-address-form").validate({
    errorClass: "error jquery-error",
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
            required: true,
        },
        phoneNumber: {
            required: true,
            minlength: 2,
            regex: $.__phoneRegex,
            normalizer: function (value) {
                return $.trim(value);
            }
        },
        country: {
            required: true
        },
        zipCode: {
            required: true,
            minlength: 2,
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
        phoneNumber: {
            required: "Please enter a phone number.",
            regex: "Only US numbers are allowed."
        },
        country: {
            required: "Please select a country.",
        },
        zipCode: {
            required: "Please enter a postal code.",
        },
        addressLineOne: {
            required: "Please enter a address line.",
        },
        city: {
            required: "Please select a city.",
        },
        state: {
            required: "Please select a state.",
        },
    },
    submitHandler: function (form) {
        form.submit();
        return true;
    }
    });

}) ();