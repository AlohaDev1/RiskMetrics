CREATE DATABASE  IF NOT EXISTS `state_schematic` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `state_schematic`;
-- MySQL dump 10.13  Distrib 5.5.16, for Win32 (x86)
--
-- Host: localhost    Database: state_schematic
-- ------------------------------------------------------
-- Server version	5.5.29

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `comb`
--

DROP TABLE IF EXISTS `comb`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `comb` (
  `UniqueID` int(11) NOT NULL AUTO_INCREMENT,
  `MasterUID` varchar(15) DEFAULT NULL,
  `DUNS_ULT` char(9) DEFAULT NULL,
  `DUNS_Loc` char(9) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `MailingAddress` varchar(255) DEFAULT NULL,
  `MailingAddressCity` varchar(100) DEFAULT NULL,
  `MailingAddressState` char(2) DEFAULT NULL,
  `MailingAddressZip` varchar(7) DEFAULT NULL,
  `MailingAddressZip4` char(4) DEFAULT NULL,
  `PhysicalAddress` varchar(255) DEFAULT NULL,
  `PhysicalAddressCity` varchar(100) DEFAULT NULL,
  `PhysicalAddressState` char(2) DEFAULT NULL,
  `PhysicalAddressZip` varchar(7) DEFAULT NULL,
  `PhysicalAddressZip4` char(4) DEFAULT NULL,
  `PhoneEmp` varchar(25) DEFAULT NULL,
  `FEIN` varchar(15) DEFAULT NULL,
  `CountyNum` char(5) DEFAULT NULL,
  `RecordType` char(1) DEFAULT NULL,
  `ReportingState` char(2) DEFAULT NULL,
  PRIMARY KEY (`UniqueID`),
  KEY `UniqueID` (`UniqueID`),
  KEY `ReportingState` (`ReportingState`),
  KEY `Description` (`Description`)
) ENGINE=MyISAM AUTO_INCREMENT=12296288 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `county`
--

DROP TABLE IF EXISTS `county`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `county` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `description` varchar(45) NOT NULL,
  `state` varchar(2) DEFAULT NULL,
  `selectflag` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=29511 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `employeesize`
--

DROP TABLE IF EXISTS `employeesize`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `employeesize` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Description` varchar(45) NOT NULL,
  `DnB` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `exported`
--

DROP TABLE IF EXISTS `exported`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `exported` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ExportedOn` datetime DEFAULT NULL,
  `UserId` int(11) DEFAULT NULL,
  `RecordsExportedCount` int(11) DEFAULT NULL,
  `FileName` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `exported_company`
--

DROP TABLE IF EXISTS `exported_company`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `exported_company` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CompanyId` varchar(15) DEFAULT NULL,
  `ExportedId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `ExportedId_idx` (`Id`),
  KEY `ExportedId_idx1` (`ExportedId`),
  CONSTRAINT `ExportedId` FOREIGN KEY (`ExportedId`) REFERENCES `exported` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=777 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `jigsaw_logins`
--

DROP TABLE IF EXISTS `jigsaw_logins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `jigsaw_logins` (
  `id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `login_date` datetime NOT NULL,
  `status` bit(1) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `loginfo`
--

DROP TABLE IF EXISTS `loginfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `loginfo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  `lastloginDate` datetime NOT NULL,
  `CompanyName` varchar(45) NOT NULL,
  `name` varchar(45) NOT NULL,
  `lastlogoutDate` datetime DEFAULT NULL,
  `eventtype` varchar(45) NOT NULL,
  `ReportCount` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `number_of_logins`
--

DROP TABLE IF EXISTS `number_of_logins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `number_of_logins` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `userId` int(11) NOT NULL,
  `loginDate` datetime NOT NULL,
  `loginCount` int(11) unsigned zerofill NOT NULL,
  PRIMARY KEY (`id`),
  KEY `userId_idx` (`userId`),
  CONSTRAINT `user_Id` FOREIGN KEY (`userId`) REFERENCES `user` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `prim`
--

DROP TABLE IF EXISTS `prim`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `prim` (
  `MasterUID` varchar(15) NOT NULL,
  `DUNS_ULT` char(9) DEFAULT NULL,
  `DUNS_Loc` char(9) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `MailingAddress` varchar(255) DEFAULT NULL,
  `MailingAddressCity` varchar(100) DEFAULT NULL,
  `MailingAddressState` char(2) DEFAULT NULL,
  `MailingAddressZip` varchar(7) DEFAULT NULL,
  `MailingAddressZip4` char(4) DEFAULT NULL,
  `PhysicalAddress` varchar(255) DEFAULT NULL,
  `PhysicalAddressCity` varchar(100) DEFAULT NULL,
  `PhysicalAddressState` char(2) DEFAULT NULL,
  `PhysicalAddressZip` varchar(7) DEFAULT NULL,
  `PhysicalAddressZip4` char(4) DEFAULT NULL,
  `PhoneEmp` varchar(25) DEFAULT NULL,
  `ClassCode` varchar(75) DEFAULT NULL,
  `SICCode` char(4) DEFAULT NULL,
  `SICCode2` char(2) DEFAULT NULL,
  `EmployeeSizeRange` char(10) DEFAULT NULL,
  `EmployeeSizeId` int(11) NOT NULL,
  `EffectiveDate` char(5) DEFAULT NULL,
  `EffectiveMonth` char(2) DEFAULT NULL,
  `FEIN` varchar(15) DEFAULT NULL,
  `DUNSConfidenceCode` char(2) DEFAULT NULL,
  `PolicySelf` varchar(100) DEFAULT NULL,
  `CountyNum` char(5) DEFAULT NULL,
  `StateNum` char(2) DEFAULT NULL,
  `CountyName` varchar(100) DEFAULT NULL,
  `ContactName` varchar(255) DEFAULT NULL,
  `NAICCarrierName` varchar(255) DEFAULT NULL,
  `NAICGroupName` varchar(255) DEFAULT NULL,
  `ReportingState` char(2) DEFAULT NULL,
  `CurrentOwnerName` varchar(255) DEFAULT NULL,
  `CurrentOwnerAddress` varchar(255) DEFAULT NULL,
  `CurrentOwnerCity` varchar(100) DEFAULT NULL,
  `CurrentOwnerState` char(2) DEFAULT NULL,
  `CurrentOwnerZip` varchar(7) DEFAULT NULL,
  `CurrentOwnerZip4` char(4) DEFAULT NULL,
  `CurrentOwnerCareOf` varchar(255) DEFAULT NULL,
  `TotalAssessedValue` varchar(255) DEFAULT NULL,
  `AssessedImprovementValue` varchar(255) DEFAULT NULL,
  `AssessedLandValue` varchar(255) DEFAULT NULL,
  `AssessmentYear` varchar(255) DEFAULT NULL,
  `RecordingDateAssessment` varchar(255) DEFAULT NULL,
  `TotalMarketValue` varchar(255) DEFAULT NULL,
  `MarketValueImprovement` varchar(255) DEFAULT NULL,
  `MarketValueLand` varchar(255) DEFAULT NULL,
  `MarketValueYear` varchar(255) DEFAULT NULL,
  `OriginalContractDate` varchar(255) DEFAULT NULL,
  `SalesPrice` varchar(255) DEFAULT NULL,
  `YearBuilt` varchar(255) DEFAULT NULL,
  `Zoning` varchar(255) DEFAULT NULL,
  `OriginalLotSize` varchar(255) DEFAULT NULL,
  `BuildingArea` varchar(255) DEFAULT NULL,
  `NoOfBuildings` varchar(255) DEFAULT NULL,
  `NoOfStories` varchar(255) DEFAULT NULL,
  `Pool` varchar(255) DEFAULT NULL,
  `Elevator` varchar(255) DEFAULT NULL,
  `Car_Fleet` varchar(255) DEFAULT NULL,
  `Truck_Fleet` varchar(255) DEFAULT NULL,
  `Total_Fleet` varchar(255) DEFAULT NULL,
  `Entry_Level_Car` varchar(255) DEFAULT NULL,
  `Basic_Economy_Car` varchar(255) DEFAULT NULL,
  `Lower_Middle_Car` varchar(255) DEFAULT NULL,
  `Upper_Middle_Car` varchar(255) DEFAULT NULL,
  `Upper_Middle_Specialty_Car` varchar(255) DEFAULT NULL,
  `Traditional_Large_Car` varchar(255) DEFAULT NULL,
  `Basic_Sporty_Car` varchar(255) DEFAULT NULL,
  `Mid_Sporty_Car` varchar(255) DEFAULT NULL,
  `Prestige_Sporty_Car` varchar(255) DEFAULT NULL,
  `Basic_Luxury_Car` varchar(255) DEFAULT NULL,
  `Mid_Luxury_Car` varchar(255) DEFAULT NULL,
  `Prestige_Luxury_Car` varchar(255) DEFAULT NULL,
  `Heavy_Duty_Station_Wagon` varchar(255) DEFAULT NULL,
  `Minivan_Cargo` varchar(255) DEFAULT NULL,
  `Minivan_Passenger` varchar(255) DEFAULT NULL,
  `Window_Van_Passenger` varchar(255) DEFAULT NULL,
  `Mini_Sport_Utility` varchar(255) DEFAULT NULL,
  `Sport_Utility` varchar(255) DEFAULT NULL,
  `Fullsize_Utility` varchar(255) DEFAULT NULL,
  `Luxury_Pickup` varchar(255) DEFAULT NULL,
  `Compact_Pickup` varchar(255) DEFAULT NULL,
  `Midsize_Pickup` varchar(255) DEFAULT NULL,
  `Fullsize_Pickup` varchar(255) DEFAULT NULL,
  `Fullsize_Van_Cargo` varchar(255) DEFAULT NULL,
  `Ambulance` varchar(255) DEFAULT NULL,
  `Bus` varchar(255) DEFAULT NULL,
  `Car_Carrier` varchar(255) DEFAULT NULL,
  `Camper_Motor_Driven` varchar(255) DEFAULT NULL,
  `Cab_Chassis` varchar(255) DEFAULT NULL,
  `Cutaway_Van` varchar(255) DEFAULT NULL,
  `Dump_Truck` varchar(255) DEFAULT NULL,
  `Flat_Bed` varchar(255) DEFAULT NULL,
  `Log_Carrier` varchar(255) DEFAULT NULL,
  `Motorhome` varchar(255) DEFAULT NULL,
  `Panel_Truck` varchar(255) DEFAULT NULL,
  `Pickup_Camper` varchar(255) DEFAULT NULL,
  `Refrigerator_Truck` varchar(255) DEFAULT NULL,
  `Sedan_Delivery` varchar(255) DEFAULT NULL,
  `Stake_Truck` varchar(255) DEFAULT NULL,
  `Station_Wagon_Truck` varchar(255) DEFAULT NULL,
  `Tank_Truck` varchar(255) DEFAULT NULL,
  `Transit_Mixer` varchar(255) DEFAULT NULL,
  `Tractor_Truck` varchar(255) DEFAULT NULL,
  `Step_Van` varchar(255) DEFAULT NULL,
  `Van_Camper` varchar(255) DEFAULT NULL,
  `Wrecker` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`MasterUID`),
  KEY `MasterUID` (`MasterUID`),
  KEY `ReportingState` (`ReportingState`),
  KEY `StateNum` (`StateNum`),
  KEY `CountyNum` (`CountyNum`),
  KEY `SICCode2` (`SICCode2`),
  KEY `SICCode` (`SICCode`),
  KEY `EffectiveMonth` (`EffectiveMonth`),
  KEY `EmployeeSizeRange` (`EmployeeSizeRange`),
  KEY `AllExceptIndustry` (`CountyNum`,`StateNum`,`EffectiveMonth`,`EmployeeSizeRange`),
  FULLTEXT KEY `ClassCode` (`ClassCode`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `role`
--

DROP TABLE IF EXISTS `role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `role` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `searchlog`
--

DROP TABLE IF EXISTS `searchlog`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `searchlog` (
  `qui` int(11) NOT NULL AUTO_INCREMENT,
  `id` int(11) NOT NULL,
  `searchname` varchar(45) NOT NULL,
  `description` varchar(45) NOT NULL,
  `address` varchar(45) NOT NULL,
  `city` varchar(45) NOT NULL,
  `state` varchar(2) NOT NULL,
  `zip` varchar(45) NOT NULL,
  `SICCode` varchar(45) NOT NULL,
  `EffectiveMonth` varchar(45) NOT NULL,
  `PhoneEmp` bit(1) NOT NULL,
  `EmpSizeRange` varchar(45) NOT NULL,
  `CountyName` varchar(45) NOT NULL,
  `Active` bit(1) NOT NULL,
  `searchlogcol` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`qui`),
  UNIQUE KEY `qui_UNIQUE` (`qui`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `siccode`
--

DROP TABLE IF EXISTS `siccode`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `siccode` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ParentId` varchar(45) NOT NULL,
  `Code` varchar(45) NOT NULL,
  `Description` varchar(45) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=9652 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `usageinfo`
--

DROP TABLE IF EXISTS `usageinfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usageinfo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(45) NOT NULL,
  `name` varchar(45) NOT NULL,
  `reportid` int(11) NOT NULL,
  `description` varchar(45) NOT NULL,
  `address` varchar(45) NOT NULL,
  `city` varchar(45) NOT NULL,
  `state` varchar(45) NOT NULL,
  `zip` varchar(45) NOT NULL,
  `zipplus4` varchar(45) NOT NULL,
  `classcode` int(11) NOT NULL,
  `siccode` int(11) NOT NULL,
  `status` varchar(45) NOT NULL,
  `effectivedate` varchar(45) NOT NULL,
  `carriernum` varchar(45) NOT NULL,
  `phoneemp` varchar(45) NOT NULL,
  `contactname` varchar(45) NOT NULL,
  `empsizerange` varchar(45) NOT NULL,
  `salesvolrange` varchar(45) NOT NULL,
  `carriername` varchar(45) NOT NULL,
  `countyname` varchar(45) NOT NULL,
  `NAICCarrierNumber` varchar(45) NOT NULL,
  `NAICGroupName` varchar(45) NOT NULL,
  `createdAt` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=111 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `userName` varchar(45) NOT NULL,
  `filePath` varchar(150) DEFAULT NULL,
  `lastloginDate` datetime DEFAULT NULL,
  `states` varchar(45) NOT NULL,
  `activationdate` datetime DEFAULT NULL,
  `renewaldate` datetime DEFAULT NULL,
  `expirationdate` datetime DEFAULT NULL,
  `companyName` varchar(45) NOT NULL,
  `admin` bit(1) NOT NULL,
  `canexportlist` bit(1) NOT NULL,
  `maxreportviewspermonth` int(11) unsigned zerofill NOT NULL,
  `maxexports` int(11) unsigned zerofill NOT NULL,
  `maxjigsawreportsviewspermonth` int(11) unsigned zerofill NOT NULL,
  `maxjigsawexports` int(11) unsigned zerofill NOT NULL,
  `password` varchar(45) NOT NULL,
  `firstName` varchar(100) NOT NULL,
  `lastName` varchar(100) NOT NULL,
  `headline` varchar(100) DEFAULT NULL,
  `profilerequest` varchar(1000) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `user_role`
--

DROP TABLE IF EXISTS `user_role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user_role` (
  `userId` int(11) NOT NULL,
  `roleId` int(11) NOT NULL,
  PRIMARY KEY (`userId`,`roleId`),
  KEY `userId_idx` (`userId`),
  KEY `roleId_idx` (`roleId`),
  CONSTRAINT `userId` FOREIGN KEY (`userId`) REFERENCES `user` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `roleId` FOREIGN KEY (`roleId`) REFERENCES `role` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `user_states`
--

DROP TABLE IF EXISTS `user_states`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user_states` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `userId` int(11) NOT NULL,
  `state_name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  KEY `filelist_foreign_idx` (`userId`),
  KEY `user_idForein_idx` (`userId`),
  CONSTRAINT `user_idForein` FOREIGN KEY (`userId`) REFERENCES `user` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `usercredits`
--

DROP TABLE IF EXISTS `usercredits`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usercredits` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `credits` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping events for database 'state_schematic'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2013-02-03 19:38:53
