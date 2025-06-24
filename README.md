# SchoolBookRentalSystem

A comprehensive book rental management solution for Jamaica Elite High School built as a .NET Framework WinForms desktop application with SQL Server database integration.

## Project Overview

This project provides a complete book rental management system specifically designed for Jamaica Elite High School's textbook rental program. The system enables efficient management of textbook inventory, student rentals, and administrative operations through a user-friendly desktop interface.

The solution showcases:

- Database-first approach using SQL Server
- Entity Framework integration for data access
- Windows Forms desktop application
- Role-based access control for different user types
- Student and staff authentication
- Comprehensive rental tracking and management
- Late fee calculation and payment processing
- Inventory management for school textbooks

## Application Features

### Student Authentication & Management

The WinForms application provides secure access control with role-based functionality:

#### Student Features

- **Secure Login**: Student authentication using school credentials
- **Book Catalog**: Browse and search available textbooks by subject, grade level, or title
- **Rental Management**:
  - View currently rented textbooks
  - Check rental due dates
  - Extend rental periods (when permitted)
- **Rental History**: Complete history of all textbook rentals
- **Fee Management**: View and pay outstanding late fees or damage charges
- **Account Information**: Update personal contact details

#### Staff Features

All student capabilities, plus:

- **Book Inventory Management**:
  - Add new textbooks to the rental catalog
  - Update book information and availability
  - Remove damaged or outdated books
- **Rental Processing**:
  - Process new textbook rentals for students
  - Handle book returns and condition assessment
  - Calculate and apply late fees or damage charges
- **Student Account Management**:
  - View student rental histories
  - Process fee payments
  - Generate rental reports

#### Administrator Features

All staff capabilities, plus:

- **User Management**:
  - Add/remove student and staff accounts
  - Update user roles and permissions
  - Block/unblock accounts for policy violations
- **System Administration**:
  - Generate comprehensive reports on rental statistics
  - Manage system settings and policies
  - Oversee fee structures and rental periods
- **Inventory Analytics**:
  - Track book usage patterns
  - Identify popular and underutilized textbooks
  - Generate procurement recommendations

## Technical Architecture

### Database Design

- **SQL Server Database**: Centralized data storage for all rental operations
- **Database-First Approach**: Schema designed to match school rental workflows
- **Key Entities**:
  - Students and Staff (Users)
  - Textbooks and Inventory
  - Rentals and Transactions
  - Fees and Payments

### Desktop Application

- **.NET Framework**: Robust Windows Forms application
- **Entity Framework**: Object-relational mapping for database operations
- **Layered Architecture**: Separation of concerns with data, business, and presentation layers
- **Windows Forms UI**: Intuitive desktop interface optimized for school staff workflows

## User Roles

The system supports three primary user roles within Jamaica Elite High School:

### Students

- Browse available textbooks for their grade level and subjects
- Rent textbooks for academic terms
- Track current rentals and due dates
- View rental history and academic records
- Pay outstanding fees and charges
- Update personal contact information

### Staff (Teachers/Librarians)

All student capabilities, plus:

- Process textbook rentals and returns
- Manage textbook inventory and catalog
- Assess book conditions and apply damage fees
- Generate student rental reports
- Handle fee collection and payment processing

### Administrators (Principal/Vice-Principal)

All staff capabilities, plus:

- Manage user accounts and permissions
- Configure system settings and rental policies
- Generate comprehensive administrative reports
- Oversee financial aspects of the rental program
- Monitor system usage and performance

## School-Specific Features

## Development Approach

- **Database-First Design**: Database schema designed to reflect school rental workflows
- **Entity Framework Integration**: Code-first approach with database migrations
- **Modular Architecture**: Clean separation between data access, business logic, and UI layers
- **User-Centered Design**: Interface designed with feedback from Jamaica Elite High School staff

## Getting Started

### Prerequisites

- Visual Studio 2022 or later
- SQL Server 2019 or later (SQL Server Express acceptable)
- .NET Framework 4.8
- Windows 10 or later

### Installation & Setup

1. **Clone the Repository**

   ```
   git clone [repository-url]
   cd SchoolBookRentalSystem
   ```

2. **Database Setup**

   - Open SQL Server Management Studio
   - Create a new database named `JamaicaEliteBookRentals`
   - Run the database scripts in the `Database/Scripts` folder in order

3. **Application Configuration**

   - Open the solution in Visual Studio
   - Update the connection string in `App.config` to point to your SQL Server instance
   - Build the solution to restore NuGet packages

4. **Initial Data Setup**

   - Run the application as Administrator to create the initial admin account
   - Import student data using the provided CSV import feature
   - Add initial textbook inventory through the admin interface

5. **Deployment**
   - Build in Release mode
   - Deploy to school computers or network shared location
   - Ensure all users have appropriate database access permissions

## System Requirements

### Minimum Requirements

- Windows 10 (64-bit)
- .NET Framework 4.8
- 4 GB RAM
- 500 MB available disk space
- SQL Server 2019 Express (or full version)
- Network connectivity for shared database access

### Recommended Requirements

- Windows 11 (64-bit)
- 8 GB RAM
- 1 GB available disk space
- SQL Server 2022
- Dedicated database server for multi-user scenarios

## Future Enhancements

- **Automated Notifications**: Email/SMS reminders for due dates and overdue books
- **Barcode Integration**: Barcode scanning for quick book identification and processing
- **Mobile Companion App**: Simple mobile app for students to check rental status
- **Advanced Reporting**: Detailed analytics on rental patterns and inventory utilization
- **Digital Integration**: Links to digital versions of textbooks where available
- **Parent Portal**: Allow parents to view their child's rental status and pay fees
- **Integration with School Management System**: Sync with existing student information systems

## Support & Maintenance

For technical support or feature requests, contact the Jamaica Elite High School IT Department or the development team.

## License

This project is proprietary software developed specifically for Jamaica Elite High School. All rights reserved.

---

**Jamaica Elite High School**  
_Excellence in Education_
