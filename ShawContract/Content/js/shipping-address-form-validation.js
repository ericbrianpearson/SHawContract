$(document).ready(function() {
  $("#new-address-form").validate({
    rules: {
      firstName: {
        required: true,
        minlength: 2
      },
      lastName: {
        required: true
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
    submitHandler: function(form) {
      alert("valid form submitted");
      return false;
    }
  });
});
