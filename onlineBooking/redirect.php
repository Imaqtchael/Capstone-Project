<?php
    session_start();

    if (isset($_POST['book'])) {
        $_SESSION['name'] = "{$_POST['fname']} {$_POST['lname']} {$_POST['mname']}";
        $_SESSION['address'] = $_POST['address'];
        $_SESSION['email'] = $_POST['email'];
        $_SESSION['number'] = $_POST['no'];
        $_SESSION['type'] = $_POST['type'];

        $connection = new mysqli("localhost", "root", "", "real_capstone");

        if ($connection -> connect_errno) {
            echo "<script>alert('Network error')</script>";
            exit();
        }

        $sql = "INSERT INTO events (type, booker) VALUES ('{$_POST['type']}', '{$_SESSION['name']}')";
        $result = $connection->query($sql);

        $sql = "SELECT guests_id FROM events WHERE booker='{$_SESSION['name']}'";
        $result = $connection->query($sql);
        $result = $result->fetch_array(MYSQLI_NUM);

        $guests_id = $result[0];

        $sql = "INSERT INTO guest (guest_id, name, address, email, number, type) VALUES ($guests_id, '{$_SESSION['name']}', '{$_SESSION['address']}', '{$_SESSION['email']}', '{$_SESSION['number']}', 'booker')";
        $result = $connection->query($sql);
    }
?>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Nicolas Resort Online Booking | Homepage</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="shortcut icon" href="pictures/Nicolas_Logo.jpg" type="image/x-icon">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.0/jquery.min.js"></script>
    <script src="redirect.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.1.js"></script>
    <link rel="stylesheet" href="redirect.css">
</head>

<body>
    <div class="header">
        <div class="logo">
            <a href="index.php"><span class="link"></span></a>
            <img src="pictures/Nicolas_Logo.jpg" alt="">
            <span>Nicolas Resort Online Booking</span>
        </div>

    </div>
    <br>
    <br>
    <br>
    <br>

    <div class="search-text">Waiting for your payment</div>

    <footer>
        <div class="footer">
            <div class="like" style="text-align: center;">
                <p style="font-size: 18px;">Like what you see?</p>
                <br>
                <p>Then give us a call and we'll chat through what you need.</p>
                <p>We've got coffee, tea, and buscuits!</p>
                <p style="font-weight: 500">(if you're quick)</p>
            </div>
            <div class="contact">
                <img src="pictures/Software-PNG-Photos.png" alt="">
                <span style="font-size: 18px;">CONTACT US</span>
                <p><i class="fa fa-comments"></i> (+63) 9366296799</p>
                <p><a href="https://www.imaqtchael@gmail.com" style="text-decoration: none; color: white;"><i
                            class="fa fa-envelope"></i> nicolasresort@gmail.com</a></p>
                <p><i class="fa fa-home"></i> Nicolas Resort Building, Phase 1a Sub-Urban Village Brgy. San Jose, Rodriguez, Rizal, Philippines</p>
            </div>
            <div class="follow">
                <p style="font-size: 18px;">FOLLOW US</p>
                <br>
                <a href="https://www.facebook.com/" target="_blank" title="Visit our Facebook Page"><i
                        class="fa fa-facebook-square"></i></a>
                <a href="https://www.instagram.com/" target="_blank" title="Visit our Instagram account"><i
                        class="fa fa-instagram"></i></a>
                <a href="https://twitter.com/" target="_blank" title="Visis our Twitter account"><i
                        class="fa fa-twitter-square"></i></a>

            </div>
        </div>
        <br>
        <center>
            <p>@2022 QuickTech. All Rights Reserved.</p>
        </center>
    </footer>

</body>

</html>