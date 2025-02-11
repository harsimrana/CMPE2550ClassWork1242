<?php

    // Hashing the password
    // password_hash(ActualPassword, Encryption Algo)

    $secret = password_hash("Simran123", PASSWORD_DEFAULT);

    error_log(" Excrypted Password: " . $secret );

    

?>