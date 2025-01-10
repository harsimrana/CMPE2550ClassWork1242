<?php
    // Single line comment
    # Single line comment - Another version to add Comment
    /*
        Multi line comments 
    */
    // Declare a variable to name
    $name = "Harsimranjot";
    // error_log will be your friend in debugging your code.
    error_log("Insert a entry into error log file");
?>
<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Demo 01a PHP</title>
    </head>
    <body>
        <h1>Demo 01: CMPE2550: A02 Section </h1>
        <?php 
            echo "<p> Printing the value of name variable: $name </p> ";
            
        ?>
    </body>
</html>