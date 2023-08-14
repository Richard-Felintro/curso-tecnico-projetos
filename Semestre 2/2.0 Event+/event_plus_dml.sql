-- DML - Data Manipulation Language
USE EventPlus

INSERT INTO TipoDeUsuario    VALUES ('Comum'),('Administrador')
INSERT INTO Usuario          VALUES 
(2,'Joaquinsson','jqnsn@gmail.com','admin1234'),
(1,'Pedro Mendes','pedromendes123@gmail.com','12345678'),
(1,'Joana Joana','joana@jmail.com','87654321')
INSERT INTO TipoDeEvento     VALUES ('Palestra'),('C#'),('HTML')
INSERT INTO Instituicao      VALUES 
('03776284000109','SENAI','SERVI�O NACIONAL DE APRENDIZAGEM INDUSTRIAL - SENAI','Rua dos Bobos, 0')
INSERT INTO Evento           VALUES 
(1,1,'Palestra sobre inclus�o escolar.','Dr. Nome Chique Daora Discute sua experi�ncia com a inclus�o nas escolas modernas.','2023-07-25','14:00:00'),
(2,1,'B�sico de C#','Professor Pseudoeverton ensina o b�sico do C# incluindo vari�veis e m�todos.','2023-09-03','18:00:00')
INSERT INTO Comentario       VALUES (1,2,'Muito bom, adorei muito bom uau muito muito bom gostei uau uau <3'),
(1,3,'horr�vel.'),
(2,3,'Muito animado para o evento! Espero muito.')
INSERT INTO PresencaEmEvento VALUES(1,1,1),(1,2,1),(1,3,0),(2,2,1)

SELECT * FROM PresencaEmEvento
