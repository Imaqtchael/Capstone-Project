$(document).ready(function() {
    var counter = 2;
    setInterval(function() {
        document.getElementById('radio' + counter).checked = true;
        counter += 1;
        if (counter > 4) {
            counter = 1;
        }
    }, 5000);

    jQuery.ajax({
        type: "POST",
        url: 'https://event-venue.website/includes/functions.php',
        dataType: 'json',
        data: { functionname: 'checkForEvents' },

        success: function(obj, textstatus) {
            var result = obj.result;

            if (result == 'paid') {
                window.location.href = "https://event-venue.website/guest.php";
            } else if (result == 'notPaid') {
                window.location.href = "https://event-venue.website/redirect.php";
            }
        }
    });

    jQuery.ajax({
        type: "POST",
        url: 'https://event-venue.website/includes/functions.php',
        dataType: 'json',
        data: { functionname: 'getAllDates' },

        success: function(obj, textstatus) {
            var jsonCount = Object.keys(obj).length;
            var disabledDate = [];


            if (jsonCount > 0) {
                for (var i = 0; i < jsonCount; i++) {
                    disabledDate.push(obj[i]);
                }
            }

            var dateNow = new Date();
            var maxDate = String(parseInt(dateNow.getFullYear(), 10) + 1) + '/' + String(dateNow.getMonth() ).padStart(2, '0') + '/' + String(dateNow.getDate()).padStart(2, '0')


            $('#datetimepicker').datetimepicker({
                minDate: 0,
                format: 'Y/m/d g:i A',
                disabledDates: disabledDate,
                maxDate: maxDate
            });

        }
    });
});