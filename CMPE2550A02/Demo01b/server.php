<?php
    // Step 1: Validation : validate the data and request itself coming from client side
    /*
     isset()- function checks whether or not a variable is set
     which means it has to be declared and is not null
    */

    if(isset($_GET['username']) && strlen($_GET['username'])>0)
    {
        
        // Step 2: Sanitize your inputs
        /* Need to sanitize your data on server side
            trim()- clean white spaces from both sides of the input
            strip_tags()- strip a string from HTML, XML, PHP or other tags 
        */
        error_log("Before cleaning ". $_GET['username']);
        // stt is user defined function defined at the bottom of this file. No GOOGLE search
        $cleanName = stt($_GET['username']);  
        $cleanAge =  stt($_GET['userage']);  
        
        error_log("After cleaning ". $cleanName);

        echo "<br>Welcome to server side";
        echo "<br>User Details";
        echo "<br>Username: ". $cleanName;
        echo "<br>UserAge: ". $cleanAge;
    }
    else
    {
        echo "Sorry you are not allowed. Provide valid data or enjoy the winter outside!";
    }

    /*************************************
     * Function     : stt
     * Purpose      : user defined function to clean inputs
     * Inputs       : string
     * Output       : Cleaned string
     **************************************/

    function stt($input)
    {
        return strip_tags(trim($input));
    }
?>