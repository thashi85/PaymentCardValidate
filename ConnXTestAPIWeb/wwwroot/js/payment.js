$(document).ready(function () {
    console.log("ready!");

    $("#form").submit(function (event) {
        $("#error").hide();
        $("#success").hide();
        if ($("#exampleInputCard").val().length == 0) {
            $("#error").html("Card number cannot be empty");
            $("#error").show();
            return false;
        } else {
            let postData = {
                "CardType": $("#cardType").val(),
                "CardNumber": $("#exampleInputCard").val()
            }
            $.ajax({
                url: WebAPIUrl + "api/V1.0/payments/card-types/validate",
                type: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(postData),
                success: function (response) {
                    console.log(response)
                    if (response && response.status) {
                        if (response.status.isError != undefined && !response.status.isError && response.data && response.data.isValid) {
                            $("#success").html("Valid Card");
                            $("#success").show();
                        } else {
                            if (response.data && response.data.errorDetails) {
                                let err = ""
                                response.data.errorDetails.forEach(a => {
                                    if (err.length > 0)
                                        err += " ";
                                    if (a.errorCode)
                                        err += a.errorCode + " : " + a.description
                                    else if (a.description)
                                        err += a.description
                                });
                                $("#error").html("Invalid:" + err);
                                $("#error").show();
                            } else {
                                $("#error").html("Invalid");
                                $("#error").show();
                            }
                        }
                    } else {
                        $("#error").html("Invalid");
                        $("#error").show();
                    }
                  
                },
                error: function () {
                    $("#error").html("Error Occured");
                    $("#error").show();
                }
                
            });
        }

       
        event.preventDefault();
    });
});