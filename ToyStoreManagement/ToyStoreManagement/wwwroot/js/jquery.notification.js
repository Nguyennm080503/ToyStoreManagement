$(document).ready(function () {
    // Automatically hide the alert after 5 seconds
    setTimeout(function () {
        $('.alert').addClass('bounceOutRight');
        $('.alert').one('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function () {
            $(this).hide();
        });
    }, 5000);

    // Close button functionality
    $('.close').on('click', function () {
        var alertBox = $(this).parent();
        alertBox.addClass('bounceOutRight');
        alertBox.one('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function () {
            alertBox.hide();
        });
    });
});