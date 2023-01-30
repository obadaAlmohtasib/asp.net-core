### Task Scenario: ### 

Assume we have an XML file which contains available hotels and rooms and a JSON file which also contains available hotels and rooms as well, but with a different structure and we need a web service which manipulates the two different files and returns a unified output as XML to a front-end ASP.NET Core app that displays returned results in a table (each row represent a hotel with child rows that represent rooms) with a filtration facility.

 

### Task Components: ### 

  * Web API service
    * Handles the unification process and returns output.

    * Handles the filtration process requests.

  * MVC application
    * One view to display results in a grid.

    * Grid parent rows (hotels) collapsible to display child rows (rooms).

  * Filtration by (HotelName, HotelRating, IsReady) via web API service.

 

### Task Objectives : ### 

  * Combine results from both JSON and XML files in a unified output.

  * Web service client should receive a unified output regardless the source of data (Our JSON and XML files).

 

### Take into consideration the following points : ###

  * We need a flexible software design which accepts adding a new file structure (e.g. CSV, etc) without affecting the whole process.

  * Filtration process occurs within the web service.

  * Development should be under C#.

  * JSON and XML data sources attached.

  * Expected time estimation: 8-16 working hours and a maximum of 2 days.
