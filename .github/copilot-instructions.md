# Copilot Instructions

## Project Guidelines
- Project DB schema (file جداول القاعدة.sql) — contains tables: Persons (IDPerson, FullName, Housing, NumPhone, Email, Nationality, National number, Gender, Birthdate, Picture); Users (IDUser, UserName, Password, Authorities, Status Account, Role, IDPerson FK); Requests (RequestID, Status, Fees, DateRequest, IDPerson FK, LicenseClassID FK, RequestTypeID FK, CreateByUserID FK, PassedTests); Tests (TestID, ExamDate, Mark, Result, FeesExam, RequestID FK, TestTypeID FK, CreateByUserID FK); Licenses (LicenceID, StatusRelease, RelaseDate, EndDate, ProfilePicture, RequestID FK, LicenseClassID FK, CategoryID FK); LicenseHolds (HoldID, HoldDate, Reason, PenaltyAmount, ReleasedDate, LicenceID FK); LicenseClass (LicenseClassID, ClassName, ClassDescription, MinAge, ValidatyLength, Class fees); InternationalLicenses (interLicenseID, IssueDate, ExpiryDate, Status, LicenceID FK); AuditLogs (LogID, Action, ActionDate, Description, IDUser FK); RequestTypes (RequestTypeID, TypeName, Description); LicenseCategories (CategoryID, CategoryName, Description); TestTypes (TestTypeID, TypeName, Description). File path: جداول القاعدة.sql in workspace root.

## General Guidelines
- Include Arabic translations in responses.
- Write code comments in Arabic for code changes.
- Include Arabic translation of all assistant replies.