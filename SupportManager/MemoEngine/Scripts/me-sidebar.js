//[!] 사이드바 관련 자바스크립트 코드: jQuery가 기본으로 상단에 포함되어져 있어야 함
$(function () {
    $('html').on('click', function (e) {
        $('.me-dropdown-menu').each(function (i, el) {
            if (!$(el).hasClass('me-keep-open') && $(el).css('display') != 'block') {
                $(el).hide();
            }
        });
    });
    $('.me-dropdown-toggle').on('click', function (e) {
        e.preventDefault();
        e.stopPropagation();
        if ($(this).next().css('display') == 'block' && !$(this).next().hasClass('me-keep-open')) {
            $(this).next().slideUp('fast');
        }
        else {
            $(this).next().slideDown('fast');
        }
    });
});