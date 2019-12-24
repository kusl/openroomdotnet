use Openroom;
go

if (object_id('dbo.RESERVATION') is not null)
	begin
	drop table dbo.RESERVATION
end

if (object_id('dbo.PATRON') is not null)
	begin
	drop table dbo.PATRON;
end

if (object_id('dbo.RESOURCE') is not null)
	begin
	drop table dbo.RESOURCE;
end

create table dbo.PATRON
(
	ID int identity(1,1) not null primary key,
	NAME nvarchar(255) not null,
	ROW_VERSION rowversion not null
);

insert into dbo.PATRON (name) values ('Kushal');
insert into dbo.PATRON (name) values ('Pratikchhya');

create table dbo.RESOURCE
(
	ID int identity(1,1) not null primary key,
	NAME nvarchar(255) not null,
	ROW_VERSION rowversion not null
);

insert into dbo.resource (name) values ('Instant Pot');
insert into dbo.resource (name) values ('Rice Cooker');


create table dbo.RESERVATION
(
	ID int identity(1,1) not null primary key,
	PATRON_ID int not null
		constraint FK_RESERVATION_PATRON
		references	dbo.PATRON,
	RESOURCE_ID int not null
		constraint FK_RESERVATION_RESOURCE
		references dbo.RESOURCE,
	START_TIME datetime2 not null,
	END_TIME datetime2 not null,
	ROW_VERSION rowversion not null
);

insert into dbo.reservation (patron_id, resource_id, start_time, end_time) values (1, 1, '2019-12-26 10:00:00. 0000000 -7:00', '2019-12-26 10:30:00. 0000000 -7:00');
insert into dbo.reservation (patron_id, resource_id, start_time, end_time) values (2, 2, '2019-12-26 10:00:00. 0000000 -7:00', '2019-12-26 11:00:00. 0000000 -7:00');
