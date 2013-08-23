ALTER TABLE `state_schematic`.`number_of_logins` 

  ADD CONSTRAINT `filelist_FK`

  FOREIGN KEY (`user_id` )

  REFERENCES `state_schematic`.`filelist` (`id` )

  ON DELETE NO ACTION

  ON UPDATE NO ACTION

, ADD INDEX `filelist_FK_idx` (`user_id` ASC) ;

