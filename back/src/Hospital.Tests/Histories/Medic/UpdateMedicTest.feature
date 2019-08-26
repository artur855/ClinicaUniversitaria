Feature: UpdateMedicTest
	In order to Update data in a medic

Scenario: Update data of a medic
	Given I'm opening the update medic screen
	Given I choose the medic by CRM 123
	Given I'm updating the name Ciclano
	Given I'm updating the CRM 456
	Given I'm updating the UserID 456
	When I'm clicking in the update button
	Then The medic should be updated with sucess
