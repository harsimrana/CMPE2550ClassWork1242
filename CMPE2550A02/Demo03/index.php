<?php
    // ALWAY use require_once because it will terminate the script if the file is missing
    require_once('DbUtil.php');

?>
<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Demo 03: Database Retrieval</title>
    </head>
    <body>
        <header>
            <h1>Week 05: Day 01: Demo 03: 03 Feb 2025: DataBase Retrieval part</h1>
        </header>
        <main>
            <?php
             // Step 1: Connect to DB
             mySQLConnection();
            
             // Step 2: Prepare your query 
                $query = "select * from Student ";

                error_log($query);

                $resultset = mySelectQuery($query);

                // fetch_assoc() - returns one row at a time as an object
                while( $row = $resultset-> fetch_assoc() )
                {
                    echo $row['sid']."<br>";
                }
            ?>
        </main>
        <footer>

        </footer>
    </body>
</html>