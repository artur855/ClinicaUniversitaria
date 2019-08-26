Feature: DeleteMedicTest
	In order to delete medic

Scenario: Delete Medic
	Given I'm opening the medic delete screen
	Given Choose the medic with CRM 123456
	When I'm clicking at delete
	Then The medic should be deleted with sucess
