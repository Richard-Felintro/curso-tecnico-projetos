-- DQL - Data Query Language
USE EventPlus

-- Criar script para consulta exibindo os seguintes dados.
/*Usar JOIN

Nome do usu�rio
Tipo do usu�rio
Data do evento
Local do evento (Institui��o)
Titulo do evento
Nome do evento
Descri��o do evento
Situa��o do evento
Coment�rio do evento
*/

SELECT 
Usuario.Nome AS Username,
TipoDeUsuario.TituloTipoUsuario AS Usertype,
Evento.Nome AS 'Evento',
Evento.Descricao AS 'Descri��o',
Evento.DataEvento AS 'Data do Evento',
Instituicao.Endereco AS 'Endere�o',
CASE PresencaEmEvento.Confirmacao WHEN 0 THEN 'Ausente' WHEN 1 THEN 'Presente' END AS 'Presen�a',
Comentario.Conteudo AS 'Coment�rio'

FROM 
TipoDeUsuario
LEFT JOIN Usuario ON TipoDeUsuario.IdTipoUsuario = Usuario.IdTipoUsuario
LEFT JOIN PresencaEmEvento ON PresencaEmEvento.IdUsuario = Usuario.IdUsuario
LEFT JOIN Evento ON Evento.IdEvento = PresencaEmEvento.IdEvento
LEFT JOIN Comentario ON (Comentario.IdUsuario = Usuario.IdUsuario AND Comentario.IdEvento = Evento.IdEvento)
LEFT JOIN Instituicao ON Instituicao.IdInstituicao = Evento.IdInsituicao

WHERE
Usuario.IdUsuario = 2