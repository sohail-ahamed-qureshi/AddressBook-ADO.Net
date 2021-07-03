--UC1 ability to create Database
create database AddressBookADO;
use AddressBookADO;

--UC2 -- ability to create table
create table ContactBook(
firstName varchar(255),
lastName varchar(255),
address varchar(255),
city varchar(255),
state varchar(255),
zip int,
phoneNumber bigint,
email varchar(255)
);

--display table
select * from ContactBook

--UC9 -ability to identify each address book with name and type
ALTER TABLE ContactBook ADD Name varchar(255) not null DEFAULT 'FriendsContacts', 
TypeOf varchar(255) not null DEFAULT 'Friends'; 