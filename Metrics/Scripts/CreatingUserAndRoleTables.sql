delimiter $$

CREATE TABLE `roles` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1$$


delimiter $$

CREATE TABLE `users` (
  `username` varchar(64) CHARACTER SET utf8 DEFAULT NULL,
  `userid` int(11) NOT NULL AUTO_INCREMENT,
  `password` varchar(64) CHARACTER SET utf8 DEFAULT NULL,  
  `last_login` datetime DEFAULT NULL,
  `fullname` varchar(200) CHARACTER SET utf8 DEFAULT NULL,
  `created_on` datetime NOT NULL,
  `contacts` varchar(250) CHARACTER SET utf8 DEFAULT NULL,
  `email` varchar(200) DEFAULT NULL,
  `active` bit(1) NOT NULL,
  `role_id` int(11) DEFAULT NULL,
  `passKey` varchar(4) DEFAULT NULL,
  `passToken` varchar(45) DEFAULT NULL,
  `passTokenExpiration` datetime DEFAULT NULL,
  `photo` varchar(300) DEFAULT NULL,
  PRIMARY KEY (`userid`),
  KEY `role_id` (`role_id`),
  CONSTRAINT `users_ibfk_1` FOREIGN KEY (`role_id`) REFERENCES `roles` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=latin1$$

INSERT INTO `state_schematic`.`roles` (`id`, `name`) VALUES (1, 'User');

INSERT INTO `state_schematic`.`users` (`username`, `userid`, `password`, `fullname`, `created_on`, `contacts`, `email`, `active`, `role_id`) VALUES ('test', 29, 'test', 'test', '2012-06-19 18:21:30', 'test', 'test@trdt.com', 1, 1);


