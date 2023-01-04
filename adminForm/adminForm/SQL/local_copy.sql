

CREATE TABLE `admin` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `fullname` varchar(50) NOT NULL,
  `address` varchar(250) NOT NULL,
  `contact` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL,
  `role` varchar(50) NOT NULL,
  `status` varchar(50) NOT NULL DEFAULT 'ACTIVE',
  PRIMARY KEY (`id`),
  UNIQUE KEY `username` (`fullname`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4;


INSERT INTO admin VALUES
("1","DEFAULT","default_admin_password","ADMIN ADMIN","ADDRESS","CONTACT NUMBER","email@email.com","EVENT MANAGER","INACTIVE"),
("2","giovanni","0330","MIchael Justin Barcenas","Sub Urban Village","09366296799","imaqtchael@gmail.com","EVENT MANAGER","ACTIVE"),
("20","Shan","1234","Sumalinog","San Isidro","09366296799","imaqtchael@gmail.com","STAFF","ACTIVE");




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
("1","1","Michael\'s Birthday","12/30/2022","7:00 PM","BIRTHDAY","1","Michael Justin Barcenas"),
("3","0","Janessa\'s Birthday","12/31/2022","7:00 PM","WEDDING","0","Janessa Mae Corsino");




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
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4;


INSERT INTO guest VALUES
("1","1","","","Michael Justin Barcenas","Sub Urban Village","imaqtchael@gmail.com","09366296799","BOOKER"),
("2","1","","","Michael Justin Barcenas","Sub Urban Village","imaqtchael@gmail.com","09366296799","BOOKER"),
("3","3","","","Janessa Mae Corsino","Sub Urban Village","imaqtchael@gmail.com","09366296799","BOOKER"),
("4","3","","","Janessa Mae Corsino","Sub Urban Village","imaqtchael@gmail.com","09366296799","BOOKER");


