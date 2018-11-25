// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Activation tooltips
$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();
});


$(document).ready(function () {
    var textError = $(".errors").text();

    if (!textError) {
        //Show and hide message about belts
        $(".chip_100").mouseenter(function () {
            $("#belts h1").fadeIn();
            $("#belts h1").css("display", "inline-block");
        });
        $(".chip_100").mouseleave(function () {
            $("#belts h1").fadeOut();
        });
        $(".chip_25").mouseenter(function () {
            $("#belts h1").fadeIn();
            $("#belts h1").css("display", "inline-block");
        });
        $(".chip_25").mouseleave(function () {
            $("#belts h1").fadeOut();
        });
        $(".chip_10").mouseenter(function () {
            $("#belts h1").fadeIn();
            $("#belts h1").css("display", "inline-block");
        });
        $(".chip_10").mouseleave(function () {
            $("#belts h1").fadeOut();
        });
        $(".chip_5").mouseenter(function () {
            $("#belts h1").fadeIn();
            $("#belts h1").css("display", "inline-block");
        });
        $(".chip_5").mouseleave(function () {
            $("#belts h1").fadeOut();
        });
    } else {
        $(".chip_100").mouseenter(function () {
            $("#sorry h2").fadeIn();
            $("#sorry h2").css("display", "inline-block");
        });
        $(".chip_100").mouseleave(function () {
            $("#sorry h2").fadeOut();
        });
        $(".chip_25").mouseenter(function () {
            $("#sorry h2").fadeIn();
            $("#sorry h2").css("display", "inline-block");
        });
        $(".chip_25").mouseleave(function () {
            $("#sorry h2").fadeOut();
        });
        $(".chip_10").mouseenter(function () {
            $("#sorry h2").fadeIn();
            $("#sorry h2").css("display", "inline-block");
        });
        $(".chip_10").mouseleave(function () {
            $("#sorry h2").fadeOut();
        });
        $(".chip_5").mouseenter(function () {
            $("#sorry h2").fadeIn();
            $("#sorry h2").css("display", "inline-block");
        });
        $(".chip_5").mouseleave(function () {
            $("#sorry h2").fadeOut();
        });
    }
});


// Chips Rotate 
var x, y, n = 0, rotINT;

function rotateChip100() {
    x = document.querySelector(".chip_100");
    clearInterval(rotINT);
    rotINT = setInterval("startRotate()", 10);
}
function rotateChip25() {
    x = document.querySelector(".chip_25");
    clearInterval(rotINT);
    rotINT = setInterval("startRotate()", 10);
}

function rotateChip10() {
    x = document.querySelector(".chip_10");
    clearInterval(rotINT);
    rotINT = setInterval("startRotate()", 10);
}

function rotateChip5() {
    x = document.querySelector(".chip_5");
    clearInterval(rotINT);
    rotINT = setInterval("startRotate()", 10);
}
function startRotate() {
    n = n + 1;
    x.style.transform = "rotate(" + n + "deg)";
    x.style.webkitTransform = "rotate(" + n + "deg)";
    x.style.OTransform = "rotate(" + n + "deg)";
    x.style.MozTransform = "rotate(" + n + "deg)";
    if (n == 180 || n == 360) {
        clearInterval(rotINT);
        if (n == 360) { n = 0 }
    }
}