create table Product
(Id bigint  primary key identity(1,1),
Name nvarchar(50) not null,
Price decimal(10,2) not null,
Gst decimal(10,2) not null,
Weight decimal(10,2) not null,
Description varchar(5000) not null)

select * from Product

create procedure InsertProduct
(@Name nvarchar(50),
@Price decimal(10,2),
@Gst decimal(10,2),
@Weight decimal(10,2),
@Description varchar(5000)
)
as 
begin 
insert into Product
(Name,Price,Gst,Weight,Description)
values(@Name,@Price,@Gst,@Weight,@Description)
end 
exec InsertProduct 'bike',80000.20,8000.00,100.00,'Tvs XL Super'