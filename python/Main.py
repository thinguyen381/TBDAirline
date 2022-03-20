from Account import Account
from Airport import Airport
from Airline import Airline
from Passenger import Passenger


def main():

    # Passenger Build
    my_account = Account('myEmail@emails.com', 'thisIsNotMyPassword')
    codi_yost = Passenger(my_account, 'Codi', 'Yost', '661-435-8231')
    codi_yost.print()

    # Airport Build
    my_airport = Airport('Krynn')
    my_airport.create_hanger()
    my_airport.print()

    that_airport = Airport('Middle Earth')
    that_airport.create_hanger()
    that_airport.print()

    # Airline build
    TBDAirline = Airline('TBDAirline')
    TBDAirline.create_flight(my_airport.hangers[0], that_airport.hangers[0])
    TBDAirline.print()

    codi_yost.book_reservation(TBDAirline.flights[0].reservations[0])
    codi_yost.print()

main()
