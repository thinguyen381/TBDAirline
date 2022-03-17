import Account
import Flight
import Passenger


def main():
    my_account = Account('myEmail@emails.com','thisIsNotMyPassword')
    codi_yost = Passenger(my_account, 'Codi', 'Yost', '661-435-8231')
    my_flight = Flight(1, 'Los Angeles','Sacramento', 1, 2, 20)
    codi_yost.book_reservation(my_flight.reservations[0])

    codi_yost.print_passenger()


main()
