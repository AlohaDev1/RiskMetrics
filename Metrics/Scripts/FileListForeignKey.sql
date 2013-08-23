ALTER TABLE `state_schematic`.`searchlog` 

  ADD CONSTRAINT `file_FK`

  FOREIGN KEY (`id` )

  REFERENCES `state_schematic`.`filelist` (`id` )

  ON DELETE NO ACTION

  ON UPDATE NO ACTION

, ADD INDEX `file_FK_idx` (`id` ASC) ;

