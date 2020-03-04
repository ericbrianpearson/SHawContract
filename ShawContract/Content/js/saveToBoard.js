$(document).ready(function () {

  var selectedColorPhoto = document.getElementById('save-to-board-selected-image');
  var colors = document.querySelectorAll('.save-to-board-color');
  var allColors = document.querySelectorAll('#addToBoardModal .color-wrapper');
  var arrowBtn = document.getElementById('colorArrowBtn');
  var newBoardField = document.querySelector('#addToBoardModal .new-board-name');
  var selectBoardDropDown = document.getElementById('selectBoardField');
  var selectBoardDropDownError = document.getElementById('boardNameDropdownError');
  var newBoardFieldInput = document.getElementById('newBoardName');
  var newBoardError = document.getElementById('newBoardError');
  var saveBtn = document.querySelector('.saving-to-board-form button[type="submit"]');

  var minimumAmountOfColorsToShow = 6;

  try {

    // ===================
    // ON PAGE LOAD
    // ===================
    resetArrowBtn();
    
    // ===================
    // ON IMAGE CLICK
    // ===================
    for (var i = 0; i < colors.length; i++) {
      colors[i].addEventListener('click', onColorClick);
    }


    // ===================
    // ON ARROW CLICK
    // ===================
    arrowBtn.addEventListener('click', showAllColors);


    // ===================
    // ON SELECT BOARD
    // ===================
    selectBoardDropDown.addEventListener('change', onSelectBoardChange);



    // ===================
    // ON NAME BOARD FIELD CHANGE
    // ===================
    newBoardFieldInput.addEventListener('change', onNameBoardFieldInputChange);


    // ===================
    // ON MODAL CLOSE
    // ===================
    $('#addToBoardModal').on('hidden.bs.modal', function () {
      resetArrowBtn();
      resetSelectBoardDropdown();
      resetNewBoardField();
      saveBtn.removeAttribute('disabled');
    });


    // ===================
    // ON MODAL OPEN
    // ===================
    var placeholderText = null;

    $('#addToBoardModal').on('show.bs.modal', function (e) {
      try {
        setColorOnModalOpen();
        var placeholder = document.querySelector('#selectBoardField + button.select-style .filter-option-inner-inner');
        placeholderText = placeholder.innerText;
      } catch (error) {
        console.warn('Save to board functionality not yet loaded');
      }
    });
    
  } catch (error) {
    
  }


  function onColorClick(event) {
    var elem = event.currentTarget;
    setSelectedImage(elem);
  }

  function setColorOnModalOpen() {
    var index = document.querySelector('#product_color_picker .btn-choose-color.active').getAttribute('data-index');
    var elem = document.querySelector('#addToBoardModal .save-to-board-color[data-color="' + index + '"]');
    setSelectedImage(elem);

    if (index-1 > minimumAmountOfColorsToShow) {
      showAllColors();
    }
  }

  function setSelectedImage(elem) {
    var src = getSrc(elem);
    setLargeImageSrc(src);
    setSelectedAttributes(elem);
  }

  function getSrc(elem) {
    return elem.getAttribute('src');
  }

  function setLargeImageSrc(url) {
    selectedColorPhoto.setAttribute('src', url);
  }

  function setSelectedAttributes(elem) {
    for (var i = 0; i < colors.length; i++) {
      colors[i].parentElement.removeAttribute('data-selected');
    }
    elem.parentElement.setAttribute('data-selected', "");
    selectedColorPhoto.setAttribute('data-product', elem.getAttribute('data-product'));
    selectedColorPhoto.setAttribute('data-color', elem.getAttribute('data-color'));
  }

  function showAllColors() {
    arrowBtn.classList.add('d-none');

    for (var i = 0; i < allColors.length; i++) {
      allColors[i].classList.add('show');
    }

    setTimeout(function () {
      for (var i = 0; i < allColors.length; i++) {
        allColors[i].classList.add('animate');
      }
    }, 10);
  }

  function onSelectBoardChange(e) {
    if (e.currentTarget.value !== '') {
      selectBoardDropDownError.classList.remove('show', 'animate');
    }

    if (e.currentTarget.value === 'new board') {
      newBoardSelected();
    }
    else {
      hideNewBoardField();
    }
  }

  function newBoardSelected () {
    newBoardField.classList.add('show');
    setTimeout(function() {
      newBoardField.classList.add('animate');
    }, 10);
  }

  function hideNewBoardField() {
    newBoardField.classList.remove('animate', 'show');
  }


  function onNameBoardFieldInputChange(e) {
    if (e.currentTarget.value !== '') {
      newBoardError.classList.remove('show', 'animate');
    }
  }

  function resetArrowBtn() {

    if (!allColors || !arrowBtn) {
      return;
    }

    arrowBtn.classList.remove('d-none');

    for (var i = minimumAmountOfColorsToShow; i < allColors.length; i++) {
      allColors[i].classList.remove('show', 'animate');
    }
  }

  function resetSelectBoardDropdown() {
    var dropdown = document.querySelector('#selectBoardField + button.select-style');
    var placeholder = dropdown.querySelector('.filter-option-inner-inner');

    dropdown.classList.add('bs-placeholder');
    placeholder.innerText = placeholderText;
    hideNewBoardField();
    selectBoardDropDown.value = '';
  }

  function resetNewBoardField() {
    newBoardFieldInput.value = '';
    newBoardError.classList.remove('animate', 'show');
  }
});

// ===================
// ON SAVE TO BOARD CLICK
// ===================
var __savedToBoard = function () {
  // get the add to board sections
  var selectionWindow = document.querySelector('#addToBoardModal .saving-to-board-form');
  var heartWindow = document.querySelector('#addToBoardModal .saved-to-board');

  // hide the selection window and display the heart icon window
  selectionWindow.classList.add('d-none');
  heartWindow.classList.add('show');

  // animate the heart icon window and fade modal
  setTimeout(function () {
    heartWindow.classList.add('animate');
    fadeModal();
  }, 10);

  //fade the modal after a small amount of time and async reset the Save to Board modal
  // Async because there is a fade animation
  function fadeModal() {
    setTimeout(function () {
      $('#addToBoardModal').modal('hide');
      resetSaveToBoard();
    }, 1600);
  }

  function resetSaveToBoard() {
    setTimeout(function () {
      selectionWindow.classList.remove('d-none');
      heartWindow.classList.remove('show', 'animate');
    }, 600);
  }
};