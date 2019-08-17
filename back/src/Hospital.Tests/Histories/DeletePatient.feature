Feature: DeletePatient
  Como um usuario eu quero deletar pacientes do sistema


  Scenario: Deletar paciente
    Given Eu abra a tela de deletar paciente
    And Escolha o cliente com Id 1
    When Eu clicar em deletar
    Then O cliente deve ser deletado com sucesso