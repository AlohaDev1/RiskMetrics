CREATE  TABLE `state_schematic`.`user` (

  `id` INT(11) NOT NULL AUTO_INCREMENT ,

  `userName` VARCHAR(45) NOT NULL ,

  `filePath` VARCHAR(150) NULL ,

  `lastloginDate` DATETIME NULL ,

  `states` VARCHAR(45) NOT NULL ,

  `activationdate` DATETIME NULL ,

  `renewaldate` DATETIME NULL ,

  `expirationdate` DATETIME NULL ,

  `companyName` VARCHAR(45) NOT NULL ,

  `admin` BIT(1) NOT NULL ,

  `canexportlist` BIT(1) NOT NULL ,

  `maxreportviewspermonth` INT(11) ZEROFILL NOT NULL ,

  `maxexports` INT(11) ZEROFILL NOT NULL ,

  `maxjigsawreportsviewspermonth` INT(11) ZEROFILL NOT NULL ,

  `maxjigsawexports` INT(11) ZEROFILL NOT NULL ,

  `password` VARCHAR(45) NOT NULL ,

  `firstName` VARCHAR(100) NOT NULL ,

  `lastName` VARCHAR(100) NOT NULL ,

  `headline` VARCHAR(100) NULL ,

  `profilerequest` VARCHAR(1000) NULL ,

  PRIMARY KEY (`id`) );

