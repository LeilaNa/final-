$(document).ready(function () {

    $(".searchbutton").click(function () {
        $(".searchmob").css("width", "100%");
        $(".searchmob").css("padding", "20px");
    })
    $(".close").click(function () {
        $(".searchmob").css("width", "0");
        $(".searchmob").css("padding", "0px");
    })

    $(".barsIcon").click(function () {
        $(".accordion").css("height", "100%");
        $(".barsIcon").css("display", "none");
        $(".closebar").css("display", "block")
    })

    $(".closebar").click(function () {
        $(".accordion").css("height", "0");
        $(".closebar").css("display", "none");
        $(".barsIcon").css("display", "block")
    })

    $('.collapse').on('shown.bs.collapse', function () {
        $(this).parent().find(".glyphicon-plus").removeClass("glyphicon-plus").addClass("glyphicon-minus");
    }).on('hidden.bs.collapse', function () {
        $(this).parent().find(".glyphicon-minus").removeClass("glyphicon-minus").addClass("glyphicon-plus");
    });
    $(window).scroll(function () {
        var scr = $(window).scrollTop();
        if (scr > 195) {
            $(".bottom").addClass("fixed");
        }
        else {
            $(".bottom").removeClass("fixed")
        }
    })


    $(".filterIcon").click(function () {
        $(".filter").css("display", "block");
        $(".filterIcon").css("display", "none");
        $(".closefilter").css("display", "block")
    })

    $(".closefilter").click(function () {
        $(".filter").css("display", "none");
        $(".filterIcon").css("display", "block");
        $(".closefilter").css("display", "none")
    })
});
