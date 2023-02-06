CREATE TABLE Users
(
	[User_id] BIGINT NOT NULL IDENTITY(1, 1) PRIMARY KEY, 
    [User_first_name] NVARCHAR(50) NULL, 
    [User_last_name] NVARCHAR(100) NULL, 
    [User_email] NVARCHAR(100) NULL, 
    [User_username] NVARCHAR(50) NOT NULL, 
    [User_password] NVARCHAR(50) NOT NULL, 
    [User_picture] NVARCHAR(500) NULL
)
