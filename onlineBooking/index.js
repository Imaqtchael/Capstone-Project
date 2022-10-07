window.onload = changeBackground();

function changeBackground() {
    var number = 0;
    var images = ['basketball.jpg', 'birthday.jpg', 'concert.jpg', 'debut.jpg', 'wedding.jpg'];
    setInterval(() => {
        var random = Math.floor(Math.random() * 4);
        $('#vary').css('background-image', `url(pictures/index/${images[number]})`);
        number += 1;
        if (number > 4) {
            number = 0;
        }
        $('#vary').css('transition', '0.9s');
    }, 3000);
}