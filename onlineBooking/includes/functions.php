<?php
    if (isset($_POST['functionname'])) {
        if ($_POST['functionname'] == 'insertData') {
            $json = $_POST['arguments'];
            insertData($json);
        } elseif ($_POST['functionname'] == 'checkIfPaid') {
            $eventName = $_COOKIE['eventName'];
            checkIfPaid($eventName, $_POST['arguments']);
        } elseif ($_POST['functionname'] == 'getAllDates') {
            getAllDates();
        }
    }

    function checkIfPaid($eventName, $from) {
        $connection = new mysqli("localhost", "root", "", "real_capstone");
        $connresult = array();

        if ($connection -> connect_errno) {
            echo "<script>alert('Network error')</script>";
            exit();
        }

        $sql = "SELECT ispaid FROM events WHERE name='{$eventName}'";

        $result = $connection->query($sql);
        $result = $result->fetch_array(MYSQLI_NUM);

        if ($result[0] == 1) {
            $connresult['result'] = "true";
            if ($from == 'php') {
                return true;
            } else {
                echo json_encode($connresult);
            }
        } else {
            $connresult['result'] = "false";
            if ($from == 'php') {
                return false;
            } else {
                echo json_encode($connresult);
            }
        }

    }

    function insertData($data) {
        $connection = new mysqli("localhost", "root", "", "real_capstone");

        $sql = "SELECT guests_id FROM events WHERE name='{$_COOKIE['eventName']}'";
        $result = $connection->query($sql);
        $result = $result->fetch_array(MYSQLI_NUM);

        $guests_id = $result[0];

        if ($connection -> connect_errno) {
            echo "<script>alert('Failed to connect to database')</script>";
            exit();
        }

        $personData = json_decode($data, true);

        $sql = "INSERT INTO guest (guest_id, name, address, email, number, type) VALUES";

        foreach($personData as $person) {
            # Get informations from person
            $name = $person['name'];
            $address = $person['address'];
            $email = $person['email'];
            $number = $person['number'];

            $new_sql = " ({$guests_id}, '{$name}', '{$address}', '{$email}', '{$number}', 'GUEST'),";

            $sql = "{$sql}{$new_sql}";
        }

        $sql = substr($sql, 0, -1);

        $result = $connection->query($sql);

        if ($result == TRUE) {
            setcookie('eventName', null, time() - 86400, '/');
            unset($_COOKIE['eventName']);

            echo "Guest submission success!";
        } else {
            echo "Guest submission failed!";
        }

    }

    function getAllDates() {
        $connection = new mysqli("localhost", "root", "", "real_capstone");
        $connectionResult = array();

        $sql = "SELECT date FROM events";
        $result = $connection->query($sql);
        while ($row = $result->fetch_array(MYSQLI_NUM)) {
            $connectionResult[] = date("Y/m/d", strtotime($row[0]));
        }
        #$result = $result->fetch_array(MYSQLI_NUM);

        #$counter = 0;
        #foreach ($result as $date) {
        #    $connectionResult[$counter] = $date;
        #}

        echo json_encode($connectionResult);
    }
?>