Feature: Genre Resource

@GetGenre
Scenario: Get Genre All
	Given I am a client
	When I make Get Request 'api/Genres/'
	Then  response code must be '200'
	And response data must look like '[{"id":1,"name":"Action"}]'

@GetByGenreId
Scenario Outline: Get By Id of Genre
	Given I am a client
	When I make Get Request with '<Id>' and 'api/Genres/'
	Then response code must be '<status code>'
	Examples: 
	| Id | status code |
	| 1  | 200         |
	| 9  | 404         |

@PostGenre
Scenario Outline: Add an Genre
	Given I am a client
	When I make Post Request with '<Genre>' and 'api/Genres/'
	Then response code must be '<status code>'
	Examples: 
	| Genre               | status code |
	| {"name":"Thriller"} | 201         |
	| {"name":}           | 400         |
	

@UpdateGenre
Scenario Outline: Update an Genre
	Given I am a client
	When I make Update Request with '<Genre>' , '<Id>' and 'api/Genres/'
	Then response code must be '<status code>'
	Examples: 
	| Id | Genre               | status code |
	| 1  | {"name":"Thriller"} | 200         |
	| 1  | {"name":}           | 400         |
	| 2  | {"name":"Thriller"} | 404         |
	

@DeleteGenre
Scenario Outline: Delete an Genre
	Given I am a client
	When I make Delete Request with '<Id>' and 'api/Genres/'
	Then response code must be '<status code>'
	Examples: 
	| Id | status code |
	| 1  | 200         |
	| 2  | 404         |
