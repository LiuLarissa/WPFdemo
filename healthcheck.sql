-- MySQL dump 10.13  Distrib 8.0.25, for Win64 (x86_64)
--
-- Host: localhost    Database: d_healthcheck
-- ------------------------------------------------------
-- Server version	8.0.25

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `t_blood`
--

DROP TABLE IF EXISTS `t_blood`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_blood` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_blood`
--

LOCK TABLES `t_blood` WRITE;
/*!40000 ALTER TABLE `t_blood` DISABLE KEYS */;
INSERT INTO `t_blood` VALUES (1,'血常规'),(2,'肝功'),(4,'血脂'),(5,'空腹血糖');
/*!40000 ALTER TABLE `t_blood` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_blooditem`
--

DROP TABLE IF EXISTS `t_blooditem`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_blooditem` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(20) DEFAULT NULL,
  `standard` varchar(20) DEFAULT NULL,
  `unit` varchar(20) DEFAULT NULL,
  `higher` varchar(300) DEFAULT NULL,
  `lower` varchar(300) DEFAULT NULL,
  `bloodid` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `bloodid` (`bloodid`),
  CONSTRAINT `t_blooditem_ibfk_1` FOREIGN KEY (`bloodid`) REFERENCES `t_blood` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_blooditem`
--

LOCK TABLES `t_blooditem` WRITE;
/*!40000 ALTER TABLE `t_blooditem` DISABLE KEYS */;
INSERT INTO `t_blooditem` VALUES (1,'红细胞RBC','3.5-5.5','10^12/L','真性红细胞增多症、严重脱水、肺源性心脏病、先天性心脏病、高山地区的居民、严重烧伤等','贫血',1),(2,'血红蛋白HGB','110-160','g/L','真性红细胞增多症、严重脱水、肺源性心脏病、先天性心脏病、高山地区的居民、严重烧伤等','贫血',1),(3,'白细胞WBC','4-10','10^9/L','各种细胞感染、炎症、严重烧伤。当白细胞超过200-500且伴有发热、出血、贫血等症状时应警惕白血病','白细胞减少症、脾功能亢进、造血功能障碍等',1),(4,'中性粒细胞比率NEUT%','50-70','%','代表炎症，见于各种感染，包括细菌和病毒','各种感染（多为病毒），中性粒细胞减少症',1),(5,'淋巴细胞LYM','0.8-4','10^9/L','百日咳、传染性单核细胞增多症、急性传染性淋巴细胞增多症、淋巴细胞性白血病等','免疫缺陷等',1),(6,'血小板PLT','100-320','10^9/L','原发性血小板增多症、真性红细胞增多症、慢性白血病、症状性血小板增多症、感染、炎症、恶行肿瘤、缺铁性贫血、外伤、手术、出血等','原发性血小板减少性紫癜、播散性红斑狼疮、药物过敏性血小板减少症、弥漫性血管内凝血、血小板破坏增多、血小板生成减少等',1),(8,'空腹葡萄糖GLU','3.9-6.11','mmol/L','可见于糖尿病、甲状腺功能亢进、皮质醇增多症、肢端肥大症、嗜铬细胞瘤、脑外伤、脑溢血等应激状态；妊娠呕吐、脱水、全身麻醉时，肝硬化病人等','可见于各种原因引起的胰岛素分泌过多或对抗胰岛素的激素分泌不足、甲状腺功能不全、肾上腺功能不全、急性进行性肝脏疾病等',5),(9,'谷丙转氨酶ALT','<40','U/L','可见于肝胆疾病，如急慢性肝炎、胆石症引起的胆道梗阻等；某些药物造成的肝脏损伤',NULL,2),(10,'谷草转氨酶AST','<40','U/L','可见于急慢性肝炎等肝脏疾病及某些药物的毒副作用。与ALT主要显示肝脏疾病不同。AST还可存在于心肌、骨骼肌、肾脏，所以AST升高还可见于心肌梗死、心肌炎、肌溶解等疾病',NULL,2),(11,'总胆红素TBLL','2-19','umol/L','若伴随转氨酶升高，多见于黄疸型肝炎或其他疾病造成的黄疸症状，否则主要见于慢性溶血及先天胆红素代谢异常',NULL,2),(12,'直接胆红素DBIL','0-6.84','mmol/L','同上',NULL,2);
/*!40000 ALTER TABLE `t_blooditem` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_cancer`
--

DROP TABLE IF EXISTS `t_cancer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_cancer` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_cancer`
--

LOCK TABLES `t_cancer` WRITE;
/*!40000 ALTER TABLE `t_cancer` DISABLE KEYS */;
INSERT INTO `t_cancer` VALUES (1,'乳腺癌'),(2,'肺癌'),(3,'结直肠癌'),(4,'甲状腺癌'),(5,'胃癌'),(6,'宫颈癌'),(7,'肝癌'),(8,'子宫内膜癌'),(9,'食道癌');
/*!40000 ALTER TABLE `t_cancer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_item`
--

DROP TABLE IF EXISTS `t_item`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_item` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(20) DEFAULT NULL,
  `period` varchar(20) DEFAULT NULL,
  `desp` varchar(1000) DEFAULT NULL,
  `cancerid` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `cancerid` (`cancerid`),
  CONSTRAINT `t_item_ibfk_1` FOREIGN KEY (`cancerid`) REFERENCES `t_cancer` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_item`
--

LOCK TABLES `t_item` WRITE;
/*!40000 ALTER TABLE `t_item` DISABLE KEYS */;
INSERT INTO `t_item` VALUES (1,'乳腺钼靶','2年1次','建议40岁以上开始检查，有家族史要尽早检查',1),(2,'乳腺彩超','1年1次','建议20岁以上开始检查',1),(3,'低剂量螺旋CT','1年1次','结节<3mm，建议每年复查；3mm<=结节<10mm,3个月复查增强CT；另：遵医嘱',2),(4,'肠镜','5-10年1次','40岁以上建议每2年1次，家族史需尽早开始',3),(5,'大便潜血','1年1次','如果检查有问题，仍需要肠镜',3),(6,'甲状腺彩超','1年1次','3级以下良性结节需要遵医嘱复查，3级以上恶行结节需手术取出',4),(7,'胃镜','2年1次','可选择无痛胃镜和胶囊胃镜',5),(8,'TCT检查','3年1次','尽量不选择宫颈刮片，漏检率很高',6),(9,'HPV病毒检测','3年1次',NULL,6),(10,'肝脏彩超','1年1次','如果已有肝病，需增加肝功能和乙肝DNA定量',7),(11,'甲胎蛋白AFP','1年1次',NULL,7),(12,'阴道彩超','1年1次','注意观察是否有不规则出血，绝经后妇女特别要注意',8),(13,'食管镜/胃镜','2年1次','建议食管和胃一起检查，有家族史尽早检查',9);
/*!40000 ALTER TABLE `t_item` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-12-14 11:33:03
