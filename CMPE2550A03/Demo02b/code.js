// To handle on page load stuff
$().ready( ()=> {
    console.log("On page load");

    $("#b1").on("click", ()=>{
        console.log("B1 has been clicked");
    });
})