var __addedToCart = function () {
    var cartIconWindow = document.querySelector('#addToCartModal .added-to-cart');
    try {
        cartIconWindow.classList.add('show');

        setTimeout(function () {
            cartIconWindow.classList.add('animate');
            fadeModal();
        }, 10);


        function fadeModal() {
            setTimeout(function () {
                $('#addToCartModal').modal('hide');
                resetModal();
            }, 1600);
        }

        function resetModal() {
            setTimeout(function () {
                cartIconWindow.classList.remove('show', 'animate');
            }, 600);
        }
    } catch (error) { }
};