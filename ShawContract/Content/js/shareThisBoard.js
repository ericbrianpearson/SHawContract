(function () {
    try {
        var shareBtn = document.getElementById('shareThisBoard');

    __addSuccessNotificationToElement(shareBtn, 'Product Board Shared', 'Board URL copied to your clipboard');
        shareBtn.addEventListener('click', function () {
            var url = document.getElementById('board-url').getAttribute("data-url-board");
            __copyToClipboard(url);
    })
    } catch (error) {}
})();