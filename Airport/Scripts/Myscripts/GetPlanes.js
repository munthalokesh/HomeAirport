$(function () {

    //Detect changes in the email field
    $("#GetAvailablePlanes").click(function () {
        var HangerId = $("#Book").val();
        //alert(email);
        // Perform validation or other checks if needed
        // Then send the email value to the controller using AJAX
        alert(HangerId);
        var fromdate = $("input[name='fromdate']").val();
        var todate = $("input[name='todate']").val();
        alert(fromdate + todate);
        alert($("input[name='L" + HangerId + "']").val());
        var query =
            $.ajax({
                url: "/Hanger/GetPlanes?FromDate=" + fromdate + "&ToDate=" + todate,
            type: 'Get',
            dataType: "json",
            contentType: "application/json;charset=utf-8",
            success: function (data) {
                var successModel = $("#successModal");
                var modalBody = $('#successModal .modal-body');
                modalBody.empty();

                if (data != null) {
                    var location = "<p>" + $("input[name='L" + HangerId + "']").val() + "</p>";
                    var capacity = "<p>" + HangerId + "</p>";

                    modalBody.append(location);
                    modalBody.append(capacity);

                    modalBody.append("<p class='d-none text-danger'id='selectPlane'>Required</p>");
                    var select = $("<select name='SelectedPlaneId' class='form-control'><option value=' '>Select a plane</option></select>");

                    for (var i = 0; i < data.length; i++) {
                        select.append("<option value='" + data[i].PlaneId + "'>" + data[i].PlaneId + "</option>");
                    }

                    modalBody.append(select);
                    $('#errorModal').modal('hide');
                    $('#successModal').modal('show');
                }
                else {
                    var modalBody = $('#errorModal .modal-body');
                    modelBody.append("No Plane Available between " + fromdate + " to " + todate);
                    $('#successModal').modal('hide');
                    $('#errorModal').modal('show');
                }
            },
                error: function (x, err) {
                    var modalBody = $('#errorModal .modal-body');
                    modalBody.append("No Plane Available between " + fromdate + " to " + todate);
                    $('#successModal').modal('hide');
                    $('#errorModal').modal('show');
                alert(x.readyState);
                alert(x.responseText);
                
               

            }

        });
    });
    $("#BookHanger").click(function () {
        if ($("#selectPlane").val() == " ") {
            alert("hi");
            $("#selectPlane").removeClass("d-none");
        }
        else {
            $("#selectPlane").addClass("d-none");
            alert(fromdate);
        }
    })

})
