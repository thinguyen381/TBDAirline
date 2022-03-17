import Reservation


class Flight:
    def __init__(self, flight_id, departure, arrival,
                 departure_time, arrival_time, num_reservations):
        self.flight_id = flight_id
        self.departure_airport = departure
        self.arrival_airport = arrival
        self.departure_time = departure_time
        self.arrival_time = arrival_time
        self.duration = arrival_time - departure_time
        self.num_reservations = num_reservations
        self.reservations = [Reservation(self, None, reservation, 10)
                             for reservation in range(num_reservations)]

        def print_flight():
            pass
