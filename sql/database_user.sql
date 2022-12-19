create user ers_db identified by ers
	default tablespace USERS temporary tablespace TEMP;
	grant connect, resource to ers_db;
	grant create table to ers_db;
	grant create view to ers_db;
	grant create procedure to ers_db;
	grant create synonym to ers_db;
	grant create sequence to ers_db;
	grant select on dba_rollback_segs to ers_db;
	grant select on dba_segments to ers_db;
	grant unlimited tablespace to ers_db;