-- DQL - Data Query Language
USE HealthClinic

--Criar fun��o para retornar a quantidade de m�dicos de uma determinada especialidade
SELECT
M.Nome AS Nome,
M.Email AS Email

FROM Medico AS M
LEFT JOIN JoinEspecialidade AS J ON J.IdMedico = M.IdMedico
WHERE J.IdEspecialidade = 2

--Criar procedure para retornar a idade de um determinado usu�rio espec�fico
USE HealthClinic

SELECT 
Paciente.Nome,
DATEDIFF(YEAR, Paciente.DataNascimento, GETDATE()) AS Idade
FROM Paciente
WHERE Paciente.IdPaciente = 3