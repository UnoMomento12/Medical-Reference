
#SELECT ID FROM institutions WHERE title = "Лікарня №1";

/*
CREATE DEFINER = CURRENT_USER TRIGGER `handbook`.`institutions_BEFORE_INSERT` BEFORE INSERT ON `institutions` FOR EACH ROW
BEGIN
	IF (SELECT ID FROM institutions WHERE title = NEW.title) IS NOT NULL THEN
    SIGNAL SQLSTATE '45000';
    END IF;
END

CALL insert_inst ("Лікарня №4", "Лікарня", "address", "phone");
*/

/*
CREATE TRIGGER `handbook`.`institutions_BEFORE_UPDATE` BEFORE UPDATE ON `institutions` FOR EACH ROW
BEGIN
	IF (SELECT ID FROM institutions WHERE title = NEW.title) IS NOT NULL THEN
    SIGNAL SQLSTATE '45000';
    END IF;
END
*/



