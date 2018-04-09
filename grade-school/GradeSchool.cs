using System;
using System.Collections.Generic;
using System.Linq;

public class School
{    
    public List<Enrollment> Enrollments { get; set; }

    public void Add(string student, int grade)
    {
        var newEnrollment = new Enrollment { Student = student, Grade = grade };

        if (this.Enrollments == null)
        {
            this.Enrollments = new List<Enrollment>();
        }

        this.Enrollments.Add(newEnrollment);
    }

    public IEnumerable<string> Roster()
    {
       return this.Enrollments
            .OrderBy(e => e.Grade)
            .ThenBy(e => e.Student)
            .Select(e => e.Student);
    }

    public IEnumerable<string> Grade(int grade)
    {
        if (this.Enrollments == null)
        {
            return new List<string>();
        }
        else
        {
            return this.Enrollments
                .Where(e => e.Grade == grade)
                .OrderBy(e => e.Student)
                .Select(e => e.Student);
        }
    }
}
public class Enrollment
{
    public string Student { get; set; }
    public int Grade { get; set; }
}