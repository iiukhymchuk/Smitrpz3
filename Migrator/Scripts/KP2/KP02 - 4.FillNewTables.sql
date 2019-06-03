CREATE TABLE DcSubdivisionCopyA
(
	DcSubdivisionId INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Name NVARCHAR(250) NOT NULL
)

CREATE TABLE DcSubdivisionCopyB
(
	DcSubdivisionId INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Name NVARCHAR(25) NOT NULL,
	Abbreviation NVARCHAR(10)
)

CREATE TABLE DcSubdivisionCopyC
(
	DcSubdivisionId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(25) NOT NULL
)

SET IDENTITY_INSERT DcSubdivisionCopyA ON;
INSERT INTO DcSubdivisionCopyA(DcSubdivisionId, Name) SELECT * FROM DcSubdivision
SET IDENTITY_INSERT DcSubdivisionCopyA OFF;

SET IDENTITY_INSERT DcSubdivisionCopyB ON;
INSERT INTO DcSubdivisionCopyB(DcSubdivisionId, Name) SELECT * FROM DcSubdivision
SET IDENTITY_INSERT DcSubdivisionCopyB OFF;

SET IDENTITY_INSERT DcSubdivisionCopyC ON;
INSERT INTO DcSubdivisionCopyC(DcSubdivisionId, Name) SELECT * FROM DcSubdivision
	WHERE DcSubdivision.DcSubdivisionId > 5
SET IDENTITY_INSERT DcSubdivisionCopyC OFF;

CREATE TABLE DcDisciplineCopy
(
	DcDisciplineId INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Name NVARCHAR(25) NOT NULL
)

SET IDENTITY_INSERT DcDisciplineCopy ON;
INSERT INTO DcDisciplineCopy(DcDisciplineId, Name) SELECT * FROM DcDiscipline
	WHERE DcDiscipline.DcDisciplineId > 3 AND DcDiscipline.DcDisciplineId < 6
SET IDENTITY_INSERT DcDisciplineCopy OFF;

CREATE TABLE ExamCopy
(
	ExamId INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Mark INT NOT NULL,
	DateExam DATE NOT NULL,
	StudentId INT NOT NULL,
	DcDisciplineId INT NOT NULL,
	EmployeeId INT NOT NULL
)

SET IDENTITY_INSERT ExamCopy ON;
INSERT INTO ExamCopy(ExamId, Mark, DateExam, StudentId, DcDisciplineId, EmployeeId) 
	SELECT * FROM Exam
	WHERE Exam.Mark = 5
SET IDENTITY_INSERT ExamCopy OFF;

CREATE TABLE DcDisciplineCopyNew
(
	DcDisciplineId INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Name NVARCHAR(25) NOT NULL
)

SET IDENTITY_INSERT DcDisciplineCopyNew ON;
INSERT INTO DcDisciplineCopyNew(DcDisciplineId, Name) SELECT * FROM DcDisciplineCopy
SET IDENTITY_INSERT DcDisciplineCopyNew OFF;

ALTER TABLE Student
ADD DateApl NVARCHAR(20);