# DockingReservation a schedule-able unit of time within a hanger
import datetime
from Hanger import Hanger


class DockingReservation:

    def __init__(self, time, hanger, airport):
        # Reservation status:
        #   0 = reservation open
        #   1 = reservation booked
        self.reservation_status = 0
        self.flight = None
        self.time = time
        self.hanger = hanger
        self.airport = airport

    def print(self):
        pass

    def reserve_dock(self, flight):
        self.flight = flight
        self.reservation_status = 1
