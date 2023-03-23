create table tags 
(
  tagid int not null  primary key,
  tagName nvarchar (30) not null
)
go 
create table publishers
( 
  publisherid int  primary key,
  publishername nvarchar (40) not null,
  publisheremail nvarchar (50) null,
  tagid int not null references tags(tagid)
 )
 go
 create table authors
 (
	authorid int  primary key,
	authorname nvarchar(50) not null,
	email nvarchar(50) null,
	bookid int not null references books(bookid)
)
go
 create table books
( 
  bookid int  primary key,
  title nvarchar (40) not null,
  coverprice money not null,
  publishdate date not null,
  available bit default 0,
  publisherid int not null references publishers(publisherid)
 )
go