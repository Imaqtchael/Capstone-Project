

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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4;


INSERT INTO events VALUES
("1","2","Jerico Birthday","12/24/2022","09:00 PM","BD","1","Christian delos reyes runas"),
("2","0","Jennies Wedding","12/27/2022","10:00 AM","WEDDING","1","Jennie Kim");




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
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4;


INSERT INTO guest VALUES
("3","1","12/24/2022 6:59:29 PM","0007748236","Christian delos reyes runas","Sub Urban Village","cdelosreyes2793@gmail.com","09062619386","BOOKER"),
("4","1","12/24/2022 6:59:20 PM, 12/24/2022 6:59:26 PM","0008100286","andrew wolf","Sub Urban Village","imaqtchael@gmail.com","09366296799","GUEST"),
("5","1","12/24/2022 6:59:05 PM","0007810685","errol spence","Sub Urban Village","spence@gmail.com","09366296799","GUEST"),
("7","2","","","Jennie Kim","Kasiglahan Village","imaqtchael@gmail.com","09366296799","BOOKER");


