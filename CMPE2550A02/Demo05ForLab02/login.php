<?php
    error_log("inside Login.php");
    if($_SERVER['REQUEST_METHOD']=='POST')
    {
        error_log("Inside main logic");
        // start a new session
        session_start();
        $cleanUserName = trim(strip_tags($_POST['username']));
        $cleanPassword = trim(strip_tags($_POST['password']));

        $_SESSION['username'] = $cleanUserName;

        // Write your logic to validate password
        // Compare for valid credentials 
        
        //Redirect the user to Welcome page
        header('Location:welcome.php');  // redirect the user to welcome.php

    }
?>

<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Login Page </title>

        <!-- Link to CSS-->
        <link rel="stylesheet" href="styles.css">

    </head>
    <body>
        <h1> Login Page</h1>
        <form action="login.php" method="POST">
            <label for="username"> Username</label>
            <input type="text" name="username" placeholder="Enter your username">

            <label for="password">Password</label>
            <input type="password" name="password" placeholder="Enter your password">

            <input type="submit" value="Login">
            <input type="reset" value ="Reset">
            <input type="button" value="Registration">
        </form>
    </body>
</html>