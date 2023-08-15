-- DDL - Data Definition Language
CREATE DATABASE HealthClinic

USE HealthClinic

CREATE TABLE Clinica
(
	IdClinica INT PRIMARY KEY IDENTITY,
	Cnpj VARCHAR(14) NOT NULL UNIQUE,
	Endereco VARCHAR(256) NOT NULL,
	RazaoSocial VARCHAR(256) NOT NULL,
	NomeFantasia VARCHAR(32) NOT NULL,
	HorarioAbertura TIME NOT NULL,
	HorarioFechamento TIME NOT NULL
)

CREATE TABLE Paciente
(
	IdPaciente INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(64) NOT NULL,
	Email VARCHAR(64) NOT NULL UNIQUE,
	Senha VARCHAR(64) NOT NULL,
	DataNascimento DATE NOT NULL
)

CREATE TABLE Medico
(
	IdMedico INT PRIMARY KEY IDENTITY,
	IdClinica INT FOREIGN KEY REFERENCES Clinica(IdClinica),
	Nome VARCHAR(64) NOT NULL,
	Email VARCHAR(64) NOT NULL UNIQUE,
	Senha VARCHAR(64) NOT NULL,
	DataNascimento DATE NOT NULL
)

CREATE TABLE Administrador
(
	IdAdministrador INT PRIMARY KEY IDENTITY,
	IdClinica INT FOREIGN KEY REFERENCES Clinica(IdClinica),
	Nome VARCHAR(64) NOT NULL,
	Email VARCHAR(64) NOT NULL UNIQUE,
	Senha VARCHAR(64) NOT NULL,
	DataNascimento DATE NOT NULL
)

CREATE TABLE Consulta
(
	IdConsulta INT PRIMARY KEY IDENTITY,
	IdClinica INT FOREIGN KEY REFERENCES Clinica(IdClinica),
	IdPaciente INT FOREIGN KEY REFERENCES Paciente(IdPaciente),
	IdMedico INT FOREIGN KEY REFERENCES Medico(IdMedico),
	DataAtendimento DATE,
	HoraAtendimento TIME,
	Prontuario VARCHAR(MAX),
)

CREATE TABLE Especialidade
(
	IdEspecialidade INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(64) NOT NULL
)

CREATE TABLE JoinEspecialidade
(
	IdMedico INT FOREIGN KEY REFERENCES Medico(IdMedico),
	IdEspecialidade INT FOREIGN KEY REFERENCES Especialidade(IdEspecialidade)
)

CREATE TABLE Comentario
(
	IdComentario INT PRIMARY KEY IDENTITY,
	IdPaciente INT FOREIGN KEY REFERENCES Paciente(IdPaciente),
	IdConsulta INT FOREIGN KEY REFERENCES Consulta(IdConsulta),
	Conteudo VARCHAR(256) NOT NULL
)