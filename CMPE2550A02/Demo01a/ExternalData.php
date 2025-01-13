<?php

    // Library for PHP functions and other data items

    $age = 42;

    /*************************************
     * Function     : MakeArray
     * Purpose      : To create an array to store stars
     * Inputs       : INT: Number of stars
     * Output       : An array
     **************************************/
    function MakeArray($quantity)
    {
        $stars = array(); // Creating an empty array

        for($i = 0; $i <= $quantity; ++$i)
        {
            $stars[] = "*";  // without index, it will still add element into the list    
        }

        // Return the whole array back to calling location
        return $stars;  
    }
?>