﻿using GradeBook.Enums;
using System;
using System.Linq;
using System.Collections.Generic;

namespace GradeBook.GradeBooks

{
    public class RankedGradeBook:BaseGradeBook
    {
        public RankedGradeBook(string name):base(name)
        {
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averagegrade)
        {
            if (Students.Count<5)
            {
                InvalidOperationException invalidOperationException = new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
                throw invalidOperationException;
            }
            var threshold = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();
            if (grades[threshold - 1] <= averagegrade)
                return 'A';
            else if (grades[threshold*2 - 1] <= averagegrade)
                return 'B';
            else if (grades[threshold*3 - 1] <= averagegrade)
                return 'C';
            else if (grades[threshold*4 - 1] <= averagegrade)
                return 'D';
            else
                return 'F';
        }
    }
}
