Feature: InsertPatient
  Como um usuario eu quero cadastrar pacientes no sistema


  Scenario: Cadastrar paciente
    Given Eu abra a tela de cadastrar paciente
    And Insira o nome Arthur
    And Insira a data de nascimento 09/10/1999
    And Insira a cor branco
    And Insira o sexo M
    When Eu clicar em cadastrar
    Then Meu paciente deve ser listado com id maior que 0