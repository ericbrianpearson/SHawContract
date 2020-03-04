(function setLocalTime() {
    var timestamps = document.querySelectorAll('.server-timestamp');
    if (!timestamps) {
        return;
    }

    for (var i = 0; i < timestamps.length; i++) {
        var element = timestamps[i];
        var date = new Date(element.textContent.trim());
        var localFormatedDate = date.toLocaleString();
        element.textContent = localFormatedDate;
    }
})();