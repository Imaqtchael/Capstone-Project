<?php
    if (isset($_POST['book'])) {
        # Check if the user is reloading the page
        $connection = new mysqli("191.101.230.103", "u608197321_van_", "~C3qt^9kZ", "u608197321_real_capstone");

        if ($connection -> connect_errno) {
            echo "<script>alert('Network error')</script>";
            exit();
        }

        setcookie('eventName', $_POST['event_name'], time() + (86400 * 3), "/");

        $sql = "SELECT ispaid FROM events WHERE name='{$_POST['event_name']}'";
        $result = $connection->query($sql);
        $result = $result->fetch_array(MYSQLI_NUM);

        $isPaid = $result;

        if ($isPaid == 1) {
            return;
        }

        #might wanna destroy these as the one you just want to be saved is the name
        #of the event. that in itself is enough to enter the data to the database.

        #check for empty middle name 
        $name = "";
        if ($_POST['mname'] == "") {
            $name = "{$_POST['fname']} {$_POST['lname']}";
        } else {
            $name = "{$_POST['fname']} {$_POST['lname']} {$_POST['mname']}";
        }
        
        $address = $_POST['address'];
        $email = $_POST['email'];
        $number = $_POST['no'];
        $eventType = $_POST['type'];
        
        $dateTime = explode(" ", $_POST['date_time']);
        $date = date("m/d/Y", strtotime($_POST['date_time']));
        
        $time = date("g:i A", strtotime($_POST['date_time']));

        $sql = "INSERT INTO events (name, date, time, type, booker) VALUES ('{$_POST['event_name']}', '$date', '$time', '$eventType', '$name')";
        $result = $connection->query($sql);

        $sql = "SELECT guests_id FROM events WHERE name='{$_POST['event_name']}'";
        $result = $connection->query($sql);
        $result = $result->fetch_array(MYSQLI_NUM);

        $guests_id = $result[0];

        $sql = "INSERT INTO guest (guest_id, name, address, email, number, type) VALUES ($guests_id, '$name', '$address', '$email', '$number', 'BOOKER')";
        $result = $connection->query($sql);
    }
?>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Redirecting...</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="shortcut icon" href="pictures/Nicolas_Logo.jpg" type="image/x-icon">
    <link rel="stylesheet" href="css/redirect.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.0/jquery.min.js"></script>
    <script src="js/redirect.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.1.js"></script>
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

    <div class="center">
        <div class="search-text">Waiting for your payment</div>
    </div>

    <div class="center-search">
        <div class="book-events gcash">
            <div class="book-event" style="background-color: #2570e3;">
                <div class="event-text gcash">
                    <div>
                        <center>
                            <img src="pictures/redirect/GCASH.png" alt="">
                        </center>
                    </div>

                </div>
                <div class="event-form">
                    <div id="freshmen" class="container">
                        <form method="post" enctype="multipart/form-data" action="redirect.php">
                            <div class="user-details">

                                <div class="input-box">
                                    <span class="details">Number</span>
                                    <input type="text" name="fname" placeholder="Enter your first name" readonly>
                                </div>

                                <div class="input-box">
                                    <span class="details">Name</span>
                                    <input type="text" name="lname" placeholder="Enter your last name" readonly>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="center-search">
        <div class="book-events paymaya">
            <div class="book-event" style="background-color: #87ba41;">
                <div class="event-text paymaya">
                    <div>
                        <center>
                            <img src="pictures/redirect/PAYMAYA.png" alt="">
                        </center>
                    </div>

                </div>
                <div class="event-form">
                    <div id="freshmen" class="container">
                        <form method="post" enctype="multipart/form-data" action="redirect.php">
                            <div class="user-details">

                                <div class="input-box">
                                    <span class="details">Number</span>
                                    <input type="text" name="fname" placeholder="Enter your first name" readonly>
                                </div>

                                <div class="input-box">
                                    <span class="details">Name</span>
                                    <input type="text" name="lname" placeholder="Enter your last name" readonly>
                                </div>

                                <div class="input-box">
                                    <span class="details">Middle Name [Leave blank if n/a]</span>
                                    <input type="text" name="mname" placeholder="Enter your middle name">
                                </div>

                                <div class="input-box">
                                    <span class="details">E-Mail</span>
                                    <input type="text" name="email" placeholder="Enter your email" readonly>
                                </div>

                                <div class="input-box">
                                    <span class="details">Number</span>
                                    <input type="text" name="no" placeholder="Enter your number" readonly>
                                </div>

                                <div class="input-box">
                                    <span class="details">Address</span>
                                    <input type="input" name="address" placeholder="Enter your address" readonly>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="center-search">
        <div class="book-events bpi">
            <div class="book-event" style="background-color: #b4031c;">
                <div class="event-text bpi">
                    <div>
                        <center>
                            <img src="pictures/redirect/BPI.png" alt="">
                        </center>
                    </div>

                </div>
                <div class="event-form">
                    <div id="freshmen" class="container">
                        <form method="post" enctype="multipart/form-data" action="redirect.php">
                            <div class="user-details">

                                <div class="input-box">
                                    <span class="details">Number</span>
                                    <input type="text" name="fname" placeholder="Enter your first name" readonly>
                                </div>

                                <div class="input-box">
                                    <span class="details">Name</span>
                                    <input type="text" name="lname" placeholder="Enter your last name" readonly>
                                </div>

                                <div class="input-box">
                                    <span class="details">Middle Name [Leave blank if n/a]</span>
                                    <input type="text" name="mname" placeholder="Enter your middle name">
                                </div>

                                <div class="input-box">
                                    <span class="details">E-Mail</span>
                                    <input type="text" name="email" placeholder="Enter your email" readonly>
                                </div>

                                <div class="input-box">
                                    <span class="details">Number</span>
                                    <input type="text" name="no" placeholder="Enter your number" readonly>
                                </div>

                                <div class="input-box">
                                    <span class="details">Address</span>
                                    <input type="input" name="address" placeholder="Enter your address" readonly>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="center-search">
        <div class="book-events bdo">
            <div class="book-event" style="background-color: #0b2972;">
                <div class="event-text bdo">
                    <div>
                        <center>
                            <img src="pictures/redirect/BDO.png" alt="">
                        </center>
                    </div>

                </div>
                <div class="event-form">
                    <div id="freshmen" class="container">
                        <form method="post" enctype="multipart/form-data" action="redirect.php">
                            <div class="user-details">

                                <div class="input-box">
                                    <span class="details">Number</span>
                                    <input type="text" name="fname" placeholder="Enter your first name" readonly>
                                </div>

                                <div class="input-box">
                                    <span class="details">Name</span>
                                    <input type="text" name="lname" placeholder="Enter your last name" readonly>
                                </div>

                                <div class="input-box">
                                    <span class="details">Middle Name [Leave blank if n/a]</span>
                                    <input type="text" name="mname" placeholder="Enter your middle name">
                                </div>

                                <div class="input-box">
                                    <span class="details">E-Mail</span>
                                    <input type="text" name="email" placeholder="Enter your email" readonly>
                                </div>

                                <div class="input-box">
                                    <span class="details">Number</span>
                                    <input type="text" name="no" placeholder="Enter your number" readonly>
                                </div>

                                <div class="input-box">
                                    <span class="details">Address</span>
                                    <input type="input" name="address" placeholder="Enter your address" readonly>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
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
                <img src="pictures/Nicolas_Logo.jpg" alt="">
                <span style="font-size: 18px;">CONTACT US</span>
                <p><i class="fa fa-comments"></i> (+63) 9366296799</p>
                <p><a href="https://www.imaqtchael@gmail.com" style="text-decoration: none; color: white;"><i
                            class="fa fa-envelope"></i> nicolasresort@gmail.com</a></p>
                <p><i class="fa fa-home"></i> Nicolas Resort Building, Phase 1a Sub-Urban Village Brgy. San Jose,
                    Rodriguez, Rizal, Philippines</p>
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