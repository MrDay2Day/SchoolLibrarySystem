--

-- Create Database
CREATE DATABASE Library_System;
GO

-- Use Database
USE Library_System;
GO

-- ###############################################################
--		TABLES
-- ###############################################################

-- Create Tables
CREATE TABLE Users (
    User_id INT IDENTITY(1,1) PRIMARY KEY,
    First_name NVARCHAR(250) NOT NULL,
    Last_name NVARCHAR(250) NOT NULL,
    Email NVARCHAR(250) UNIQUE NOT NULL,
    Phone NVARCHAR(11),
    Type NVARCHAR(50) NOT NULL CHECK (Type IN ('STAFF', 'USER', 'ADMIN')) DEFAULT 'USER',
    Password NVARCHAR(250) NOT NULL,
	Blocked BIT NOT NULL DEFAULT 0,
    --
    created_at DATETIME2 DEFAULT GETDATE() NOT NULL,
    updated_at DATETIME2 DEFAULT GETDATE() NOT NULL
);
INSERT INTO Users(First_name, Last_name, email, password)
VALUES('Administrator', 'Admin', 'admin@email.com', '5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8');
GO

CREATE TABLE Books (
    Book_id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(255) NOT NULL,
    Description NVARCHAR(500) NOT NULL,
    Author NVARCHAR(255) NOT NULL,
    PublishedYear INT,
    Available BIT NOT NULL DEFAULT 1,
    --
    created_at DATETIME2 DEFAULT GETDATE() NOT NULL,
    updated_at DATETIME2 DEFAULT GETDATE() NOT NULL
);
CREATE INDEX IX_Book_Name ON Books (Title);
GO

CREATE TABLE Borrows (
	Borrow_id INT IDENTITY(1,1) PRIMARY KEY,
	Book_id INT NOT NULL,
	User_id INT NOT NULL,
	Borrow_date DATETIME2 DEFAULT GETDATE() NOT NULL,
	Schedule_return_date DATETIME2 DEFAULT GETDATE() NOT NULL,
	Actual_return_date DATETIME2 NULL,
	--
    created_at DATETIME2 DEFAULT GETDATE() NOT NULL,
    updated_at DATETIME2 DEFAULT GETDATE() NOT NULL,
	--
	FOREIGN KEY (User_id) REFERENCES Users(User_id) ON DELETE CASCADE,
	FOREIGN KEY (Book_id) REFERENCES Books(Book_id) ON DELETE CASCADE
);
GO

-- Create after book is returned only if 'Actual_return_date' is greater than 'Schedule_return_date'
CREATE TABLE LateFeePayments (
	Payment_id INT IDENTITY(1,1) PRIMARY KEY,
	Borrow_id INT NOT NULL,
	Amount DECIMAL(18,2) NOT NULL,
	Paid BIT NOT NULL DEFAULT 0,
	--
    created_at DATETIME2 DEFAULT GETDATE() NOT NULL,
    updated_at DATETIME2 DEFAULT GETDATE() NOT NULL,
	--
	FOREIGN KEY (Borrow_id) REFERENCES Borrows(Borrow_id) ON DELETE CASCADE
);
GO

-- ###############################################################
--		TRIGGERS
-- ###############################################################

-- Trigger for Users table
CREATE TRIGGER trg_UpdateUsers_Timestamp
ON Users
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Users 
    SET updated_at = GETDATE() 
    WHERE User_id IN (SELECT DISTINCT User_id FROM inserted);
END;
GO

-- Trigger for Books table
CREATE TRIGGER trg_UpdateBooks_Timestamp
ON Books
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Books 
    SET updated_at = GETDATE() 
    WHERE Book_id IN (SELECT DISTINCT Book_id FROM inserted);
END;
GO

-- Trigger for Borrows table
CREATE TRIGGER trg_UpdateBorrows_Timestamp
ON Borrows
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Borrows 
    SET updated_at = GETDATE() 
    WHERE Borrow_id IN (SELECT DISTINCT Borrow_id FROM inserted);
END;
GO

-- Trigger for LateFeePayments table
CREATE TRIGGER trg_UpdateLateFeePayments_Timestamp
ON LateFeePayments
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE LateFeePayments 
    SET updated_at = GETDATE() 
    WHERE Payment_id IN (SELECT DISTINCT Payment_id FROM inserted);
END;
GO

-- ###############################################################
--		PROCEDURES
-- ###############################################################

-- Query Books
CREATE OR ALTER PROCEDURE sp_FetchBooks
    @page_number INT = 1,
    @is_available INT = 1, -- 1: All, 2: Available Only, 3: Not Available
    @search_text NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Validate parameters
    IF @page_number < 1 SET @page_number = 1
    IF @is_available NOT IN (1, 2, 3) SET @is_available = 1
    
    -- Define page size
    DECLARE @page_size INT = 50
    DECLARE @offset INT = (@page_number - 1) * @page_size
    
    -- Prepare search text for LIKE query
    DECLARE @search_pattern NVARCHAR(258)
    IF @search_text IS NOT NULL
        SET @search_pattern = '%' + @search_text + '%'
    
    -- Create temp table to store filtered results
    CREATE TABLE #FilteredBooks (
        Book_id INT,
        Title NVARCHAR(255),
        Description NVARCHAR(500),
        Author NVARCHAR(255),
        PublishedYear INT,
        Available BIT,
        Borrow_id INT,
        Borrow_date DATETIME2,
        Schedule_return_date DATETIME2,
        Borrower_Name NVARCHAR(501),
        SearchRank INT
    )

    -- Insert filtered results into temp table
    INSERT INTO #FilteredBooks
    SELECT 
        b.Book_id,
        b.Title,
        b.Description,
        b.Author,
        b.PublishedYear,
        b.Available,
        br.Borrow_id,
        br.Borrow_date,
        br.Schedule_return_date,
        u.First_name + ' ' + u.Last_name AS Borrower_Name,
        -- Calculate search rank based on where the match is found
        CASE 
            WHEN @search_text IS NULL THEN 1
            ELSE (
                CASE WHEN b.Title LIKE @search_pattern THEN 3 ELSE 0 END +
                CASE WHEN b.Author LIKE @search_pattern THEN 2 ELSE 0 END +
                CASE WHEN b.Description LIKE @search_pattern THEN 1 ELSE 0 END
            )
        END AS SearchRank
    FROM 
        Books b
        LEFT JOIN Borrows br ON b.Book_id = br.Book_id 
            AND br.Actual_return_date IS NULL -- Only get current borrow if exists
        LEFT JOIN Users u ON br.User_id = u.User_id
    WHERE 
        (@search_text IS NULL OR 
         b.Title LIKE @search_pattern OR 
         b.Author LIKE @search_pattern OR 
         b.Description LIKE @search_pattern)
        AND
        (@is_available = 1 OR 
         (@is_available = 2 AND b.Available = 1) OR 
         (@is_available = 3 AND b.Available = 0))

    -- Get counts for different categories
    SELECT
        (SELECT COUNT(*) FROM #FilteredBooks) AS TotalFilteredCount,
        (SELECT COUNT(*) FROM Books) AS TotalBooksCount,
        (SELECT COUNT(*) FROM Books WHERE Available = 1) AS AvailableBooksCount,
        (SELECT COUNT(*) FROM Books WHERE Available = 0) AS BorrowedBooksCount
    
    -- Return paginated results
    SELECT 
        Book_id,
        Title,
        Description,
        Author,
        PublishedYear,
        Available,
        Borrow_id,
        Borrow_date,
        Schedule_return_date,
        Borrower_Name
    FROM 
        #FilteredBooks
    ORDER BY 
        SearchRank DESC, -- Higher ranked matches appear first
        Title ASC -- Then alphabetically by title
    OFFSET @offset ROWS
    FETCH NEXT @page_size ROWS ONLY

    -- Clean up
    DROP TABLE #FilteredBooks
END;
--EXEC sp_FetchBooks @page_number = 1, @is_available = 1, @search_text = NULL
--GO
GO

CREATE PROCEDURE sp_FetchBooks_Simple
    @is_available INT = 1, -- 1: All, 2: Available Only, 3: Not Available
    @search_text NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Validate parameters
    IF @is_available NOT IN (1, 2, 3) SET @is_available = 1
    
    
    -- Prepare search text for LIKE query
    DECLARE @search_pattern NVARCHAR(258)
    IF @search_text IS NOT NULL
        SET @search_pattern = '%' + @search_text + '%'
    
    -- Main query with CTE to handle ranking of search results
    ;WITH RankedBooks AS (
        SELECT 
            b.Book_id,
            b.Title,
            b.Description,
            b.Author,
            b.PublishedYear,
            b.Available,
            br.Borrow_id,
            br.Borrow_date,
            br.Schedule_return_date,
            u.First_name + ' ' + u.Last_name AS Borrower_Name,
            -- Calculate search rank based on where the match is found
            CASE 
                WHEN @search_text IS NULL THEN 1
                ELSE (
                    CASE WHEN b.Title LIKE @search_pattern THEN 3 ELSE 0 END +
                    CASE WHEN b.Author LIKE @search_pattern THEN 2 ELSE 0 END +
                    CASE WHEN b.Description LIKE @search_pattern THEN 1 ELSE 0 END
                )
            END AS SearchRank
        FROM 
            Books b
            LEFT JOIN Borrows br ON b.Book_id = br.Book_id 
                AND br.Actual_return_date IS NULL -- Only get current borrow if exists
            LEFT JOIN Users u ON br.User_id = u.User_id
        WHERE 
            (@search_text IS NULL OR 
             b.Title LIKE @search_pattern OR 
             b.Author LIKE @search_pattern OR 
             b.Description LIKE @search_pattern)
            AND
            (@is_available = 1 OR 
             (@is_available = 2 AND b.Available = 1) OR 
             (@is_available = 3 AND b.Available = 0))
    )
    
    -- Final select with pagination
    SELECT 
        Book_id,
        Title,
        Description,
        Author,
        PublishedYear,
        Available,
        Borrow_id,
        Borrow_date,
        Schedule_return_date,
        Borrower_Name,
        -- Get total count for pagination
        COUNT(*) OVER() AS TotalCount
    FROM 
        RankedBooks
    ORDER BY 
        SearchRank DESC, -- Higher ranked matches appear first
        Title ASC; -- Then alphabetically by title
END;
GO

CREATE OR ALTER PROCEDURE sp_FetchBooks_Search_Only
    @page_number INT = 1,
    @is_available INT = 1, -- 1: All, 2: Available Only, 3: Not Available
	@page_size INT = 20,
    @search_text NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Validate parameters
    IF @page_number < 1 SET @page_number = 1
    IF @is_available NOT IN (1, 2, 3) SET @is_available = 1
    
    -- Define page size
    DECLARE @offset INT = (@page_number - 1) * @page_size
    
    -- Prepare search text for LIKE query
    DECLARE @search_pattern NVARCHAR(258)
    IF @search_text IS NOT NULL
        SET @search_pattern = '%' + @search_text + '%'
    
    -- Main query with CTE to handle ranking of search results
    ;WITH RankedBooks AS (
        SELECT 
            b.Book_id,
            b.Title,
            b.Description,
            b.Author,
            b.PublishedYear,
            b.Available,
            br.Borrow_id,
            br.Borrow_date,
            br.Schedule_return_date,
            u.First_name + ' ' + u.Last_name AS Borrower_Name,
            -- Calculate search rank based on where the match is found
            CASE 
                WHEN @search_text IS NULL THEN 1
                ELSE (
                    CASE WHEN b.Title LIKE @search_pattern THEN 3 ELSE 0 END +
                    CASE WHEN b.Author LIKE @search_pattern THEN 2 ELSE 0 END +
                    CASE WHEN b.Description LIKE @search_pattern THEN 1 ELSE 0 END
                )
            END AS SearchRank
        FROM 
            Books b
            LEFT JOIN Borrows br ON b.Book_id = br.Book_id 
                AND br.Actual_return_date IS NULL -- Only get current borrow if exists
            LEFT JOIN Users u ON br.User_id = u.User_id
        WHERE 
            (@search_text IS NULL OR 
             b.Title LIKE @search_pattern OR 
             b.Author LIKE @search_pattern OR 
             b.Description LIKE @search_pattern)
            AND
            (@is_available = 1 OR 
             (@is_available = 2 AND b.Available = 1) OR 
             (@is_available = 3 AND b.Available = 0))
    )
    
    -- Final select with pagination
    SELECT 
        Book_id,
        Title,
        Description,
        Author,
        PublishedYear,
        Available,
        Borrow_id,
        Borrow_date,
        Schedule_return_date,
        Borrower_Name,
        -- Get total count for pagination
        COUNT(*) OVER() AS TotalCount
    FROM 
        RankedBooks
    ORDER BY 
        SearchRank DESC, -- Higher ranked matches appear first
        Title ASC -- Then alphabetically by title
    OFFSET @offset ROWS
    FETCH NEXT @page_size ROWS ONLY;
END;
GO

CREATE OR ALTER PROCEDURE sp_FetchBooks_Count_Only
    @is_available INT = 1, -- 1: All, 2: Available Only, 3: Not Available
    @search_text NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Validate parameters
    IF @is_available NOT IN (1, 2, 3) SET @is_available = 1
    
    
    -- Prepare search text for LIKE query
    DECLARE @search_pattern NVARCHAR(258)
    IF @search_text IS NOT NULL
        SET @search_pattern = '%' + @search_text + '%'
    
    -- Create temp table to store filtered results
    CREATE TABLE #FilteredBooks (
        Book_id INT,
        Title NVARCHAR(255),
        Description NVARCHAR(500),
        Author NVARCHAR(255),
        PublishedYear INT,
        Available BIT,
        Borrow_id INT,
        Borrow_date DATETIME2,
        Schedule_return_date DATETIME2,
        Borrower_Name NVARCHAR(501),
        SearchRank INT
    )

    -- Insert filtered results into temp table
    INSERT INTO #FilteredBooks
    SELECT 
        b.Book_id,
        b.Title,
        b.Description,
        b.Author,
        b.PublishedYear,
        b.Available,
        br.Borrow_id,
        br.Borrow_date,
        br.Schedule_return_date,
        u.First_name + ' ' + u.Last_name AS Borrower_Name,
        -- Calculate search rank based on where the match is found
        CASE 
            WHEN @search_text IS NULL THEN 1
            ELSE (
                CASE WHEN b.Title LIKE @search_pattern THEN 3 ELSE 0 END +
                CASE WHEN b.Author LIKE @search_pattern THEN 2 ELSE 0 END +
                CASE WHEN b.Description LIKE @search_pattern THEN 1 ELSE 0 END
            )
        END AS SearchRank
    FROM 
        Books b
        LEFT JOIN Borrows br ON b.Book_id = br.Book_id 
            AND br.Actual_return_date IS NULL -- Only get current borrow if exists
        LEFT JOIN Users u ON br.User_id = u.User_id
    WHERE 
        (@search_text IS NULL OR 
         b.Title LIKE @search_pattern OR 
         b.Author LIKE @search_pattern OR 
         b.Description LIKE @search_pattern)
        AND
        (@is_available = 1 OR 
         (@is_available = 2 AND b.Available = 1) OR 
         (@is_available = 3 AND b.Available = 0))

    -- Get counts for different categories
    SELECT
        (SELECT COUNT(*) FROM #FilteredBooks) AS TotalFilteredCount,
        (SELECT COUNT(*) FROM Books) AS TotalBooksCount,
        (SELECT COUNT(*) FROM Books WHERE Available = 1) AS AvailableBooksCount,
        (SELECT COUNT(*) FROM Books WHERE Available = 0) AS BorrowedBooksCount


    -- Clean up
    DROP TABLE #FilteredBooks
END;
--EXEC sp_FetchBooks @page_number = 1, @is_available = 1, @search_text = NULL
--GO
GO


-- Borrow Book
CREATE OR ALTER PROCEDURE sp_BorrowBook
    @book_id INT,
    @user_id INT,
    @borrow_days INT = 14 -- Default borrow period is 14 days
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        -- Start transaction
        BEGIN TRANSACTION;

        -- Declare variables for validation
        DECLARE @is_book_available BIT;
        DECLARE @is_user_blocked BIT;
        DECLARE @active_borrows INT;
        DECLARE @has_late_fees BIT;
        
        -- Check if book exists and is available
        SELECT @is_book_available = Available
        FROM Books 
        WHERE Book_id = @book_id;

        IF @is_book_available IS NULL
        BEGIN
            THROW 50001, 'Book does not exist.', 1;
        END

        IF @is_book_available = 0
        BEGIN
            THROW 50002, 'Book is not available for borrowing.', 1;
        END

        -- Check if user exists and is not blocked
        SELECT @is_user_blocked = Blocked
        FROM Users
        WHERE User_id = @user_id;

        IF @is_user_blocked IS NULL
        BEGIN
            THROW 50003, 'User does not exist.', 1;
        END

        IF @is_user_blocked = 1
        BEGIN
            THROW 50004, 'User is blocked from borrowing books.', 1;
        END

        -- Check if user has any active borrows that are overdue
        SELECT @active_borrows = COUNT(*)
        FROM Borrows
        WHERE User_id = @user_id
        AND Actual_return_date IS NULL
        AND Schedule_return_date < GETDATE();

        IF @active_borrows > 0
        BEGIN
            THROW 50005, 'User has overdue books that need to be returned first.', 1;
        END

        -- Check if user has any unpaid late fees
        SELECT @has_late_fees = CASE WHEN COUNT(*) > 0 THEN 1 ELSE 0 END
        FROM LateFeePayments lfp
        INNER JOIN Borrows b ON lfp.Borrow_id = b.Borrow_id
        WHERE b.User_id = @user_id
        AND lfp.Paid = 0;

        IF @has_late_fees = 1
        BEGIN
            THROW 50006, 'User has unpaid late fees that need to be settled first.', 1;
        END

        -- Calculate borrow and return dates
        DECLARE @borrow_date DATETIME2 = GETDATE();
        DECLARE @schedule_return_date DATETIME2 = DATEADD(DAY, @borrow_days, @borrow_date);

        -- Create borrow record
        INSERT INTO Borrows (
            Book_id,
            User_id,
            Borrow_date,
            Schedule_return_date
        )
        VALUES (
            @book_id,
            @user_id,
            @borrow_date,
            @schedule_return_date
        );

        -- Update book availability
        UPDATE Books
        SET Available = 0
        WHERE Book_id = @book_id;

        -- Commit transaction
        COMMIT TRANSACTION;

        -- Return borrow details
        SELECT 
            b.Borrow_id,
            bk.Title,
            u.First_name + ' ' + u.Last_name AS Borrower_Name,
            b.Borrow_date,
            b.Schedule_return_date,
            bk.Author,
            bk.Description
        FROM Borrows b
        INNER JOIN Books bk ON b.Book_id = bk.Book_id
        INNER JOIN Users u ON b.User_id = u.User_id
        WHERE b.Book_id = @book_id
        AND b.User_id = @user_id
        AND b.Actual_return_date IS NULL;

    END TRY
    BEGIN CATCH
        -- Rollback transaction if error occurs
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        -- Return error information
        SELECT 
            ERROR_NUMBER() AS ErrorNumber,
            ERROR_SEVERITY() AS ErrorSeverity,
            ERROR_STATE() AS ErrorState,
            ERROR_PROCEDURE() AS ErrorProcedure,
            ERROR_LINE() AS ErrorLine,
            ERROR_MESSAGE() AS ErrorMessage;
    END CATCH;
END;
-- Borrow a book with default 14-day period
--EXEC sp_BorrowBook @book_id = 1, @user_id = 1;
-- Borrow a book with custom 7-day period
--EXEC sp_BorrowBook @book_id = 1, @user_id = 1, @borrow_days = 7;
GO

-- Return Book 
CREATE OR ALTER PROCEDURE sp_ReturnBook
    @borrow_id INT,
    @daily_late_fee DECIMAL(18,2) = 0 -- Default late fee of $1 per day
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        -- Start transaction
        BEGIN TRANSACTION;

        DECLARE @book_id INT;
        DECLARE @schedule_return_date DATETIME2;
        DECLARE @days_late INT;
        
        -- Get borrow information
        SELECT 
            @book_id = Book_id,
            @schedule_return_date = Schedule_return_date
        FROM Borrows 
        WHERE Borrow_id = @borrow_id
            AND Actual_return_date IS NULL;

        -- Check if borrow exists and is not already returned
        IF @book_id IS NULL
        BEGIN
            THROW 50001, 'Invalid borrow ID or book already returned.', 1;
        END

        -- Set return date to current date/time
        DECLARE @return_date DATETIME2 = GETDATE();

        -- Update borrow record with actual return date
        UPDATE Borrows
        SET Actual_return_date = @return_date
        WHERE Borrow_id = @borrow_id;

        -- Update book availability
        UPDATE Books
        SET Available = 1
        WHERE Book_id = @book_id;

        -- Calculate days late (if any)
        SET @days_late = DATEDIFF(DAY, @schedule_return_date, @return_date);

        -- If book is returned late, create late fee payment record
        IF @days_late > 0
        BEGIN
            DECLARE @late_fee DECIMAL(18,2) = @days_late * @daily_late_fee;

            INSERT INTO LateFeePayments (
                Borrow_id,
                Amount,
                Paid
            )
            VALUES (
                @borrow_id,
                @late_fee,
                0
            );
        END

        -- Commit transaction
        COMMIT TRANSACTION;

        -- Return result
        SELECT 
            b.Book_id,
            bk.Title,
            u.First_name + ' ' + u.Last_name AS Borrower_Name,
            b.Borrow_date,
            b.Schedule_return_date,
            b.Actual_return_date,
            @days_late AS Days_Late,
            CASE 
                WHEN @days_late > 0 THEN @late_fee 
                ELSE 0 
            END AS Late_Fee_Amount
        FROM Borrows b
        INNER JOIN Books bk ON b.Book_id = bk.Book_id
        INNER JOIN Users u ON b.User_id = u.User_id
        WHERE b.Borrow_id = @borrow_id;

    END TRY
    BEGIN CATCH
        -- Rollback transaction if error occurs
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        -- Return error information
        SELECT 
            ERROR_NUMBER() AS ErrorNumber,
            ERROR_SEVERITY() AS ErrorSeverity,
            ERROR_STATE() AS ErrorState,
            ERROR_PROCEDURE() AS ErrorProcedure,
            ERROR_LINE() AS ErrorLine,
            ERROR_MESSAGE() AS ErrorMessage;
    END CATCH;
END;
-- Return a book with default late fee
--EXEC sp_ReturnBook @borrow_id = 1;

-- Return a book with custom late fee of $2 per day
--EXEC sp_ReturnBook @borrow_id = 1, @daily_late_fee = 2.00;
GO





ALTER TABLE Borrows DROP CONSTRAINT FK__Borrows__User_id__59063A47;
ALTER TABLE Borrows DROP CONSTRAINT FK__Borrows__Book_id__59FA5E80;

ALTER TABLE Borrows ADD CONSTRAINT FK_Borrows_User
    FOREIGN KEY (User_id) REFERENCES Users(User_id) ON DELETE CASCADE;

ALTER TABLE Borrows ADD CONSTRAINT FK_Borrows_Book
    FOREIGN KEY (Book_id) REFERENCES Books(Book_id) ON DELETE CASCADE;

