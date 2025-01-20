<?php
    // start/rejoin a session
    session_start();
    
    if(isset($_SESSION['count']))
    {
        $_SESSION['count']++;
    }
    else
    {
        $_SESSION['count'] = 1;
    }
    $count = 0;
    // Entry into error log
    error_log("Inside server file");

    // validate the request 
    if($_SERVER['REQUEST_METHOD'] == "GET")
    {
        if(isset($_GET['action']) && $_GET['action']=="b2")
        { // request from b2 button
            $cleanName = strip_tags( trim( $_GET['p1Name']) );
            $_SESSION['count']++;

            echo "Hello $cleanName from server side. Call number". $_SESSION['count'];
        } 
        else if(isset($_GET['action']) && $_GET['action']=="b3")
        { // request from b3 button
            $cleanName = strip_tags( trim( $_GET['p1Name']) );
            $score = 6;
            $_SESSION['count']++;

            $data = (object) [
                'name'      => $cleanName,
                'score'     => $score,
                'nextTurn'  => 2,
                'Count'     => $_SESSION['count']
            ];
            //Convert an object into string
            // PHP json_encode() - converts a object into a string

            error_log(json_encode($data));

            // Returning data back to client
            echo json_encode($data);
            die();
            
            
        }
        else if(isset($_GET['action']) && $_GET['action']=="b4")
        { // request from b4 button
            
            // To delete all your session variables
            session_unset();

            // To destroy the session
            session_destroy();
            echo "Session clear";
        } 
        else
        { // Request from b1 button
            //To send data back to client 
            $count++;
            echo "hello message from server side call Count". $_SESSION['count']; 
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