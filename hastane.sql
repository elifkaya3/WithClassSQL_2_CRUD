USE sHastane
CREATE TABLE tblBolumler
(
ID INT IDENTITY (1,1) NOT NULL,
BolumAd VARCHAR(30) UNIQUE NOT NULL,
PRIMARY KEY(ID)
)
GO
INSERT INTO tblBolumler
VALUES
('Dahiliye'),('Nöroloji'),('Ortopedi')
GO

CREATE TABLE tblDoktorlar
(
ID INT IDENTITY(1,1) NOT NULL,
SicilNo CHAR(5) NOT NULL,
AdSoyad VARCHAR(40) NOT NULL,
Mail VARCHAR(30) NOT NULL,
BolumID INT NOT NULL,
PRIMARY KEY(ID),
FOREIGN KEY(BolumID) REFERENCES tblBolumler(ID)
)
GO
USE sHastane
INSERT INTO tblDoktorlar VALUES
('58564','Ali can','alican@gmail.com',1,'456789123'),
('25486','Demet Evgar','demet@gmail.com',1,'123456879'),
('59877','Sedat Kunar','sedat@gmail.com',3,'78945613'),
('33666','Ferhunde Hanım','ferhunde@gmail.com',2,'4566123789'),
('44147','Zafer Kimki','zafer@gmail.com',2,'123789456')
GO