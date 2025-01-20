// To handle on page load stuff
$().ready(()=>{
   console.log("On page load"); 
    //Bind onclick event for button with id b1
    $("#b1").on("click", ()=>{
        console.log("B1 has been clicked");
        MakeAjaxCall("server.php", "GET", {}, "HTML", successB1, errorHandler);
    
    });

    //Bind onclick event for button with id b2
    $("#b2").on("click", ()=>{
        console.log("B2 has been clicked");

        // Preparing client data to be sent to server
        let data={};
        data['p1Name'] = "Harsimran";
        data['action'] = "b2";

        MakeAjaxCall("server.php", "GET", data, "HTML", successB1, errorHandler);
    
    });

    
    //Bind onclick event for button with id b3
    $("#b3").on("click", ()=>{
        console.log("B3 has been clicked");

        // Preparing client data to be sent to server
        let data={};
        data['p1Name'] = "Harsimran";
        data['action'] = "b3";
        
        MakeAjaxCall("server.php", "GET", data, "JSON", successB1, errorHandler);
    
    });

    //Bind onclick event for button with id b4
    $("#b4").on("click", ()=>{
        console.log("B4 has been clicked");

        // Preparing client data to be sent to server
        let data={};
        data['action'] = "b4";
        
        MakeAjaxCall("server.php", "GET", data, "HTML", successB1, errorHandler);
    
    });

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