﻿-- create table container (
--   container_id serial primary key,
--   descricao varchar(100),
--   altura numeric(10,2),
--   largura numeric(10,2),
--   comprimento numeric(10,2),
--   capacidade numeric(18,2),
--   dt_record timestamp without time zone,
--   dt_update timestamp without time zone,
--   dt_vencimento date,
--   tipo smallint
-- );

-- create table produto (
--   produto_id serial primary key,
--   descricao varchar(100),
--   unidade varchar(20),
--   dt_record timestamp without time zone,
--   dt_update timestamp without time zone
-- );

-- create table navio (
--   navio_id serial primary key,
--   descricao varchar(100),
--   capacidade integer,
--   dt_record timestamp without time zone,
--   dt_update timestamp without time zone
-- );

-- create table viagem (
--   viagem_id serial primary key,
--   origem varchar(100),
--   destino varchar(100),
--   dt_partida date,
--   dt_planejado date,
--   dt_chegada date,
--   navio_id integer references navio(navio_id),
--   dt_record timestamp without time zone,
--   dt_update timestamp without time zone
-- );

-- create table item_viagem (
--   item_viagem_id serial primary key,
--   viagem_id integer references viagem(viagem_id),
--   container_id integer references container(container_id),
--   produto_id integer references produto(produto_id),
--   carga numeric(18,2),
--   dt_record timestamp without time zone,
--   dt_update timestamp without time zone
-- );