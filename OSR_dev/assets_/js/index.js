document.addEventListener('DOMContentLoaded', function () {
    var elems = document.querySelectorAll('.fixed-action-btn');
    var instances = M.FloatingActionButton.init(elems, {
        direction: 'left'
    });
});


$(document).ready(function () {
    $('.materialboxed').materialbox();
});

$(document).ready(function () {
    $('.tooltipped').tooltip();
});

// $('.carousel.carousel-slider').carousel({
//     fullWidth: true
// });