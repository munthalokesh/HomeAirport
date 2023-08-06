$(function () {
    
     //Detect changes in the email field
    $("#Email").blur(function () {
        var email = $("#Email").val();
        //alert(email);
        // Perform validation or other checks if needed
        // Then send the email value to the controller using AJAX
        $.ajax({
            url: "/Plane/CheckingMail/",
            type: 'POST',
            dataType: "json",
            data: JSON.stringify({ "email": email }),
            contentType: "application/json;charset=utf-8",
            success: function (data) {
                if (data != null) {
                    $('#HouseNo').val(data.HouseNo);
                    $('#City').val(data.City);
                    $('#State').val(data.State);
                    $('#Country').val(data.Country);
                    $('#PinNo').val(data.PinNo);
                    $('#AddressLine').val(data.AddressLine);
                    $("#HouseNo").removeAttr("disabled");
                    $("#City").removeAttr("disabled");
                    $("#State").removeAttr("disabled");
                    $("#Country").removeAttr("disabled");
                    $("#PinNo").removeAttr("disabled");
                    $("#AddressLine").removeAttr("disabled");
                    
                }
            },
            error: function (x, err) {
                //alert(x.readyState);
                //alert(x.responseText);
                alert("Owner not found kindly please enter the details")
                $("#HouseNo").removeAttr("disabled");
                $("#City").removeAttr("disabled");
                $("#State").removeAttr("disabled");
                $("#Country").removeAttr("disabled");
                $("#PinNo").removeAttr("disabled");
                $("#AddressLine").removeAttr("disabled");
                
            }

        });
    });
    
})
