<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Nicolas Resort Event Online Booking | Homepage</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="shortcut icon" href="pictures/Software-PNG-Photos.png" type="image/x-icon">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.0/jquery.min.js"></script>
    <script src="index.js"></script>
    <link rel="stylesheet" href="index.css">
</head>

<body>
    <div class="header">
        <div class="logo">
            <a href="index.php"><span class="link"></span></a>
            <img src="" alt="">
            <span>Nicolas Resort Event Online Booking</span>
        </div>

        <!--<div class="search">
            <form action="#">
                <input type="text" placeholder="Search for services...">
                <button type="submit"><i class="fa fa-search"></i></button>
            </form>
        </div>-->

        <div class="navigation">
            <ul type="none">
                <li id="signup"><a href="loginORsignUp.html">Sign up</a></li>
                <li id="login"><a href="loginORsignUp.html">Log in</a></li>
                <li><a href="aboutUs.html">About us</a></li>
                <li>
                    <a id="profile" href="profile.html"></a>
                </li>
            </ul>
        </div>

    </div>
    <div class="background" id="vary">
        <br>
        <br>
        <br>
        <br>
        <br>
        <br>
        <center>
            <h1>
                ALL TICKETS IN ONE PLACE
            </h1>
        </center>

    </div>
    <div class="search-text">Search for your target event</div>


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
                        </thead>
                    </table>
                </div>
            </div>
        </div>
    </div>

    <div class="search-text">You can also book your event</div>

    <div class="center-search">
        <div class="book-events">
            <div class="book-event">
                <div class="event-text">
                    <center><p>Experience the fullest of the moment with us.<p></center>
                </div>
                <div class="event-form">
                <div id="freshmen" class="container">
            <div class="title">Book an Event</div>
            <form method="post" enctype="multipart/form-data">
                <div class="user-details">

                    <div class="input-box">
                        <span class="details">First Name</span>
                        <input type="text" name="Ffname" placeholder="Enter your first name" required>
                    </div>

                    <div class="input-box">
                        <span class="details">Last Name</span>
                        <input type="text" name="Flname" placeholder="Enter your last name" required>
                    </div>

                    <div class="input-box">
                        <span class="details">Middle Name</span>
                        <input type="text" name="Fmname" placeholder="Enter your middle name" required>
                    </div>

                    <div class="input-box">
                        <span class="details">E-Mail</span>
                        <input type="text" name="Femail" placeholder="Enter your email" required>
                    </div>

                    <div class="input-box">
                        <span class="details">Number</span>
                        <input type="text" name="Fno" placeholder="Enter your number" required>
                    </div>

                    <div class="course">
                        <center>
                            <label for="course">Choose</label>
                            <select name="Fcourse" id="course" required>
                                <option hidden disabled selected value>-- Type of Event --</option>
                                <option value="BSIT">Wedding</option>
                                <option value="BSCPE">Debut</option>
                                <option value="BSED">Birthday</option>
                            </select>
                        </center>
                    </div>

                </div>
                <div class="button">
                    <input type="submit" value="Book now" name="Fresh">
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
                <img src="pictures/Software-PNG-Photos.png" alt="">
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

</html>