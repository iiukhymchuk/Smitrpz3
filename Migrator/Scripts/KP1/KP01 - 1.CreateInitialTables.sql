CREATE TABLE DcSubdivision
(
	DcSubdivisionId INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(250) NOT NULL
);


CREATE TABLE DcDiscipline
(
	DcDisciplineId INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(250) NOT NULL
);


CREATE TABLE DcDuties
(
	DcDutiesId INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) NOT NULL,
	DcSubdivisionId INT,
	CONSTRAINT FK_DcDuties_To_DcSubdivision FOREIGN KEY (DcSubdivisionId) REFERENCES DcSubdivision (DcSubdivisionId)
);

CREATE TABLE StudyGroup
(
	StudyGroupId INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(100) NOT NULL,
	DcSubdivisionId INT NOT NULL,
	DataVstup DATE,
	CONSTRAINT FK_StudyGroup_To_DcSubdivision FOREIGN KEY (DcSubdivisionId) REFERENCES DcSubdivision (DcSubdivisionId)
);

CREATE TABLE Student
(
	StudentId INT PRIMARY KEY,
	Surname NVARCHAR(20) NOT NULL,
	Name NVARCHAR(15) NOT NULL,
	Petronymic NVARCHAR(20),
	Birthday DATE NOT NULL,
	RecordBook NVARCHAR(10) NOT NULL,
	BirthdayCity NVARCHAR(10),
	StudyGroupId INT NOT NULL,
	CONSTRAINT FK_StudyGroup_To_Student FOREIGN KEY (StudyGroupId) REFERENCES StudyGroup (StudyGroupId),
	Stipendiya MONEY
);


CREATE TABLE Employee
(
	EmployeeId INT PRIMARY KEY,
	Surname NVARCHAR(20) NOT NULL,
	Name NVARCHAR(15) NOT NULL,
	Patronymic NVARCHAR(20),
	Oklad MONEY NOT NULL,
	BirthdayCity NVARCHAR(10),
	Nadbavka MONEY,
	DataVuplatu DATE,
	DcDutiesId INT,
	Birthday DATE,
	CONSTRAINT FK_Employee_To_DcDuties FOREIGN KEY (DcDutiesId) REFERENCES DcDuties (DcDutiesId)
);

CREATE TABLE Exam
(
	ExamId INT PRIMARY KEY IDENTITY,
	Mark INT NOT NULL,
	DateExam DATE NOT NULL,
	StudentId INT NOT NULL,
	DcDisciplineId INT NOT NULL,
	EmployeeId INT NOT NULL,
	CONSTRAINT FK_Student_To_Exam FOREIGN KEY (StudentId) REFERENCES Student (StudentId),
	CONSTRAINT FK_Employee_To_Exam FOREIGN KEY (EmployeeId) REFERENCES Employee (EmployeeId),
	CONSTRAINT FK_DcDiscipline_To_Exam FOREIGN KEY (DcDisciplineId) REFERENCES DcDiscipline (DcDisciplineId)
);