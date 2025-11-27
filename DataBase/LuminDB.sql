CREATE DATABASE Lumin;

USE Lumin

CREATE TABLE Usuario(
	id INT PRIMARY KEY IDENTITY,
	nome VARCHAR(120),
	email VARCHAR(120) UNIQUE,
	senha VARCHAR(15),
	telefone VARCHAR(15)
);

CREATE TABLE Postagem(
	id INT PRIMARY KEY IDENTITY,
	descricao VARCHAR(300),

	Usuario_id INT,
	FOREIGN KEY (Usuario_id) REFERENCES Usuario(id)
);

CREATE TABLE Curtidas(
	id INT PRIMARY KEY IDENTITY,
	Horario DATETIME,
	
	Usuario_id INT,
	FOREIGN KEY (Usuario_id) REFERENCES Usuario(id),

	Postagem_id INT,
	FOREIGN KEY (Postagem_id) REFERENCES Postagem(id),
);

CREATE TABLE tipoPrestador(
	id INT PRIMARY KEY IDENTITY,
	Tipo VARCHAR(9)
);

CREATE TABLE prestadorDeServicos(
	id INT PRIMARY KEY IDENTITY,
	Identificador INT,
	Certificados VARCHAR(200),

	Tipo_id INT,
	FOREIGN KEY (Tipo_id) REFERENCES tipoPrestador(id)
);

CREATE TABLE Midia(
	id INT PRIMARY KEY IDENTITY,
	Imagem VARCHAR(150),
 
	Postagem_id INT,
	FOREIGN KEY (Postagem_id) REFERENCES Postagem(id)
);

CREATE TABLE Comentarios(
	id INT PRIMARY KEY IDENTITY,
	
	Usuario_id INT,
	FOREIGN KEY (Usuario_id) REFERENCES Usuario(id),
	Postagem_id INT,
	FOREIGN KEY (Postagem_id) REFERENCES Postagem(id)
);

-- drop table Postagem;