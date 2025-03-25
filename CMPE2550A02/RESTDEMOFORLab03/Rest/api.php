<?php
error_log("Inside API.php GET:".json_encode($_GET));
error_log("Inside API.php Request:".json_encode($_REQUEST['request']));

require_once 'apiDef.php';

try
{
    $API = new MyAPI($_REQUEST['request']);  // Pass the information to constructor
    error_log("Inside API.PHP after constructor call");
    echo $API->processAPI(); // Echo the data back to client
}
catch(Exception $e)
{
    echo json_encode(Array('error' => $e.getMessage()));
}