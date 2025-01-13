<?php
    
    require_once('ExternalData.php');

    // Single line comment
    # Single line comment - Another version to add Comment
    /*
        Multi line comments 
    */
    // Declare a variable to name
    $name = "Harsimranjot";
    // error_log will be your friend in debugging your code.
    error_log("Insert a entry into error log file");

    $numbers = array(1,2,3,4); // Creating an array to store some numbers

    /*************************************
     * Function     : UserData
     * Purpose      : To print user Data
     * Inputs       : No
     * Output       : void
     **************************************/
    function UserData()
    {
        global $name; 
        // To access global variables inside a funciton, you need to mention the scope 

        echo "<br>Inside Function Userdata Your name = $name";

        # or super global array                             $GLOBALS[indexnameofvariable]                   
        echo "<br> Inside function Userdata Your name = " . $GLOBALS['name']; 
    }
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
            
            error_log("Before accessing array element");
            echo "<br> Value of element at index position 0 : " . $numbers[0]; 

            // Call your function
            UserData();

            // Try to access data from external file. 
            echo "<br>Your age is = $age";

            // Try to call MakeArray()

            $collection = MakeArray(7);

            // Print this list
            $list = "<ul>";

            foreach($collection as $key => $value)
            {
                $list .= "<li> $key = $value </li>";
            }
            // Regular form of concat

            $list = $list . "</ul>";
            // shortcut form of Concat
            //$list .= "</ul>";

            // Add the list to your page
            echo $list;
        ?>

        <footer>
            <?
                // Used to include stuff from another file
                
                require_once('footer.php');
                //include('footer.php');
                /*
                    The only difference is that include statement 
                    generates a warning or alert but PHP script will keep running
                    if that file is missing
                    On the other hand, require_once() will generate fatal error
                    and it will terminate the script

                    Recommended: Use require_once in all cases from security point of view
                */
            ?>
        </footer>
    </body>
</html>