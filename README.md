Overview :
The Library Management System is an ASP.NET Core web application designed to manage library operations such as adding, editing, deleting books 
and users, issuing and returning books, and searching for available books. This application is built using the MVC architecture, Entity Framework Core, and is backed by a SQL database.

Features:

User Management:

Add new users
Edit user details
Delete users
List all users.


Book Management:

Add new books
Edit book details
Delete books
List all books
Search for books by title, author, or ISBN



Book Issuing Management:

Issue books to users
Return books


Technologies Used
ASP.NET Core
Entity Framework Core
SSMS
Razor Pages for Views
Bootstrap for styling

Functionality Overview:
User Management:
List Users: The home page displays all users in the system.
Add User: Use the "Add New User" button to add a new user to the system. Fill in the required details and click save.
Edit User: Click on a user to edit their information. Make the necessary changes and save.
Delete User: Click on the delete button next to a user to remove them from the system. Confirm deletion on the prompt.

Book Management:
List Books: The books page displays all books in the library.
Add Book: Use the "Add New Book" button to add a new book to the system. Fill in the required details and click save.
Edit Book: Click on a book to edit its information. Make the necessary changes and save.
Delete Book: Click on the delete button next to a book to remove it from the library. Confirm deletion on the prompt.
Search Books: Use the search functionality to find books by title, author, or ISBN.

Book Issuing Management:
Issue Book: Select a user and a book to issue the book. This action will record the issue date and set the due date for returning the book.
Return Book: Users can return issued books, which updates the record in the database.
