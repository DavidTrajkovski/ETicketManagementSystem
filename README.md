# ETicketManagementSystem
My individual project in C# in asp.net core for my course Integrated Systems at FCSE coded in Onion Architecture.

**Description:** This app is something like an e-shop for movie tickets and management system for orders and payments.
These are some of the features it has:
- User sign up and login;
- CRUD operations for tickets;
- View for all tickets in a responsive grid;
- Option to filter tickets on a specific date;
- Adding tickets with quantity in a shopping cart and a view of the cart and option to make an order and a payment as well.
The user receives an e-mail with status and description of his order. 
The mailing process was done using a background worker and a MailKit library and the payment was configured using Stripe;
- Every user has a view of his orders and can generate a PDF document for a detailed view of a specific order
This was done using a GemBox library;
- The administrator can export all tickets into excel file with an option to filter the tickets based on the movie genre.
This was done using the ClosedXML library;
- The administrator can import users from an excel file. This was done using the ExcelDataReader library;
