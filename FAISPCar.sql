create database FAISPCar;
use faispcar;
create table clientes (
nome varchar(255),
cpf varchar(14) not null,
telefone varchar(20),
email varchar(255),
endereço varchar(255),
datanasc varchar(10),
login varchar(255),
usuario varchar(255),
senha varchar(10),
PRIMARY KEY (cpf)
);

create table carros (
cod_car int primary key auto_increment,
marca varchar(20),
carroceria varchar(20),
ano varchar(4),
quilometragem int(20),
modelo varchar(20),
placa varchar(7),
versao varchar(100),
valor_compra decimal(8,2),
valor_venda decimal(8,2),
lucro decimal(8,2),
data_compra varchar(10),
data_venda varchar(10),
combustivel varchar(10),
cor varchar(20)
);

describe carros;
select * from carros;
describe clientes;
select * from clientes;
use faispcar;
DELETE FROM faispcar.carros
WHERE cod_car = 1;
update carros
set versao = 4
where cod_car = 2;
insert into carros (marca, modelo, carroceria, ano, quilometragem, placa,
versao, cor, valor_compra, valor_venda, lucro, data_compra, data_venda, combustivel)
values
('Volkswagen','Fox','Hatch','2010',110000,'FSP4D23','1.0','Preto',30000,33000,3000,'2020-05-06','2024-05-06','Flex');

-- Volkswagen
	-- Fox
	-- Fusca
	-- Gol
	-- Jetta
	-- Kombi
-- FIAT
	-- 500
    -- Stilo
    -- Uno
    -- Doblô
    -- Palio
-- Ford
	-- Belima
    -- Mustang
    -- Escort
    -- Fiesta
    -- Fusion
-- Chevrolet
	-- Opala
    -- Astra
    -- Blazer
    -- Camaro
    -- Caravan
-- BYD
	-- Dolphin Mini
    -- Dolphin
    -- Seal
    -- Yuan
    -- Song
    
   ALTER TABLE carros
   modify column lucro decimal (8,2);
   
   describe carros;
   
   select * from carros;
   use faispcar;
alter table carros
modify column deleted_by varchar(14) null;
   
   