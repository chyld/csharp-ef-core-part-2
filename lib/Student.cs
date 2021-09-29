using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib
{
  public class Student
  {
    public int Id { get; set; }  // primary key
    [Required]
    [StringLength(22)]
    public string Name { get; set; } // required field
    [Required]
    [Column(TypeName = "varchar(35)")]
    public string Email { get; set; } // required field with explicit column type
    public List<Klass> Klasses { get; set; }
    public List<Registration> Registrations { get; set; }
    public List<Book> Books { get; set; }

    public Student(string name, string email)
    {
      Name = name;
      Email = email;
      Books = new();
      Klasses = new();
    }

    public Registration Register(Klass k)
    {
      return new() { Student = this, Klass = k };
    }

    public Registration UpdateGrade(string klassName, double grade)
    {
      var registration = this.Registrations.Where(r => r.Klass.Name == klassName).First();
      registration.Grade = grade;
      return registration;
    }
  }
}
















