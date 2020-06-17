#CREATE DATABASE handbook;

#USE handbook;

DROP TABLE IF EXISTS symptom_has_sickness;
DROP TABLE IF EXISTS symptom_has_medicine;
DROP TABLE IF EXISTS symptom_has_doctor;
DROP TABLE IF EXISTS symptom;
DROP TABLE IF EXISTS part;
DROP TABLE IF EXISTS doctor;
DROP TABLE IF EXISTS sickness;
DROP TABLE IF EXISTS medicine;
DROP TABLE IF EXISTS form_releases;
DROP TABLE IF EXISTS pharmac_groups;
DROP TABLE IF EXISTS institutions;
DROP TABLE IF EXISTS types;


CREATE TABLE pharmac_groups (
	ID INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
    class TEXT NOT NULL,
    INDEX(ID)
);


CREATE TABLE form_releases (
	ID INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
    form TEXT NOT NULL,
    INDEX(ID)
);


CREATE TABLE sickness (
	ID INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
    title VARCHAR(45) NOT NULL,
    description TEXT NOT NULL,
    symptoms TEXT, 
    treatment TEXT,
    INDEX(ID),
    INDEX (title)
);

CREATE TABLE medicine (
    ID INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
    title VARCHAR(64) NOT NULL,
    external_propreties TEXT,
    content TEXT,
    form_release INT,
    pharmac_group INT,
    pharmac_propreties TEXT,
    indication TEXT,
    dosage TEXT,
    side_effect TEXT,
    contraindication TEXT,
    overdose TEXT,
    features TEXT,
    price DECIMAL(10,2),
    FOREIGN KEY (form_release) REFERENCES form_releases(ID),
    FOREIGN KEY (pharmac_group) REFERENCES pharmac_groups(ID),
    INDEX(ID),
    INDEX(title),
    INDEX(form_release),
    INDEX(pharmac_group)
);

CREATE TABLE doctor (
	ID INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
    specialty VARCHAR(64) NOT NULL,
    competence TEXT NOT NULL,
    INDEX(ID),
    INDEX(specialty)
);

CREATE TABLE part (
	ID INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
    organ VARCHAR(256) NOT NULL,
    INDEX(ID)
);

CREATE TABLE symptom (
	ID INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
    title VARCHAR(45) NOT NULL,
    short_info TEXT NOT NULL,
	ID_part INT NOT NULL,
    FOREIGN KEY (ID_part) REFERENCES part(ID),
    INDEX(ID),
    INDEX (title)
);



CREATE TABLE types (
	ID INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
    kind VARCHAR(128) NOT NULL,
    INDEX(ID)
);

CREATE TABLE institutions (
	ID INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
	title VARCHAR(256) NOT NULL,
    kind INT NOT NULL,
    address VARCHAR(256) NOT NULL,
    phone VARCHAR(16),
    FOREIGN KEY (kind) REFERENCES types(ID),
    INDEX (ID),
    INDEX (title),
    INDEX (kind)
);

CREATE TABLE symptom_has_sickness (
	symptom_ID INT NOT NULL,
    sickness_ID INT NOT NULL,
    PRIMARY KEY (symptom_ID, sickness_ID),
    FOREIGN KEY (symptom_ID) REFERENCES symptom(ID),
    FOREIGN KEY (sickness_ID) REFERENCES sickness(ID),
    INDEX (symptom_ID),
    INDEX (sickness_ID)
);

CREATE TABLE symptom_has_medicine (
	symptom_ID INT NOT NULL,
    medicine_ID INT NOT NULL,
    PRIMARY KEY (symptom_ID, medicine_ID),
    FOREIGN KEY (symptom_ID) REFERENCES symptom(ID),
    FOREIGN KEY (medicine_ID) REFERENCES medicine(ID),
    INDEX (symptom_ID),
    INDEX (medicine_ID)
);

CREATE TABLE symptom_has_doctor (
	symptom_ID INT NOT NULL,
    doctor_ID INT NOT NULL,
    PRIMARY KEY (symptom_ID, doctor_ID),
    FOREIGN KEY (symptom_ID) REFERENCES symptom(ID),
    FOREIGN KEY (doctor_ID) REFERENCES doctor(ID),
    INDEX (symptom_ID),
    INDEX (doctor_ID)
);
























































































































































































