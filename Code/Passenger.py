import Account
import Reservation


class Passenger:
    def __init__(self, passenger_account, first_name,
                 last_name, phone_number):
        self.passenger_account = passenger_account
        self.first_name = first_name
        self.last_name = last_name
        self.phone_number = phone_number

        self.num_reservations = 0
        self.reservations = None

    def print_passenger(self):
        print("" + self.first_name + " " + self.last_name + "\n" +
              'Phone Number: ' + self.phone_number + '\n' +
              'Email: ' + self.passenger_account.email + '' + '\n' +
              self.num_reservations + 'Reservations:\n')

        for reservation in self.reservations:
            self.reservations[reservation].print_reservation
            print('\n')

    def book_reservation(self, reservation):
        if reservation.booking_status == 0:
            self.reservations[self.num_reservations] = reservation
            reservation.booking_status = 1
            self.num_reservations += 1
        else:
            pass
