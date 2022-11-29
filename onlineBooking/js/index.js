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
        url: 'http://localhost/Capstone/onlineBooking/includes/functions.php',
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

            $('#datetimepicker').datetimepicker({
                minDate: 0,
                format: 'Y/m/d g:i A',
                disabledDates: disabledDate
            });

        }
    });
});