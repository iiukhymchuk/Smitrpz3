using System.Collections.Generic;

namespace App.Models.Queries
{
    public class KR4_queries
    {
        public static List<string> GetQueries = new List<string>
        {
            @"SELECT DISTINCT Surname, Name FROM Employee
            WHERE EmployeeId IN (SELECT EmployeeId FROM Exam)
            ORDER BY Surname ASC",

            @"SELECT DISTINCT Surname, Name FROM Employee
            WHERE EmployeeId NOT IN (SELECT EmployeeId FROM EXAM)
            ORDER BY Surname ASC",

            @"SELECT DISTINCT Surname, Name FROM Student 
            WHERE StudentId NOT IN (SELECT StudentId FROM Exam)
            ORDER BY Surname ASC",

            @"SELECT DISTINCT DcSubdivision.Name FROM DcSubdivision, Employee, DcDuties
            WHERE Employee.DcDutiesId IN (DcDuties.DcDutiesId)
	            AND (DcSubdivision.DcSubdivisionId IN (SELECT DcDuties.DcSubdivisionId FROM DcDuties))
            ORDER BY Name ASC",

            @"SELECT DISTINCT Name FROM DcSubdivision
            WHERE DcSubdivisionId NOT IN (SELECT DcSubdivisionId FROM StudyGroup)
            ORDER BY NAME ASC",

            @"SELECT DISTINCT Student.Surname, Student.Name, Student.Petronymic, Student.RecordBook, 
	            StudyGroup.Name AS GroupName, Exam.Mark FROM Student, StudyGroup, Exam
            WHERE ExamId IN (SELECT ExamId FROM Exam WHERE Mark = 5)
	            AND Student.StudyGroupId = StudyGroup.StudyGroupId
	            AND Exam.StudentId = Student.StudentId
            ORDER BY Student.Surname ASC",

            @"SELECT DISTINCT Employee.Surname, Employee.Name, Employee.Patronymic, DcDuties.Name,
	            DcDiscipline.Name FROM Employee, DcDuties, DcDiscipline, Exam
            WHERE Employee.EmployeeId = Exam.EmployeeId
	            AND Employee.DcDutiesId = DcDuties.DcDutiesId
	            AND Exam.DcDisciplineId = DcDiscipline.DcDisciplineId
	            AND Exam.DcDisciplineId IN (SELECT DcDisciplineId FROM DcDiscipline WHERE Name IN (N'Математика'))",

            @"SELECT DISTINCT Employee.Surname, Employee.Name, Employee.Patronymic, DcDuties.Name, 
	            DcDiscipline.Name FROM Employee, DcDuties, DcDiscipline, Exam
            WHERE Employee.EmployeeId = Exam.EmployeeId
	            AND Exam.DcDisciplineId = DcDiscipline.DcDisciplineId
	            AND Employee.DcDutiesId = DcDuties.DcDutiesId
	            AND DcDiscipline.Name = N'Математика'",

            @"SELECT Employee.Surname, Employee.Name, Employee.Patronymic, Employee.Oklad, Employee.Nadbavka,
	            DcDuties.Name, DcSubdivision.Name FROM Employee, DcDuties, DcSubdivision
            WHERE Nadbavka >= 450
	            AND Employee.DcDutiesId = DcDuties.DcDutiesId
	            AND DcDuties.DcSubdivisionId = DcSubdivision.DcSubdivisionId
	            AND (Oklad > (SELECT AVG(Oklad) FROM Employee))",

            @"SELECT Student.Surname, Student.Name, Student.Petronymic, Student.RecordBook, StudyGroup.Name,
	            Exam.Mark FROM Student, Exam, StudyGroup
            WHERE Student.StudentId = Exam.StudentId
	            AND StudyGroup.StudyGroupId = Student.StudyGroupId
	            AND Mark >= (SELECT AVG(Mark) FROM Exam)",

            @"SELECT Student.Surname, Exam.Mark FROM Student JOIN Exam 
	            ON Student.StudentId = Exam.StudentId
            GROUP BY Student.Surname, Exam.Mark
            HAVING AVG(Mark) > (SELECT AVG(Mark) FROM Exam)",

            @"SELECT * FROM Employee 
            WHERE BirthdayCity IN (SELECT BirthdayCity FROM Employee WHERE EmployeeId = 1)",

            @"SELECT * FROM Employee 
            WHERE DcDutiesId IN (SELECT DcDutiesId FROM Employee WHERE Surname = N'Мацуки')
	            AND Oklad > (SELECT AVG(Oklad) FROM Employee)",

            @"SELECT * FROM Student 
            WHERE StudyGroupId IN (SELECT StudyGroupId FROM Student WHERE Surname = N'Масливець')",

            @"SELECT COUNT(DcDutiesId) FROM (SELECT DcDutiesId FROM Employee 
	            GROUP BY DcDutiesId
	            HAVING COUNT(EmployeeId) > 2) AS DutiesCount",

            @"SELECT COUNT(StudyGroupId) FROM (SELECT StudyGroupId FROM Student 
	            GROUP BY StudyGroupId
	            HAVING COUNT(StudentId) > 5) AS StudentCount",

            @"SELECT COUNT(StudentId) FROM (SELECT StudentId FROM Exam
	            GROUP BY StudentId
	            HAVING COUNT(DcDisciplineId) > 1) AS CountStudent",

            @"SELECT StudentId FROM (SELECT StudentId FROM Exam
	            GROUP BY StudentId
	            HAVING AVG(Mark) = 5) AS StudentCount",

            @"SELECT DISTINCT EmployeeId FROM (SELECT EmployeeId, DcDiscipline.Name FROM Exam, DcDiscipline
                WHERE Exam.DcDisciplineId = DcDiscipline.DcDisciplineId
                AND DcDiscipline.DcDisciplineId IN (SELECT DcDisciplineId FROM DcDiscipline
                WHERE DcDiscipline.Name = N'Математика' OR DcDiscipline.Name = N'Физика')) AS EMP",
        };
    }
}