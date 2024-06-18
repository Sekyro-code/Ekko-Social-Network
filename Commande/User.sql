-- Création des utilisateurs
INSERT INTO [USER_API.User] ([Id], [UserName], [FirstName], [LastName], [Birthday], [Gender], [Email], [Password], [Validate], [Notification], [Biography], [Country], [PhoneNumber], [Picture], [CreatedAt])
VALUES
    (NEWID(), 'user1', 'John', 'Doe', '1990-01-01', 1, 'user1@email.com', 'password1', 1, 1, 'Biography 1', 'Country 1', '123456789', 'picture1.jpg', GETDATE()),
    (NEWID(), 'user2', 'Jane', 'Smith', '1992-03-15', 0, 'user2@email.com', 'password2', 1, 1, 'Biography 2', 'Country 2', '987654321', 'picture2.jpg', GETDATE()),
    (NEWID(), 'user3', 'Bob', 'Johnson', '1985-07-22', 1, 'user3@email.com', 'password3', 1, 0, 'Biography 3', 'Country 3', '555555555', 'picture3.jpg', GETDATE()),
    (NEWID(), 'user4', 'Alice', 'Williams', '1998-11-10', 0, 'user4@email.com', 'password4', 1, 0, 'Biography 4', 'Country 4', '999999999', 'picture4.jpg', GETDATE());
