Feature: Actor Resource

@GetActor
Scenario: Get Actor All
	Given I am a client
	When I make Get Request 'api/Actors/'
	Then  response code must be '200'
	And response data must look like '[{"id":1,"name":"Robert Brown Junior","bio":"Robert Brown Junior is a renowned American actor known for his iconic portrayal of Tony Stark, also known as Iron Man, in the Marvel Cinematic Universe.","dateOfBirth":"1965-04-04T00:00:00","gender":"Male"},{"id":2,"name":"Will Smith","bio":"Steve Rogers, a scrawny but patriotic young man who is given super-soldier serum and becomes Captain America","dateOfBirth":"1976-06-13T00:00:00","gender":"Male"},{"id":3,"name":"Chris Hemsworth","bio":"Thor, the Asgardian god of thunder","dateOfBirth":"1983-08-13T00:00:00","gender":"Male"}]'

@GetByActorId
Scenario Outline: Get By Id of Actor
	Given I am a client
	When I make Get Request with '<Id>' and 'api/Actors/'
	Then response code must be '<status code>'
	Examples: 
	| Id | status code |
	| 1  | 200         |
	| 9  | 404        |

@PostActor
Scenario Outline: Add an Actor
	Given I am a client
	When I make Post Request with '<Actor>' and 'api/Actors/'
	Then response code must be '<status code>'
	Examples: 
	| Actor                                                                                                                                                                                                                                      | status code |
	| {"name":"Robert Brown Junior","bio":"Robert Brown Junior is renowned American actor known for his iconic portrayal of Tony Stark, also known as Iron Man, in the Marvel Cinematic Universe.","dateOfBirth":"1965-04-04","gender":"Male"} | 201         |
	| {"name":,"bio":"Robert Brown Junior is a renowned American actor known for his iconic portrayal of Tony Stark, also known as Iron Man, in the Marvel Cinematic Universe.","dateOfBirth":"1965-04-04","gender":"Male"}                      | 400         |
	| {"name":"Robert Brown Junior","bio":,"dateOfBirth":"1965-04-04T00:00:00","gender":"Male"}                                                                                                                                                  | 400         |
	| {"name":"Robert Brown Junior","bio":"Robert Brown Junior is a renowned American actor known for his iconic portrayal of Tony Stark, also known as Iron Man, in the Marvel Cinematic Universe.","dateOfBirth":,"gender":"Male"}             | 400         |
	| {"name":"Robert Brown Junior","bio":"Robert Brown Junior is a renowned American actor known for his iconic portrayal of Tony Stark, also known as Iron Man, in the Marvel Cinematic Universe.","dateOfBirth":"1965-04-04","gender":}       | 400         |

@UpdateActor
Scenario Outline: Update an Actor
	Given I am a client
	When I make Update Request with '<Actor>' , '<Id>' and 'api/Actors/'
	Then response code must be '<status code>'
	Examples: 
	| Id | Actor                                                                                                                                                                                                                                               | status code |
	| 1  | {"name":"Robert Brown Junior","bio":"Robert Brown Junior is a renowned American actor known for his iconic portrayal of Tony Stark, also known as Iron Man, in the Marvel Cinematic Universe.","dateOfBirth":"1985-04-04T00:00:00","gender":"Male"} | 200         |
	| 1  | {"name":"","bio":"Robert Brown Junior is a renowned American actor known for his iconic portrayal of Tony Stark, also known as Iron Man, in the Marvel Cinematic Universe.","dateOfBirth":"1965-04-04T00:00:00","gender":"Male"}                    | 400         |
	| 1  | {"name":"Robert Brown Junior","bio":,"dateOfBirth":"1965-04-04T00:00:00","gender":"Male"}                                                                                                                                                           | 400         |
	| 1  | {"name":"Robert Brown Junior","bio":"Robert Brown Junior is a renowned American actor known for his iconic portrayal of Tony Stark, also known as Iron Man, in the Marvel Cinematic Universe.","dateOfBirth":"","gender":"Male"}                    | 400         |
	| 1  | {"name":"Robert Brown Junior","bio":"Robert Brown Junior is a renowned American actor known for his iconic portrayal of Tony Stark, also known as Iron Man, in the Marvel Cinematic Universe.","dateOfBirth":"1965-04-04T00:00:00","gender":}       | 400         |

	| 9  | {"name":"Robert Brown Junior","bio":"Robert Brown Junior is a renowned American actor known for his iconic portrayal of Tony Stark, also known as Iron Man, in the Marvel Cinematic Universe.","dateOfBirth":"1985-04-04T00:00:00","gender":"Male"} | 404         |

@DeleteActor
Scenario Outline: Delete an Actor
	Given I am a client
	When I make Delete Request with '<Id>' and 'api/Actors/'
	Then response code must be '<status code>'
	Examples: 
	| Id | status code |
	| 1  | 200         |
	| 9  | 404         |
