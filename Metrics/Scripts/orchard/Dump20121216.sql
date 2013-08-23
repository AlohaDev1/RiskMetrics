CREATE DATABASE  IF NOT EXISTS `test` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `test`;
-- MySQL dump 10.13  Distrib 5.5.16, for Win32 (x86)
--
-- Host: localhost    Database: test
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
-- Table structure for table `common_bodypartrecord`
--

DROP TABLE IF EXISTS `common_bodypartrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `common_bodypartrecord` (
  `Id` int(11) NOT NULL,
  `ContentItemRecord_id` int(11) DEFAULT NULL,
  `Text` text,
  `Format` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `common_bodypartrecord`
--

LOCK TABLES `common_bodypartrecord` WRITE;
/*!40000 ALTER TABLE `common_bodypartrecord` DISABLE KEYS */;
INSERT INTO `common_bodypartrecord` VALUES (8,8,'<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a nibh ut tortor dapibus vestibulum. Aliquam vel sem nibh. Suspendisse vel condimentum tellus.</p>',NULL),(9,9,'<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a nibh ut tortor dapibus vestibulum. Aliquam vel sem nibh. Suspendisse vel condimentum tellus.</p>',NULL),(10,10,'<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur a nibh ut tortor dapibus vestibulum. Aliquam vel sem nibh. Suspendisse vel condimentum tellus.</p>',NULL),(12,12,'<p>You\'ve successfully setup your Orchard Site and this is the homepage of your new site.\r\nHere are a few things you can look at to get familiar with the application.\r\nOnce you feel confident you don\'t need this anymore, you can\r\n<a href=\"Admin/Contents/Edit/12\">remove it by going into editing mode</a>\r\nand replacing it with whatever you want.</p>\r\n<p>First things first - You\'ll probably want to <a href=\"Admin/Settings\">manage your settings</a>\r\nand configure Orchard to your liking. After that, you can head over to\r\n<a href=\"Admin/Themes\">manage themes to change or install new themes</a>\r\nand really make it your own. Once you\'re happy with a look and feel, it\'s time for some content.\r\nYou can start creating new custom content types or start from the built-in ones by\r\n<a href=\"Admin/Contents/Create/Page\">adding a page</a>, or <a href=\"Admin/Navigation\">managing your menus.</a></p>\r\n<p>Finally, Orchard has been designed to be extended. It comes with a few built-in\r\nmodules such as pages and blogs or themes. If you\'re looking to add additional functionality,\r\nyou can do so by creating your own module or by installing one that somebody else built.\r\nModules are created by other users of Orchard just like you so if you feel up to it,\r\n<a href=\"http://orchardproject.net/contribution\">please consider participating</a>.</p>\r\n<p>Thanks for using Orchard – The Orchard Team </p>',NULL);
/*!40000 ALTER TABLE `common_bodypartrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `common_commonpartrecord`
--

DROP TABLE IF EXISTS `common_commonpartrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `common_commonpartrecord` (
  `Id` int(11) NOT NULL,
  `OwnerId` int(11) DEFAULT NULL,
  `CreatedUtc` datetime DEFAULT NULL,
  `PublishedUtc` datetime DEFAULT NULL,
  `ModifiedUtc` datetime DEFAULT NULL,
  `Container_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `common_commonpartrecord`
--

LOCK TABLES `common_commonpartrecord` WRITE;
/*!40000 ALTER TABLE `common_commonpartrecord` DISABLE KEYS */;
INSERT INTO `common_commonpartrecord` VALUES (3,2,'2012-12-16 11:38:00','2012-12-16 11:38:00','2012-12-16 11:38:00',NULL),(4,2,'2012-12-16 11:38:00','2012-12-16 11:38:00','2012-12-16 11:38:00',NULL),(5,2,'2012-12-16 11:38:00','2012-12-16 11:38:00','2012-12-16 11:38:00',NULL),(6,2,'2012-12-16 11:38:00','2012-12-16 11:38:00','2012-12-16 11:38:00',NULL),(7,2,'2012-12-16 11:38:00','2012-12-16 11:38:00','2012-12-16 11:38:00',NULL),(8,2,'2012-12-16 11:38:00','2012-12-16 11:38:00','2012-12-16 11:38:00',7),(9,2,'2012-12-16 11:38:00','2012-12-16 11:38:00','2012-12-16 11:38:00',7),(10,2,'2012-12-16 11:38:00','2012-12-16 11:38:00','2012-12-16 11:38:00',7),(11,0,'2012-12-16 11:38:00','2012-12-16 11:38:01','2012-12-16 11:38:00',NULL),(12,2,'2012-12-16 11:38:01','2012-12-16 11:38:01','2012-12-16 11:38:01',NULL),(13,2,'2012-12-16 11:38:01','2012-12-16 11:39:02','2012-12-16 11:39:02',NULL),(14,2,'2012-12-16 11:38:01','2012-12-16 11:38:01','2012-12-16 11:38:01',3),(15,2,'2012-12-16 11:39:13','2012-12-16 11:39:13','2012-12-16 11:39:13',NULL),(16,2,'2012-12-16 11:39:21','2012-12-16 11:39:21','2012-12-16 11:39:21',NULL),(17,2,'2012-12-16 11:39:34','2012-12-16 11:39:34','2012-12-16 11:39:34',NULL),(20,18,'2012-12-16 12:05:08','2012-12-16 12:05:08','2012-12-16 12:05:56',4),(23,2,'2012-12-26 20:40:59','2012-12-26 20:40:59','2012-12-26 20:40:59',NULL);
/*!40000 ALTER TABLE `common_commonpartrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `common_commonpartversionrecord`
--

DROP TABLE IF EXISTS `common_commonpartversionrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `common_commonpartversionrecord` (
  `Id` int(11) NOT NULL,
  `ContentItemRecord_id` int(11) DEFAULT NULL,
  `CreatedUtc` datetime DEFAULT NULL,
  `PublishedUtc` datetime DEFAULT NULL,
  `ModifiedUtc` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `common_commonpartversionrecord`
--

LOCK TABLES `common_commonpartversionrecord` WRITE;
/*!40000 ALTER TABLE `common_commonpartversionrecord` DISABLE KEYS */;
INSERT INTO `common_commonpartversionrecord` VALUES (3,3,'2012-12-16 11:38:00','2012-12-16 11:38:00','2012-12-16 11:38:00'),(4,4,'2012-12-16 11:38:00','2012-12-16 11:38:00','2012-12-16 11:38:00'),(5,5,'2012-12-16 11:38:00','2012-12-16 11:38:00','2012-12-16 11:38:00'),(6,6,'2012-12-16 11:38:00','2012-12-16 11:38:00','2012-12-16 11:38:00'),(7,7,'2012-12-16 11:38:00','2012-12-16 11:38:00','2012-12-16 11:38:00'),(8,8,'2012-12-16 11:38:00','2012-12-16 11:38:00','2012-12-16 11:38:00'),(9,9,'2012-12-16 11:38:00','2012-12-16 11:38:00','2012-12-16 11:38:00'),(10,10,'2012-12-16 11:38:00','2012-12-16 11:38:00','2012-12-16 11:38:00'),(11,11,'2012-12-16 11:38:00','2012-12-16 11:38:01','2012-12-16 11:38:00'),(12,12,'2012-12-16 11:38:01','2012-12-16 11:38:01','2012-12-16 11:38:01'),(13,13,'2012-12-16 11:38:01','2012-12-16 11:38:01','2012-12-16 11:38:01'),(14,14,'2012-12-16 11:38:01','2012-12-16 11:38:01','2012-12-16 11:38:01'),(15,13,'2012-12-16 11:39:02','2012-12-16 11:39:02','2012-12-16 11:39:02'),(16,15,'2012-12-16 11:39:13','2012-12-16 11:39:13','2012-12-16 11:39:13'),(17,16,'2012-12-16 11:39:21','2012-12-16 11:39:21','2012-12-16 11:39:21'),(18,17,'2012-12-16 11:39:34','2012-12-16 11:39:34','2012-12-16 11:39:34'),(21,20,'2012-12-16 12:05:08','2012-12-16 12:05:08','2012-12-16 12:05:56'),(27,23,'2012-12-26 20:40:59','2012-12-26 20:40:59','2012-12-26 20:40:59');
/*!40000 ALTER TABLE `common_commonpartversionrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `common_identitypartrecord`
--

DROP TABLE IF EXISTS `common_identitypartrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `common_identitypartrecord` (
  `Id` int(11) NOT NULL,
  `Identifier` text,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `common_identitypartrecord`
--

LOCK TABLES `common_identitypartrecord` WRITE;
/*!40000 ALTER TABLE `common_identitypartrecord` DISABLE KEYS */;
INSERT INTO `common_identitypartrecord` VALUES (8,'SetupHtmlWidget1'),(9,'SetupHtmlWidget2'),(10,'SetupHtmlWidget3'),(13,'4ff3e14a0a3842c39138d3c8b92b9e7d'),(14,'MenuWidget1'),(15,'b390fa4de2f1495db7fea239128c6c0e'),(16,'80344e52a569427ca10b6e79e854ebd4'),(17,'7808fadcf66843d9a8cf6b41b34fcc59'),(20,'41b890e8493645d18375a93d6a6dfe69');
/*!40000 ALTER TABLE `common_identitypartrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `containers_containablepartrecord`
--

DROP TABLE IF EXISTS `containers_containablepartrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `containers_containablepartrecord` (
  `Id` int(11) NOT NULL,
  `Weight` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `containers_containablepartrecord`
--

LOCK TABLES `containers_containablepartrecord` WRITE;
/*!40000 ALTER TABLE `containers_containablepartrecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `containers_containablepartrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `containers_containerpartrecord`
--

DROP TABLE IF EXISTS `containers_containerpartrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `containers_containerpartrecord` (
  `Id` int(11) NOT NULL,
  `Paginated` tinyint(1) DEFAULT NULL,
  `PageSize` int(11) DEFAULT NULL,
  `OrderByProperty` varchar(255) DEFAULT NULL,
  `OrderByDirection` int(11) DEFAULT NULL,
  `ItemContentType` varchar(255) DEFAULT NULL,
  `ItemsShown` tinyint(1) DEFAULT '1',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `containers_containerpartrecord`
--

LOCK TABLES `containers_containerpartrecord` WRITE;
/*!40000 ALTER TABLE `containers_containerpartrecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `containers_containerpartrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `containers_containerwidgetpartrecord`
--

DROP TABLE IF EXISTS `containers_containerwidgetpartrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `containers_containerwidgetpartrecord` (
  `Id` int(11) NOT NULL,
  `ContainerId` int(11) DEFAULT NULL,
  `PageSize` int(11) DEFAULT NULL,
  `OrderByProperty` varchar(255) DEFAULT NULL,
  `OrderByDirection` int(11) DEFAULT NULL,
  `ApplyFilter` tinyint(1) DEFAULT NULL,
  `FilterByProperty` varchar(255) DEFAULT NULL,
  `FilterByOperator` varchar(255) DEFAULT NULL,
  `FilterByValue` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `containers_containerwidgetpartrecord`
--

LOCK TABLES `containers_containerwidgetpartrecord` WRITE;
/*!40000 ALTER TABLE `containers_containerwidgetpartrecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `containers_containerwidgetpartrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `containers_custompropertiespartrecord`
--

DROP TABLE IF EXISTS `containers_custompropertiespartrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `containers_custompropertiespartrecord` (
  `Id` int(11) NOT NULL,
  `CustomOne` varchar(255) DEFAULT NULL,
  `CustomTwo` varchar(255) DEFAULT NULL,
  `CustomThree` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `containers_custompropertiespartrecord`
--

LOCK TABLES `containers_custompropertiespartrecord` WRITE;
/*!40000 ALTER TABLE `containers_custompropertiespartrecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `containers_custompropertiespartrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `navigation_adminmenupartrecord`
--

DROP TABLE IF EXISTS `navigation_adminmenupartrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `navigation_adminmenupartrecord` (
  `Id` int(11) NOT NULL,
  `AdminMenuText` varchar(255) DEFAULT NULL,
  `AdminMenuPosition` varchar(255) DEFAULT NULL,
  `OnAdminMenu` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `navigation_adminmenupartrecord`
--

LOCK TABLES `navigation_adminmenupartrecord` WRITE;
/*!40000 ALTER TABLE `navigation_adminmenupartrecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `navigation_adminmenupartrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `navigation_contentmenuitempartrecord`
--

DROP TABLE IF EXISTS `navigation_contentmenuitempartrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `navigation_contentmenuitempartrecord` (
  `Id` int(11) NOT NULL,
  `ContentMenuItemRecord_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `navigation_contentmenuitempartrecord`
--

LOCK TABLES `navigation_contentmenuitempartrecord` WRITE;
/*!40000 ALTER TABLE `navigation_contentmenuitempartrecord` DISABLE KEYS */;
INSERT INTO `navigation_contentmenuitempartrecord` VALUES (13,12);
/*!40000 ALTER TABLE `navigation_contentmenuitempartrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `navigation_menuitempartrecord`
--

DROP TABLE IF EXISTS `navigation_menuitempartrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `navigation_menuitempartrecord` (
  `Id` int(11) NOT NULL,
  `Url` text,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `navigation_menuitempartrecord`
--

LOCK TABLES `navigation_menuitempartrecord` WRITE;
/*!40000 ALTER TABLE `navigation_menuitempartrecord` DISABLE KEYS */;
INSERT INTO `navigation_menuitempartrecord` VALUES (15,'MetricsCorporation.Orchard.Web'),(16,'MetricsCorporation.Orchard.Web/LogReports'),(17,'MetricsCorporation.Orchard.Web/Search');
/*!40000 ALTER TABLE `navigation_menuitempartrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `navigation_menupartrecord`
--

DROP TABLE IF EXISTS `navigation_menupartrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `navigation_menupartrecord` (
  `Id` int(11) NOT NULL,
  `MenuText` varchar(255) DEFAULT NULL,
  `MenuPosition` varchar(255) DEFAULT NULL,
  `MenuId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `navigation_menupartrecord`
--

LOCK TABLES `navigation_menupartrecord` WRITE;
/*!40000 ALTER TABLE `navigation_menupartrecord` DISABLE KEYS */;
INSERT INTO `navigation_menupartrecord` VALUES (13,'Home','1',11),(15,'Adminstration','2',11),(16,'LogReports','3',11),(17,'Search','4',11);
/*!40000 ALTER TABLE `navigation_menupartrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `navigation_menuwidgetpartrecord`
--

DROP TABLE IF EXISTS `navigation_menuwidgetpartrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `navigation_menuwidgetpartrecord` (
  `Id` int(11) NOT NULL,
  `StartLevel` int(11) DEFAULT NULL,
  `Levels` int(11) DEFAULT NULL,
  `Breadcrumb` tinyint(1) DEFAULT NULL,
  `AddHomePage` tinyint(1) DEFAULT NULL,
  `AddCurrentPage` tinyint(1) DEFAULT NULL,
  `Menu_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `navigation_menuwidgetpartrecord`
--

LOCK TABLES `navigation_menuwidgetpartrecord` WRITE;
/*!40000 ALTER TABLE `navigation_menuwidgetpartrecord` DISABLE KEYS */;
INSERT INTO `navigation_menuwidgetpartrecord` VALUES (14,1,0,0,0,0,11),(20,1,0,0,0,0,11);
/*!40000 ALTER TABLE `navigation_menuwidgetpartrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_alias_actionrecord`
--

DROP TABLE IF EXISTS `orchard_alias_actionrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_alias_actionrecord` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Area` varchar(255) DEFAULT NULL,
  `Controller` varchar(255) DEFAULT NULL,
  `Action` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_alias_actionrecord`
--

LOCK TABLES `orchard_alias_actionrecord` WRITE;
/*!40000 ALTER TABLE `orchard_alias_actionrecord` DISABLE KEYS */;
INSERT INTO `orchard_alias_actionrecord` VALUES (1,'Contents','Item','Display');
/*!40000 ALTER TABLE `orchard_alias_actionrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_alias_aliasrecord`
--

DROP TABLE IF EXISTS `orchard_alias_aliasrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_alias_aliasrecord` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Path` text,
  `Action_id` int(11) DEFAULT NULL,
  `RouteValues` text,
  `Source` text,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_alias_aliasrecord`
--

LOCK TABLES `orchard_alias_aliasrecord` WRITE;
/*!40000 ALTER TABLE `orchard_alias_aliasrecord` DISABLE KEYS */;
INSERT INTO `orchard_alias_aliasrecord` VALUES (1,'',1,'<v Id=\"12\" />','Autoroute:View');
/*!40000 ALTER TABLE `orchard_alias_aliasrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_autoroute_autoroutepartrecord`
--

DROP TABLE IF EXISTS `orchard_autoroute_autoroutepartrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_autoroute_autoroutepartrecord` (
  `Id` int(11) NOT NULL,
  `ContentItemRecord_id` int(11) DEFAULT NULL,
  `CustomPattern` text,
  `UseCustomPattern` tinyint(1) DEFAULT '0',
  `DisplayAlias` text,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_autoroute_autoroutepartrecord`
--

LOCK TABLES `orchard_autoroute_autoroutepartrecord` WRITE;
/*!40000 ALTER TABLE `orchard_autoroute_autoroutepartrecord` DISABLE KEYS */;
INSERT INTO `orchard_autoroute_autoroutepartrecord` VALUES (12,12,'/',1,'');
/*!40000 ALTER TABLE `orchard_autoroute_autoroutepartrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_blogs_blogarchivespartrecord`
--

DROP TABLE IF EXISTS `orchard_blogs_blogarchivespartrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_blogs_blogarchivespartrecord` (
  `Id` int(11) NOT NULL,
  `BlogId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_blogs_blogarchivespartrecord`
--

LOCK TABLES `orchard_blogs_blogarchivespartrecord` WRITE;
/*!40000 ALTER TABLE `orchard_blogs_blogarchivespartrecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `orchard_blogs_blogarchivespartrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_blogs_blogpartarchiverecord`
--

DROP TABLE IF EXISTS `orchard_blogs_blogpartarchiverecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_blogs_blogpartarchiverecord` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Year` int(11) DEFAULT NULL,
  `Month` int(11) DEFAULT NULL,
  `PostCount` int(11) DEFAULT NULL,
  `BlogPart_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_blogs_blogpartarchiverecord`
--

LOCK TABLES `orchard_blogs_blogpartarchiverecord` WRITE;
/*!40000 ALTER TABLE `orchard_blogs_blogpartarchiverecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `orchard_blogs_blogpartarchiverecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_blogs_blogpartrecord`
--

DROP TABLE IF EXISTS `orchard_blogs_blogpartrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_blogs_blogpartrecord` (
  `Id` int(11) NOT NULL,
  `Description` text,
  `PostCount` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_blogs_blogpartrecord`
--

LOCK TABLES `orchard_blogs_blogpartrecord` WRITE;
/*!40000 ALTER TABLE `orchard_blogs_blogpartrecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `orchard_blogs_blogpartrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_blogs_recentblogpostspartrecord`
--

DROP TABLE IF EXISTS `orchard_blogs_recentblogpostspartrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_blogs_recentblogpostspartrecord` (
  `Id` int(11) NOT NULL,
  `BlogId` int(11) DEFAULT NULL,
  `Count` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_blogs_recentblogpostspartrecord`
--

LOCK TABLES `orchard_blogs_recentblogpostspartrecord` WRITE;
/*!40000 ALTER TABLE `orchard_blogs_recentblogpostspartrecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `orchard_blogs_recentblogpostspartrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_comments_commentpartrecord`
--

DROP TABLE IF EXISTS `orchard_comments_commentpartrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_comments_commentpartrecord` (
  `Id` int(11) NOT NULL,
  `Author` varchar(255) DEFAULT NULL,
  `SiteName` varchar(255) DEFAULT NULL,
  `UserName` varchar(255) DEFAULT NULL,
  `Email` varchar(255) DEFAULT NULL,
  `Status` varchar(255) DEFAULT NULL,
  `CommentDateUtc` datetime DEFAULT NULL,
  `CommentText` text,
  `CommentedOn` int(11) DEFAULT NULL,
  `CommentedOnContainer` int(11) DEFAULT NULL,
  `CommentsPartRecord_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_comments_commentpartrecord`
--

LOCK TABLES `orchard_comments_commentpartrecord` WRITE;
/*!40000 ALTER TABLE `orchard_comments_commentpartrecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `orchard_comments_commentpartrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_comments_commentsettingspartrecord`
--

DROP TABLE IF EXISTS `orchard_comments_commentsettingspartrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_comments_commentsettingspartrecord` (
  `Id` int(11) NOT NULL,
  `ModerateComments` tinyint(1) DEFAULT NULL,
  `EnableSpamProtection` tinyint(1) DEFAULT NULL,
  `AkismetKey` varchar(255) DEFAULT NULL,
  `AkismetUrl` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_comments_commentsettingspartrecord`
--

LOCK TABLES `orchard_comments_commentsettingspartrecord` WRITE;
/*!40000 ALTER TABLE `orchard_comments_commentsettingspartrecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `orchard_comments_commentsettingspartrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_comments_commentspartrecord`
--

DROP TABLE IF EXISTS `orchard_comments_commentspartrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_comments_commentspartrecord` (
  `Id` int(11) NOT NULL,
  `CommentsShown` tinyint(1) DEFAULT NULL,
  `CommentsActive` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_comments_commentspartrecord`
--

LOCK TABLES `orchard_comments_commentspartrecord` WRITE;
/*!40000 ALTER TABLE `orchard_comments_commentspartrecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `orchard_comments_commentspartrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_framework_contentitemrecord`
--

DROP TABLE IF EXISTS `orchard_framework_contentitemrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_framework_contentitemrecord` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Data` text,
  `ContentType_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_framework_contentitemrecord`
--

LOCK TABLES `orchard_framework_contentitemrecord` WRITE;
/*!40000 ALTER TABLE `orchard_framework_contentitemrecord` DISABLE KEYS */;
INSERT INTO `orchard_framework_contentitemrecord` VALUES (1,NULL,1),(2,NULL,2),(3,NULL,3),(4,NULL,3),(5,NULL,3),(6,NULL,3),(7,NULL,3),(8,NULL,4),(9,NULL,4),(10,NULL,4),(11,NULL,5),(12,NULL,6),(13,NULL,7),(14,NULL,8),(15,NULL,9),(16,NULL,9),(17,NULL,9),(18,NULL,2),(20,NULL,8),(21,NULL,2),(22,NULL,2),(23,NULL,3);
/*!40000 ALTER TABLE `orchard_framework_contentitemrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_framework_contentitemversionrecord`
--

DROP TABLE IF EXISTS `orchard_framework_contentitemversionrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_framework_contentitemversionrecord` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Number` int(11) DEFAULT NULL,
  `Published` tinyint(1) DEFAULT NULL,
  `Latest` tinyint(1) DEFAULT NULL,
  `Data` text,
  `ContentItemRecord_id` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_framework_contentitemversionrecord`
--

LOCK TABLES `orchard_framework_contentitemversionrecord` WRITE;
/*!40000 ALTER TABLE `orchard_framework_contentitemversionrecord` DISABLE KEYS */;
INSERT INTO `orchard_framework_contentitemversionrecord` VALUES (1,1,1,1,NULL,1),(2,1,1,1,NULL,2),(3,1,1,1,NULL,3),(4,1,1,1,NULL,4),(5,1,1,1,NULL,5),(6,1,1,1,NULL,6),(7,1,1,1,NULL,7),(8,1,1,1,NULL,8),(9,1,1,1,NULL,9),(10,1,1,1,NULL,10),(11,1,1,1,NULL,11),(12,1,1,1,NULL,12),(13,1,0,0,NULL,13),(14,1,0,0,NULL,14),(15,2,1,1,NULL,13),(16,1,1,1,NULL,15),(17,1,1,1,NULL,16),(18,1,1,1,NULL,17),(19,1,1,1,NULL,18),(21,1,1,1,NULL,20),(22,1,1,1,NULL,21),(23,1,0,0,NULL,22),(26,2,1,1,NULL,22),(27,1,0,0,NULL,23);
/*!40000 ALTER TABLE `orchard_framework_contentitemversionrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_framework_contenttyperecord`
--

DROP TABLE IF EXISTS `orchard_framework_contenttyperecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_framework_contenttyperecord` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_framework_contenttyperecord`
--

LOCK TABLES `orchard_framework_contenttyperecord` WRITE;
/*!40000 ALTER TABLE `orchard_framework_contenttyperecord` DISABLE KEYS */;
INSERT INTO `orchard_framework_contenttyperecord` VALUES (1,'Site'),(2,'User'),(3,'Layer'),(4,'HtmlWidget'),(5,'Menu'),(6,'Page'),(7,'ContentMenuItem'),(8,'MenuWidget'),(9,'MenuItem');
/*!40000 ALTER TABLE `orchard_framework_contenttyperecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_framework_culturerecord`
--

DROP TABLE IF EXISTS `orchard_framework_culturerecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_framework_culturerecord` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Culture` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_framework_culturerecord`
--

LOCK TABLES `orchard_framework_culturerecord` WRITE;
/*!40000 ALTER TABLE `orchard_framework_culturerecord` DISABLE KEYS */;
INSERT INTO `orchard_framework_culturerecord` VALUES (1,'en-US');
/*!40000 ALTER TABLE `orchard_framework_culturerecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_framework_datamigrationrecord`
--

DROP TABLE IF EXISTS `orchard_framework_datamigrationrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_framework_datamigrationrecord` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `DataMigrationClass` varchar(255) DEFAULT NULL,
  `Version` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_framework_datamigrationrecord`
--

LOCK TABLES `orchard_framework_datamigrationrecord` WRITE;
/*!40000 ALTER TABLE `orchard_framework_datamigrationrecord` DISABLE KEYS */;
INSERT INTO `orchard_framework_datamigrationrecord` VALUES (1,'Orchard.Core.Settings.Migrations',4),(2,'Orchard.ContentManagement.DataMigrations.FrameworkDataMigration',1),(3,'Orchard.Core.Common.Migrations',2),(4,'Orchard.Core.Containers.Migrations',3),(5,'Orchard.Core.Title.Migrations',1),(6,'Orchard.Core.Navigation.Migrations',3),(7,'Orchard.Core.Scheduling.Migrations',1),(8,'Orchard.Pages.Migrations',3),(9,'Orchard.Themes.ThemesDataMigration',1),(10,'Orchard.Users.UsersDataMigration',2),(11,'Orchard.Roles.RolesDataMigration',2),(12,'Orchard.Packaging.Migrations',1),(13,'Orchard.Alias.Migrations',1),(14,'Orchard.Autoroute.Migrations',1),(15,'Orchard.PublishLater.Migrations',1),(16,'Orchard.Widgets.WidgetsDataMigration',4),(17,'Orchard.Blogs.Migrations',5),(18,'Orchard.Comments.Migrations',3),(19,'Orchard.Media.MediaDataMigration',1),(20,'Orchard.Projections.Migrations',3),(21,'Orchard.Tags.TagsDataMigration',1),(22,'Orchard.Warmup.Migrations',1);
/*!40000 ALTER TABLE `orchard_framework_datamigrationrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_media_mediasettingspartrecord`
--

DROP TABLE IF EXISTS `orchard_media_mediasettingspartrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_media_mediasettingspartrecord` (
  `Id` int(11) NOT NULL,
  `UploadAllowedFileTypeWhitelist` varchar(255) DEFAULT 'jpg jpeg gif png txt doc docx xls xlsx pdf ppt pptx pps ppsx odt ods odp',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_media_mediasettingspartrecord`
--

LOCK TABLES `orchard_media_mediasettingspartrecord` WRITE;
/*!40000 ALTER TABLE `orchard_media_mediasettingspartrecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `orchard_media_mediasettingspartrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_packaging_packagingsource`
--

DROP TABLE IF EXISTS `orchard_packaging_packagingsource`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_packaging_packagingsource` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FeedTitle` varchar(255) DEFAULT NULL,
  `FeedUrl` text,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_packaging_packagingsource`
--

LOCK TABLES `orchard_packaging_packagingsource` WRITE;
/*!40000 ALTER TABLE `orchard_packaging_packagingsource` DISABLE KEYS */;
INSERT INTO `orchard_packaging_packagingsource` VALUES (1,'Orchard Gallery','http://packages.orchardproject.net/FeedService.svc');
/*!40000 ALTER TABLE `orchard_packaging_packagingsource` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_projections_decimalfieldindexrecord`
--

DROP TABLE IF EXISTS `orchard_projections_decimalfieldindexrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_projections_decimalfieldindexrecord` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `PropertyName` varchar(255) DEFAULT NULL,
  `Value` decimal(19,5) DEFAULT NULL,
  `FieldIndexPartRecord_Id` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_projections_decimalfieldindexrecord`
--

LOCK TABLES `orchard_projections_decimalfieldindexrecord` WRITE;
/*!40000 ALTER TABLE `orchard_projections_decimalfieldindexrecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `orchard_projections_decimalfieldindexrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_projections_doublefieldindexrecord`
--

DROP TABLE IF EXISTS `orchard_projections_doublefieldindexrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_projections_doublefieldindexrecord` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `PropertyName` varchar(255) DEFAULT NULL,
  `Value` double DEFAULT NULL,
  `FieldIndexPartRecord_Id` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_projections_doublefieldindexrecord`
--

LOCK TABLES `orchard_projections_doublefieldindexrecord` WRITE;
/*!40000 ALTER TABLE `orchard_projections_doublefieldindexrecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `orchard_projections_doublefieldindexrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_projections_fieldindexpartrecord`
--

DROP TABLE IF EXISTS `orchard_projections_fieldindexpartrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_projections_fieldindexpartrecord` (
  `Id` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_projections_fieldindexpartrecord`
--

LOCK TABLES `orchard_projections_fieldindexpartrecord` WRITE;
/*!40000 ALTER TABLE `orchard_projections_fieldindexpartrecord` DISABLE KEYS */;
INSERT INTO `orchard_projections_fieldindexpartrecord` VALUES (3),(4),(5),(6),(7),(8),(9),(10),(11),(12),(13),(14),(15),(16),(17),(18),(20),(21),(22),(23);
/*!40000 ALTER TABLE `orchard_projections_fieldindexpartrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_projections_filtergrouprecord`
--

DROP TABLE IF EXISTS `orchard_projections_filtergrouprecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_projections_filtergrouprecord` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `QueryPartRecord_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_projections_filtergrouprecord`
--

LOCK TABLES `orchard_projections_filtergrouprecord` WRITE;
/*!40000 ALTER TABLE `orchard_projections_filtergrouprecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `orchard_projections_filtergrouprecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_projections_filterrecord`
--

DROP TABLE IF EXISTS `orchard_projections_filterrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_projections_filterrecord` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Category` varchar(64) DEFAULT NULL,
  `Type` varchar(64) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `State` text,
  `Position` int(11) DEFAULT NULL,
  `FilterGroupRecord_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_projections_filterrecord`
--

LOCK TABLES `orchard_projections_filterrecord` WRITE;
/*!40000 ALTER TABLE `orchard_projections_filterrecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `orchard_projections_filterrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_projections_integerfieldindexrecord`
--

DROP TABLE IF EXISTS `orchard_projections_integerfieldindexrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_projections_integerfieldindexrecord` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `PropertyName` varchar(255) DEFAULT NULL,
  `Value` bigint(20) DEFAULT NULL,
  `FieldIndexPartRecord_Id` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_projections_integerfieldindexrecord`
--

LOCK TABLES `orchard_projections_integerfieldindexrecord` WRITE;
/*!40000 ALTER TABLE `orchard_projections_integerfieldindexrecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `orchard_projections_integerfieldindexrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_projections_layoutrecord`
--

DROP TABLE IF EXISTS `orchard_projections_layoutrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_projections_layoutrecord` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Category` varchar(64) DEFAULT NULL,
  `Type` varchar(64) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `State` text,
  `DisplayType` varchar(64) DEFAULT NULL,
  `Display` int(11) DEFAULT NULL,
  `QueryPartRecord_id` int(11) DEFAULT NULL,
  `GroupProperty_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_projections_layoutrecord`
--

LOCK TABLES `orchard_projections_layoutrecord` WRITE;
/*!40000 ALTER TABLE `orchard_projections_layoutrecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `orchard_projections_layoutrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_projections_memberbindingrecord`
--

DROP TABLE IF EXISTS `orchard_projections_memberbindingrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_projections_memberbindingrecord` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Type` varchar(255) DEFAULT NULL,
  `Member` varchar(64) DEFAULT NULL,
  `Description` text,
  `DisplayName` varchar(64) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_projections_memberbindingrecord`
--

LOCK TABLES `orchard_projections_memberbindingrecord` WRITE;
/*!40000 ALTER TABLE `orchard_projections_memberbindingrecord` DISABLE KEYS */;
INSERT INTO `orchard_projections_memberbindingrecord` VALUES (1,'Orchard.Core.Common.Models.CommonPartRecord','CreatedUtc','When the content item was created','Creation date'),(2,'Orchard.Core.Common.Models.CommonPartRecord','ModifiedUtc','When the content item was modified','Modification date'),(3,'Orchard.Core.Common.Models.CommonPartRecord','PublishedUtc','When the content item was published','Publication date'),(4,'Orchard.Core.Title.Models.TitlePartRecord','Title','The title assigned using the Title part','Title Part Title'),(5,'Orchard.Core.Common.Models.BodyPartRecord','Text','The text from the Body part','Body Part Text');
/*!40000 ALTER TABLE `orchard_projections_memberbindingrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_projections_navigationquerypartrecord`
--

DROP TABLE IF EXISTS `orchard_projections_navigationquerypartrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_projections_navigationquerypartrecord` (
  `Id` int(11) NOT NULL,
  `Items` int(11) DEFAULT NULL,
  `Skip` int(11) DEFAULT NULL,
  `QueryPartRecord_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_projections_navigationquerypartrecord`
--

LOCK TABLES `orchard_projections_navigationquerypartrecord` WRITE;
/*!40000 ALTER TABLE `orchard_projections_navigationquerypartrecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `orchard_projections_navigationquerypartrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_projections_projectionpartrecord`
--

DROP TABLE IF EXISTS `orchard_projections_projectionpartrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_projections_projectionpartrecord` (
  `Id` int(11) NOT NULL,
  `Items` int(11) DEFAULT NULL,
  `ItemsPerPage` int(11) DEFAULT NULL,
  `Skip` int(11) DEFAULT NULL,
  `PagerSuffix` varchar(255) DEFAULT NULL,
  `MaxItems` int(11) DEFAULT NULL,
  `DisplayPager` tinyint(1) DEFAULT NULL,
  `QueryPartRecord_id` int(11) DEFAULT NULL,
  `LayoutRecord_Id` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_projections_projectionpartrecord`
--

LOCK TABLES `orchard_projections_projectionpartrecord` WRITE;
/*!40000 ALTER TABLE `orchard_projections_projectionpartrecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `orchard_projections_projectionpartrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_projections_propertyrecord`
--

DROP TABLE IF EXISTS `orchard_projections_propertyrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_projections_propertyrecord` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Category` varchar(64) DEFAULT NULL,
  `Type` varchar(64) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `State` text,
  `Position` int(11) DEFAULT NULL,
  `LayoutRecord_id` int(11) DEFAULT NULL,
  `ExcludeFromDisplay` tinyint(1) DEFAULT NULL,
  `CreateLabel` tinyint(1) DEFAULT NULL,
  `Label` varchar(255) DEFAULT NULL,
  `LinkToContent` tinyint(1) DEFAULT NULL,
  `CustomizePropertyHtml` tinyint(1) DEFAULT NULL,
  `CustomPropertyTag` varchar(64) DEFAULT NULL,
  `CustomPropertyCss` varchar(64) DEFAULT NULL,
  `CustomizeLabelHtml` tinyint(1) DEFAULT NULL,
  `CustomLabelTag` varchar(64) DEFAULT NULL,
  `CustomLabelCss` varchar(64) DEFAULT NULL,
  `CustomizeWrapperHtml` tinyint(1) DEFAULT NULL,
  `CustomWrapperTag` varchar(64) DEFAULT NULL,
  `CustomWrapperCss` varchar(64) DEFAULT NULL,
  `NoResultText` text,
  `ZeroIsEmpty` tinyint(1) DEFAULT NULL,
  `HideEmpty` tinyint(1) DEFAULT NULL,
  `RewriteOutput` tinyint(1) DEFAULT NULL,
  `RewriteText` text,
  `StripHtmlTags` tinyint(1) DEFAULT NULL,
  `TrimLength` tinyint(1) DEFAULT NULL,
  `AddEllipsis` tinyint(1) DEFAULT NULL,
  `MaxLength` int(11) DEFAULT NULL,
  `TrimOnWordBoundary` tinyint(1) DEFAULT NULL,
  `PreserveLines` tinyint(1) DEFAULT NULL,
  `TrimWhiteSpace` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_projections_propertyrecord`
--

LOCK TABLES `orchard_projections_propertyrecord` WRITE;
/*!40000 ALTER TABLE `orchard_projections_propertyrecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `orchard_projections_propertyrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_projections_querypartrecord`
--

DROP TABLE IF EXISTS `orchard_projections_querypartrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_projections_querypartrecord` (
  `Id` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_projections_querypartrecord`
--

LOCK TABLES `orchard_projections_querypartrecord` WRITE;
/*!40000 ALTER TABLE `orchard_projections_querypartrecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `orchard_projections_querypartrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_projections_sortcriterionrecord`
--

DROP TABLE IF EXISTS `orchard_projections_sortcriterionrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_projections_sortcriterionrecord` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Category` varchar(64) DEFAULT NULL,
  `Type` varchar(64) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `State` text,
  `Position` int(11) DEFAULT NULL,
  `QueryPartRecord_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_projections_sortcriterionrecord`
--

LOCK TABLES `orchard_projections_sortcriterionrecord` WRITE;
/*!40000 ALTER TABLE `orchard_projections_sortcriterionrecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `orchard_projections_sortcriterionrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_projections_stringfieldindexrecord`
--

DROP TABLE IF EXISTS `orchard_projections_stringfieldindexrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_projections_stringfieldindexrecord` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `PropertyName` varchar(255) DEFAULT NULL,
  `Value` text,
  `FieldIndexPartRecord_Id` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_projections_stringfieldindexrecord`
--

LOCK TABLES `orchard_projections_stringfieldindexrecord` WRITE;
/*!40000 ALTER TABLE `orchard_projections_stringfieldindexrecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `orchard_projections_stringfieldindexrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_roles_permissionrecord`
--

DROP TABLE IF EXISTS `orchard_roles_permissionrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_roles_permissionrecord` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL,
  `FeatureName` varchar(255) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_roles_permissionrecord`
--

LOCK TABLES `orchard_roles_permissionrecord` WRITE;
/*!40000 ALTER TABLE `orchard_roles_permissionrecord` DISABLE KEYS */;
INSERT INTO `orchard_roles_permissionrecord` VALUES (1,'ApplyTheme','Orchard.Themes','Apply a Theme'),(2,'PublishContent','Contents','Publish or unpublish content for others'),(3,'EditContent','Contents','Edit content for others'),(4,'DeleteContent','Contents','Delete content for others'),(5,'PublishOwnContent','Contents','Publish or unpublish own content'),(6,'EditOwnContent','Contents','Edit own content'),(7,'DeleteOwnContent','Contents','Delete own content'),(8,'ViewContent','Contents','View all content'),(9,'ManageMainMenu','Navigation','Manage main menu'),(10,'ManageFeatures','Orchard.Modules','Manage Features'),(11,'SiteOwner','Orchard.Framework','Site Owners Permission'),(12,'AccessAdminPanel','Orchard.Framework','Access admin panel'),(13,'AccessFrontEnd','Orchard.Framework','Access site front-end'),(14,'SetHomePage','Orchard.Autoroute','Set Home Page'),(15,'ManageWidgets','Orchard.Widgets','Managing Widgets'),(16,'ManageBlogs','Orchard.Blogs','Manage blogs for others'),(17,'PublishBlogPost','Orchard.Blogs','Publish or unpublish blog post for others'),(18,'EditBlogPost','Orchard.Blogs','Edit blog posts for others'),(19,'DeleteBlogPost','Orchard.Blogs','Delete blog post for others'),(20,'ManageOwnBlogs','Orchard.Blogs','Manage own blogs'),(21,'EditOwnBlogPost','Orchard.Blogs','Edit own blog posts'),(22,'ManageComments','Orchard.Comments','Manage comments'),(23,'AddComment','Orchard.Comments','Add comment'),(24,'EditContentTypes','Orchard.ContentTypes','Edit content types.'),(25,'ManageMedia','Orchard.Media','Managing Media Files'),(26,'ManageTags','Orchard.Tags','Manage tags'),(27,'AdministrationUsers','MetricsCorporation.Orchard.Web','Administration filelist&masterId');
/*!40000 ALTER TABLE `orchard_roles_permissionrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_roles_rolerecord`
--

DROP TABLE IF EXISTS `orchard_roles_rolerecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_roles_rolerecord` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_roles_rolerecord`
--

LOCK TABLES `orchard_roles_rolerecord` WRITE;
/*!40000 ALTER TABLE `orchard_roles_rolerecord` DISABLE KEYS */;
INSERT INTO `orchard_roles_rolerecord` VALUES (1,'Administrator'),(6,'Authenticated'),(7,'Anonymous'),(8,'Master'),(9,'Carrier'),(10,'Agency'),(11,'Producer');
/*!40000 ALTER TABLE `orchard_roles_rolerecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_roles_rolespermissionsrecord`
--

DROP TABLE IF EXISTS `orchard_roles_rolespermissionsrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_roles_rolespermissionsrecord` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Role_id` int(11) DEFAULT NULL,
  `Permission_id` int(11) DEFAULT NULL,
  `RoleRecord_Id` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_roles_rolespermissionsrecord`
--

LOCK TABLES `orchard_roles_rolespermissionsrecord` WRITE;
/*!40000 ALTER TABLE `orchard_roles_rolespermissionsrecord` DISABLE KEYS */;
INSERT INTO `orchard_roles_rolespermissionsrecord` VALUES (1,1,1,1),(2,1,2,1),(3,1,3,1),(4,1,4,1),(5,1,9,1),(6,1,10,1),(7,1,11,1),(8,1,12,1),(20,6,8,6),(21,6,13,6),(22,7,8,7),(23,7,13,7),(24,1,14,1),(25,1,15,1),(26,1,16,1),(27,1,22,1),(28,1,23,1),(29,1,24,1),(30,1,25,1),(31,1,26,1),(47,7,23,7),(48,6,23,6),(50,8,27,8);
/*!40000 ALTER TABLE `orchard_roles_rolespermissionsrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_roles_userrolespartrecord`
--

DROP TABLE IF EXISTS `orchard_roles_userrolespartrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_roles_userrolespartrecord` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) DEFAULT NULL,
  `Role_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_roles_userrolespartrecord`
--

LOCK TABLES `orchard_roles_userrolespartrecord` WRITE;
/*!40000 ALTER TABLE `orchard_roles_userrolespartrecord` DISABLE KEYS */;
INSERT INTO `orchard_roles_userrolespartrecord` VALUES (1,21,10),(8,22,8),(9,18,8);
/*!40000 ALTER TABLE `orchard_roles_userrolespartrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_tags_contenttagrecord`
--

DROP TABLE IF EXISTS `orchard_tags_contenttagrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_tags_contenttagrecord` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `TagRecord_Id` int(11) DEFAULT NULL,
  `TagsPartRecord_Id` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_tags_contenttagrecord`
--

LOCK TABLES `orchard_tags_contenttagrecord` WRITE;
/*!40000 ALTER TABLE `orchard_tags_contenttagrecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `orchard_tags_contenttagrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_tags_tagrecord`
--

DROP TABLE IF EXISTS `orchard_tags_tagrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_tags_tagrecord` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `TagName` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_tags_tagrecord`
--

LOCK TABLES `orchard_tags_tagrecord` WRITE;
/*!40000 ALTER TABLE `orchard_tags_tagrecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `orchard_tags_tagrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_tags_tagspartrecord`
--

DROP TABLE IF EXISTS `orchard_tags_tagspartrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_tags_tagspartrecord` (
  `Id` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_tags_tagspartrecord`
--

LOCK TABLES `orchard_tags_tagspartrecord` WRITE;
/*!40000 ALTER TABLE `orchard_tags_tagspartrecord` DISABLE KEYS */;
INSERT INTO `orchard_tags_tagspartrecord` VALUES (12);
/*!40000 ALTER TABLE `orchard_tags_tagspartrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_themes_themesitesettingspartrecord`
--

DROP TABLE IF EXISTS `orchard_themes_themesitesettingspartrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_themes_themesitesettingspartrecord` (
  `Id` int(11) NOT NULL,
  `CurrentThemeName` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_themes_themesitesettingspartrecord`
--

LOCK TABLES `orchard_themes_themesitesettingspartrecord` WRITE;
/*!40000 ALTER TABLE `orchard_themes_themesitesettingspartrecord` DISABLE KEYS */;
INSERT INTO `orchard_themes_themesitesettingspartrecord` VALUES (1,'Bootstrap');
/*!40000 ALTER TABLE `orchard_themes_themesitesettingspartrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_users_registrationsettingspartrecord`
--

DROP TABLE IF EXISTS `orchard_users_registrationsettingspartrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_users_registrationsettingspartrecord` (
  `Id` int(11) NOT NULL,
  `UsersCanRegister` tinyint(1) DEFAULT '0',
  `UsersMustValidateEmail` tinyint(1) DEFAULT '0',
  `ValidateEmailRegisteredWebsite` varchar(255) DEFAULT NULL,
  `ValidateEmailContactEMail` varchar(255) DEFAULT NULL,
  `UsersAreModerated` tinyint(1) DEFAULT '0',
  `NotifyModeration` tinyint(1) DEFAULT '0',
  `NotificationsRecipients` text,
  `EnableLostPassword` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_users_registrationsettingspartrecord`
--

LOCK TABLES `orchard_users_registrationsettingspartrecord` WRITE;
/*!40000 ALTER TABLE `orchard_users_registrationsettingspartrecord` DISABLE KEYS */;
INSERT INTO `orchard_users_registrationsettingspartrecord` VALUES (1,0,0,NULL,NULL,0,0,NULL,0);
/*!40000 ALTER TABLE `orchard_users_registrationsettingspartrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_users_userpartrecord`
--

DROP TABLE IF EXISTS `orchard_users_userpartrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_users_userpartrecord` (
  `Id` int(11) NOT NULL,
  `UserName` varchar(255) DEFAULT NULL,
  `Email` varchar(255) DEFAULT NULL,
  `NormalizedUserName` varchar(255) DEFAULT NULL,
  `Password` varchar(255) DEFAULT NULL,
  `PasswordFormat` varchar(255) DEFAULT NULL,
  `HashAlgorithm` varchar(255) DEFAULT NULL,
  `PasswordSalt` varchar(255) DEFAULT NULL,
  `RegistrationStatus` varchar(255) DEFAULT 'Approved',
  `EmailStatus` varchar(255) DEFAULT 'Approved',
  `EmailChallengeToken` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_users_userpartrecord`
--

LOCK TABLES `orchard_users_userpartrecord` WRITE;
/*!40000 ALTER TABLE `orchard_users_userpartrecord` DISABLE KEYS */;
INSERT INTO `orchard_users_userpartrecord` VALUES (2,'admin','','admin','cxTmMVWcMU2TqVg0iFOUvwEe5gw=','Hashed','SHA1','WE+okN4RC0s5QEyzw617aw==','Approved','Approved',NULL),(18,'jmc1','jmc1','jmc1','XtouQ9A+q+d92XUSVtWYBTCH2UU=','Hashed','SHA1','aMpLAXRBD3du8i7vqqeo7g==','Approved','Approved',NULL),(21,'AgencyTest','AgencyTest@test.com','agencytest','IMbMdWIKyk/ZDv7ih4dbMBg87w0=','Hashed','SHA1','GY6AqsMpS/McdUAXMBYYMA==','Approved','Approved',NULL),(22,'test','test@test2.com','test','glxkcZVma7kVBz8dfmfsJrkK/0o=','Hashed','SHA1','Q+WZ7/+Px2713Esb6ZfWpg==','Approved','Approved',NULL);
/*!40000 ALTER TABLE `orchard_users_userpartrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_warmup_warmupsettingspartrecord`
--

DROP TABLE IF EXISTS `orchard_warmup_warmupsettingspartrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_warmup_warmupsettingspartrecord` (
  `Id` int(11) NOT NULL,
  `Urls` text,
  `Scheduled` tinyint(1) DEFAULT NULL,
  `Delay` int(11) DEFAULT NULL,
  `OnPublish` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_warmup_warmupsettingspartrecord`
--

LOCK TABLES `orchard_warmup_warmupsettingspartrecord` WRITE;
/*!40000 ALTER TABLE `orchard_warmup_warmupsettingspartrecord` DISABLE KEYS */;
INSERT INTO `orchard_warmup_warmupsettingspartrecord` VALUES (1,NULL,0,90,0);
/*!40000 ALTER TABLE `orchard_warmup_warmupsettingspartrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_widgets_layerpartrecord`
--

DROP TABLE IF EXISTS `orchard_widgets_layerpartrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_widgets_layerpartrecord` (
  `Id` int(11) NOT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `Description` text,
  `LayerRule` text,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_widgets_layerpartrecord`
--

LOCK TABLES `orchard_widgets_layerpartrecord` WRITE;
/*!40000 ALTER TABLE `orchard_widgets_layerpartrecord` DISABLE KEYS */;
INSERT INTO `orchard_widgets_layerpartrecord` VALUES (3,'Default','The widgets in this layer are displayed on all pages','true'),(4,'Authenticated','The widgets in this layer are displayed when the user is authenticated','authenticated'),(5,'Anonymous','The widgets in this layer are displayed when the user is anonymous','not authenticated'),(6,'Disabled','The widgets in this layer are never displayed','false'),(7,'TheHomepage','The widgets in this layer are displayed on the home page','url \'~/\''),(23,'Test',NULL,'true');
/*!40000 ALTER TABLE `orchard_widgets_layerpartrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orchard_widgets_widgetpartrecord`
--

DROP TABLE IF EXISTS `orchard_widgets_widgetpartrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orchard_widgets_widgetpartrecord` (
  `Id` int(11) NOT NULL,
  `Title` varchar(255) DEFAULT NULL,
  `Position` varchar(255) DEFAULT NULL,
  `Zone` varchar(255) DEFAULT NULL,
  `RenderTitle` tinyint(1) DEFAULT '1',
  `Name` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orchard_widgets_widgetpartrecord`
--

LOCK TABLES `orchard_widgets_widgetpartrecord` WRITE;
/*!40000 ALTER TABLE `orchard_widgets_widgetpartrecord` DISABLE KEYS */;
INSERT INTO `orchard_widgets_widgetpartrecord` VALUES (8,'First Leader Aside','5','TripelFirst',1,NULL),(9,'Second Leader Aside','5','TripelSecond',1,NULL),(10,'Third Leader Aside','5','TripelThird',1,NULL),(14,'Main Menu','1','Navigation',0,NULL),(20,'MainMenu','1','Navigation',0,NULL);
/*!40000 ALTER TABLE `orchard_widgets_widgetpartrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `scheduling_scheduledtaskrecord`
--

DROP TABLE IF EXISTS `scheduling_scheduledtaskrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `scheduling_scheduledtaskrecord` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `TaskType` varchar(255) DEFAULT NULL,
  `ScheduledUtc` datetime DEFAULT NULL,
  `ContentItemVersionRecord_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `scheduling_scheduledtaskrecord`
--

LOCK TABLES `scheduling_scheduledtaskrecord` WRITE;
/*!40000 ALTER TABLE `scheduling_scheduledtaskrecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `scheduling_scheduledtaskrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `settings_contentfielddefinitionrecord`
--

DROP TABLE IF EXISTS `settings_contentfielddefinitionrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `settings_contentfielddefinitionrecord` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `settings_contentfielddefinitionrecord`
--

LOCK TABLES `settings_contentfielddefinitionrecord` WRITE;
/*!40000 ALTER TABLE `settings_contentfielddefinitionrecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `settings_contentfielddefinitionrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `settings_contentpartdefinitionrecord`
--

DROP TABLE IF EXISTS `settings_contentpartdefinitionrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `settings_contentpartdefinitionrecord` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL,
  `Hidden` tinyint(1) DEFAULT NULL,
  `Settings` text,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `settings_contentpartdefinitionrecord`
--

LOCK TABLES `settings_contentpartdefinitionrecord` WRITE;
/*!40000 ALTER TABLE `settings_contentpartdefinitionrecord` DISABLE KEYS */;
INSERT INTO `settings_contentpartdefinitionrecord` VALUES (1,'BodyPart',0,'<settings ContentPartSettings.Attachable=\"True\" BodyPartSettings.FlavorDefault=\"html\" />'),(2,'CommonPart',0,'<settings ContentPartSettings.Attachable=\"True\" />'),(3,'IdentityPart',0,'<settings ContentPartSettings.Attachable=\"True\" />'),(4,'WidgetPart',0,'<settings ContentPartSettings.Attachable=\"True\" />'),(5,'ContainerWidgetPart',0,NULL),(6,'ContainerPart',0,'<settings ContentPartSettings.Attachable=\"True\" />'),(7,'ContainablePart',0,'<settings ContentPartSettings.Attachable=\"True\" />'),(8,'CustomPropertiesPart',0,'<settings ContentPartSettings.Attachable=\"True\" />'),(9,'TitlePart',0,'<settings ContentPartSettings.Attachable=\"True\" />'),(10,'MenuPart',0,'<settings ContentPartSettings.Attachable=\"True\" />'),(11,'NavigationPart',0,'<settings ContentPartSettings.Attachable=\"True\" />'),(12,'MenuWidgetPart',0,NULL),(13,'AdminMenuPart',0,'<settings ContentPartSettings.Attachable=\"True\" />'),(14,'ContentMenuItemPart',0,NULL),(15,'PublishLaterPart',0,'<settings ContentPartSettings.Attachable=\"True\" />'),(16,'AutoroutePart',0,'<settings ContentPartSettings.Attachable=\"True\" />'),(17,'LayerPart',0,NULL),(18,'BlogPart',0,NULL),(19,'BlogPostPart',0,NULL),(20,'RecentBlogPostsPart',0,NULL),(21,'BlogArchivesPart',0,NULL),(22,'CommentPart',0,NULL),(23,'CommentsContainerPart',0,NULL),(24,'CommentsPart',0,'<settings ContentPartSettings.Attachable=\"True\" />'),(25,'QueryPart',0,NULL),(26,'ProjectionPart',0,NULL),(27,'NavigationQueryPart',0,NULL),(28,'TagsPart',0,'<settings ContentPartSettings.Attachable=\"True\" />'),(29,'LocalizationPart',0,NULL);
/*!40000 ALTER TABLE `settings_contentpartdefinitionrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `settings_contentpartfielddefinitionrecord`
--

DROP TABLE IF EXISTS `settings_contentpartfielddefinitionrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `settings_contentpartfielddefinitionrecord` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL,
  `Settings` text,
  `ContentFieldDefinitionRecord_id` int(11) DEFAULT NULL,
  `ContentPartDefinitionRecord_Id` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `settings_contentpartfielddefinitionrecord`
--

LOCK TABLES `settings_contentpartfielddefinitionrecord` WRITE;
/*!40000 ALTER TABLE `settings_contentpartfielddefinitionrecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `settings_contentpartfielddefinitionrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `settings_contenttypedefinitionrecord`
--

DROP TABLE IF EXISTS `settings_contenttypedefinitionrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `settings_contenttypedefinitionrecord` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL,
  `DisplayName` varchar(255) DEFAULT NULL,
  `Hidden` tinyint(1) DEFAULT NULL,
  `Settings` text,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `settings_contenttypedefinitionrecord`
--

LOCK TABLES `settings_contenttypedefinitionrecord` WRITE;
/*!40000 ALTER TABLE `settings_contenttypedefinitionrecord` DISABLE KEYS */;
INSERT INTO `settings_contenttypedefinitionrecord` VALUES (1,'Site','Site',0,'<settings />'),(2,'ContainerWidget','Container Widget',0,'<settings Stereotype=\"Widget\" />'),(3,'Page','Page',0,'<settings ContentTypeSettings.Creatable=\"True\" ContentTypeSettings.Draftable=\"True\" TypeIndexing.Included=\"true\" />'),(4,'MenuItem','Custom Link',0,'<settings Description=\"Represents a simple custom link with a text and an url.\" Stereotype=\"MenuItem\" />'),(5,'Menu','Menu',0,'<settings />'),(6,'MenuWidget','Menu Widget',0,'<settings Stereotype=\"Widget\" />'),(7,'HtmlMenuItem','Html Menu Item',0,'<settings Description=\"Renders some custom HTML in the menu.\" BodyPartSettings.FlavorDefault=\"html\" Stereotype=\"MenuItem\" />'),(8,'ContentMenuItem','Content Menu Item',0,'<settings Description=\"Adds a Content Item to the menu.\" Stereotype=\"MenuItem\" />'),(9,'User','User',0,'<settings ContentTypeSettings.Creatable=\"False\" />'),(10,'Layer','Layer',0,'<settings />'),(11,'HtmlWidget','Html Widget',0,'<settings Stereotype=\"Widget\" />'),(12,'Blog','Blog',0,'<settings />'),(13,'BlogPost','Blog Post',0,'<settings ContentTypeSettings.Draftable=\"True\" TypeIndexing.Included=\"true\" />'),(14,'RecentBlogPosts','Recent Blog Posts',0,'<settings Stereotype=\"Widget\" />'),(15,'BlogArchives','Blog Archives',0,'<settings Stereotype=\"Widget\" />'),(16,'Comment','Comment',0,'<settings />'),(17,'Query','Query',0,'<settings />'),(18,'ProjectionWidget','Projection Widget',0,'<settings Stereotype=\"Widget\" />'),(19,'ProjectionPage','Projection',0,'<settings ContentTypeSettings.Creatable=\"True\" />'),(20,'NavigationQueryMenuItem','Query Link',0,'<settings Description=\"Injects menu items from a Query\" Stereotype=\"MenuItem\" />');
/*!40000 ALTER TABLE `settings_contenttypedefinitionrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `settings_contenttypepartdefinitionrecord`
--

DROP TABLE IF EXISTS `settings_contenttypepartdefinitionrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `settings_contenttypepartdefinitionrecord` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Settings` text,
  `ContentPartDefinitionRecord_id` int(11) DEFAULT NULL,
  `ContentTypeDefinitionRecord_Id` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=76 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `settings_contenttypepartdefinitionrecord`
--

LOCK TABLES `settings_contenttypepartdefinitionrecord` WRITE;
/*!40000 ALTER TABLE `settings_contenttypepartdefinitionrecord` DISABLE KEYS */;
INSERT INTO `settings_contenttypepartdefinitionrecord` VALUES (1,'<settings />',2,2),(2,'<settings />',4,2),(3,'<settings />',5,2),(4,'<settings />',11,3),(5,'<settings DateEditorSettings.ShowDateEditor=\"true\" />',2,3),(6,'<settings />',15,3),(7,'<settings />',9,3),(8,'<settings AutorouteSettings.AllowCustomPattern=\"true\" AutorouteSettings.AutomaticAdjustmentOnEdit=\"false\" AutorouteSettings.PatternDefinitions=\"[{Name:\'Title\', Pattern: \'{Content.Slug}\', Description: \'my-page\'}]\" AutorouteSettings.DefaultPatternIndex=\"0\" />',16,3),(9,'<settings />',1,3),(10,'<settings />',10,4),(11,'<settings />',3,4),(12,'<settings />',2,4),(13,'<settings OwnerEditorSettings.ShowOwnerEditor=\"false\" />',2,5),(14,'<settings />',9,5),(15,'<settings />',2,6),(16,'<settings />',3,6),(17,'<settings />',4,6),(18,'<settings />',12,6),(19,'<settings />',10,7),(20,'<settings />',1,7),(21,'<settings />',2,7),(22,'<settings />',3,7),(23,'<settings />',10,8),(24,'<settings />',2,8),(25,'<settings />',3,8),(26,'<settings />',14,8),(27,'<settings />',17,10),(28,'<settings OwnerEditorSettings.ShowOwnerEditor=\"false\" />',2,10),(29,'<settings />',4,11),(30,'<settings />',1,11),(31,'<settings />',2,11),(32,'<settings />',3,11),(33,'<settings />',18,12),(34,'<settings />',2,12),(35,'<settings />',9,12),(36,'<settings AutorouteSettings.AllowCustomPattern=\"true\" AutorouteSettings.AutomaticAdjustmentOnEdit=\"false\" AutorouteSettings.PatternDefinitions=\"[{Name:\'Title\', Pattern: \'{Content.Slug}\', Description: \'my-blog\'}]\" AutorouteSettings.DefaultPatternIndex=\"0\" />',16,12),(37,'<settings />',10,12),(38,'<settings AdminMenuPartTypeSettings.DefaultPosition=\"2\" />',13,12),(39,'<settings />',23,12),(40,'<settings />',19,13),(41,'<settings DateEditorSettings.ShowDateEditor=\"true\" />',2,13),(42,'<settings />',15,13),(43,'<settings />',9,13),(44,'<settings AutorouteSettings.AllowCustomPattern=\"true\" AutorouteSettings.AutomaticAdjustmentOnEdit=\"false\" AutorouteSettings.PatternDefinitions=\"[{Name:\'Blog and Title\', Pattern: \'{Content.Container.Path}/{Content.Slug}\', Description: \'my-blog/my-post\'}]\" AutorouteSettings.DefaultPatternIndex=\"0\" />',16,13),(45,'<settings />',1,13),(46,'<settings />',20,14),(47,'<settings />',2,14),(48,'<settings />',4,14),(49,'<settings />',21,15),(50,'<settings />',2,15),(51,'<settings />',4,15),(52,'<settings />',22,16),(53,'<settings />',2,16),(54,'<settings />',3,16),(55,'<settings />',25,17),(56,'<settings />',9,17),(57,'<settings />',3,17),(58,'<settings />',4,18),(59,'<settings />',2,18),(60,'<settings />',3,18),(61,'<settings />',26,18),(62,'<settings />',2,19),(63,'<settings />',9,19),(64,'<settings AutorouteSettings.AllowCustomPattern=\"true\" AutorouteSettings.AutomaticAdjustmentOnEdit=\"false\" AutorouteSettings.PatternDefinitions=\"[{Name:\'Title\', Pattern: \'{Content.Slug}\', Description: \'my-projections\'}]\" AutorouteSettings.DefaultPatternIndex=\"0\" />',16,19),(65,'<settings />',10,19),(66,'<settings />',26,19),(67,'<settings AdminMenuPartTypeSettings.DefaultPosition=\"5\" />',13,19),(68,'<settings />',27,20),(69,'<settings />',10,20),(70,'<settings />',2,20),(71,'<settings />',28,3),(72,'<settings />',29,3),(73,'<settings />',24,13),(74,'<settings />',28,13),(75,'<settings />',29,13);
/*!40000 ALTER TABLE `settings_contenttypepartdefinitionrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `settings_shelldescriptorrecord`
--

DROP TABLE IF EXISTS `settings_shelldescriptorrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `settings_shelldescriptorrecord` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `SerialNumber` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `settings_shelldescriptorrecord`
--

LOCK TABLES `settings_shelldescriptorrecord` WRITE;
/*!40000 ALTER TABLE `settings_shelldescriptorrecord` DISABLE KEYS */;
INSERT INTO `settings_shelldescriptorrecord` VALUES (1,5);
/*!40000 ALTER TABLE `settings_shelldescriptorrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `settings_shellfeaturerecord`
--

DROP TABLE IF EXISTS `settings_shellfeaturerecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `settings_shellfeaturerecord` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL,
  `ShellDescriptorRecord_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=288 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `settings_shellfeaturerecord`
--

LOCK TABLES `settings_shellfeaturerecord` WRITE;
/*!40000 ALTER TABLE `settings_shellfeaturerecord` DISABLE KEYS */;
INSERT INTO `settings_shellfeaturerecord` VALUES (220,'Orchard.Framework',1),(221,'Common',1),(222,'Containers',1),(223,'Contents',1),(224,'Dashboard',1),(225,'Feeds',1),(226,'Navigation',1),(227,'Reports',1),(228,'Scheduling',1),(229,'Settings',1),(230,'Shapes',1),(231,'Title',1),(232,'Orchard.Pages',1),(233,'Orchard.Themes',1),(234,'Orchard.Users',1),(235,'Orchard.Roles',1),(236,'Orchard.Modules',1),(237,'PackagingServices',1),(238,'Orchard.Packaging',1),(239,'Gallery',1),(240,'Orchard.Recipes',1),(241,'Orchard.Blogs',1),(242,'Orchard.Widgets',1),(243,'Orchard.Scripting',1),(244,'Orchard.jQuery',1),(245,'Orchard.PublishLater',1),(246,'Orchard.jQuery',1),(247,'Orchard.Comments',1),(248,'Orchard.Tags',1),(249,'Orchard.jQuery',1),(250,'Orchard.Alias',1),(251,'Orchard.Autoroute',1),(252,'Orchard.Alias',1),(253,'Orchard.Tokens',1),(254,'TinyMce',1),(255,'Orchard.Media',1),(256,'Orchard.MediaPicker',1),(257,'Orchard.Media',1),(258,'Orchard.jQuery',1),(259,'Orchard.ContentPicker',1),(260,'Orchard.PublishLater',1),(261,'Orchard.jQuery',1),(262,'Orchard.jQuery',1),(263,'Orchard.Widgets',1),(264,'Orchard.Scripting',1),(265,'Orchard.Widgets.PageLayerHinting',1),(266,'Orchard.Widgets',1),(267,'Orchard.Scripting',1),(268,'Orchard.ContentTypes',1),(269,'Orchard.Scripting',1),(270,'Orchard.Scripting.Lightweight',1),(271,'Orchard.Scripting',1),(272,'PackagingServices',1),(273,'Orchard.Packaging',1),(274,'Orchard.Warmup',1),(275,'Orchard.Projections',1),(276,'Orchard.Tokens',1),(277,'Orchard.Forms',1),(278,'Orchard.Fields',1),(279,'Orchard.jQuery',1),(280,'Orchard.Media',1),(281,'Orchard.MediaPicker',1),(282,'Orchard.Media',1),(283,'Orchard.jQuery',1),(284,'TheThemeMachine',1),(285,'Bootstrap',1),(286,'MetricsCorporation.Orchard.Web',1),(287,'MetricsCorporation.Orchard.Api',1);
/*!40000 ALTER TABLE `settings_shellfeaturerecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `settings_shellfeaturestaterecord`
--

DROP TABLE IF EXISTS `settings_shellfeaturestaterecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `settings_shellfeaturestaterecord` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL,
  `InstallState` varchar(255) DEFAULT NULL,
  `EnableState` varchar(255) DEFAULT NULL,
  `ShellStateRecord_Id` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=47 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `settings_shellfeaturestaterecord`
--

LOCK TABLES `settings_shellfeaturestaterecord` WRITE;
/*!40000 ALTER TABLE `settings_shellfeaturestaterecord` DISABLE KEYS */;
INSERT INTO `settings_shellfeaturestaterecord` VALUES (1,'Orchard.Framework','Up','Up',1),(2,'Common','Up','Up',1),(3,'Containers','Up','Up',1),(4,'Contents','Up','Up',1),(5,'Dashboard','Up','Up',1),(6,'Feeds','Up','Up',1),(7,'Navigation','Up','Up',1),(8,'Reports','Up','Up',1),(9,'Scheduling','Up','Up',1),(10,'Settings','Up','Up',1),(11,'Shapes','Up','Up',1),(12,'Title','Up','Up',1),(13,'Orchard.Pages','Up','Up',1),(14,'Orchard.Themes','Up','Up',1),(15,'Orchard.Users','Up','Up',1),(16,'Orchard.Roles','Up','Up',1),(17,'Orchard.Modules','Up','Up',1),(18,'PackagingServices','Up','Up',1),(19,'Orchard.Packaging','Up','Up',1),(20,'Gallery','Up','Up',1),(21,'Orchard.Recipes','Up','Up',1),(22,'Orchard.Blogs','Up','Up',1),(23,'Orchard.Widgets','Up','Up',1),(24,'Orchard.Scripting','Up','Up',1),(25,'Orchard.jQuery','Up','Up',1),(26,'Orchard.PublishLater','Up','Up',1),(27,'Orchard.Comments','Up','Up',1),(28,'Orchard.Tags','Up','Up',1),(29,'Orchard.Alias','Up','Up',1),(30,'Orchard.Autoroute','Up','Up',1),(31,'Orchard.Tokens','Up','Up',1),(32,'TinyMce','Up','Up',1),(33,'Orchard.Media','Up','Up',1),(34,'Orchard.MediaPicker','Up','Up',1),(35,'Orchard.ContentPicker','Up','Up',1),(36,'Orchard.Widgets.PageLayerHinting','Up','Up',1),(37,'Orchard.ContentTypes','Up','Up',1),(38,'Orchard.Scripting.Lightweight','Up','Up',1),(39,'Orchard.Warmup','Up','Up',1),(40,'Orchard.Projections','Up','Up',1),(41,'Orchard.Forms','Up','Up',1),(42,'Orchard.Fields','Up','Up',1),(43,'TheThemeMachine','Up','Up',1),(44,'Bootstrap','Up','Up',1),(45,'MetricsCorporation.Orchard.Web','Up','Up',1),(46,'MetricsCorporation.Orchard.Api','Up','Up',1);
/*!40000 ALTER TABLE `settings_shellfeaturestaterecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `settings_shellparameterrecord`
--

DROP TABLE IF EXISTS `settings_shellparameterrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `settings_shellparameterrecord` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Component` varchar(255) DEFAULT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `Value` varchar(255) DEFAULT NULL,
  `ShellDescriptorRecord_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `settings_shellparameterrecord`
--

LOCK TABLES `settings_shellparameterrecord` WRITE;
/*!40000 ALTER TABLE `settings_shellparameterrecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `settings_shellparameterrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `settings_shellstaterecord`
--

DROP TABLE IF EXISTS `settings_shellstaterecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `settings_shellstaterecord` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Unused` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `settings_shellstaterecord`
--

LOCK TABLES `settings_shellstaterecord` WRITE;
/*!40000 ALTER TABLE `settings_shellstaterecord` DISABLE KEYS */;
INSERT INTO `settings_shellstaterecord` VALUES (1,NULL);
/*!40000 ALTER TABLE `settings_shellstaterecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `settings_sitesettings2partrecord`
--

DROP TABLE IF EXISTS `settings_sitesettings2partrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `settings_sitesettings2partrecord` (
  `Id` int(11) NOT NULL,
  `BaseUrl` text,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `settings_sitesettings2partrecord`
--

LOCK TABLES `settings_sitesettings2partrecord` WRITE;
/*!40000 ALTER TABLE `settings_sitesettings2partrecord` DISABLE KEYS */;
INSERT INTO `settings_sitesettings2partrecord` VALUES (1,'http://localhost:1984');
/*!40000 ALTER TABLE `settings_sitesettings2partrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `settings_sitesettingspartrecord`
--

DROP TABLE IF EXISTS `settings_sitesettingspartrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `settings_sitesettingspartrecord` (
  `Id` int(11) NOT NULL,
  `SiteSalt` varchar(255) DEFAULT NULL,
  `SiteName` varchar(255) DEFAULT NULL,
  `SuperUser` varchar(255) DEFAULT NULL,
  `PageTitleSeparator` varchar(255) DEFAULT NULL,
  `HomePage` varchar(255) DEFAULT NULL,
  `SiteCulture` varchar(255) DEFAULT NULL,
  `ResourceDebugMode` varchar(255) DEFAULT 'FromAppSetting',
  `PageSize` int(11) DEFAULT NULL,
  `SiteTimeZone` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `settings_sitesettingspartrecord`
--

LOCK TABLES `settings_sitesettingspartrecord` WRITE;
/*!40000 ALTER TABLE `settings_sitesettingspartrecord` DISABLE KEYS */;
INSERT INTO `settings_sitesettingspartrecord` VALUES (1,'d02b92f765694ce681599ab9534c711b','MetricsCorporation','admin',' - ',NULL,'en-US','FromAppSetting',10,'FLE Standard Time');
/*!40000 ALTER TABLE `settings_sitesettingspartrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `title_titlepartrecord`
--

DROP TABLE IF EXISTS `title_titlepartrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `title_titlepartrecord` (
  `Id` int(11) NOT NULL,
  `ContentItemRecord_id` int(11) DEFAULT NULL,
  `Title` text,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `title_titlepartrecord`
--

LOCK TABLES `title_titlepartrecord` WRITE;
/*!40000 ALTER TABLE `title_titlepartrecord` DISABLE KEYS */;
INSERT INTO `title_titlepartrecord` VALUES (11,11,'Main Menu'),(12,12,'Welcome to Orchard!');
/*!40000 ALTER TABLE `title_titlepartrecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'test'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2012-12-28 14:48:42
