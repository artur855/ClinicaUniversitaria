create table tb_usuarios (
  id serial,
  senha varchar(45),
  email varchar(60),
  nome varchar(150)
);

create table tb_medicos(
  crm  varchar(13),
  titulacao varchar(45) null,
  ano_inicio date null,
  tipo_medico smallint not null,
  id_usuario serial not null
);

create table tb_resultado_exame (
  id serial,
  crm_medico varchar(13),
  id_pedido_exame serial,
  link_pdf varchar(350),
  data_hora date
);

create table tb_pedidos_exames(
  id serial,
  crm_medico varchar(13),
  exame smallint,
  data_prevista date,
  recomendacao varchar(650),
  hipotese_cid varchar(4),
  id_paciente serial
);

create table tb_laudos(
  id_pedido_exame serial,
  crm_medico varchar(13),
  descricao varchar(250),
  conclusao varchar(150)
);

create table tb_laudos_status(
  id_laudo_exame serial,
  status boolean,
  crm_medico varchar(13)
);

create table tb_pacientes(
  id serial,
  sexo char(1),
  cor smallint,
  dt_nasc date,
  id_usuario serial
);

-- primary keys
alter table tb_medicos add constraint tb_medicos_pk primary key (crm);

alter table tb_resultado_exame add constraint tb_resultado_exame_pk primary key (id);

alter table tb_pedidos_exames add constraint tb_pedidos_exames_pk primary key (id);

alter table tb_laudos add constraint tb_laudos_pk primary key (id_pedido_exame);

alter table tb_laudos_status add constraint  tb_laudos_status_pk primary key (id_laudo_exame);

alter table tb_pacientes add constraint tb_pacientes_pk primary key  (id);

alter table tb_usuarios add constraint tb_usuarios_pk primary key (id);


-- foregin keys

alter table tb_medicos add constraint tb_medicos_usuarios_fk foreign key (id_usuario) references tb_usuarios (id);


alter table tb_pacientes add constraint tb_pacientes_usuarios_fk foreign key (id_usuario) references tb_usuarios (id);


alter table tb_resultado_exame add constraint tb_resultado_exame_medicos_fk foreign key (crm_medico) references tb_medicos (crm);

alter table tb_resultado_exame add constraint tb_resultado_exame_pedidos_exames_fk foreign key (id_pedido_exame) references tb_pedidos_exames(id);


alter table tb_pedidos_exames add constraint tb_pedidos_exames_medico_fk foreign key (crm_medico) references tb_medicos (crm);

alter table tb_pedidos_exames add constraint tb_pedidos_exames_paciente_fk foreign key (id_paciente) references tb_pacientes(id);

alter table tb_laudos add constraint tb_laudos_exame_fk foreign key (id_pedido_exame) references tb_resultado_exame (id);

alter table tb_laudos add constraint tb_laudos_medicos_fk foreign key (crm_medico) references tb_medicos(crm);


alter table tb_laudos_status add constraint tb_laudos_status_laudo_fk foreign key (id_laudo_exame) references tb_laudos (id_pedido_exame);

alter table tb_laudos_status add constraint tb_laudos_status_medicos_fk foreign key (crm_medico) references tb_medicos (crm);


-- constraints
alter table tb_pacientes add constraint tb_pacientes_cor check (cor between 0 and 4);

alter table tb_pacientes add constraint tb_pacientes_sexo check (sexo in ('M', 'F'));


alter table tb_medicos add constraint tb_medicos_tipo check (tipo_medico in (0, 1, 2));









