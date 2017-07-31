-- SCHEMA
DROP TABLE IF EXISTS CourseEnrollment;
DROP TABLE IF EXISTS Courses;
DROP SEQUENCE IF EXISTS course_id_seq;
DROP TABLE IF EXISTS Students;
DROP SEQUENCE IF EXISTS student_id_seq;

CREATE SEQUENCE student_id_seq;
CREATE TABLE Students (
    StudentID int NOT NULL DEFAULT NEXTVAL('student_id_seq'),
    Name varchar(100) NOT NULL,
    PRIMARY KEY (StudentID)
);

CREATE SEQUENCE course_id_seq;
CREATE TABLE Courses (
    CourseID int NOT NULL DEFAULT NEXTVAL('course_id_seq'),
    CourseName varchar(100) NOT NULL,
    ProfessorID int NOT NULL,
    PRIMARY KEY (CourseID)
);

CREATE TABLE CourseEnrollment (
    CourseID int NOT NULL,
    StudentID int NOT NULL,
    Grade int NOT NULL,
    Term int NOT NULL,
    FOREIGN KEY (CourseID) REFERENCES Courses (CourseID),
    FOREIGN KEY (StudentID) REFERENCES Students (StudentID)
);

-- DATA
INSERT INTO Students (
    Name
)
VALUES 
('Benson Liam'),
('Forrest Pip'),
('Jemmy Rain'),
('Milford Rocky'),
('Davie Virgil'),
('Quentin Allyn'),
('Brand Jefferson'),
('Freeman Clifford'),
('Blair Kenith'),
('Gresham Lesley'),
('Tiger Sylvanus'),
('Alvin Maitland'),
('Tyler Dederick'),
('Marcus Harvie'),
('Tristin Clayton'),
('Everette Shelly'),
('Jewell Kayden'),
('Rigby Ross'),
('Johnnie Lex'),
('Bentley Milton');

INSERT INTO Courses (
    CourseName, ProfessorID
)
VALUES
('Mathematics', 1),
('Physics', 2),
('Telecommunications', 3);

INSERT INTO CourseEnrollment (
    CourseID, StudentID, Grade, Term
)
VALUES
(1, 1, 33, 2),
(1, 2, 22, 1),
(1, 3, 9, 2),
(1, 4, 27, 1),
(1, 5, 81, 2),
(1, 6, 14, 2),
(1, 7, 57, 2),
(1, 8, 39, 2),
(1, 9, 18, 1),
(1, 10, 66, 1),
(1, 11, 14, 2),
(1, 12, 75, 2),
(1, 13, 34, 1),
(1, 14, 82, 2),
(1, 15, 86, 1),
(1, 16, 72, 3),
(1, 17, 68, 1),
(1, 18, 78, 3),
(1, 19, 98, 3),
(1, 20, 43, 2),
(2, 1, 72, 2),
(2, 2, 31, 3),
(2, 3, 11, 2),
(2, 4, 37, 2),
(2, 5, 92, 3),
(2, 6, 32, 2),
(2, 7, 1, 2),
(2, 8, 68, 3),
(2, 9, 78, 3),
(2, 10, 67, 3),
(2, 11, 52, 3),
(2, 12, 43, 3),
(2, 13, 92, 1),
(2, 14, 74, 2),
(2, 15, 64, 2),
(2, 16, 55, 1),
(2, 17, 68, 1),
(2, 18, 48, 2),
(2, 19, 17, 3),
(2, 20, 39, 3),
(3, 1, 95, 1),
(3, 2, 48, 1),
(3, 3, 78, 1),
(3, 4, 95, 1),
(3, 5, 40, 3),
(3, 6, 12, 1),
(3, 7, 18, 2),
(3, 8, 93, 3),
(3, 9, 9, 2),
(3, 10, 88, 3),
(3, 11, 65, 3),
(3, 12, 86, 2),
(3, 13, 20, 3),
(3, 14, 85, 3),
(3, 15, 12, 1),
(3, 16, 68, 3),
(3, 17, 33, 3),
(3, 18, 80, 1),
(3, 19, 38, 1),
(3, 20, 92, 3);

-- QUERIES

-- SOLUTION 1
SELECT Students.*, SUM(CourseEnrollment.Grade) AS Total, ROUND(AVG(CourseEnrollment.Grade), 2) AS average
FROM Students
JOIN CourseEnrollment USING (StudentID)
GROUP BY Students.StudentID
ORDER BY Total DESC
LIMIT (
    SELECT COUNT(*) * 0.1
    FROM Students
);