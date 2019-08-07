$(document).ready(function () {

    // number add 
    var number = 1;
    $(".numberof").val(number);

    $(".plus").click(function () {
        number = number + 1;
        $(".numberof").val(number);
    })
    $(".minus").click(function (ev) {
        if (number == 1) {
            number = 1;
        }
        else {
            number = number - 1;
        }
        $(".numberof").val(number);

    })

    // owl carusel

    $('.owl-tab').owlCarousel({
        margin: 10,
        nav: true,
        responsiveClass: true,
        responsive: {
            0: {
                items: 1,
                nav: true
            },
            480: {
                items: 2,
                nav: true
            },
            768: {
                items: 3,
                nav: true,
            },
            960: {
                items: 5,
                nav: true,
            }
        }
    })
})