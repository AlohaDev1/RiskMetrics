CREATE  TABLE `state_schematic`.`jigsaw_logins` (

  `id` INT NOT NULL ,

  `user_id` INT NOT NULL ,

  `login_date` DATETIME NOT NULL ,

  `status` BIT NOT NULL ,

  PRIMARY KEY (`id`) ,

  UNIQUE INDEX `id_UNIQUE` (`id` ASC) );