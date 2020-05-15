if (compare_url == "OSR") {

    $.post(
        base_url + "Dashboard/get_osr_dashboard",
        {
            "data_check": compare_url
        },
        function (data) {
            var color = "";
            var font = "";
            var pending = "";
            var released = "";
            append_val = 0;

            $.each(data["pending"], function (i, osr_data) {
           
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
                pending += "<td><button class='btn btn-primary btn-sm dl-button' id='download-button' data-get-document='" + osr_data.id + "'><i class='fa fa-download'></i></button></td>";
                pending += "</tr>";
              
            });

            $("#pending-data").append(pending);

            $.each(data["archive"], function (i, osr_data) {

                if (osr_data.status == "RELEASED") {
                    color = "background-color: #d4edda;";
                    font = "color: #155724;"
                }

                else if (osr_data.status == "FORM CANCELLED") {
                    color = "background-color: #f8d7da;";
                    font = "color: #721c24;"
                }
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
                released += "<td data-osr-id='" + osr_data.id + "' style='" + color +""+ font +"'>" + osr_data.status + "</td>";
                released += "<td><button class='btn btn-primary btn-sm dl-button' id='download-button' data-get-document='" + osr_data.id + "'><i class='fa fa-download'></i></button></td>";
                released += "</tr>";

            });

            $("#released-data").append(released);

            $(document).ready(function () {
                $('#pending').DataTable({
                    dom: '<".top"B>frt<".bottom"p>',
                    order: [],
                    buttons: [{
                        extend: 'excel', title: '', text: '<i class="fas fa-download"></i> Export to Excel', className: 'button_color btn-sm', filename: function () {
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
                        extend: 'excel', title: '', text: '<i class="fas fa-download"></i> Export to Excel', className: 'button_color btn-sm', filename: function () {
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
                $.post(
                    base_url + "Dashboard/report",
                    function (report) {
                       
                        $("#released-count-saturday").html(report["firstDay"].released);
                        $("#released-count-sunday").html(report["secondDay"].released);
                        $("#released-count-monday").html(report["thirdDay"].released);
                        $("#released-count-tuesday").html(report["fourthDay"].released);
                        $("#released-count-wednesday").html(report["fifthDay"].released);
                        $("#released-count-thursday").html(report["sixthDay"].released);
                        $("#released-count-friday").html(report["seventhDay"].released);
                        $("#released-count").html(report["overall"].released);

                        $("#cancelled-count-saturday").html(report["cancelledFirstDay"].released);
                        $("#cancelled-count-sunday").html(report["cancelledSecondDay"].released);
                        $("#cancelled-count-monday").html(report["cancelledThirdDay"].released);
                        $("#cancelled-count-tuesday").html(report["cancelledFourthDay"].released);
                        $("#cancelled-count-wednesday").html(report["cancelledFifthDay"].released);
                        $("#cancelled-count-thursday").html(report["cancelledSixthDay"].released);
                        $("#cancelled-count-friday").html(report["cancelledSeventhDay"].released);
                        $("#cancelled-count").html(report["cancelledOverall"].released);

                    });
                $(".loader").hide();
            });
        });

    $(document).on("click", "#download-button", function () {
  
        var id = $(this).attr("data-get-document");
        
        $.post(
            base_url + "Form/get_osr_documents",
            {
                "osr_id": id,
                "data_check": compare_url
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

if (compare_url == "OSRBURNIN") {
   
    $.post(
        base_url + "Dashboard/get_osr_dashboard",
        {
            "data_check":compare_url
        },
        function (data) {
            var color = "";
            var font = "";
            var pending = "";
            var released = "";
            append_val = 0;
            console.log(data);
            $.each(data["pending"], function (i, osr_data) {
              
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
                    pending += "<tr id='osr_data' class='loadboard_data' style='cursor: pointer; data-osr-id='" + osr_data.id + "'>";
                    pending += "<td data-osr-id='" + osr_data.id + "'><p><a href='history_burnin/" + osr_data.m3Number + "' target='_blank' style='color:blue'>" + osr_data.m3Number + "</a></p></td>";
                    pending += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.handlerID + "</td>";
                    pending += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.package + "</td>";
                    pending += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.family + "</td>";
                    pending += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.process + "</td>";
                    pending += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.dateRequest + "</td>";
                    pending += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.expectedDateOfSetup + "</td>";
                    pending += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.shift + "</td>";
                    pending += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.requestBy + "</td>";
                    pending += "<td data-osr-id='" + osr_data.id + "' style ='" + font + " " + color + "'>" + osr_data.status + "</td>";
                    pending += "<td><button class='btn btn-primary btn-sm dl-button' id='download-button' data-get-document='" + osr_data.id + "'><i class='fa fa-download'></i></button></td>";
                    pending += "</tr>";
               
            });

            $("#pending-data").append(pending);

            $.each(data["archive"], function (i, osr_data) {

                if (osr_data.status == "RELEASED") {
                    color = "background-color: #d4edda;";
                    font = "color: #155724;"
                    //background-color: #d4edda; color: #155724
                }
                else if (osr_data.status == "FORM CANCELLED") {
                    color = "background-color: #f8d7da;";
                    font = "color: #721c24;"
                }
                released += "<tr id='osr_data' class='loadboard_data' data-osr-id='" + osr_data.id + "'>";
                released += "<td data-osr-id='" + osr_data.id + "'><p><a href='history_burnin/" + osr_data.m3Number + "' target='_blank' style='color:blue'>" + osr_data.m3Number + "</a></p></td>";
                released += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.handlerID + "</td>";
                released += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.package + "</td>";
                released += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.family + "</td>";
                released += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.process + "</td>";
                released += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.dateRequest + "</td>";
                released += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.expectedDateOfSetup + "</td>";
                released += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.shift + "</td>";
                released += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.requestBy + "</td>";
                released += "<td data-osr-id='" + osr_data.id + "' style='" + color + "" + font + "'>" + osr_data.status + "</td>";
                released += "<td><button class='btn btn-primary btn-sm dl-button' id='download-button' data-get-document='" + osr_data.id + "'><i class='fa fa-download'></i></button></td>";
                released += "</tr>";

            });

            $("#released-data").append(released);

            $(document).ready(function () {
                $('#pending').DataTable({
                    dom: '<".top"B>frt<".bottom"p>',
                    order: [],
                    buttons: [{
                        extend: 'excel', title: '', text: '<i class="fas fa-download"></i> Export to Excel', className: 'button_color btn-sm', filename: function () {
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
                        extend: 'excel', title: '', text: '<i class="fas fa-download"></i> Export to Excel', className: 'button_color btn-sm', filename: function () {
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
                $.post(
                    base_url + "Dashboard/report_burnin",
                    function (report) {
                        $("#released-count-saturday").html(report["firstDay"].released);
                        $("#released-count-sunday").html(report["secondDay"].released);
                        $("#released-count-monday").html(report["thirdDay"].released);
                        $("#released-count-tuesday").html(report["fourthDay"].released);
                        $("#released-count-wednesday").html(report["fifthDay"].released);
                        $("#released-count-thursday").html(report["sixthDay"].released);
                        $("#released-count-friday").html(report["seventhDay"].released);
                        $("#released-count").html(report["overall"].released);

                        $("#cancelled-count-saturday").html(report["cancelledFirstDay"].released);
                        $("#cancelled-count-sunday").html(report["cancelledSecondDay"].released);
                        $("#cancelled-count-monday").html(report["cancelledThirdDay"].released);
                        $("#cancelled-count-tuesday").html(report["cancelledFourthDay"].released);
                        $("#cancelled-count-wednesday").html(report["cancelledFifthDay"].released);
                        $("#cancelled-count-thursday").html(report["cancelledSixthDay"].released);
                        $("#cancelled-count-friday").html(report["cancelledSeventhDay"].released);
                        $("#cancelled-count").html(report["cancelledOverall"].released);
                    });
                $(".loader").hide();
            });
        });

    $(document).on("click", "#download-button", function () {

        var id = $(this).attr("data-get-document");

        $.post(
            base_url + "Form/get_osr_documents",
            {
                "osr_id": id,
                "data_check": compare_url

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

}

if (compare_url == "OSRQFN") {

    $.post(
        base_url + "Dashboard/get_osr_dashboard",
        {
            "data_check":compare_url
        },

        function (data) {
            var color = "";
            var font = "";
            var pending = "";
            var released = "";
            append_val = 0;

            $.each(data["pending"], function (i, osr_data) {

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

                pending += "<tr id='osr_data' class='loadboard_data' style='cursor: pointer; data-osr-id='" + osr_data.id + "'>";
                pending += "<td data-osr-id='" + osr_data.id + "'><p><a href='history_qfn/" + osr_data.m3Number + "' target='_blank' style='color:blue'>" + osr_data.m3Number + "</a></p></td>";
                pending += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.testerID + "</td>";
                pending += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.handlerID + "</td>";
                pending += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.package + "</td>";
                pending += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.family + "</td>";
                pending += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.process + "</td>";
                pending += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.dateRequest + "</td>";
                pending += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.expectedDateOfSetup + "</td>";
                pending += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.shift + "</td>";
                pending += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.requestBy + "</td>";
                pending += "<td data-osr-id='" + osr_data.id + "' style ='" + font + " " + color + "'>" + osr_data.status + "</td>";
                pending += "<td><button class='btn btn-primary btn-sm dl-button' id='download-button' data-get-document='" + osr_data.id + "'><i class='fa fa-download'></i></button></td>";
                pending += "</tr>";

            });

            $("#pending-data").append(pending);

            $.each(data["archive"], function (i, osr_data) {

                if (osr_data.status == "RELEASED") {
                    color = "background-color: #d4edda;";
                    font = "color: #155724;"
                }

                else if (osr_data.status == "FORM CANCELLED") {
                    color = "background-color: #f8d7da;";
                    font = "color: #721c24;"
                }
                released += "<tr id='osr_data' class='loadboard_data' data-osr-id='" + osr_data.id + "'>";
                released += "<td data-osr-id='" + osr_data.id + "'><p><a href='history_qfn/" + osr_data.m3Number + "' target='_blank' style='color:blue'>" + osr_data.m3Number + "</a></p></td>";
                released += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.testerID + "</td>";
                released += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.handlerID + "</td>";
                released += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.package + "</td>";
                released += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.family + "</td>";
                released += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.process + "</td>";
                released += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.dateRequest + "</td>";
                released += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.expectedDateOfSetup + "</td>";
                released += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.shift + "</td>";
                released += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.requestBy + "</td>";
                released += "<td data-osr-id='" + osr_data.id + "' style='" + color + "" + font + "'>" + osr_data.status + "</td>";
                released += "<td><button class='btn btn-primary btn-sm dl-button' id='download-button' data-get-document='" + osr_data.id + "'><i class='fa fa-download'></i></button></td>";
                released += "</tr>";

            });

            $("#released-data").append(released);

            $(document).ready(function () {
                $('#pending').DataTable({
                    dom: '<".top"B>frt<".bottom"p>',
                    order: [],
                    buttons: [{
                        extend: 'excel', title: '', text: '<i class="fas fa-download"></i> Export to Excel', className: 'button_color btn-sm', filename: function () {
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
                        extend: 'excel', title: '', text: '<i class="fas fa-download"></i> Export to Excel', className: 'button_color btn-sm', filename: function () {
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
                $.post(
                    base_url + "Dashboard/report_qfn",
                    function (report) {

                        $("#released-count-saturday").html(report["firstDay"].released);
                        $("#released-count-sunday").html(report["secondDay"].released);
                        $("#released-count-monday").html(report["thirdDay"].released);
                        $("#released-count-tuesday").html(report["fourthDay"].released);
                        $("#released-count-wednesday").html(report["fifthDay"].released);
                        $("#released-count-thursday").html(report["sixthDay"].released);
                        $("#released-count-friday").html(report["seventhDay"].released);
                        $("#released-count").html(report["overall"].released);

                        $("#cancelled-count-saturday").html(report["cancelledFirstDay"].released);
                        $("#cancelled-count-sunday").html(report["cancelledSecondDay"].released);
                        $("#cancelled-count-monday").html(report["cancelledThirdDay"].released);
                        $("#cancelled-count-tuesday").html(report["cancelledFourthDay"].released);
                        $("#cancelled-count-wednesday").html(report["cancelledFifthDay"].released);
                        $("#cancelled-count-thursday").html(report["cancelledSixthDay"].released);
                        $("#cancelled-count-friday").html(report["cancelledSeventhDay"].released);
                        $("#cancelled-count").html(report["cancelledOverall"].released);

                    });
                $(".loader").hide();
            });
        });

    $(document).on("click", "#download-button", function () {

        var id = $(this).attr("data-get-document");

        $.post(
            base_url + "Form/get_osr_documents",
            {
                "osr_id": id,
                "data_check": compare_url
            },
            function (data_document) {


                if (data_document != "") {
                    $.each(data_document, function (i, document) {
                        //document_append += "<a class='document-attachment' href='/uploads/osr/" + document.item_name + "' target='_blank'>" + document.item_name + "</a>"
                        window.open("/uploads/osr_qfn/" + document.item_name, "_blank");
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

if (compare_url == "OSR_CENTS") {

    $.post(
        base_url + "Dashboard/get_osr_dashboard",
        {
            "data_check": compare_url
        },
        function (data) {
            var color = "";
            var font = "";
            var pending = "";
            var released = "";
            append_val = 0;

            $.each(data["pending"], function (i, osr_data) {

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

                pending += "<tr id='osr_data' class='loadboard_data' style='cursor: pointer; data-osr-id='" + osr_data.id + "'>";
                pending += "<td data-osr-id='" + osr_data.id + "'><p><a href='history_cents/" + osr_data.m3Number + "' target='_blank' style='color:blue'>" + osr_data.m3Number + "</a></p></td>";
                pending += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.socketID + "</td>";
                pending += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.handlerID + "</td>";
                pending += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.handlerModel + "</td>";
                pending += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.package + "</td>";
                pending += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.dateRequest + "</td>";
                pending += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.expectedDateOfSetup + "</td>";
                pending += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.requestBy + "</td>";
                pending += "<td data-osr-id='" + osr_data.id + "' style ='" + font + " " + color + "'>" + osr_data.status + "</td>";
                pending += "</tr>";

            });

            $("#pending-data").append(pending);

            $.each(data["archive"], function (i, osr_data) {

                if (osr_data.status == "RELEASED") {
                    color = "background-color: #d4edda;";
                    font = "color: #155724;"
                }

                else if (osr_data.status == "FORM CANCELLED") {
                    color = "background-color: #f8d7da;";
                    font = "color: #721c24;"
                }
                released += "<tr id='osr_data' class='loadboard_data' data-osr-id='" + osr_data.id + "'>";
                released += "<td data-osr-id='" + osr_data.id + "'><p><a href='history_cents/" + osr_data.m3Number + "' target='_blank' style='color:blue'>" + osr_data.m3Number + "</a></p></td>";
                released += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.socketID + "</td>";
                released += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.handlerID + "</td>";
                released += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.handlerModel + "</td>";
                released += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.package + "</td>";
                released += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.dateRequest + "</td>";
                released += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.expectedDateOfSetup + "</td>";
                released += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.requestBy + "</td>";
                released += "<td data-osr-id='" + osr_data.id + "' style='" + color + "" + font + "'>" + osr_data.status + "</td>";
                released += "</tr>";

            });

            $("#released-data").append(released);

            $(document).ready(function () {
                $('#pending').DataTable({
                    dom: '<".top"B>frt<".bottom"p>',
                    order: [],
                    buttons: [{
                        extend: 'excel', title: '', text: '<i class="fas fa-download"></i> Export to Excel', className: 'button_color btn-sm', filename: function () {
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
                        extend: 'excel', title: '', text: '<i class="fas fa-download"></i> Export to Excel', className: 'button_color btn-sm', filename: function () {
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
                $.post(
                    base_url + "Dashboard/report_cents",
                    function (report) {

                        $("#released-count-saturday").html(report["firstDay"].released);
                        $("#released-count-sunday").html(report["secondDay"].released);
                        $("#released-count-monday").html(report["thirdDay"].released);
                        $("#released-count-tuesday").html(report["fourthDay"].released);
                        $("#released-count-wednesday").html(report["fifthDay"].released);
                        $("#released-count-thursday").html(report["sixthDay"].released);
                        $("#released-count-friday").html(report["seventhDay"].released);
                        $("#released-count").html(report["overall"].released);

                        $("#cancelled-count-saturday").html(report["cancelledFirstDay"].released);
                        $("#cancelled-count-sunday").html(report["cancelledSecondDay"].released);
                        $("#cancelled-count-monday").html(report["cancelledThirdDay"].released);
                        $("#cancelled-count-tuesday").html(report["cancelledFourthDay"].released);
                        $("#cancelled-count-wednesday").html(report["cancelledFifthDay"].released);
                        $("#cancelled-count-thursday").html(report["cancelledSixthDay"].released);
                        $("#cancelled-count-friday").html(report["cancelledSeventhDay"].released);
                        $("#cancelled-count").html(report["cancelledOverall"].released);

                    });
                $(".loader").hide();
            });
        });

    $(document).on("click", "#download-button", function () {

        var id = $(this).attr("data-get-document");

        $.post(
            base_url + "Form/get_osr_documents",
            {
                "osr_id": id,
                "data_check": compare_url
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

$(document).on("click", "#redirect-dashboard-burn-in", function (e) {
    e.preventDefault();
    window.location.href = base_url + "Dashboard/OSRBURNIN";
});

$(document).on("click", "#redirect-create-form-burn-in", function (e) {
    e.preventDefault();
    window.location.href = base_url + "Form/CreateOSRBurnIn";
});

$(document).on("click", "#redirect-pending-task-burn-in", function (e) {
    e.preventDefault();
    window.open(base_url + "Dashboard/liveupdatesBurnIn");
});

$(document).on("click", "#redirect-dashboard-qfn", function (e) {
    e.preventDefault();
    window.location.href = base_url + "Dashboard/OSRQFN";
});

$(document).on("click", "#redirect-create-form-qfn", function (e) {
    e.preventDefault();
    window.location.href = base_url + "Form/CreateOSRQFN";
});

$(document).on("click", "#redirect-pending-task-qfn", function (e) {
    e.preventDefault();
    window.open(base_url + "Dashboard/liveupdatesQFN");
});

$(document).on("click", "#redirect-data-extraction", function (e) {
    e.preventDefault();
    window.open(base_url + "Dashboard/data_extraction");
});

$(document).on("click", "#redirect-data-extraction_burnin", function (e) {
    e.preventDefault();
    window.open(base_url + "Dashboard/data_extraction_burnin");
});

$(document).on("click", "#redirect-data-extraction_qfn", function (e) {
    e.preventDefault();
    window.open(base_url + "Dashboard/data_extraction_qfn");
});

$(document).on("click", "#redirect-data-extraction-cents", function (e) {
    e.preventDefault();
    window.open(base_url + "Dashboard/data_extraction_cents");
});

$(document).on("click", "#redirect-dashboard-cents", function (e) {
    e.preventDefault();
    window.location.href = base_url + "Dashboard/OSR_CENTS";
});

$(document).on("click", "#redirect-create-form-cents", function (e) {
    e.preventDefault();
    window.location.href = base_url + "Form/CreateOSRCents";
});

$(document).on("click", "#redirect-pending-task-cents", function (e) {
    e.preventDefault();
    window.location.href = base_url + "Dashboard/liveupdatesCENTS"
})

//$(document).on("click", "#osr_data", function () {
//    var repair_id = $(this).attr("data-repair-id");
   
//});
