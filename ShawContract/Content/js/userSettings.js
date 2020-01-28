(function () {
    var userSettingsPage = document.querySelector("main.user-settings");

    if (!userSettingsPage) {
        return;
    }

    // Form Validations
    $(document).ready(function () {
        $("#personal-information-form").validate({
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
                email: {
                    required: true,
                    email: true,
                    normalizer: function (value) {
                        return $.trim(value);
                    }
                },
                password: {
                    required: true
                }
                // phoneNumber: {
                //   regex: $.__phoneRegex,
                //   normalizer: function(value) {
                //     return $.trim(value);
                //   }
                // }
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
                email: {
                    required: "Please enter an email address.",
                    email: "Invalid email address."
                }
                // phoneNumber: {
                //   regex: "Only US numbers are allowed"
                // }
            },
            submitHandler: function (form) {
                alert("valid form submitted");
                return false;
            }
        });

        $("#company-information-form").validate({
            rules: {
                companyName: {
                    required: true
                },
                roleTitle: {
                    required: true
                },
                industry: {
                    required: true
                },
                password: {
                    required: true
                }
                // workNumber: {
                //   regex: $.__phoneRegex,
                //   normalizer: function(value) {
                //     return $.trim(value);
                //   }
                // }
            },
            messages: {
                roleTitle: {
                    required: "This field is required."
                },
                industry: {
                    required: "This field is required."
                }
                // workNumber: {
                //   regex: "Only US numbers are allowed."
                // }
            },

            submitHandler: function (form) {
                alert("valid form submitted");
                return false;
            }
        });

        $("#communication-form").validate({
            rules: {
                language: {
                    required: true
                }
            },
            messages: {
                language: {
                    required: "This field is required"
                }
            },
            submitHandler: function (form) {
                alert("valid form submitted");
                return false;
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
