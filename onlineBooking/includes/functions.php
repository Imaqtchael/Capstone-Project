<?php

    if ($_POST['functionname'] == 'getAllList') {
        getAllList();
    }

    function getAllList() {
        $connection = new mysqli("localhost", "root", "", "capstone");
        $connectionResult = array();

        if ($connection -> connect_errno) {
            echo "<script>alert('Failed to connect to database')</script>";
            exit();
        }

        $sql = "SELECT * FROM sample_events";
        $result = $connection->query($sql);
    
        $data = $result->fetch_all(MYSQLI_ASSOC);

        $result = $result->fetch_array();

        $connectionResult['result'] = $result;

        print_r($data);
        #print_r($result);

        #echo json_encode($connectionResult);
    }

    getAllList();
?>