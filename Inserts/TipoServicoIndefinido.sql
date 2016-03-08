/*
1	� Inglesa
2	Franco-Americano
3	� Inglesa com sobremesa em Ponto de Apoio
4	Volante
5	Volante com Ponto de Apoio
6	Volante e Buffet Simult�neos

update
	evento
set
	tiposervicoid = 2
where
	id in (57)

477 - 1

*/
SELECT
	e.id, CONVERT(VARCHAR(19), e.Data, 103), l.NomeCasa, e.NomeHomenageados, e.Data
FROM
	Evento e inner join [Local] l on l.id = e.localid
WHERE 
	TipoServicoId is null
	and e.id in
	(
		SELECT EventoId
		from PratoSelecionado
		WHERE Escolhido = 1
	)
Order by
	data