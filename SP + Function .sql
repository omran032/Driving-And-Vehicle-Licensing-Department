
-- SP ADD

    CREATE PROCEDURE AddPerson
     @FullName       NVARCHAR(120),
     @National_Number       NVARCHAR(70),
    @Housing        NVARCHAR(100),
    @NumPhone       NVARCHAR(20),
    @Email          NVARCHAR(50),
    @Nationality    NVARCHAR(50),
    @Gender         NVARCHAR(6),
    @Birthdate      DATE,
    @Picture        VARBINARY(MAX)
AS
BEGIN
    -- إذا لم يتم إرسال صورة → خزّن NULL
    IF (@Picture IS NULL OR DATALENGTH(@Picture) = 0)
    BEGIN
        SET @Picture = NULL;
    END

    INSERT INTO Persons (FullName,[National Number], Housing, NumPhone, Email, Nationality, Gender, Birthdate, Picture)
    VALUES (@FullName,@National_Number, @Housing, @NumPhone, @Email, @Nationality, @Gender, @Birthdate, @Picture);

    SELECT SCOPE_IDENTITY();   -- يرجّع IDPerson لـ ExecuteScalar
END;




-- SP Update
CREATE PROCEDURE UpdatePerson
    @IDPerson      INT,
    @FullName      NVARCHAR(120),
     @National_Number       NVARCHAR(70),
    @Housing       NVARCHAR(100),
    @NumPhone      NVARCHAR(20),
    @Email         NVARCHAR(50),
    @Nationality   NVARCHAR(50),
    @Gender        NVARCHAR(6),
    @Birthdate     DATE,
    @Picture       VARBINARY(MAX)
AS
BEGIN
    IF (@Picture IS NULL)
    BEGIN
        UPDATE Persons
        SET FullName   = @FullName,
            [National Number] = @National_Number,
            Housing    = @Housing,
            NumPhone   = @NumPhone,
            Email      = @Email,
            Nationality= @Nationality,
            Gender     = @Gender,
            Birthdate  = @Birthdate
        WHERE IDPerson = @IDPerson;
    END
    ELSE
    BEGIN
        UPDATE Persons
        SET FullName   = @FullName,
            [National Number] = @National_Number,
            Housing    = @Housing,
            NumPhone   = @NumPhone,
            Email      = @Email,
            Nationality= @Nationality,
            Gender     = @Gender,
            Birthdate  = @Birthdate,
            Picture    = @Picture
        WHERE IDPerson = @IDPerson;
    END
END



-- SP DeletePerson

CREATE PROCEDURE DeletePerson
    @IDPerson INT
AS
BEGIN
    DELETE FROM Persons
    WHERE IDPerson = @IDPerson;
END








