from DockingReservation import DockingReservation


class Hanger:

    def __init__(self, airport, hanger_id):
        self.airport = airport
        self.hanger_id = hanger_id
        self.reservations = []

        # Initializes 24 separate instances of DockingReservation,
        # one for each hour
        for reservation_index in range(23):
            new_reservation = DockingReservation(reservation_index + 1, self)
            self.reservations.append(new_reservation)

    def print_available(self):
        print('Hanger: ' + self.hanger_id)
        for reservation in self.reservations:
            if reservation.reservation_status == 0:
                reservation.print()

    # Prints all DockingReservations
    def print(self):
        print('Hanger: ' + str(self.hanger_id))
        for reservation in self.reservations:
            print('\t', end='')
            reservation.print()
