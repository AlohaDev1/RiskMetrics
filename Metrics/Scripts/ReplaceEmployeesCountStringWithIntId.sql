ALTER TABLE `state_schematic`.`prim` ADD COLUMN `EmployeeSizeId` INT NOT NULL  AFTER `EmployeeSizeRange` ;

SET SQL_SAFE_UPDATES=0; 
UPDATE `state_schematic`.`prim` SET `EmployeeSizeId`=1 WHERE `EmployeeSizeRange`='0 TO 4';
UPDATE `state_schematic`.`prim` SET `EmployeeSizeId`=2 WHERE `EmployeeSizeRange`='5 TO 9';
UPDATE `state_schematic`.`prim` SET `EmployeeSizeId`=3 WHERE `EmployeeSizeRange`='10 TO 19';
UPDATE `state_schematic`.`prim` SET `EmployeeSizeId`=4 WHERE `EmployeeSizeRange`='20 TO 49';
UPDATE `state_schematic`.`prim` SET `EmployeeSizeId`=5 WHERE `EmployeeSizeRange`='50 TO 99';
UPDATE `state_schematic`.`prim` SET `EmployeeSizeId`=6 WHERE `EmployeeSizeRange`='100 TO 499';
UPDATE `state_schematic`.`prim` SET `EmployeeSizeId`=7 WHERE `EmployeeSizeRange`='500 PLUS';
