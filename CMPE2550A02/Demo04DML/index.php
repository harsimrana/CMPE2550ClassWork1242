<?php
    // ALWAY use require_once because it will terminate the script if the file is missing
    require_once('DbUtil.php');

?>
<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Demo 04: DML</title>
    </head>
    <body>
        <header>
            <h1>Week 05: Day 03: Demo 04: 05 Feb 2025: DML Operations</h1>
        </header>
        <main>
            <?php
            // RETRIEVAL PART

             // Step 1: Connect to DB
             mySQLConnection();
            
             // Step 2: Prepare your query 
                $query = "select * from Student ";

                error_log($query);

                $resultset = mySelectQuery($query);
                //Header row
                echo "Sid   |  Sname  |   SEmail   | SPhone <br>";

                // fetch_assoc() - returns one row at a time as an object
                while( $row = $resultset-> fetch_assoc() )
                {
                    echo $row['sid']. " | ". $row['sname']. " | " . $row['semail']. " | ". $row['sphone']."<br>";
                }


                // PART 2: DML operations
                //SPECIAL NOTE: DO not run delete/ update without where clause
               /*
                $query = "delete from Student ";
                $query .= "Where sid = 1";

                error_log($query);

                // Execute query directly from PHP code
                $dbResponse = mysqlNonQuery($query);
                if($dbResponse== false)
                {
                    echo $mysql_response;    
                }
                else{
                    echo "Delete operation has affected $dbResponse rows.";
                }
                */
                $name = "Harsimran'jot";


                // real_escape_string()

                $name = $mysql_connection-> real_escape_string( trim( strip_tags($name) ) ); 

                // Insert and update part
                 $query = "update Student ";  // Observe space at the end of the string because we are splitting our query across multiple line
                 $query .= "set sname = '$name' ";
                 $query .= "where sid = 5 ";
                // Testing it with Stored procedure

                // To call your SP syntax
                // call SP_Name (Parameters)
                $query = "call UpdateStudent('$name', 5) ";

                 error_log($query);

                 // Execute query directly from PHP code
                 $dbResponse = mysqlNonQuery($query);
                 if($dbResponse== false)
                 {
                     echo $mysql_response;    
                 }
                 else{
                     echo "Update operation has affected $dbResponse rows.";
                 }
            ?>
        </main>
        <footer>

        </footer>
    </body>
</html>