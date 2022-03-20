Classes:
	USER PERSON
	Account - Handles Person's login information
	Passenger - Handles Person's account, personal information and collects user's reservation(s)
	
	USER AIRLINE
	Reservation - single unit Reservation created by Flight held by USER PERSON. 
		booking status = 0 - reservation available
		booking status = 1 - reservation unavailable
	Flight - handles Reservations hold DockingReservation for departing and arriving 
	Airline - handles flights, matches Flights with Airports
	
	USER AIRPORT
	DockingReservation - singular unit Reservation of time
	Hanger - handles DockingReservations
	Airport - Handles Hangers

	#TODO:
	implement proper datetime across project.
	finish writing print statements.
	write up a test main.
	project wide error handling.

    I will re-create UML and Use Case Diagrams once I can confirm that the objects are in a proper status.