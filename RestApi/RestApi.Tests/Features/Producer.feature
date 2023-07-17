Feature: Producer Resource

@GetProducer
Scenario: Get Producer All
	Given I am a client
	When I make Get Request 'api/Producers/'
	Then  response code must be '200'
	And response data must look like '[{"id":1,"name":"S.S. Rajamouli","bio":"S.S. Rajamouli is an Indian film director and screenwriter who primarily works in Telugu cinema and is known for his action, fantasy, and epic genre films. He is the highest grossing Indian director of all time and the highest-paid director in India. ","dateOfBirth":"1973-10-20T00:00:00","gender":"Male"}]'
@GetByProducerId
Scenario Outline: Get By Id of Producer
	Given I am a client
	When I make Get Request with '<Id>' and 'api/Producers/'
	Then response code must be '<status code>'
	Examples: 
	| Id | status code |
	| 1  | 200         |
	| 9  | 404         |

@PostProducer
Scenario Outline: Add an Producer
	Given I am a client
	When I make Post Request with '<Producer>' and 'api/Producers/'
	Then response code must be '<status code>'
	Examples: 
	| Producer                                                                                                                                                                                                                                                                 | status code |
	| { "name": "James Cameron", "bio": "James Cameron is a Canadian filmmaker, director, producer, screenwriter, and environmentalist. He is known for directing the films Titanic, Avatar, and Terminator 2: Judgment Day.", "dateOfBirth": "1954-08-16", "gender": "Male" } | 201         |
	| {"name": , "bio": "James Cameron is a Canadian filmmaker, director, producer, screenwriter, and environmentalist. He is known for directing the films Titanic, Avatar, and Terminator 2: Judgment Day.", "dateOfBirth": "1954-08-16", "gender": "Male" }                 | 400         |
	| {"name": "James Cameron", "bio": , "dateOfBirth": "1954-08-16", "gender": "Male" }                                                                                                                                                                                       | 400         |
	| {"name": "James Cameron", "bio": "James Cameron is a Canadian filmmaker, director, producer, screenwriter, and environmentalist. He is known for directing the films Titanic, Avatar, and Terminator 2: Judgment Day.", "dateOfBirth": , "gender": "Male" }              | 400         |
	| {"name": "James Cameron", "bio": "James Cameron is a Canadian filmmaker, director, producer, screenwriter, and environmentalist. He is known for directing the films Titanic, Avatar, and Terminator 2: Judgment Day.", "dateOfBirth": "1954-08-16", "gender":  }        | 400         |
	

@UpdateProducer
Scenario Outline: Update an Producer
	Given I am a client
	When I make Update Request with '<Producer>' , '<Id>' and 'api/Producers/'
	Then response code must be '<status code>'
	Examples: 
	| Id | Producer                                                                                                                                                                                                                                                                | status code |
	| 1  | {"name": "James Cameron", "bio": "James Cameron is a Canadian filmmaker, director, producer, screenwriter, and environmentalist. He is known for directing the films Titanic, Avatar, and Terminator 2: Judgment Day.", "dateOfBirth": "1955-08-16", "gender": "Male" } | 200         |
	| 1  | {"name": , "bio": "James Cameron is a Canadian filmmaker, director, producer, screenwriter, and environmentalist. He is known for directing the films Titanic, Avatar, and Terminator 2: Judgment Day.", "dateOfBirth": "1955-08-16", "gender": "Male" }                | 400         |
	| 1  | {name": "James Cameron", "bio": , "dateOfBirth": "1955-08-16", "gender": "Male" }                                                                                                                                                                                       | 400         |
	| 1  | {name": "James Cameron", "bio": "James Cameron is a Canadian filmmaker, director, producer, screenwriter, and environmentalist. He is known for directing the films Titanic, Avatar, and Terminator 2: Judgment Day.", "dateOfBirth": , "gender": "Male" }              | 400         |
	| 1  | {"name": "James Cameron", "bio": "James Cameron is a Canadian filmmaker, director, producer, screenwriter, and environmentalist. He is known for directing the films Titanic, Avatar, and Terminator 2: Judgment Day.", "dateOfBirth": "1955-08-16", "gender":  }       | 400         |
	| 2  | {"name": "James Cameron", "bio": "James Cameron is a Canadian filmmaker, director, producer, screenwriter, and environmentalist. He is known for directing the films Titanic, Avatar, and Terminator 2: Judgment Day.", "dateOfBirth": "1955-08-16", "gender": "Male" } | 404         |
	
@DeleteProducer
Scenario Outline: Delete an Producer
	Given I am a client
	When I make Delete Request with '<Id>' and 'api/Producers/'
	Then response code must be '<status code>'
	Examples: 
	| Id | status code |
	| 1  | 200         |
	| 9  | 404         |
