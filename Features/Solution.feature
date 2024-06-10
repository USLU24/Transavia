@Demo
Feature: Tech Interview Challenge Solution

This is the BDD Cucumber feature file for the solution


    @Demo-B
Scenario: DemoQA Practice Form page
    Given I am on the  DemoQA Practife Form page
    When I enter Name as "Abcd" for Student Registration Form
    When I enter Surname as "EFG" for Student Registration Form
    When I enter Mail as "abcd.efgh@example.com" for Student Registration Form
    When I click Gender Male Button
    When I enter Mobile Number as "0123456789" for Student Registration Form
    When I click Date Of Birth Button
    When I enter Birth Month as "December" for Student Registration Form
    When I enter Birth Year as "1995" for Student Registration Form
    When I enter Select day as "19" for Student Registration Form
    Then I verify the date of birth is "19 Dec 1995"
    When I click Hobbies Sports Button
    When I click Hobbies Reading Button
    When I click Hobbies Music Button
    When I enter Current Address as "Obispo Street" for Student Registration Form
    When I click State  Button
    When I click Selected State Button
    When I click City  Button
    When I click Selected City Button
    When I submit Submit Button
    Then I verify that the thanks message is displayed


@Demo-E
   Scenario: Verify slider values are equal
    Given I navigate to the DemoQA slider page
    When I drag the slider button to the right
    Then the slider value should match the slider value text
