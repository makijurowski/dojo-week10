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

 Date: 29/10/2017 14:58:05
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for Comments
-- ----------------------------
DROP TABLE IF EXISTS `Comments`;
CREATE TABLE `Comments` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `message_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `comment` text NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `message_id` (`message_id`),
  KEY `author_id` (`user_id`),
  CONSTRAINT `author_id` FOREIGN KEY (`user_id`) REFERENCES `Users` (`id`),
  CONSTRAINT `message_id` FOREIGN KEY (`message_id`) REFERENCES `Messages` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Comments
-- ----------------------------
BEGIN;
INSERT INTO `Comments` VALUES (1, 4, 6, 'Condimentum vitae sapien pellentesque habitant morbi tristique senectus et netus. Aliquam vestibulum morbi blandit cursus risus at ultrices. Suspendisse faucibus interdum posuere lorem ipsum. Rhoncus dolor purus non enim. Aliquam ultrices sagittis orci a scelerisque purus semper eget duis. Nunc consequat interdum varius sit amet mattis vulputate. Posuere urna nec tincidunt praesent semper feugiat nibh sed. Ut pharetra sit amet aliquam id diam. Congue nisi vitae suscipit tellus mauris a.', '2017-10-28 20:05:59', '2017-10-28 20:05:59');
INSERT INTO `Comments` VALUES (2, 4, 6, 'Laoreet suspendisse interdum consectetur libero id faucibus nisl tincidunt eget. Accumsan sit amet nulla facilisi morbi tempus iaculis urna. ', '2017-10-28 20:04:55', '2017-10-28 20:04:55');
INSERT INTO `Comments` VALUES (3, 4, 6, 'Aliquam ultrices sagittis orci a scelerisque purus semper eget duis. Nunc consequat interdum varius sit amet mattis vulputate. Posuere urna nec tincidunt praesent semper feugiat nibh sed. ', '2017-10-28 20:04:48', '2017-10-28 20:04:48');
INSERT INTO `Comments` VALUES (4, 1, 6, 'Mattis molestie a iaculis at erat pellentesque. Posuere morbi leo urna molestie at elementum eu facilisis sed. Rhoncus mattis rhoncus urna neque. Arcu cursus vitae congue mauris rhoncus aenean vel.', '2017-10-28 20:04:33', '2017-10-28 20:04:33');
INSERT INTO `Comments` VALUES (5, 1, 6, 'Gravida cum sociis natoque penatibus et. Velit euismod in pellentesque massa placerat. Non curabitur gravida arcu ac tortor dignissim convallis aenean et. At in tellus integer feugiat scelerisque varius.', '2017-10-28 20:05:11', '2017-10-28 20:05:11');
INSERT INTO `Comments` VALUES (6, 1, 6, 'Urna porttitor rhoncus dolor purus non enim. Et ligula ullamcorper malesuada proin libero nunc consequat interdum. Elit duis tristique sollicitudin nibh sit amet. Vitae nunc sed velit dignissim sodales ut.', '2017-10-28 20:05:19', '2017-10-28 20:05:19');
INSERT INTO `Comments` VALUES (7, 1, 6, 'Interdum varius sit amet mattis vulputate enim nulla aliquet. Nulla facilisi morbi tempus iaculis urna id volutpat. Aliquet bibendum enim facilisis gravida neque convallis a cras.', '2017-10-28 20:04:40', '2017-10-28 20:04:40');
INSERT INTO `Comments` VALUES (8, 1, 6, 'Aliquam ultrices sagittis orci a scelerisque purus semper eget duis. Nunc consequat interdum varius sit amet mattis vulputate. Posuere urna nec tincidunt praesent semper feugiat nibh sed. ', '2017-10-28 20:05:29', '2017-10-28 20:05:29');
INSERT INTO `Comments` VALUES (9, 3, 6, 'Arcu odio ut sem nulla pharetra. Metus vulputate eu scelerisque felis imperdiet proin fermentum leo vel. Id volutpat lacus laoreet non curabitur. Porttitor rhoncus dolor purus non enim praesent elementum facilisis leo. Egestas purus viverra accumsan in nisl. Ullamcorper sit amet risus nullam eget felis eget nunc.', '2017-10-28 20:05:46', '2017-10-28 20:05:46');
INSERT INTO `Comments` VALUES (10, 6, 10, 'Congue eu consequat ac felis donec et odio pellentesque. Pulvinar elementum integer enim neque volutpat ac. In tellus integer feugiat scelerisque varius. Hendrerit gravida rutrum quisque non tellus orci. Lacus suspendisse faucibus interdum posuere lorem ipsum dolor sit amet. Quisque id diam vel quam elementum pulvinar etiam. Sed risus pretium quam vulputate dignissim suspendisse. Vitae suscipit tellus mauris a diam maecenas sed. ', '2017-10-28 20:05:40', '2017-10-28 20:05:40');
INSERT INTO `Comments` VALUES (11, 1, 6, 'Velit sed ullamcorper morbi tincidunt ornare massa eget egestas. Id interdum velit laoreet id donec. ', '2017-10-28 20:05:56', '2017-10-28 20:05:56');
INSERT INTO `Comments` VALUES (12, 4, 6, 'Are you sure about this one?', '2017-10-28 20:06:39', '2017-10-28 20:06:39');
INSERT INTO `Comments` VALUES (13, 5, 13, ' In scelerisque sem at dolor. Maecenas mattis. Sed convallis tristique sem. Proin ut ligula vel nunc egestas porttitor. Morbi lectus risus, iaculis vel, suscipit quis, luctus non, massa. Fusce ac turpis quis ligula lacinia aliquet. Mauris ipsum. Nulla metus metus, ullamcorper vel, tincidunt sed, euismod in, nibh. Quisque volutpat condimentum velit. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nam nec ante. Sed lacinia, urna non tincidunt mattis, tortor neque adipiscing diam, a cursus ipsum ante quis turpis. Nulla facilisi. Ut fringilla. Suspendisse potenti. Nunc feugiat mi a tellus consequat imperdiet. Vestibulum sapien. Proin quam. Etiam ultrices. Suspendisse in justo eu magna luctus suscipit. Sed lectus. Integer euismod lacus luctus magna. ', '2017-10-29 14:05:27', '2017-10-29 14:05:27');
INSERT INTO `Comments` VALUES (14, 8, 13, 'Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc. Curabitur tortor. ', '2017-10-29 14:05:52', '2017-10-29 14:05:52');
INSERT INTO `Comments` VALUES (15, 9, 13, 'Fusce ac turpis quis ligula lacinia aliquet. Mauris ipsum. Nulla metus metus, ullamcorper vel, tincidunt sed, euismod in, nibh. ', '2017-10-29 14:06:07', '2017-10-29 14:06:07');
INSERT INTO `Comments` VALUES (16, 7, 13, 'Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc. Curabitur tortor. ', '2017-10-29 14:06:23', '2017-10-29 14:06:23');
INSERT INTO `Comments` VALUES (17, 11, 13, 'What?', '2017-10-29 14:07:19', '2017-10-29 14:07:19');
INSERT INTO `Comments` VALUES (18, 3, 16, 'Happy to be here!', '2017-10-29 14:46:05', '2017-10-29 14:46:05');
INSERT INTO `Comments` VALUES (19, 2, 16, 'Thought I would leave you some love~', '2017-10-29 14:46:20', '2017-10-29 14:46:20');
INSERT INTO `Comments` VALUES (20, 12, 16, 'Cool story bro', '2017-10-29 14:46:28', '2017-10-29 14:46:28');
COMMIT;

-- ----------------------------
-- Table structure for Messages
-- ----------------------------
DROP TABLE IF EXISTS `Messages`;
CREATE TABLE `Messages` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `message` text NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `id` (`id`),
  KEY `id_2` (`id`),
  KEY `user_id` (`user_id`),
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
  CONSTRAINT `user_id` FOREIGN KEY (`user_id`) REFERENCES `Users` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Messages
-- ----------------------------
BEGIN;
INSERT INTO `Messages` VALUES (1, 6, 'Eu tincidunt tortor aliquam nulla. Morbi non arcu risus quis varius quam quisque id. Aliquam sem et tortor consequat id porta. Vulputate eu scelerisque felis imperdiet. Pulvinar etiam non quam lacus. Phasellus faucibus scelerisque eleifend donec. Eget nulla facilisi etiam dignissim. Semper auctor neque vitae tempus. Auctor neque vitae tempus quam pellentesque. Tortor condimentum lacinia quis vel eros donec ac odio. Nec sagittis aliquam malesuada bibendum arcu. Tortor consequat id porta nibh venenatis. Tempus urna et pharetra pharetra massa. Lorem dolor sed viverra ipsum nunc aliquet. Ipsum faucibus vitae aliquet nec ullamcorper sit amet risus.', '2017-10-28 20:03:18', '2017-10-28 20:03:18');
INSERT INTO `Messages` VALUES (2, 6, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ultrices neque ornare aenean euismod elementum nisi quis eleifend. Dignissim sodales ut eu sem integer. Felis imperdiet proin fermentum leo vel orci. Ut consequat semper viverra nam libero justo laoreet sit amet. Erat imperdiet sed euismod nisi. Sit amet justo donec enim diam. Quis viverra nibh cras pulvinar mattis nunc sed. Sed risus ultricies tristique nulla aliquet enim tortor. Id diam vel quam elementum pulvinar. Non odio euismod lacinia at quis. Magna sit amet purus gravida quis. Ut eu sem integer vitae justo eget magna. Vel eros donec ac odio tempor orci dapibus ultrices in. Eget egestas purus viverra accumsan in. Arcu non sodales neque sodales. Donec ultrices tincidunt arcu non sodales. Aenean et tortor at risus viverra adipiscing at in tellus. Id aliquet risus feugiat in ante.', '2017-10-28 20:02:38', '2017-10-28 20:02:38');
INSERT INTO `Messages` VALUES (3, 6, 'Facilisi cras fermentum odio eu feugiat pretium. Consectetur adipiscing elit duis tristique sollicitudin nibh. Maecenas accumsan lacus vel facilisis volutpat. ', '2017-10-28 20:04:02', '2017-10-28 20:04:02');
INSERT INTO `Messages` VALUES (4, 6, 'Elit duis tristique sollicitudin nibh sit amet. Vitae nunc sed velit dignissim sodales ut. Gravida cum sociis natoque penatibus et. Velit euismod in pellentesque massa placerat. Non curabitur gravida arcu ac tortor dignissim convallis aenean et. At in tellus integer feugiat scelerisque varius. Duis ultricies lacus sed turpis tincidunt id. Mattis molestie a iaculis at erat pellentesque. Posuere morbi leo urna molestie at elementum eu facilisis sed. ', '2017-10-28 20:03:59', '2017-10-28 20:03:59');
INSERT INTO `Messages` VALUES (5, 6, 'Pulvinar elementum integer enim neque volutpat ac. In tellus integer feugiat scelerisque varius. Hendrerit gravida rutrum quisque non tellus orci. Lacus suspendisse faucibus interdum posuere lorem ipsum dolor sit amet. Quisque id diam vel quam elementum pulvinar etiam. Sed risus pretium quam vulputate dignissim suspendisse. Vitae suscipit tellus mauris a diam maecenas sed. Tempor orci eu lobortis elementum nibh. Accumsan lacus vel facilisis volutpat est velit egestas. Tincidunt tortor aliquam nulla facilisi cras fermentum odio. Pretium vulputate sapien nec sagittis. Elementum pulvinar etiam non quam.', '2017-10-28 20:03:49', '2017-10-28 20:03:49');
INSERT INTO `Messages` VALUES (6, 6, 'Donec ac odio tempor orci dapibus ultrices in iaculis nunc. Hac habitasse platea dictumst quisque sagittis purus sit amet. Volutpat lacus laoreet non curabitur gravida arcu. Fames ac turpis egestas sed tempus urna. Dui id ornare arcu odio. Urna molestie at elementum eu facilisis sed odio. Varius duis at consectetur lorem donec. Id cursus metus aliquam eleifend mi in. Porttitor eget dolor morbi non arcu risus quis varius quam. Purus non enim praesent elementum. Turpis egestas maecenas pharetra convallis posuere. Suspendisse faucibus interdum posuere lorem ipsum dolor sit. Eu feugiat pretium nibh ipsum consequat nisl vel pretium lectus. Ut faucibus pulvinar elementum integer enim neque volutpat ac tincidunt.', '2017-10-28 20:02:51', '2017-10-28 20:02:51');
INSERT INTO `Messages` VALUES (7, 6, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Quis eleifend quam adipiscing vitae proin sagittis. Pellentesque dignissim enim sit amet venenatis urna cursus eget nunc. Integer enim neque volutpat ac tincidunt vitae semper quis. Nunc sed blandit libero volutpat sed cras ornare.', '2017-10-28 20:03:40', '2017-10-28 20:03:40');
INSERT INTO `Messages` VALUES (8, 6, 'Fermentum leo vel orci porta. Tortor id aliquet lectus proin nibh nisl. Duis tristique sollicitudin nibh sit amet commodo nulla. Eleifend donec pretium vulputate sapien. Turpis egestas pretium aenean pharetra magna ac. Nisl pretium fusce id velit ut tortor pretium. Turpis nunc eget lorem dolor sed viverra ipsum nunc. Auctor elit sed vulputate mi sit amet. Ac tincidunt vitae semper quis. Duis at consectetur lorem donec massa. Integer eget aliquet nibh praesent tristique. At risus viverra adipiscing at in tellus integer. Maecenas sed enim ut sem viverra aliquet eget sit. Consectetur adipiscing elit duis tristique sollicitudin. Quis enim lobortis scelerisque fermentum dui faucibus in.', '2017-10-28 20:03:04', '2017-10-28 20:03:04');
INSERT INTO `Messages` VALUES (9, 6, 'Id interdum velit laoreet id donec. Mauris ultrices eros in cursus turpis. Sed risus pretium quam vulputate dignissim. Neque ornare aenean euismod elementum nisi. A arcu cursus vitae congue mauris. Dictum non consectetur a erat nam at lectus urna duis. Vitae proin sagittis nisl rhoncus mattis rhoncus urna. Augue eget arcu dictum varius. Enim ut tellus elementum sagittis vitae et leo duis. Nulla at volutpat diam ut venenatis. Scelerisque varius morbi enim nunc faucibus a pellentesque. Sociis natoque penatibus et magnis dis parturient montes nascetur.', '2017-10-28 20:02:56', '2017-10-28 20:02:56');
INSERT INTO `Messages` VALUES (10, 12, 'The wall is a happy and fun space where you can post whatever you want and share it with others.', '2017-10-28 20:52:08', '2017-10-28 20:52:08');
INSERT INTO `Messages` VALUES (11, 13, 'Quisque volutpat condimentum velit. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nam nec ante. Sed lacinia, urna non tincidunt mattis, tortor neque adipiscing diam, a cursus ipsum ante quis turpis. Nulla facilisi. Ut fringilla. Suspendisse potenti. Nunc feugiat mi a tellus consequat imperdiet. Vestibulum sapien. Proin quam. Etiam ultrices. Suspendisse in justo eu magna luctus suscipit. Sed lectus. Integer euismod lacus luctus magna. Quisque cursus, metus vitae pharetra auctor, sem massa mattis sem, at interdum magna augue eget diam. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Morbi lacinia molestie dui. Praesent blandit dolor. Sed non quam. In vel mi sit amet augue congue elementum. Morbi in ipsum sit amet pede facilisis laoreet. Donec lacus nunc, viverra nec.', '2017-10-29 14:06:37', '2017-10-29 14:06:37');
INSERT INTO `Messages` VALUES (12, 6, 'KNSA', '2017-10-29 14:44:33', '2017-10-29 14:44:33');
COMMIT;

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

-- ----------------------------
-- Records of Users
-- ----------------------------
BEGIN;
INSERT INTO `Users` VALUES (1, 'Maki', 'Poopy', 'maki@poop.com', 'AQAAAAEAACcQAAAAEIer9/daD9GFzGKzlLSG6W7FWgkCyzUwzOib4jteTlxUimJ8Bq5vHEPwAqXCm4gqMA==', '2017-10-25 19:55:59', '2017-10-25 19:55:59');
INSERT INTO `Users` VALUES (2, 'Maki', 'Roggers', 'maki@maki5.com', 'AQAAAAEAACcQAAAAEIer9/daD9GFzGKzlLSG6W7FWgkCyzUwzOib4jteTlxUimJ8Bq5vHEPwAqXCm4gqMA==', '2017-10-25 19:52:18', '2017-10-25 19:52:18');
INSERT INTO `Users` VALUES (3, 'Steven', 'Maki', 'steve@steve.com', 'AQAAAAEAACcQAAAAELS6/MuK0UVQ2o2sXl4EEK6lACgBxx7UBEq0gjq+dOuxS+IK8jQrxKPWdFKErNe1Vg==', '2017-10-25 20:31:11', '2017-10-25 20:31:11');
INSERT INTO `Users` VALUES (4, 'Lola', 'Lola', 'lola@lola.com', 'AQAAAAEAACcQAAAAEIlTkOYa4DO2w2O4fCvq/y+PYyZvTmso2i28WbXw8j9dsQCW7i4hCKJCj8pxpbegjw==', '2017-10-25 20:32:28', '2017-10-25 20:32:28');
INSERT INTO `Users` VALUES (5, 'Maki', 'Roggers', 'maki5@maki5.com', 'AQAAAAEAACcQAAAAEMd1FH6XXmSxE5h+HYH1kNEvbNwODb/EoPjNEuQena/tk9YMg9Cvl/MH0kAY9prl7A==', '2017-10-25 22:54:42', '2017-10-25 22:54:42');
INSERT INTO `Users` VALUES (6, 'Maki', 'Roggers', 'maki@maki.com', 'AQAAAAEAACcQAAAAEFdcYGREp47fyew+utKzKpl+1TO5AnPGLeLAXsxd4xrrFryfA9HghcWvSlAnmmlXxA==', '2017-10-26 00:52:42', '2017-10-26 00:52:42');
INSERT INTO `Users` VALUES (7, 'Maki', 'MakiMaki', 'maki10@maki10.com', 'AQAAAAEAACcQAAAAEN0DUI3ZalNkd3fNq9g5GxBzyGyutdtDzVuWnGSQiU2ePPNLuDHtAanntKd3pfu88g==', '2017-10-26 11:07:13', '2017-10-26 11:07:13');
INSERT INTO `Users` VALUES (8, 'Maki', 'Maki', 'maki20@maki20.com', 'AQAAAAEAACcQAAAAEDlUqY8VeIgkvN2178XjTj0CAG0qwjGhmxgxivZjijceqlF1Uywp5gtyeyi1y8Izbg==', '2017-10-26 14:02:41', '2017-10-26 14:02:41');
INSERT INTO `Users` VALUES (9, 'Maki', 'Roggers', 'maki@slownova.com', 'AQAAAAEAACcQAAAAEJYeZEVi7wT9PnOgSdnAMhhtjx+0JmcKSZPLnWI5I4Igk1ah+MESqniV1tkuY+ZAuQ==', '2017-10-26 19:24:12', '2017-10-26 19:24:12');
INSERT INTO `Users` VALUES (10, 'Jimbo', 'Jimbo', 'jimbo@jimbo.com', 'AQAAAAEAACcQAAAAEBWGgZ5tHIXB3NOPUGmrj5r0uHnYyXq1mO7HdqaEBEghlkby6wQbjgDXvNR+miSRzg==', '2017-10-27 16:39:01', '2017-10-27 16:39:01');
INSERT INTO `Users` VALUES (11, 'Pimple', 'Puss', 'yuck@yuck.com', 'AQAAAAEAACcQAAAAEOmSfe7fV8pqMWPc0OjP2xIA+cs97fiQj5u8rOhuPYpiZycEZl9wLpztQogyqOxl5A==', '2017-10-27 20:51:06', '2017-10-27 20:51:06');
INSERT INTO `Users` VALUES (12, 'Silly', 'Sally', 'sally@sally.com', 'AQAAAAEAACcQAAAAEG1eeqzKJ5Fd3yODqPgiXE6L2DPgWtgjGsu2iDjDDlMTFwxQbKzU2/tCNAEn/j7c0w==', '2017-10-28 20:51:42', '2017-10-28 20:51:42');
INSERT INTO `Users` VALUES (13, 'Thai', 'Peanuts', 'thai@thai.com', 'AQAAAAEAACcQAAAAEPbNqfYnhnz8qn1F+dp84a3gTEcM81GKRY7OXo0ZQh3U1DQ830GHL29hoMu3qY7GfA==', '2017-10-29 14:04:48', '2017-10-29 14:04:48');
INSERT INTO `Users` VALUES (14, 'Sam', 'Samuelson', 'sam@sam.com', 'AQAAAAEAACcQAAAAEAfeCVQh3glexDnP58YCVFJbAcz2Lwo1kHzn5whyKUzVqNFa7EkBkd4mxkfFlavUBw==', '2017-10-29 14:11:33', '2017-10-29 14:11:33');
INSERT INTO `Users` VALUES (15, 'Ikam', 'Ikam', 'ikam@ikam.com', 'AQAAAAEAACcQAAAAEHT4+7bo/JXzrWdHyxbzCeBeFIfOxElnRRBn0ZHPCtxL/rKu0dMYwNkNJtE8W1psxw==', '2017-10-29 14:35:45', '2017-10-29 14:35:45');
INSERT INTO `Users` VALUES (16, 'Ginger', 'May', 'may@may.com', 'AQAAAAEAACcQAAAAELfOIO8NuXS/fWbHxjb70+fx+BP2ER5d+hnZP3QZ3gPZGliQOjX2IVWcdEBJiGT0nA==', '2017-10-29 14:45:54', '2017-10-29 14:45:54');
COMMIT;

-- ----------------------------
-- View structure for all_data
-- ----------------------------
DROP VIEW IF EXISTS `all_data`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `all_data` AS select `comments_messages_users_copy1`.`comment_id` AS `comment_id`,`comments_messages_users_copy1`.`comment_user_id` AS `comment_user_id`,`comments_messages_users_copy1`.`comment` AS `comment`,`comments_messages_users_copy1`.`comment_user` AS `comment_username`,`comments_messages_users_copy1`.`comment_email` AS `comment_email`,`comments_messages_users_copy1`.`comment_created_at` AS `comment_created_at`,`comments_messages_users_copy1`.`comment_updated_at` AS `comment_updated_at`,`comments_messages_users_copy1`.`message_id` AS `message_id`,`comments_messages_users_copy1`.`message_user_id` AS `message_user_id`,`messages_users`.`message_username` AS `message_username`,`messages_users`.`message_email` AS `message_email`,`comments_messages_users_copy1`.`message` AS `message`,`comments_messages_users_copy1`.`message_created_at` AS `message_created_at`,`comments_messages_users_copy1`.`message_updated_at` AS `message_updated_at` from (`comments_messages_users_copy1` join `messages_users` on((`comments_messages_users_copy1`.`message_id` = `messages_users`.`id`)));

-- ----------------------------
-- View structure for comments_messages_users
-- ----------------------------
DROP VIEW IF EXISTS `comments_messages_users`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `comments_messages_users` AS select `comments_users`.`comment_id` AS `comment_id`,`comments_users`.`comment_user_id` AS `comment_user_id`,`comments_users`.`comment` AS `comment`,`comments_users`.`comment_user` AS `comment_user`,`comments_users`.`comment_email` AS `comment_email`,`comments_users`.`comment_created_at` AS `comment_created_at`,`comments_users`.`comment_updated_at` AS `comment_updated_at`,`comments_users`.`message_id` AS `message_id`,`messages`.`user_id` AS `message_user_id`,`messages`.`message` AS `message`,`messages`.`created_at` AS `message_created_at`,`messages`.`updated_at` AS `message_updated_at` from (`comments_users` join `messages` on((`comments_users`.`message_id` = `messages`.`id`)));

-- ----------------------------
-- View structure for comments_users
-- ----------------------------
DROP VIEW IF EXISTS `comments_users`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `comments_users` AS select `comments`.`id` AS `comment_id`,`comments`.`user_id` AS `comment_user_id`,`comments`.`comment` AS `comment`,`users`.`first_name` AS `comment_user`,`users`.`email` AS `comment_email`,`comments`.`created_at` AS `comment_created_at`,`comments`.`updated_at` AS `comment_updated_at`,`comments`.`message_id` AS `message_id` from (`comments` join `users` on((`comments`.`user_id` = `users`.`id`)));

-- ----------------------------
-- View structure for messages_users
-- ----------------------------
DROP VIEW IF EXISTS `messages_users`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `messages_users` AS select `messages`.`id` AS `id`,`messages`.`user_id` AS `user_id`,`users`.`first_name` AS `message_username`,`users`.`email` AS `message_email`,`messages`.`message` AS `message`,`messages`.`created_at` AS `message_created_at`,`messages`.`updated_at` AS `message_updated_at` from (`messages` join `users` on((`messages`.`user_id` = `users`.`id`)));

SET FOREIGN_KEY_CHECKS = 1;
