from DockingReservation import DockingReservation


class Hanger:

    def __init__(self, hanger):
        self.reservations

        # Initializes 24 separate instances of DockingReservation,
        # one for each hour
        for reservation_index in range(24):
            new_reservation = DockingReservation(reservation_index, hanger)
            self.reservations.append(new_reservation)
            