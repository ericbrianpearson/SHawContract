var __addLineClamps = (function () {

    //Breakpoints 
    var mobileBreakpoint = 576;
    var tabletBreakpoint = 768;
    var laptopBreakpoint = 992;
    var desktopBreakpoint = 1200;

    function addRemoveLineClamps(cards, breakpoint, lines) {
        return function () {
            if (lines === undefined) {
                lines = 'auto';
            }

            if (breakpoint === undefined) {
                breakpoint = 0;
            }

            try {
                if (window.innerWidth >= breakpoint) {
                    for (var i = 0; i < cards.length; i++) {
                        $clamp(cards[i], { clamp: lines });
                    }
                } else {
                    for (var i = 0; i < cards.length; i++) {
                        cards[i].setAttribute('style', '');
                    }
                }
            }
            catch (e) {
                console.warn(e);
            }
        }
    }

    // higher order function
    var addLineClamps = function (selector, breakpoint, lines) {
        var paragraphs = document.querySelectorAll(selector);

        if (paragraphs.length === 0) {
            return;
        }

        var clampFunction = addRemoveLineClamps(paragraphs, breakpoint, lines);
        window.addEventListener('DOMContentLoaded', clampFunction);
        window.addEventListener('resize', clampFunction);
        clampFunction();
    }

    // blog cards
    addLineClamps('.blogs-wrapper .blog-item .description p', tabletBreakpoint, '100px');
    // shared page product cards 
    addLineClamps('.product-boards-shared-page .product-card .card-text', desktopBreakpoint, 4);
     // feature-list widget
    addLineClamps('.feature-card .description', 0, 4);

    return addLineClamps;

})();