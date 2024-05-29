@Demo
Feature: Tech Interview Challenge Solution

This is the BDD Cucumber feature file for the solution

@Demo-A
  Scenario: Successful Transavia with Valid Credentials
   # Given I am on the  Transavia page
   # When I click on the Book button
   # When I click on the World Icon button
   # When I count the texts of sibling div elements
   # Then I print the count of texts of sibling div elements
    Given I am on the  DemoQA Buttons page
    When I click on the doubleclick button
    Then Message "You have done a double click" from doubleClick
    When I click on the rightclick button
    Then Message "You have done a right click" from rightClick




