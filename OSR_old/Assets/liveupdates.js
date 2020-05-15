function update() {

    $("#pending tr:not(#head)").fadeOut("normal", function () {
        $(this).remove();
    });
    $("#ready-bo tr:not(#head)").fadeOut("normal", function () {
        $(this).remove();
    });
    $.post(
        base_url + "Dashboard/get_osr_dashboard",
        function (data) {
            var pending = "";
            var released = "";
            var color = "";
            append_val = 0;
            $.each(data, function (i, osr_data) {

                if (osr_data.status != "READY FOR BUY OFF" && osr_data.status != "RELEASED" && osr_data.status != "FORM CANCELLED") {
                    pending += "<tr id='osr_data' class='loadboard_data' style='cursor: pointer; background-color:" + color + "' data-osr-id='" + osr_data.id + "'>";
                    pending += "<td style='font-size:5em'>" + osr_data.m3Number + "</td>";
                    pending += "</tr>";
                }
                else if (osr_data.status == "READY FOR BUY OFF") {

                    released += "<tr id='osr_data' class='loadboard_data' style='cursor: pointer; background-color:" + color + "' data-osr-id='" + osr_data.id + "'>";
                    released += "<td style='font-size:5em'>" + osr_data.m3Number + "</td>";
                    released += "</tr>";
                }
            });

            $("#pending-data").delay(500).append(pending).hide().fadeIn(1000);
            $("#buy-off").delay(500).append(released).hide().fadeIn(1000);
        });

}

update();

setInterval(function () {
    update();
}, 60000);


