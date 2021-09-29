using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using lib;

namespace app
{
  class Program
  {
    static void Main(string[] args)
    {
      // creating an object graph
      using var db = new Database();
      Student s = new Student("Janet", "janet@aol.com");
      s.Books.AddRange(new Book[] {
        new () { SerialNumber = "0001", Title = "Algebra I" },
        new () { SerialNumber = "0002", Title = "Chemistry I" }
      });
      Teacher t = new Teacher("Wallace");
      Klass k = new Klass("MAT-104") { Description = "Logic", Department = "Mathematics" };
      k.Teachers.Add(t);

      db.AddRange(s, k); // only adding 2 object, which are the root objects in a graph
      db.SaveChanges();

      // registering a student with a class
      Registration r = s.Register(k);
      db.Add(r);
      db.SaveChanges();
      // updating a student's grade
      r = s.UpdateGrade("MAT-104", 79.99);
      db.SaveChanges();

      // debug query with extension method
      // projection of result into anonymous object
      var query = from stu in db.Students select new { Key = stu.Id, Name = stu.Name };
      var queryStr = query.ToQueryString();
      Console.WriteLine($"query: {queryStr}");
      foreach (var q in query) Console.WriteLine($"From Query: {q}");

      // finding bob and including all of bob's classes which implicitly also gets registrations
      var bob = db.Students.Where(s => s.Name == "Bob").Include(s => s.Klasses).First();
      foreach (var br in bob.Registrations)
        Console.WriteLine($"{br.Student.Name} took {br.Klass.Name} and made an {br.Grade}");

      // finding chem-101 and including all of its students which implicitly also gets registrations
      var chem = db.Klasses.Where(k => k.Name == "CHEM-101").Include(k => k.Students).First();
      foreach (var chemr in chem.Registrations)
        Console.WriteLine($"{chemr.Student.Name} took {chemr.Klass.Name} and made an {chemr.Grade}");

      // get a list of names of classes that Mrs. Jackson teaches
      // need to include Klasses in the query
      var listOfKlassNames = db.Teachers
      .Where(t => t.Name == "Mrs. Jackson")
      .Include(t => t.Klasses)
      .First()
      .Klasses
      .Select(k => k.Name);
      listOfKlassNames.ToList().ForEach(name => Console.WriteLine(name));

      // get student email that owns a particular book
      var studentEmail = db.Books.Where(b => b.SerialNumber == "0005").First().Owner.Email;
      Console.WriteLine($"The email address of the student using book 0005 is : {studentEmail}");

      // a fairly involved query
      db.Teachers
      .Where(t => t.Name == "Mrs. Jackson")
      .Include(t => t.Klasses)
      .ThenInclude(k => k.Registrations)
      .First()
      .Klasses
      .SelectMany(k => k.Registrations, (klass, registration) => new { klass.Name, registration.Grade })
      .ToList()
      .ForEach(o => Console.WriteLine($"Class : {o.Name}, Grade : {o.Grade}"));
    }
  }
}
