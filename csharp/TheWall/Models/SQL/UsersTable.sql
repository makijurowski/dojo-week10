/*
 Navicat Premium Data Transfer

 Source Server         : mySQL
 Source Server Type    : MySQL
 Source Server Version : 50719
 Source Host           : localhost:3306
 Source Schema         : mydb

 Target Server Type    : MySQL
 Target Server Version : 50719
 File Encoding         : 65001

 Date: 29/10/2017 14:54:53
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for Users
-- ----------------------------
DROP TABLE IF EXISTS `Users`;
CREATE TABLE `Users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `first_name` varchar(255) NOT NULL,
  `last_name` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`,`email`),
  KEY `id` (`id`),
  KEY `id_2` (`id`),
  KEY `id_3` (`id`),
  KEY `id_4` (`id`),
  KEY `id_5` (`id`),
  KEY `id_6` (`id`),
  KEY `id_7` (`id`),
  KEY `id_8` (`id`),
  KEY `id_9` (`id`),
  KEY `id_10` (`id`),
  KEY `id_11` (`id`),
  KEY `id_12` (`id`),
  KEY `id_13` (`id`),
  KEY `id_14` (`id`),
  KEY `id_15` (`id`),
  KEY `id_16` (`id`),
  KEY `id_17` (`id`),
  KEY `id_18` (`id`),
  KEY `id_19` (`id`),
  KEY `id_20` (`id`),
  KEY `id_21` (`id`),
  KEY `id_22` (`id`),
  KEY `id_23` (`id`),
  KEY `id_24` (`id`),
  KEY `id_25` (`id`),
  KEY `id_26` (`id`),
  KEY `id_27` (`id`),
  KEY `id_28` (`id`),
  KEY `id_29` (`id`),
  KEY `id_30` (`id`),
  KEY `id_31` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;

SET FOREIGN_KEY_CHECKS = 1;
