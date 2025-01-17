<?php
    error_log("Inside Server.php");
    error_log(json_encode( $_GET));

    // Valdiate your request
    if($_SERVER['REQUEST_METHOD']== "GET")
    {
        // Whether request is from B1 or B2 button
        if( strip_tags( $_GET['action']) == "b2")
        {
            // Validate sanitize your data

            session_start();
            $_SESSION['p1Name'] = strip_tags(trim($_GET['p1Name'])); 
            $_SESSION['p2Name'] = strip_tags(trim($_GET['p2Name'])); 
            $_SESSION['gameBoard'] = array();

            error_log(json_encode( $_SESSION));

            // returning response back to client
            echo "Player  ". $_SESSION['p1Name'] ." will go first ";
        }
        else // otherwise it is b1 button
        {
        
            $string = "Welcome to server side";
            $string .= "Current Turn: 1";

            echo $string;  // Point to return HTML data back to client
        }
    }
    else
    {
        echo "No my friend you are not allowed";
    }
?>