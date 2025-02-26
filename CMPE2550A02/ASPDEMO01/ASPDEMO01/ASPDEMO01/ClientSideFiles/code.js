//JS file

$().ready(()=>{
    console.log("On Page Load");

    // Bind event to event listener

    $("[name=postSubmit]").click(PostSubmit);

})

function PostSubmit()
{
    console.log("In post Submit");

    let url= "https://localhost:7090/registerPost";

    let data={};

    data.postFirst = $("[name=postFirst]").val();
    data.postColor = $("[name=postColor]").val();
    data.postAge = $("[name=postAge]").val();

    console.log(data);

    // Make Ajax call here for HTML Part -- Uncomment the following line and make changes on Server side as well
    // CallAjax(url, "HTML", data, "POST", SuccessPost, ErrorHandler);
    
    // Make Ajax call here for JSON Part -- Uncomment the following line and make changes on Server side as well
    CallAjax(url, "JSON", data, "POST", SuccessPost, ErrorHandler);
}

function SuccessPost(serverData, serverStatus)
{
    console.log(serverData);
    console.log(serverData.status);  // Object style dot notaion
    console.log(serverData['count']); // Array style 
}

function ErrorHandler(ajReq, SerStatus, ErrorThrown)
{
    console.log(SerStatus);
    console.log(ErrorThrown);
}
function CallAjax(url, dataType, reqData, reqMethod, SuccessFxn, errorFxn)
{
    console.log("inside call ajax function");

    let ajOp={};

    ajOp['url']         = url; // URL of SERVER
    ajOp['data']        = JSON.stringify(reqData); // NEW for ASP PART
    ajOp['dataType']    = dataType;
    ajOp['type']        = reqMethod;
    ajOp['success']     = SuccessFxn;
    ajOp['error']       = errorFxn;
    ajOp['contentType'] = "application/json";       // New For ASP PART

    console.log(ajOp);

    $.ajax(ajOp);
}