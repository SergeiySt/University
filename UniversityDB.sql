create database UniversityDB;


use UniversityDB
go


create table Students
(
	id_students int not null identity(1,1) primary key,
	SName nvarchar(50) check (SName <> '') not null,
	SSurname nvarchar(50) check (SSurname <> '') not null,
	SAge int not null
);
go

create table Courses
(
	id_courses int not null identity(1,1) primary key,
	CName nvarchar(50) check (CName <> '') not null,
	CTeacher nvarchar(100) check (CTeacher <> '') not null,
);
go

insert into Students values
('Жора', 'Кириленко', 19),
('Світлана', 'Сидоренко',  20),
( 'Наталія', 'Ткаченко', 19),
('Світлана', 'Река',  19),
('Віктор', 'Максимов',  20),
('Ігор', 'Полонський', 20),
('Генадій', 'Кириленко', 21),
('Василь', 'Шаповалов', 19),
('Світлана', 'Москаленко', 21);
go


insert into Courses values
('Дискретна математика', 'Ожога В. В.'),
('Статистика', 'Пінчук О. О.'),
('Мова програмування С#', 'Тканов В. В.'),
('English', 'Андрющенко С. В.'),
('PHP', 'Шаповалов О. Г.');
go

create table StudentCourse
(
	id_students int not null,
	id_courses int not null,
	foreign key (id_students) references Students(id_students),
	foreign key (id_courses) references Courses(id_courses)
);
go

insert into StudentCourse values
(1, 5),
(1, 1),
(1, 6),
(6, 1);
go

