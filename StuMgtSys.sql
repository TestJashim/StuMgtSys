Use master
CREATE Database StuMgtSysDB
GO

Use StuMgtSysDB
GO

-- Create the Students table
CREATE TABLE Students (
    ID INT PRIMARY KEY IDENTITY,
    Name VARCHAR(100),
    RollNumber VARCHAR(20),
    ImagePath VARCHAR(200)
);
GO

-- Insert dummy data
INSERT INTO Students (Name, RollNumber, ImagePath)
VALUES ('John Doe', 'A001', 'C:\Images\john_doe.jpg'),
       ('Jane Smith', 'B002', 'C:\Images\jane_smith.jpg'),
       ('Michael Johnson', 'C003', 'C:\Images\michael_johnson.jpg');
GO

-- Create the stored procedure for inserting a student record
CREATE PROCEDURE InsertStudent
    @Name VARCHAR(100),
    @RollNumber VARCHAR(20),
    @ImagePath VARCHAR(200)
AS
BEGIN
    INSERT INTO Students (Name, RollNumber, ImagePath)
    VALUES (@Name, @RollNumber, @ImagePath);
END;
GO

-- Create the stored procedure for updating a student record
CREATE PROCEDURE UpdateStudent
    @ID INT,
    @Name VARCHAR(100),
    @RollNumber VARCHAR(20),
    @ImagePath VARCHAR(200)
AS
BEGIN
    UPDATE Students
    SET Name = @Name, RollNumber = @RollNumber, ImagePath = @ImagePath
    WHERE ID = @ID;
END;
GO

-- Create the stored procedure for deleting a student record
CREATE PROCEDURE DeleteStudent
    @ID INT
AS
BEGIN
    DELETE FROM Students
    WHERE ID = @ID;
END;
GO

-- Create the stored procedure for retrieving all student records
CREATE PROCEDURE GetAllStudents
AS
BEGIN
    SELECT * FROM Students;
END;
GO

-- Create the stored procedure for retrieving a specific student record by ID
CREATE PROCEDURE GetStudentByID
    @ID INT
AS
BEGIN
    SELECT * FROM Students
    WHERE ID = @ID;
END;
GO

EXEC GetAllStudents
GO