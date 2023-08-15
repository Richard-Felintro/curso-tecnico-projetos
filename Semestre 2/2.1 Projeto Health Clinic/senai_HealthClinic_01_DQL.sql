-- DQL - Data Query Language
USE HealthClinic

-- Criar função para retornar a quantidade de médicos de uma determinada especialidade
SELECT
M.Nome AS Nome,
M.Email AS Email

FROM Medico AS M
LEFT JOIN JoinEspecialidade AS J ON J.IdMedico = M.IdMedico
WHERE J.IdEspecialidade = 2

-- Criar procedure para retornar a idade de um determinado usuário específico
USE HealthClinic

SELECT 
Paciente.Nome,
DATEDIFF(YEAR, Paciente.DataNascimento, GETDATE()) AS Idade
FROM Paciente
WHERE Paciente.IdPaciente = 3


-- Join da consulta
SELECT
Clinica.NomeFantasia AS 'Clínica Responsável',
Paciente.Nome AS Paciente,
DATEDIFF(YEAR, Paciente.DataNascimento, GETDATE()) AS Idade,
Medico.Nome AS 'Médico Responsável',
Especialidade.Nome AS 'Especialidade Médico',
CAST(Consulta.DataAtendimento as SMALLDATETIME) + CAST(Consulta.HoraAtendimento AS SMALLDATETIME) as 'Horário',
Consulta.Prontuario AS 'Prontuário',
Comentario.Conteudo AS 'Comentário'

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