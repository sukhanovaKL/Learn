create database Learn
go

use Learn 

create table Genders
(
Id	int primary key,
[Name] nvarchar(max)
)
go

create table Tegs
(
Id	int primary key,
[Name] nvarchar(max),
Color nvarchar(max)
)
go 

create table OtherPhotos
(
Id	int primary key,
Photo nvarchar(max),
ProductsId int,
ServicesId int,
CustomerVisits int
)

go

create table Customers
(
Id	int primary key,
Surname nvarchar(max),
[Name] nvarchar(max),
Patronymic nvarchar(max),
PhoneNumber nvarchar(max),
Email nvarchar(max),
GenderId int,
DateRegistration datetime,
Photo nvarchar(max),
TegId int,
DateBirthDay datetime

foreign key (GenderId) references Genders(id),
foreign key (TegId) references Tegs(id)
)
go

create table [Services]
(
Id	int primary key,
[Name] nvarchar(max),
[Description] nvarchar(max),
Cost int,
Sale int,
[Minutes] int,
Photo nvarchar(max),
OtherPhotoId int

foreign key (OtherPhotoId) references OtherPhotos(id)
)
go

create table CustomerVisits
(
Id	int primary key,
CustomerId int,
DateVisit datetime,
ServiceId int,
Comment nvarchar(max),
OtherPhotoId int

foreign key (CustomerId) references Customers(id),
foreign key (ServiceId) references [Services](id),
foreign key (OtherPhotoId) references OtherPhotos(id)
)
go

create table EmployeeCategories
(
Id	int primary key,
[Name] nvarchar(max)
)
go

create table Employees
(
Id	int primary key,
Surname nvarchar(max),
[Name] nvarchar(max),
Patronymic nvarchar(max),
PassportNumber nvarchar(max),
PassportSeria nvarchar(max),
KodPodrazdelenia int,
Coefficient float,
DateBirthDay dateTime,
EmployeeCategoryId int

foreign key (EmployeeCategoryId) references EmployeeCategories(id)
)
go

create table ProductsCategories
(
Id	int primary key,
[Name] nvarchar(max)
)
go

create table Manufacturers
(
Id	int primary key,
[Name] nvarchar(max),
DateStartWork dateTime
)
go

create table Products
(
Id	int primary key,
[Name] nvarchar(max),
ProductCategoryId int,
Cost int,
Haracteristics nvarchar(max),
[Description] nvarchar(max),
[Weight] int,
Wight int,
Height int,
ManufacturerId int,
Photo nvarchar(max),
OtherPhotoId int,
IsActual bit

foreign key (ProductCategoryId) references ProductsCategories(id),
foreign key (ManufacturerId) references Manufacturers(id),
foreign key (OtherPhotoId) references OtherPhotos(id)
)
go

create table HistiryBuy
(
Id	int primary key,
DateBuy int,
TotalCost int,
CustomerId int,
ServiceId int

foreign key (CustomerId) references Customers(id),
foreign key (ServiceId) references [Services](id)
)
go

create table ProductsHisoryBuy
(
Id	int primary key,
ProductId int,
HistoryBuyId int,
CountProduct int

foreign key (ProductId) references Products(id),
foreign key (HistoryBuyId) references HistiryBuy(id)
)
go
