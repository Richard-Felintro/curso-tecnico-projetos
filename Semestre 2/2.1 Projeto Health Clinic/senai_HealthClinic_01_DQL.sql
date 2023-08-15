-- DQL - Data Query Language
USE HealthClinic

-- Criar fun��o para retornar a quantidade de m�dicos de uma determinada especialidade
SELECT
M.Nome AS Nome,
M.Email AS Email

FROM Medico AS M
LEFT JOIN JoinEspecialidade AS J ON J.IdMedico = M.IdMedico
WHERE J.IdEspecialidade = 2

-- Criar procedure para retornar a idade de um determinado usu�rio espec�fico
USE HealthClinic

SELECT 
Paciente.Nome,
DATEDIFF(YEAR, Paciente.DataNascimento, GETDATE()) AS Idade
FROM Paciente
WHERE Paciente.IdPaciente = 3


-- Join da consulta
SELECT
Clinica.NomeFantasia AS 'Cl�nica Respons�vel',
Paciente.Nome AS Paciente,
DATEDIFF(YEAR, Paciente.DataNascimento, GETDATE()) AS Idade,
Medico.Nome AS 'M�dico Respons�vel',
Especialidade.Nome AS 'Especialidade M�dico',
CAST(Consulta.DataAtendimento as SMALLDATETIME) + CAST(Consulta.HoraAtendimento AS SMALLDATETIME) as 'Hor�rio',
Consulta.Prontuario AS 'Prontu�rio',
Comentario.Conteudo AS 'Coment�rio'

FROM Consulta
LEFT JOIN Paciente ON Consulta.IdPaciente = Paciente.IdPaciente
LEFT JOIN Medico ON Consulta.IdMedico = Medico.IdMedico
LEFT JOIN Clinica ON Clinica.IdClinica = Medico.IdClinica
LEFT JOIN Comentario ON Comentario.IdConsulta = Consulta.IdConsulta
LEFT JOIN JoinEspecialidade ON (JoinEspecialidade.IdMedico = Medico.IdMedico) 
LEFT JOIN Especialidade ON (JoinEspecialidade.IdMedico = Medico.IdMedico) 
AND (Especialidade.IdEspecialidade = JoinEspecialidade.IdEspecialidade)

WHERE Consulta.IdConsulta = 2

SELECT
CONVERT(TIME(0), Clinica.HorarioAbertura)
FROM Clinica