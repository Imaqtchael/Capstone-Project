

CREATE TABLE `events` (
  `guests_id` int(20) NOT NULL AUTO_INCREMENT,
  `registered` int(1) NOT NULL DEFAULT 0,
  `name` varchar(255) NOT NULL,
  `date` varchar(255) NOT NULL,
  `time` varchar(255) NOT NULL,
  `type` varchar(255) NOT NULL,
  `ispaid` tinyint(1) NOT NULL DEFAULT 0,
  `booker` varchar(255) NOT NULL,
  PRIMARY KEY (`guests_id`),
  UNIQUE KEY `name` (`name`,`date`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4;


INSERT INTO events VALUES
("4","2","Janessa\'s Birthday","12/20/2022","10:00 AM","BIRTHDAY","1","Janessa Mae Corsino");




CREATE TABLE `guest` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `guest_id` int(11) NOT NULL,
  `logs` mediumtext NOT NULL DEFAULT '',
  `rfid` varchar(255) NOT NULL,
  `name` varchar(255) NOT NULL,
  `address` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `number` varchar(255) NOT NULL,
  `type` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4;


INSERT INTO guest VALUES
("5","4","12/20/2022 5:44:50 PM, 12/20/2022 5:45:18 PM, 12/20/2022 5:45:19 PM","0007810685","Janessa Mae Corsino","Tarlac City, Tarlac","imaqtchael@gmail.com","09366296799","BOOKER"),
("6","4","12/20/2022 5:44:52 PM, 12/20/2022 5:45:21 PM","0008100286","Niall Jeydon Corsino","Tarlac City, Tarlac","imaqtchael@gmail.com","09366296799","GUEST"),
("7","4","12/20/2022 5:44:54 PM, 12/20/2022 5:45:22 PM","0007748236","Michael Justin Barcenas","Sub Urban Village","imaqtchael@gmail.com","09366296799","GUEST"),
("8","4","12/20/2022 5:44:55 PM, 12/20/2022 5:45:24 PM, 12/20/2022 5:45:24 PM, 12/20/2022 5:45:25 PM, 12/20/2022 5:45:26 PM","0011159868","Janeth Corsino","Tarlac City, Tarlac","imaqtchael@gmail.com","09366296799","GUEST"),
("9","4","12/20/2022 5:44:57 PM, 12/20/2022 5:45:28 PM","0008296445","Nicholas Corsino","Tarlac City, Tarlac","imaqtchael@gmail.com","09366296799","GUEST");


