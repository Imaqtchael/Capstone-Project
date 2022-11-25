<?php

    if ($_POST['functionname'] == 'getAllList') {
        getAllList();
    } elseif ($_POST['functionname'] == 'getThis') {
        $type = $_POST['arguments'][0];
        $search = $_POST['arguments'][1];
        getThis($type, $search);
    } elseif ($_POST['functionname'] == 'uploadData') {
        $connectionResult = array();
        $connectionResult['result'] = json_decode($_POST['arguments'], true);

        echo json_encode($connectionResult);
    }

    function insertData(data) {
        $connection = new mysqli("localhost", "root", "", "real_capstone");

        if ($connection -> connect_errno) {
            echo "<script>alert('Failed to connect to database')</script>";
            exit();
        }

        $sql = "INSERT INTO events SET(registered, date, time, type, booker)"

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