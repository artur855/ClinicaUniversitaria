Feature: DeleteExamTest
	In order to delete exams, i order deletem them.

Scenario: Deletando exame
	Given Eu abra a tela que procura os exames ecocardiograma
	When Eu clicar em deletar exame
	Then O sistema atualiza e verifica
