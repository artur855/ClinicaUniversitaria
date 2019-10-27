-- Inserindo usuarios
INSERT INTO tb_usuarios (id, senha, email, nome) VALUES(1, 'admin', 'admin@admin.com', 'admin');
INSERT INTO tb_usuarios (id, senha, email, nome) VALUES(2, '123', 'anakin@medico.com', 'Anakin');
INSERT INTO tb_usuarios (id, senha, email, nome) VALUES(3, '123', 'leia@medico.com', 'Leia');
INSERT INTO tb_usuarios (id, senha, email, nome) VALUES(4, '123', 'luke@medico.com', 'Luke');
INSERT INTO tb_usuarios (id, senha, email, nome) VALUES(5, '123', 'obiwan@medico.com', 'Obi-Wan');
INSERT INTO tb_usuarios (id, senha, email, nome) VALUES(6, '123', 'yoda@medico.com', 'Yoda');
INSERT INTO tb_usuarios (id, senha, email, nome) VALUES(7, '123', 'han@paciente.com', 'Han Solo');
INSERT INTO tb_usuarios (id, senha, email, nome) VALUES(8, '123', 'lando@paciente.com', 'Lando');
INSERT INTO tb_usuarios (id, senha, email, nome) VALUES(9, '123', 'jabba@paciente.com', 'Jabba');

-- Inserindo Medicos
INSERT INTO tb_medicos (id, crm, titulacao, ano_inicio, tipo_medico, id_usuario) VALUES(1, '09283SE', NULL, '2010-06-04', 2, 6);
INSERT INTO tb_medicos (id, crm, titulacao, ano_inicio, tipo_medico, id_usuario) VALUES(2, '81273RJ', NULL, '1977-04-10', 2, 4);
INSERT INTO tb_medicos (id, crm, titulacao, ano_inicio, tipo_medico, id_usuario) VALUES(3, '12938RE', NULL, '2019-08-07', 2, 1);
INSERT INTO tb_medicos (id, crm, titulacao, ano_inicio, tipo_medico, id_usuario) VALUES(4, '19823LP', 'Meste', NULL, 1, 5);
INSERT INTO tb_medicos (id, crm, titulacao, ano_inicio, tipo_medico, id_usuario) VALUES(5, '129083DP', NULL, NULL, 0, 3);

-- Inserindo Pacientes 
INSERT INTO tb_pacientes (id, sexo, cor, dt_nasc, id_usuario) VALUES(1, 'M', 0, '1094-05-02', 7);
INSERT INTO tb_pacientes (id, sexo, cor, dt_nasc, id_usuario) VALUES(2, 'M', 1, '1827-08-10', 8);
INSERT INTO tb_pacientes (id, sexo, cor, dt_nasc, id_usuario) VALUES(3, 'M', 2, '2000-06-28', 9);

-- Inserindo Pedidos Exame
INSERT INTO tb_pedidos_exames (id, id_medico, exame, data_prevista, recomendacao, hipotese_cid, id_paciente) VALUES(1, 1, 1, '2021-05-09', 'tomar chá', '2', 1);
INSERT INTO tb_pedidos_exames (id, id_medico, exame, data_prevista, recomendacao, hipotese_cid, id_paciente) VALUES(2, 2, 2, '2019-08-07', 'relaxar', '3', 1);
INSERT INTO tb_pedidos_exames (id, id_medico, exame, data_prevista, recomendacao, hipotese_cid, id_paciente) VALUES(3, 3, 2, '2019-09-01', 'qualquer coisa aqui', NULL, 1);
INSERT INTO tb_pedidos_exames (id, id_medico, exame, data_prevista, recomendacao, hipotese_cid, id_paciente) VALUES(4, 4, 1, '2019-09-01', 'qualquer coisa aqui', NULL, 1);
INSERT INTO tb_pedidos_exames (id, id_medico, exame, data_prevista, recomendacao, hipotese_cid, id_paciente) VALUES(5, 5, 3, '2019-09-23', 'qualquer coisa aqui', NULL, 1);
INSERT INTO tb_pedidos_exames (id, id_medico, exame, data_prevista, recomendacao, hipotese_cid, id_paciente) VALUES(6, 5, 3, '2019-09-23', 'qualquer coisa aqui', NULL, 1);
INSERT INTO tb_pedidos_exames (id, id_medico, exame, data_prevista, recomendacao, hipotese_cid, id_paciente) VALUES(7, 2, 3, '2019-09-23', 'qualquer coisa aqui', NULL, 1);

