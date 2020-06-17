/*
CREATE PROCEDURE `update_cost` (new_cost DECIMAL(10,2), title_med VARCHAR(64))
BEGIN
	UPDATE medicine SET price = new_cost WHERE title = title_med;
END
    
CALL update_cost(11.3, "Полькортолон");
*/ 

/*
CREATE PROCEDURE `insert_inst`(_title VARCHAR(256), _kind VARCHAR(128), _address VARCHAR(256), _phone VARCHAR(16))
BEGIN
	INSERT INTO institutions VALUES (NULL, _title, ( SELECT ID FROM types WHERE kind =_kind ), _address, _phone);
END
    
  
    
CALL insert_inst ("лік", "Лікарня", "тернопіль", "0321");
    
*/  
   
/*
CREATE PROCEDURE `update_inst` (new_title VARCHAR(256), _kind INT, _address VARCHAR(256), _phone VARCHAR(16), past_title VARCHAR(256))
BEGIN
	UPDATE institutions SET title = new_title, kind = _kind, address = _address, phone = _phone WHERE title = past_title;
END

CALL update_inst("new title", 2, "address", "032544", "лік");
*/

/*
CREATE PROCEDURE `delete_inst`(_title VARCHAR(256))
BEGIN
	DELETE FROM institutions WHERE title = _title;
END

CALL delete_inst ("new title");
*/















