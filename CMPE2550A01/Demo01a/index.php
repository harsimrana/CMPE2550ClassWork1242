<?php
    // Single Line comment
    # Single line comment - Another Version to add single line comment
    /*
        Multi line comments using same style we used in Javascipt and C#
    */
    error_log("Inside Index.php file ");
    $name = "Harsimranjot";
    echo "Some stuff from PHP";
    $numbers= array(3,5,7,8); // An array to hold some int values

?>
<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Demo 01a PHP </title>
    </head>
    <body>
        <?php error_log("Value of Name variable $name" );?>
        <h1> <?php  echo "Demo 01a: $name"; ?></h1>

        <?php
            #For Error log
            error_log("Before printing array value"); // Your friend for debugging- same as console.log in Javacript
            echo "<p>Value at index postion 0 in my array: $numbers[0]</p>";
            // You can insert your variables directly inside your string

            // . (dot)  is used to concat strings

            echo "<p>Value at index position 0 in my array: ". $numbers[0]." </p>";
        ?>

    </body>
</html>