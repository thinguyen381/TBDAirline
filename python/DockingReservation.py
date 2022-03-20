# DockingReservation a schedule-able unit of time within a hanger
import datetime


class DockingReservation:

    def __init__(self, time, hanger):
        # Reservation status:
        #   0 = reservation open
        #   1 = reservation booked
        self.reservation_status = 0
        self.flight = None
        self.time = time
        self.hanger = hanger

    def print(self):
        print('Hanger: ' + str(self.hanger.hanger_id) + '\tTime: ' + str(self.time))

    def reserve_dock(self, flight):
        self.flight = flight
        self.reservation_status = 1
