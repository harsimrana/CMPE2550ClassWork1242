// To handle on page load stuff
$().ready(()=>{
   console.log("On page load"); 
})

function successB1(serverData, serverStatus)
{
    console.log(serverData);
    console.log(serverStatus);
}

function errorHandler(ajaxReq, ajaxStatus, errorThrown) 
{
    console.log(ajaxStatus);
    console.log(errorThrown);
}

// Function MakeAjaxCall to handle all ajax calls

function MakeAjaxCall(serverURL, reqMethod, data, serverResponse, successHandler, errorHandler)
{
    console.log("Inside MakeAjax call");

    let ajaxOptions = {};
    ajaxOptions['url']      = serverURL;        // Destination URL
    ajaxOptions['type']     = reqMethod;        // GET/POST
    ajaxOptions['dataType'] = serverResponse;   // HTML/JSON
    ajaxOptions['data']     = data;             // Client data to be passed to server
    ajaxOptions['success']  = successHandler;   // Callback function to handle successful case
    ajaxOptions['error']    = errorHandler;     // Callback function for error handling

    // Make ajax
    $.ajax(ajaxOptions);

}