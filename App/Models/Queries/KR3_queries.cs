using System.Collections.Generic;

namespace App.Models.Queries
{
    public class KR3_queries
    {
        public static List<string> GetQueries = new List<string>
        {
            @"SELECT * FROM DcDuties
            WHERE Name = N'Доцент'",

            @"SELECT * FROM DcDiscipline
            WHERE Name LIKE N'Англ%'",

            @"SELECT DISTINCT Surname, Name, Patronymic FROM Employee
            ORDER BY Surname, Name, Patronymic",

            @"SELECT Name, DcSubdivisionId FROM DcDuties
            ORDER BY Name",

            @"SELECT DcDuties.Name AS Duties, DcSubdivision.Name AS Subdivision
            FROM DcDuties CROSS JOIN DcSubdivision",

            @"SELECT DcSubdivision.Name AS Subdivision, StudyGroup.Name AS StudyGroup
            FROM DcSubdivision CROSS JOIN StudyGroup",

            @"SELECT A.Name, B.Name
            FROM StudyGroup AS A CROSS JOIN DcSubdivision AS B",

            @"SELECT Student.Surname, Student.Name, Student.Petronymic, StudyGroup.Name AS StudyGroup
            FROM Student, StudyGroup
            WHERE Student.StudyGroupId = StudyGroup.StudyGroupId",

            @"SELECT A.Surname, A.Name, A. Petronymic, B.Name AS StudyGroup
            FROM Student AS A, StudyGroup AS B
            WHERE A.StudyGroupId = B.StudyGroupId",

            @"SELECT Student.Surname, Student.Name, Student.Petronymic, StudyGroup.Name AS StudyGroup
            FROM Student JOIN StudyGroup ON Student.StudyGroupId = StudyGroup.StudyGroupId",

            @"SELECT A.Surname, A.Name, A.Petronymic, B.Name AS StudyGroup
            FROM Student AS A
            JOIN StudyGroup AS B
            ON A.StudyGroupId = B.StudyGroupId",

            @"SELECT DcDuties.Name, DcSubdivision.Name
            FROM DcDuties, DcSubdivision
            WHERE DcDuties.DcSubdivisionId = DcSubdivision.DcSubdivisionId
            AND DcSubdivision.Name = N'Кафедра 1'",

            @"SELECT D.Name AS Duties, S.Name AS Subdivision
            FROM DcDuties AS D, DcSubdivision AS S
            WHERE D.DcSubdivisionId = S.DcSubdivisionId
            AND S.Name = N'Кафедра 1'",

            @"SELECT DcDuties.Name, DcSubdivision.Name
            FROM DcDuties JOIN DcSubdivision
            ON DcDuties.DcSubdivisionId = DcSubdivision.DcSubdivisionId
            WHERE DcSubdivision.Name = N'Кафедра 1'",

            @"SELECT D.Name AS Duties, S.Name AS Subdivision
            FROM DcDuties AS D JOIN DcSubdivision AS S
            ON D.DcSubdivisionId = S.DcSubdivisionId
            WHERE S.Name = N'Кафедра 1'",

            @"SELECT
                S.Surname + N' ' + S.Name + N' ' + ISNULL(S.Petronymic, N'') AS FIO,
                G.Name AS GroupName,
                S.BirthdayCity,
                S.Stipendiya
            FROM Student AS S

                JOIN StudyGroup AS G ON S.StudyGroupId = G.StudyGroupId
            WHERE S.BirthdayCity IN ('Ялта', N'Луцк')
            ORDER BY FIO",

            @"SELECT
                S.Surname + N' ' + S.Name + N' ' + ISNULL(S.Petronymic, N'') AS FIO,
                G.Name As GroupName,
                S.BirthdayCity,
                S.Birthday,
                ISNULL(S.Stipendiya, 0) AS Stipendiya
            FROM Student AS S
                JOIN StudyGroup AS G ON S.StudyGroupId = G.StudyGroupId
            WHERE S.Stipendiya BETWEEN N'620' AND N'800'
                OR S.Stipendiya IS NULL
            ORDER BY Stipendiya, FIO",

            @"SELECT
                S.Surname + N' ' + S.Name + N' ' + ISNULL(S.Petronymic, N'') AS FIO_ST,
                E.Mark,
                D.Name AS Discipline,
                EM.Surname + N' ' + EM.Name + N' ' + ISNULL(EM.Patronymic, N'') AS FIO_EMP,
                DUT.Name AS Duties
            FROM Student AS S
                JOIN Exam AS E ON S.StudentId = E.StudentId
                JOIN DcDiscipline AS D ON E.DcDisciplineId = D.DcDisciplineId
                JOIN Employee AS EM ON E.EmployeeId = EM.EmployeeId
                JOIN DcDuties AS DUT ON EM.DcDutiesId = DUT.DcDutiesId
            ORDER BY FIO_ST",

            @"SELECT
                E.Surname + N' ' + E.Name + N' ' + ISNULL(E.Patronymic, N'') AS FIO,
                D.Name AS Duties,
                S.Name  AS Subdivision,
                E.Oklad + E.Nadbavka AS Vuplatu,
                E.DataVuplatu
            FROM Employee AS E
                JOIN DcDuties AS D ON E.DcDutiesId = D.DcDutiesId
                JOIN DcSubdivision AS S ON D.DcSubdivisionId = S.DcSubdivisionId
            WHERE (E.Oklad + E.Nadbavka) > 3400
                AND E.DataVuplatu BETWEEN N'2013-01-01' AND N'2013-04-01'
            ORDER BY Vuplatu DESC",

            @"SELECT
                E.Surname + N' ' + E.Name + N' ' + ISNULL(E.Patronymic, N'') AS FIO,
                D.Name AS Duties,
                S.Name AS Subdivision
            FROM Employee AS E
                JOIN DcDuties AS D ON E.DcDutiesId = D.DcDutiesId
                JOIN DcSubdivision AS S ON D.DcSubdivisionId = S.DcSubdivisionId
            WHERE S.Name NOT IN ('Кафедра 1', N'Кафедра 2')
            ORDER BY FIO",

            @"SELECT DISTINCT
                E.Surname + N' ' + E.Name + N' ' + ISNULL(E.Patronymic, N'') AS FIO,
                D.Name AS Duties,
                S.Name AS Subdivision,
                B.Name AS Discipline,
                G.Name AS GroupName
            FROM Exam AS A
                JOIN Employee AS E ON A.EmployeeId = E.EmployeeId
                JOIN DcDuties AS D ON E.DcDutiesId = D.DcDutiesId
                JOIN DcSubdivision AS S ON D.DcSubdivisionId = S.DcSubdivisionId
                JOIN DcDiscipline AS B ON A.DcDisciplineId = B.DcDisciplineId
                JOIN StudyGroup AS G ON S.DcSubdivisionId = G.DcSubdivisionId
            ORDER BY FIO",

            @"SELECT
                G.Name AS GroupName,
                COUNT(S.StudentId) AS Students
            FROM StudyGroup AS G
                JOIN Student AS S ON G.StudyGroupId = S.StudyGroupId
            GROUP BY G.Name",

            @"SELECT
                G.Name AS GroupName,
                COUNT(S.StudentId) AS Students
            FROM StudyGroup AS G
                JOIN Student AS S ON S.StudyGroupId = G.StudyGroupId
                JOIN Exam AS E ON S.StudentId = E.StudentId
            GROUP BY G.Name, E.Mark
            HAVING E.Mark = 5",

            @"SELECT
                E.Surname,
                D.Name AS Duties,
                S.Name AS Subdivision,
                COUNT(DISTINCT G.StudyGroupId) AS Groups
            FROM Employee AS E
                JOIN DcDuties AS D ON E.DcDutiesId = D.DcDutiesId
                JOIN DcSubdivision AS S ON D.DcSubdivisionId = S.DcSubdivisionId
                JOIN Exam AS EX ON EX.EmployeeId = E.EmployeeId
                JOIN Student AS ST ON EX.StudentId = ST.StudentId
                JOIN StudyGroup AS G ON G.StudyGroupId = ST.StudyGroupId
            GROUP BY E.Surname, D.Name, S.Name
            HAVING S.Name = N'Кафедра 1'
            ORDER BY E.Surname",

            @"SELECT
                D.Name AS Discipline,
                E.Surname + N' ' + E.Name + N' ' + ISNULL(E.Patronymic, N'') AS FIO,
                EX.DateExam
            FROM Exam AS EX
                JOIN Employee AS E ON EX.EmployeeId = E.EmployeeId
                JOIN DcDiscipline AS D ON D.DcDisciplineId = EX.DcDisciplineId
            WHERE EX.DateExam BETWEEN N'2013-06-01' AND N'2013-06-07'
            GROUP BY D.Name, E.Surname, E.Name, E.Patronymic, EX.DateExam
            ORDER BY D.Name, FIO",

            @"SELECT
                D.Name AS Duties,
                ISNULL(S.Name, N'неопределенно') AS Subdivision
            FROM DcDuties AS D
                LEFT JOIN DcSubdivision AS S ON D.DcSubdivisionId = S.DcSubdivisionId
            ORDER BY Duties",

            @"SELECT
                S.Name AS Subdivision,
                ISNULL(G.Name, N'неопределенно') AS GroupName
            FROM DcSubdivision AS S
                LEFT JOIN StudyGroup AS G ON S.DcSubdivisionId = G.DcSubdivisionId
            ORDER BY Subdivision"
        };
    }
}
