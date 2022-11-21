<?php

    if ($_POST['functionname'] == 'getAllList') {
        getAllList();
    } elseif ($_POST['functionname'] == 'getThis') {
        $type = $_POST['arguments'][0];
        $search = $_POST['arguments'][1];
        getThis($type, $search);
    }

    function getAllList() {
        $connection = new mysqli("localhost", "root", "", "real_capstone");
        $connectionResult = array();

        if ($connection -> connect_errno) {
            echo "<script>alert('Failed to connect to database')</script>";
            exit();
        }

        $sql = "SELECT name, time, due, price FROM events";
        $result = $connection->query($sql);
    
        $data = $result->fetch_all(MYSQLI_ASSOC);

        $connectionResult['result'] = $data;

        echo json_encode($connectionResult);

    }

    function getThis($type, $search) {
        $connection = new mysqli("localhost", "root", "", "real_capstone");
        $connectionResult = array();

        if ($connection -> connect_errno) {
            echo "<script>alert('Failed to connect to database')</script>";
            exit();
        }

        $sql = "SELECT * FROM events WHERE {$type} LIKE '%{$search}%'";
        $result = $connection->query($sql);
    
        $data = $result->fetch_all(MYSQLI_ASSOC);

        $connectionResult['result'] = $data;

        echo json_encode($connectionResult);
    }
?>