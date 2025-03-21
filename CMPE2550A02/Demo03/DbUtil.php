<?php
// Database connection information
$mysql_connection= null;


/*****************************************
 * Function Name    :  mySQLConnection: to establish a connection to DB
 * Inputs           :  No 
 * Output           :  No
 ****************************************/
function  mySQLConnection()
{
    // Grab hold to global variable inside function
    global $mysql_connection;
    
    // Try to connect to DB
    /*
        mysqli()
        1. URL of Server
        2. Datebase
        3. Username
        4. Password
    */
                            //      DB SERVER,    USERNAME                  Password    , Database name
    $mysql_connection = new mysqli ("localhost", "aulakhha_2550A02Admin", '[*C7FPr$$$eR', "aulakhha_cmpe2550A02DB"); 

    if($mysql_connection -> connect_errno)
    {
        error_log("Connection errror");
        die(); 
    }
    // If you are here
    error_log("Connection is successful");

} 
/*****************************************
 * Function Name    :  mySelectQuery: to execute retrieval queries
 * Inputs           :  Query
 * Output           :  ResultSet or false
 ****************************************/

function mySelectQuery($myquery)
{
    // Grab hold to global variable inside function
    global $mysql_connection;
    
    // query function - returns result set or false

    if( !($result = $mysql_connection -> query($myquery)) )
    {
        //Error 
        error_log("Error while executing query");
        return false;
    }
    else
    {
        // All good
        // return the results back to calling location
        error_log("Inside DBUtil file before returning data");
        return $result;
    }

}

?>