Feature: UpdatePatient
  Como um usuario eu quero atualizar as informações do paciente


  Scenario: Atualizar paciente
    Given Eu abra a tela de atualizar pacientes
    And Eu escolha o cliente com Id 1
    And Eu insira o nome Arthur
    And Eu insira a data de nascimento para 09/10/1999
    And Eu insira a cor Branco
    When Eu clicar no botao atualizar
    Then O paciente deve ser atualizado com sucesso