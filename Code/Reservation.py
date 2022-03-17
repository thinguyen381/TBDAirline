import Flight


class Reservation:
    def __init__(self, flight, passenger,
                 reservation_id, price):
        self.flight = flight
        self.passenger = passenger
        self.reservation_id = reservation_id
        self.booking_status = 0
        self.price = price

    def print_reservation(self):
        print('Reservation ID: ' + self.reservation_id)
        self.flight.print_flight()
        print('Price: ' + self.price)
