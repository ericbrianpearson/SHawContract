function __checkSampleCount(successCallback) {
    return function (event) {
        var productQuantities = document.querySelectorAll('.checkout-product-card select');
        var errorBlock = document.querySelector('.error.error-message');
        var totalQuantity = 0;
        var MaxQuantity = 30;

        //defensive
        if (!productQuantities || !errorBlock) {
            return;
        }

        // loop over them to calc the total
        for (var i = 0; i < productQuantities.length; i++) {
            totalQuantity += parseInt(productQuantities[i].value);
        }

        // if higher than the max -> show error
        if (totalQuantity > MaxQuantity) {
            event.preventDefault();
            errorBlock.classList.add('show');
            setTimeout(function () {
                errorBlock.classList.add('animate');
            }, 0);
        } else {
            // send request for checkout
            successCallback();
        }
    }
};