if (compare_url == "DATA_EXTRACTION") {
    $.post(
        base_url + "Dashboard/data_extraction_extract",
        function (data) {
            var append = "";
            $.each(data["osr"], function (i, osr_data) {
                //console.log(osr_data);
                append += "<tr id='osr_data' class='loadboard_data' style='cursor: pointer; data-osr-id='" + osr_data.id + "'>";
                append += "<td data-osr-id='" + osr_data.id + "'><p><a href='history/" + osr_data.m3Number + "' target='_blank' style='color:blue'>" + osr_data.m3Number + "</a></p></td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.testerID + "</td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.handlerID + "</td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.package + "</td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.family + "</td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.process + "</td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.dateRequest + "</td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.expectedDateOfSetup + "</td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.shift + "</td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.requestBy + "</td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.status + "</td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.releasedTo + "</td>";
                append += "</tr>";
              
                //$.post(
                //    base_url + "Dashboard/get_released_to_data_from_data_extract",
                //    {
                //        "m3Number": osr_data.m3Number
                //    },
                //    function (releasedToData)
                //    {
                //        console.log(releasedToData);
                //        $("#released-to-data").val(releasedToData.releasedTo);
                //    }
                //    );
            });
            $("#data-extraction-data").append(append);
            $(".loader").hide();
            $('#data-extraction').DataTable({
                dom: '<".top"B>frt<".bottom"p>',
                order: [],
                buttons: [{
                    extend: 'excel', title: '', text: '<i class="fas fa-download"></i> Export to Excel', className: 'button_color btn-sm', filename: function () {
                        var d = new Date();
                        return 'REPORT-' + d;
                    },
                    exportOptions: {
                        //columns: 'th:not(:last-child)'
                    }
                }],
                language: {
                    searchPlaceholder: "Search Records"
                },
                autoWidth: true
            });
        }
    );
}

else if (compare_url == "DATA_EXTRACTION_BURNIN") {
    $.post(
        base_url + "Dashboard/data_extraction_extract",
        function (data) {
            var append = "";
            $.each(data["osr_burnin"], function (i, osr_data) {
                //console.log(osr_data);
                append += "<tr id='osr_data' class='loadboard_data' style='cursor: pointer; data-osr-id='" + osr_data.id + "'>";
                append += "<td data-osr-id='" + osr_data.id + "'><p><a href='history/" + osr_data.m3Number + "' target='_blank' style='color:blue'>" + osr_data.m3Number + "</a></p></td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.testerID + "</td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.handlerID + "</td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.package + "</td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.family + "</td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.process + "</td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.dateRequest + "</td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.expectedDateOfSetup + "</td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.shift + "</td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.requestBy + "</td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.status + "</td>";
                append += "</tr>";
            });
            $("#data-extraction-data-burnin").append(append);
            $(".loader").hide();
            $('#data-extraction-burnin').DataTable({
                dom: '<".top"B>frt<".bottom"p>',
                order: [],
                buttons: [{
                    extend: 'excel', title: '', text: '<i class="fas fa-download"></i> Export to Excel', className: 'button_color btn-sm', filename: function () {
                        var d = new Date();
                        return 'REPORT-' + d;
                    },
                    exportOptions: {
                        //columns: 'th:not(:last-child)'
                    }
                }],
                language: {
                    searchPlaceholder: "Search Records"
                },
                autoWidth: true
            });
        }
    );

}

if (compare_url == "DATA_EXTRACTION_QFN") {
    $.post(
        base_url + "Dashboard/data_extraction_extract",
        function (data) {
            var append = "";
            $.each(data["osr_qfn"], function (i, osr_data) {
                //console.log(osr_data);
                append += "<tr id='osr_data' class='loadboard_data' style='cursor: pointer; data-osr-id='" + osr_data.id + "'>";
                append += "<td data-osr-id='" + osr_data.id + "'><p><a href='history/" + osr_data.m3Number + "' target='_blank' style='color:blue'>" + osr_data.m3Number + "</a></p></td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.testerID + "</td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.handlerID + "</td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.package + "</td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.family + "</td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.process + "</td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.dateRequest + "</td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.expectedDateOfSetup + "</td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.shift + "</td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.requestBy + "</td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.status + "</td>";
                append += "</tr>";
            });
            $("#data-extraction-data").append(append);
            $(".loader").hide();
            $('#data-extraction-qfn').DataTable({
                dom: '<".top"B>frt<".bottom"p>',
                order: [],
                buttons: [{
                    extend: 'excel', title: '', text: '<i class="fas fa-download"></i> Export to Excel', className: 'button_color btn-sm', filename: function () {
                        var d = new Date();
                        return 'REPORT-' + d;
                    },
                    exportOptions: {
                        //columns: 'th:not(:last-child)'
                    }
                }],
                language: {
                    searchPlaceholder: "Search Records"
                },
                autoWidth: true
            });
        }
    );
}

if (compare_url == "DATA_EXTRACTION_CENTS") {
    $.post(
        base_url + "Dashboard/data_extraction_extract",
        function (data) {
            var append = "";
            $.each(data["osr_cents"], function (i, osr_data) {
                //console.log(osr_data);
                append += "<tr id='osr_data' class='loadboard_data' style='cursor: pointer; data-osr-id='" + osr_data.id + "'>";
                append += "<td data-osr-id='" + osr_data.id + "'><p><a href='history_cents/" + osr_data.m3Number + "' target='_blank' style='color:blue'>" + osr_data.m3Number + "</a></p></td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.socketID + "</td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.handlerID + "</td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.handlerModel + "</td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.package + "</td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.dateRequest + "</td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.expectedDateOfSetup + "</td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.shift + "</td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.requestBy + "</td>";
                append += "<td data-osr-id='" + osr_data.id + "'>" + osr_data.status + "</td>";
                append += "</tr>";
            });
            $("#data-extraction-data").append(append);
            $(".loader").hide();
            $('#data-extraction').DataTable({
                dom: '<".top"B>frt<".bottom"p>',
                order: [],
                buttons: [{
                    extend: 'excel', title: '', text: '<i class="fas fa-download"></i> Export to Excel', className: 'button_color btn-sm', filename: function () {
                        var d = new Date();
                        return 'REPORT-' + d;
                    },
                    exportOptions: {
                        //columns: 'th:not(:last-child)'
                    }
                }],
                language: {
                    searchPlaceholder: "Search Records"
                },
                autoWidth: true
            });
        }
    );
}