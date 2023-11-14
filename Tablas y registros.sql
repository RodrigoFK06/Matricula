create table Estudiantes(
ID_estudiante int IDENTITY(1,1) not null,
nombres varchar(30) not null,
apellidos varchar (30) not null,
fecha_nacimiento date,
correo varchar (100),
direccion varchar (100),
constraint PK_ID_estudiante primary key (ID_estudiante),
); 

INSERT INTO Estudiantes (nombres, apellidos, fecha_nacimiento, correo, direccion)
VALUES 
('Rodrigo', 'Torres', '2003-07-03', 'rodrigofk@gmail.com' , 'direccion 1'),
('Sofía', 'Lopez', '2004-07-03', 'rodrigof@gmail.com', 'direccion 2'),
('Carlos', 'Perez', '2005-07-03', 'rodrigo@gmail.com' , 'direccion 3');

SELECT*FROM estudiantes



create table Cursos(
ID_curso int IDENTITY(1,1) not null,
nombre_curso varchar(30) not null,
descripcion varchar (30) not null,
creditos int,
ID_Profesor int not null,
constraint PK_ID_curso primary key (ID_curso),
constraint FK_ID_profesor_curso foreign key (ID_Profesor) references Profesores (ID_profesor)
); 

INSERT INTO Cursos (nombre_curso, descripcion, creditos, ID_profesor)
VALUES 
('Matematica', 'mate', 5, 1),
('Comunicacion', 'comu', 5, 2),
('Ciencia', 'ciencia', 5, 3);


create table Matriculas(
ID_matricula int IDENTITY(1,1) not null,
ID_estudiante int not null,
ID_curso int  not null,
fecha_matricula date,
estado char (2),
constraint PK_ID_matricula primary key (ID_matricula),
constraint FK_ID_estudiante_matricula foreign key (ID_estudiante) references Estudiantes (ID_estudiante),
constraint FK_ID_curso_matricula foreign key (ID_curso) references Cursos (ID_curso)

); 


INSERT INTO Matriculas (ID_estudiante, ID_curso, fecha_matricula,estado)
VALUES 
(1, 1, '2020-07-03',  'Ac'),
(2, 2, '2020-09-03',  'Ac'),
(3, 3, '2020-08-03',  'Ac');



create table Profesores(
ID_profesor int IDENTITY(1,1) not null,
nombres varchar(30) not null,
apellidos varchar (30) not null,
correo varchar (100),
direccion varchar (100),
constraint PK_ID_profesor primary key (ID_profesor),
); 

INSERT INTO Profesores (nombres, apellidos, correo, direccion)
VALUES 
('Isabel', 'Garcia', 'isabel@gmail.com' , 'direccion 1'),
('Pablo', 'Martinez', 'pablo@gmail.com', 'direccion 2'),
('Miguel', 'Lopez', 'miguel@gmail.com' , 'direccion 3');

drop table Profesores;

create table Horarios(
ID_horario int IDENTITY(1,1) not null,
ID_curso int not null,
dia_semana varchar(30) not null,
hora_inicio int not null,
hora_fin int not null,
aula varchar (100),
constraint PK_ID_horario primary key (ID_horario),
constraint FK_ID_curso_horario foreign key (ID_curso) references Cursos (ID_curso));

INSERT INTO Horarios (ID_curso, dia_semana, hora_inicio, hora_fin,aula)
VALUES 
(1, 'Lunes', 5 , 7,'C'),
(2, 'Martes', 5, 6,'B'),
(3, 'Miercoles', 5 , 9,'A');


