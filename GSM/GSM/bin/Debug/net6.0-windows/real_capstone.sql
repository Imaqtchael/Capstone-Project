

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
("22","MIKE","0330","Justin Barcenas","Sub Urban Village","09123456789","imaqtchael@gmail.com","EVENT MANAGER","ACTIVE");




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
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4;


INSERT INTO events VALUES
("1","0","Michael Birthday","10/28/2023","6:00 AM","DEBUT","1","Michael Justin Barcenas"),
("2","0","Jerico Birthday","01/25/2023","5:21 PM","DEBUT","1","Jerico  Biscarra"),
("4","0","Janessa Birthday","12/27/2022","5:26 PM","WEDDING","1","Janessa Mae Corsino"),
("5","0","Raizel Jen Birthday","01/27/2023","9:00 PM","DEBUT","1","Raizel Jen Manalili"),
("6","0","Ryan Birthday","12/01/2022","9:00 PM","DEBUT","1","Ryan Miguel Manalili");




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
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8mb4;


INSERT INTO guest VALUES
("1","1","","","Michael Justin Barcenas","Sub Urban Village","imaqtchael@gmail.com","09366296799","BOOKER"),
("2","1","","","Jerico Biscarra","Sub Urban Village","imaqtchael@gmail.com","09366296799","GUEST"),
("3","1","","","Janessa Mae Corsino","Sub Urban Village","imaqtchael@gmail.com","09366296799","GUEST"),
("4","1","","","Kerwin Reniva","Sub Urban Village","imaqtchael@gmail.com","09366296799","GUEST"),
("5","1","","","John Carlo Garado","Sub Urban Village","imaqtchael@gmail.com","09366296799","GUEST"),
("6","2","","","Jerico  Biscarra","Sub Urban Village","imaqtchael@gmail.com","09366296799","BOOKER"),
("8","2","","","Michael Justin Barcenas","Sub Urban Village","imaqtchael@gmail.com","09366296799","GUEST"),
("9","2","","","Janessa Mae Corsino","Sub Urban Village","imaqtchael@gmail.com","09366296799","GUEST"),
("10","2","","","Kerwin Reniva","Sub Urban Village","imaqtchael@gmail.com","09366296799","GUEST"),
("11","2","","","John Carlo Garado","Sub Urban Village","imaqtchael@gmail.com","09366296799","GUEST"),
("12","4","","","Janessa Mae Corsino","Sub Urban Village","imaqtchael@gmail.com","09366296799","BOOKER"),
("13","4","","","Michael Justin Barcenas","Sub Urban Village","imaqtchael@gmail.com","09366296799","GUEST"),
("14","4","","","Jerico Biscarra","Sub Urban Village","imaqtchael@gmail.com","09366296799","GUEST"),
("15","4","","","Kerwin Reniva","Sub Urban Village","imaqtchael@gmail.com","09366296799","GUEST"),
("16","5","","","Raizel Jen Manalili","Sub Urban Village","imaqtchael@gmail.com","09366296799","BOOKER"),
("17","5","","","Teofilo Erro Manalili","Sub Urban Village","imaqtchael@gmail.com","09366296799","GUEST"),
("18","5","","","Gerlie Erro","Sub Urban Village","imaqtchael@gmail.com","09366296799","GUEST"),
("19","5","","","Jenny Erro","Sub Urban Village","imaqtchael@gmail.com","09366296799","GUEST"),
("20","5","","","Ralph Vincent Manalili","Sub Urban Village","imaqtchael@gmail.com","09366296799","GUEST"),
("21","6","12/1/2022 6:47:58 PM, 12/1/2022 6:48:15 PM, 12/1/2022 6:48:23 PM, 12/1/2022 6:48:28 PM","0008296445","Ryan Miguel Manalili","Sub Urban Village","imaqtchael@gmail.com","09366296799","BOOKER"),
("23","6","","","Ralph Vincent Manalili","Sub Urban Village","imaqtchael@gmail.com","09366296799","GUEST"),
("24","6","","","Rhiam Marie Manalili","Sub Urban Village","imaqtchael@gmail.com","09366296799","GUEST"),
("25","6","","","Raizel Jen Manalili","Sub Urban Village","imaqtchael@gmail.com","09366296799","GUEST"),
("26","6","","","Teofilo Manalili","Sub Urban Village","imaqtchael@gmail.com","09366296799","GUEST"),
("27","6","","","Raya Manalili","Sub Urban Village","imaqtchael@gmail.com","09366296799","GUEST");


