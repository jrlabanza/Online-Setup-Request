if (compare_url == "OSR") {
    $.post(
        base_url + "Dashboard/get_osr_dashboard",
        function (data) {
            var color = "";
            var font = "";
            var pending = "";
            var released = "";
            append_val = 0;
            $.each(data, function (i, osr_data) {

                if (osr_data.status != "RELEASED" && osr_data.status != "FORM CANCELLED") {
                    if (osr_data.status == "FOR PREPARATION")
                    {
                        color = "background-color: #d6d8d9";
                        font = "color: black;"
                    }
                    else if (osr_data.status == "ON GOING PREPARATION")
                    {
                        color = "background-color: #fff3cd";
                        font = "color: #856404;"
                    }
                    else if (osr_data.status == "READY FOR BUY OFF") {
                        color = "background-color: #cce5ff;";
                        font = "color: #004085;";
                    }
                    pending += "<tr id='osr_data' class='loadboard_data' style='cursor: pointer; data-osr-id='" + osr_data.id + "'>";
                    pending += "<td data-osr-id='" + osr_data.id + "'><p><a href='history/" + osr_data.m3Number + "' target='_blank' style='color:blue'>" + osr_data.m3Number + "</a></p></td>";
                    pending += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.testerID + "</td>";
                    pending += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.handlerID + "</td>";
                    pending += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.package + "</td>";
                    pending += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.family + "</td>";
                    pending += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.process + "</td>";
                    pending += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.dateRequest + "</td>";
                    pending += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.expectedDateOfSetup + "</td>";
                    pending += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.shift + "</td>";
                    pending += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.requestBy + "</td>";
                    pending += "<td data-osr-id='" + osr_data.id + "' style ='" + font + " "+ color +"'>" + osr_data.status + "</td>";
                    pending += "<td><button class='btn btn-primary dl-button' id='download-button' data-get-document='" + osr_data.id + "'><i class='fa fa-download'></i></button></td>";
                    pending += "</tr>";

                }

                else if (osr_data.status == "RELEASED" && osr_data.status != "FORM CANCELLED") {
                    released += "<tr id='osr_data' class='loadboard_data' data-osr-id='" + osr_data.id + "'>";
                    released += "<td data-osr-id='" + osr_data.id + "'><p><a href='history/" + osr_data.m3Number + "' target='_blank' style='color:blue'>" + osr_data.m3Number + "</a></p></td>";
                    released += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.testerID + "</td>";
                    released += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.handlerID + "</td>";
                    released += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.package + "</td>";
                    released += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.family + "</td>";
                    released += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.process + "</td>";
                    released += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.dateRequest + "</td>";
                    released += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.expectedDateOfSetup + "</td>";
                    released += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.shift + "</td>";
                    released += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.requestBy + "</td>";
                    released += "<td data-osr-id='" + osr_data.id + "' style='background-color: #d4edda; color: #155724'>" + osr_data.status + "</td>";
                    released += "<td><button class='btn btn-primary dl-button' id='download-button' data-get-document='" + osr_data.id + "'><i class='fa fa-download'></i></button></td>";
                    released += "</tr>";
                }
            });

            $("#pending-data").append(pending);

            $("#released-data").append(released);

            $('#pending').DataTable({
                dom: '<".top"B>frt<".bottom"p>',
                order: [],
                buttons: [{
                    extend: 'excel', title: '', text: '<i class="fas fa-download"></i>', className: 'mb-1 button_color', filename: function () {
                        var d = new Date();
                        return 'REPORT-' + d;
                    },
                    exportOptions: {
                        columns: 'th:not(:last-child)'
                    }
                }],
                language: {
                    searchPlaceholder: "Search Records"
                },
                autoWidth: true
            });

            $('#released').DataTable({
                dom: '<".top"B>frt<".bottom"p>',
                order: [],
                buttons: [{
                    extend: 'excel', title: '', text: '<i class="fas fa-download"></i>', className: 'mb-1 button_color', filename: function () {
                        var d = new Date();
                        return 'REPORT-' + d;
                    },
                    exportOptions: {
                        columns: 'th:not(:last-child)'
                    }
                }],
                language: {
                    searchPlaceholder: "Search Records"
                },
                autoWidth: true
            });
        });

    $(document).on("click", "#download-button", function () {
  
        var id = $(this).attr("data-get-document");
        
        $.post(
            base_url + "Form/get_osr_documents",
            {
                "osr_id": id
            },
            function (data_document) {

                if (data_document != "")
                {
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

}

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
    base_url + "Dashboard/get_osr_history",
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
            append += "<td>" + osr_data.releasedTo + "</td>";
            append += "</tr>";
          
        });
        $("#history-data").append(append);

        $('#pending').DataTable({
            dom: '<".top"B>frt<".bottom"p>',
            order: [],
            ordering: false,
            paging:false,
            buttons: [{
                extend: 'excel', title: '', text: '<i class="fas fa-download"></i>', className: 'mb-1 button_color', filename: function () {
                    var d = new Date();
                    return 'OSR-' + d;
                }
            }],
            
        });
    });


}

$(document).on("click", "#redirect-dashboard", function (e) {
    e.preventDefault();
    window.location.href = base_url + "Dashboard/OSR";
});

$(document).on("click", "#redirect-create-form", function (e) {
    e.preventDefault();
    window.location.href = base_url + "Form/CreateOSR";
});

$(document).on("click", "#redirect-pending-task", function (e) {
    e.preventDefault();
    window.open(base_url + "Dashboard/liveupdates");
});

//$(document).on("click", "#osr_data", function () {
//    var repair_id = $(this).attr("data-repair-id");
   
//});
