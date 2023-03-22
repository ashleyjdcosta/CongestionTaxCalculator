## Congestion Tax Calculator - .Net Core Solution :- 
In this readme file I will briefly discuss about the implementation, and what fixes, packages, appraoches along with the Test cases that I make use of. 

Technology selected: .Net Core standard 2.0, and in some of them due to package dependencies I have re-aligned the Versions accordingly(One challenge while re-aligning the version: The re-aligning of versioning caused some delay with targetted framework and so on)

## Author: Ashley Jeff Dcosta, Sr. Software Engineer. 

## Porjects used in the .Net Technology
## I have made use of three projects 
 1. The technical assignement project i.e. congestion-tax-calculator-net-core
 2. The .Net core web Api project to create an HTTP endpoint for accessing the Tax calculation Logic named congestion-tax-api
 3. Lastly I have used the .Net framework unit test project named congestion-tax-unit-tests


## The latest version of .Net web api has a swagger UI hence there would not be required for a Startup.cs nor a Postman tool inorder to test the API call. 

## Packages installed: 
 1. Json NewtonSoft from NuGets manager
 2. Microsoft Extensions Configurations

## Approach that I have made use inorder to address the problem statement, and solve the bug fixes
 1. I first created a unit test project inorder to test all the methods
 2. lot of hard coding in the code, I tried to create a data store such as the json file which could also be translated to an RDMS master table if requried. 
 3. Fix some bugs going forward
 4. Created unit tests for various scenarios provided in the problem statement helped a lot for the implementation to progress
 5. Created an entry point for the calculator to be used using an web api with a swagger UI for it to be tested

## Several BugFixes found in the code: 
 1. The Models such as the Car.cs and the MotorBike.cs were having the String class datatype instead of the instacne of the String i.e. string
 2. Code that was used to check the difference for an hour was being calculated over the DateTimes milliseconds whereas it should have been on the minutes of the dattime hence I made use of the TimeSpan date subtract feature
 3. The bug in #2 was violating the Single charge rule which is now fixed! 


### Test cases implemented: 
 I have implemented five test cases to test each of the following Scenarios(This TDD approach was very helpful atleast to fix the code part, and then the entry point using Web api was created)
 Scenario 1: ShouldReturnCorrectTaxAmount - Actual positive scenario - Passed!
 Scenario 2: ShouldReturnZeroForTollFreeVehicle - Positive scenario making sure the values return Toll free for said Vehicles - Passed!
 Scenario 3: ShouldReturnMaxDailyFeeIfExceeded - Max fee to pay is SEK 60, if there is a case that is exceeding then it is returning only 60 - Passed!
 Scenario 4: IsTollFreeVehicle_ShouldReturnTrueForTollFreeVehicle - True value for all Toll free Vehicles from the lsit provided - Passed!
Scenario 5: IsTollFreeVehicle_ShouldReturnFalseForNonTollFreeVehicle - False for all non toll free Vehicles - Passed!

## For the Bonus Scenario, 
 Since I have made use of the json storage as an option to add/update new cities, tax rules, etc. it is very welcoming for those changes. 
 I have created all of the content as a variables that are read by the json deserializer, and I have mapped the same json object with a model that I created called CongestionData.cs for the same. 
 Additionally, It is also possible to have the data source to be stored as master tables in the RDMS Sql databases.

## Note: 
 I have made use of two appsettings.json file, one for the UnitTesting purposes, and the other for the WebAPI inorder to perform Server side validation! 


 Estimated time spent for the overall completion was about 6.5 hours divided into 1.5, 1, 2, and 2 hours over the course of one week since I have a passion for programming and once I am engaged loose track of time :)  

 There could be lot that could improve this application and make it highly lucarative, following improvements that I can think of, 
 1. Adding a FrontEnd layer like an Angular project inroder to have a user friendly SPA(Single page applicaiton)
 2. As discussed even before, creating an RDMBS structure for the Data Structure, even for the transactions, mabye for audit purposes
 3. Add numerous Test Cases to test every positive, false postive, ... Scenarios
 4. Add more secuirty to the code  by implementing HTTPS SSL certificates 
