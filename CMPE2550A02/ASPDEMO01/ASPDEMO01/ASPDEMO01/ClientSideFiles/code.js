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

    // Make Ajax call here
    CallAjax(url, "HTML", data, "POST", SuccessPost, ErrorHandler);
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