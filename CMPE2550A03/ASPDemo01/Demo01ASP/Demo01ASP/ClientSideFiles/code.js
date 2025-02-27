

function errorHandler(ajaxReq, ajaxStatus, errorThrown)
{
    console.log("Inside error handler function");
    console.log(ajaxStatus);
    console.log(errorThrown);
    $("#serverResponse").html(ajaxStatus);
}

// MakeAjaxCall is used to make an ajax call
function MakeAjaxCall(serverURL, reqMethod, serverResponse, data, Successhandler, Errorhander)
{
    console.log("inside MakeAjaxCall function");

    let ajaxOptions= {};
    ajaxOptions['url']      = serverURL;    // Destination URL
    ajaxOptions['data']     = data;         // Client Data sent to server
    ajaxOptions['type']     = reqMethod;    // GET/POST
    ajaxOptions['dataType'] = serverResponse;// HTML/ JSON
    ajaxOptions['success']  = Successhandler;// Function to call on successful attemp
    ajaxOptions['error']    = Errorhander;   // Callback function in case of an error
    
    //Actually making ajax call now

    $.ajax(ajaxOptions);

}