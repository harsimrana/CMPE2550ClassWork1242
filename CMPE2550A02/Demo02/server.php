<?php

    // Entry into error log
    error_log("Inside server file");

    // validate the request 
    if($_SERVER['REQUEST_METHOD'] == "GET")
    {
        if(isset($_GET['action']) && $_GET['action']=="b2")
        { // request from b2 button
            $cleanName = strip_tags( trim( $_GET['p1Name']) );

            echo "Hello $cleanName from server side";
        } 
        else if(isset($_GET['action']) && $_GET['action']=="b3")
        { // request from b3 button
            $cleanName = strip_tags( trim( $_GET['p1Name']) );
            $score = 6;

            $data = (object) [
                'name'      => $cleanName,
                'score'     => $score,
                'nextTurn'  => 2 
            ];
            //Convert an object into string
            // PHP json_encode() - converts a object into a string

            error_log(json_encode($data));

            // Returning data back to client
            echo json_encode($data);
            die();
            
            
        } 
        else
        { // Request from b1 button
            //To send data back to client 
            echo "hello message from server side"; 
        }
    }
    else
    {
        echo "You are not authorized. Or check with Admin";
        
        // Redirect the user to any other page.
        header("Location:index.html");
    }

//echo "serverResponse";

?>