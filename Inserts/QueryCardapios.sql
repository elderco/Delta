/*
--DROP TABLE Cardapio
CREATE TABLE Cardapio(
	Id int IDENTITY(1,1) PRIMARY KEY,
	Nome nvarchar(max) NOT NULL
)
GO

--DROP TABLE TipoPrato
CREATE TABLE TipoPrato(
	Id int IDENTITY(1,1) PRIMARY KEY,
	Nome nvarchar(max) NOT NULL,
	Ordem int NOT NULL
)
GO
--DROP TABLE Prato
CREATE TABLE Prato(
	Id int IDENTITY(1,1) PRIMARY KEY,
	Nome nvarchar(max) NOT NULL,
	TipoPratoId int NOT NULL FOREIGN KEY REFERENCES TipoPrato(Id)
)

--DROP TABLE PratoCardapio
CREATE TABLE PratoCardapio(
	PratoId int NULL,
	CardapioId int NULL
)

UPDATE PratosImportados SET PRATO = REPLACE(ltrim(rtrim(prato)), ' COQUETEL FRIO - ', '')
select count(1) from PratosImportados

--INSERT INTO Cardapio
select distinct(Cardapio) from PratosImportados
order by 1

--INSERT INTO TipoPrato
select distinct(TipoPrato), 0 from PratosImportados
order by 1

DELETE FROM PratosImportados

*/

select distinct(Prato), count(1)
from PratosImportados
group by prato
order by 1, 2 DESC

--SELECT * FROM PratosImportados WHERE Prato LIKE 'welcome drinks - %'
--UPDATE PratosImportados SET Prato = LTRIM(RTRIM(Prato))
--UPDATE PratosImportados SET Prato = REPLACE(Prato, 'gtorgonzola', 'gorgonzola')

/*

UPDATE PratosImportados
SET Prato = LTRIM(RTRIM(LEFT(lower(Prato), CHARINDEX('acompanhad', Prato) - 1)))
WHERE CHARINDEX('acompanhad', Prato) - 1 > 0

UPDATE PratosImportados SET Prato = lower(Prato)

congrio chileno e espinafre ao molho de laranja e conhaque legumes

caldinho de feij�o preto spicy	2
caldinho de feij�o preto spicy servido em x�cara de porcelana	1

creme de ab�bora aromatizado	1
creme de ab�bora aromatizado servido em x�cara de porcelana	1

frisse salad com beterrabas e roquefort	6
frisse salad com beterrabas e roquefort temperadas com molho de azeite, lim�o, sal, pimenta e ervas	1

micro quiche de queijo
micro quiche de queijos

petit caprese ao pesto genovese
petit caprese com pesto genovese

piccolini ao molho de tomates frescos
piccolini com molho de tomates frescos
piccolini com molho de tomates frescos(acompanha queijo ralado)

salada de frutas da esta��o marinadas em redu��o de bals�mico (molho) e spicy pecans
salada de frutas da esta��o marinadas em redu��o de bals�mico e spicy pecans

sofioli verde com queijos especiais ao molho de tomates r�sticos
sofiolli verde com queijos especias ao molho de tomates r�sticos

standby
frutas frescas fatiadas
standby
frutas frescas laminadas

terrine de legumes grelhados, castanhas em redu��o de bals�mico (molho) e suas folhas frescas
terrine de legumes grelhados, castanhas em redu��o de bals�mico e suas folhas frescas

*/
