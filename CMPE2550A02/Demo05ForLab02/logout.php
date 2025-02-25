<?php
    session_start();  // Create a session or rejoin session 

    // To delete all your session variables
    session_unset();

    // To destroy the session   
    session_destroy();
    
    header('Location:login.php'); 

?>