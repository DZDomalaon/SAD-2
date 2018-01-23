-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `glaciers` DEFAULT CHARACTER SET utf8 ;
USE `glaciers` ;

-- -----------------------------------------------------
-- Table `glaciers`.`person`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `glaciers`.`person` (
  `PERSON_ID` INT(11) NOT NULL AUTO_INCREMENT,
  `FIRSTNAME` VARCHAR(45) NULL DEFAULT NULL,
  `LASTNAME` VARCHAR(45) NULL DEFAULT NULL,
  `CONTACT_NUM` VARCHAR(15) NULL DEFAULT NULL,
  `EMAIL` VARCHAR(64) NULL DEFAULT NULL,
  `ADDRESS` VARCHAR(64) NULL DEFAULT NULL,
  `GENDER` INT(11) NULL DEFAULT NULL,
  `PERSON_TYPE` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`PERSON_ID`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `glaciers`.`customer`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `glaciers`.`customer` (
  `CUSTOMER_ID` INT(11) NOT NULL AUTO_INCREMENT,
  `BALANCE` DOUBLE NULL DEFAULT NULL,
  `CREDIT_LIMIT` INT(11) NULL DEFAULT NULL,
  `CUSTOMER_PERSON_ID` INT(11) NOT NULL,
  PRIMARY KEY (`CUSTOMER_ID`),
  INDEX `fk_customer_person_idx` (`CUSTOMER_PERSON_ID` ASC),
  CONSTRAINT `fk_customer_person`
    FOREIGN KEY (`CUSTOMER_PERSON_ID`)
    REFERENCES `glaciers`.`person` (`PERSON_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `glaciers`.`employee`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `glaciers`.`employee` (
  `EMP_ID` INT(11) NOT NULL AUTO_INCREMENT,
  `SHIFT` VARCHAR(20) NULL DEFAULT NULL,
  `SALARY` DOUBLE NULL DEFAULT NULL,
  `DATE_HIRED` VARCHAR(45) NULL DEFAULT NULL,
  `POSITION` VARCHAR(20) NULL DEFAULT NULL,
  `STATUS` VARCHAR(20) NULL DEFAULT NULL,
  `USERNAME` VARCHAR(45) NULL DEFAULT NULL,
  `PASSWORD` VARCHAR(45) NULL DEFAULT NULL,
  `TIME_IN` VARCHAR(45) NULL DEFAULT NULL,
  `TIME_OUT` VARCHAR(45) NULL DEFAULT NULL,
  `LOG_DATE` VARCHAR(45) NULL DEFAULT NULL,
  `EMP_PERSON_ID` INT(11) NOT NULL,
  PRIMARY KEY (`EMP_ID`),
  INDEX `fk_staff_person1_idx` (`EMP_PERSON_ID` ASC),
  CONSTRAINT `fk_staff_person1`
    FOREIGN KEY (`EMP_PERSON_ID`)
    REFERENCES `glaciers`.`person` (`PERSON_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `glaciers`.`inventory`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `glaciers`.`inventory` (
  `INVENTORY_ID` INT(11) NOT NULL AUTO_INCREMENT,
  `QUANTITY` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`INVENTORY_ID`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `glaciers`.`payment`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `glaciers`.`payment` (
  `PAYMENT_ID` INT(11) NOT NULL AUTO_INCREMENT,
  `AMOUNT` DOUBLE NULL DEFAULT NULL,
  `PAYMENT_DATE` VARCHAR(20) NULL DEFAULT NULL,
  `TYPE` VARCHAR(45) NULL DEFAULT NULL,
  `INTEREST` DOUBLE NULL DEFAULT NULL,
  `TERM` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`PAYMENT_ID`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `glaciers`.`product_catalogue`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `glaciers`.`product_catalogue` (
  `PC_ID` INT(11) NOT NULL AUTO_INCREMENT,
  `PC_CATEGORY` VARCHAR(45) NULL DEFAULT NULL,
  `PC_VARIANT` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`PC_ID`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `glaciers`.`product`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `glaciers`.`product` (
  `PRODUCT_ID` INT(11) NOT NULL AUTO_INCREMENT,
  `PRODUCT_NAME` VARCHAR(45) NULL DEFAULT NULL,
  `DESCRIPTION` VARCHAR(45) NULL DEFAULT NULL,
  `PRICE` DECIMAL(5,2) NULL DEFAULT NULL,
  `SERIAL` VARCHAR(45) NULL DEFAULT NULL,
  `PRODUCT_PC_ID` INT(11) NOT NULL,
  `PRODUCT_INV_ID` INT(11) NOT NULL,
  PRIMARY KEY (`PRODUCT_ID`),
  INDEX `fk_product_product_catalogue1_idx` (`PRODUCT_PC_ID` ASC),
  INDEX `fk_product_inventory1_idx` (`PRODUCT_INV_ID` ASC),
  CONSTRAINT `fk_product_product_catalogue1`
    FOREIGN KEY (`PRODUCT_PC_ID`)
    REFERENCES `glaciers`.`product_catalogue` (`PC_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_product_inventory1`
    FOREIGN KEY (`PRODUCT_INV_ID`)
    REFERENCES `glaciers`.`inventory` (`INVENTORY_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `glaciers`.`supplier`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `glaciers`.`supplier` (
  `SUPPLIER_ID` INT(11) NOT NULL AUTO_INCREMENT,
  `CONTACT_PERSON` VARCHAR(45) NULL DEFAULT NULL,
  `ORGANIZATION` VARCHAR(45) NULL DEFAULT NULL,
  `SUPPLIER_PERSON_ID` INT(11) NOT NULL,
  PRIMARY KEY (`SUPPLIER_ID`),
  INDEX `fk_supplier_person1_idx` (`SUPPLIER_PERSON_ID` ASC),
  CONSTRAINT `fk_supplier_person1`
    FOREIGN KEY (`SUPPLIER_PERSON_ID`)
    REFERENCES `glaciers`.`person` (`PERSON_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `glaciers`.`product_has_supplier`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `glaciers`.`product_has_supplier` (
  `product_PRODUCT_ID` INT(11) NOT NULL,
  `supplier_SUPPLIER_ID` INT(11) NOT NULL,
  INDEX `fk_product_has_supplier_supplier1_idx` (`supplier_SUPPLIER_ID` ASC),
  INDEX `fk_product_has_supplier_product1_idx` (`product_PRODUCT_ID` ASC),
  CONSTRAINT `fk_product_has_supplier_product1`
    FOREIGN KEY (`product_PRODUCT_ID`)
    REFERENCES `glaciers`.`product` (`PRODUCT_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_product_has_supplier_supplier1`
    FOREIGN KEY (`supplier_SUPPLIER_ID`)
    REFERENCES `glaciers`.`supplier` (`SUPPLIER_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `glaciers`.`purchase`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `glaciers`.`purchase` (
  `PURCHASE_ID` INT(11) NOT NULL AUTO_INCREMENT,
  `PURCHASE_DATE` VARCHAR(45) NULL DEFAULT NULL,
  `PRODUCT_NAME` VARCHAR(45) NULL DEFAULT NULL,
  `QUANTITY` INT(11) NULL DEFAULT NULL,
  `PRICE` DOUBLE NULL DEFAULT NULL,
  `STATUS` VARCHAR(45) NULL DEFAULT NULL,
  `PURCHASE_EMP_ID` INT(11) NOT NULL,
  `PURCHASE_SUPPLIER_ID` INT(11) NOT NULL,
  PRIMARY KEY (`PURCHASE_ID`),
  INDEX `fk_purchase_supplier1_idx` (`PURCHASE_SUPPLIER_ID` ASC),
  INDEX `fk_purchase_staff1_idx` (`PURCHASE_EMP_ID` ASC),
  CONSTRAINT `fk_purchase_staff1`
    FOREIGN KEY (`PURCHASE_EMP_ID`)
    REFERENCES `glaciers`.`employee` (`EMP_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_purchase_supplier1`
    FOREIGN KEY (`PURCHASE_SUPPLIER_ID`)
    REFERENCES `glaciers`.`supplier` (`SUPPLIER_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `glaciers`.`sales_order`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `glaciers`.`sales_order` (
  `ORDER_ID` INT(11) NOT NULL AUTO_INCREMENT,
  `ORDER_PRICE` DOUBLE NULL DEFAULT NULL,
  `ORDER_SUBTOTAL` DOUBLE NULL DEFAULT NULL,
  `ORDER_TOTAL` DOUBLE NULL DEFAULT NULL,
  `ORDER_TQUANTITY` INT(11) NULL DEFAULT NULL,
  `ORDER_QUANTITY` INT(11) NULL DEFAULT NULL,
  `ORDER_DISCOUNT` DOUBLE NULL DEFAULT NULL,
  `ORDER_DATE` VARCHAR(20) NULL DEFAULT NULL,
  `ORDER_WARRANTY` VARCHAR(20) NULL DEFAULT NULL,
  `ORDER_STATUS` VARCHAR(45) NULL DEFAULT NULL,
  `ORDER_CUSTOMER_ID` INT(11) NOT NULL,
  `ORDER_EMP_ID` INT(11) NOT NULL,
  `ORDER_PAYMENT_ID` INT(11) NOT NULL,
  `ORDER_PRODUCT_ID` INT(11) NOT NULL,
  PRIMARY KEY (`ORDER_ID`, `ORDER_PRODUCT_ID`, `ORDER_PAYMENT_ID`, `ORDER_CUSTOMER_ID`, `ORDER_EMP_ID`),
  INDEX `fk_order_customer1_idx` (`ORDER_CUSTOMER_ID` ASC),
  INDEX `fk_order_staff1_idx` (`ORDER_EMP_ID` ASC),
  INDEX `fk_order_payment1_idx` (`ORDER_PAYMENT_ID` ASC),
  INDEX `fk_order_Product1_idx` (`ORDER_PRODUCT_ID` ASC),
  CONSTRAINT `fk_order_Product1`
    FOREIGN KEY (`ORDER_PRODUCT_ID`)
    REFERENCES `glaciers`.`product` (`PRODUCT_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_order_customer1`
    FOREIGN KEY (`ORDER_CUSTOMER_ID`)
    REFERENCES `glaciers`.`customer` (`CUSTOMER_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_order_payment1`
    FOREIGN KEY (`ORDER_PAYMENT_ID`)
    REFERENCES `glaciers`.`payment` (`PAYMENT_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_order_staff1`
    FOREIGN KEY (`ORDER_EMP_ID`)
    REFERENCES `glaciers`.`employee` (`EMP_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `glaciers`.`stock_in`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `glaciers`.`stock_in` (
  `SI_ID` INT(11) NOT NULL AUTO_INCREMENT,
  `SI_QUANTITY` INT(11) NULL DEFAULT NULL,
  `SI_PRODUCT_ID` INT(11) NOT NULL,
  `SI_INVENTORY_ID` INT(11) NOT NULL,
  PRIMARY KEY (`SI_ID`),
  INDEX `fk_stock_in_Product1_idx` (`SI_PRODUCT_ID` ASC),
  INDEX `fk_stock_in_Inventory1_idx` (`SI_INVENTORY_ID` ASC),
  CONSTRAINT `fk_stock_in_Inventory1`
    FOREIGN KEY (`SI_INVENTORY_ID`)
    REFERENCES `glaciers`.`inventory` (`INVENTORY_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_stock_in_Product1`
    FOREIGN KEY (`SI_PRODUCT_ID`)
    REFERENCES `glaciers`.`product` (`PRODUCT_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

USE `glaciers`;

DELIMITER $$
USE `glaciers`$$
CREATE
DEFINER=`root`@`localhost`
TRIGGER `glaciers`.`insertToProfile`
AFTER INSERT ON `glaciers`.`person`
FOR EACH ROW
BEGIN
	IF new.PERSON_TYPE = 'EMPLOYEE' then
		INSERT INTO EMPLOYEE(DATE_HIRED, STATUS, USERNAME, PASSWORD, EMP_PERSON_ID) 
        VALUES (CONCAT(MONTH(NOW()),'-',DAY(NOW()),'-',YEAR(NOW())), 'ACTIVE',NEW.EMAIL, NEW.EMAIL, NEW.PERSON_ID);
	ELSEIF new.PERSON_TYPE = 'CUSTOMER' then
		INSERT INTO CUSTOMER(CREDIT_LIMIT, CUSTOMER_PERSON_ID) VALUES ('3', NEW.PERSON_ID);
	ELSEIF new.PERSON_TYPE = 'SUPPLIER' then
		INSERT INTO SUPPLIER(SUPPLIER_PERSON_ID) VALUES (NEW.PERSON_ID);
	END IF;
END$$




DELIMITER ;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
