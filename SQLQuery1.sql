Create database admin;
Use admin
go
create table employees1(
name nvarchar (255) not null,
phone_number nvarchar (15)not null primary key ,

password nvarchar(255) not null,

);
Select * from employees1
insert into employees1 (name,phone_number, password) 
values ('upasana','9843816723','nepal'),
('sova','9857687574','hello'),
('rinjha','9855647809','hi');

create table productlist(
item_name nvarchar (255) not null,
item_id nvarchar (15)not null primary key ,

category nvarchar(255) not null,
quantity nvarchar(255) not null,

);


Select * from productlist
DELETE FROM productlist where 1=1;
insert into productlist (item_name,item_id, quantity,category) 
values ('upasana','9843816723','100','2');

create table productIn(

quantity int not null,
);

Select *from productIn
insert into productIn(item_name,quantity)



create table productOut(
item_name nvarchar(255) not null,
quantity int not null,
);

Select *from productIn
insert into productIn(item_name,quantity)
values('aalu','2');

use admin;
create table transactionHistory1(

 id int  identity(1,1) primary key ,
product_in nvarchar(255) not null,
--product_out nvarchar(255) not null,
--product_inHand nvarchar(255) not null,


);

use admin;
create table productOut(

 id int  identity(1,1) primary key ,
product_out nvarchar(255) not null,



);


use admin;
select *from productlist;

use admin;
Select *from transactionHistory1

use admin;
Select *from productOut;




