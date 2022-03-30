import datetime
from Reservation import Reservation
from DockingReservation import DockingReservation


class Flight:
    def __init__(self, flight_id, airline, departure_dock, departure_time, arrival_time, arrival_dock,
                 num_reservations):

        self.flight_id = flight_id
        self.airline = airline

        self.departure_dock = departure_dock
        self.departure_dock.__class__ = DockingReservation
        self.departure_time = departure_time

        self.arrival_dock = arrival_dock
        self.arrival_dock.__class__ = DockingReservation
        self.arrival_time = arrival_time

        self.duration = arrival_dock.time - departure_dock.time

        self.num_reservations = num_reservations
        self.reservations = [Reservation(self, None, reservation)
                             for reservation in range(num_reservations)]

    def print(self):
        print('Flight number ' + str(self.flight_id) +
              " " + self.departure_dock.airport.location + ' to ' +
              self.arrival_dock.airport.location + ' at ')
              #self.arrival_dock.airport.location + ' at ' + str(self.departure_dock.time))
