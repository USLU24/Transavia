@Demo
Feature: Tech Interview Challenge Solution

This is the BDD Cucumber feature file for the solution

@Demo-A
  #Scenario: DemoQA Buttons page
   # Given I am on the  DemoQA Buttons page
   # When I click on the doubleclick button
   # Then Message "You have done a double click" from doubleClick
   # When I click on the rightclick button
   # Then Message "You have done a right click" from rightClick


    @Demo-B
Scenario: DemoQA Practice Form page
    Given I am on the  DemoQA Practife Form page
    When I enter Name as "Muharrem" for Student Registration Form
    When I enter Surname as "Uslu" for Student Registration Form
    When I enter Mail as "muharrem.uslu@example.com" for Student Registration Form
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





   






