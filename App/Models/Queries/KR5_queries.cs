using System.Collections.Generic;

namespace App.Models.Queries
{
    public class KR5_queries
    {
        public static List<string> GetQueries = new List<string>
        {
            @"SELECT Surname, Name, Petronymic, BirthdayCity, BirthDay FROM Student
            UNION ALL SELECT Surname, Name, Patronymic, BirthdayCity, BirthDay FROM Employee",

            @"SELECT Surname, Name, Petronymic, BirthdayCity, BirthDay FROM Student
            UNION SELECT Surname, Name, Patronymic, BirthdayCity, BirthDay FROM Employee",

            @"SELECT BirthdayCity FROM Employee
            EXCEPT SELECT BirthdayCity FROM Student",

            @"SELECT BirthdayCity FROM Employee
            INTERSECT SELECT BirthdayCity FROM Student",

            @"UPDATE Student SET RecordBook = N'ИК-24-03-01'
            WHERE Surname = N'Персиков'",

            @"UPDATE Student SET BirthdayCity = N'Прага'
            WHERE StudentId BETWEEN 5 AND 10",

            @"UPDATE Employee SET Oklad *= 1.25
            WHERE DcDutiesId IN (SELECT DcDutiesId FROM DcDuties WHERE Name = N'Профессор' OR Name = N'Доцент')",

            @"UPDATE Employee SET Oklad *= 1.07
            WHERE Oklad IN (SELECT MIN(Oklad) FROM Employee)",

            @"UPDATE Employee SET Oklad *= 2
            WHERE Oklad IN (SELECT MAX(OKLAD) FROM Employee)",

            @"UPDATE Student SET DateApl = N'2003-09-01'
            WHERE StudentId IN(SELECT StudentId FROM Student)",

            @"UPDATE Student SET DateApl = N'2005-09-01'
            WHERE StudyGroupId IN(SELECT StudyGroupId FROM StudyGroup WHERE Name = N'ИК-11')",

            @"DELETE FROM Exam WHERE StudentId > 3 AND StudentId< 5",

            @"DELETE FROM Exam WHERE StudentId IN (SELECT StudentId FROM Student WHERE BirthdayCity = N'Одесса')",

            @"DELETE FROM Student WHERE StudentId > 4 AND StudentId< 8",
        };
    }
}