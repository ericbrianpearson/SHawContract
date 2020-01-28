(function () {
    // Invoke Immediately
    adjustNavPositionBasedOnScroll();
    startAnimation();
    window.addEventListener("scroll", onPageScroll);
    window.addEventListener("resize", onPageResize);
    $(function () {
        onDocumentLoaded();
    });

    try {
        document
            .getElementById("product_color_label_switch")
            .addEventListener("change", onColorLabelChange);
    } catch (error) { }

    // Helper functions
    function adjustNavPositionBasedOnScroll() {
        var howFarHasUserScrolled = window.pageYOffset;
        if (howFarHasUserScrolled && howFarHasUserScrolled > 0) {
            document.body.classList.add("scrolling");
        } else {
            document.body.classList.remove("scrolling");
        }
    }

    function debounce(fn, ms) {
        var time = null;
        return function () {
            var a = arguments,
                t = this;
            clearTimeout(time);
            time = setTimeout(function () {
                fn.apply(t, a);
            }, ms);
        };
    }
    function throttle(fn, ms) {
        var time,
            last = 0;
        return function () {
            var a = arguments,
                t = this,
                now = +new Date(),
                exe = function () {
                    last = now;
                    fn.apply(t, a);
                };
            clearTimeout(time);
            now >= last + ms ? exe() : (time = setTimeout(exe, ms));
        };
    }
    function hasClass(el, cls) {
        if (el.classList.contains(cls)) {
            return true;
        }
    }
    function addClass(el, cls) {
        if (el) {
            el.classList.add(cls);
        }
    }
    function delClass(el, cls) {
        el.classList.remove(cls);
    }
    function elementFromTop(elem, classToAdd, distanceFromTop, unit) {
        var winY = window.innerHeight || document.documentElement.clientHeight,
            elemLength = elem.length,
            distTop,
            distPercent,
            distPixels,
            distUnit,
            i;
        for (i = 0; i < elemLength; ++i) {
            distTop = elem[i].getBoundingClientRect().top;
            distPercent = Math.round((distTop / winY) * 100);
            distPixels = Math.round(distTop);
            distUnit = unit == "percent" ? distPercent : distPixels;
            if (distUnit <= distanceFromTop) {
                if (!hasClass(elem[i], classToAdd)) {
                    addClass(elem[i], classToAdd);
                }
            } else {
                delClass(elem[i], classToAdd);
            }
        }
    }
    function addClassToElementsThatHaveComeIntoView(elementSelector, cssClass) {
        //elementFromTop(document.querySelectorAll(elementSelector),  cssClass,  0, 'pixels');
        elementFromTop(
            document.querySelectorAll(elementSelector),
            cssClass,
            90,
            "percent"
        );
    }

    function show(elem, speed) {
        if (speed === undefined) {
            speed = 350;
        }

        // Get the natural height of the element
        var getHeight = function () {
            elem.style.display = "block"; // Make it visible
            var height = elem.scrollHeight + "px"; // Get it's height
            elem.style.display = ""; //  Hide it again
            return height;
        };

        var height = getHeight(); // Get the natural height
        elem.classList.add("is-visible"); // Make the element visible
        elem.style.height = height; // Update the max-height

        // Once the transition is complete, remove the inline max-height so the content can scale responsively
        window.setTimeout(function () {
            elem.style.height = "";
        }, speed);
    }

    function hide(elem, speed) {
        if (speed === undefined) {
            speed = 350;
        }

        // Give the element a height to change from
        elem.style.height = elem.scrollHeight + "px";

        // Set the height back to 0
        window.setTimeout(function () {
            elem.style.height = "0";
        }, 1);

        // When the transition is complete, hide it
        window.setTimeout(function () {
            elem.classList.remove("is-visible");
        }, speed);
    }

    // Aggregate calls on common window actions
    function onPageScroll() {
        adjustNavPositionBasedOnScroll();
        addClassToElementsThatHaveComeIntoView("section.widget", "now-viewable");
    }

    function onPageResize() {
        addClassToElementsThatHaveComeIntoView("section.widget", "now-viewable");
    }

    function onDocumentLoaded() {
        try {
            // Enable bootstraip tooltip
            $('[data-toggle="tooltip"]').tooltip();

            // Product Detail fake show progress
            fakeProgress();

            // Attempt to download file to users computer
            $(".download-this").click(function (e) {
                e.preventDefault();
                var that = $(this);
                var link = document.createElement("a");
                document.body.appendChild(link);
                link.href = that.attr("data-download");
                link.setAttribute("download", "");
                link.click();
            });

            // Save to board
            $(".save-to-board").click(function (e) {
                e.preventDefault();
                var that = $(this);
                var productNumber = that.attr("data-product") + "";
                var colorNumber = that.attr("data-color") + "";

                alert(
                    'save to board called with values "Product: ' +
                    productNumber +
                    '" and "Color: ' +
                    colorNumber +
                    '"'
                );
            });

            // Swamp Product Detail Views
            $(".btn-maximize").click(function (e) {
                e.preventDefault();
                var that = $(this);
                var parent = that.closest(".swappable");

                if (parent) {
                    $(".swappable").removeClass(
                        "maximized minimized col-sm-12 col-sm-6 order-6"
                    );
                    parent.addClass("col-sm-12 maximized");
                    $(".swappable")
                        .not(parent)
                        .addClass("col-sm-6 minimized order-6");
                }
            });

            $(".install-method").click(function (e) {
                e.preventDefault();
                var that = $(this);
                var parent = that.closest(".control-area");
                if (parent) {
                    $(".img-area img", parent).attr("src", that.attr("href"));
                }
            });
        } catch (error) { }
    }

    // Product detail page - show color labels
    function onColorLabelChange() {
        var isChecked = document.getElementById("product_color_label_switch")
            .checked;
        if (isChecked) {
            document
                .getElementById("product_color_picker")
                .classList.add("show-labels");
            $('[data-toggle="tooltip"]').tooltip("dispose");
        } else {
            document
                .getElementById("product_color_picker")
                .classList.remove("show-labels");
            $('[data-toggle="tooltip"]').tooltip();
        }
    }

    // Product detail page - image loader progress bar
    function updateProductDetailLoadProgress(intPercentComplete) {
        var progressBar = document.getElementById("product_detail_progress");
        progressBar.style.width = intPercentComplete + "%";

        if (intPercentComplete >= 100) {
            productDetailLoadComplete();
        }
    }
    function productDetailLoadComplete() {
        document.getElementById("product_detail_loader").style.display = "none";
        show(document.getElementById("product_detail_view_swap"), 500);
    }
    function fakeProgress() {
        updateProductDetailLoadProgress(25);
        setTimeout(function () {
            updateProductDetailLoadProgress(35);
        }, 500);
        setTimeout(function () {
            updateProductDetailLoadProgress(45);
        }, 1000);
        setTimeout(function () {
            updateProductDetailLoadProgress(65);
        }, 1500);
        setTimeout(function () {
            updateProductDetailLoadProgress(85);
        }, 2000);
        setTimeout(function () {
            updateProductDetailLoadProgress(95);
        }, 2500);
        setTimeout(function () {
            updateProductDetailLoadProgress(100);
        }, 3100);
    }

    function startAnimation() {
        var windowHeight = 650;
        var dancingSquareWidgets = document.getElementsByClassName(
            "dancing-squares"
        );
        var firstDancingSquareWidget;

        if (dancingSquareWidgets.length > 0) {
            firstDancingSquareWidget = dancingSquareWidgets[0];

            if (firstDancingSquareWidget.offsetTop <= windowHeight) {
                addClass(firstDancingSquareWidget, "now-viewable");
            }
        }
    }
})();
