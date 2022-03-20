import datetime
from Reservation import Reservation


class Flight:
    def __init__(self, flight_id, airline, departure_dock, arrival_dock,
                 num_reservations):
        self.flight_id = flight_id
        self.airline = airline
        self.departure_dock = departure_dock
        self.arrival_dock = arrival_dock
        self.duration = arrival_dock.time - departure_dock.time
        self.num_reservations = num_reservations
        self.reservations = [Reservation(self, None, reservation, 10)
                             for reservation in range(num_reservations)]

    def print(self):
        print('Flight number ' + str(self.flight_id) +
              " " + self.departure_dock.airport + ' to ' +
              self.arrival_dock.airport + ' at ' + str(self.departure_dock.time))
