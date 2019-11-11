Feature: UpdateMedicTest
	In order to Update data in a medic

Scenario: Update data of a medic
	Given I'm opening the update medic screen
	Given I choose the medic by CRM 456
	Given I'm updating the name Faluno
	Given I'm updating the UserID 123
	When I'm clicking in the update button
	Then The medic should be updated with sucess
