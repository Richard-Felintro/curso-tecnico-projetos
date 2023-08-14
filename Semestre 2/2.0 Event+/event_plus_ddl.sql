-- DDL - Data Definition Language

-- Criar o banco de dados
CREATE DATABASE EventPlus

DROP DATABASE EventPlus

-- Criar tabelas
USE EventPlus

CREATE TABLE TipoDeUsuario
(
	IdTipoUsuario INT PRIMARY KEY IDENTITY,
	TituloTipoUsuario VARCHAR(16) NOT NULL
)

CREATE TABLE Usuario
(
	IdUsuario INT PRIMARY KEY IDENTITY,
	IdTipoUsuario INT FOREIGN KEY REFERENCES TipoDeUsuario(IdTipoUsuario),
	Nome VARCHAR(32)  NOT NULL,
	Email VARCHAR(128) NOT NULL UNIQUE,
	Senha VARCHAR(16) NOT NULL
)

CREATE TABLE TipoDeEvento
(
	IdTipoEvento INT PRIMARY KEY IDENTITY,
	TituloTipoEvento VARCHAR(32) NOT NULL
)

CREATE TABLE Instituicao
(
	IdInstituicao INT PRIMARY KEY IDENTITY,
	Cnpj CHAR(14)            NOT NULL UNIQUE,
	NomeFantasia VARCHAR(32) NOT NULL,
	RazaoSocial VARCHAR(128) NOT NULL,
	Endereco VARCHAR(128)    NOT NULL
)

CREATE TABLE Evento
(
	IdEvento INT PRIMARY KEY IDENTITY,
	IdTipoEvento INT FOREIGN KEY REFERENCES TipoDeEvento(IdTipoEvento),
	IdInsituicao INT FOREIGN KEY REFERENCES Instituicao(IdInstituicao),
	Nome VARCHAR(64)       NOT NULL,
	Descricao VARCHAR(128) NOT NULL,
	DataEvento DATE        NOT NULL,
	HoraEvento TIME        NOT NULL
)

CREATE TABLE Comentario
(
	IdComentario INT PRIMARY KEY IDENTITY,
	IdEvento INT FOREIGN KEY REFERENCES Evento(IdEvento),
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario),
	Conteudo VARCHAR(256) NOT NULL,
)

CREATE TABLE PresencaEmEvento
(
	IdPresencaEvento INT PRIMARY KEY IDENTITY,
	IdEvento INT FOREIGN KEY REFERENCES Evento(IdEvento),
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario),
	Confirmacao BIT,
)


