using System.Collections.Generic;

namespace App.Models.Queries
{
    public static class KR2_queries
    {
        public static List<string> GetQueries = new List<string>
        {
            "SELECT * FROM DcDiscipline",
            "SELECT * FROM StudyGroup",
            "SELECT * FROM DcDuties",
            "SELECT Surname, Name, Patronymic, Oklad FROM Employee",
            "SELECT DateExam, Mark, StudentId, EmployeeId FROM Exam",

            @"SELECT Surname, Name, Petronymic, Stipendiya, StudentId FROM Student
            WHERE Stipendiya < 300",

            @"SELECT Surname, Name, Petronymic, Stipendiya, StudentId, BirthdayCity FROM Student
            WHERE Stipendiya > 500 AND BirthdayCity = N'Киев'",

            @"SELECT Surname, Name, Petronymic, StudentId, BirthdayCity FROM Student
            WHERE BirthdayCity != N'Киев'",

            @"SELECT Surname, Name, Petronymic, StudentId, BirthdayCity FROM Student
            WHERE BirthdayCity = N'Киев' OR BirthdayCity LIKE N'Тер%'",

            @"SELECT Surname, Name, Petronymic, Stipendiya, StudentId, BirthdayCity FROM Student
            WHERE(Stipendiya = 300 AND BirthdayCity = N'Киев') OR BirthdayCity = N'Черкассы'",

            @"SELECT Surname, Name, Petronymic, Birthday, StudentId FROM Student
            WHERE Birthday BETWEEN N'1989-01-01' AND N'1990-12-31'",

            @"SELECT Surname, Name, Petronymic, Birthday, StudentId, Stipendiya FROM Student
            WHERE Birthday BETWEEN N'1989-01-01' AND N'1990-12-31'
            AND Stipendiya >= 600",

            @"SELECT Surname, Name, Petronymic, Birthday, StudentId FROM Student
            WHERE Birthday NOT BETWEEN N'1989-01-01' AND N'1990-12-31'",

            @"SELECT* FROM Exam
            WHERE(DcDisciplineId = 1 OR DcDisciplineId = 2 OR DcDisciplineId = 3)
            AND(EmployeeId = 1 OR EmployeeId = 8)",

            @"SELECT Surname, Name, Petronymic, Stipendiya, StudentId, BirthdayCity FROM Student
            WHERE Stipendiya = 300 AND(BirthdayCity = N'Киев' OR BirthdayCity = N'Черкассы')",

            @"SELECT* FROM Employee
            WHERE Surname LIKE N'Пет%'",

            @"SELECT* FROM Employee
            WHERE Birthday LIKE N'1966%'",

            @"SELECT* FROM Employee
            WHERE Birthday LIKE N'%-05-%'",

            @"SELECT* FROM Employee
            WHERE Birthday LIKE N'%05%'",

            @"SELECT* FROM Employee
            WHERE Birthday LIKE N'%-05-%'
            AND Nadbavka >= 500",

            @"SELECT* FROM Student
            WHERE(Petronymic IS NOT NULL) AND Stipendiya<> 500",

            @"SELECT* FROM Student
            WHERE Petronymic IS NULL",

            @"SELECT Surname, Employee.Name, Patronymic, EmployeeId FROM Employee, DcDuties
            WHERE (Patronymic IS NOT NULL) AND(Employee.DcDutiesId = DcDuties.DcDutiesId)
            AND(DcDuties.Name = N'Профессор')",

            @"SELECT DISTINCT Surname, Name, Patronymic FROM Employee
            ORDER BY Surname, Name, Patronymic",

            @"SELECT DISTINCT Stipendiya FROM Student
            ORDER BY Stipendiya DESC",

            @"SELECT COUNT(*) FROM Student",
            @"SELECT COUNT(*) FROM(SELECT DISTINCT Surname, Name, Petronymic FROM Student) AS Student",
            @"SELECT COUNT(DISTINCT Name) AS Name FROM Student",

            @"SELECT

                COUNT(DISTINCT Name) AS Name,
                COUNT(DISTINCT Surname) AS Surname
            FROM Student",


            @"SELECT COUNT(DISTINCT Petronymic) AS Patronymic FROM Student",

            @"SELECT COUNT(*) FROM Student WHERE Stipendiya = 300",

            @"SELECT COUNT(*) AS Employee, MIN(Oklad) AS MinOklad, MAX(Oklad) AS MaxOklad, AVG(Oklad) AS AvgOklag FROM Employee",

            @"SELECT DcDutiesId, COUNT(DcDutiesId) AS KolDuties,
                MIN(Oklad + Nadbavka) AS MinPayment,
                  MAX(Oklad + Nadbavka) AS MaxPayment,
                    AVG(Oklad + Nadbavka) AS AvgPayment
            FROM Employee GROUP BY DcDutiesId ORDER BY DcDutiesId",

            @"SELECT DcDutiesId, COUNT(DcDutiesId) AS KolDuties,
                MIN(Oklad + Nadbavka) AS MinPayment,
                  MAX(Oklad + Nadbavka) AS MaxPayment,
                    AVG(Oklad + Nadbavka) AS AvgPayment,
                      DataVuplatu
            FROM Employee GROUP BY DcDutiesId, DataVuplatu ORDER BY DcDutiesId",

            @"SELECT DcDutiesId, COUNT(DcDutiesId) AS KolDuties,
                MIN(Oklad + Nadbavka) AS MinPayment,
                  MAX(Oklad + Nadbavka) AS MaxPayment,
                    AVG(Oklad + Nadbavka) AS AvgPayment,
                      DataVuplatu
            FROM Employee
            WHERE DcDutiesId NOT IN(3, 10)
            GROUP BY DcDutiesId, DataVuplatu
            ORDER BY DcDutiesId",

            @"SELECT DISTINCT Surname From Student",

            @"SELECT Name, COUNT(*) AS Quantity
            FROM Student
            GROUP BY Name
            HAVING NAME LIKE N'К%'",

            @"SELECT DISTINCT DcDutiesId AS DutiesID
            FROM Employee
            WHERE(Oklad+Nadbavka) > 5000",

            @"SELECT BirthdayCity, COUNT(DcDutiesID) AS CountEmployee
            FROM Employee
            GROUP BY BirthdayCity
            ORDER BY BirthdayCity",

            @"SELECT Mark, COUNT(DISTINCT StudentId) AS CountStudent, COUNT(DISTINCT DcDisciplineId) AS CountDiscipline
            FROM Exam
            GROUP BY Mark",

            @"SELECT DcDiscipline.Name, COUNT(StudentId) AS CountStudent
            FROM Exam, DcDiscipline
            WHERE Mark > 2 AND DcDiscipline.DcDisciplineId = Exam.DcDisciplineId
            GROUP BY DcDiscipline.Name",

            @"SELECT DcDiscipline.Name, COUNT(StudentId) As CountStudent
            FROM Exam, DcDiscipline
            WHERE Mark = 5 AND DcDiscipline.DcDisciplineId = Exam.DcDisciplineId
            GROUP BY DcDiscipline.Name",

            @"SELECT DateExam AS Дата, COUNT(ExamId) AS [Количество экзаменов]
            FROM Exam
            GROUP BY DateExam
            ORDER BY DateExam",

            @"SELECT DateExam AS Дата, COUNT(ExamId) AS [Количество экзаменов]
            FROM Exam
            GROUP BY DateExam
            HAVING COUNT(ExamId) > 5
            ORDER BY DateExam",

            @"SELECT * FROM Student
            WHERE BirthdayCity = N'Киев' AND Stipendiya <= 500",

            @"SELECT (Surname + N' N' + Employee.Name + N' N' + Patronymic) AS ФИО,
                Birthday AS[День рождения],
                Oklad AS Оклад,
                Nadbavka AS Надбавка,
                DcDuties.Name AS Должность
            FROM Employee, DcDuties
            WHERE Birthday BETWEEN N'1945-01-01' AND N'1965-12-31'
            AND Oklad + Nadbavka >= 5000
            AND DcDuties.DcDutiesId = Employee.DcDutiesId",

            @"SELECT BirthdayCity AS Город, AVG(Oklad+Nadbavka) AS[Среднии выплаты]
            FROM Employee
            WHERE Birthday BETWEEN N'1945-01-01' AND N'1965-12-31'
            GROUP BY BirthdayCity",


            @"SELECT COUNT(Patronymic) FROM Employee",

            @"SELECT COUNT(DISTINCT Patronymic) FROM Employee",

            @"SELECT COUNT(EmployeeId) FROM Employee
            WHERE Patronymic IS NULL",

            @"SELECT AVG(Oklad) AS[Средний оклад] FROM Employee",

            @"SELECT SUM(Oklad)/COUNT(EmployeeId) AS[Средний оклад] FROM Employee",

            @"SELECT MAX(Oklad) AS MaxOklad, MIN(Oklad) AS MinOklad,
             MAX(Oklad)+100 AS MaxOklad_100, MIN(Oklad)+100 AS MinOklad_100
            FROM Employee",

            @"SELECT StudentId, AVG(Mark) AS AvgMark
            FROM Exam
            GROUP BY StudentId
            HAVING AVG(Mark) > 3",

            @"SELECT EmployeeId, Surname, Name, Patronymic, SUM(Oklad + Nadbavka) AS Vyplaty
            FROM Employee
            GROUP BY EmployeeId, Surname, Name, Patronymic
            HAVING SUM(Oklad+Nadbavka) > 4300",

            @"SELECT DcDutiesId, AVG(Oklad + ISNULL(Nadbavka, 35)) AS Vyplaty
            FROM Employee
            GROUP BY DcDutiesId
            HAVING AVG(Oklad+Nadbavka) > 4500",

            @"SELECT Surname + Name + Patronymic AS ФИО, BirthdayCity AS Город
            FROM Employee
            GROUP BY Surname, Name, Patronymic, BirthdayCity
            HAVING AVG(Oklad) = AVG(Oklad+Nadbavka)"
        };
    }
}
