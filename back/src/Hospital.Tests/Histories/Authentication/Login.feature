Feature: LoginUser
  Como um usuario eu quero logar no sistema


  Scenario: Logar usuário
    Given Eu abra a tela de login
    And Eu insira o email email@email.com
    And Eu insira a senha 1234567890
    When Eu clicar em login
    Then O usuario dese ser logado com sucesso