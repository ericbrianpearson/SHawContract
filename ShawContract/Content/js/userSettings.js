(function () {
    var userSettingsPage = document.querySelector("main.account-profile .user-settings");

    if (!userSettingsPage) {
        return;
    }

    // Form Validations
    $(document).ready(function () {
        $("#personal-information-form").validate({
            errorClass: "error jquery-error",
            rules: {
                "Data.FirstName": {
                    required: true,
                    minlength: 2,
                    maxlength: 100,
                    regex: $.__nameRegex,
                    normalizer: function (value) {
                        return $.trim(value);
                    }
                },
                "Data.LastName": {
                    required: true,
                    minlength: 2,
                    maxlength: 100,
                    regex: $.__nameRegex,
                    normalizer: function (value) {
                        return $.trim(value);
                    }
                },
                "Data.Email": {
                    required: true,
                    email: true,
                    normalizer: function (value) {
                        return $.trim(value);
                    }
                },
                password: {
                    required: true
                },
                "Data.CellPhone": {
                    required: true,
                    // regex: $.__phoneRegex,
                    // normalizer: function(value) {
                    //     return $.trim(value);
                    // }
                }
            },
            messages: {
                "Data.FirstName": {
                    required: "Please enter a first name.",
                    minlength: "Please enter at least {0} characters.",
                    maxlength: "Maximum character length: {0}.",
                    regex: "Only letters and the following symbols: -,'.  are accepted."
                },
                "Data.LastName": {
                    required: "Please enter a last name.",
                    minlength: "Please enter at least {0} characters.",
                    maxlength: "Maximum character length: {0}.",
                    regex: "Only letters and the following symbols: -,'.  are accepted."
                },
                "Data.Email": {
                    required: "Please enter an email address.",
                    email: "Invalid email address."
                },
                "Data.CellPhone": {
                    required: "Please enter a phone number."
                //   regex: "Only US numbers are allowed"
                }
            },
            submitHandler: function (form) {
                form.submit();
                return true;
            }
        });

        $("#company-information-form").validate({
            errorClass: "error jquery-error",
            rules: {
                "Data.CompanyName": {
                    required: true
                },
                "Data.JobTitle": {
                    required: true
                },
                "Data.Industry": {
                    required: true
                },
                password: {
                    required: true
                },
                // "Data.WorkPhone": {
                //   regex: $.__phoneRegex,
                //   normalizer: function(value) {
                //     return $.trim(value);
                //   }
                // }
            },
            messages: {
                "Data.CompanyName": {
                    required: "Please enter a company name."
                },
                "Data.JobTitle": {
                    required: "Please select a job title."
                },
                "Data.Industry": {
                    required: "Please enter an industry."
                },
                password: {
                    required: "Please enter a password."
                },
                "Data.WorkPhone": {
                    // regex: "Invalid number."
                }
            },

            submitHandler: function (form) {
                form.submit();
                return true;
            }
        });

        $("#communication-form").validate({
            errorClass: "error jquery-error",
            rules: {
                "Data.Language": {
                    required: true
                }
            },
            messages: {
                "Data.Language": {
                    required: "This field is required."
                }
            },
            submitHandler: function (form) {
                form.submit();
                return true;
            }
        });
    });

    try {
        var togglePasswordBtn = document.getElementById("toggle-password-btn");

        // Show and hide password
        function togglePassword() {
            var input = document.getElementById("password");
            var btn = document.querySelector(".show-btn");
            var inputType;
            if (!input) {
                return false;
            }

            inputType = input.getAttribute("type");

            if (input.value !== "" && btn) {
                if (inputType === "password") {
                    input.setAttribute("type", "text");
                    btn.innerHTML = "hide";
                } else {
                    input.setAttribute("type", "password");
                    btn.innerHTML = "shaw";
                }
            }
        }

        // Remove validation error for all selectors on change
        // $(".selectpicker")
        //   .selectpicker()
        //   .change(function() {
        //     $(this).valid();
        //   });

        togglePasswordBtn.addEventListener("click", togglePassword);

        // Input mask
        $("#personal-phone-number").mask("(999) 999-9999");
        $("#work-number").mask("(999) 999-9999");
    } catch (e) {
        console.warn(e);
    }
})();
