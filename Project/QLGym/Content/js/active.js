
(function ($) {
    'use strict';

    var browserWindow = $(window);

    // :: 1.0 Preloader Active Code
    browserWindow.on('load', function () {
        $('#preloader').fadeOut('slow', function () {
            $(this).remove();
        });
    });

    // :: 2.0 Newsticker Active Code
    $.simpleTicker($("#breakingNewsTicker"), {
        speed: 1250,
        delay: 3500,
        easing: 'swing',
        effectType: 'roll'
    });

    // :: 3.0 Nav Active Code
    if ($.fn.classyNav) {
        $('#deliciousNav').classyNav();
    }

    // :: 4.0 Search Active Code
    var searchwrapper = $('.search-wrapper');
    $('.search-btn').on('click', function () {
        searchwrapper.toggleClass('on');
    });
    $('.close-btn').on('click', function () {
        searchwrapper.removeClass('on');
    });

    // :: 5.0 Sliders Active Code
    if ($.fn.owlCarousel) {
        var welcomeSlide = $('.hero-slides');
        var receipeSlide = $('.receipe-slider');

        welcomeSlide.owlCarousel({
            items: 1,
            margin: 0,
            loop: true,
            nav: true,
            navText: ['Prev', 'Next'],
            dots: true,
            autoplay: true,
            autoplayTimeout: 5000,
            smartSpeed: 1000
        });

        welcomeSlide.on('translate.owl.carousel', function () {
            var slideLayer = $("[data-animation]");
            slideLayer.each(function () {
                var anim_name = $(this).data('animation');
                $(this).removeClass('animated ' + anim_name).css('opacity', '0');
            });
        });

        welcomeSlide.on('translated.owl.carousel', function () {
            var slideLayer = welcomeSlide.find('.owl-item.active').find("[data-animation]");
            slideLayer.each(function () {
                var anim_name = $(this).data('animation');
                $(this).addClass('animated ' + anim_name).css('opacity', '1');
            });
        });

        $("[data-delay]").each(function () {
            var anim_del = $(this).data('delay');
            $(this).css('animation-delay', anim_del);
        });

        $("[data-duration]").each(function () {
            var anim_dur = $(this).data('duration');
            $(this).css('animation-duration', anim_dur);
        });

        var dot = $('.hero-slides .owl-dot');
        dot.each(function () {
            var index = $(this).index() + 1 + '.';
            if (index < 10) {
                $(this).html('0').append(index);
            } else {
                $(this).html(index);
            }
        });

        receipeSlide.owlCarousel({
            items: 1,
            margin: 0,
            loop: true,
            nav: true,
            navText: ['Prev', 'Next'],
            dots: true,
            autoplay: true,
            autoplayTimeout: 5000,
            smartSpeed: 1000
        });
    }

    // :: 6.0 Gallery Active Code
    if ($.fn.magnificPopup) {
        $('.videobtn').magnificPopup({
            type: 'iframe'
        });
    }

    // :: 7.0 ScrollUp Active Code
    if ($.fn.scrollUp) {
        browserWindow.scrollUp({
            scrollSpeed: 200,
            scrollText: '<i class="fa fa-angle-up"></i>'
        });
    }

    // :: 8.0 CouterUp Active Code
    if ($.fn.counterUp) {
        $('.counter').counterUp({
            delay: 10,
            time: 2000
        });
    }

    // :: 9.0 nice Select Active Code
    if ($.fn.niceSelect) {
        $('select').niceSelect();
    }

    // :: 10.0 wow Active Code
    if (browserWindow.width() > 767) {
        new WOW().init();
    }

    // :: 11.0 prevent default a click
    $('a[href="#"]').click(function ($) {
        $.preventDefault()
    });

})(jQuery);


function initForms() {
    var page = (window.location.pathname).split("/");
    var len = page.length;

    //select
    //$('.asp-select').hide();
    //if ($('.asp-select').next().hasClass('nice-select')) {
    //    $('.asp-select').next().remove();
    //}

    //var option = ""

    //$(".asp-select > option").each(function () {
    //    alert(this.text + ' ' + this.value);
    //});
    //$('.asp-select').after('<div class="nice-select" tabindex="0"><span class="current">-- None --</span><ul class="list"><li data-value="0" class="option selected focus">-- None --</li><li data-value="1" class="option">Customer</li><li data-value="2" class="option">Coach</li><li data-value="3" class="option">Admin</li></ul></div>')

    // :: 9.0 nice Select Active Code
    if ($.fn.niceSelect) {
        $('select').niceSelect();
    }

    //Datetime picker
    $(function () {
        $('.date').datetimepicker({
            format: 'YYYY-MM-DD',
            Default: {
                previous: 'fa fa-angle-left',
                next: 'fa fa-angle-left',
            },
        });

        $('.birth-date').datetimepicker({
            //beforeShow: function () {
            //    date: new Date(1997, 0, 1);
            //    },
            format: " YYYY", // Notice the Extra space at the beginning
            viewMode: "years",
            icons: {
                previous: 'fa fa-angle-left',
                next: 'fa fa-angle-right',
            },
        });
    });

    var pathname = window.location.pathname;
    var li = $('#NavMenu').children();
    li.each(function () {
        var atag = $(this).find('a:first');
        if ($(this).hasClass('active')) {
            $(this).removeClass('active');
        }
        if (atag.attr('href').includes(pathname)) {
            //console.log(pathname);
            $(this).addClass("active");
        }
    })
}


Sys.Application.add_load(AppLoad);
function AppLoad() {
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequest);
    initForms();
}
function EndRequest(sender, args) {
    initForms();
}
