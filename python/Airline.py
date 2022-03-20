# Airline handles and books flights/reservations of flights
from Flight import Flight
from Airport import Airport


class Airline:

    def __init__(self, name):

        self.name = name
        self.num_flights = 0
        self.flights = []

    def create_flight(self, departure, arrival):

        self.flights.append(Flight(self.num_flights, self, departure, arrival, 5))
        self.num_flights += 1

    def print(self):
        print(self.name + ':')
        for flight in self.flights:
            print('\t', end="")
            flight.print()
