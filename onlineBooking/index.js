//window.onload = startUp();

function startUp() {
    updateList();
    changeBackground();
}

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

function updateList() {
    var eventsList;
    jQuery.ajax({
        type: "POST",
        url: 'includes/functions.php',
        dataType: 'json',
        data: { functionname: 'getAllList' },

        success: function(obj, textstatus) {
            eventsList = obj.result;
            display(eventsList);
        }
    });
}

function searchEvent() {
    var eventsList;
    var search = document.getElementById("searchEventSearch").value;
    var type = document.getElementById("course").value;
    jQuery.ajax({
        type: "POST",
        url: 'includes/functions.php',
        dataType: 'json',
        data: { functionname: 'getThis', arguments: [type, search] },

        success: function(obj, textstatus) {
            eventsList = obj.result;
            removeData();
            display(eventsList);
        }
    });
}

function removeData() {
    var body = document.getElementById("tbody");
    body.parentNode.removeChild(body);
}

function display(data) {
    var events = document.getElementById("events");

    var body = document.createElement("TBODY");
    body.setAttribute("id", "tbody");

    for (var i = 0; i < data.length; i++) {
        var tablerow = body.insertRow(-1);
        var tableCell = tablerow.insertCell(-1);
        tableCell.innerHTML = data[i].name;

        var tableCell1 = tablerow.insertCell(-1);
        tableCell1.innerHTML = data[i].time;

        var tableCell2 = tablerow.insertCell(-1);
        tableCell2.innerHTML = data[i].due;

        var tableCell3 = tablerow.insertCell(-1);
        tableCell3.innerHTML = data[i].price;
    }
    events.appendChild(body);
}

function loadCSS() {
    var head = document.getElementsByTagName('HEAD')[0];
    var link = document.createElement('link');
    link.rel = 'stylesheet';
    link.href = 'index.css';
    head.appendChild(link);
}

$(document).ready(function() {
    var counter = 2;
    setInterval(function() {
        document.getElementById('radio' + counter).checked = true;
        counter += 1;
        if (counter > 4) {
            counter = 1;
        }
    }, 5000);

    $('#datetimepicker').datetimepicker({
        minDate: 0
    });

    $(document).on('click', '.book-n', function() {
        alert("push");
    });
});