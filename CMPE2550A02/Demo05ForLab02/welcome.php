<?php
    session_start(); // create or rejoin a session

    if(isset($_SESSION['username']))
    {
        echo "Welcome to my website : " . $_SESSION['username'];
    }
    else
    {
        echo "Sorry you are not authorized to see the stuff on this page";
        die();
        header('Location:login.php');  // Redirect the user back to login page.
    }

?>

<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Welcome Page</title>
    </head>
    <body>
      <a href="logout.php">logout</a>
    </body>
</html>