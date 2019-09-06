Feature: CreateExamRequest
  Como médico eu quero solicitar um pedido de um exame para um paciente para poder realizar um diagnóstico

  Scenario: Criar pedido de exame: 
    Given Eu abra a tela para fazer pedidos de exames
    And Eu adicionar o identificador do paciente 2
    And Escolha o exame ecocardiograma
    And Escolha a data 2019-08-08 para realizar o exame
    And Informe o hípotese A001
    When Eu clicar em emitir pedido
    Then O sistema salvar e imprimir o pedido de exame