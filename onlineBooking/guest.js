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

var hasAdded = false;

function ReEditTable() {
    //adding the editable table function
    var table = document.getElementById("events");
    var cells = table.getElementsByTagName('td');

    for (var i = 0; i < cells.length; i++) {
        cells[i].onclick = function() {
            if (this.hasAttribute('data-clicked') || this.hasAttribute('isButton')) {
                return;
            }

            this.setAttribute('data-clicked', 'yes');
            this.setAttribute('data-text', this.innerHTML);

            var input = document.createElement('input');
            input.setAttribute('type', 'text');
            input.value = this.innerHTML;
            input.style.width = "auto";
            input.style.height = this.offsetHeight - (this.clientTop * 2) + "px";
            input.style.fontFamily = "inherit";
            input.style.fontSize = "inherit";
            input.style.textAlign = "center";
            input.style.backgroundColor = "LightGoldenRodYellow";

            input.onblur = function() {
                var td = input.parentElement;
                var orig_text = input.parentElement.getAttribute('data-text');
                var current_text = this.value;

                if (orig_text != current_text) {
                    //here you can add the data to the database

                    td.removeAttribute('data-clicked');
                    td.removeAttribute('data-text');
                    td.innerHTML = current_text;
                    td.style.cssText = 'padding: 12px 15px';
                } else {
                    td.removeAttribute('data-clicked');
                    td.removeAttribute('data-text');
                    td.innerHTML = orig_text;
                    td.style.cssText = 'padding: 12px 15px';
                }
            }

            input.onkeydown = function() {
                if (event.keyCode == 13) {
                    this.blur();
                }
            }

            this.innerHTML = '';
            this.style.cssText = 'padding: 0px';
            this.append(input);
            this.firstElementChild.select();
        }
    }
}

$(document).ready(function() {
    $(document).on('click', '.delete-btn', function() {
        $(this).closest('.row').remove();

        //check if there is a table remaining
        var table = document.getElementById("events");
        var cells = table.getElementsByTagName('td');
        if (cells.length == 0) {
            //remove the submit button
            document.getElementById('submit-btn').style.cssText = 'display: none;'
            hasAdded = false;
        }
    });

    $(document).on('click', '.add-user', function() {
        var fullname = $("#fullname").val();
        var address = $("#fulladdress").val();
        var email = $("#email").val();
        var number = $("#number").val();

        if (fullname == "") {
            return;
        } else if (address == "") {
            return;
        } else if (email == "") {
            return;
        } else if (number == "") {
            return;
        }

        var table = document.getElementById("events");
        var cells = table.getElementsByTagName('td');

        for (var i = 0; i < cells.length; i++) {
            if (cells[i].innerHTML == fullname) {
                alert("You have already added " + fullname + "!");
                return;
            }
        }

        $("#events tbody").append("<tr class='row'><td>" + fullname + "</td><td>" + address + "</td><td>" + email + "</td><td>" + number + "</td><td isButton='delete'><input class='delete-btn' type='submit' value='DELETE'></input></td></tr>");
        ReEditTable();

        if (!hasAdded) {
            //add the submit button
            document.getElementById('submit-btn').style.cssText = 'display: inline;'
            hasAdded = true;
        }
        //$("#fullname").val("");
        //$("#fulladdress").val("");
        //$("#email").val("");
        //$("#number").val("");
    });

    //changes the picture besides the guest data entry
    var counter = 1;
    setInterval(function() {
        document.getElementById('radio' + counter).checked = true;
        counter += 1;
        if (counter > 4) {
            counter = 1;
        }
    }, 5000);
});