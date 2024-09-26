--El nombre de la base de datos puede variar, a nosotros se nos generó como se muestra abajo porque era 
--codefirst y tomó el nombre del proyecto y el nombre de la ubicación de la clase de modelo

--Se recomienda primero generar la base de datos desde el proyecto web con el codeFirst, ya que, puede no funcionar
--si se genera la base de datos con un nombre diferente de "[MikhunaEcuador.Models.MikhunaDB]" 

--Ejecute esto para crear la base de datos, si ya está creada no lo ejecute, pase directo al ingreso de datos.

CREATE DATABASE [MikhunaEcuador.Models.MikhunaDB]
USE [MikhunaEcuador.Models.MikhunaDB]

CREATE TABLE Recetas(
	RecetaID int Identity(1,1) NOT NULL,
	Nombre varchar(50) NOT NULL,
	Duracion real NOT NULL,
	UrlImagen nvarchar(400),
	CalificacionPromedio real NOT NULL,
	CONSTRAINT PK_Recetas PRIMARY KEY (RecetaID)
);

CREATE TABLE Ingredientes(
	IngredienteID int Identity(1,1) NOT NULL,
	Nombre varchar(50) NOT NULL,
	Unidad varchar(50) NOT NULL,
	RecetaID int NOT NULL,
	CONSTRAINT PK_Ingredientes PRIMARY KEY (IngredienteID),
	CONSTRAINT FK_Ingredientes_Recetas FOREIGN KEY (RecetaID) REFERENCES Recetas(RecetaID)
);

CREATE TABLE Pasos(
	PasosID int Identity(1,1) NOT NULL,
	Paso varchar(100) NOT NULL,
	RecetaID int NOT NULL,
	CONSTRAINT PK_Pasos PRIMARY KEY (PasosID),
	CONSTRAINT FK_Pasos_Recetas FOREIGN KEY (RecetaID) REFERENCES Recetas(RecetaID)
);

CREATE TABLE Usuarios(
	UsuarioID int Identity(1,1) NOT NULL,
	NickName nvarchar(50) NOT NULL,
	Correo nvarchar(100) NOT NULL,
	Clave nvarchar(30) NOT NULL,
	Nivel int NOT NULL,
	Imagen nvarchar(400),
	CONSTRAINT PK_Usuarios PRIMARY KEY (UsuarioID)
);

CREATE TABLE Comentarios(
	ComentarioID int Identity(1,1) NOT NULL,
	Contenido nvarchar(MAX) NOT NULL,
	RecetaID int NOT NULL,
	UsuarioID int NOT NULL,
	CONSTRAINT PK_Comentarios PRIMARY KEY (ComentarioID),
	CONSTRAINT FK_Comentarios_Recetas FOREIGN KEY (RecetaID) REFERENCES Recetas(RecetaID),
	CONSTRAINT FK_Comentarios_Usuario FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID)
);

CREATE TABLE Favoritos(
	FavoritoID int Identity(1,1) NOT NULL,
	RecetaID int NOT NULL,
	UsuarioID int NOT NULL,
	CONSTRAINT PK_Favoritos PRIMARY KEY (FavoritoID),
	CONSTRAINT FK_Favoritos_Recetas FOREIGN KEY (RecetaID) REFERENCES Recetas(RecetaID),
	CONSTRAINT FK_Favoritos_Usuario FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID)
);

CREATE TABLE RecetasTerminadas(
	RecetasTerminadas int Identity(1,1) NOT NULL,
	RecetaID int NOT NULL,
	UsuarioID int NOT NULL,
	CONSTRAINT PK_RecetasTerminadas PRIMARY KEY (RecetasTerminadas),
	CONSTRAINT FK_RecetasTerminadas_Recetas FOREIGN KEY (RecetaID) REFERENCES Recetas(RecetaID),
	CONSTRAINT FK_RecetasTerminadas_Usuario FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID)
);

CREATE TABLE Calificacions(
	CalificacionID int Identity(1,1) NOT NULL,
	NumeroEstrellas real NOT NULL,
	RecetaID int NOT NULL,
	UsuarioID int NOT NULL,
	CONSTRAINT PK_Calificacions PRIMARY KEY (CalificacionID),
	CONSTRAINT FK_Calificacions_Recetas FOREIGN KEY (RecetaID) REFERENCES Recetas(RecetaID),
	CONSTRAINT FK_Calificacions_Usuario FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID)
);



--Insertar datos de las principales tablas

SELECT * FROM Recetas

--Ingreso de un usuario con el que podrá loguearse
INSERT INTO Usuarios(NickName, Correo, Clave, Nivel, Imagen) VALUES ('usuario1', 'usuario1@gmail.com','usuario1', 1,'https://res.cloudinary.com/dbxw3bxby/image/upload/v1657727394/mbji73v85jylldzna90z.jpg' )



--Primera Receta
INSERT INTO Recetas(Nombre, Duracion, UrlImagen, CalificacionPromedio) 
VALUES ('Ceviche', 50, 'https://res.cloudinary.com/dbxw3bxby/image/upload/v1657979685/pblxwn5xhmm1z07gen8y.jpg', 1)

--Ingredientes
INSERT INTO Ingredientes(Nombre, Unidad, RecetaID) VALUES('Camarón', '1 Libra', 1)
INSERT INTO Ingredientes(Nombre, Unidad, RecetaID) VALUES('Verde', '5 unidades', 1)
INSERT INTO Ingredientes(Nombre, Unidad, RecetaID) VALUES('Limón', 'Al gusto', 1)

--Pasos
INSERT INTO Pasos(Paso, RecetaID) VALUES('Pelar el camarón',1)
INSERT INTO Pasos(Paso, RecetaID) VALUES('Cocinar el camarón con los aliños',1)
INSERT INTO Pasos(Paso, RecetaID) VALUES('Pelas el verde y añadirlo a la olla',1)




--Segunda Receta
INSERT INTO Recetas(Nombre, Duracion, UrlImagen, CalificacionPromedio) 
VALUES ('Tacos', 120, 'https://res.cloudinary.com/dbxw3bxby/image/upload/v1657727116/m4oykyo4mk7e1whciid0.jpg', 1)

--Ingredientes
INSERT INTO Ingredientes(Nombre, Unidad, RecetaID) VALUES('Carne modila', '2 Libras', 2)
INSERT INTO Ingredientes(Nombre, Unidad, RecetaID) VALUES('Tortillas de maíz', '12 unidades', 2)
INSERT INTO Ingredientes(Nombre, Unidad, RecetaID) VALUES('Aguacate', 'Al gusto', 2)

--Pasos
INSERT INTO Pasos(Paso, RecetaID) VALUES('Hacer el refrito y poner a la olla',1)
INSERT INTO Pasos(Paso, RecetaID) VALUES('Cocinar la carne junto al refrito y mezlcar por varios mintuos',1)
INSERT INTO Pasos(Paso, RecetaID) VALUES('Hacer pico de gallo para el taco',1)

--Agregar Comentarios
INSERT INTO Comentarios(Contenido, RecetaID, UsuarioID) VALUES('El ceviche en la playa es lo más delicioso', 1, 1)
INSERT INTO Comentarios(Contenido, RecetaID, UsuarioID) VALUES('Los tacos, el mejor exponente de méxico', 2, 1)
