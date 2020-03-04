var __addSuccessNotificationToElement = (function () {
  if (!toastr) {
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

  return function (elem, title, description, options) {
    if (!elem) {
      return; 
    }

    if (elem.length) {
      for (var i=0; i<elem.length; i++) {
        elem[i].addEventListener('click', function() {
          toastr.success(description, title, options);
        })
      }
    } else {
      elem.addEventListener('click', function () {
        toastr.success(description, title, options);
      });
    }
  }
})();