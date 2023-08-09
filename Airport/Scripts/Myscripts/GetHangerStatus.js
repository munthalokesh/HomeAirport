$(function () {

    //Detect changes in the email field
    $("#Btnstatus").click(function () {
        
        var HangerId = $("#SelectedPlaneId").val();
        var fromdate = $("#fromdate").val();
        var todate = $("#todate").val();
        alert(HangerId + fromdate + todate);
        //alert(email);
        // Perform validation or other checks if needed
        // Then send the email value to the controller using AJAX
        $.ajax({
            url: "https://localhost:44304/api/HangerDetails/GetStatus?HangerId=" + HangerId + "&fromdate=" + fromdate + "&todate=" + todate,
            type: 'GET',
            contentType: "application/json;charset=utf-8",
            success: function (data) {
                var location=$("#L"+HangerId).val();
                var capacity = $("#C" + HangerId).val();
                alert(location + capacity);
                $("#AvailableHangers").empty();
                $("#AvailableHangers").append("<tr><td>HangerId</td><td>HangerLocation</td><td>PlaneId</td><td>FromDate</td><td>ToDate</td><td>Status</td></tr>");
                if (data != null) {
                    for (var i = 0; i < data.length; i++) {
                        $("#AvailableHangers").append("<tr><td>" + data[i].HangerId + "</td><td>" + data[i].HangerLocation + "</td><td>" + data[i].PlaneId + "</td><td>" + data[i].FromDate + "</td><td>" + data[i].ToDate +"</td><td>Booked</td></tr>");
                    }
                    
                }
                alert(data.length);
                for (var i = 0; i < capacity - data.length; i++) {
                    
                    $("#AvailableHangers").append("<tr><td>" + HangerId + "</td><td>" + location + "</td><td>No Plane </td><td>" + fromdate + "</td><td>" + todate + "</td><td>Available</td></tr>");
                }
            },
            error: function (x, err) {
                alert(x.readyState);
                alert(x.responseText);
                alert("Owner not found kindly please enter the details")
                

            }

        });
    });

})
