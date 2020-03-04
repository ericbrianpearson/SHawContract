(function () {
    var productPage = document.querySelector("main.product");

    if (!productPage) {
        return;
    }
    
    //ADD TO CART
    var addToCartBtn = document.getElementById("addToCartBtn");

    var model = JSON.parse($("#data").val());
    var addProductLink = $("#addProductLink").val();
    var reloadCart = $("#reloadCart").val();

    //IMAGE CHANGES
    var roomScenes = document.getElementsByClassName("room-scene");
    var installationMethods = document.getElementsByClassName("installation-method");
    var selectColorBtns = document.getElementsByClassName("select-color-btn");
    var imageSize = model.SizeForImage;
    var styleNumber = model.Product.StyleNumber;
    var url = location.protocol + "//" + location.host + location.pathname;

    // ON SAVE TO BOARD BUTTON CLICK
    var saveBtn = document.querySelector('.saving-to-board-form button[type="submit"]');
    var selectBoardDropDown = document.getElementById("selectBoardField");
    var selectBoardDropDownError = document.getElementById("boardNameDropdownError");
    var newBoardFieldInput = document.getElementById("newBoardName");
    var newBoardError = document.getElementById("newBoardError");
    var selectedColorPhoto = document.getElementById("save-to-board-selected-image");
    var saveToBoardLink = $("#saveToBoardLink").val();
    var refreshBoardsLink = $("#refreshBoardsLink").val();
    var addItemToExsistingBoard = $("#addItemToExsistingBoard").val();

    // FOR IMAGE ROTATION
    var counter = 0;
    var rotateImgBtn = document.getElementById("rotate-img-btn");
    var singleTileImg = document.getElementById("single-tile-img");

    function onAddToCart() {
        var dataToPost = { colorId: model.SelectedColor.SKUID };
        $.post(addProductLink, dataToPost, function () {
            $('#cart').load(reloadCart);
        });
    }

    function onSaveBtnClick() {
        var colorIndex = selectedColorPhoto.getAttribute('data-color');
        var color = model.Product.Colors[colorIndex];
        var productBoardItem = {
            StyleName: model.Product.StyleName,
            StyleNumber: model.Product.StyleNumber,
            ColorName: color.ColorName,
            ColorNumber: color.ColorNumber,
            ImageUrl: color.ImageUrl
        };

        if (selectBoardDropDown.value === 'new board') {
            newBoardRequest(newBoardFieldInput.value, productBoardItem);
        }
        else {
            existingBoardRequest(selectBoardDropDown.value, productBoardItem);
        }
    }

    function newBoardRequest(boardName, productBoardItem) {
        // check new board field
        if (boardName === '') {
            displayNewBoardNameError();
        }
        else {
            saveBtn.setAttribute('disabled', '');
            var dataToPost = { boardName: boardName, userId: model.UserId, productBoardItem: productBoardItem };
            $.post(saveToBoardLink, dataToPost, function (response) {
                __savedToBoard();
                addNewBoardToDropdown(response.id, boardName);
                $('#boardDropDownContent').load(refreshBoardsLink);
            });
        }
    }


    function existingBoardRequest(boardId, productBoardItem) {
        if (!boardId || !productBoardItem) {
            displayDropDownError();
        }
        else {
            var dataToPost = { boardId: boardId, productBoardItem: productBoardItem };

            saveBtn.setAttribute('disabled', '');

            $.post(addItemToExsistingBoard, dataToPost, function () {
                __savedToBoard();
                $('#boardDropDownContent').load(refreshBoardsLink);
            });
        }
    }

    function addNewBoardToDropdown(id, boardName) {
        var option = document.createElement('option');
        option.setAttribute('value', id);
        option.textContent = boardName;
        selectBoardDropDown.append(option);
        $(selectBoardDropDown).selectpicker('refresh');
    }


    function displayNewBoardNameError() {
        newBoardError.classList.add("show");

        setTimeout(function () {
            newBoardError.classList.add("animate");
        }, 15);
    }

    function displayDropDownError() {
        selectBoardDropDownError.classList.add("show");

        setTimeout(function () {
            selectBoardDropDownError.classList.add("animate");
        }, 15);
    }

    function rotateImg(img) {
        counter++;
        if (counter > 4) {
            counter = 1;
        }

        switch (counter) {
            case 1:
                img.classList.add("rotate-" + 90);
                img.classList.remove("rotate-360");
                break;
            case 2:
                img.classList.add("rotate-" + 180);
                img.classList.remove("rotate-90");
                break;
            case 3:
                img.classList.add("rotate-" + 270);
                img.classList.remove("rotate-180");
                break;
            case 4:
                img.classList.add("rotate-" + 360);
                img.classList.remove("rotate-270");
                break;
        }
    }

    function roomSceneSelected(roomIndex) {
        var room = model.Product.KontentData.AvailableRoomScenes[roomIndex];
        model.SelectedRoomScene = room.Id;

        var roomSceneUrl = "http://scrl.img.trykcloudstatic.com/designs/" + styleNumber + "/colors/" + model.SelectedColor.ColorNumber + "/rooms/" + model.SelectedRoomScene + "/installs/" + model.SelectedInstallParameter + "?pixels=500";
        document.getElementById("roomScene").src = roomSceneUrl;
        document.getElementById("roomSceneSmall").src = roomSceneUrl;
        document.getElementById("roomSceneDownload").setAttribute("data-download", roomSceneUrl);
    }

    function installationMethodSelected(item) {

        var parameter = model.InstallationParametersMapping[item.toLowerCase() + imageSize];

        model.SelectedInstallParameter = parameter;
        var roomSceneUrl = "http://scrl.img.trykcloudstatic.com/designs/" + styleNumber + "/colors/" + model.SelectedColor.ColorNumber + "/rooms/" + model.SelectedRoomScene + "/installs/" + model.SelectedInstallParameter + "?pixels=500";
        var installImageUrl = "http://scrl.img.trykcloudstatic.com/designs/" + styleNumber + "/colors/" + model.SelectedColor.ColorNumber + "/installs/" + model.SelectedInstallParameter + "?physWidth=9ft&physHeight=6ft&pixels=500";

        document.getElementById("roomScene").src = roomSceneUrl;
        document.getElementById("roomSceneSmall").src = roomSceneUrl;
        document.getElementById("roomSceneDownload").setAttribute("data-download", roomSceneUrl);

        document.getElementById("installImage").src = installImageUrl;
        document.getElementById("installImageSmall").src = installImageUrl;
        document.getElementById("installImageDownload").setAttribute("data-download", installImageUrl);
    }

    function selectColor(colorIndex) {
        var oldActive = document.getElementsByClassName("btn btn-choose-color active");
        oldActive[0].classList.remove("active");

        var newActiveColor = document.getElementById("chooseColor" + colorIndex);
        newActiveColor.classList.add("active");

        model.SelectedColor = model.Product.Colors[colorIndex];

        // change url
        history.pushState(null, null, url + "?colorNumber=" + model.SelectedColor.ColorNumber);

        var roomSceneUrl = "http://scrl.img.trykcloudstatic.com/designs/" + styleNumber + "/colors/" + model.SelectedColor.ColorNumber + "/rooms/" + model.SelectedRoomScene + "/installs/" + model.SelectedInstallParameter + "?pixels=500";
        var installImageUrl = "http://scrl.img.trykcloudstatic.com/designs/" + styleNumber + "/colors/" + model.SelectedColor.ColorNumber + "/installs/" + model.SelectedInstallParameter + "?physWidth=9ft&physHeight=6ft&pixels=500";
        var tileImageUrl = "http://scrl.img.trykcloudstatic.com/designs/" + styleNumber + "/colors/" + model.SelectedColor.ColorNumber + "/tiles/" + imageSize + "/1?pixels=500";


        document.getElementById("roomScene").src = roomSceneUrl;
        document.getElementById("roomSceneSmall").src = roomSceneUrl;
        document.getElementById("roomSceneDownload").setAttribute("data-download", roomSceneUrl);

        document.getElementById("installImage").src = installImageUrl;
        document.getElementById("installImageSmall").src = installImageUrl;
        document.getElementById("installImageDownload").setAttribute("data-download", installImageUrl);


        document.getElementById("single-tile-img").src = tileImageUrl;
        document.getElementById("tileImageSmall").src = tileImageUrl;
        document.getElementById("tileImageDownload").setAttribute("data-download", tileImageUrl);

        document.getElementById("selectedColor").innerHTML = model.SelectedColor.ColorName + " " + model.SelectedColor.ColorNumber + " ";
    }

    $("#addToCartModal").on("shown.bs.modal", __addedToCart);

    saveBtn.addEventListener("click", onSaveBtnClick);

    addToCartBtn.addEventListener("click", function () {
        onAddToCart();
    });

    rotateImgBtn.addEventListener("click", function () {
        rotateImg(singleTileImg);
    });

    for (var i = 0; i < roomScenes.length; i++) {

        roomScenes[i].addEventListener("click", function () {
            var roomIndex = this.getAttribute("data-id");
            roomSceneSelected(roomIndex);
        });
    }

    for (var j = 0; j < installationMethods.length; j++) {
        installationMethods[j].addEventListener("click", function () {
            var item = this.getAttribute("data-item");
            installationMethodSelected(item);
        });
    }

    for (var k = 0; k < selectColorBtns.length; k++) {
        selectColorBtns[k].addEventListener("click", function () {
            var index = this.getAttribute("data-index");
            selectColor(index);
        });
    }
})();
