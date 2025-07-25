using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public string Name { get; set; }
    public List<SubjectScore> Scores { get; set; }
}

public class SubjectScore
{
    public string Subject { get; set; }
    public int Score { get; set; }
}

public class Program
{
    public static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student
            {
                Name = "TAYO",
                Scores = new List<SubjectScore>
                {
                    new SubjectScore { Subject = "Mathematics", Score = 85 },
                    new SubjectScore { Subject = "English", Score = 70 },
                    new SubjectScore { Subject = "Yoruba", Score = 90 }
                }
            },
            new Student
            {
                Name = "FUNKE",
                Scores = new List<SubjectScore>
                {
                    new SubjectScore { Subject = "Mathematics", Score = 75 },
                    new SubjectScore { Subject = "English", Score = 60 },
                    new SubjectScore { Subject = "Yoruba", Score = 85 }
                }
            },
            new Student
            {
                Name = "NKECHI",
                Scores = new List<SubjectScore>
                {
                    new SubjectScore { Subject = "Mathematics", Score = 60 },
                    new SubjectScore { Subject = "English", Score = 50 },
                    new SubjectScore { Subject = "Yoruba", Score = 40 }
                }
            }
        };

        // 1. Compute average score per student (formatted to 2 decimal places)
        var studentAverages = students
            .Select(s => new
            {
                Name = s.Name,
                AverageScore = s.Scores.Average(ss => ss.Score).ToString("F2")
            });

        Console.WriteLine("Average Scores:");
        foreach (var student in studentAverages)
        {
            Console.WriteLine($"{student.Name}: {student.AverageScore}");
        }

        // 2. Grade each student's score per subject
        var studentGrades = students
            .Select(s => new
            {
                s.Name,
                Grades = s.Scores.Select(ss => new
                {
                    ss.Subject,
                    Grade = GetGrade(ss.Score)
                })
            });

        Console.WriteLine("\nGrades:");
        foreach (var student in studentGrades)
        {
            foreach (var grade in student.Grades)
            {
                Console.WriteLine($"{student.Name} - {grade.Subject}: {grade.Grade}");
            }
        }

        // 3. Rank students based on average scores
        var rankedStudents = students
            .Select(s => new
            {
                s.Name,
                Average = s.Scores.Average(ss => ss.Score)
            })
            .OrderByDescending(s => s.Average)
            .Select((s, index) => new
            {
                Rank = index + 1,
                s.Name,
                s.Average
            });

        Console.WriteLine("\nStudent Rankings:");
        foreach (var student in rankedStudents)
        {
            Console.WriteLine($"{student.Rank}st: {student.Name} (Average: {student.Average:F2})");
        }

        // 4. Identify best student per subject
        var bestStudentsPerSubject = students
            .SelectMany(s => s.Scores.Select(ss => new { s.Name, ss.Subject, ss.Score }))
            .GroupBy(x => x.Subject)
            .Select(g => new
            {
                Subject = g.Key,
                BestStudent = g.OrderByDescending(x => x.Score).First()
            });

        Console.WriteLine("\nBest Students Per Subject:");
        foreach (var subject in bestStudentsPerSubject)
        {
            Console.WriteLine($"Best in {subject.Subject} is {subject.BestStudent.Name}");
        }
    }

    private static string GetGrade(int score)
    {
        if (score >= 60) return "A";
        if (score >= 40) return "B";
        return "C";
    }
}