CREATE PROC SP_CREATE_DOCTOR
	@Name VARCHAR(MAX),
	@Experience INT
AS
BEGIN
	INSERT INTO Doctors(Name,Experience) 
	VALUES(@Name,@Experience)

	SET @Id = SCOPE_IDENTITY();

	INSERT INTO Specializations_Doctors(DoctorId,SpecializationId) SELECT @Id , CAST(VALUE AS INT) FROM string_split(@Specialisations,',');
END

select * from Appointments



select * from Doc