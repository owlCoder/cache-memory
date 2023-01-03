CREATE TABLE Potrosnja_Energije
(
    userId INT NOT NULL,
    userName VARCHAR2(32) NOT NULL,
    userAddress VARCHAR2(32) NOT NULL,
    userCity VARCHAR2(32) NOT NULL,

    brojiloId VARCHAR2(12) NOT NULL,
    potroseno DECIMAL(10, 2) NOT NULL,
    potrosnjaMesec VARCHAR(16) NOT NULL
);

SELECT *FROM Potrosnja_Energije;