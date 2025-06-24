EXEC sp_FetchBooks @page_number = 1, @is_available = 1, @search_text = NULL;
EXEC sp_FetchBooks 1, 1, NULL;
EXEC sp_FetchBooks_Simple 1, NULL;

EXEC sp_FetchBooks_Count_only 1, NULL;
EXEC sp_FetchBooks_Search_only 1, 1, 500, NULL;
GO

EXEC sp_BorrowBook @book_id = 1, @user_id = 7, @borrow_days = 7;
GO

