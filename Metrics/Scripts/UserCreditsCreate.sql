CREATE  TABLE `state_schematic`.`user_credits` (

  `id` INT NOT NULL AUTO_INCREMENT ,

  `user_id` INT NOT NULL ,

  `credits` INT NOT NULL ,

  PRIMARY KEY (`id`) ,

  UNIQUE INDEX `id_UNIQUE` (`id` ASC) );

