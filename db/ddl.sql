create table tb_medicos
(
  crm  varchar(13),
  nome varchar(150)
);

create table tb_docentes
(
  crm_medico varchar(13),
  titulacao  varchar(20)
);

create table tb_residentes(
  crm_medico varchar(13),
  ano_inicio date
);
create table tb_exames (
  id serial,
  nome varchar(25)
);

create table tb_resultado_exame (
  id serial,
  crm_residente varchar(13),
  id_pedido_exame serial,
  link_pdf varchar(350),
  data_hora date
);

create table tb_pedidos_exames(
  id serial,
  crm_medico varchar(13),
  id_exame serial,
  data_prevista date,
  recomendacao varchar(650),
  hipotese_cid varchar(4),
  id_paciente serial
);

create table tb_cid10(
  cid varchar(4)
);

create table tb_laudos(
  id_exame serial,
  crm_residente varchar(13),
  descricao varchar(250),
  conclusao varchar(150)
);

create table tb_laudos_status(
  id_laudo_exame serial,
  status boolean,
  crm_docente varchar(13)
);

create table tb_pacientes(
  id serial,
  nome varchar(150),
  sexo char(1),
  cor smallint,
  dt_nasc date
);

alter table tb_medicos add constraint tb_medicos_pk primary key (crm);

alter table tb_docentes add constraint tb_docentes_pk primary key (crm_medico);

alter table tb_residentes add constraint tb_residentes_pk primary key (crm_medico);

alter table tb_exames add constraint tb_exames_pk primary key (id);

alter table tb_resultado_exame add constraint tb_resultado_exame_pk primary key (id);

alter table tb_pedidos_exames add constraint tb_pedidos_exames_pk primary key (id);

alter table tb_cid10 add constraint tb_cid10_pk primary key (cid);

alter table tb_laudos add constraint tb_laudos_pk primary key (id_exame);

alter table tb_laudos_status add constraint  tb_laudos_status_pk primary key (id_laudo_exame);

alter table tb_pacientes add constraint tb_pacientes_pk primary key  (id);

alter table tb_docentes add constraint tb_docentes_medicos_fk foreign key (crm_medico) references tb_medicos(crm);

alter table tb_residentes add constraint tb_residentes_medicos_fk foreign key (crm_medico) references tb_medicos(crm);

alter table tb_resultado_exame add constraint tb_resultado_exame_residentes_fk foreign key (crm_residente) references tb_residentes (crm_medico);

alter table tb_resultado_exame add constraint tb_resultado_exame_pedidos_exames_fk foreign key (id_pedido_exame) references tb_pedidos_exames(id);

alter table tb_pedidos_exames add constraint tb_pedidos_exames_medico_fk foreign key (crm_medico) references tb_medicos (crm);

alter table tb_pedidos_exames add constraint tb_pedidos_exames_cid_fk foreign key (hipotese_cid) references tb_cid10 (cid);

alter table tb_pedidos_exames add constraint tb_pedidos_exames_paciente_fk foreign key (id_paciente) references tb_pacientes(id);

alter table tb_pedidos_exames add constraint tb_pedidos_exames_exame_fk foreign key (id_exame) references tb_exames (id);

alter table tb_laudos add constraint tb_laudos_exame_fk foreign key (id_exame) references tb_resultado_exame(id);

alter table tb_laudos add constraint tb_laudos_residentes_fk foreign key (crm_residente) references tb_residentes(crm_medico);

alter table tb_laudos_status add constraint tb_laudos_status_laudo_fk foreign key (id_laudo_exame) references tb_laudos (id_exame);

alter table tb_laudos_status add constraint tb_laudos_status_docente_fk foreign key (crm_docente) references tb_docentes (crm_medico);

alter table tb_pacientes add constraint tb_pacientes_cor check (cor between 0 and 4);

alter table tb_pacientes add constraint tb_pacientes_sexo check (sexo in ('M', 'F'));









