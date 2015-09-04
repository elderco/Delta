/*

CREATE TABLE Cardapio(
	Id int IDENTITY(1,1) PRIMARY KEY,
	Nome nvarchar(max) NOT NULL
)
GO
CREATE TABLE TipoPrato(
	Id int IDENTITY(1,1) PRIMARY KEY,
	Nome nvarchar(max) NOT NULL,
	Ordem int NOT NULL
)
GO
CREATE TABLE Prato(
	Id int IDENTITY(1,1) PRIMARY KEY,
	Nome nvarchar(max) NOT NULL,
	TipoPratoId int NOT NULL FOREIGN KEY REFERENCES TipoPrato(Id),
	CardapioPadrao_Id int NULL
)

UPDATE PratosImportados SET PRATO = REPLACE(ltrim(rtrim(prato)), ' COQUETEL FRIO - ', '')
select count(1) from PratosImportados

--INSERT INTO Cardapio
select distinct(Cardapio) from PratosImportados
order by 1

--INSERT INTO TipoPrato
select distinct(TipoPrato), 0 from PratosImportados
order by 1
*/

select distinct(Prato), count(1) from PratosImportados
--where prato like '%tortelini%'
group by prato
order by 1, 2 DESC
