<?php
/*
    API - Application programming Interface 
    REST API  [Representaional State Transfer]
        - 1. Stateless communication: NO sessions
        - 2. Resources - Data and services  
        - 3. HTTP Methods - GET, POST, PUT, DELETE
        - 4. Standard Data Format - JSON, XML
        - 5. Uniform interface  -- URI [Uniform Resource Indentifier]
*/

?>
<!DOCTYPE html>
<html>
    <head>
        <title>CMPE2550 REST DEMO</title>
        <meta charset="UTF-8">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
        <script type="text/javascript" src="stuff.js"></script>
        <style>
            div a:link, div a:visited{
                font-size:0.8em;
            }
        </style>
    </head>
    <body>
        <h1>CMPE2550 for Lab03 - Winter 2025</h1><hr/>
       
        
        <input type="button" id="testGET" value="GET">
        <input type="button" id="testPOST" value="POST">
        <input type="button" id="testPUT" value="PUT">
        <input type="button" id="testDELETE" value="DELETE">

        <hr/>
        <div id="output">
            
        </div>
    </body>
</html>