<?php
    $connection = new mysqli("localhost", "u608197321_van_", "~C3qt^9kZ", "u608197321_real_capstone");
    #$connection = new mysqli("localhost", "root", "", "local_copy");
    if (isset($_POST['functionname'])) {
        if ($_POST['functionname'] == 'insertData') {
            insertData();
        } elseif ($_POST['functionname'] == 'checkIfPaid') {
            $eventName = $_COOKIE['eventName'];
            
            checkIfPaid($eventName, $_POST['arguments']);
        } elseif ($_POST['functionname'] == 'getAllDates') {
            getAllDates();
        } elseif ($_POST['functionname'] == 'checkForEvents') {
            checkForEvents();
        } elseif ($_POST['functionname'] == 'insertTempData') {
            $json = $_POST['arguments'];
            $event_name = $_COOKIE['eventName'];
            
            insertTempData($json, $event_name);
        } elseif ($_POST['functionname'] == 'getTempData') {
            getTempData();
        }
    }
    
    function eventRegistered($eventName) {
        global $connection;
        $connresult = array();

        if ($connection -> connect_errno) {
            echo "<script>alert('Network error')</script>";
            exit();
        }

        $sql = "SELECT event_name FROM md5 WHERE hash='{$eventName}'";

        $result = $connection->query($sql);

        if ($result->num_rows == 0) {
            return 1;
        }

        $result = $result->fetch_array(MYSQLI_NUM);
        
        $name = str_replace("'", "\'", $result[0]);
        $sql = "SELECT registered FROM events WHERE name='{$name}'";

        $result = $connection->query($sql);
        $result = $result->fetch_array(MYSQLI_NUM);

        if ($result[0] == 1) {
            return 1;
        } else {
            return 0;
        }
    }
    
    
    function checkIfPaid($eventName, $from) {
        global $connection;
        $connresult = array();

        if ($connection -> connect_errno) {
            echo "<script>alert('Network error')</script>";
            exit();
        }

        $sql = "SELECT ispaid FROM events WHERE name='{$eventName}'";

        $result = $connection->query($sql);
        $result = $result->fetch_array(MYSQLI_NUM);

        if ($result[0] == 1) {
            $sql = "SELECT hash FROM md5 WHERE event_name='{$eventName}'";

            $result = $connection->query($sql);
            $result = $result->fetch_array(MYSQLI_NUM);

            $connresult['result'] = "true";
            $connresult['name'] = $result[0];
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

    function getTempData() {
        global $connection;

        $sql = "SELECT event_name FROM md5 WHERE hash='{$_COOKIE['eventName']}'";
        $result = $connection->query($sql);
        $result = $result->fetch_array(MYSQLI_NUM);

        $name = str_replace("'", "\'", $result[0]);

        $sql = "SELECT guest_json FROM temporary_guest_copy WHERE event_name='{$name}'";
        $result = $connection->query($sql);
        $result = $result->fetch_array(MYSQLI_NUM);
        
        $connectionResult = array();
        $connectionResult['result'] = $result;
        
        echo json_encode($connectionResult);
    }

    function insertTempData($data, $event_name) {
        global $connection;

        $sql = "SELECT event_name FROM md5 WHERE hash='{$event_name}'";
        $result = $connection->query($sql);
        $result = $result->fetch_array(MYSQLI_NUM);

        $name = str_replace("'", "\'", $result[0]);

        $sql = "UPDATE temporary_guest_copy SET guest_json='{$data}' WHERE event_name='{$name}'";
        $connection->query($sql);
    }

    function insertData() {
        //Check if we can connect to the database
        global $connection;
        if ($connection -> connect_errno) {
            echo "<script>alert('Failed to connect to database')</script>";
            exit();
        }

        $sql = "SELECT event_name FROM md5 WHERE hash='{$_COOKIE['eventName']}'";
        $result = $connection->query($sql);
        $result = $result->fetch_array(MYSQLI_NUM);

        $event_name = str_replace("'", "\'", $result[0]);

        //Get the guest_json from the database
        $sql = "SELECT guest_json FROM temporary_guest_copy WHERE event_name='{$event_name}'";
        $result = $connection->query($sql);
        $result = $result->fetch_array(MYSQLI_NUM);

        $guest_json = $result[0];

        //Get the event id 
        $sql = "SELECT guests_id FROM events WHERE name='{$event_name}'";
        $result = $connection->query($sql);
        $result = $result->fetch_array(MYSQLI_NUM);

        $guests_id = $result[0];

        $personData = json_decode($guest_json, true);

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
        $sql = "{$sql}; DELETE FROM temporary_guest_copy WHERE event_name='{$event_name}'; DELETE FROM md5 WHERE event_name='{$event_name}'";
        $result = $connection->multi_query($sql);

        if ($result == TRUE) {
            setcookie('eventName', null, time() - 86400, '/');
            unset($_COOKIE['eventName']);

            echo "Guest submission success!";
        } else {
            echo "Guest submission failed!";
        }
    }

    function getAllDates() {
        global $connection;
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

    function checkForEvents () {
        global $connection;
        $connectionResult = array();

        if (isset($_COOKIE['eventName'])) {
            $sql = "SELECT ispaid FROM events WHERE name='{$_COOKIE['eventName']}'";
            $result = $connection->query($sql);
            $events = array();

            while ($row = $result->fetch_array(MYSQLI_NUM)) {
                $events[] = $row[0];
            }

            if ($events[0] == 0) {
                $connectionResult['result'] = 'notPaid';
            } else {
                $connectionResult['result'] = 'paid';
            }
            exit(json_encode($connectionResult));
        }        
    }
?>