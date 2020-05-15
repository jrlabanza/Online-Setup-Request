if (ActionName == "history") {
   
    $.post(
        base_url + "Dashboard/get_download_id",
        {
            "m3Number": idNumber
        },
        function (data) {
            $("#download-button").attr("data-get-document", data.id);

        }
    );

    $(document).on("click", "#download-button", function () {

        var id = $(this).attr("data-get-document");

        $.post(
            base_url + "Form/get_osr_documents",
            {
                "osr_id": id,
                "data_check": ActionName
            },
            function (data_document) {

                if (data_document != "") {
                    $.each(data_document, function (i, document) {
                        //document_append += "<a class='document-attachment' href='/uploads/osr/" + document.item_name + "' target='_blank'>" + document.item_name + "</a>"
                        window.open("/uploads/osr/" + document.item_name, "_blank");
                    })
                }
                else {
                    $.notify({
                        title: '<strong>NO DOCUMENTS WERE UPLOADED!</strong>',
                        message: ""
                    }, {
                        type: 'danger'
                    });
                    setTimeout(function () {
                        $.notifyClose('top-right');
                    }, 2000);
                }
            });
        $("#myModal").modal('hide');
    });

    $.post(
    base_url + "Dashboard/get_osr_history",
    {
        "osr_id": idNumber
    },
    function (data) {
        var append = "";
        var color = "";
        var font = "";
        var forecast = "";


        $.each(data, function (i, osr_data) {
            if (osr_data.status == "FOR PREPARATION") {
                color = "background-color: #d6d8d9";
                font = "color: black;"
            }
            else if (osr_data.status == "ON GOING PREPARATION") {
                color = "background-color: #fff3cd";
                font = "color: #856404;"
            }
            else if (osr_data.status == "READY FOR BUY OFF") {
                color = "background-color: #cce5ff;";
                font = "color: #004085;";
            }
            else if (osr_data.status == "FORM CANCELLED") {
                color = "background-color: #f8d7da;";
                font = "color: #721c24;";
            }
            else if (osr_data.status == "RELEASED") {
                color = "background-color: #d4edda;";
                font = "color: #155724;";
            }
            //if (osr_data.isPlanned == "1") {
            //    forecast = "PLANNED";
            //}
            //else if (osr_data.isPlanned == "0") {
            //    forecast = "UNPLANNED";
            //}
            //else {
            //    forecast = "N/A";
            //}

            append += "<tr>";
            append += "<td>" + osr_data.m3Number + "</td>";
            append += "<td>" + osr_data.testerID + "</td>";
            append += "<td>" + osr_data.handlerID + "</td>";
            append += "<td>" + osr_data.package + "</td>";
            append += "<td>" + osr_data.family + "</td>";
            append += "<td>" + osr_data.process + "</td>";
            //append += "<td>" + osr_data.dateRequest + "</td>";
            //append += "<td>" + osr_data.expectedDateOfSetup + "</td>";
            //append += "<td>" + osr_data.shift + "</td>";
            append += "<td>" + osr_data.requestBy + "</td>";
            append += "<td style ='" + font + " " + color + "'>" + osr_data.status + "</td>";
            append += "<td class='forecast'></td>";
            append += "<td>" + osr_data.updater + "</td>";
            append += "<td>" + osr_data.dateUpdated + "</td>";
            append += "<td>" + "" + "</td>";
            append += "<td>" + osr_data.remarks + "</td>";
            append += "<td>" + osr_data.reasonToChangeExpectedDateOfSetup + "</td>";
            append += "<td>" + osr_data.releasedTo + "</td>";
            append += "</tr>";

        });
        $("#history-data").append(append);
        $.post(
            base_url + "Dashboard/get_forecast",
            {
                "m3Number": idNumber
            },
            function (data) {
               
                if (data.isPlanned == "1") {
                    $(".forecast").html("PLANNED");
                }
                else if (data.isPlanned == "0") {
                    $(".forecast").html("UNPLANNED");
                }
                else {
                    $(".forecast").html("N/A");
                }
                

            }
        );
    });
}

if (ActionName == "history_burnin") {
    // alert('test');
    $.post(
        base_url + "Dashboard/get_download_id_burnin",
        {
            "m3Number": idNumber
        },
        function (data) {
            $("#download-button").attr("data-get-document", data.id);

        }
    );

    $(document).on("click", "#download-button", function () {

        var id = $(this).attr("data-get-document");

        $.post(
            base_url + "Form/get_osr_burn_in_documents",
            {
                "osr_id": id
            },
            function (data_document) {

                if (data_document != "") {
                    $.each(data_document, function (i, document) {
                        //document_append += "<a class='document-attachment' href='/uploads/osr/" + document.item_name + "' target='_blank'>" + document.item_name + "</a>"
                        window.open("/uploads/osr_burnin/" + document.item_name, "_blank");
                    })
                }
                else {
                    $.notify({
                        title: '<strong>NO DOCUMENTS WERE UPLOADED!</strong>',
                        message: ""
                    }, {
                        type: 'danger'
                    });
                    setTimeout(function () {
                        $.notifyClose('top-right');
                    }, 2000);
                }
            });
        $("#myModal").modal('hide');
    });

    $.post(
    base_url + "Dashboard/get_osr_burnin_history",
    {
        "osr_id": idNumber
    },
    function (data) {
        var append = "";
        var color = "";
        var font = "";


        $.each(data, function (i, osr_data) {
            if (osr_data.status == "FOR PREPARATION") {
                color = "background-color: #d6d8d9";
                font = "color: black;"
            }
            else if (osr_data.status == "ON GOING PREPARATION") {
                color = "background-color: #fff3cd";
                font = "color: #856404;"
            }
            else if (osr_data.status == "READY FOR BUY OFF") {
                color = "background-color: #cce5ff;";
                font = "color: #004085;";
            }
            else if (osr_data.status == "FORM CANCELLED") {
                color = "background-color: #f8d7da;";
                font = "color: #721c24;";
            }
            else if (osr_data.status == "RELEASED") {
                color = "background-color: #d4edda;";
                font = "color: #155724;";
            }

            append += "<tr>";
            append += "<td>" + osr_data.m3Number + "</td>";
            append += "<td>" + osr_data.handlerID + "</td>";
            append += "<td>" + osr_data.package + "</td>";
            append += "<td>" + osr_data.family + "</td>";
            append += "<td>" + osr_data.process + "</td>";
            //append += "<td>" + osr_data.dateRequest + "</td>";
            //append += "<td>" + osr_data.expectedDateOfSetup + "</td>";
            //append += "<td>" + osr_data.shift + "</td>";
            append += "<td>" + osr_data.requestBy + "</td>";
            append += "<td style ='" + font + " " + color + "'>" + osr_data.status + "</td>";
            append += "<td>" + osr_data.updater + "</td>";
            append += "<td>" + osr_data.dateUpdated + "</td>";
            append += "<td>" + "" + "</td>";
            append += "<td>" + osr_data.remarks + "</td>";
            append += "<td>" + osr_data.reasonToChangeExpectedDateOfSetup + "</td>";
            append += "<td>" + osr_data.releasedTo + "</td>";
            append += "</tr>";

        });
        $("#history-data").append(append);

    });
}

if (ActionName == "history_qfn") {

    $.post(
        base_url + "Dashboard/get_download_id",
        {
            "m3Number": idNumber
        },
        function (data) {
            $("#download-button").attr("data-get-document", data.id);

        }
    );

    $(document).on("click", "#download-button", function () {

        var id = $(this).attr("data-get-document");

        $.post(
            base_url + "Form/get_osr_documents",
            {
                "osr_id": id
            },
            function (data_document) {

                if (data_document != "") {
                    $.each(data_document, function (i, document) {
                        //document_append += "<a class='document-attachment' href='/uploads/osr/" + document.item_name + "' target='_blank'>" + document.item_name + "</a>"
                        window.open("/uploads/osr/" + document.item_name, "_blank");
                    })
                }
                else {
                    $.notify({
                        title: '<strong>NO DOCUMENTS WERE UPLOADED!</strong>',
                        message: ""
                    }, {
                        type: 'danger'
                    });
                    setTimeout(function () {
                        $.notifyClose('top-right');
                    }, 2000);
                }
            });
        $("#myModal").modal('hide');
    });

    $.post(
    base_url + "Dashboard/get_osr_qfn_history",
    {
        "osr_id": idNumber
    },
    function (data) {
        var append = "";
        var color = "";
        var font = "";


        $.each(data, function (i, osr_data) {
            if (osr_data.status == "FOR PREPARATION") {
                color = "background-color: #d6d8d9";
                font = "color: black;"
            }
            else if (osr_data.status == "ON GOING PREPARATION") {
                color = "background-color: #fff3cd";
                font = "color: #856404;"
            }
            else if (osr_data.status == "READY FOR BUY OFF") {
                color = "background-color: #cce5ff;";
                font = "color: #004085;";
            }
            else if (osr_data.status == "FORM CANCELLED") {
                color = "background-color: #f8d7da;";
                font = "color: #721c24;";
            }
            else if (osr_data.status == "RELEASED") {
                color = "background-color: #d4edda;";
                font = "color: #155724;";
            }

            append += "<tr>";
            append += "<td>" + osr_data.m3Number + "</td>";
            append += "<td>" + osr_data.testerID + "</td>";
            append += "<td>" + osr_data.handlerID + "</td>";
            append += "<td>" + osr_data.package + "</td>";
            append += "<td>" + osr_data.family + "</td>";
            append += "<td>" + osr_data.process + "</td>";
            //append += "<td>" + osr_data.dateRequest + "</td>";
            //append += "<td>" + osr_data.expectedDateOfSetup + "</td>";
            //append += "<td>" + osr_data.shift + "</td>";
            append += "<td>" + osr_data.requestBy + "</td>";
            append += "<td style ='" + font + " " + color + "'>" + osr_data.status + "</td>";
            append += "<td>" + osr_data.updater + "</td>";
            append += "<td>" + osr_data.dateUpdated + "</td>";
            append += "<td>" + "" + "</td>";
            append += "<td>" + osr_data.remarks + "</td>";
            append += "<td>" + osr_data.reasonToChangeExpectedDateOfSetup + "</td>";
            append += "<td>" + osr_data.releasedTo + "</td>";
            append += "</tr>";

        });
        $("#history-data").append(append);

    });
}

if (ActionName == "history_cents") {

        $.post(
        base_url + "Dashboard/get_osr_cents_history",
        {
            "osr_id": idNumber
        },
        function (data) {
            var append = "";
            var color = "";
            var font = "";


            $.each(data, function (i, osr_data) {
                if (osr_data.status == "FOR PREPARATION") {
                    color = "background-color: #d6d8d9";
                    font = "color: black;"
                }
                else if (osr_data.status == "ON GOING PREPARATION") {
                    color = "background-color: #fff3cd";
                    font = "color: #856404;"
                }
                else if (osr_data.status == "READY FOR BUY OFF") {
                    color = "background-color: #cce5ff;";
                    font = "color: #004085;";
                }
                else if (osr_data.status == "FORM CANCELLED") {
                    color = "background-color: #f8d7da;";
                    font = "color: #721c24;";
                }
                else if (osr_data.status == "RELEASED") {
                    color = "background-color: #d4edda;";
                    font = "color: #155724;";
                }

                append += "<tr>";
                append += "<td>" + osr_data.m3Number + "</td>";
                append += "<td>" + osr_data.socketID + "</td>";
                append += "<td>" + osr_data.handlerID + "</td>";
                append += "<td>" + osr_data.handlerModel + "</td>";
                append += "<td>" + osr_data.package + "</td>";
                //append += "<td>" + osr_data.dateRequest + "</td>";
                //append += "<td>" + osr_data.expectedDateOfSetup + "</td>";
                //append += "<td>" + osr_data.shift + "</td>";
                append += "<td>" + osr_data.requestBy + "</td>";
                append += "<td style ='" + font + " " + color + "'>" + osr_data.status + "</td>";
                append += "<td>" + osr_data.updater + "</td>";
                append += "<td>" + osr_data.dateUpdated + "</td>";
                append += "<td>" + "" + "</td>";
                append += "<td>" + osr_data.remarks + "</td>";
                append += "<td>" + osr_data.reasonToChangeExpectedDateOfSetup + "</td>";
                append += "<td>" + osr_data.releasedTo + "</td>";
                append += "</tr>";

            });
            $("#history-data").append(append);

        });
 
}
