-- DML - Data Manipulation Language
USE HealthClinic

INSERT INTO Clinica VALUES 
	(12345678901234,'Rua dos Bobos, 0','Rede Hospitalar de Consultas Health Clinic','Health Clinic','06:00','22:00')
INSERT INTO Paciente VALUES 
	('João Pedro','joaopedro06@gmail.com','joao1234'),
	('Astunfo','astunfo1234@hotmail.com','12345678'),
	('Arnaldina','arna33@gmail.com','1a2b3c4d'),
	('Vitória','derrota@gmail.com','12345abcde'),
	('Menelique II','reunifiqueiaetiopia@gmail.com','12341234')
INSERT INTO Medico VALUES
	(1,'Jotuncio Neves','jneves666@gmail.com','JN12345678'),
	(1,'Cláudio João','automotivaclaudio3k@gmail.com','Claudio6969'),
	(1,'Jetumbia Augusta','jetaug33@gmail.com','1234567890')
INSERT INTO Administrador VALUES
	(1,'Washington Rothschild','ricoprakrl@gmail.com','KRL123123'),
	(1,'Melon Husk','minasdecobalto@gmail.com','musk123456')
INSERT INTO Consulta VALUES
	(1,1,3,'02-08-2023','08:00','Exame de urina realizado, tudo de acordo.'),
	(1,2,2,'23-07-2023','15:00','Check-Up básico, tudo de acordo.'),
	(1,3,1,'16-08-2023','17:00','Exame de pele, suspeita de cancer.')
INSERT INTO Especialidade VALUES
	('Dermatólogo'),('Pediátra'),('Urólogo'),('Anestesista'),('Médico Radiologista'),('Necromante')
INSERT INTO JoinEspecialidade VALUES
	(1,1),(1,6),(2,2),(2,3),(3,2),(3,4),(3,5)
INSERT INTO Comentario VALUES
	(1,3,'Isso não me parece bom...')