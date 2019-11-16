Feature: CreateExamReport
  Como um residente eu quero poder cadastrar o laudo do exame para que ele possa ser avaliado

  Scenario: Criar laudo de exame:
    Given Eu abra a tela para publicar o laudo do exame
    And Eu escolha o exame de id 1
    And Eu irei adicionar a descrição Manchas na parte superior esquerdo do pulmao
    And Eu adicione a hipótese como 123
    When Eu clicar em emitir laudo
    Then O sistema devera emitir o laudo em meu nome