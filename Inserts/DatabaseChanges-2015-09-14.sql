/*
	SELECT
		C.*
	FROM
		SYSCOLUMNS C
		INNER JOIN SYSOBJECTS T
		ON C.id = T.id
	WHERE
		T.Name = 'Evento'
*/

if NOT exists(
	SELECT
		1
	FROM
		SYSCOLUMNS C
		INNER JOIN SYSOBJECTS T
		ON C.id = T.id
	WHERE
		T.Name = 'Evento'
		And C.Name = 'EnviarAgendaSemanal'
	) 
BEGIN
	print 'N�o existe'
	ALTER TABLE Evento ADD EnviarAgendaSemanal BIT NOT NULL DEFAULT 1
	print 'coluna criada'
END
ELSE
	print 'coluna j� existe'
