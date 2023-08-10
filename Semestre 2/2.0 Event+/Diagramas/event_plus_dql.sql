-- DQL - Data Query Language
USE EventPlus

-- Mostrar todos os comentários referentes ao Evento de C# em 2023/07/25 e seus comentantes.
SELECT 
Usuario.Nome,
Comentario.Conteudo AS Comentário

FROM
TipoDeUsuario,
Usuario,
Comentario

WHERE
TipoDeUsuario.IdTipoUsuario = Usuario.IdTipoUsuario AND
Comentario.IdUsuario = Usuario.IdUsuario AND
Comentario.IdEvento = 1