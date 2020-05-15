$(document).on("click", "#osr_data td:not(:first-child):not(:last-child)", function () {

    
    $("#id-placeholder").val($(this).attr("data-osr-id"));
    var id = $("#id-placeholder").val();
    $("#myModal").modal("show");
    $('#remarks').val('');
    $(".clear").remove();

    $.post(
        base_url + "Form/getOSRData",
        {
            "id": id
        },
        function (data) {
            $.post(
                base_url + "Users/is_valid",
                {
                    "FFID": FFID
                },
                function (is_valid) {
                    console.log(is_valid);

                    if (((is_valid.FFID != null) || (data.sub_ffID == FFID && data.status == "FOR PREPARATION")) && (data.status != "RELEASED")) {
                        $(".update-checker").show();
                        $(".release-checking").hide();
                    }
                    else {
                        $(".update-checker").hide();
                        $(".release-checking").hide();
                    }

                    var status_append = "";
                    $(".clear-data").remove();
                    $("#m3-number").val(data.m3Number);
                    $("#tester-id").val(data.testerID);
                    $("#handler-id").val(data.handlerID);
                    $("#family").val(data.family);
                    $("#package").val(data.package);
                    $("#process").val(data.process);
                    $("#requested-by").val(data.requestBy);
                    var formatDate = Date.parse(data.dateRequest);
                    var newDate = formatDate.toString('yyyy-MM-dd HH:mm:ss');
                    $("#date-submitted").val(newDate);
                    var edsDate = Date.parse(data.expectedDateOfSetup);
                    var newEDS = edsDate.toString('yyyy-MM-dd HH:mm:ss');
                    $("#expected-date-of-setup").val(newEDS);
                    $("#recently-updated-by").val(data.updater);
                    $("#shift").val(data.shift);

                    switch (data.status) {
                        case "FOR PREPARATION":
                            status_append += "<option class='clear-data' value='" + data.status + "'>" + data.status + "</option>";
                            if ((data.sub_ffID == FFID && is_valid.FFID != null) || (is_valid.FFID != null)) {
                                status_append += "<option class='clear-data' value='ON GOING PREPARATION'>ON GOING PREPARATION</option>";
                            }
                            status_append += "<option class='clear-data' value='FORM CANCELLED'>FORM CANCELLED</option>";
                            $("#status").append(status_append);
                            break;
                        case "ON GOING PREPARATION":
                            status_append += "<option class='clear-data' value='" + data.status + "'>" + data.status + "</option>";
                            status_append += "<option class='clear-data' value='READY FOR BUY OFF'>READY FOR BUY OFF</option>";
                            status_append += "<option class='clear-data' value='FORM CANCELLED'>FORM CANCELLED</option>";
                            $("#status").append(status_append);
                            break;
                        case "READY FOR BUY OFF":
                            status_append += "<option class='clear-data' value='" + data.status + "'>" + data.status + "</option>";
                            status_append += "<option class='clear-data' value='RELEASED'>RELEASED</option>";
                            status_append += "<option class='clear-data' value='FORM CANCELLED'>FORM CANCELLED</option>";
                            $("#status").append(status_append);
                            break;
                        case "RELEASED":
                            break;
                        case "FORM CANCELLED":
                            break;
                    }
                }
            )
        }
        );

});

$(document).on("click", "#update-osr", function () {
    if ($("#status").val() == "RELEASED" && $("#released-to").val() == "") {
        $("#released-to").addClass("is-invalid").removeClass("is-valid");
    }
    else {
        $("#released-to").addClass("is-valid").removeClass("is-invalid");
    }

    if ($("#status").val() == "RELEASED" && $("#released-to").val() == "") {
        $.notify({
            title: '<strong>PLEASE FILL UP ALL INFORMATION!</strong>',
            message: ""
        }, {
            type: 'danger',
            z_index: 9999
        });
        setTimeout(function () {
            $.notifyClose('top-right');
        }, 1000);

    }
    else {
        var get_status = $("#status").val();
        update_osr(get_status);
    }
    
});

function update_osr(get_status) {
    var id = $("#id-placeholder").val();
    var m3Number = $("#m3-number").val();
    var testerID = $("#tester-id").val();
    var handlerID = $("#handler-id").val();
    var family = $("#family").val();
    var package = $("#package").val();
    var process = $("#process").val();
    var requestedBy = $("#requested-by").val();
    var dateSubmitted = $("#date-submitted").val();
    var expectedDateofSetup = $("#expected-date-of-setup").val();
    var recentlyUpdateBy = $("#recently-updated-by").val();
    var shift = $("#shift").val();
    var status = get_status;
    var remarks = $("#remarks").val();
    var releasedTo = $("#released-to").val();

    var UPDATE_OSR = {
        "id": id,
        "m3Number": m3Number,
        "testerID": testerID,
        "handlerID": handlerID,
        "family": family,
        "package": package,
        "process": process,
        "requestedBy": requestedBy,
        "dateSubmitted": dateSubmitted,
        "expectedDateofSetup": expectedDateofSetup,
        "recentlyUpdateBy": recentlyUpdateBy,
        "shift": shift,
        "status": status,
        "remarks": remarks,
        "releasedTo": releasedTo
    }
    $.post(
        base_url + "Form/OSRFormUpdate",
        UPDATE_OSR,
        function (data) {
            $.notify({
                title: '<strong>Success!</strong>',
                message: "Data has been updated. Returning to Dashboard"
            }, {
                type: 'success',
                z_index: 9999
            });
            setTimeout(function () {
                $.notifyClose('top-right');
                window.location.reload();
                //window.close();
            }, 1000);
        }
        );

}


$(document).on("change", "#status" , function () {
    var status = $("#status").val();
    if (status == "RELEASED") {
        $(".release-checking").show();
        $.post(
        base_url + "Form/get_user_list",
        function (data) {
            var append = "";
            $.each(data, function (i, user) {
                append += "<option class= clear>" + user.firstName + " " + user.lastName +"</option>"
            });
            $("#released-list").append(append);
        });
    }
    else {
        $(".release-checking").hide();
        $(".clear").remove();
    }
});

