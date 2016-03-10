/*
MySQL Backup
Source Server Version: 5.5.47
Source Database: tonline
Date: 10/03/2016 11:45:07
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
--  Table structure for `almacen`
-- ----------------------------
DROP TABLE IF EXISTS `almacen`;
CREATE TABLE `almacen` (
  `AlmacenId` int(11) NOT NULL AUTO_INCREMENT,
  `Denominacion` varchar(255) NOT NULL,
  `LocalId` int(11) NOT NULL,
  PRIMARY KEY (`AlmacenId`),
  KEY `fkAlmacenLocal` (`LocalId`),
  CONSTRAINT `fkAlmacenLocal` FOREIGN KEY (`LocalId`) REFERENCES `local` (`LocalId`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
--  Table structure for `articulo`
-- ----------------------------
DROP TABLE IF EXISTS `articulo`;
CREATE TABLE `articulo` (
  `ArticuloId` int(11) NOT NULL AUTO_INCREMENT,
  `MarcaId` int(11) NOT NULL,
  `CategoriaId` int(11) NOT NULL,
  `Codigo` varchar(255) DEFAULT NULL,
  `Denominacion` varchar(255) NOT NULL,
  `Descripcion` text,
  `Precio` decimal(15,2) NOT NULL DEFAULT '0.00',
  `Imagen` varchar(255) DEFAULT NULL,
  `Estado` bit(1) NOT NULL,
  PRIMARY KEY (`ArticuloId`),
  UNIQUE KEY `pkArticuloId` (`ArticuloId`),
  KEY `fkArticuloMarca` (`MarcaId`),
  KEY `fkArticuloCategoria` (`CategoriaId`),
  CONSTRAINT `fkArticuloCategoria` FOREIGN KEY (`CategoriaId`) REFERENCES `categoria` (`CategoriaId`) ON DELETE NO ACTION ON UPDATE CASCADE,
  CONSTRAINT `fkArticuloMarca` FOREIGN KEY (`MarcaId`) REFERENCES `marca` (`MarcaId`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8;

-- ----------------------------
--  Table structure for `articulodet`
-- ----------------------------
DROP TABLE IF EXISTS `articulodet`;
CREATE TABLE `articulodet` (
  `ArticuloDetId` int(11) NOT NULL AUTO_INCREMENT,
  `ArticuloId` int(11) NOT NULL,
  `Detalle` varchar(255) NOT NULL,
  PRIMARY KEY (`ArticuloDetId`),
  KEY `fkArticuloDetalleArt` (`ArticuloId`) USING BTREE,
  CONSTRAINT `fkArticuloDetalleArt` FOREIGN KEY (`ArticuloId`) REFERENCES `articulo` (`ArticuloId`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
--  Table structure for `caracteristica`
-- ----------------------------
DROP TABLE IF EXISTS `caracteristica`;
CREATE TABLE `caracteristica` (
  `CaracteristicaId` int(11) NOT NULL AUTO_INCREMENT,
  `Denominacion` varchar(255) NOT NULL,
  `ArticuloId` int(11) NOT NULL,
  PRIMARY KEY (`CaracteristicaId`),
  KEY `fkArticuloCaracterisitica` (`ArticuloId`),
  CONSTRAINT `fkArticuloCaracterisitica` FOREIGN KEY (`ArticuloId`) REFERENCES `articulo` (`ArticuloId`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
--  Table structure for `categoria`
-- ----------------------------
DROP TABLE IF EXISTS `categoria`;
CREATE TABLE `categoria` (
  `CategoriaId` int(11) NOT NULL AUTO_INCREMENT,
  `Denominacion` varchar(255) DEFAULT NULL,
  `RubroId` int(11) DEFAULT NULL,
  PRIMARY KEY (`CategoriaId`),
  KEY `fkRubroCategoria` (`RubroId`),
  CONSTRAINT `fkRubroCategoria` FOREIGN KEY (`RubroId`) REFERENCES `rubro` (`RubroId`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

-- ----------------------------
--  Table structure for `direccion`
-- ----------------------------
DROP TABLE IF EXISTS `direccion`;
CREATE TABLE `direccion` (
  `DireccionId` int(11) NOT NULL,
  `Denominacion` varchar(500) DEFAULT NULL,
  `Referencia` varchar(500) DEFAULT NULL,
  `PersonaId` int(11) DEFAULT NULL,
  PRIMARY KEY (`DireccionId`),
  KEY `fkPersonaDireccion` (`PersonaId`),
  CONSTRAINT `fkPersonaDireccion` FOREIGN KEY (`PersonaId`) REFERENCES `persona` (`PersonaId`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
--  Table structure for `inventario`
-- ----------------------------
DROP TABLE IF EXISTS `inventario`;
CREATE TABLE `inventario` (
  `AlmacenId` int(11) NOT NULL,
  `ArticuloId` int(11) NOT NULL,
  `Cantidad` int(11) NOT NULL DEFAULT '0',
  `Ubicacion` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`ArticuloId`,`AlmacenId`),
  UNIQUE KEY `pkInventario` (`AlmacenId`,`ArticuloId`),
  CONSTRAINT `fkInventarioAlmacen` FOREIGN KEY (`AlmacenId`) REFERENCES `almacen` (`AlmacenId`) ON DELETE NO ACTION ON UPDATE CASCADE,
  CONSTRAINT `fkInventarioArticulo` FOREIGN KEY (`ArticuloId`) REFERENCES `articulo` (`ArticuloId`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
--  Table structure for `local`
-- ----------------------------
DROP TABLE IF EXISTS `local`;
CREATE TABLE `local` (
  `LocalId` int(11) NOT NULL AUTO_INCREMENT,
  `Denominacion` varchar(255) NOT NULL,
  `Direccion` varchar(400) DEFAULT NULL,
  `Telefono` varchar(9) DEFAULT NULL,
  PRIMARY KEY (`LocalId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
--  Table structure for `marca`
-- ----------------------------
DROP TABLE IF EXISTS `marca`;
CREATE TABLE `marca` (
  `MarcaId` int(11) NOT NULL AUTO_INCREMENT,
  `Denominacion` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`MarcaId`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
--  Table structure for `movimiento`
-- ----------------------------
DROP TABLE IF EXISTS `movimiento`;
CREATE TABLE `movimiento` (
  `MovimientoId` int(11) NOT NULL AUTO_INCREMENT,
  `AlmacenId` int(11) NOT NULL,
  `Tipo` enum('Entrada','Salida') NOT NULL,
  `Operacion` enum('Venta','Compra','Transferencia','Devolucion','Ajuste') NOT NULL,
  `Estado` enum('Pendiente','Confirmado','Preventa','Entregado','Anulado') DEFAULT NULL,
  `PersonaId` int(11) NOT NULL,
  `Fecha` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00' ON UPDATE CURRENT_TIMESTAMP,
  `SubTotal` decimal(15,2) NOT NULL,
  `IGV` decimal(15,2) NOT NULL,
  `Ajuste` decimal(15,2) NOT NULL DEFAULT '0.00',
  `Total` decimal(15,2) NOT NULL,
  `Glosa` varchar(255) DEFAULT NULL,
  `Documento` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`MovimientoId`),
  KEY `fkMovimientoAlmacen` (`AlmacenId`),
  KEY `fkPersonaId` (`PersonaId`),
  CONSTRAINT `fkMovimientoAlmacen` FOREIGN KEY (`AlmacenId`) REFERENCES `almacen` (`AlmacenId`) ON DELETE NO ACTION ON UPDATE CASCADE,
  CONSTRAINT `fkPersonaId` FOREIGN KEY (`PersonaId`) REFERENCES `persona` (`PersonaId`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
--  Table structure for `movimientodet`
-- ----------------------------
DROP TABLE IF EXISTS `movimientodet`;
CREATE TABLE `movimientodet` (
  `MovimientoDetId` int(11) NOT NULL AUTO_INCREMENT,
  `MovimientoId` int(11) DEFAULT NULL,
  `ArticuloId` int(11) DEFAULT NULL,
  `Cantidad` int(11) DEFAULT '0',
  `Precio` decimal(15,2) DEFAULT '0.00',
  `Importe` decimal(15,2) DEFAULT '0.00',
  `Descripcion` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`MovimientoDetId`),
  KEY `fkMovDetArticulo` (`ArticuloId`),
  KEY `fkMovDetMov` (`MovimientoId`),
  CONSTRAINT `fkMovDetArticulo` FOREIGN KEY (`ArticuloId`) REFERENCES `articulo` (`ArticuloId`) ON DELETE NO ACTION ON UPDATE CASCADE,
  CONSTRAINT `fkMovDetMov` FOREIGN KEY (`MovimientoId`) REFERENCES `movimiento` (`MovimientoId`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
--  Table structure for `persona`
-- ----------------------------
DROP TABLE IF EXISTS `persona`;
CREATE TABLE `persona` (
  `PersonaId` int(11) NOT NULL,
  `Tipo` enum('J','N') NOT NULL DEFAULT 'N' COMMENT 'Tipo Persona',
  `Nombres` varchar(60) NOT NULL,
  `Paterno` varchar(60) DEFAULT NULL,
  `Materno` varchar(60) DEFAULT NULL,
  `TipoDocumento` enum('DNI','RUC') NOT NULL DEFAULT 'DNI',
  `NroDocumento` varchar(11) NOT NULL,
  `Celular` varchar(10) NOT NULL,
  `Correo` varchar(100) DEFAULT NULL,
  `Sexo` enum('F','M') DEFAULT 'F',
  `FechaNacimiento` date DEFAULT NULL,
  `Estado` bit(1) NOT NULL DEFAULT b'1',
  PRIMARY KEY (`PersonaId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
--  Table structure for `rubro`
-- ----------------------------
DROP TABLE IF EXISTS `rubro`;
CREATE TABLE `rubro` (
  `RubroId` int(11) NOT NULL AUTO_INCREMENT,
  `Denominacion` varchar(255) NOT NULL,
  PRIMARY KEY (`RubroId`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
--  Table structure for `serie`
-- ----------------------------
DROP TABLE IF EXISTS `serie`;
CREATE TABLE `serie` (
  `SerieId` int(11) NOT NULL AUTO_INCREMENT,
  `Codigo` varchar(30) DEFAULT NULL,
  `ArticuloId` int(11) DEFAULT NULL,
  `MovimientoDetEntId` int(11) DEFAULT NULL,
  `MovimientoDetSalId` int(11) DEFAULT NULL,
  PRIMARY KEY (`SerieId`),
  KEY `fkentradaserie` (`MovimientoDetEntId`),
  KEY `fksalidaserie` (`MovimientoDetSalId`),
  KEY `fkArticuloSerie` (`ArticuloId`),
  CONSTRAINT `fkArticuloSerie` FOREIGN KEY (`ArticuloId`) REFERENCES `articulo` (`ArticuloId`) ON DELETE NO ACTION ON UPDATE CASCADE,
  CONSTRAINT `fkentradaserie` FOREIGN KEY (`MovimientoDetEntId`) REFERENCES `movimientodet` (`MovimientoDetId`) ON DELETE NO ACTION ON UPDATE CASCADE,
  CONSTRAINT `fksalidaserie` FOREIGN KEY (`MovimientoDetSalId`) REFERENCES `movimientodet` (`MovimientoDetId`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
--  Table structure for `usuario`
-- ----------------------------
DROP TABLE IF EXISTS `usuario`;
CREATE TABLE `usuario` (
  `UsuarioId` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(50) NOT NULL,
  `Clave` varchar(50) NOT NULL,
  `PersonaId` int(11) NOT NULL,
  `IndAdm` bit(1) NOT NULL DEFAULT b'0',
  `Estado` bit(1) NOT NULL DEFAULT b'1',
  PRIMARY KEY (`UsuarioId`),
  KEY `fkUsuarioPersona` (`PersonaId`),
  CONSTRAINT `fkUsuarioPersona` FOREIGN KEY (`PersonaId`) REFERENCES `persona` (`PersonaId`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
--  Records 
-- ----------------------------
INSERT INTO `almacen` VALUES ('1','Almacen San Juan','1');
INSERT INTO `articulo` VALUES ('4','1','3','123852','Notebook HP 11-n010LA Pavilion Intel Pentium RAM 4GB 500GB Windows 8.1 de 11.6\'\'','Descubre una de las maneras más sencillas para añadir almacenamiento a tu computadora con el disco duro externo portátil Canvio® Basics 3.0 de Toshiba. Desde el momento en que lo desempaques te darás cuenta que es una de las soluciones más fáciles y eficaces para guardar tu información. Canvio® Basics 3.0 es la solución perfecta sdfsdfsdf  sd f sdf sdf','852.00',NULL,''), ('5','2','1','123','coer i7 de 3.2 gh','disco duo de 500\nasdasdasda\nasd','500.00',NULL,''), ('6','2','2','56965','notebook 11 pulagas windows original','casaverde\nasdasdasd\nas\ndas\nd\nasd\nas\nda','1500.00',NULL,''), ('7','2','2','963258','erwerw','werwrwr','85.00',NULL,''), ('8','2','2','852','notebook pc core i5 17 pulgadas','asasasasasasdsds\nsdsds\nsdsdssd\nsdsd\nsdsd','1050.00',NULL,''), ('9','1','1','sdf','laptop original nuevo i7 HD 500GB','ssss','852.00',NULL,''), ('10','1','2','852','wwer','eeee','999.00',NULL,''), ('21','2','2','96325','Destop Toshiba i5 cuarta Generacion 500 Gb','ssss','1500.00',NULL,'');
INSERT INTO `categoria` VALUES ('1','Laptops y Notebooks','1'), ('2','Desktops','1'), ('3','nuevo','1'), ('4','otro','1'), ('5','datos','1'), ('6','nuevo111','1'), ('7','pppp','1'), ('8','nuevossss','2'), ('9','asdasdas','2'), ('10','nuevo','1'), ('11','sdsd','2');
INSERT INTO `local` VALUES ('1','San juan','Capillapata 256','966900599');
INSERT INTO `marca` VALUES ('1','HP'), ('2','Toshiba');
INSERT INTO `rubro` VALUES ('1','Computo'), ('2','Muebles');
