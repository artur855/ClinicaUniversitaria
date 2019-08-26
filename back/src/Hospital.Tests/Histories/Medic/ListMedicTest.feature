Feature: ListMedicTest
	In order to list all medics registred in the system

Scenario: Listing two or more medics
	Given I'm opening the medic list screen
	Then All the medic should be listed below
