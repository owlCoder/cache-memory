CREATE TABLE "brojilo" (
	"id"	INTEGER NOT NULL UNIQUE,
	"naziv"	varchar(32),
	PRIMARY KEY("id")
);

CREATE TABLE "evidencijaPotrosnje" (
	"userId"	INTEGER NOT NULL,
	"brojiloId"	INTEGER NOT NULL,
	"mesec"	INTEGER NOT NULL,
	"grad"	varchar(32) NOT NULL
, "zabelezenaPotrosnja"	REAL NOT NULL);

CREATE TABLE "korisnici" (
	"uid"	INTEGER NOT NULL,
	"username"	varchar(32) NOT NULL UNIQUE,
	"password"	varchar(32) NOT NULL,
	"adresa"	varchar(32) NOT NULL,
	PRIMARY KEY("uid" AUTOINCREMENT)
)

CREATE TABLE "korisnikBrojilo" (
	"userId"	INTEGER NOT NULL,
	"brojiloId"	INTEGER NOT NULL,
	CONSTRAINT "userID_FK" FOREIGN KEY("userId") REFERENCES korisnici(uid),
	CONSTRAINT "brojiloID_FK" FOREIGN KEY("brojiloId") REFERENCES brojilo(id)
)

