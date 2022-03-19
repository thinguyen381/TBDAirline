# Airline handles and books flights/reservations of flights
from Flight import Flight
from Airport import Airport


class Airline:

    def __init__(self, name):

        self.name = name
        self.flights = None

    def create_flight(self, departure, arrival):

        self.flights.append(self.flights.length - 1, departure, arrival)