(function () {
    var checkoutPage = document.querySelector("main.checkout");

    if (!checkoutPage) {
        return;
    }

    try {
        // Sections
        var shippingAddressSection = document.getElementById(
            "shipping-address-wrapper"
        );
        var additionalDetailsSection = document.getElementById(
            "additional-details-wrapper"
        );
        var finalizeSection = document.getElementById("finalize-wrapper");
        // Buttons
        var existingShippingAddressContinueBtn = document.getElementById(
            "continue-0-btn"
        );
        var newShippingAddressContinueBtn = document.getElementById(
            "continue-1-btn"
        );
        var additionalDetailsContinueBtn = document.getElementById(
            "continue-2-btn"
        );
        var backToShippingAddressBtn = document.getElementById(
            "back-to-shipping-address-btn"
        );
        var backToAdditionalDetailsBtn = document.getElementById(
            "back-to-additional-details-btn"
        );
        // Tabs
        var shippingAddressTab = document.getElementById("shipping-address-tab");
        var addtitionalDetailsTab = document.getElementById(
            "additional-details-tab"
        );
        var finalizeTab = document.getElementById("finalize-tab");

        // Remove validation error for all selectors on change
        $(".selectpicker")
            .selectpicker()
            .change(function () {
                $(this).valid();
            });

        // Initialize Jquery Validator
        $("#checkout-form").validate({
            errorClass: "error jquery-error",
            // onfocusout: true,
            // onChange: true,
            // onkeyup: true
        });

        // Switch between the checkout views
        function goToAdditionalDetailsSection() {
            shippingAddressSection.classList.remove("show");
            additionalDetailsSection.classList.add("show");
            shippingAddressTab.classList.remove("is-active");
            addtitionalDetailsTab.classList.add("is-active");
            window.scrollTo(0, 55);

            setTimeout(function () {
                shippingAddressSection.classList.remove("animate");
                additionalDetailsSection.classList.add("animate");
            }, 0);
        }

        function goToFinalizeAndSubmitSection() {
            additionalDetailsSection.classList.remove("show");
            finalizeSection.classList.add("show");
            addtitionalDetailsTab.classList.remove("is-active");
            finalizeTab.classList.add("is-active");
            window.scrollTo(0, 55);

            setTimeout(function () {
                additionalDetailsSection.classList.remove("animate");
                finalizeSection.classList.add("animate");
            }, 0);
        }

        function backToShippingAddressSection(e) {
            e.preventDefault();
            additionalDetailsSection.classList.remove("show");
            shippingAddressSection.classList.add("show");
            addtitionalDetailsTab.classList.remove("is-active");
            shippingAddressTab.classList.add("is-active");
            window.scrollTo(0, 55);

            setTimeout(function () {
                additionalDetailsSection.classList.remove("animate");
                shippingAddressSection.classList.add("animate");
            }, 0);
        }

        function backToAdditionalDetailsSection(e) {
            e.preventDefault();
            finalizeSection.classList.remove("show");
            additionalDetailsSection.classList.add("show");
            finalizeTab.classList.remove("is-active");
            addtitionalDetailsTab.classList.add("is-active");
            window.scrollTo(0, 55);

            setTimeout(function () {
                finalizeSection.classList.remove("animate");
                additionalDetailsSection.classList.add("animate");
            }, 0);
        }
        // Validate Shipping address forms
        function validateExistingShippingAddress(e) {
            e.preventDefault();

            var requiredFields = $('[name="existingAddress"]');

            requiredFields.each(function () {
                $(this).rules("add", {
                    required: true,
                    messages: {
                        required: "Please, select an existing address."
                    }
                });
            });

            if (requiredFields.valid()) {
                e.preventDefault();
                goToAdditionalDetailsSection();
            }
        }

        function validateNewShippingAddress(e) {
            var requiredFields = $(
                '[name="firstName"], [name="lastName"], [name="company"], [name="country"], [name="zipCode"], [name="addressLineOne"], [name="city"], [name="state"]'
            );
            var firstGroupfieldNames = ["first name", "last name"];
            var secondGroupfieldNames = [
                "a company",
                "a country",
                "a zip/ postal code",
                "an address line 1",
                "a city",
                "a state"
            ];

            $('[name="firstName"], [name="lastName"]').each(function (i) {
                $(this).rules("add", {
                    required: true,
                    minlength: 2,
                    maxlength: 100,
                    regex: $.__nameRegex,
                    normalizer: function (value) {
                        return $.trim(value);
                    },
                    messages: {
                        required: `Please enter a ${firstGroupfieldNames[i]}`,
                        minlength: "Please enter at least {0} characters.",
                        maxlength: "Maximum character length: {0}.",
                        regex: "Only letters and the following symbols: -,'.  are accepted."
                    }
                });
            });

            $(
                '[name="company"], [name="country"], [name="zipCode"], [name="addressLineOne"], [name="city"], [name="state"]'
            ).each(function (i) {
                $(this).rules("add", {
                    required: true,
                    messages: {
                        required: `Please enter ${secondGroupfieldNames[i]}`
                    }
                });
            });

            $('[name="phoneNumber"]').each(function () {
                $(this).rules("add", {
                    regex: $.__phoneRegex,
                    normalizer: function (value) {
                        return $.trim(value);
                    },
                    messages: {
                        regex: "Only US numbers are allowed."
                    }
                });
            });

            if (requiredFields.valid()) {
                goToAdditionalDetailsSection();
                e.preventDefault();
            }
        }

        // Validate Additional Details
        function validateAdditionalDetails(e) {
            e.preventDefault();

            var requiredFields = $('[name="projectName"]');

            requiredFields.each(function () {
                $(this).rules("add", {
                    required: true,
                    maxlength: 50
                });
            });

            if (requiredFields.valid()) {
                goToFinalizeAndSubmitSection();
            }
        }

        // Listen for events
        backToShippingAddressBtn.addEventListener(
            "click",
            backToShippingAddressSection
        );

        backToAdditionalDetailsBtn.addEventListener(
            "click",
            backToAdditionalDetailsSection
        );

        existingShippingAddressContinueBtn.addEventListener(
            "click",
            validateExistingShippingAddress
        );

        newShippingAddressContinueBtn.addEventListener(
            "click",
            validateNewShippingAddress
        );

        additionalDetailsContinueBtn.addEventListener(
            "click",
            validateAdditionalDetails
        );

        $("#submit-btn").click(function (e) {
            // Do something on submit
        });
    } catch (e) { }
})();
