(function() {
  var minCharLen = 3;
  var searchResultsWrapper = document.querySelector('.search-results-wrapper');
  var searchInput = document.getElementById('searchProducts');

  if(!!searchResultsWrapper && !!searchInput) {

    function hideResults() {
      searchResultsWrapper.classList.remove('show');
    }

    function showResults() {
      searchResultsWrapper.classList.add('show');
    }

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

    searchInput.addEventListener('keyup', onInputChange);
    searchInput.addEventListener('blur', hideResults);
    searchInput.addEventListener('focus', onFocusBack);
  }
})();