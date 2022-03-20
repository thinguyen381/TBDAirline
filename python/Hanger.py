from DockingReservation import DockingReservation


class Hanger:

    def __init__(self, airport, hanger):
        self.airport = airport
        self.reservations

        # Initializes 24 separate instances of DockingReservation,
        # one for each hour
        for reservation_index in range(24):
            new_reservation = DockingReservation(reservation_index, hanger, airport)
            self.reservations.append(new_reservation)

    def print_available(self):
        for reservation in self.reservations:
            if reservation.reservation_status == 0:
                reservation.print()

    # Prints all DockingReservations
    def print(self):
        pass
