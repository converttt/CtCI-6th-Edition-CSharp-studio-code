# postgresql schema

DROP TABLE IF EXISTS Buildings;
DROP SEQUENCE IF EXISTS buildings_id_seq;
DROP TABLE IF EXISTS Apartments;
DROP SEQUENCE IF EXISTS apartments_id_seq;
DROP TABLE IF EXISTS Requests;
DROP SEQUENCE IF EXISTS requests_id_seq;

CREATE SEQUENCE buildings_id_seq;
CREATE TABLE Buildings (
    BuilidingID int NOT NULL DEFAULT NEXTVAL('buildings_id_seq'),
    ComplexID int NOT NULL,
    BuildingName varchar(100) NOT NULL,
    Address varchar(100) NOT NULL,
    PRIMARY KEY (BuilidingID)
);

CREATE SEQUENCE apartments_id_seq;
CREATE TABLE Apartments (
    AptID int NOT NULL DEFAULT NEXTVAL('apartments_id_seq'),
    UnitNumber varchar(10) NOT NULL,
    BuilidingID int,
    PRIMARY KEY (AptID),
    FOREIGN KEY (BuilidingID) REFERENCES Buildings (BuilidingID)
);

CREATE SEQUENCE requests_id_seq;
CREATE TABLE Requests (
    RequestID int NOT NULL DEFAULT NEXTVAL('requests_id_seq'),
    Status varchar(100) NOT NULL,
    AptID int NOT NULL,
    Description text NOT NULL,
    PRIMARY KEY (RequestID),
    FOREIGN KEY (AptID) REFERENCES Apartments (AptID)
);

INSERT INTO Buildings (
    ComplexID, BuildingName, Address
) 
VALUES 
(1, 'Bach', '1 Octavius Str.'),
(2, 'Chopin', '2 Octavius Str.'),
(3, 'Mozart', '3 Octavius Str.'),
(1, 'Beethhoven', '1a Green Str.'),
(2, 'Beethhoven', '1b Green Str.'),
(3, 'Rattle', '2 Green Str.');

INSERT INTO Apartments (
    UnitNumber, BuilidingID
)
VALUES
('100', 1),
('110', 1),
('120', 1),
('130', 1),
('140', 1),
('150', 1),
('101', 3),
('102', 3),
('103', 3),
('01', 2);

INSERT INTO Requests (
    Status, AptID, Description
)
VALUES
('OPEN', 1, 'NO LIGHTS'),
('OPEN', 1, 'NO LIGHTS'),
('CLOSED', 1, 'NO HOT WATER'),
('OPEN', 3, 'NO LIGHTS'),
('CLOSED', 3, 'NO HOT WATER'),
('OPEN', 3, 'NO LIGHTS'),
('OPEN', 4, 'NO LIGHTS'),
('OPEN', 5, 'NO HOT WATER'),
('OPEN', 7, 'NO HOT WATER'),
('OPEN', 7, 'NO LIGHTS'),
('CLOSED', 7, 'NO LIGHTS'),
('OPEN', 7, 'NO HOT WATER'),
('OPEN', 8, 'NO HOT WATER'),
('CLOSED', 8, 'NO LIGHTS'),
('OPEN', 8, 'NO LIGHTS'),
('OPEN', 9, 'NO HOT WATER'),
('OPEN', 10, 'NO HOT WATER'),
('OPEN', 10, 'NO HOT WATER');