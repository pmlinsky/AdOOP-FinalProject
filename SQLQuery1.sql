

create table CUSTOMER(
	Id int identity(1,1) not null,
	Username nchar(30) not null,
	Pswrd nchar(30) not null,
	Balance decimal(7,2)

	constraint [PK_CUST] primary key (Id),
	constraint [UIX_USER] unique (Username)
)

insert into CUSTOMER values('psinger','password',500),('test','csharp',1100);

create table INVENTORY(
	Id int not null,
	ItemName nchar(30) not null,
	Price decimal(5,2) not null,
	QtyInStock int not null

	constraint [PK_ITEM] primary key (Id),
	constraint [UIX_NAME] unique (ItemName),
	constraint [CHK_PRICE] check (Price > 0),
	constraint [CHK_QTY] check (QtyInStock >= 0)
)

insert into INVENTORY values(1, 'Computer Desk',299.99, 46),(2, 'Desk Chair',199.99,98),
(3, 'Large Table',299.99, 47),(4, 'Recliner',850.00,97),
(5, 'Sofa',900, 4),(6, 'Large Couch',950,0),
(7, 'Coffee Table',84.99, 50),(8, 'Desk Lamp',50.99,97)

create table PURCHASES(
	Id int identity(1,1) not null, 
	DateOfPurchase date not null default getdate(),
	CustID int not null,
	ItemName nchar(30) not null,
	Qty int not null,
	Price decimal(8,2) not null

	constraint [PK_PURCHASES] primary key (Id),
	constraint [CHK_P_QTY] check (Qty > 0),
	constraint [FK_ItemName] foreign key (ItemName) references Inventory(ItemName),
	constraint [FK_CustID] foreign key (CustID) references Customer(Id),
	constraint [CHK_TotalPrice] check (Price > 0)
)
 update customer set balance = 500 where id = 1
 update customer set balance = 1100 where id = 2
 select * from purchases
 select * from customer
 select * from inventory
