CREATE DEFINER=`root`@`localhost` FUNCTION `concat_str`(str VARCHAR(256)) RETURNS varchar(256) CHARSET utf8
BEGIN
RETURN CONCAT("%", str, "%");
END


CREATE DEFINER=`root`@`localhost` FUNCTION `get_root`(str VARCHAR(256)) RETURNS varchar(256) CHARSET utf8
BEGIN
	CASE
		WHEN char_length(str) = 5 THEN RETURN SUBSTRING(str, 1, 3);
        WHEN char_length(str) = 6 THEN RETURN SUBSTRING(str, 1, 4);
        WHEN char_length(str) = 7 THEN RETURN SUBSTRING(str, 1, 5);
        WHEN char_length(str) = 8 THEN RETURN SUBSTRING(str, 1, 6);
        WHEN char_length(str) > 8 THEN RETURN SUBSTRING(str, 1, 8);
        ELSE RETURN str;
	END CASE;
END



CREATE DEFINER=`root`@`localhost` FUNCTION `SPLIT_STRING`(x VARCHAR(255),
pos INT) RETURNS varchar(255) CHARSET utf8
BEGIN
	DECLARE str VARCHAR(256);
    
    SET str = REPLACE(SUBSTRING(SUBSTRING_INDEX(x, ' ', pos), CHAR_LENGTH(SUBSTRING_INDEX(x, ' ', pos -1)) + 1), ' ', '');
    
    IF char_length(str) > 0 THEN RETURN str;
    ELSE RETURN x;
    END IF;
END