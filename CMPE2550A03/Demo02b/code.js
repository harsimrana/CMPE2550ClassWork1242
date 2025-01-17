// To handle on page load stuff
$().ready( ()=> {
    console.log("On page load");

    $("#b1").on("click", ()=>{
        console.log("B1 has been clicked");
    });
})

// function to handle successful response for B1 button
function successB1(serverData, serverStatus)
{
    console.log("Inside Success handler");
    console.log(serverData);
    console.log(serverStatus);
}

function errorHandler(ajaxReq, ajaxStatus, errorThrown)
{
    console.log("Inside error handler function");
    console.log(serverData);
    console.log(errorThrown);
}

// MakeAjaxCall is used to make an ajax call
function MakeAjaxCall(serverURL, reqMethod, serverResponse, data, Successhandler, Errorhander)
{
    console.log("inside MakeAjaxCall function")';

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