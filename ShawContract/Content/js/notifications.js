(function () {
  if (!toastr || !window) {
    return;
  }

  toastr.options = {
    "closeButton": false,
    "debug": false,
    "newestOnTop": true,
    "progressBar": false,
    "positionClass": "toast-top-right",
    "preventDuplicates": false,
    "onclick": null,
    "showDuration": "300",
    "hideDuration": "1000",
    "timeOut": "5000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
  };

  function addSuccessNotificationToElement(elm, title, description, options) {
    if (!!elm) {
      elm.addEventListener('click', function () {
        toastr.success(description, title, options);
      });
    }
  }

  var shareBtn = document.querySelector('.copy-to-clipboard');
  addSuccessNotificationToElement(shareBtn, 'Product Board Shared', 'Board URL copied to your clipboard');
})();