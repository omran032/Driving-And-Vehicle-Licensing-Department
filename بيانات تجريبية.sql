INSERT INTO Persons (FullName, Housing, NumPhone, Email, Nationality, Gender, Birthdate, [National number])
VALUES
('John Smith', N'Damascus - Mezzeh', '0991111111', 'john@mail.com', N'Syrian', 'Male', '1999-04-10', 'A123456'),
('Michael Brown', N'Damascus - Barzeh', '0992222222', 'michael@mail.com', N'Syrian', 'Male', '1995-07-21', 'B987654'),
('Sarah Johnson', N'Damascus - Maliki', '0993333333', 'sarah@mail.com', N'Syrian', 'Female', '2000-11-02', 'C112233'),
('Emily Davis', N'Damascus - Dummar', '0994444444', 'emily@mail.com', N'Syrian', 'Female', '1998-02-15', 'D556677');


INSERT INTO Users (UserName, Password, Authorities, [Status Account], IDPerson, Role)
VALUES
('admin', 'HASHED_PASS', 'All', 'Active', 1, 'Admin'),
('emp_req', 'HASHED_PASS', 'Requests', 'Active', 2, 'Employee'),
('emp_test', 'HASHED_PASS', 'Tests', 'Active', 3, 'Employee'),
('emp_disabled', 'HASHED_PASS', 'Requests', 'Inactive', 4, 'Employee');


INSERT INTO LicenseClass (ClassName, ClassDescription, MinAge, ValidatyLength, [Class fees])
VALUES
('A', N'Motorcycles', 18, 10, 20000),
('B', N'Private Cars', 18, 10, 30000),
('C', N'Trucks', 21, 5, 45000),
('D', N'Buses', 25, 5, 50000);


INSERT INTO LicenseCategories (CategoryName, Description)
VALUES
('Private', N'Private Driving License'),
('Public', N'Public Driving License');


INSERT INTO Requests (Status, Fees, DateRequest, IDPerson, LicenseClassID, RequestTypeID)
VALUES
(0, 15000, '2024-01-10', 1, 2, 1),   -- Pending
(1, 15000, '2024-01-05', 2, 2, 1),   -- Completed
(-1, 15000, '2024-01-03', 3, 1, 1),  -- Cancelled
(1, 10000, '2024-02-01', 4, 2, 2);   -- Completed Renew


INSERT INTO TestTypes (TypeName, Description, Fees)
VALUES
('Theory Test', N'Written exam', 5000),
('Street Test', N'Practical driving exam', 7000),
('Vision Test', N'Vision check exam', 3000);


INSERT INTO TestTypes (TypeName, Description, Fees)
VALUES
('Theory Test', N'Written exam', 5000),
('Street Test', N'Practical driving exam', 7000),
('Vision Test', N'Vision check exam', 3000);


INSERT INTO Licenses (StatusRelease, RelesaseDate, EndDate, ProfilePicture, RequestID, LicenseClassID, CategoryID, PersonID)
VALUES
(1, '2024-01-25', '2034-01-25', 0x00, 2, 2, 1, 2),
(0, '2024-02-10', NULL, 0x00, 4, 2, 1, 4);


INSERT INTO LicenseHolds (HoldDate, Reason, PenaltyAmount, ReleasedDate, LicenceID)
VALUES
('2024-03-01', N'Speed Violation', 20000, '2024-03-10', 1);



INSERT INTO InternationalLicenses (IssueDate, ExpiryDate, Status, LicenceID)
VALUES
('2024-04-01', '2025-04-01', 'Active', 1);


INSERT INTO AuditLogs (Action, ActionDate, Description, IDUser)
VALUES
(N'Login', '2024-01-01', N'User logged in', 3),
(N'Create Request', '2024-01-10', N'New request created', 3),
(N'Delete Request', '2024-01-15', N'Request removed', 4);







-------------------------------------------------------------------
-------------------------------------------------------------------
-------------------------------------------------------------------
-------------------------------------------------------------------
-------------------------------------------------------------------

INSERT INTO Persons (FullName, Housing, NumPhone, Email, Nationality, Gender, Birthdate, [National number])
VALUES
('Alex Turner', N'Damascus - Kafarsouseh', '0991110001', 'alex@mail.com', N'Syrian', 'Male', '1998-03-12', 'N1001'),
('Ben Parker', N'Damascus - Rukn Aldin', '0991110002', 'ben@mail.com', N'Syrian', 'Male', '1997-06-25', 'N1002'),
('Charlie Evans', N'Damascus - Qaboun', '0991110003', 'charlie@mail.com', N'Syrian', 'Male', '1999-09-10', 'N1003'),
('Daniel Foster', N'Damascus - Jaramana', '0991110004', 'daniel@mail.com', N'Syrian', 'Male', '1996-12-05', 'N1004');




INSERT INTO Requests (Status, Fees, DateRequest, IDPerson, LicenseClassID, RequestTypeID)
VALUES
(0, 15000, '2024-01-10', 1, 2, 1),   -- Alex → 0 passed
(0, 15000, '2024-01-11', 2, 2, 1),   -- Ben → 1 passed
(0, 15000, '2024-01-12', 3, 2, 1),   -- Charlie → 2 passed
(0, 15000, '2024-01-13', 4, 2, 1);   -- Daniel → 3 passed




INSERT INTO Tests (ExamDate, Mark, Result, FeesExam, RequestID, TestTypeID)
VALUES
('2024-01-15', 82, 'Pass', 5000, 2, 1);


INSERT INTO Tests (ExamDate, Mark, Result, FeesExam, RequestID, TestTypeID)
VALUES
('2024-01-16', 90, 'Pass', 5000, 3, 1),
('2024-01-18', 87, 'Pass', 5000, 3, 2);


INSERT INTO Tests (ExamDate, Mark, Result, FeesExam, RequestID, TestTypeID)
VALUES
('2024-01-17', 92, 'Pass', 5000, 4, 1),
('2024-01-19', 89, 'Pass', 5000, 4, 2),
('2024-01-21', 95, 'Pass', 5000, 4, 3);


INSERT INTO Licenses (StatusRelease, RelesaseDate, EndDate, ProfilePicture, RequestID, LicenseClassID, CategoryID, PersonID)
VALUES
(1, '2024-02-01', '2034-02-01', 0x00, 4, 2, 1, 4);

