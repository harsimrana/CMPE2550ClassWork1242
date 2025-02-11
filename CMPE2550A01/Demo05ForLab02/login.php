<?php

?>

<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Login Page</title>
        
        <!--Link to css-->
        <link rel="stylesheet" href="styles.css">
    </head>
    <body>
        <h1> Login page</h1>

        <form action="login.php" method="POST">

        <label for="username">Username</label>
        <input type="text" name="username" placeholder="Enter your username">

        <label for="password">Password</label>
        <input type="password" name="password">

        <input type="submit" value ="Login">
        <input type="reset" value="reset">
        <input type="button" value= "Register">


        </form>
    </body>
</html>