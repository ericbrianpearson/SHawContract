(function () {

  onInit();

  function onInit() {
    searchBar();
    validation();
  }

  function searchBar() {
    var minCharLen = 3;
    var searchResultsWrapper = document.querySelector('.search-results-wrapper');
    var searchInput = document.getElementById('searchProducts');

    if (!!searchResultsWrapper && !!searchInput) {

      function onInputChange(event) {
        if (searchInput.value && searchInput.value.length >= minCharLen) {
          showResults();
        } else {
          hideResults();
        }
      }

      function onFocusBack() {
        if (searchInput.value && searchInput.value.length >= minCharLen) {
          showResults();
        }
      }

      function hideResults() {
        searchResultsWrapper.classList.remove('show');
      }

      function showResults() {
        searchResultsWrapper.classList.add('show');
      }

      searchInput.addEventListener('keyup', onInputChange);
      searchInput.addEventListener('blur', hideResults);
      searchInput.addEventListener('focus', onFocusBack);
    }
  }

  function validation() {
    var introParagraph = document.getElementById('introParagraph');
    var form = document.getElementById('edit-board-form');

    if (!!introParagraph && !!form) {
      $(form).validate({
        errorClass: "error jquery-error",
        rules: {
          "Notes": {
            // required: true,
            maxlength: 500,
          }
        },
        messages: {
          "Notes": {
            // required: "This field is required.",
            maxlength: "Maximum of {0} characters."
          }
        },
        submitHandler: function (form) {
          form.submit();
          return true;
      }
      });
    }
  }
})();