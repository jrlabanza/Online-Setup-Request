function update() {

    //$("#pending tr:not(#head)").fadeOut("normal", function () {
    //    $(this).remove();
    //});
    //$("#ready-bo tr:not(#head)").fadeOut("normal", function () {
    //    $(this).remove();
    //});

    $.post(
        base_url + "Dashboard/live_updates_qfn",
        function (data) {
            var pending = "";
            var released = "";
            var color = "";
            append_val = 0;
            $.each(data, function (i, osr_data) {
                if (new Date(osr_data.expectedDateOfSetup) <= (new Date())) {
                    var color = "red";
                }
                else {
                    var color = "black";
                }

                if (osr_data.status != "READY FOR BUY OFF" && osr_data.status != "RELEASED" && osr_data.status != "FORM CANCELLED") {
                    pending += "<div id='osr_data' class='loadboard_data col s6 l6 m6 data_refresh' style='cursor: pointer; background-color:' data-osr-id='" + osr_data.id + "'>";
                    pending += "<div style='font-size:3em; color:" + color + "'>" + osr_data.m3Number + "</div>";
                    pending += "</div>";
                }
                else if (osr_data.status == "READY FOR BUY OFF") {

                    released += "<div id='osr_data' class='loadboard_data col s6 l6 m6 data_refresh' style='cursor: pointer; background-color:' data-osr-id='" + osr_data.id + "'>";
                    released += "<div style='font-size:3em; color:" + color + "'>" + osr_data.m3Number + "</div>";
                    released += "</div>";
                }
            });

            $(".pending-data").append(pending);
            $(".buy-off").append(released);
        });

}

update();

setInterval(function () {
    update();
    $(".data_refresh").fadeOut("normal");
}, 60000);


