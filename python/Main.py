from Account import Account
from Flight import Flight
from Passenger import Passenger


def main():
    my_account = Account('myEmail@emails.com', 'thisIsNotMyPassword')
    codi_yost = Passenger(my_account, 'Codi', 'Yost', '661-435-8231')

    codi_yost.print_passenger()


main()
