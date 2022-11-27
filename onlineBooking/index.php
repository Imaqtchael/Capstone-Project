<?php
    
?>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Homepage | Nicolas Resort Online Booking</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="shortcut icon" href="pictures/Nicolas_Logo.jpg" type="image/x-icon">
    <link rel="stylesheet" href="css/index.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.0/jquery.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.1.js"></script>
    <script src="js/index.js"></script>
    <script src="js/jquery.min.js"></script>
</head>

<body>
    <div class="header">
        <div class="logo">
            <a href="index.php"><span class="link"></span></a>
            <img src="pictures/Nicolas_Logo.jpg" alt="">
            <span>Nicolas Resort Online Booking</span>
        </div>

        <!--<div class="search">
            <form action="#">
                <input type="text" placeholder="Search for services...">
                <button type="submit"><i class="fa fa-search"></i></button>
            </form>
        </div>-->

        <!--<div class="navigation">
            <ul type="none">
                <li id="signup"><a href="loginORsignUp.html">Sign up</a></li>
                <li id="login"><a href="loginORsignUp.html">Log in</a></li>
                <li><a href="aboutUs.html">About us</a></li>
                <li>
                    <a id="profile" href="profile.html"></a>
                </li>
            </ul>
        </div>-->

    </div>
    <div class="background" id="vary">
        <center>
            <h1>
                PUT SOME TEXT HERE SHEEEEEEEEEEEEESH
            </h1>
        </center>
        <div class="slides">
            <input type="radio" name="radio-btn" id="radio1">
            <input type="radio" name="radio-btn" id="radio2">
            <input type="radio" name="radio-btn" id="radio3">
            <input type="radio" name="radio-btn" id="radio4">
            <div class="slide first first-image">
            </div>
            <div class="slide second-image">
            </div>
            <div class="slide third-image">
            </div>
            <div class="slide fourth-image">
            </div>
            <div class="navigation-auto">
                <div class="auto-btn1"></div>
                <div class="auto-btn2"></div>
                <div class="auto-btn3"></div>
                <div class="auto-btn4"></div>
            </div>
        </div>
        <div class="navigation-manual">
            <label for="radio1" class="manual-btn"></label>
            <label for="radio2" class="manual-btn"></label>
            <label for="radio3" class="manual-btn"></label>
            <label for="radio4" class="manual-btn"></label>
        </div>
    </div>
    <!--<div class="search-text">Search for your target event</div>


    <div class="center-search">
        <div class="search-events">
            <div class="search-event">
                <div class="search">
                    <form action="" onsubmit="return false">
                        <input type="text" name="search" id="searchEventSearch" placeholder="Search for an event...">
                        <button type="submit" name="buyEvent" onclick="searchEvent()"><i class="fa fa-search"></i></button>
                        <span class="course">
                        <select name="type" id="course" required>
                            <option hidden disabled selected value>-- SEARCH BY --</option>
                            <option value="name">NAME</option>
                            <option value="price">PRICE</option>
                            <option value="place">LOCATION</option>
                            <option value="due">DATE</option>
                        </select>
                    </span>
                    </form>

                </div>
                <div class="events-list">
                    <table class="events-table" id="events">
                        <thead>
                            <tr>
                                <th>Name</th>
                                <th>Time</th>
                                <th>Date</th>
                                <th>Price</th>
                            </tr>
                            <tr>
                                <td>Alfreds Futterkiste</td>
                                <td>Maria Anders</td>
                                <td>Germany</td>
                                <td>Germany</td>
                            </tr>
                            <tr>
                                <td>Alfreds Futterkiste</td>
                                <td>Maria Anders</td>
                                <td>Germany</td>
                                <td>Germany</td>
                        </thead>
                    </table>
                </div>
            </div>
        </div>
    </div>-->

    <div class="search-text">Book your event</div>

    <div class="center-search">
        <div class="book-events">
            <div class="book-event">
                <div class="event-text">
                    <center>
                        <br>
                        <br>
                        <br>
                        <p>Experience the fullest of the moment with us.
                            <p>
                    </center>
                </div>
                <div class="event-form">
                    <div id="freshmen" class="container">
                        <div class="title">Book an Event</div>
                        <form method="post" enctype="multipart/form-data" action="redirect.php">
                            <div class="user-details">

                                <div class="input-box">
                                    <span class="details">First Name</span>
                                    <input type="text" name="fname" placeholder="Enter your first name" required>
                                </div>

                                <div class="input-box">
                                    <span class="details">Last Name</span>
                                    <input type="text" name="lname" placeholder="Enter your last name" required>
                                </div>

                                <div class="input-box">
                                    <span class="details">Middle Name [Leave blank if n/a]</span>
                                    <input type="text" name="mname" placeholder="Enter your middle name">
                                </div>

                                <div class="input-box">
                                    <span class="details">E-Mail</span>
                                    <input type="text" name="email" placeholder="Enter your email" required>
                                </div>

                                <div class="input-box">
                                    <span class="details">Number</span>
                                    <input type="text" name="no" placeholder="Enter your number" required>
                                </div>

                                <div class="input-box">
                                    <span class="details">Address</span>
                                    <input type="input" name="address" placeholder="Enter your address" required>
                                </div>

                                <div class="input-box">
                                    <span class="details">Event Name</span>
                                    <input type="text" name="event_name" placeholder="Enter the event name" required>
                                </div>

                                <div class="input-box">
                                    <span class="details">Date and Time</span>
                                    <input type="text" id="datetimepicker" name="date_time" placeholder="Choose date and time" autocomplete="off" required>
                                </div>

                                <div class="course">
                                    <center>
                                        <label for="course">Choose type of Event</label>
                                        <select name="type" id="course" required>
                                            <option hidden disabled selected value>-- Type of Event --</option>
                                            <option value="WEDDING">Wedding</option>
                                            <option value="DEBUT">Debut</option>
                                            <option value="BIRTHDAY">Birthday</option>
                                        </select>
                                    </center>
                                </div>

                            </div>
                            <div class="button">
                                <input class='book-now' type="submit" value="Book now" name="book">
                            </div>

                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="check-text">
        <center>
            <p style="font-size: 25px; font-weight: 500;">We also accept walk-ins!</p>
            <p style="font-size: 16px;">Come and visit our store so we can check your device, it's always <strong>free!</strong></p>
        </center>

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
                <p><a href="https://www.imaqtchael@gmail.com" style="text-decoration: none; color: white;"><i class="fa fa-envelope"></i> nicolasresort@gmail.com</a></p>
                <p><i class="fa fa-home"></i> Nicolas Resort Building, Phase 1a Sub-Urban Village Brgy. San Jose, Rodriguez, Rizal, Philippines</p>
            </div>
            <div class="follow">
                <p style="font-size: 18px;">FOLLOW US</p>
                <br>
                <a href="https://www.facebook.com/" target="_blank" title="Visit our Facebook Page"><i class="fa fa-facebook-square"></i></a>
                <a href="https://www.instagram.com/" target="_blank" title="Visit our Instagram account"><i class="fa fa-instagram"></i></a>
                <a href="https://twitter.com/" target="_blank" title="Visis our Twitter account"><i class="fa fa-twitter-square"></i></a>

            </div>
        </div>
        <br>
        <center>
            <p>@2022 QuickTech. All Rights Reserved.</p>
        </center>
    </footer>

</body>

<link rel="stylesheet" type="text/css" href="css/jquery.datetimepicker.min.css"/>
<script src="js/jquery.datetimepicker.js"></script>

</html>