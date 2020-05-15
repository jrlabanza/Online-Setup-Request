if (compare_url == "CreateOSR") {

    $.post(
    base_url + "Dashboard/m3_number_by_id",
    function (data) {
        
        var m3gen = parseInt(data.id) + 1;
        var m3num = "";
        
        if ($.isNumeric(data.id)) {
            if (data.id <= 9) {
                var m3num = "M3000" + m3gen;
            }
            else if (data.id <= 99) {
                var m3num = "M300" + m3gen;
            }
            else if (data.id <= 999) {
                var m3num = "M30" + m3gen;
            }
            else {
                var m3num = "M3" + m3gen;
            }
        }
        else {
            
            var m3num = "M30001";
        }


        
        $("#m3-number").val(m3num);
    }
    )

    $('.customdate').daterangepicker({
        "singleDatePicker": true,
        "showDropdowns": true,
        "timePicker24Hour": true,
        "timePicker": true,
        "autoApply": true,

        locale: {
            format: "YYYY-MM-DD h:mm"
        }

    },
    function (start, end, label) {
        console.log('New date range selected: ' + start.format('YYYY-MM-DD') + ' to ' + end.format('YYYY-MM-DD') + ' (predefined range: ' + label + ')');
    });

    $.post(
        base_url + "Dashboard/get_tester_id",
        function (data)
        {
            var append = "";
            $.each(data, function (i, tester_id) {
                var tstID = tester_id.TEST;
                append += "<option>" + tstID.toUpperCase() + "</option>";
            })
            $("#tester-id-datalist").append(append);
        }
    )
    //HANDLER TST

    //$.post(
    //    base_url + "Dashboard/get_handler_id",
    //    function (data)
    //    {
    //        var append = "";
    //        $.each(data, function (i, handler_id) {
    //            var hdID = handler_id.HAND;
    //            append += "<option>" + hdID.toUpperCase() + "</option>";
    //        })
    //        $("#handler-id-datalist").append(append);
    //    }
    //)

    //HANDLER XFN

    $.post(
    base_url + "Dashboard/get_handler_id_xfn",
    function (data) {
        var append = "";
        $.each(data, function (i, handler_id) {
            var hdID = handler_id.Equipt_ID;
            append += "<option>" + hdID.toUpperCase() + "</option>";
        })
        $("#handler-id-datalist").append(append);
    }
    )

//    $.post(
//    base_url + "Dashboard/get_device",
//    function (data) {
//        var append = "";
//        $.each(data, function (i, device) {
//            var hdID = device.DEVICE;
//            append += "<option>" + hdID.toUpperCase() + "</option>";
//        })
//        $("#family").append(append);
//    }
//)

    $.post(
    base_url + "Dashboard/get_process",
    function (data) {
        var append = "";
        $.each(data, function (i, process_id) {
            //var hdID = process_id.process;
            append += "<option>" + process_id.process + "</option>";
        })
        $("#process").append(append);
    }
    )

    $(".custom-file-input").on("change", function () {
        var fileName = $(this).val().split("\\").pop();
        var fileLen = this.files.length
        $(this).siblings(".custom-file-label").addClass("selected").html(fileLen + " FILE/S SELECTED");
    });

    $(document).on("keyup change select", "#tester-id", function () {
        var testerID = $("#tester-id").val();
        $.post(
            base_url + "Dashboard/get_handler_id_from_tester_id",
            {
                "testerID": testerID
            },
            function (data) {
                $("#handler-id").val(data.Handler_ID);
                //$("#package").val(data.pkg_type);
            }
            )
    });

    $(document).on("keyup change select", "#handler-id", function () {
        var handlerID = $("#handler-id").val();
        $.post(
            base_url + "Dashboard/get_tester_id_from_handler_id",
            {
                "handlerID": handlerID
            },
            function (data) {
                $("#tester-id").val(data.TesterID);
                //$("#package").val(data.pkg_type);
            }
            )
    });

    $(document).on("keyup change select", "#family", function () {
        var familyID = $("#family").val();
        $.post(
            base_url + "Form/get_package_from_family",
            {
                "familyID": familyID
            },
            function (data) {
                $("#package").val(data.Pkg_Type);
            }
            )
    });


    $("#create-form-osr").on('click', function (e) {
        e.preventDefault();
        if ($("#tester-id").val() == "" || $("#handler-id").val() == "" || $("#family").val() == "" || $("#package").val() == "" || $("#process").val() == "") {

            $.notify({
                title: '<strong>PLEASE FILL UP ALL INFORMATION!</strong>',
                message: ""
            }, {
                type: 'danger'
            });
            setTimeout(function () {
                $.notifyClose('top-right');
            }, 1000);

            if ($("#tester-id").val() == "") {
                $("#tester-id").addClass("is-invalid").removeClass("is-valid");
            }
            else {
                $("#tester-id").addClass("is-valid").removeClass("is-invalid");
            }

            if ($("#handler-id").val() == "") {
                $("#handler-id").addClass("is-invalid").removeClass("is-valid");
            }
            else {
                $("#handler-id").addClass("is-valid").removeClass("is-invalid");
            }

            if ($("#family").val() == "") {
                $("#family").addClass("is-invalid").removeClass("is-valid");
            }
            else {
                $("#family").addClass("is-valid").removeClass("is-invalid");
            }

            if ($("#package").val() == "") {
                $("#package").addClass("is-invalid").removeClass("is-valid");
            }
            else {
                $("#package").addClass("is-valid").removeClass("is-invalid");
            }

            if ($("#process").val() == "") {
                $("#process").addClass("is-invalid").removeClass("is-valid");
            }
            else {
                $("#process").addClass("is-valid").removeClass("is-invalid");
            }

        }
        else {
            if ($("input#file-upload-osr")[0].files.length == 0) {
                $.notify({
                    title: '<strong>PLEASE ATTACH A DOCUMENT!</strong>',
                    message: ""
                }, {
                    type: 'danger'
                });
                setTimeout(function () {
                    $.notifyClose('top-right');
                }, 1000);
            }
            else
            {
                var testerID = $("#tester-id").val();
                var handlerID = $("#handler-id").val();
                var family = $("#family").val();
                var package = $("#package").val();
                var process = $("#process").val();
                var fileLen = $("input#file-upload-osr")[0].files.length;
                var expectedDateofSetup = $("#expected-date-of-setup").val();
                var shift = $("#shift").val();
                var status = $("#status").val();
                var formData = new FormData();
                var m3Number = $("#m3-number").val();
                OSR_DATA =
                {
                    "testerID": testerID.toUpperCase(),
                    "handlerID": handlerID.toUpperCase(),
                    "family": family.toUpperCase(),
                    "package": package.toUpperCase(),
                    "process": process.toUpperCase(),
                    "fileLen": fileLen,
                    "expectedDateofSetup": expectedDateofSetup,
                    "shift": shift.toUpperCase(),
                    "status": status,
                    "m3Number": m3Number
                }

                $.post(
                   base_url + "Form/OSRFormSubmit",
                   OSR_DATA,
                   function (data) {
                       console.log("ok");
                       var lastId = data.id;

                       //update m3 data here
                       //MUST GET LAST ID FROM PREVIOUS DATA
                       //if (data.id == null) {
                       //    var m3gen = "M30001";
                       //}
                       //else if (data.id <= 99) {
                       //    var m3gen = "M300" + lastId;
                       //}
                       //else if (data.id <= 999) {
                       //    var m3gen = "M30" + lastId;
                       //}
                       //else {
                       //    var m3gen = "M3" + lastId;
                       //}
                       //$.post(
                       //    base_url + "Form/OSRM3Number",
                       //    {
                       //        "m3gen": m3gen,
                       //        "id": lastId
                       //    },
                       //    function () {

                       //    }
                       // );

                       if (fileLen > 0) {
                           formData.append("fileLen", fileLen);
                           formData.append("lastId", lastId);
                           for (var i = 0; i < fileLen; i++) {
                               nameTmp = "osr_" + i;
                               formData.append(nameTmp, $("input#file-upload-osr")[0].files[i]);
                           }

                           var request = $.ajax({
                               url: base_url + "Form/UploadDocumentsOSR",
                               type: "post",
                               data: formData,
                               contentType: false,
                               cache: false,
                               processData: false
                           });

                           request.done(function (uploadImage) {

                               $.notify({
                                   title: '<strong>Success!</strong>',
                                   message: "Data has been inputted with upload. Returning to Dashboard"
                               }, {
                                   type: 'success',
                                   z_index: 9999
                               });
                               setTimeout(function () {
                                   $.notifyClose('top-right');
                                   window.location.href = base_url + "Dashboard/OSR";
                                   //window.close();
                               }, 3000);


                           });
                       }
                       else {
                           $.notify({
                               title: '<strong>Success!</strong>',
                               message: "Data has been inputted. Returning to Dashboard"
                           }, {
                               type: 'success',
                               z_index: 9999
                           });
                           setTimeout(function () {
                               $.notifyClose('top-right');
                               window.location.href = base_url + "Dashboard/OSR";
                               //window.close();
                           }, 3000);
                       }
                   }
               )
            }
        }
    });

}