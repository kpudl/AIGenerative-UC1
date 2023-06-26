# AIGenerative-UC1

## Description: Use Case #1
This is .NET Core Web Api application that has only one endpoint. 
Endpoint is used to filter countries (supplied by REST API https://restcountries.com/v3.1/all current day call) by population and name. 
There is also sorting enabled and very simple pagination.
User can choose if they want to flter by every parameter or pick only ones that are needed.

## Usage

![image](https://github.com/kpudl/AIGenerative-UC1/assets/136784637/00563298-6a5a-40a8-990b-cc1df1aaf2ca)

call: /api/RestCountries
type: GET
parameters (all optional): 
- country (string) - filter string, fragment of country name we are looking  for (case is not important, search will be conducted no matter what casing is used)
- population (int) - number of milions, which searched country has less then
- SortTypes (enum) - sorting type:  ascend (0) or descend(1)
- records (int) - how many records do we want to display

## Examples

###  #1 - display all
call: https://localhost:44351/api/RestCountries

### #2 - display only one
call: https://localhost:44351/api/RestCountries?records=1

### #3 - display countries with population less then one milion
call: https://localhost:44351/api/RestCountries?population=1

### #4 - display 5 sorted ascending countries by name:
call: https://localhost:44351/api/RestCountries?sortBy=0&records=5

### #5 - display 3 sorted ascending countries that have "Islands" in name:
call: https://localhost:44351/api/RestCountries?country=Islands&sortBy=0&records=3

### #6 - display 2 sorted descending countries that have "Islands" in name:
call: https://localhost:44351/api/RestCountries?country=Islands&sortBy=1&records=2

### #7 - display 5 sorted descending countries that have "ISLANDS" in name with population less then 2 milion:
call: https://localhost:44351/api/RestCountries?country=ISLANDS&population=2&sortBy=1&records=5

### #8 - display last 3 countries, when they are sorted:
call: https://localhost:44351/api/RestCountries?&sortBy=1&records=3

### #9 - display all countries that have "ARR" in name:
call: https://localhost:44351/api/RestCountries?country=ARR

### #10 - display all countries that have population less then 0 milion:
call: https://localhost:44351/api/RestCountries?population=0
