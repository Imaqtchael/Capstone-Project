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

        var json = JSON.stringify(TableToJSON(document.getElementById("events")));

        DownloadJSON(json);
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

        var json = JSON.stringify(TableToJSON(document.getElementById("events")));

        DownloadJSON(json);

        if (!hasAdded) {
            //add the submit button
            document.getElementById('submit-btn').style.cssText = 'display: inline;'
            hasAdded = true;
        }
        $("#fullname").val("");
        $("#fulladdress").val("");
        $("#email").val("");
        $("#number").val("");
    });

    $(document).on('click', '.submit-table-btn', function() {

        jQuery.ajax({
            type: "POST",
            url: 'https://event-venue.website/includes/functions.php',
            dataType: 'json',
            data: { functionname: 'uploadData', arguments: localStorage.getItem('backup.json') },

            success: function(obj, textstatus) {
                eventsList = obj.result;
                alert(eventsList);
            }
        });


        //$.post('includes/functions.php', { 'json': localStorage.getItem('backup.json') }, function(data) {
        //    alert(data);
        //});
    });


    setInterval(function() {
        jQuery.ajax({
            type: "POST",
            url: 'https://event-venue.website/includes/functions.php',
            dataType: 'json',
            data: { functionname: "checkIfPaid", arguments: 'js' },

            success: function(obj, textstatus) {
                if (obj.result == "true") {
                    window.location.href = "https://event-venue.website/guest.php";
                }
            }
        });
    }, 1000);
});