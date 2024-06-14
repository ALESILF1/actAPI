create table Rota
(
  Id int identity,
  Origin varchar(140) not null,
  Destination varchar(140) not null,
  Cost decimal(12,2) not null
)

insert into rota (Origin,Destination,Cost)
	select 'GRU','BRC',10 union all
	select 'BRC','SCL', 5 union all
	select 'GRU','CDG',75 union all
	select 'GRU','SCL',20 union all
	select 'GRU','ORL',56 union all
	select 'ORL','CDG', 5 union all
	select 'SCL','ORL',20

select * from rota
