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

function TableToJSON(table) {
    var data = [];

    var headers = ['name', 'address', 'email', 'number'];

    //get the headers
    //for (var i = 0; i < table.rows[0].cells.length; i++) {
    //    headers[i] = table.rows[0].cells[i].innerHTML.toLowerCase().replace(/ /gi, '');
    //}

    //get all the table data
    for (var i = 1; i < table.rows.length; i++) {
        var tableRow = table.rows[i];
        var rowData = {};

        for (var j = 0; j < tableRow.cells.length; j++) {
            if (j == 4) {
                continue;
            }
            rowData[headers[j]] = tableRow.cells[j].innerHTML;
        }

        data.push(rowData);
    }

    return data;
}

function DownloadJSON(exportObj) {
    //var data_str = "data:text/json;charset=utf-8," + encodeURIComponent(exportObj);

    localStorage.setItem('backup.json', exportObj);
    //var downloadAnchorNode = document.createElement('a');

    //downloadAnchorNode.setAttribute("href", data_str);
    //downloadAnchorNode.setAttribute('download', "backup.json");
    //downloadAnchorNode.innerHTML = "hadhfashdf"
    //document.body.appendChild(downloadAnchorNode);

    //downloadAnchorNode.click();
    //downloadAnchorNode.remove();
}

function CheckForPreviousEntry() {
    //localStorage.clear();
    var backup = localStorage.getItem('backup.json');

    console.log(JSON.parse(backup));

    if (backup != null && Object.keys(JSON.parse(backup)).length > 0) {
        JSONToTable(JSON.parse(backup));
        //ReEditTable();
    } else {
        return false;
    }
}

function JSONToTable(json) {
    json.forEach(function(obj) {
        $("#events tbody").append("<tr class='row'><td>" + obj.name + "</td><td>" + obj.address + "</td><td>" + obj.email + "</td><td>" + obj.number + "</td><td isButton='delete'><input class='delete-btn' type='submit' value='DELETE'></input></td></tr>");
    });
    document.getElementById('submit-btn').style.cssText = 'display: inline;'
    hasAdded = true;
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
            dataType: 'text',
            data: { functionname: 'insertData', arguments: localStorage.getItem('backup.json') },

            success: function(obj, textstatus) {
                if (obj == "Guest submission success!") {
                    localStorage.removeItem('backup.json');
                    window.location.href = "https://event-venue.website/index.php";
                }
                alert(obj);
            }
        });


        //$.post('includes/functions.php', { 'json': localStorage.getItem('backup.json') }, function(data) {
        //    alert(data);
        //});
    });

    CheckForPreviousEntry();

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