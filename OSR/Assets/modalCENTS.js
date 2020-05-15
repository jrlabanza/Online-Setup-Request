if (compare_url == "OSR_CENTS") {
    $(document).on("click", "#osr_data td:not(:first-child):not(:last-child)", function () {
        $(".update-expected-date-of-setup").hide();

        $("#id-placeholder").val($(this).attr("data-osr-id"));
        var id = $("#id-placeholder").val();

        $("#myModal").modal("show");
        $('#remarks').val('');
        $(".clear").remove();

        $.post(
            base_url + "Form/getOSRCENTSData",
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
                        $("#socket-id").val(data.socketID);
                        $("#request-qty").val(data.request_qty);
                        $("#handler-model").val(data.handlerModel);
                        $("#handler-id").val(data.handlerID);
                        $("#package").val(data.package);
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
                                //status_append += "<option class='clear-data' value='" + data.status + "'>" + data.status + "</option>";
                                //status_append += "<option class='clear-data' value='READY FOR BUY OFF'>READY FOR BUY OFF</option>";
                                //status_append += "<option class='clear-data' value='FORM CANCELLED'>FORM CANCELLED</option>";
                                //$("#status").append(status_append);
                                status_append += "<option class='clear-data' value='" + data.status + "'>" + data.status + "</option>";
                                status_append += "<option class='clear-data' value='RELEASED'>RELEASED</option>";
                                status_append += "<option class='clear-data' value='FORM CANCELLED'>FORM CANCELLED</option>";
                                $("#status").append(status_append);
                                break;
                            //case "READY FOR BUY OFF":
                            //    status_append += "<option class='clear-data' value='" + data.status + "'>" + data.status + "</option>";
                            //    status_append += "<option class='clear-data' value='RELEASED'>RELEASED</option>";
                            //    status_append += "<option class='clear-data' value='FORM CANCELLED'>FORM CANCELLED</option>";
                            //    $("#status").append(status_append);
                            //    break;
                            case "RELEASED":
                                break;
                            case "FORM CANCELLED":
                                break;
                        }
                    }
                )
            }
        );
        $('.customdate').daterangepicker({
            "singleDatePicker": true,
            "autoApply": true,
            "hour": "06",
            "drops": "up",
            locale: {
                format: "YYYY-MM-DD 06:00:00"
            }

        },
        function (start, end, label) {
            console.log('New date range selected: ' + start.format('YYYY-MM-DD') + ' to ' + end.format('YYYY-MM-DD') + ' (predefined range: ' + label + ')');
        });

        $("#expected-date-of-setup").on("change", function () {
            $(".update-expected-date-of-setup").show().addClass("update-enabled");
        });


    });

    $(document).on("click", "#update-osr", function () {
        if ($("#status").val() == "RELEASED" && ($("#released-to").val() == "" || $("#socket-id").val() == "")) {
            $("#released-to").addClass("is-invalid").removeClass("is-valid");
            $("#socket-id").addClass("is-invalid").removeClass("is-valid");

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
            $("#released-to").addClass("is-valid").removeClass("is-invalid");
            $("#socket-id").addClass("is-valid").removeClass("is-invalid");
            var socketID = $("#socket-id").val();
            var package_type = $("#package").val();
            var get_status = $("#status").val();
            var handler_id = $("#handler-id").val();
            var handler_model = $("#handler-model").val();
            var releasedTo = $("#released-to").val();
            var remarks = $("#remarks").val();
            var request_qty = $("#request-qty").val();
            //check package 
            if ($("#status").val() == "RELEASED") {
                $.post(
                    base_url + "Form/check_package_socket",
                    {
                        "socketID": socketID,
                        "package_type": package_type
                    },
                    function (data) {
                        if (data.socket_id == socketID) {
                            $.notify({
                                title: '<strong>Success!</strong>',
                                message: "Package Match, Updating CENTS...."
                            }, {
                                type: 'success',
                                z_index: 9999
                            });
                            setTimeout(function () {
                                $.notifyClose('top-right');
                                $.post(
                                    base_url + "Form/update_cents",
                                    {
                                        "socketID": socketID,
                                        "package_type": package_type,
                                        "status": get_status,
                                        "handler_id": handler_id,
                                        "handler_model": handler_model,
                                        "released_to": releasedTo,
                                        "remarks": remarks,
                                        "request_qty": request_qty

                                    },
                                    function () {
                                        $.notify({
                                            title: '<strong>Success!</strong>',
                                            message: "Updated CENTS, Processing Form...."
                                        }, {
                                            type: 'success',
                                            z_index: 9999
                                        });
                                        setTimeout(function () {
                                            update_osr(get_status);
                                        },2000);
                                    }
                                    );
                            }, 2000);

                        }
                        else {
                            $.notify({
                                title: '<strong>SOCKET MISMATCH!</strong>',
                                message: ""
                            }, {
                                type: 'danger',
                                z_index: 9999
                            });
                            setTimeout(function () {
                                $.notifyClose('top-right');
                            }, 3000);
                        }
                    }
                );
            }
            else {
                update_osr(get_status);
            }

            
        }
    });

    function update_osr(get_status) {

        var id = $("#id-placeholder").val();
        var m3Number = $("#m3-number").val();
        var socketID = $("#socket-id").val();
        var handlerID = $("#handler-id").val();
        var handlerModel = $("#handler-model").val();
        var package = $("#package").val();
        var requestedBy = $("#requested-by").val();
        var dateSubmitted = $("#date-submitted").val();
        var expectedDateofSetup = $("#expected-date-of-setup").val();
        var recentlyUpdateBy = $("#recently-updated-by").val();
        var shift = $("#shift").val();
        var status = get_status;
        var remarks = $("#remarks").val();
        var releasedTo = $("#released-to").val();
        var reasonToChangeSetup = $("#reason-to-change-setup").val();
        var request_qty = $("#request-qty").val();

        var UPDATE_OSR = {
            "id": id,
            "m3Number": m3Number,
            "socketID": socketID,
            "handlerID": handlerID,
            "handlerModel": handlerModel,
            "package": package,
            "requestedBy": requestedBy,
            "dateSubmitted": dateSubmitted,
            "expectedDateofSetup": expectedDateofSetup,
            "recentlyUpdateBy": recentlyUpdateBy,
            "shift": shift,
            "status": status,
            "remarks": remarks,
            "releasedTo": releasedTo,
            "reasonToChangeSetup": reasonToChangeSetup,
            "request_qty": request_qty
        }

        if ($(".update-expected-date-of-setup").hasClass("update-enabled")) { // if user change expected date of setup

            if ($("#reason-to-change-setup").val() == "") {
                $("#reason-to-change-setup").addClass("is-invalid").removeClass("is-valid");
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
                $.post(
                    base_url + "Users/is_valid_for_update",
                    {
                        "FFID": FFID,
                    },
                    function (is_valid) {
                        console.log(is_valid);

                        if ((is_valid.FFID != null) || (userDetailsSession == requestedBy)) {

                            if ($("#remarks").val() == "" || $("#remarks").val() == null) {
                                $.notify({
                                    title: '<strong>Warning!</strong>',
                                    message: "Please Input Remarks"
                                }, {
                                    type: 'danger',
                                    z_index: 9999
                                });
                                setTimeout(function () {
                                    $.notifyClose('top-right');

                                }, 3000);
                            }
                            else {
                                $.post(
                                base_url + "Form/OSRCENTSFormUpdateWithExpectedUpdate",
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
                                    }, 1000);
                                }
                             );
                            }

                        }
                        else {
                            $.notify({
                                title: '<strong>Warning!</strong>',
                                message: "UNAUTHORIZED ACTION!"
                            }, {
                                type: 'danger',
                                z_index: 9999
                            });
                            setTimeout(function () {
                                $.notifyClose('top-right');
                            }, 1000);
                        }

                    }
                );

            }

        }
        else {
            if ($("#remarks").val() == "" || $("#remarks").val() == null) {
                $.notify({
                    title: '<strong>Warning!</strong>',
                    message: "Please Input Remarks"
                }, {
                    type: 'danger',
                    z_index: 9999
                });
                setTimeout(function () {
                    $.notifyClose('top-right');

                }, 3000);
            }
            else {
                $.post(
                    base_url + "Form/OSRCENTSFormUpdateWithExpectedUpdate",
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
        }
    }


    $(document).on("change", "#status", function () {
        var status = $("#status").val();
        if (status == "RELEASED") {
            $(".release-checking").show();
            $.post(
            base_url + "Form/get_user_list",
            function (data) {
                var append = "";
                $.each(data, function (i, user) {
                    append += "<option class= clear>" + user.firstName + " " + user.lastName + "</option>"
                });
                $("#released-list").append(append);
                //$.post(
                //base_url + "Form/get_socket_list",
                //function (data) {
                //    var append = "";
                //    $.each(data, function (i, user) {
                //        append += "<option class= clear>" + user.socket_id + "</option>"
                //    });
                //    $("#socket-list").append(append);

                //});
            });
            
        }
        else {
            $(".release-checking").hide();
            $(".clear").remove();
        }
    });


}
