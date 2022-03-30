# Airline handles and books flights/reservations of flights
from Flight import Flight
from Airport import Airport


class Airline:

    def __init__(self, name):

        self.name = name
        self.num_flights = 0
        self.flights = []

    def create_flight(self, departure, arrival):
        # I think the error in logic has to do with this line arrival.time and departure.time not defined
        # Flight creation does not implement departure/arrival times
        self.flights.append(Flight(self.num_flights, self, departure, 1, arrival, 2, 5))
        self.num_flights += 1

    def print(self):
        print(self.name + ':')
        for flight in self.flights:
            print('\t', end="")
            flight.print()
