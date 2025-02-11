<?php

    // Hashing the password
    // password_hash(ActualPassword, Encryption Algo)

    $secret = password_hash("Simran123", PASSWORD_DEFAULT);

    error_log(" Excrypted Password: " . $secret );

    // password_verify(regularpassword, encrypted one inside database)


    function LoginCheck($user, $pass)
    {
        // bring your username and password from DB
        global $secret;

        if($user == "Simran" && password_verify($pass, $secret))
        {
            return true;
        }
        return false
       
    }


?>