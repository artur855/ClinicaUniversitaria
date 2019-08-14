Feature: InsertPacient
  Como um médico eu quero poder cadastrar pacientes no sistema


  Scenario: Cadastrar paciente
    Given Eu abra a tela de cadastrar paciente
    And Insira o nome Arthur
    And Insira a data de nascimento 09/10/1999
    And Insira a cor branco
    And Insira o sexo M
    When Eu clicar em cadastrar
    Then Meu cliente deve ser listado com id maior que 0