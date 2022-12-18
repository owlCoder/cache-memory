CREATE TABLE Korisnik (
    userId INTEGER PRIMARY KEY,
    username VARCHAR(32) NOT NULL UNIQUE,
    password VARCHAR(32) NOT NULL,
    adresa VARCHAR(32) NOT NULL
);

CREATE TABLE Brojilo (
    brojiloId INTEGER PRIMARY KEY,
    naziv VARCHAR(32)
);

CREATE TABLE KorisnikBrojilo (
    userId INTEGER NOT NULL,
    brojiloId INTEGER NOT NULL,
    CONSTRAINT USERID_FK FOREIGN KEY(userId) REFERENCES KORISNIK(userId),
    CONSTRAINT BROJILOID_FK FOREIGN KEY(brojiloId) REFERENCES BROJILO(brojiloId)
);

CREATE TABLE EvidencijaPotrosnje (
    userId INTEGER NOT NULL,
    brojiloId INTEGER NOT NULL,
    mesec INTEGER NOT NULL,
    grad VARCHAR(32) NOT NULL,
    zabelezenaPotrosnja REAL NOT NULL
);

-- KORISNIK
INSERT INTO KORISNIK VALUES(1, 'ana10',  'ps1', 'Ugrinovacka 12, Leta');
INSERT INTO KORISNIK VALUES(2, 'maja21', 'pa2', 'Lele Detelinare 1, Novi Sad');
INSERT INTO KORISNIK VALUES(3, 'comi32', '123', 'Lemanska 54, Beograd');
INSERT INTO KORISNIK VALUES(4, 'losmi2', '111', 'Zvezdana Bogdana 1, Beograd');
INSERT INTO KORISNIK VALUES(5, 'rapgo2', '333', 'Nele Agrin 5, Pancevo');

-- BROJILA
INSERT INTO BROJILO VALUES(101, 'SE-2154');
INSERT INTO BROJILO VALUES(102, 'SB-6321');
INSERT INTO BROJILO VALUES(103, 'SE-4125');
INSERT INTO BROJILO VALUES(104, 'SE-6324');

-- KORISNIKBROJILO
INSERT INTO KORISNIKBROJILO VALUES(1, 101);
INSERT INTO KORISNIKBROJILO VALUES(5, 103);
INSERT INTO KORISNIKBROJILO VALUES(2, 104);

-- EVIDENCIJA POTROSNJE
INSERT INTO EVIDENCIJAPOTROSNJE VALUES(1, 101, 11, 'Leta', 41.21);
INSERT INTO EVIDENCIJAPOTROSNJE VALUES(1, 101, 12, 'Leta', 125.41);
INSERT INTO EVIDENCIJAPOTROSNJE VALUES(2, 104, 5, 'Novi Sad', 1.21);

-- promene se cuvaju u bazi
commit;

-- prikaz unetih podataka
SELECT *FROM KORISNIK;
SELECT *FROM BROJILO;
SELECT *FROM KORISNIKBROJILO;
SELECT *FROM EVIDENCIJAPOTROSNJE;