Feature: Movie Resource

@GetMovie
Scenario: Get All Movies
	Given I am a client
	When I make Get Request 'api/Movies/'
	Then  response code must be '200'
	And response data must look like '[{"id":1,"name":"Avatar","yearOfRelease":"2009-05-22T00:00:00","plot":"A paralyzed former Marine joins the Avatar Program, a project that allows humans to remotely control genetically engineered  bodies, in order to infiltrate  and stop the RDA corporation from mining a valuable mineral on their planet.","actors":[{"id":2,"name":"Will Smith","bio":"Steve Rogers, a scrawny but patriotic young man who is given super-soldier serum and becomes Captain America","dateOfBirth":"1976-06-13T00:00:00","gender":"Male"}],"genres":[{"id":1,"name":"Action"}],"producer":{"id":1,"name":"S.S. Rajamouli","bio":"S.S. Rajamouli is an Indian film director and screenwriter who primarily works in Telugu cinema and is known for his action, fantasy, and epic genre films. He is the highest grossing Indian director of all time and the highest-paid director in India. ","dateOfBirth":"1973-10-20T00:00:00","gender":"Male"},"poster":"C:\\Users\\Kalyan\\Downloads\\Avatar.png"}]'

@GetByMovieId
Scenario Outline: Get By Id of Movie
	Given I am a client
	When I make Get Request with '<Id>' and 'api/Movies/'
	Then response code must be '<status code>'
	Examples: 
	| Id | status code |
	| 1  | 200         |
	| 9  | 400         |

@PostMovie
Scenario Outline: Add a Movie
	Given I am a client
	When I make Post Request with '<Movie>' and 'api/Movies/'
	Then response code must be '<status code>'
	Examples: 
	| Movie                                                                                                                                                                                                                                                                                                                                                                                                   | status code |
	| {"Name":"Bahubali","YearOfRelease":"2009-05-22T00:00:00","Plot":"A paralyzed former Marine joins the Avatar Program, a project that allows humans to remotely control genetically engineered  bodies, in order to infiltrate and stop the RDA corporation from mining a valuable mineral on their planet.","Actors":"1","Genres":"1","ProducerId":1,"Poster":"C://Users/Kalyan/Downloads/Bahubali.png"} | 201         |
	| {"name":,"yearOfRelease":"2009-05-22T00:00:00","plot":"A paralyzed former Marine joins the Avatar Program, a project that allows humans to remotely control genetically engineered  bodies, in order to infiltrate and stop the RDA corporation from mining a valuable mineral on their planet.","actors":"1","genres":"1","producer":1,"poster":"C://Users/Kalyan/Downloads/Bahubali.png"}           | 400         |
	| {"name":"Bahubali","yearOfRelease":,"plot":"A paralyzed former Marine joins the Avatar Program, a project that allows humans to remotely control genetically engineered  bodies, in order to infiltrate and stop the RDA corporation from mining a valuable mineral on their planet.","actors":"1","genres":"1","producer":1,"poster":"C://Users/Kalyan/Downloads/Bahubali.png"}                      | 400         |
	| {"name":"Bahubali","yearOfRelease":"2009-05-22T00:00:00","plot":,"actors":"1","genres":"1","producer":1,"poster":"C://Users/Kalyan/Downloads/Bahubali.png"}                                                                                                                                                                                                                                           | 400         |
	| {"name":"Bahubali","yearOfRelease":"2009-05-22T00:00:00","plot":"A paralyzed former Marine joins the Avatar Program, a project that allows humans to remotely control genetically engineered  bodies, in order to infiltrate and stop the RDA corporation from mining a valuable mineral on their planet.","actors":"1","genres":"1","producer":1,"poster":}                                          | 400         |
	| {"name":"Bahubali","yearOfRelease":"2009-05-22T00:00:00","plot":"A paralyzed former Marine joins the Avatar Program, a project that allows humans to remotely control genetically engineered  bodies, in order to infiltrate and stop the RDA corporation from mining a valuable mineral on their planet.","actors":"1","genres":"1","producer":,"poster":"C://Users/Kalyan/Downloads/Bahubali.png"}  | 400         |
	| {"name":"Bahubali","yearOfRelease":"2009-05-22T00:00:00","plot":"A paralyzed former Marine joins the Avatar Program, a project that allows humans to remotely control genetically engineered  bodies, in order to infiltrate and stop the RDA corporation from mining a valuable mineral on their planet.","actors":"1","genres":,"producer":1,"poster":"C://Users/Kalyan/Downloads/Bahubali.png"}    | 400         |
	| {"name":"Bahubali","yearOfRelease":"2009-05-22T00:00:00","plot":"A paralyzed former Marine joins the Avatar Program, a project that allows humans to remotely control genetically engineered  bodies, in order to infiltrate and stop the RDA corporation from mining a valuable mineral on their planet.","actors":,"genres":"1","producer":1,"poster":"C://Users/Kalyan/Downloads/Bahubali.png"}    | 400         |

@UpdateMovie
Scenario Outline: Update a Movie
	Given I am a client
	When I make Update Request with '<Movie>' , '<Id>' and 'api/Movies/'
	Then response code must be '<status code>'
	Examples: 
	| Id | Movie                                                                                                                                                                                                                                                                                                                                                                                                         | status code |
	| 1  | {"Name":"Bahubali","YearOfRelease":"2009-05-22T00:00:00","Plot":"A paralyzed former Marine joins the Avatar Program, a project that allows humans to remotely control genetically engineered  bodies, in order to infiltrate and stop the RDA corporation from mining a valuable mineral on their planet.","Actors":"1","Genres":"1","ProducerId":1,"Poster":"C://Users/Kalyan/Downloads/Bahubali.png"} | 200         |
	| 1  | {"name":,"yearOfRelease":"2009-05-22T00:00:00","plot":"A paralyzed former Marine joins the Avatar Program, a project that allows humans to remotely control genetically engineered  bodies, in order to infiltrate and stop the RDA corporation from mining a valuable mineral on their planet.","actors":"1","genres":"1","producer":1,"poster":"C://Users/Kalyan/Downloads/Bahubali.png"}                   | 400         |
	| 1  | {"name":"Bahubali","yearOfRelease":,"plot":"A paralyzed former Marine joins the Avatar Program, a project that allows humans to remotely control genetically engineered  bodies, in order to infiltrate and stop the RDA corporation from mining a valuable mineral on their planet.","actors":"1","genres":"1","producer":1,"poster":"C://Users/Kalyan/Downloads/Bahubali.png"}                              | 400         |
	| 1  | {"name":"Bahubali","yearOfRelease":"2009-05-22T00:00:00","plot":,"actors":"1","genres":"1","producer":1,"poster":"C://Users/Kalyan/Downloads/Bahubali.png"}                                                                                                                                                                                                                                                   | 400         |
	| 1  | {"name":"Bahubali","yearOfRelease":"2009-05-22T00:00:00","plot":"A paralyzed former Marine joins the Avatar Program, a project that allows humans to remotely control genetically engineered  bodies, in order to infiltrate and stop the RDA corporation from mining a valuable mineral on their planet.","actors":"1","genres":"1","producer":1,"poster":}                                                  | 400         |
	| 1  | {"name":"Bahubali","yearOfRelease":"2009-05-22T00:00:00","plot":"A paralyzed former Marine joins the Avatar Program, a project that allows humans to remotely control genetically engineered  bodies, in order to infiltrate and stop the RDA corporation from mining a valuable mineral on their planet.","actors":"1","genres":"1","producer":,"poster":"C://Users/Kalyan/Downloads/Bahubali.png"}          | 400         |
	| 1  | {"name":"Bahubali","yearOfRelease":"2009-05-22T00:00:00","plot":"A paralyzed former Marine joins the Avatar Program, a project that allows humans to remotely control genetically engineered  bodies, in order to infiltrate and stop the RDA corporation from mining a valuable mineral on their planet.","actors":"1","genres":,"producer":1,"poster":"C://Users/Kalyan/Downloads/Bahubali.png"}            | 400         |
	| 9  | {"name":"Bahubali","yearOfRelease":"2009-05-22T00:00:00","plot":"A paralyzed former Marine joins the Avatar Program, a project that allows humans to remotely control genetically engineered  bodies, in order to infiltrate and stop the RDA corporation from mining a valuable mineral on their planet.","actors":"1","genres":"1","producer":1,"poster":"C://Users/Kalyan/Downloads/Bahubali.png"}         | 400         |

@DeleteMovie
Scenario Outline: Delete a Movie
	Given I am a client
	When I make Delete Request with '<Id>' and 'api/Movies/'
	Then response code must be '<status code>'
	Examples: 
	| Id | status code |
	| 1  | 200         |
	| 9  | 400         |
