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

                else if (osr_data.status == "RELEASED" || osr_data.status == "FORM CANCELLED") {
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

    $.post(
        base_url + "Dashboard/calendar",
        function (calendar_data) {

            console.log("calendar", calendar_data);

            var calendarEl = document.getElementById('calendar');

            var calendar = new FullCalendar.Calendar(calendarEl, {
                plugins: ['interaction', 'dayGrid', 'timeGrid', 'list', ],
                droppable: true,
                editable: true,
                header: {
                    left: 'prev,next today',
                    center: 'title',
                    right: 'dayGridMonth,timeGridWeek,timeGridDay,listMonth'
                },
                defaultView: 'dayGridMonth',
                //height: 850,
                events: calendar_data,
                eventLimit: true,
                views: {
                    timeGrid: {
                        eventLimit: 6 // adjust to 6 only for timeGridWeek/timeGridDay
                    }
                }
            });

            calendar.render();

            //document.addEventListener('DOMContentLoaded', function () {
                

               
            //});
        });




}

if (compare_url == "OSRBURNIN") {
   
    $.post(
        base_url + "Dashboard/get_osr_burnin_dashboard",
        function (data) {
            var color = "";
            var font = "";
            var pending = "";
            var released = "";
            append_val = 0;
            $.each(data, function (i, osr_data) {

                if (osr_data.status != "RELEASED" && osr_data.status != "FORM CANCELLED") {
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
                    pending += "<td><button class='btn btn-primary dl-button' id='download-button' data-get-document='" + osr_data.id + "'><i class='fa fa-download'></i></button></td>";
                    pending += "</tr>";

                }

                else if (osr_data.status == "RELEASED" || osr_data.status == "FORM CANCELLED") {
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

}

//$(document).ready(function () {
//    Chart.defaults.global.defaultFontFamily = '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
//    Chart.defaults.global.defaultFontColor = '#292b2c';

//    var ControllerName = '@ViewBag.ControllerName';
//    var ActionName = '@ViewBag.ActionName';
//    var idNumber = '@ViewBag.idNumber';
//    var FFID = '@ViewBag.userFFID';

//    $(document).ready(function () {
//        var ctx = document.getElementById("ChartTester");
//        var myChart = new Chart(ctx, {
//            type: 'bar',
//            data: {
//                labels: ['Monday', 'Tuesday', 'Wednesday', 'Thrusday', 'Friday', 'Saturday', 'Sunday'],
//                datasets: [{
//                    label: '# of Failed Forms',
//                    data: [12, 19, 3, 5, 2, 3, 9],
//                    backgroundColor: [
//                        'rgba(255, 99, 132, 0.2)',
//                        'rgba(54, 162, 235, 0.2)',
//                        'rgba(255, 206, 86, 0.2)',
//                        'rgba(75, 192, 192, 0.2)',
//                        'rgba(153, 102, 255, 0.2)',
//                        'rgba(255, 159, 64, 0.2)',
//                        'rgba(255, 159, 64, 0.2)'
//                    ],
//                    borderColor: [
//                        'rgba(255, 99, 132, 1)',
//                        'rgba(54, 162, 235, 1)',
//                        'rgba(255, 206, 86, 1)',
//                        'rgba(75, 192, 192, 1)',
//                        'rgba(153, 102, 255, 1)',
//                        'rgba(255, 159, 64, 1)',
//                        'rgba(255, 159, 64, 1)'
//                    ],
//                    borderWidth: 1
//                }]
//            },
//            options: {
//                scales: {
//                    yAxes: [{
//                        ticks: {
//                            beginAtZero: true
//                        }
//                    }]
//                }
//            }
//        });

//        $.post(
//            base_url + "Dashboard/get_chart_result",
//            function (data) {
//                console.log(data);
//            }
//        );
//    });
//});


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

$(document).on("click", "#data-extraction-redirect", function (e) {
    e.preventDefault();
    window.open(base_url + "Dashboard/archive");
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

//$(document).on("click", "#osr_data", function () {
//    var repair_id = $(this).attr("data-repair-id");
   
//});
