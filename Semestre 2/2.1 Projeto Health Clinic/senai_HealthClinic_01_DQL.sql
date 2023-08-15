-- DQL - Data Query Language
USE HealthClinic

--Criar função para retornar a quantidade de médicos de uma determinada especialidade
SELECT
M.Nome AS Nome,
M.Email AS Email

FROM Medico AS M
LEFT JOIN JoinEspecialidade AS J ON J.IdMedico = M.IdMedico
WHERE J.IdEspecialidade = 2

--Criar procedure para retornar a idade de um determinado usuário específico
USE HealthClinic

SELECT 
Paciente.Nome,
DATEDIFF(YEAR, Paciente.DataNascimento, GETDATE()) AS Idade
FROM Paciente
WHERE Paciente.IdPaciente = 3