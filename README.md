# LibrarySystem

A comprehensive library management solution consisting of two integrated applications that share a single SQL Server database:

1. A .NET Framework WinForms desktop application for staff and user operations
2. A .NET Core MVC web application with Razor pages for online library services

## Project Overview

This project demonstrates a complete library management system with distinct interfaces for different user roles while maintaining data consistency through a shared database. The solution showcases:

- Database-first approach using SQL Server
- Entity Framework integration (.NET Framework & Entity Framework Core)
- Multiple UI technologies (WinForms & Razor Pages)
- Role-based access control
- Authentication and authorization (including ASP.NET Identity integration)
- Session management
- Search and filtering capabilities
- Book reservation and borrowing workflows
- Late fee calculation and payment processing

## Applications

### Desktop Application (WinForms)

The .NET Framework Windows Forms application provides a feature-rich desktop interface primarily designed for in-library use:

#### Features

- **User Authentication**: Secure login system with role-based access control
- **Book Management**:
  - Staff and admins can add/remove books from the library catalog
  - All users can search the catalog with category filtering
  - Book borrowing and return processing
- **User Management** (Admin Only):
  - Add/remove user accounts
  - Update user information
  - Block/unblock user accounts
- **Borrowing History**: Users can view their currently borrowed books
- **Late Fee Management**: Users can view and pay overdue fees

### Web Application (MVC with Razor Pages)

The .NET Core MVC application provides an online interface for library services:

#### Features

- **User Authentication**: Integrated with ASP.NET Identity framework
- **Book Catalog**: Browse and search all library books with filtering options
- **Book Reservation**: Reserve books for in-person pickup
- **Account Management**: Users can update their personal information
- **Borrowing History**: View currently borrowed books and history
- **Late Fee Management**: View and pay outstanding late fees

## Technical Architecture

### Database

- SQL Server database (database-first approach)
- Shared between both applications for consistent data

### Desktop Application

- .NET Framework
- Entity Framework for data access
- Windows Forms UI

### Web Application

- .NET Core
- Entity Framework Core
- MVC architecture with Razor pages
- ASP.NET Identity for authentication and authorization
- Session management for user state

## User Roles

The system supports three main user roles:

### Regular Users

- Browse and search books
- Borrow and return books
- Reserve books online
- View personal borrowing history
- Pay late fees
- Update personal information

### Staff

All regular user capabilities, plus:

- Add/remove books from the catalog
- Process returns and borrowings

### Administrators

All staff capabilities, plus:

- Add/remove user accounts
- Block/unblock users
- Modify user information and privileges

## Development Approach

- **Database-First Design**: Created the database schema first, then generated entity models
- **Entity Framework Scaffolding**: Used for the .NET Core project to integrate with the existing database
- **Identity Framework Integration**: Implemented in the .NET Core application for authentication
- **Shared Database Access**: Both applications maintain data consistency through the same database

## Getting Started

### Prerequisites

- Visual Studio 2022 or later
- SQL Server 2019 or later
- .NET Framework 4.8
- .NET Core 6.0 or later

### Setup

1. Clone the repository
2. Open the solution in Visual Studio
3. Update the connection strings in both projects to point to your SQL Server instance
4. Run the database migration scripts located in the `Database` folder
5. Build and run the solution

## Future Enhancements

- Email notifications for due dates and reservations
- Integration with external book databases for catalog enrichment
- Mobile application development
- Advanced reporting features for library analytics
- Online payment gateway integration

## License

This project is licensed under the MIT License - see the LICENSE file for details.
