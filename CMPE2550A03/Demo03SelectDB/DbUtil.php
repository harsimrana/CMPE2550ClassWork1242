<?php

/****************************************
 * Function Name    : mySQLConnection: To connect to DB
 * Inputs           : No
 * Output           : No
 ****************************************/
function mySQLConnection()
{
    // Try to connect to Db here
    /*
    1. Database you would like to connect 
    2. Username
    3. Password
    4. DB server URL
    */
                            //      DB Server,   Username              , Password,         DBName
    $mysql_connection = new mysqli("localhost", "aulakhha_2550A03Admin", "WY!4{eGk#^HK", "aulakhha_2550A03DB");

    if($mysql_connection -> connect_errno)
    {
        error_log("Connection error");
        die();
    }
    // if you are here
    error_log("Connection is successful");

}

// Testing my function 

//mySQLConnection();
?>