<?php

    session_start();

    if(isset($_SESSION['username']))
    {
        echo "Welcome to Dashboard page " . $_SESSION['username'];
    }
    else
    {
        echo "<br> Sorry my friend you can enjoy outside";
    }

?>