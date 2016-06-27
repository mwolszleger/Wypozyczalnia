-- MySQL dump 10.13  Distrib 5.5.21, for Win32 (x86)
--
-- Host: localhost    Database: wypozyczalnia
-- ------------------------------------------------------
-- Server version	5.5.21-log

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
-- Table structure for table `cars`
--

DROP TABLE IF EXISTS `cars`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cars` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `brand` char(30) COLLATE utf8_unicode_ci NOT NULL,
  `model` char(30) COLLATE utf8_unicode_ci NOT NULL,
  `year_of_construction` int(10) unsigned NOT NULL,
  `engine_displacement` double NOT NULL,
  `climatisation` enum('true','false') COLLATE utf8_unicode_ci NOT NULL,
  `fuel` enum('petrol','diesel','lpg') COLLATE utf8_unicode_ci DEFAULT NULL,
  `color` char(30) COLLATE utf8_unicode_ci NOT NULL,
  `registration_number` char(10) COLLATE utf8_unicode_ci NOT NULL,
  `price` double NOT NULL,
  `availability` enum('true','false') COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cars`
--

LOCK TABLES `cars` WRITE;
/*!40000 ALTER TABLE `cars` DISABLE KEYS */;
INSERT INTO `cars` VALUES (1,'Renault','Modus',2011,1.2,'true','petrol','srebrny','SY2729F',120,'true'),(2,'Fiat','Seicento',2003,1.1,'false','petrol','czerwony','SY23361',50,'true');
/*!40000 ALTER TABLE `cars` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customers`
--

DROP TABLE IF EXISTS `customers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `customers` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` char(30) COLLATE utf8_unicode_ci NOT NULL,
  `last_name` char(30) COLLATE utf8_unicode_ci NOT NULL,
  `street` char(30) COLLATE utf8_unicode_ci NOT NULL,
  `house_number` char(30) COLLATE utf8_unicode_ci NOT NULL,
  `flat_number` int(11) DEFAULT NULL,
  `code_town` char(6) COLLATE utf8_unicode_ci NOT NULL,
  `place` char(30) COLLATE utf8_unicode_ci NOT NULL,
  `phone_number` char(9) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customers`
--

LOCK TABLES `customers` WRITE;
/*!40000 ALTER TABLE `customers` DISABLE KEYS */;
INSERT INTO `customers` VALUES (1,'Jan','Kowalski','Prosta','3',0,'41-933','Radzionków','885665551'),(2,'Robert','Szymanski','Pochyla','2',0,'41-936','Bytom','555888999');
/*!40000 ALTER TABLE `customers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employees`
--

DROP TABLE IF EXISTS `employees`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `employees` (
  `login` char(30) COLLATE utf8_unicode_ci NOT NULL,
  `name` char(30) COLLATE utf8_unicode_ci NOT NULL,
  `last_name` char(30) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`login`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employees`
--

LOCK TABLES `employees` WRITE;
/*!40000 ALTER TABLE `employees` DISABLE KEYS */;
INSERT INTO `employees` VALUES ('jarzabek','Karol','Jarząbek'),('kowalski','Jan','Kowalski'),('nowak','Janina','Nowak');
/*!40000 ALTER TABLE `employees` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transactions`
--

DROP TABLE IF EXISTS `transactions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `transactions` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `id_car` int(10) unsigned NOT NULL,
  `id_customer` int(10) unsigned NOT NULL,
  `beginning_date` date NOT NULL,
  `end_date` date DEFAULT NULL,
  `employee_beginning` char(30) COLLATE utf8_unicode_ci NOT NULL,
  `employee_end` char(30) COLLATE utf8_unicode_ci DEFAULT NULL,
  `price` decimal(10,0) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id_car` (`id_car`),
  KEY `id_customer` (`id_customer`),
  KEY `employee_beginning` (`employee_beginning`),
  KEY `employee_end` (`employee_end`),
  CONSTRAINT `transactions_ibfk_1` FOREIGN KEY (`id_car`) REFERENCES `cars` (`id`),
  CONSTRAINT `transactions_ibfk_2` FOREIGN KEY (`id_customer`) REFERENCES `customers` (`id`),
  CONSTRAINT `transactions_ibfk_3` FOREIGN KEY (`employee_beginning`) REFERENCES `employees` (`login`),
  CONSTRAINT `transactions_ibfk_4` FOREIGN KEY (`employee_end`) REFERENCES `employees` (`login`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transactions`
--

LOCK TABLES `transactions` WRITE;
/*!40000 ALTER TABLE `transactions` DISABLE KEYS */;
INSERT INTO `transactions` VALUES (1,2,2,'2016-06-27','2016-06-27','kowalski','kowalski',50);
/*!40000 ALTER TABLE `transactions` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-06-27 23:46:49
