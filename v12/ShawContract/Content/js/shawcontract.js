(function () {

    // Invoke Immediately
    adjustNavPositionBasedOnScroll();
    window.addEventListener("scroll", onPageScroll);
    window.addEventListener("resize", onPageResize);


    // Helper functions
    function adjustNavPositionBasedOnScroll() {
        var howFarHasUserScrolled = window.pageYOffset;
        if (howFarHasUserScrolled && howFarHasUserScrolled > 0) { document.body.classList.add("scrolling"); }
        else { document.body.classList.remove("scrolling"); }
    }

    function debounce(fn, ms) {
        var time = null;
        return function () {
            var a = arguments, t = this;
            clearTimeout(time);
            time = setTimeout(function () { fn.apply(t, a); }, ms);
        }
    }
    function throttle(fn, ms) {
        var time, last = 0;
        return function () {
            var a = arguments, t = this, now = +(new Date), exe = function () { last = now; fn.apply(t, a); };
            clearTimeout(time);
            (now >= last + ms) ? exe() : time = setTimeout(exe, ms);
        }
    }
    function hasClass(el, cls) { if(el.classList.contains(cls)) { return true; } }
    function addClass(el, cls) { el.classList.add(cls); }
    function delClass(el, cls) { el.classList.remove(cls); }
    function elementFromTop(elem, classToAdd, distanceFromTop, unit) {
        var winY = window.innerHeight || document.documentElement.clientHeight,
            elemLength = elem.length, distTop, distPercent, distPixels, distUnit, i;
        for (i = 0; i < elemLength; ++i) {
            distTop = elem[i].getBoundingClientRect().top;
            distPercent = Math.round((distTop / winY) * 100);
            distPixels = Math.round(distTop);
            distUnit = unit == 'percent' ? distPercent : distPixels;
            if (distUnit <= distanceFromTop) {
                if (!hasClass(elem[i], classToAdd)) { addClass(elem[i], classToAdd); }
            } else {
                delClass(elem[i], classToAdd);
            }
        }
    }
    function addClassToElementsThatHaveComeIntoView(elementSelector, cssClass) {
        //elementFromTop(document.querySelectorAll(elementSelector),  cssClass,  0, 'pixels');
        elementFromTop(document.querySelectorAll(elementSelector),  cssClass,  90, 'percent');
    }


    // Aggregate calls on common window actions
    function onPageScroll() {
        adjustNavPositionBasedOnScroll();
        addClassToElementsThatHaveComeIntoView('section.widget','now-viewable');
    }

    function onPageResize() {
        addClassToElementsThatHaveComeIntoView('section.widget','now-viewable');
    }

})();