

-- الأشخاص
CREATE TABLE [dbo].Persons
(
	[IDPerson] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FullName] NVARCHAR(120) NOT NULL, 
    [Housing] NVARCHAR(100) NOT NULL, 
    [NumPhone] NVARCHAR(20) NOT NULL, 
    [Email] NVARCHAR(50) NULL, 
    [Nationality] NVARCHAR(50) NOT NULL, -- الجنسية
	[National number] varchar(50) null,-- الرقم الوطني
    [Gender] NVARCHAR(6) NOT NULL, 
    [Birthdate] DATE NOT NULL, 
    [Picture] VARBINARY(MAX) NULL
);

-- المستخدمين
CREATE TABLE [dbo].Users
(
	[IDUser] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserName] NVARCHAR(20) NOT NULL, 
    [Password] NVARCHAR(30) NOT NULL, 
    [Authorities] NVARCHAR(100) NOT NULL, -- صلاحيات المستخدم 
    [Status Account] NVARCHAR(50) NULL ,
    [Role]  NVARCHAR(50) Not null  -- الصفة _موظف/مدير
);

ALTER TABLE Users
ADD [IDPerson] INT;

ALTER TABLE Users
ADD CONSTRAINT FK_Users_Persons
FOREIGN KEY ([IDPerson]) REFERENCES Persons([IDPerson]);


-- الطلبات
CREATE TABLE [dbo].Requests
(
	[RequestID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Status] NVARCHAR(20) NULL, 
    [Fees] INT NULL, 
    [DateRequest] Date NULL
);


ALTER TABLE Requests
ADD [IDPerson] INT;


ALTER TABLE Requests
ADD [LicenseClassID] INT;


ALTER TABLE Requests
ADD [RequestTypeID] INT;


ALTER TABLE Requests
ADD CONSTRAINT FK_Requests_Persons
FOREIGN KEY ([IDPerson]) REFERENCES Persons([IDPerson]);


ALTER TABLE Requests
ADD CONSTRAINT FK_Requests_LicenseClass
FOREIGN KEY ([LicenseClassID]) REFERENCES LicenseClass([LicenseClassID]);


ALTER TABLE Requests
ADD CONSTRAINT FK_Requests_RequestTypes
FOREIGN KEY ([RequestTypeID]) REFERENCES RequestTypes([RequestTypeID]);



-- الفحوصات
CREATE TABLE [dbo].Tests
(
	[TestID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ExamDate] DATE NOT NULL, 
    [Mark] INT NOT NULL, 
    [Result] NVARCHAR(20) NULL, 
    [FeesExam] INT NOT NULL
);


ALTER TABLE Tests
ADD [RequestID] INT;

ALTER TABLE Tests
ADD CONSTRAINT FK_Requests_Requests
FOREIGN KEY ([RequestID]) REFERENCES Requests([RequestID]);
---

ALTER TABLE Tests
ADD [TestTypeID] INT;

ALTER TABLE Tests
ADD CONSTRAINT FK_Requests_TestTypes
FOREIGN KEY ([TestTypeID]) REFERENCES TestTypes([TestTypeID]);

 




-- الرخص
CREATE TABLE [dbo].Licenses
(
	[LicenceID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [StatusRelease] NVARCHAR(50) NOT NULL, 
    [RelesaseDate] DATE NOT NULL, 
    [EndDate] DATE NULL, 
    [ProfilePicture] VARBINARY(MAX) NOT NULL
);


ALTER TABLE Licenses
ADD [RequestID] INT;

ALTER TABLE Licenses
ADD CONSTRAINT FK_Licenses_Requests
FOREIGN KEY ([RequestID]) REFERENCES Requests([RequestID]);
---


ALTER TABLE Licenses
ADD [LicenseClassID] INT;

ALTER TABLE Licenses
ADD CONSTRAINT FK_Licenses_LicenseClass
FOREIGN KEY ([LicenseClassID]) REFERENCES LicenseClass([LicenseClassID]);

---
ALTER TABLE Licenses
ADD [CategoryID] INT;

ALTER TABLE Licenses
ADD CONSTRAINT FK_Licenses_LicenseCategories
FOREIGN KEY ([CategoryID]) REFERENCES LicenseCategories([CategoryID]);



SELECT * 
FROM sys.foreign_keys 
WHERE name = 'FK_Requests_Requests';


 
-- حجز الرخص
CREATE TABLE [dbo].LicenseHolds
(
    [HoldID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [HoldDate] DATE NOT NULL, 
    [Reason] NVARCHAR(200) NOT NULL, 
    [PenaltyAmount] INT NULL, 
    [ReleasedDate] DATE NOT NULL
);

 ---
ALTER TABLE LicenseHolds
ADD [LicenceID] INT;

ALTER TABLE LicenseHolds
ADD CONSTRAINT FK_LicenseHolds_Licenses
FOREIGN KEY ([LicenceID]) REFERENCES Licenses([LicenceID]);


 -- فئات الرخص
 CREATE TABLE [dbo].LicenseClass
(
	[LicenseClassID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ClassName] NVARCHAR(100) NOT NULL, 
    [ClassDescription] NVARCHAR(200) NULL, 
    [MinAge] INT NOT NULL, 
    [ValidatyLength] INT NOT NULL, 
    [Class fees] INT NOT NULL
);




-- الرخص الدولية 
CREATE TABLE [dbo].InternationalLicenses
(
	[interLicenseID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IssueDate] DATE NOT NULL, 
    [ExpiryDate] DATE NULL, 
    [Status] NVARCHAR(50) NOT NULL 
);

ALTER TABLE InternationalLicenses
ADD [LicenceID] INT;

ALTER TABLE InternationalLicenses
ADD CONSTRAINT FK_InternationalLicenses_Licenses
FOREIGN KEY ([LicenceID]) REFERENCES Licenses([LicenceID]);



-- سجل الحركات
CREATE TABLE [dbo].AuditLogs
(
	[LogID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Action] NVARCHAR(50) NOT NULL, 
    [ActionDate] DATE NOT NULL, 
    [Description] NVARCHAR(100)  NULL 
);

ALTER TABLE AuditLogs
ADD [IDUser] INT;

ALTER TABLE AuditLogs
ADD CONSTRAINT FK_AuditLogs_Users
FOREIGN KEY ([IDUser]) REFERENCES Users([IDUser]);




-- أنواع الطلبات
CREATE TABLE [dbo].RequestTypes
(
	[RequestTypeID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TypeName] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(200) NULL 
);


-- فئات الرخص
CREATE TABLE [dbo].LicenseCategories
(
	[CategoryID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CategoryName] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(200) NULL 
);


-- أنواع الفحوصات
CREATE TABLE [dbo].TestTypes
(
	[TestTypeID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TypeName] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(200) NULL 
);










