Average Scores:
For each student, compute the average of their scores using Average() and format it to 2 decimal places with .ToString("F2").
Grades Assignment:
Use a helper method GetGrade to assign grades (A, B, C) based on score thresholds.
Project each student's scores into subjects with corresponding grades.
Student Ranking:
Order students by their average scores in descending order.
Assign ranks using the index from Select (adjusted by +1 to start from 1).
Best Students Per Subject:
Flatten student scores into a list of subject-score entries.
Group by subject and select the student with the highest score in each group using OrderByDescending and First().
