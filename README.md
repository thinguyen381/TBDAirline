# TBDAirline

Flight reservation system for CSUN COMP 380 Into To Software Engineering Spring 2022

What is working?
  Search Controller
  Book Controlller
  Home Controller

Known errors:
  Account Controller - writing account into db
  Account not staying logged in...


Contributers:
  Codi Yost
  Thi Nguyen
  Christopher Olivio
  Hector Torres
  
  
*** Updated Apr 4: 
    
   What is working?
          Search Controller
          Book Controlller
          Home Controller
          Account Controller (Account and Register pages)
   
   Next tasks?
          Payment Controller
          Reservation Controller
   
   Notes:
          The current flow can be adjusted later because for now I want to make it easiest to implement
          A simple image was added as background
          A working version of the website has been published at http://tbdairline.azurewebsites.net
          (If you go to the website, try searh for flights, register and log in. You would be stopped at Payment page as I have not implemented it yet)
  
  Currrent flow:  
          Search for flights - Select flights - Confirm booking flights -
          Log in (if account has already existed) or Register a new account then Log in -
          Payment - Reservation confirmed
   
 *** Updated Apr 12:
What are working? - Search Controller,  Book Controlller,    Home Controller,     Account Controller,  Payment Controller,   Reservation Controller

What is next? - Report Controller (will receive a FlightID then show a list of passenger in that flight) 

I also added 1 more controller which is Tracking Controller. It does a simple task that receives tracking number and shows reservation's infomation.

Notes: You can try the published website if you can't launch it from the Visual studio.

*** Updated Apr 13:

TODO:

  Account info page:
    Account info page needs to show flights account has reserved
    options to cancal a reservation. 
    Manage account info.
    BONUS ** History of Orders **

  Make dates that are not possible unselectable
    departing flight cannot be scheduled for any date passed today
    returning flight / arrival flight date and time cannot happen before departing

  Error Handling
    Clicking book without selecting flights causes a crash
    clicking search without search paramaters full causes a crash
    Can select times that shouldn't be selectable
    selecting ONLY a departing flight causes a crash
    selecting ONLY a return flight causes a crash
    incorrect tracking needs a user notice
  
  Adding round trip/one way option to flight schedule
    one way flight will not show a return flight.
