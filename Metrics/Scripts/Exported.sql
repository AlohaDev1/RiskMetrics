delimiter $$

CREATE TABLE `exported` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ExportedOn` datetime DEFAULT NULL,
  `UserId` int(11) DEFAULT NULL,
  `RecordsExportedCount` int(11) DEFAULT NULL,
  `FileName` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8$$



delimiter $$

CREATE TABLE `exported_company` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CompanyId` varchar(15) DEFAULT NULL,
  `ExportedId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `ExportedId_idx` (`Id`),
  KEY `ExportedId` (`ExportedId`),
  CONSTRAINT `ExportedId` FOREIGN KEY (`ExportedId`) REFERENCES `expoerted` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8$$

