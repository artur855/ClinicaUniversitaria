Feature: InsertMedicTest
	In order to register Medic in the system

Scenario: Registing Medic
	Given I'm opening the medic register screen
	Given Insert the CRM 123
	Given Insert the UserID 123
	When I'm clicking in register screen
	Then My medic should be listed with CRM and UserID 123