

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
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4;


INSERT INTO admin VALUES
("3","ADMIN","123","Christian De Los Reyes","Sub Urban Village","09123456789","christian@gmail.com","EVENT COORDINATOR","ACTIVE"),
("22","van_","0330","MIchael Justin Barcenas","Sub Urban Village","09123456789","imaqtchael@gmail.com","EVENT MANAGER","ACTIVE");




CREATE TABLE `events` (
  `guests_id` int(20) NOT NULL AUTO_INCREMENT,
  `registered` tinyint(1) NOT NULL DEFAULT 0,
  `name` varchar(255) NOT NULL,
  `date` varchar(255) NOT NULL,
  `time` varchar(255) NOT NULL,
  `type` varchar(255) NOT NULL,
  `ispaid` tinyint(1) NOT NULL DEFAULT 0,
  `booker` varchar(255) NOT NULL,
  PRIMARY KEY (`guests_id`),
  UNIQUE KEY `name` (`name`,`date`)
) ENGINE=InnoDB AUTO_INCREMENT=55 DEFAULT CHARSET=utf8mb4;


INSERT INTO events VALUES
("45","0","Michael Birthday","12/28/2022","3:00 PM","BIRTHDAY","1","Michael Justin Barcenas"),
("46","0","Jerico Birthday","11/29/2022","4:40 PM","BIRTHDAY","1","Jerico  Biscarra"),
("54","0","Janessa Debut","03/27/2023","7:00 PM","DEBUT","1","Janessa Mae Corsino");




CREATE TABLE `guest` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `guest_id` int(11) NOT NULL,
  `logs` mediumtext NOT NULL,
  `rfid` varchar(255) NOT NULL,
  `name` varchar(255) NOT NULL,
  `address` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `number` varchar(255) NOT NULL,
  `type` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=134 DEFAULT CHARSET=utf8mb4;


INSERT INTO guest VALUES
("115","45","","","Michael Justin Barcenas","Sub Urban Village","imaqtchael@gmail.com","09366296799","BOOKER"),
("116","45","","","Janessa Mae Corsino","Tarlac City, Tarlac","imaqchael@gmail.com","09366296799","GUEST"),
("117","45","","","Ashley Baloyo","Sub Urban Village","imaqtchael@gmail.com","09366296799","GUEST"),
("118","45","","","Kerwin Reniva","Sub Urban Village","imaqtchael@gmail.com","09366296799","GUEST"),
("119","45","","","Jerico Biscarra","Sub Urban Village","imaqtchael@gmail.com","09366296799","GUEST"),
("120","46","","","Jerico  Biscarra","Sub Urban Village","imaqtchael","09366296799","BOOKER"),
("121","46","","","Michael Justin Barcenas","Sub Urban Village","imaqtchael@gmail.com","09366296799","GUEST"),
("122","46","","","Kerwin Reniva","Sub Urban Village","imaqtchael@gmail.com","09366296799","GUEST"),
("123","46","","","John Carlo Garado","Sub Urban Village","imaqtchael@gmail.com","09366296799","GUEST"),
("124","46","","","Clyde Dominique Tevar","Sub Urban Village","imaqtchael@gmail.com","09366296799","GUEST"),
("125","46","","","Ranold Castinlag","Sub Urban Village","imaqtchael@gmail.com","09366296799","GUEST"),
("132","54","","","Janessa Mae Corsino","Sub Urban Village","imaqtchael@gmail.com","09366296799","BOOKER"),
("133","54","","","Michael Justin Barcenas","Sub Urban Village","imaqtchael@gmail.com","09366296799","GUEST");


